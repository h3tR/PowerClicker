using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;
using System.Collections.Concurrent;

namespace WindowsFormsApp1
{
    public partial class PowerClicker : Form
    {
        private MouseSide HoldDisableSide;
        private bool HotkeyChangeMoused = false;
        private bool SetCoords = false;
        private uint HoldX;
        private uint HoldY;
        private TimeHandler RegularTime = new TimeHandler(0, 1, 0);
        private TimeHandler HoldTime = new TimeHandler(0, 0, 999);
        // debounce for CompleteTimeOp function
        private bool InTimeOp = false;
        // if true will set hold timer to the regular timer -1 millisecond 
        private bool requireHoldTimeInitVal = false;

        private bool ClickingEnabled = false;
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int ToUnicode(uint virtualKeyCode, uint scanCode, byte[] keyboardState, System.Text.StringBuilder receivingBuffer, int bufferSize, uint flags);

        private int timesdone = 0;
        enum MouseSide
        {
            LEFT,
            RIGHT,
            BOTH,
            MIDDLE,
            ALL
        }
        // Handles Time operations: creating TimeHandlers, validating values and writing to the input fields on the GUI
        private void completeTimeOp()
        {
            if (!InTimeOp)
            {
                InTimeOp = true;

                this.RegularTime = new TimeHandler((int)this.MilSecInput.Value, (int)this.SecInput.Value, (int)this.MinInput.Value);
                if (this.RegularTime.TotalMillis < 1)
                {
                    this.RegularTime.TotalMillis = 1;
                    this.RegularTime.ValidateValue();
                }

                if (this.MinInput.Value != this.RegularTime.Minutes || this.SecInput.Value != this.RegularTime.Seconds || this.MilSecInput.Value != this.RegularTime.MilliSeconds)
                {
                    this.MinInput.Value = this.RegularTime.Minutes;
                    this.SecInput.Value = this.RegularTime.Seconds;
                    this.MilSecInput.Value = this.RegularTime.MilliSeconds;

                }
                if (this.HoldSelect.Checked)
                {
                    this.HoldTime = new TimeHandler((int)this.HoldMilSecInput.Value, (int)this.HoldSecInput.Value, (int)this.HoldMinInput.Value);
                    if (requireHoldTimeInitVal)
                    {
                        this.HoldTime.TotalMillis = this.RegularTime.TotalMillis - 1;
                        this.HoldTime.ValidateValue();
                        requireHoldTimeInitVal=false;
                    }

                    if (this.HoldTime.TotalMillis < 1)
                    {
                        this.HoldTime.TotalMillis = 1;
                        this.HoldTime.ValidateValue();
                    }
                    else if (this.HoldTime.TotalMillis >= RegularTime.TotalMillis)
                    {
                        this.HoldTime.TotalMillis = RegularTime.TotalMillis - 1;
                        this.HoldTime.ValidateValue();
                    }
                    if (this.HoldMinInput.Value != this.HoldTime.Minutes || this.HoldSecInput.Value != this.HoldTime.Seconds || this.HoldMilSecInput.Value != this.HoldTime.MilliSeconds)
                    {
                        this.HoldMinInput.Value = this.HoldTime.Minutes;
                        this.HoldSecInput.Value = this.HoldTime.Seconds;
                        this.HoldMilSecInput.Value = this.HoldTime.MilliSeconds;
                    }

                }
                InTimeOp = false;
            }
        }
        // Generates string from given keycode
        private string getUnicodeFromKeycode(Keys e)
        {
            StringBuilder charPressed = new StringBuilder(256);
            ToUnicode((uint)e, 0, new byte[256], charPressed, charPressed.Capacity, 0);
            return charPressed.ToString();
        }
        private void mouseClick(object sender, MouseEventArgs e)
        {
            if (SetCoords && e.Button == MouseButtons.Left)
            {
                SetCoords = false;
                this.XInput.Value = Cursor.Position.X;
                this.YInput.Value = Cursor.Position.Y;

            }
        }
        //constructor, Duh!
        public PowerClicker()
        {
            InitializeComponent();
            // this.MouseClick += mouseClick;
            RegisterHotKey(this.Handle, 0, 0, Keys.F6.GetHashCode());
        }

