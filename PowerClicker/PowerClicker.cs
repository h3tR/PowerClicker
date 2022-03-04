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
        private bool AutoKeyChangeMoused = false;
        private bool SetCoords = false;
        private uint HoldX;
        private uint HoldY;
        private TimeHandler RegularTime = new TimeHandler(0, 1, 0);
        private TimeHandler HoldTime = new TimeHandler(0, 0, 999);
        // debounce for CompleteTimeOp function
        private bool InTimeOp = false;
        // if true will set hold timer to the regular timer -1 millisecond 
        private bool requireHoldTimeInitVal = false;
        private Keys Hotkey = Keys.F6;
        private Keys AutoKey = Keys.E;

        private bool ClickingEnabled = false;
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

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
                        requireHoldTimeInitVal = false;
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
        private string getStringfromKeycode(Keys e)
        {
            string toreturn = getUnicodeFromKeycode(e);
            if (toreturn == string.Empty|| toreturn == " ")
            {
                toreturn = e.ToString();
            }
            return toreturn;
        }
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
            switch (Side)
            {
                case MouseSide.LEFT:

                    mouse_event(Convert.ToUInt32(0x02)/*LeftMouseDown*/, X, Y, 0, 0);
                    if (this.HoldSelect.Checked)
                    {
                        this.HoldTimer.Start();
                        HoldDisableSide = Side;
                        HoldX = X;
                        HoldY = Y;
                    }
                    else
                    {
                        mouse_event(Convert.ToUInt32(0x04)/*leftMouseUp*/, X, Y, 0, 0);
                    }
                    break;
                case MouseSide.RIGHT:
                    mouse_event(Convert.ToUInt32(0x08)/*RightMouseDown*/, X, Y, 0, 0);
                    if (this.HoldSelect.Checked)
                    {
                        this.HoldTimer.Start();
                        HoldDisableSide = Side;
                        HoldX = X;
                        HoldY = Y;
                    }
                    else
                    {
                        mouse_event(Convert.ToUInt32(0x10)/*RightMouseUp*/, X, Y, 0, 0);
                    }
                    break;
                case MouseSide.BOTH:
                    mouse_event(Convert.ToUInt32(0x02)/*LeftMouseDown*/, X, Y, 0, 0);
                    mouse_event(Convert.ToUInt32(0x08)/*RightMouseDown*/, X, Y, 0, 0);
                    if (this.HoldSelect.Checked)
                    {
                        this.HoldTimer.Start();
                        HoldDisableSide = Side;
                        HoldX = X;
                        HoldY = Y;
                    }
                    else
                    {
                        mouse_event(Convert.ToUInt32(0x04)/*leftMouseUp*/, X, Y, 0, 0);
                        mouse_event(Convert.ToUInt32(0x10)/*RightMouseUp*/, X, Y, 0, 0);
                    }
                    break;
                case MouseSide.MIDDLE:
                    mouse_event(Convert.ToUInt32(0x20)/*MiddleMouseDown*/, X, Y, 0, 0);
                    if (this.HoldSelect.Checked)
                    {
                        this.HoldTimer.Start();
                        HoldDisableSide = Side;
                        HoldX = X;
                        HoldY = Y;
                    }
                    else
                    {
                        mouse_event(Convert.ToUInt32(0x40)/*MiddleMouseUp*/, X, Y, 0, 0);
                    }
                    break;
                case MouseSide.ALL:
                    mouse_event(Convert.ToUInt32(0x20)/*MiddleMouseDown*/, X, Y, 0, 0);
                    mouse_event(Convert.ToUInt32(0x02)/*LeftMouseDown*/, X, Y, 0, 0);
                    mouse_event(Convert.ToUInt32(0x08)/*RightMouseDown*/, X, Y, 0, 0);
                    if (this.HoldSelect.Checked)
                    {
                        this.HoldTimer.Start();
                        HoldDisableSide = Side;
                        HoldX = X;
                        HoldY = Y;
                    }
                    else
                    {
                        mouse_event(Convert.ToUInt32(0x40)/*MiddleMouseUp*/, X, Y, 0, 0);
                        mouse_event(Convert.ToUInt32(0x04)/*leftMouseUp*/, X, Y, 0, 0);
                        mouse_event(Convert.ToUInt32(0x10)/*RightMouseUp*/, X, Y, 0, 0);
                    }
                    break;
                default:
                    Console.WriteLine("Warning: No Mousebutton has been selected.");
                    break;
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
                    if (this.InputSelectionTabs.SelectedTab == this.MousePage)
                    {
                        MouseSide Side = MouseSide.LEFT;
                        switch (this.MousebuttonDropdown.SelectedItem)
                        {
                            case "Left":
                                Side = MouseSide.LEFT;
                                break;
                            case "Right":
                                Side = MouseSide.RIGHT;
                                break;
                            case "Middle":
                                Side = MouseSide.MIDDLE;
                                break;
                            case "Both":
                                Side = MouseSide.BOTH;
                                break;
                            case "All":
                                Side = MouseSide.ALL;
                                break;
                            default:
                                Console.WriteLine("Warning: Invalid MouseButton input given.");
                                break;
                        }
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
                    else
                    {
                        keybd_event((byte)AutoKey, 0, 0, 0);
                        if (this.HoldSelect.Checked)
                        {
                            this.HoldTimer.Start();
                        }
                        else
                        {
                            keybd_event((byte)AutoKey, 0, 0x0002, 0);
                        }
                        timesdone++;
                        UpdateTimesDoneLabel();
                        this.Refresh();
                    }
                }
            }
        }

        private void HoldTimerTick(object sender, EventArgs e)
        {
            if (this.InputSelectionTabs.SelectedTab == this.MousePage)
            {
                switch (HoldDisableSide)
                {
                    case MouseSide.LEFT:
                        mouse_event(Convert.ToUInt32(0x04)/*leftMouseUp*/, HoldX, HoldY, 0, 0);
                        break;
                    case MouseSide.RIGHT:
                        mouse_event(Convert.ToUInt32(0x10)/*RightMouseUp*/, HoldX, HoldY, 0, 0);
                        break;
                    case MouseSide.MIDDLE:
                        mouse_event(Convert.ToUInt32(0x40)/*MiddleMouseUp*/, HoldX, HoldY, 0, 0);
                        break;
                    case MouseSide.BOTH:
                        mouse_event(Convert.ToUInt32(0x04)/*leftMouseUp*/, HoldX, HoldY, 0, 0);
                        mouse_event(Convert.ToUInt32(0x10)/*RightMouseUp*/, HoldX, HoldY, 0, 0);
                        break;
                    case MouseSide.ALL:
                        mouse_event(Convert.ToUInt32(0x40)/*MiddleMouseUp*/, HoldX, HoldY, 0, 0);
                        mouse_event(Convert.ToUInt32(0x04)/*leftMouseUp*/, HoldX, HoldY, 0, 0);
                        mouse_event(Convert.ToUInt32(0x10)/*RightMouseUp*/, HoldX, HoldY, 0, 0);
                        break;
                    default:
                        Console.WriteLine("Warning: Invalid HoldDisableSide Value.");
                        break;
                }
            }
            else
                keybd_event((byte)AutoKey, 0, 0x0002, 0);
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
                    requireHoldTimeInitVal = true;
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
                Hotkey = e.KeyCode;
                this.HotKeyLabel.Text = getStringfromKeycode(e.KeyCode);
            }
            else if (e.KeyCode == Keys.F12)
            {
                MessageBox.Show("F12 cannot be used as hotkey.", "Invalid Hotkey", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Hotkey == AutoKey)
            {
                if (Hotkey != Keys.E)
                {
                    AutoKey = Keys.E;
                    this.ActiveAutoKeyDisplay.Text = getStringfromKeycode(Keys.E);
                }
                else
                {
                    AutoKey = Keys.A;
                    this.ActiveAutoKeyDisplay.Text = getStringfromKeycode(Keys.A);
                }
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

        private void ChangeAutoKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (AutoKeyChangeMoused && e.KeyCode != Hotkey)
            {
                AutoKey = e.KeyCode;
                this.ActiveAutoKeyDisplay.Text = getStringfromKeycode(e.KeyCode);
            }
            else if (e.KeyCode == Hotkey)
            {
                MessageBox.Show("The AutoKey cannot be the same as your hotkey", "Invalid AutoKey", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeAutoKey_MouseDown(object sender, MouseEventArgs e)
        {
            AutoKeyChangeMoused = true;
        }

        private void ChangeAutoKey_MouseUp(object sender, EventArgs e)
        {
            AutoKeyChangeMoused = false;
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
