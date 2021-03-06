﻿namespace cableFactoryTestApp
{
    partial class MainForm
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
            this.openCommBtn = new System.Windows.Forms.Button();
            this.testSetupBtn = new System.Windows.Forms.Button();
            this.startTestBtn = new System.Windows.Forms.Button();
            this.abortTestBtn = new System.Windows.Forms.Button();
            this.labelSpinMotorStatus = new System.Windows.Forms.Label();
            this.labelLoadSensorStatus = new System.Windows.Forms.Label();
            this.labelContinuityStatus = new System.Windows.Forms.Label();
            this.labelLoops = new System.Windows.Forms.Label();
            this.labelTimeRemain = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configCommPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timeRemainingTimer = new System.Windows.Forms.Timer(this.components);
            this.labelBoxTimeRemaining = new System.Windows.Forms.Label();
            this.labelBoxLoops = new System.Windows.Forms.Label();
            this.labelBoxCont = new System.Windows.Forms.Label();
            this.labelBoxLoad = new System.Windows.Forms.Label();
            this.labelMotorPos = new System.Windows.Forms.Label();
            this.labelTestInProgress = new System.Windows.Forms.Label();
            this.labelTestInProgressTimer = new System.Windows.Forms.Timer(this.components);
            this.consoleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.closeCommBtn = new System.Windows.Forms.Button();
            this.labelAmbientTemp = new System.Windows.Forms.Label();
            this.labelBoxAmbientTemp = new System.Windows.Forms.Label();
            this.labelRefreshRate = new System.Windows.Forms.Label();
            this.comboBoxRefreshRate = new System.Windows.Forms.ComboBox();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.labelConsole = new System.Windows.Forms.Label();
            this.groupBoxTestData = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBoxTestData.SuspendLayout();
            this.SuspendLayout();
            // 
            // openCommBtn
            // 
            this.openCommBtn.Location = new System.Drawing.Point(12, 49);
            this.openCommBtn.Name = "openCommBtn";
            this.openCommBtn.Size = new System.Drawing.Size(226, 50);
            this.openCommBtn.TabIndex = 0;
            this.openCommBtn.Text = "Open Comm ";
            this.openCommBtn.UseVisualStyleBackColor = true;
            this.openCommBtn.Click += new System.EventHandler(this.openCommBtn_Click);
            // 
            // testSetupBtn
            // 
            this.testSetupBtn.Location = new System.Drawing.Point(12, 192);
            this.testSetupBtn.Name = "testSetupBtn";
            this.testSetupBtn.Size = new System.Drawing.Size(226, 52);
            this.testSetupBtn.TabIndex = 2;
            this.testSetupBtn.Text = "Test Setup";
            this.testSetupBtn.UseVisualStyleBackColor = true;
            this.testSetupBtn.Click += new System.EventHandler(this.testSetupBtn_Click);
            // 
            // startTestBtn
            // 
            this.startTestBtn.Location = new System.Drawing.Point(12, 250);
            this.startTestBtn.Name = "startTestBtn";
            this.startTestBtn.Size = new System.Drawing.Size(226, 50);
            this.startTestBtn.TabIndex = 3;
            this.startTestBtn.Text = "Start Test";
            this.startTestBtn.UseVisualStyleBackColor = true;
            this.startTestBtn.Click += new System.EventHandler(this.startTestBtn_Click);
            // 
            // abortTestBtn
            // 
            this.abortTestBtn.BackColor = System.Drawing.Color.DarkRed;
            this.abortTestBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abortTestBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.abortTestBtn.Location = new System.Drawing.Point(12, 302);
            this.abortTestBtn.Name = "abortTestBtn";
            this.abortTestBtn.Size = new System.Drawing.Size(226, 87);
            this.abortTestBtn.TabIndex = 4;
            this.abortTestBtn.Text = "ABORT TEST";
            this.abortTestBtn.UseVisualStyleBackColor = false;
            this.abortTestBtn.Click += new System.EventHandler(this.abortTestBtn_Click);
            // 
            // labelSpinMotorStatus
            // 
            this.labelSpinMotorStatus.AutoSize = true;
            this.labelSpinMotorStatus.Location = new System.Drawing.Point(12, 91);
            this.labelSpinMotorStatus.Name = "labelSpinMotorStatus";
            this.labelSpinMotorStatus.Size = new System.Drawing.Size(199, 17);
            this.labelSpinMotorStatus.TabIndex = 5;
            this.labelSpinMotorStatus.Text = "Spin Motor Position (Degree) :";
            // 
            // labelLoadSensorStatus
            // 
            this.labelLoadSensorStatus.AutoSize = true;
            this.labelLoadSensorStatus.Location = new System.Drawing.Point(12, 120);
            this.labelLoadSensorStatus.Name = "labelLoadSensorStatus";
            this.labelLoadSensorStatus.Size = new System.Drawing.Size(141, 17);
            this.labelLoadSensorStatus.TabIndex = 6;
            this.labelLoadSensorStatus.Text = "Load Sensor Status :";
            // 
            // labelContinuityStatus
            // 
            this.labelContinuityStatus.AutoSize = true;
            this.labelContinuityStatus.Location = new System.Drawing.Point(12, 152);
            this.labelContinuityStatus.Name = "labelContinuityStatus";
            this.labelContinuityStatus.Size = new System.Drawing.Size(122, 17);
            this.labelContinuityStatus.TabIndex = 7;
            this.labelContinuityStatus.Text = "Continuity Status :";
            // 
            // labelLoops
            // 
            this.labelLoops.AutoSize = true;
            this.labelLoops.Location = new System.Drawing.Point(12, 218);
            this.labelLoops.Name = "labelLoops";
            this.labelLoops.Size = new System.Drawing.Size(126, 17);
            this.labelLoops.TabIndex = 8;
            this.labelLoops.Text = "Loops Completed :";
            // 
            // labelTimeRemain
            // 
            this.labelTimeRemain.AutoSize = true;
            this.labelTimeRemain.Location = new System.Drawing.Point(12, 244);
            this.labelTimeRemain.Name = "labelTimeRemain";
            this.labelTimeRemain.Size = new System.Drawing.Size(118, 17);
            this.labelTimeRemain.TabIndex = 9;
            this.labelTimeRemain.Text = "Time Remaining :";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.setupToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(915, 28);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.saveToolStripMenuItem.Text = "Save As";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configCommPortToolStripMenuItem,
            this.calibrationToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // configCommPortToolStripMenuItem
            // 
            this.configCommPortToolStripMenuItem.Name = "configCommPortToolStripMenuItem";
            this.configCommPortToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.configCommPortToolStripMenuItem.Text = "Configure Comm Port";
            this.configCommPortToolStripMenuItem.Click += new System.EventHandler(this.configCommPortToolStripMenuItem_Click);
            // 
            // calibrationToolStripMenuItem
            // 
            this.calibrationToolStripMenuItem.Name = "calibrationToolStripMenuItem";
            this.calibrationToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.calibrationToolStripMenuItem.Text = "Calibration";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // timeRemainingTimer
            // 
            this.timeRemainingTimer.Interval = 1000;
            this.timeRemainingTimer.Tick += new System.EventHandler(this.timeRemainingTimer_Tick);
            // 
            // labelBoxTimeRemaining
            // 
            this.labelBoxTimeRemaining.BackColor = System.Drawing.SystemColors.Window;
            this.labelBoxTimeRemaining.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBoxTimeRemaining.Location = new System.Drawing.Point(248, 241);
            this.labelBoxTimeRemaining.Name = "labelBoxTimeRemaining";
            this.labelBoxTimeRemaining.Size = new System.Drawing.Size(100, 23);
            this.labelBoxTimeRemaining.TabIndex = 16;
            this.labelBoxTimeRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBoxLoops
            // 
            this.labelBoxLoops.BackColor = System.Drawing.SystemColors.Window;
            this.labelBoxLoops.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBoxLoops.Location = new System.Drawing.Point(248, 218);
            this.labelBoxLoops.Name = "labelBoxLoops";
            this.labelBoxLoops.Size = new System.Drawing.Size(100, 23);
            this.labelBoxLoops.TabIndex = 17;
            this.labelBoxLoops.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBoxCont
            // 
            this.labelBoxCont.BackColor = System.Drawing.SystemColors.Window;
            this.labelBoxCont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBoxCont.Location = new System.Drawing.Point(248, 149);
            this.labelBoxCont.Name = "labelBoxCont";
            this.labelBoxCont.Size = new System.Drawing.Size(100, 23);
            this.labelBoxCont.TabIndex = 18;
            this.labelBoxCont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBoxLoad
            // 
            this.labelBoxLoad.BackColor = System.Drawing.SystemColors.Window;
            this.labelBoxLoad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBoxLoad.Location = new System.Drawing.Point(248, 117);
            this.labelBoxLoad.Name = "labelBoxLoad";
            this.labelBoxLoad.Size = new System.Drawing.Size(100, 23);
            this.labelBoxLoad.TabIndex = 19;
            this.labelBoxLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMotorPos
            // 
            this.labelMotorPos.BackColor = System.Drawing.SystemColors.Window;
            this.labelMotorPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMotorPos.Location = new System.Drawing.Point(248, 88);
            this.labelMotorPos.Name = "labelMotorPos";
            this.labelMotorPos.Size = new System.Drawing.Size(100, 23);
            this.labelMotorPos.TabIndex = 20;
            this.labelMotorPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTestInProgress
            // 
            this.labelTestInProgress.BackColor = System.Drawing.Color.Red;
            this.labelTestInProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestInProgress.Location = new System.Drawing.Point(12, 405);
            this.labelTestInProgress.Name = "labelTestInProgress";
            this.labelTestInProgress.Size = new System.Drawing.Size(892, 27);
            this.labelTestInProgress.TabIndex = 21;
            this.labelTestInProgress.Text = "TEST IN PROGRESS";
            this.labelTestInProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTestInProgress.Visible = false;
            // 
            // labelTestInProgressTimer
            // 
            this.labelTestInProgressTimer.Interval = 1000;
            this.labelTestInProgressTimer.Tick += new System.EventHandler(this.labelTestProgressTimer_Tick);
            // 
            // consoleRichTextBox
            // 
            this.consoleRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleRichTextBox.Location = new System.Drawing.Point(248, 49);
            this.consoleRichTextBox.Name = "consoleRichTextBox";
            this.consoleRichTextBox.ReadOnly = true;
            this.consoleRichTextBox.Size = new System.Drawing.Size(288, 343);
            this.consoleRichTextBox.TabIndex = 22;
            this.consoleRichTextBox.Text = "";
            // 
            // closeCommBtn
            // 
            this.closeCommBtn.Location = new System.Drawing.Point(12, 105);
            this.closeCommBtn.Name = "closeCommBtn";
            this.closeCommBtn.Size = new System.Drawing.Size(226, 30);
            this.closeCommBtn.TabIndex = 23;
            this.closeCommBtn.Text = "Close Comm";
            this.closeCommBtn.UseVisualStyleBackColor = true;
            this.closeCommBtn.Click += new System.EventHandler(this.closeCommBtn_Click);
            // 
            // labelAmbientTemp
            // 
            this.labelAmbientTemp.AutoSize = true;
            this.labelAmbientTemp.Location = new System.Drawing.Point(12, 40);
            this.labelAmbientTemp.Name = "labelAmbientTemp";
            this.labelAmbientTemp.Size = new System.Drawing.Size(225, 17);
            this.labelAmbientTemp.TabIndex = 24;
            this.labelAmbientTemp.Text = "Ambient Temperature (°C) / rH % :";
            // 
            // labelBoxAmbientTemp
            // 
            this.labelBoxAmbientTemp.BackColor = System.Drawing.SystemColors.Window;
            this.labelBoxAmbientTemp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBoxAmbientTemp.Location = new System.Drawing.Point(248, 37);
            this.labelBoxAmbientTemp.Name = "labelBoxAmbientTemp";
            this.labelBoxAmbientTemp.Size = new System.Drawing.Size(100, 23);
            this.labelBoxAmbientTemp.TabIndex = 25;
            this.labelBoxAmbientTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRefreshRate
            // 
            this.labelRefreshRate.AutoSize = true;
            this.labelRefreshRate.Location = new System.Drawing.Point(12, 315);
            this.labelRefreshRate.Name = "labelRefreshRate";
            this.labelRefreshRate.Size = new System.Drawing.Size(100, 17);
            this.labelRefreshRate.TabIndex = 28;
            this.labelRefreshRate.Text = "Refresh Rate :";
            // 
            // comboBoxRefreshRate
            // 
            this.comboBoxRefreshRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRefreshRate.FormattingEnabled = true;
            this.comboBoxRefreshRate.Items.AddRange(new object[] {
            "100ms",
            "250ms",
            "500ms",
            "1000ms",
            "2000ms",
            "5000ms"});
            this.comboBoxRefreshRate.Location = new System.Drawing.Point(232, 312);
            this.comboBoxRefreshRate.Name = "comboBoxRefreshRate";
            this.comboBoxRefreshRate.Size = new System.Drawing.Size(116, 24);
            this.comboBoxRefreshRate.TabIndex = 29;
            this.comboBoxRefreshRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxRefreshRate_SelectedIndexChanged);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 1000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // labelConsole
            // 
            this.labelConsole.AutoSize = true;
            this.labelConsole.Location = new System.Drawing.Point(248, 32);
            this.labelConsole.Name = "labelConsole";
            this.labelConsole.Size = new System.Drawing.Size(59, 17);
            this.labelConsole.TabIndex = 30;
            this.labelConsole.Text = "Console";
            // 
            // groupBoxTestData
            // 
            this.groupBoxTestData.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxTestData.Controls.Add(this.labelAmbientTemp);
            this.groupBoxTestData.Controls.Add(this.comboBoxRefreshRate);
            this.groupBoxTestData.Controls.Add(this.labelBoxAmbientTemp);
            this.groupBoxTestData.Controls.Add(this.labelRefreshRate);
            this.groupBoxTestData.Controls.Add(this.labelSpinMotorStatus);
            this.groupBoxTestData.Controls.Add(this.labelMotorPos);
            this.groupBoxTestData.Controls.Add(this.labelLoadSensorStatus);
            this.groupBoxTestData.Controls.Add(this.labelBoxLoad);
            this.groupBoxTestData.Controls.Add(this.labelBoxTimeRemaining);
            this.groupBoxTestData.Controls.Add(this.labelBoxLoops);
            this.groupBoxTestData.Controls.Add(this.labelTimeRemain);
            this.groupBoxTestData.Controls.Add(this.labelBoxCont);
            this.groupBoxTestData.Controls.Add(this.labelContinuityStatus);
            this.groupBoxTestData.Controls.Add(this.labelLoops);
            this.groupBoxTestData.Location = new System.Drawing.Point(542, 49);
            this.groupBoxTestData.Name = "groupBoxTestData";
            this.groupBoxTestData.Size = new System.Drawing.Size(362, 343);
            this.groupBoxTestData.TabIndex = 30;
            this.groupBoxTestData.TabStop = false;
            this.groupBoxTestData.Text = "System Data";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 441);
            this.Controls.Add(this.groupBoxTestData);
            this.Controls.Add(this.closeCommBtn);
            this.Controls.Add(this.consoleRichTextBox);
            this.Controls.Add(this.labelTestInProgress);
            this.Controls.Add(this.abortTestBtn);
            this.Controls.Add(this.startTestBtn);
            this.Controls.Add(this.testSetupBtn);
            this.Controls.Add(this.openCommBtn);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Cable Twist/Pull Test App";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxTestData.ResumeLayout(false);
            this.groupBoxTestData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openCommBtn;
        private System.Windows.Forms.Button testSetupBtn;
        private System.Windows.Forms.Button startTestBtn;
        private System.Windows.Forms.Button abortTestBtn;
        private System.Windows.Forms.Label labelSpinMotorStatus;
        private System.Windows.Forms.Label labelLoadSensorStatus;
        private System.Windows.Forms.Label labelContinuityStatus;
        private System.Windows.Forms.Label labelLoops;
        private System.Windows.Forms.Label labelTimeRemain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timeRemainingTimer;
        private System.Windows.Forms.Label labelBoxTimeRemaining;
        private System.Windows.Forms.Label labelBoxLoops;
        private System.Windows.Forms.Label labelBoxCont;
        private System.Windows.Forms.Label labelBoxLoad;
        private System.Windows.Forms.Label labelMotorPos;
        private System.Windows.Forms.Label labelTestInProgress;
        private System.Windows.Forms.Timer labelTestInProgressTimer;
        private System.Windows.Forms.ToolStripMenuItem configCommPortToolStripMenuItem;
        private System.Windows.Forms.RichTextBox consoleRichTextBox;
        private System.Windows.Forms.Button closeCommBtn;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label labelAmbientTemp;
        private System.Windows.Forms.Label labelBoxAmbientTemp;
        private System.Windows.Forms.ToolStripMenuItem calibrationToolStripMenuItem;
        private System.Windows.Forms.Label labelRefreshRate;
        private System.Windows.Forms.ComboBox comboBoxRefreshRate;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Label labelConsole;
        private System.Windows.Forms.GroupBox groupBoxTestData;
    }
}