        //event for hotkey press
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                toggleClicking();
            }
        }
        // simulates a mouseclick at a given position according to the given MouseSide Enum value
        private void DoMouseClickAt(uint X, uint Y, MouseSide Side)
        {
            if (Side == MouseSide.LEFT)
            {
                mouse_event(0x02/*LeftMouseDown*/, X, Y, 0, 0);
                if (this.HoldSelect.Checked)
                {
                    this.HoldTimer.Start();
                    HoldDisableSide = Side;
                    HoldX = X;
                    HoldY = Y;
                }
                else
                {
                    mouse_event(0x04/*leftMouseUp*/, X, Y, 0, 0);
                }
            }
            else if (Side == MouseSide.RIGHT)
            {
                mouse_event(0x08/*RightMouseDown*/, X, Y, 0, 0);
                if (this.HoldSelect.Checked)
                {
                    this.HoldTimer.Start();
                    HoldDisableSide = Side;
                    HoldX = X;
                    HoldY = Y;
                }
                else
                {
                    mouse_event(0x10/*RightMouseUp*/, X, Y, 0, 0);
                }
            }
            else if (Side == MouseSide.BOTH)
            {

                mouse_event(0x02/*LeftMouseDown*/, X, Y, 0, 0);
                mouse_event(0x08/*RightMouseDown*/, X, Y, 0, 0);
                if (this.HoldSelect.Checked)
                {
                    this.HoldTimer.Start();
                    HoldDisableSide = Side;
                    HoldX = X;
                    HoldY = Y;
                }
                else
                {
                    mouse_event(0x04/*leftMouseUp*/, X, Y, 0, 0);
                    mouse_event(0x10/*RightMouseUp*/, X, Y, 0, 0);
                }
            }
            else if (Side == MouseSide.MIDDLE)
            {
                mouse_event(0x20/*MiddleMouseDown*/, X, Y, 0, 0);
                if (this.HoldSelect.Checked)
                {
                    this.HoldTimer.Start();
                    HoldDisableSide = Side;
                    HoldX = X;
                    HoldY = Y;
                }
                else
                {
                    mouse_event(0x40/*MiddleMouseUp*/, X, Y, 0, 0);
                }
            }
            else if (Side == MouseSide.ALL)
            {
                mouse_event(0x20/*MiddleMouseDown*/, X, Y, 0, 0);
                mouse_event(0x02/*LeftMouseDown*/, X, Y, 0, 0);
                mouse_event(0x08/*RightMouseDown*/, X, Y, 0, 0);
                if (this.HoldSelect.Checked)
                {
                    this.HoldTimer.Start();
                    HoldDisableSide = Side;
                    HoldX = X;
                    HoldY = Y;
                }
                else
                {
                    mouse_event(0x40/*MiddleMouseUp*/, X, Y, 0, 0);
                    mouse_event(0x04/*leftMouseUp*/, X, Y, 0, 0);
                    mouse_event(0x10/*RightMouseUp*/, X, Y, 0, 0);
                }
            }
        }
        // Simulates a mouseclick at the current position of the cursor
        private void DoMouseClickAtCursor(MouseSide Side)
        {
            uint X = Convert.ToUInt32(Cursor.Position.X);
            uint Y = Convert.ToUInt32(Cursor.Position.Y);
            DoMouseClickAt(X, Y, Side);
        }
        private void toggleClicking()
        {
            if (ClickingEnabled)
            {
                ClickingEnabled = false;
                this.ClickTimer.Stop();
                this.EnabledToggle.Text = "Start";
                timesdone = 0;
                UpdateTimesDoneLabel();
                this.TimesDoneLabel.Visible = false;

            }
            else
            {
                //Handles Countdown
                if (this.CountdownTime.Value > 0)
                {
                    this.EnabledToggle.Enabled = false;
                    this.Countdown.Visible = true;
                    this.Refresh();
                    for (int i = 0; i < this.CountdownTime.Value * 10; i++)
                    {
                        this.Countdown.Text = Convert.ToString((this.CountdownTime.Value * 10 - i) / 10);
                        this.Refresh();
                        System.Threading.Thread.Sleep(Convert.ToInt32(this.CountdownTime.Value * 100));
                    }
                    this.EnabledToggle.Enabled = true;
                    this.Countdown.Visible = false;
                    this.Refresh();
                }
                ClickingEnabled = true;
                this.EnabledToggle.Text = "Stop";
                this.ClickTimer.Start();
                if (this.TimesSelect.Checked)
                {
                    this.TimesDoneLabel.Visible = true;
                }

            }
            this.Refresh();

        }
        private void EnabledToggle_Click(object sender, EventArgs e)
        {
            toggleClicking();
        }
        private void TimerIntervalChanged(object sender, EventArgs e)
        {
            if (!InTimeOp)
            {
                completeTimeOp();

                this.ClickTimer.Interval = RegularTime.TotalMillis;
                if (RegularTime.TotalMillis > 1)
                {
                    this.HoldSelect.Enabled = true;
                }
                else
                {
                    this.HoldSelect.Enabled = false;
                    this.HoldTimerBox.Visible = false;
                    this.InstantSelect.Checked = true;

                }
                this.Refresh();
            }
            else
                return;

        }
        private void HoldTimerIntervalChanged(object sender, EventArgs e)
        {
            if (!InTimeOp)
            {

                completeTimeOp();
                this.HoldTimer.Interval = HoldTime.TotalMillis;
            }
            else
                return;

        }
        private void UpdateTimesDoneLabel()
        {
            this.TimesDoneLabel.Text = timesdone.ToString() + "/" + this.TimesInput.Value.ToString();
        }
        // removes hot key reference when closing the program
        private void PowerClicker_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 0);
        }
        private void TimesInput_ValueChanged(object sender, EventArgs e)
        {
            timesdone = 0;
            UpdateTimesDoneLabel();
        }

        private void ClickTimer_Tick(object sender, EventArgs e)
        {
            if ((this.TimesSelect.Checked && this.TimesInput.Value > timesdone) || this.RepeatSelect.Checked)
            {

                if (this.ClickingEnabled)
                {
                    MouseSide Side = MouseSide.LEFT;
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
                    if (this.MousebuttonDropdown.SelectedItem == "Left")
                    {
                        Side = MouseSide.LEFT;
                    }
                    else if (this.MousebuttonDropdown.SelectedItem == "Right")
                    {
                        Side = MouseSide.RIGHT;
                    }
                    else if (this.MousebuttonDropdown.SelectedItem == "Both")
                    {
                        Side = MouseSide.BOTH;
                    }
                    else if (this.MousebuttonDropdown.SelectedItem == "Middle")
                    {
                        Side = MouseSide.MIDDLE;
                    }
                    else if (this.MousebuttonDropdown.SelectedItem == "All")
                    {
                        Side = MouseSide.ALL;
                    }
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
                    timesdone++;
                    if (this.CoordinatesSelect.Checked)
                    {
                        DoMouseClickAt(Convert.ToUInt32(this.XInput.Value), Convert.ToUInt32(this.YInput.Value), Side);
                    }
                    else
                    {
                        DoMouseClickAtCursor(Side);
                    }
                    UpdateTimesDoneLabel();
                    this.Refresh();
                }
            }
        }

        private void HoldTimerTick(object sender, EventArgs e)
        {

            if (HoldDisableSide == MouseSide.LEFT)
            {

                mouse_event(0x04/*leftMouseUp*/, HoldX, HoldY, 0, 0);
            }
            else if (HoldDisableSide == MouseSide.RIGHT)
            {
                mouse_event(0x10/*RightMouseUp*/, HoldX, HoldY, 0, 0);
            }
            else if (HoldDisableSide == MouseSide.BOTH)
            {
                mouse_event(0x04/*leftMouseUp*/, HoldX, HoldY, 0, 0);
                mouse_event(0x10/*RightMouseUp*/, HoldX, HoldY, 0, 0);
            }
            else if (HoldDisableSide == MouseSide.MIDDLE)
            {
                mouse_event(0x40/*MiddleMouseUp*/, HoldX, HoldY, 0, 0);
            }
            else if (HoldDisableSide == MouseSide.ALL)
            {
                mouse_event(0x40/*MiddleMouseUp*/, HoldX, HoldY, 0, 0);
                mouse_event(0x04/*leftMouseUp*/, HoldX, HoldY, 0, 0);
                mouse_event(0x10/*RightMouseUp*/, HoldX, HoldY, 0, 0);
            }
            this.HoldTimer.Stop();
        }

        private void TimesSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (this.TimesSelect.Checked)
            {
                this.TimesInput.Visible = true;
                this.TimesDoneLabel.Visible = true;
            }
            else
            {
                this.TimesInput.Visible = false;
                this.TimesDoneLabel.Visible = false;
            }
        }

        private void HoldSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (this.HoldSelect.Checked)
            {
                this.HoldTimerBox.Visible = true;
                this.HoldTime.TotalMillis = this.RegularTime.TotalMillis - 1;
                if (!InTimeOp)
                    requireHoldTimeInitVal=true;
                    completeTimeOp();



            }
            else
            {
                this.HoldTimerBox.Visible = false;

            }
        }

        private void CoordinatesSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CoordinatesSelect.Checked)
            {
                this.XLabel.Visible = true;
                this.XInput.Visible = true;
                this.YLabel.Visible = true;
                this.YInput.Visible = true;
                this.CoordsButton.Visible = true;
            }
            else
            {
                this.XLabel.Visible = false;
                this.XInput.Visible = false;
                this.YLabel.Visible = false;
                this.YInput.Visible = false;
                this.CoordsButton.Visible = false;
            }
        }
        private void ChangeHotkeyButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (HotkeyChangeMoused && e.KeyCode != Keys.F12)
            {
                UnregisterHotKey(this.Handle, 0);
                RegisterHotKey(this.Handle, 0, 0, e.KeyCode.GetHashCode());
                this.HotKeyLabel.Text = getUnicodeFromKeycode(e.KeyCode);
                if (this.HotKeyLabel.Text == string.Empty)
                {
                    this.HotKeyLabel.Text = e.KeyCode.ToString();
                }
            }
            else if (e.KeyCode == Keys.F12)
            {
                MessageBox.Show("F12 cannot be used as hotkey.", "Invalid Hotkey", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeHotkeyButton_MouseDown(object sender, MouseEventArgs e)
        {
            HotkeyChangeMoused = true;
        }
        private void ChangeHotkeyButton_MouseUp(object sender, EventArgs e)
        {
            HotkeyChangeMoused = false;
        }

        private void CoordsButton_Click(object sender, EventArgs e)
        {
            SetCoords = true;
        }


        private class TimeHandler
        {
            public int MilliSeconds;
            public int Seconds;
            public int Minutes;
            public int TotalMillis;
            public TimeHandler(int Mils, int Sec, int Min)
            {
                this.MilliSeconds = Mils;
                this.Seconds = Sec;
                this.Minutes = Min;
                this.TotalMillis = this.MilliSeconds + this.Seconds * 1000 + this.Minutes * 60000;
                ValidateValue();
            }
            public void ValidateValue()
            {
                int processedMilSecs = this.TotalMillis;
                this.Minutes = (this.TotalMillis - this.TotalMillis % 60000) / 60000;
                processedMilSecs -= this.Minutes * 60000;
                this.Seconds = (processedMilSecs - processedMilSecs % 1000) / 1000;
                processedMilSecs -= this.Seconds * 1000;
                this.MilliSeconds = processedMilSecs;

                this.TotalMillis = this.MilliSeconds + this.Seconds * 1000 + this.Minutes * 60000;
                if (this.Minutes > 999)
                    this.Minutes = 999; 
            }
        }

    }
}
