namespace WindowsFormsApp1
{
    partial class PowerClicker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PowerClicker));
            this.MilSecInput = new System.Windows.Forms.NumericUpDown();
            this.MilsecLabel = new System.Windows.Forms.Label();
            this.SecInput = new System.Windows.Forms.NumericUpDown();
            this.SecLabel = new System.Windows.Forms.Label();
            this.MinInput = new System.Windows.Forms.NumericUpDown();
            this.MinLabel = new System.Windows.Forms.Label();
            this.EnabledToggle = new System.Windows.Forms.Button();
            this.CountdownTime = new System.Windows.Forms.NumericUpDown();
            this.CountdownLabel = new System.Windows.Forms.Label();
            this.Countdown = new System.Windows.Forms.Label();
            this.TimesInput = new System.Windows.Forms.NumericUpDown();
            this.ClickTypeBox = new System.Windows.Forms.GroupBox();
            this.TimesDoneLabel = new System.Windows.Forms.Label();
            this.RepeatSelect = new System.Windows.Forms.RadioButton();
            this.TimesSelect = new System.Windows.Forms.RadioButton();
            this.TimerBox = new System.Windows.Forms.GroupBox();
            this.HotKeyLabel = new System.Windows.Forms.Label();
            this.CursorPosition = new System.Windows.Forms.GroupBox();
            this.ComingSoonLabel = new System.Windows.Forms.Label();
            this.CoordsButton = new System.Windows.Forms.Button();
            this.CursorSelect = new System.Windows.Forms.RadioButton();
            this.CoordinatesSelect = new System.Windows.Forms.RadioButton();
            this.YInput = new System.Windows.Forms.NumericUpDown();
            this.XInput = new System.Windows.Forms.NumericUpDown();
            this.YLabel = new System.Windows.Forms.Label();
            this.XLabel = new System.Windows.Forms.Label();
            this.ClickTimer = new System.Windows.Forms.Timer(this.components);
            this.HoldTimer = new System.Windows.Forms.Timer(this.components);
            this.MousebuttonDropdown = new System.Windows.Forms.ComboBox();
            this.ClickTypeLabel = new System.Windows.Forms.Label();
            this.ClickDurationBox = new System.Windows.Forms.GroupBox();
            this.HoldSelect = new System.Windows.Forms.RadioButton();
            this.InstantSelect = new System.Windows.Forms.RadioButton();
            this.HoldTimerBox = new System.Windows.Forms.GroupBox();
            this.HoldMinLabel = new System.Windows.Forms.Label();
            this.HoldSecLabel = new System.Windows.Forms.Label();
            this.HoldMilsecLabel = new System.Windows.Forms.Label();
            this.HoldMinInput = new System.Windows.Forms.NumericUpDown();
            this.HoldSecInput = new System.Windows.Forms.NumericUpDown();
            this.HoldMilSecInput = new System.Windows.Forms.NumericUpDown();
            this.ChangeHotkeyButton = new System.Windows.Forms.Button();
            this.HotkeyTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.InputSelectionTabs = new System.Windows.Forms.TabControl();
            this.MousePage = new System.Windows.Forms.TabPage();
            this.KeyboardPage = new System.Windows.Forms.TabPage();
            this.ActiveAutoKeyDisplay = new System.Windows.Forms.Label();
            this.ChangeAutoKeyButton = new System.Windows.Forms.Button();
            this.ComingSoonTip = new System.Windows.Forms.ToolTip(this.components);
            this.VersionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MilSecInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountdownTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimesInput)).BeginInit();
            this.ClickTypeBox.SuspendLayout();
            this.TimerBox.SuspendLayout();
            this.CursorPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XInput)).BeginInit();
            this.ClickDurationBox.SuspendLayout();
            this.HoldTimerBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HoldMinInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoldSecInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoldMilSecInput)).BeginInit();
            this.InputSelectionTabs.SuspendLayout();
            this.MousePage.SuspendLayout();
            this.KeyboardPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // MilSecInput
            // 
            this.MilSecInput.Location = new System.Drawing.Point(426, 41);
            this.MilSecInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MilSecInput.Name = "MilSecInput";
            this.MilSecInput.Size = new System.Drawing.Size(120, 20);
            this.MilSecInput.TabIndex = 0;
            this.MilSecInput.ValueChanged += new System.EventHandler(this.TimerIntervalChanged);
            // 
            // MilsecLabel
            // 
            this.MilsecLabel.AutoSize = true;
            this.MilsecLabel.Location = new System.Drawing.Point(423, 16);
            this.MilsecLabel.Name = "MilsecLabel";
            this.MilsecLabel.Size = new System.Drawing.Size(67, 13);
            this.MilsecLabel.TabIndex = 1;
            this.MilsecLabel.Text = "Milliseconds:";
            // 
            // SecInput
            // 
            this.SecInput.Location = new System.Drawing.Point(242, 41);
            this.SecInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SecInput.Name = "SecInput";
            this.SecInput.Size = new System.Drawing.Size(120, 20);
            this.SecInput.TabIndex = 2;
            this.SecInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SecInput.ValueChanged += new System.EventHandler(this.TimerIntervalChanged);
            // 
            // SecLabel
            // 
            this.SecLabel.AutoSize = true;
            this.SecLabel.Location = new System.Drawing.Point(239, 16);
            this.SecLabel.Name = "SecLabel";
            this.SecLabel.Size = new System.Drawing.Size(52, 13);
            this.SecLabel.TabIndex = 3;
            this.SecLabel.Text = "Seconds:";
            // 
            // MinInput
            // 
            this.MinInput.Location = new System.Drawing.Point(44, 41);
            this.MinInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MinInput.Name = "MinInput";
            this.MinInput.Size = new System.Drawing.Size(120, 20);
            this.MinInput.TabIndex = 4;
            this.MinInput.ValueChanged += new System.EventHandler(this.TimerIntervalChanged);
            // 
            // MinLabel
            // 
            this.MinLabel.AutoSize = true;
            this.MinLabel.Location = new System.Drawing.Point(41, 16);
            this.MinLabel.Name = "MinLabel";
            this.MinLabel.Size = new System.Drawing.Size(47, 13);
            this.MinLabel.TabIndex = 5;
            this.MinLabel.Text = "Minutes:";
            // 
            // EnabledToggle
            // 
            this.EnabledToggle.Location = new System.Drawing.Point(44, 95);
            this.EnabledToggle.Name = "EnabledToggle";
            this.EnabledToggle.Size = new System.Drawing.Size(75, 23);
            this.EnabledToggle.TabIndex = 6;
            this.EnabledToggle.Text = "Start";
            this.EnabledToggle.UseVisualStyleBackColor = true;
            this.EnabledToggle.Click += new System.EventHandler(this.EnabledToggle_Click);
            // 
            // CountdownTime
            // 
            this.CountdownTime.DecimalPlaces = 1;
            this.CountdownTime.Location = new System.Drawing.Point(383, 95);
            this.CountdownTime.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.CountdownTime.Name = "CountdownTime";
            this.CountdownTime.Size = new System.Drawing.Size(120, 20);
            this.CountdownTime.TabIndex = 7;
            // 
            // CountdownLabel
            // 
            this.CountdownLabel.AutoSize = true;
            this.CountdownLabel.Location = new System.Drawing.Point(290, 99);
            this.CountdownLabel.Name = "CountdownLabel";
            this.CountdownLabel.Size = new System.Drawing.Size(87, 13);
            this.CountdownLabel.TabIndex = 8;
            this.CountdownLabel.Text = "Countdown (sec)";
            // 
            // Countdown
            // 
            this.Countdown.AutoSize = true;
            this.Countdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Countdown.ForeColor = System.Drawing.Color.Red;
            this.Countdown.Location = new System.Drawing.Point(521, 95);
            this.Countdown.Name = "Countdown";
            this.Countdown.Size = new System.Drawing.Size(24, 25);
            this.Countdown.TabIndex = 9;
            this.Countdown.Text = "0";
            this.Countdown.Visible = false;
            // 
            // TimesInput
            // 
            this.TimesInput.Location = new System.Drawing.Point(82, 45);
            this.TimesInput.Name = "TimesInput";
            this.TimesInput.Size = new System.Drawing.Size(120, 20);
            this.TimesInput.TabIndex = 10;
            this.TimesInput.Visible = false;
            this.TimesInput.ValueChanged += new System.EventHandler(this.TimesInput_ValueChanged);
            // 
            // ClickTypeBox
            // 
            this.ClickTypeBox.Controls.Add(this.TimesDoneLabel);
            this.ClickTypeBox.Controls.Add(this.RepeatSelect);
            this.ClickTypeBox.Controls.Add(this.TimesSelect);
            this.ClickTypeBox.Controls.Add(this.TimesInput);
            this.ClickTypeBox.Location = new System.Drawing.Point(12, 275);
            this.ClickTypeBox.Name = "ClickTypeBox";
            this.ClickTypeBox.Size = new System.Drawing.Size(242, 82);
            this.ClickTypeBox.TabIndex = 11;
            this.ClickTypeBox.TabStop = false;
            this.ClickTypeBox.Text = "Click Type";
            // 
            // TimesDoneLabel
            // 
            this.TimesDoneLabel.AutoSize = true;
            this.TimesDoneLabel.Location = new System.Drawing.Point(208, 49);
            this.TimesDoneLabel.Name = "TimesDoneLabel";
            this.TimesDoneLabel.Size = new System.Drawing.Size(13, 13);
            this.TimesDoneLabel.TabIndex = 13;
            this.TimesDoneLabel.Text = "0";
            this.TimesDoneLabel.Visible = false;
            // 
            // RepeatSelect
            // 
            this.RepeatSelect.AutoSize = true;
            this.RepeatSelect.Checked = true;
            this.RepeatSelect.Location = new System.Drawing.Point(14, 19);
            this.RepeatSelect.Name = "RepeatSelect";
            this.RepeatSelect.Size = new System.Drawing.Size(60, 17);
            this.RepeatSelect.TabIndex = 12;
            this.RepeatSelect.TabStop = true;
            this.RepeatSelect.Text = "Repeat";
            this.RepeatSelect.UseMnemonic = false;
            this.RepeatSelect.UseVisualStyleBackColor = true;
            // 
            // TimesSelect
            // 
            this.TimesSelect.AutoSize = true;
            this.TimesSelect.Location = new System.Drawing.Point(14, 45);
            this.TimesSelect.Name = "TimesSelect";
            this.TimesSelect.Size = new System.Drawing.Size(53, 17);
            this.TimesSelect.TabIndex = 11;
            this.TimesSelect.Text = "Times";
            this.TimesSelect.UseVisualStyleBackColor = true;
            this.TimesSelect.CheckedChanged += new System.EventHandler(this.TimesSelect_CheckedChanged);
            // 
            // TimerBox
            // 
            this.TimerBox.Controls.Add(this.MinLabel);
            this.TimerBox.Controls.Add(this.SecLabel);
            this.TimerBox.Controls.Add(this.MilsecLabel);
            this.TimerBox.Controls.Add(this.MinInput);
            this.TimerBox.Controls.Add(this.SecInput);
            this.TimerBox.Controls.Add(this.MilSecInput);
            this.TimerBox.Location = new System.Drawing.Point(15, 13);
            this.TimerBox.Name = "TimerBox";
            this.TimerBox.Size = new System.Drawing.Size(564, 76);
            this.TimerBox.TabIndex = 13;
            this.TimerBox.TabStop = false;
            this.TimerBox.Text = "Timer";
            // 
            // HotKeyLabel
            // 
            this.HotKeyLabel.AutoSize = true;
            this.HotKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HotKeyLabel.Location = new System.Drawing.Point(12, 95);
            this.HotKeyLabel.Name = "HotKeyLabel";
            this.HotKeyLabel.Size = new System.Drawing.Size(26, 17);
            this.HotKeyLabel.TabIndex = 14;
            this.HotKeyLabel.Text = "F6";
            // 
            // CursorPosition
            // 
            this.CursorPosition.Controls.Add(this.ComingSoonLabel);
            this.CursorPosition.Controls.Add(this.CoordsButton);
            this.CursorPosition.Controls.Add(this.CursorSelect);
            this.CursorPosition.Controls.Add(this.CoordinatesSelect);
            this.CursorPosition.Controls.Add(this.YInput);
            this.CursorPosition.Controls.Add(this.XInput);
            this.CursorPosition.Controls.Add(this.YLabel);
            this.CursorPosition.Controls.Add(this.XLabel);
            this.CursorPosition.Location = new System.Drawing.Point(241, 12);
            this.CursorPosition.Name = "CursorPosition";
            this.CursorPosition.Size = new System.Drawing.Size(304, 97);
            this.CursorPosition.TabIndex = 15;
            this.CursorPosition.TabStop = false;
            this.CursorPosition.Text = "Position";
            // 
            // ComingSoonLabel
            // 
            this.ComingSoonLabel.AutoSize = true;
            this.ComingSoonLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.ComingSoonLabel.Location = new System.Drawing.Point(14, 70);
            this.ComingSoonLabel.Name = "ComingSoonLabel";
            this.ComingSoonLabel.Size = new System.Drawing.Size(79, 13);
            this.ComingSoonLabel.TabIndex = 7;
            this.ComingSoonLabel.Text = "↑ Coming Soon";
            // 
            // CoordsButton
            // 
            this.CoordsButton.Location = new System.Drawing.Point(150, 65);
            this.CoordsButton.Name = "CoordsButton";
            this.CoordsButton.Size = new System.Drawing.Size(105, 23);
            this.CoordsButton.TabIndex = 6;
            this.CoordsButton.Text = "Pick Coordinates";
            this.CoordsButton.UseVisualStyleBackColor = true;
            this.CoordsButton.Visible = false;
            this.CoordsButton.Click += new System.EventHandler(this.CoordsButton_Click);
            // 
            // CursorSelect
            // 
            this.CursorSelect.AutoSize = true;
            this.CursorSelect.Checked = true;
            this.CursorSelect.Location = new System.Drawing.Point(6, 19);
            this.CursorSelect.Name = "CursorSelect";
            this.CursorSelect.Size = new System.Drawing.Size(55, 17);
            this.CursorSelect.TabIndex = 5;
            this.CursorSelect.TabStop = true;
            this.CursorSelect.Text = "Cursor";
            this.CursorSelect.UseVisualStyleBackColor = true;
            // 
            // CoordinatesSelect
            // 
            this.CoordinatesSelect.AutoSize = true;
            this.CoordinatesSelect.Enabled = false;
            this.CoordinatesSelect.Location = new System.Drawing.Point(6, 42);
            this.CoordinatesSelect.Name = "CoordinatesSelect";
            this.CoordinatesSelect.Size = new System.Drawing.Size(81, 17);
            this.CoordinatesSelect.TabIndex = 4;
            this.CoordinatesSelect.Text = "Coordinates";
            this.ComingSoonTip.SetToolTip(this.CoordinatesSelect, "Coming soon");
            this.CoordinatesSelect.UseVisualStyleBackColor = true;
            this.CoordinatesSelect.CheckedChanged += new System.EventHandler(this.CoordinatesSelect_CheckedChanged);
            // 
            // YInput
            // 
            this.YInput.Location = new System.Drawing.Point(150, 39);
            this.YInput.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.YInput.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.YInput.Name = "YInput";
            this.YInput.Size = new System.Drawing.Size(120, 20);
            this.YInput.TabIndex = 3;
            this.YInput.Visible = false;
            // 
            // XInput
            // 
            this.XInput.Location = new System.Drawing.Point(150, 11);
            this.XInput.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.XInput.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.XInput.Name = "XInput";
            this.XInput.Size = new System.Drawing.Size(120, 20);
            this.XInput.TabIndex = 2;
            this.XInput.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.XInput.Visible = false;
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Location = new System.Drawing.Point(123, 44);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(14, 13);
            this.YLabel.TabIndex = 1;
            this.YLabel.Text = "Y";
            this.YLabel.Visible = false;
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(123, 13);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(14, 13);
            this.XLabel.TabIndex = 0;
            this.XLabel.Text = "X";
            this.XLabel.Visible = false;
            // 
            // ClickTimer
            // 
            this.ClickTimer.Interval = 1000;
            this.ClickTimer.Tick += new System.EventHandler(this.ClickTimer_Tick);
            // 
            // HoldTimer
            // 
            this.HoldTimer.Interval = 500;
            this.HoldTimer.Tick += new System.EventHandler(this.HoldTimerTick);
            // 
            // MousebuttonDropdown
            // 
            this.MousebuttonDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MousebuttonDropdown.FormattingEnabled = true;
            this.MousebuttonDropdown.Items.AddRange(new object[] {
            "Left",
            "Right",
            "Both",
            "Middle",
            "All"});
            this.MousebuttonDropdown.Location = new System.Drawing.Point(103, 14);
            this.MousebuttonDropdown.Name = "MousebuttonDropdown";
            this.MousebuttonDropdown.Size = new System.Drawing.Size(121, 21);
            this.MousebuttonDropdown.TabIndex = 16;
            // 
            // ClickTypeLabel
            // 
            this.ClickTypeLabel.AutoSize = true;
            this.ClickTypeLabel.Location = new System.Drawing.Point(25, 17);
            this.ClickTypeLabel.Name = "ClickTypeLabel";
            this.ClickTypeLabel.Size = new System.Drawing.Size(72, 13);
            this.ClickTypeLabel.TabIndex = 17;
            this.ClickTypeLabel.Text = "Mousebutton:";
            // 
            // ClickDurationBox
            // 
            this.ClickDurationBox.Controls.Add(this.HoldSelect);
            this.ClickDurationBox.Controls.Add(this.InstantSelect);
            this.ClickDurationBox.Location = new System.Drawing.Point(333, 275);
            this.ClickDurationBox.Name = "ClickDurationBox";
            this.ClickDurationBox.Size = new System.Drawing.Size(246, 82);
            this.ClickDurationBox.TabIndex = 18;
            this.ClickDurationBox.TabStop = false;
            this.ClickDurationBox.Text = "Click duration";
            // 
            // HoldSelect
            // 
            this.HoldSelect.AutoSize = true;
            this.HoldSelect.Location = new System.Drawing.Point(17, 45);
            this.HoldSelect.Name = "HoldSelect";
            this.HoldSelect.Size = new System.Drawing.Size(47, 17);
            this.HoldSelect.TabIndex = 1;
            this.HoldSelect.Text = "Hold";
            this.HoldSelect.UseVisualStyleBackColor = true;
            this.HoldSelect.CheckedChanged += new System.EventHandler(this.HoldSelect_CheckedChanged);
            // 
            // InstantSelect
            // 
            this.InstantSelect.AutoSize = true;
            this.InstantSelect.Checked = true;
            this.InstantSelect.Location = new System.Drawing.Point(17, 19);
            this.InstantSelect.Name = "InstantSelect";
            this.InstantSelect.Size = new System.Drawing.Size(57, 17);
            this.InstantSelect.TabIndex = 0;
            this.InstantSelect.TabStop = true;
            this.InstantSelect.Text = "Instant";
            this.InstantSelect.UseVisualStyleBackColor = true;
            // 
            // HoldTimerBox
            // 
            this.HoldTimerBox.Controls.Add(this.HoldMinLabel);
            this.HoldTimerBox.Controls.Add(this.HoldSecLabel);
            this.HoldTimerBox.Controls.Add(this.HoldMilsecLabel);
            this.HoldTimerBox.Controls.Add(this.HoldMinInput);
            this.HoldTimerBox.Controls.Add(this.HoldSecInput);
            this.HoldTimerBox.Controls.Add(this.HoldMilSecInput);
            this.HoldTimerBox.Location = new System.Drawing.Point(15, 363);
            this.HoldTimerBox.Name = "HoldTimerBox";
            this.HoldTimerBox.Size = new System.Drawing.Size(564, 76);
            this.HoldTimerBox.TabIndex = 19;
            this.HoldTimerBox.TabStop = false;
            this.HoldTimerBox.Text = "Hold time";
            this.HoldTimerBox.Visible = false;
            // 
            // HoldMinLabel
            // 
            this.HoldMinLabel.AutoSize = true;
            this.HoldMinLabel.Location = new System.Drawing.Point(41, 16);
            this.HoldMinLabel.Name = "HoldMinLabel";
            this.HoldMinLabel.Size = new System.Drawing.Size(47, 13);
            this.HoldMinLabel.TabIndex = 5;
            this.HoldMinLabel.Text = "Minutes:";
            // 
            // HoldSecLabel
            // 
            this.HoldSecLabel.AutoSize = true;
            this.HoldSecLabel.Location = new System.Drawing.Point(239, 16);
            this.HoldSecLabel.Name = "HoldSecLabel";
            this.HoldSecLabel.Size = new System.Drawing.Size(52, 13);
            this.HoldSecLabel.TabIndex = 3;
            this.HoldSecLabel.Text = "Seconds:";
            // 
            // HoldMilsecLabel
            // 
            this.HoldMilsecLabel.AutoSize = true;
            this.HoldMilsecLabel.Location = new System.Drawing.Point(423, 16);
            this.HoldMilsecLabel.Name = "HoldMilsecLabel";
            this.HoldMilsecLabel.Size = new System.Drawing.Size(67, 13);
            this.HoldMilsecLabel.TabIndex = 1;
            this.HoldMilsecLabel.Text = "Milliseconds:";
            // 
            // HoldMinInput
            // 
            this.HoldMinInput.Location = new System.Drawing.Point(44, 41);
            this.HoldMinInput.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.HoldMinInput.Name = "HoldMinInput";
            this.HoldMinInput.Size = new System.Drawing.Size(120, 20);
            this.HoldMinInput.TabIndex = 4;
            this.HoldMinInput.ValueChanged += new System.EventHandler(this.HoldTimerIntervalChanged);
            // 
            // HoldSecInput
            // 
            this.HoldSecInput.Location = new System.Drawing.Point(242, 41);
            this.HoldSecInput.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.HoldSecInput.Name = "HoldSecInput";
            this.HoldSecInput.Size = new System.Drawing.Size(120, 20);
            this.HoldSecInput.TabIndex = 2;
            this.HoldSecInput.ValueChanged += new System.EventHandler(this.HoldTimerIntervalChanged);
            // 
            // HoldMilSecInput
            // 
            this.HoldMilSecInput.Location = new System.Drawing.Point(426, 41);
            this.HoldMilSecInput.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.HoldMilSecInput.Name = "HoldMilSecInput";
            this.HoldMilSecInput.Size = new System.Drawing.Size(120, 20);
            this.HoldMilSecInput.TabIndex = 0;
            this.HoldMilSecInput.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.HoldMilSecInput.ValueChanged += new System.EventHandler(this.HoldTimerIntervalChanged);
            // 
            // ChangeHotkeyButton
            // 
            this.ChangeHotkeyButton.Location = new System.Drawing.Point(141, 95);
            this.ChangeHotkeyButton.Name = "ChangeHotkeyButton";
            this.ChangeHotkeyButton.Size = new System.Drawing.Size(119, 23);
            this.ChangeHotkeyButton.TabIndex = 20;
            this.ChangeHotkeyButton.Text = "Change Hotkey";
            this.HotkeyTooltip.SetToolTip(this.ChangeHotkeyButton, "Click and hold, then press a key, that will be the new hotkey.");
            this.ChangeHotkeyButton.UseVisualStyleBackColor = true;
            this.ChangeHotkeyButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeHotkeyButton_KeyDown);
            this.ChangeHotkeyButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChangeHotkeyButton_MouseDown);
            // 
            // InputSelectionTabs
            // 
            this.InputSelectionTabs.Controls.Add(this.MousePage);
            this.InputSelectionTabs.Controls.Add(this.KeyboardPage);
            this.InputSelectionTabs.Location = new System.Drawing.Point(12, 124);
            this.InputSelectionTabs.Name = "InputSelectionTabs";
            this.InputSelectionTabs.SelectedIndex = 0;
            this.InputSelectionTabs.Size = new System.Drawing.Size(567, 142);
            this.InputSelectionTabs.TabIndex = 21;
            // 
            // MousePage
            // 
            this.MousePage.Controls.Add(this.ClickTypeLabel);
            this.MousePage.Controls.Add(this.MousebuttonDropdown);
            this.MousePage.Controls.Add(this.CursorPosition);
            this.MousePage.Location = new System.Drawing.Point(4, 22);
            this.MousePage.Name = "MousePage";
            this.MousePage.Padding = new System.Windows.Forms.Padding(3);
            this.MousePage.Size = new System.Drawing.Size(559, 116);
            this.MousePage.TabIndex = 0;
            this.MousePage.Text = "Mouse";
            this.MousePage.UseVisualStyleBackColor = true;
            // 
            // KeyboardPage
            // 
            this.KeyboardPage.Controls.Add(this.ActiveAutoKeyDisplay);
            this.KeyboardPage.Controls.Add(this.ChangeAutoKeyButton);
            this.KeyboardPage.Location = new System.Drawing.Point(4, 22);
            this.KeyboardPage.Name = "KeyboardPage";
            this.KeyboardPage.Padding = new System.Windows.Forms.Padding(3);
            this.KeyboardPage.Size = new System.Drawing.Size(559, 116);
            this.KeyboardPage.TabIndex = 1;
            this.KeyboardPage.Text = "Keyboard";
            this.KeyboardPage.UseVisualStyleBackColor = true;
            // 
            // ActiveAutoKeyDisplay
            // 
            this.ActiveAutoKeyDisplay.AutoSize = true;
            this.ActiveAutoKeyDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActiveAutoKeyDisplay.Location = new System.Drawing.Point(11, 9);
            this.ActiveAutoKeyDisplay.Name = "ActiveAutoKeyDisplay";
            this.ActiveAutoKeyDisplay.Size = new System.Drawing.Size(18, 17);
            this.ActiveAutoKeyDisplay.TabIndex = 15;
            this.ActiveAutoKeyDisplay.Text = "E";
            // 
            // ChangeAutoKeyButton
            // 
            this.ChangeAutoKeyButton.Location = new System.Drawing.Point(65, 9);
            this.ChangeAutoKeyButton.Name = "ChangeAutoKeyButton";
            this.ChangeAutoKeyButton.Size = new System.Drawing.Size(98, 23);
            this.ChangeAutoKeyButton.TabIndex = 0;
            this.ChangeAutoKeyButton.Text = "Change AutoKey";
            this.ChangeAutoKeyButton.UseVisualStyleBackColor = true;
            this.ChangeAutoKeyButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeAutoKey_KeyDown);
            this.ChangeAutoKeyButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChangeAutoKey_MouseDown);
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(553, 4);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(37, 13);
            this.VersionLabel.TabIndex = 22;
            this.VersionLabel.Text = "v1.2.0";
            // 
            // PowerClicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 450);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.InputSelectionTabs);
            this.Controls.Add(this.ChangeHotkeyButton);
            this.Controls.Add(this.ClickTypeBox);
            this.Controls.Add(this.HoldTimerBox);
            this.Controls.Add(this.ClickDurationBox);
            this.Controls.Add(this.HotKeyLabel);
            this.Controls.Add(this.TimerBox);
            this.Controls.Add(this.Countdown);
            this.Controls.Add(this.CountdownLabel);
            this.Controls.Add(this.CountdownTime);
            this.Controls.Add(this.EnabledToggle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PowerClicker";
            this.Text = "PowerClicker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PowerClicker_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.MilSecInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountdownTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimesInput)).EndInit();
            this.ClickTypeBox.ResumeLayout(false);
            this.ClickTypeBox.PerformLayout();
            this.TimerBox.ResumeLayout(false);
            this.TimerBox.PerformLayout();
            this.CursorPosition.ResumeLayout(false);
            this.CursorPosition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XInput)).EndInit();
            this.ClickDurationBox.ResumeLayout(false);
            this.ClickDurationBox.PerformLayout();
            this.HoldTimerBox.ResumeLayout(false);
            this.HoldTimerBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HoldMinInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoldSecInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoldMilSecInput)).EndInit();
            this.InputSelectionTabs.ResumeLayout(false);
            this.MousePage.ResumeLayout(false);
            this.MousePage.PerformLayout();
            this.KeyboardPage.ResumeLayout(false);
            this.KeyboardPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown MilSecInput;
        private System.Windows.Forms.NumericUpDown SecInput;
        private System.Windows.Forms.NumericUpDown MinInput;
        private System.Windows.Forms.NumericUpDown CountdownTime;
        private System.Windows.Forms.Label MilsecLabel;
        private System.Windows.Forms.Label SecLabel;
        private System.Windows.Forms.Label MinLabel;
        private System.Windows.Forms.Button EnabledToggle;
        private System.Windows.Forms.Label CountdownLabel;
        private System.Windows.Forms.Label Countdown;
        private System.Windows.Forms.NumericUpDown TimesInput;
        private System.Windows.Forms.GroupBox ClickTypeBox;
        private System.Windows.Forms.RadioButton RepeatSelect;
        private System.Windows.Forms.RadioButton TimesSelect;
        private System.Windows.Forms.GroupBox TimerBox;
        private System.Windows.Forms.Label HotKeyLabel;
        private System.Windows.Forms.GroupBox CursorPosition;
        private System.Windows.Forms.NumericUpDown YInput;
        private System.Windows.Forms.NumericUpDown XInput;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.Timer ClickTimer;
        private System.Windows.Forms.RadioButton CursorSelect;
        private System.Windows.Forms.RadioButton CoordinatesSelect;
        private System.Windows.Forms.Label TimesDoneLabel;
        private System.Windows.Forms.Timer HoldTimer;
        private System.Windows.Forms.ComboBox MousebuttonDropdown;
        private System.Windows.Forms.Label ClickTypeLabel;
        private System.Windows.Forms.GroupBox ClickDurationBox;
        private System.Windows.Forms.RadioButton HoldSelect;
        private System.Windows.Forms.RadioButton InstantSelect;
        private System.Windows.Forms.GroupBox HoldTimerBox;
        private System.Windows.Forms.Label HoldMinLabel;
        private System.Windows.Forms.Label HoldSecLabel;
        private System.Windows.Forms.Label HoldMilsecLabel;
        private System.Windows.Forms.NumericUpDown HoldMinInput;
        private System.Windows.Forms.NumericUpDown HoldSecInput;
        private System.Windows.Forms.NumericUpDown HoldMilSecInput;
        private System.Windows.Forms.Button ChangeHotkeyButton;
        private System.Windows.Forms.ToolTip HotkeyTooltip;
        private System.Windows.Forms.Button CoordsButton;
        private System.Windows.Forms.TabControl InputSelectionTabs;
        private System.Windows.Forms.TabPage MousePage;
        private System.Windows.Forms.TabPage KeyboardPage;
        private System.Windows.Forms.ToolTip ComingSoonTip;
        private System.Windows.Forms.Label ComingSoonLabel;
        private System.Windows.Forms.Label ActiveAutoKeyDisplay;
        private System.Windows.Forms.Button ChangeAutoKeyButton;
        private System.Windows.Forms.Label VersionLabel;
    }
}

