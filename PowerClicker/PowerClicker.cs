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

        private bool ClickingEnabled = false;
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int ToUnicode(uint virtualKeyCode, uint scanCode, byte[] keyboardState, System.Text.StringBuilder receivingBuffer,int bufferSize, uint flags);

        private int timesdone = 0;
        enum MouseSide
        {
            LEFT,
            RIGHT,
            BOTH,
            MIDDLE,
            ALL
        }
        private string getUnicodeFromKeycode(Keys e)
        {
            StringBuilder charPressed = new StringBuilder(256);
            ToUnicode((uint)e, 0, new byte[256], charPressed, charPressed.Capacity, 0);
            return charPressed.ToString();
        }
        private void mouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Hello");
            if (SetCoords && e.Button == MouseButtons.Left)
            {
                SetCoords = false;
                this.XInput.Value = Cursor.Position.X;
                this.YInput.Value = Cursor.Position.Y;

            }
        }

        public PowerClicker()
        {
            InitializeComponent();
            this.MouseClick += mouseClick;
            RegisterHotKey(this.Handle, 0, 0, Keys.F6.GetHashCode());
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                toggleClicking();
                // do something
            }
        }

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
            if (Convert.ToInt32(this.MinInput.Value * 1000000) + Convert.ToInt32(this.SecInput.Value * 1000) + Convert.ToInt32(this.MilsecInput.Value) < 1)
            {
                this.MilsecInput.Value = 1;
            }
            this.ClickTimer.Interval = Convert.ToInt32(this.MinInput.Value * 1000000) + Convert.ToInt32(this.SecInput.Value * 1000) + Convert.ToInt32(this.MilsecInput.Value);
            if (Convert.ToInt32(this.MinInput.Value * 1000000) + Convert.ToInt32(this.SecInput.Value * 1000) + Convert.ToInt32(this.MilsecInput.Value) > 1)
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
        private void HoldTimerIntervalChanged(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(this.HoldMinInput.Value * 1000000) + Convert.ToInt32(this.HoldSecInput.Value * 1000) + Convert.ToInt32(this.HoldMilSecInput.Value) < 1) ||
               (Convert.ToInt32(this.HoldMinInput.Value * 1000000) + Convert.ToInt32(this.HoldSecInput.Value * 1000) + Convert.ToInt32(this.HoldMilSecInput.Value) >= (Convert.ToInt32(this.MinInput.Value * 1000000) + Convert.ToInt32(this.SecInput.Value * 1000) + Convert.ToInt32(this.MilsecInput.Value))))
            {
                this.HoldMinInput.Value = 0;
                this.HoldSecInput.Value = 0;
                this.HoldMilSecInput.Value = 1;
                this.Refresh();
            }
            this.HoldTimer.Interval = Convert.ToInt32(this.HoldMinInput.Value * 1000000) + Convert.ToInt32(this.HoldSecInput.Value * 1000) + Convert.ToInt32(this.HoldMilSecInput.Value);

        }
        private void UpdateTimesDoneLabel()
        {
            this.TimesDoneLabel.Text = timesdone.ToString() + "/" + this.TimesInput.Value.ToString();
        }
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
                int timerInterval = Convert.ToInt32(this.MinInput.Value * 1000000) + Convert.ToInt32(this.SecInput.Value * 1000) + Convert.ToInt32(this.MilsecInput.Value);
                --timerInterval;
                string stringtimer = timerInterval.ToString();
                while (stringtimer.Length < 9)
                {
                    stringtimer = stringtimer.Insert(0, "0");
                }
                Console.WriteLine(stringtimer);
                this.HoldMinInput.Value = Convert.ToInt32(stringtimer.Substring(0, 3));
                this.HoldSecInput.Value = Convert.ToInt32(stringtimer.Substring(3, 3));
                this.HoldMilSecInput.Value = Convert.ToInt32(stringtimer.Substring(6, 3));

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
                this.CoordsButton.Visible=false;
            }
        }
        private void ChangeHotkeyButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (HotkeyChangeMoused && e.KeyCode!= Keys.F12)
            {
                UnregisterHotKey(this.Handle, 0);
                RegisterHotKey(this.Handle, 0, 0, e.KeyCode.GetHashCode());
                this.HotKeyLabel.Text = getUnicodeFromKeycode(e.KeyCode);
                if(this.HotKeyLabel.Text == string.Empty)
                {
                    this.HotKeyLabel.Text = e.KeyCode.ToString();
                }
            }else if(e.KeyCode == Keys.F12)
            {
                MessageBox.Show("F12 cannot be used as hotkey.", "Invalid Hotkey", MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            Console.WriteLine("newcoords");
            SetCoords = true;
        }
    }
}
