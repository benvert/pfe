namespace SQL
{
    partial class RelayForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Write_button = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Exit_button = new System.Windows.Forms.Button();
            this.Disconnect_button = new System.Windows.Forms.Button();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.IpBox = new System.Windows.Forms.TextBox();
            this.Connect_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Initialise_button = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.db_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.OPCINFO = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FillButton = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.vinTab = new System.Windows.Forms.TabPage();
            this.repportTab = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CreateButton = new System.Windows.Forms.Button();
            this.Get_reports = new System.Windows.Forms.Button();
            this.StopReporting = new System.Windows.Forms.Button();
            this.NamesCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oPCServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oPCClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.selectedreport = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.vinTab.SuspendLayout();
            this.repportTab.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Write_button);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.Exit_button);
            this.groupBox1.Controls.Add(this.Disconnect_button);
            this.groupBox1.Controls.Add(this.PassBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.PortBox);
            this.groupBox1.Controls.Add(this.IpBox);
            this.groupBox1.Controls.Add(this.Connect_button);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 214);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connnection Parameters";
            // 
            // Write_button
            // 
            this.Write_button.BackColor = System.Drawing.Color.DarkTurquoise;
            this.Write_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Write_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Write_button.Location = new System.Drawing.Point(15, 169);
            this.Write_button.Name = "Write_button";
            this.Write_button.Size = new System.Drawing.Size(87, 23);
            this.Write_button.TabIndex = 9;
            this.Write_button.Text = "Write To IED";
            this.Write_button.UseVisualStyleBackColor = false;
            this.Write_button.Click += new System.EventHandler(this.Write_button_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(31, 82);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(117, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Use password auth";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Exit_button
            // 
            this.Exit_button.BackColor = System.Drawing.Color.Crimson;
            this.Exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Exit_button.Location = new System.Drawing.Point(121, 168);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(75, 23);
            this.Exit_button.TabIndex = 11;
            this.Exit_button.Text = "Exit";
            this.Exit_button.UseVisualStyleBackColor = false;
            this.Exit_button.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Disconnect_button
            // 
            this.Disconnect_button.BackColor = System.Drawing.Color.DarkTurquoise;
            this.Disconnect_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Disconnect_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Disconnect_button.Location = new System.Drawing.Point(121, 139);
            this.Disconnect_button.Name = "Disconnect_button";
            this.Disconnect_button.Size = new System.Drawing.Size(75, 23);
            this.Disconnect_button.TabIndex = 10;
            this.Disconnect_button.Text = "Disconnect";
            this.Disconnect_button.UseVisualStyleBackColor = false;
            this.Disconnect_button.Click += new System.EventHandler(this.Disconnect_button_Click);
            // 
            // PassBox
            // 
            this.PassBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.PassBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PassBox.Location = new System.Drawing.Point(92, 105);
            this.PassBox.Name = "PassBox";
            this.PassBox.Size = new System.Drawing.Size(100, 20);
            this.PassBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label5.Location = new System.Drawing.Point(12, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Password:";
            // 
            // PortBox
            // 
            this.PortBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.PortBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PortBox.Location = new System.Drawing.Point(91, 55);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(100, 20);
            this.PortBox.TabIndex = 6;
            // 
            // IpBox
            // 
            this.IpBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.IpBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IpBox.Location = new System.Drawing.Point(91, 27);
            this.IpBox.Name = "IpBox";
            this.IpBox.Size = new System.Drawing.Size(100, 20);
            this.IpBox.TabIndex = 5;
            // 
            // Connect_button
            // 
            this.Connect_button.BackColor = System.Drawing.Color.DarkTurquoise;
            this.Connect_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Connect_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Connect_button.Location = new System.Drawing.Point(15, 139);
            this.Connect_button.Name = "Connect_button";
            this.Connect_button.Size = new System.Drawing.Size(87, 23);
            this.Connect_button.TabIndex = 4;
            this.Connect_button.Text = "Connect";
            this.Connect_button.UseVisualStyleBackColor = false;
            this.Connect_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IpAdress:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // Initialise_button
            // 
            this.Initialise_button.BackColor = System.Drawing.Color.DarkTurquoise;
            this.Initialise_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Initialise_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Initialise_button.Location = new System.Drawing.Point(10, 309);
            this.Initialise_button.Name = "Initialise_button";
            this.Initialise_button.Size = new System.Drawing.Size(75, 23);
            this.Initialise_button.TabIndex = 12;
            this.Initialise_button.Text = "Initialise";
            this.Initialise_button.UseVisualStyleBackColor = false;
            this.Initialise_button.Click += new System.EventHandler(this.Initialise_button_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.statusStrip1.AllowDrop = true;
            this.statusStrip1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStatus,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.db_status,
            this.toolStripStatusLabel2,
            this.OPCINFO});
            this.statusStrip1.Location = new System.Drawing.Point(0, 430);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(712, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(106, 17);
            this.toolStripStatusLabel1.Text = "Connection status:";
            // 
            // toolStatus
            // 
            this.toolStatus.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.toolStatus.Name = "toolStatus";
            this.toolStatus.Size = new System.Drawing.Size(64, 17);
            this.toolStatus.Text = "Initial state";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(95, 17);
            this.toolStripStatusLabel4.Text = "Data base status:";
            // 
            // db_status
            // 
            this.db_status.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.db_status.Name = "db_status";
            this.db_status.Size = new System.Drawing.Size(43, 17);
            this.db_status.Text = "Offline";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(78, 17);
            this.toolStripStatusLabel2.Text = "|  OPC Status:";
            // 
            // OPCINFO
            // 
            this.OPCINFO.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.OPCINFO.Name = "OPCINFO";
            this.OPCINFO.Size = new System.Drawing.Size(44, 17);
            this.OPCINFO.Text = "Started";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.groupBox2.Controls.Add(this.FillButton);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.ClearBtn);
            this.groupBox2.Controls.Add(this.dataGridView);
            this.groupBox2.Controls.Add(this.Initialise_button);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.groupBox2.Location = new System.Drawing.Point(15, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 342);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manipulated_Data";
            // 
            // FillButton
            // 
            this.FillButton.BackColor = System.Drawing.Color.DarkTurquoise;
            this.FillButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FillButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FillButton.Location = new System.Drawing.Point(102, 309);
            this.FillButton.Name = "FillButton";
            this.FillButton.Size = new System.Drawing.Size(75, 23);
            this.FillButton.TabIndex = 17;
            this.FillButton.Text = "Fill";
            this.FillButton.UseVisualStyleBackColor = false;
            this.FillButton.Click += new System.EventHandler(this.FillButton_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.checkBox2.Location = new System.Drawing.Point(302, 312);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(73, 17);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.Text = "Stop timer";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.Color.DarkTurquoise;
            this.ClearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClearBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClearBtn.Location = new System.Drawing.Point(194, 309);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearBtn.TabIndex = 14;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = false;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(6, 17);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(395, 283);
            this.dataGridView.TabIndex = 9;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_UserDeletingRow);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.vinTab);
            this.tabControl1.Controls.Add(this.repportTab);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(248, 32);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(449, 386);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 14;
            // 
            // vinTab
            // 
            this.vinTab.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.vinTab.Controls.Add(this.groupBox2);
            this.vinTab.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.vinTab.Location = new System.Drawing.Point(4, 4);
            this.vinTab.Name = "vinTab";
            this.vinTab.Padding = new System.Windows.Forms.Padding(3);
            this.vinTab.Size = new System.Drawing.Size(441, 360);
            this.vinTab.TabIndex = 0;
            this.vinTab.Text = "Virtual Inputs";
            // 
            // repportTab
            // 
            this.repportTab.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.repportTab.Controls.Add(this.dataGridView1);
            this.repportTab.Controls.Add(this.selectedreport);
            this.repportTab.Controls.Add(this.label3);
            this.repportTab.Location = new System.Drawing.Point(4, 4);
            this.repportTab.Name = "repportTab";
            this.repportTab.Padding = new System.Windows.Forms.Padding(3);
            this.repportTab.Size = new System.Drawing.Size(441, 360);
            this.repportTab.TabIndex = 1;
            this.repportTab.Text = "Reports";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel1);
            this.groupBox4.Controls.Add(this.NamesCombo);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.groupBox4.Location = new System.Drawing.Point(12, 247);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(213, 152);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Repports Parameters";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.CreateButton);
            this.flowLayoutPanel1.Controls.Add(this.Get_reports);
            this.flowLayoutPanel1.Controls.Add(this.StopReporting);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(193, 81);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.Color.DarkTurquoise;
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CreateButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CreateButton.Location = new System.Drawing.Point(3, 3);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(184, 33);
            this.CreateButton.TabIndex = 5;
            this.CreateButton.Text = "Create mdb";
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // Get_reports
            // 
            this.Get_reports.BackColor = System.Drawing.Color.DarkTurquoise;
            this.Get_reports.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Get_reports.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Get_reports.Location = new System.Drawing.Point(3, 42);
            this.Get_reports.Name = "Get_reports";
            this.Get_reports.Size = new System.Drawing.Size(89, 33);
            this.Get_reports.TabIndex = 7;
            this.Get_reports.Text = "Get reports";
            this.Get_reports.UseVisualStyleBackColor = false;
            this.Get_reports.Click += new System.EventHandler(this.Get_reports_Click);
            // 
            // StopReporting
            // 
            this.StopReporting.BackColor = System.Drawing.Color.Crimson;
            this.StopReporting.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StopReporting.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.StopReporting.Location = new System.Drawing.Point(98, 42);
            this.StopReporting.Name = "StopReporting";
            this.StopReporting.Size = new System.Drawing.Size(89, 33);
            this.StopReporting.TabIndex = 9;
            this.StopReporting.Text = "Stop reporting";
            this.StopReporting.UseVisualStyleBackColor = false;
            this.StopReporting.Click += new System.EventHandler(this.StopReporting_Click);
            // 
            // NamesCombo
            // 
            this.NamesCombo.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.NamesCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NamesCombo.FormattingEnabled = true;
            this.NamesCombo.Location = new System.Drawing.Point(53, 119);
            this.NamesCombo.Name = "NamesCombo";
            this.NamesCombo.Size = new System.Drawing.Size(99, 21);
            this.NamesCombo.TabIndex = 4;
            this.NamesCombo.SelectedIndexChanged += new System.EventHandler(this.NamesCombo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label4.Location = new System.Drawing.Point(58, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Report Name";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oPCToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(712, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oPCToolStripMenuItem
            // 
            this.oPCToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.oPCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oPCServerToolStripMenuItem,
            this.oPCClientToolStripMenuItem});
            this.oPCToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.oPCToolStripMenuItem.Name = "oPCToolStripMenuItem";
            this.oPCToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.oPCToolStripMenuItem.Text = "OPC";
            // 
            // oPCServerToolStripMenuItem
            // 
            this.oPCServerToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.oPCServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.oPCServerToolStripMenuItem.Name = "oPCServerToolStripMenuItem";
            this.oPCServerToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.oPCServerToolStripMenuItem.Text = "OPC Server";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.BackColor = System.Drawing.Color.Crimson;
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            // 
            // oPCClientToolStripMenuItem
            // 
            this.oPCClientToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.oPCClientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.oPCClientToolStripMenuItem.Name = "oPCClientToolStripMenuItem";
            this.oPCClientToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.oPCClientToolStripMenuItem.Text = "OPC Client";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.BackColor = System.Drawing.Color.Crimson;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label3.Location = new System.Drawing.Point(22, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Report Name:";
            // 
            // selectedreport
            // 
            this.selectedreport.AutoSize = true;
            this.selectedreport.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.selectedreport.Location = new System.Drawing.Point(101, 20);
            this.selectedreport.Name = "selectedreport";
            this.selectedreport.Size = new System.Drawing.Size(0, 13);
            this.selectedreport.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(428, 316);
            this.dataGridView1.TabIndex = 4;
            // 
            // RelayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(712, 452);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RelayForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.vinTab.ResumeLayout(false);
            this.repportTab.ResumeLayout(false);
            this.repportTab.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button Disconnect_button;
        private System.Windows.Forms.TextBox PassBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PortBox;
        private System.Windows.Forms.TextBox IpBox;
        private System.Windows.Forms.Button Connect_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Exit_button;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button Write_button;
        private System.Windows.Forms.Button Initialise_button;
        private System.Windows.Forms.ToolStripStatusLabel db_status;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage vinTab;
        private System.Windows.Forms.TabPage repportTab;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Get_reports;
        private System.Windows.Forms.Button StopReporting;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox NamesCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button FillButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oPCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oPCServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oPCClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel OPCINFO;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label selectedreport;
        private System.Windows.Forms.Label label3;
    }
}