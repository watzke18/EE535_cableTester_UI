namespace cableFactoryTestApp
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configCommPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timeRemainingTimer = new System.Windows.Forms.Timer(this.components);
            this.labelTimeRemaining = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTestInProgress = new System.Windows.Forms.Label();
            this.labelTestInProgressTimer = new System.Windows.Forms.Timer(this.components);
            this.consoleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.closeCommBtn = new System.Windows.Forms.Button();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openCommBtn
            // 
            this.openCommBtn.Location = new System.Drawing.Point(12, 39);
            this.openCommBtn.Name = "openCommBtn";
            this.openCommBtn.Size = new System.Drawing.Size(226, 50);
            this.openCommBtn.TabIndex = 0;
            this.openCommBtn.Text = "Open Comm ";
            this.openCommBtn.UseVisualStyleBackColor = true;
            this.openCommBtn.Click += new System.EventHandler(this.openCommBtn_Click);
            // 
            // testSetupBtn
            // 
            this.testSetupBtn.Location = new System.Drawing.Point(12, 95);
            this.testSetupBtn.Name = "testSetupBtn";
            this.testSetupBtn.Size = new System.Drawing.Size(226, 52);
            this.testSetupBtn.TabIndex = 2;
            this.testSetupBtn.Text = "Test Setup";
            this.testSetupBtn.UseVisualStyleBackColor = true;
            this.testSetupBtn.Click += new System.EventHandler(this.testSetupBtn_Click);
            // 
            // startTestBtn
            // 
            this.startTestBtn.Location = new System.Drawing.Point(12, 153);
            this.startTestBtn.Name = "startTestBtn";
            this.startTestBtn.Size = new System.Drawing.Size(226, 50);
            this.startTestBtn.TabIndex = 3;
            this.startTestBtn.Text = "Start Test";
            this.startTestBtn.UseVisualStyleBackColor = true;
            this.startTestBtn.Click += new System.EventHandler(this.startTestBtn_Click);
            // 
            // abortTestBtn
            // 
            this.abortTestBtn.Location = new System.Drawing.Point(12, 209);
            this.abortTestBtn.Name = "abortTestBtn";
            this.abortTestBtn.Size = new System.Drawing.Size(226, 50);
            this.abortTestBtn.TabIndex = 4;
            this.abortTestBtn.Text = "Abort Test";
            this.abortTestBtn.UseVisualStyleBackColor = true;
            // 
            // labelSpinMotorStatus
            // 
            this.labelSpinMotorStatus.AutoSize = true;
            this.labelSpinMotorStatus.Location = new System.Drawing.Point(15, 309);
            this.labelSpinMotorStatus.Name = "labelSpinMotorStatus";
            this.labelSpinMotorStatus.Size = new System.Drawing.Size(120, 17);
            this.labelSpinMotorStatus.TabIndex = 5;
            this.labelSpinMotorStatus.Text = "Spin Motor Status";
            // 
            // labelLoadSensorStatus
            // 
            this.labelLoadSensorStatus.AutoSize = true;
            this.labelLoadSensorStatus.Location = new System.Drawing.Point(15, 342);
            this.labelLoadSensorStatus.Name = "labelLoadSensorStatus";
            this.labelLoadSensorStatus.Size = new System.Drawing.Size(133, 17);
            this.labelLoadSensorStatus.TabIndex = 6;
            this.labelLoadSensorStatus.Text = "Load Sensor Status";
            this.labelLoadSensorStatus.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelContinuityStatus
            // 
            this.labelContinuityStatus.AutoSize = true;
            this.labelContinuityStatus.Location = new System.Drawing.Point(15, 374);
            this.labelContinuityStatus.Name = "labelContinuityStatus";
            this.labelContinuityStatus.Size = new System.Drawing.Size(114, 17);
            this.labelContinuityStatus.TabIndex = 7;
            this.labelContinuityStatus.Text = "Continuity Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Loops";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 461);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Time Remaining";
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
            this.menuStrip1.Size = new System.Drawing.Size(690, 28);
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
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configCommPortToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.setupToolStripMenuItem.Text = "Setup";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.commToolStripMenuItem_Click);
            // 
            // configCommPortToolStripMenuItem
            // 
            this.configCommPortToolStripMenuItem.Name = "configCommPortToolStripMenuItem";
            this.configCommPortToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.configCommPortToolStripMenuItem.Text = "Configure Comm Port";
            this.configCommPortToolStripMenuItem.Click += new System.EventHandler(this.configCommPortToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // timeRemainingTimer
            // 
            this.timeRemainingTimer.Interval = 1000;
            this.timeRemainingTimer.Tick += new System.EventHandler(this.timeRemainingTimer_Tick);
            // 
            // labelTimeRemaining
            // 
            this.labelTimeRemaining.BackColor = System.Drawing.SystemColors.Window;
            this.labelTimeRemaining.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTimeRemaining.Location = new System.Drawing.Point(151, 460);
            this.labelTimeRemaining.Name = "labelTimeRemaining";
            this.labelTimeRemaining.Size = new System.Drawing.Size(100, 23);
            this.labelTimeRemaining.TabIndex = 16;
            this.labelTimeRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(151, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(151, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(151, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Window;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(151, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 20;
            // 
            // labelTestInProgress
            // 
            this.labelTestInProgress.BackColor = System.Drawing.Color.Red;
            this.labelTestInProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestInProgress.Location = new System.Drawing.Point(15, 525);
            this.labelTestInProgress.Name = "labelTestInProgress";
            this.labelTestInProgress.Size = new System.Drawing.Size(641, 40);
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
            this.consoleRichTextBox.Location = new System.Drawing.Point(390, 39);
            this.consoleRichTextBox.Name = "consoleRichTextBox";
            this.consoleRichTextBox.Size = new System.Drawing.Size(288, 386);
            this.consoleRichTextBox.TabIndex = 22;
            this.consoleRichTextBox.Text = "";
            // 
            // closeCommBtn
            // 
            this.closeCommBtn.Location = new System.Drawing.Point(245, 39);
            this.closeCommBtn.Name = "closeCommBtn";
            this.closeCommBtn.Size = new System.Drawing.Size(139, 30);
            this.closeCommBtn.TabIndex = 23;
            this.closeCommBtn.Text = "Close Comm";
            this.closeCommBtn.UseVisualStyleBackColor = true;
            this.closeCommBtn.Click += new System.EventHandler(this.closeCommBtn_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 574);
            this.Controls.Add(this.closeCommBtn);
            this.Controls.Add(this.consoleRichTextBox);
            this.Controls.Add(this.labelTestInProgress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTimeRemaining);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelContinuityStatus);
            this.Controls.Add(this.labelLoadSensorStatus);
            this.Controls.Add(this.labelSpinMotorStatus);
            this.Controls.Add(this.abortTestBtn);
            this.Controls.Add(this.startTestBtn);
            this.Controls.Add(this.testSetupBtn);
            this.Controls.Add(this.openCommBtn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Cable Twist/Pull Test App";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timeRemainingTimer;
        private System.Windows.Forms.Label labelTimeRemaining;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTestInProgress;
        private System.Windows.Forms.Timer labelTestInProgressTimer;
        private System.Windows.Forms.ToolStripMenuItem configCommPortToolStripMenuItem;
        private System.Windows.Forms.RichTextBox consoleRichTextBox;
        private System.Windows.Forms.Button closeCommBtn;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

