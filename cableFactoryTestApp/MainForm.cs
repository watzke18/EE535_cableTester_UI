using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cableFactoryTestApp
{
    public partial class MainForm : Form
    {
        private int _startTime = 300;
        private int _counter;

        public commPort m_Comm = new commPort();

        public MainForm()
        {
            InitializeComponent();  
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_Comm.LoadSettings();
        }

        public void AppendConsoleText(string str)
        {
            consoleRichTextBox.AppendText(">" + str + "\n");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void startTestBtn_Click(object sender, EventArgs e)
        {
            timeRemainingTimer.Enabled = true;
            labelTestInProgressTimer.Enabled = true;
            labelTestInProgress.Visible = true;
            startTestBtn.Enabled = false;
        }
      
        private void timeRemainingTimer_Tick(object sender, EventArgs e)
        {
            labelTimeRemaining.Text = _startTime / 60 + ":" + ((_startTime % 60) >= 10 ? (_startTime % 60).ToString() : "0" + _startTime % 60);
            _startTime--;
        }

        private void consoleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool _testInProgress = false;
        private void labelTestProgressTimer_Tick(object sender, EventArgs e)
        {
            if (_testInProgress)
            {
                labelTestInProgress.Visible = true;
            }
            else
            {
                labelTestInProgress.Visible = false;
            }
              _testInProgress = !_testInProgress;
                
        
        }

        private void testSetupBtn_Click(object sender, EventArgs e)
        {
            TestSetup m_testSetup = new TestSetup();
            m_testSetup.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
 
            
        }

        private void commToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigCOMM dlg = new ConfigCOMM();

        }

        private void configCommPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigCOMM dlg = new ConfigCOMM();

            dlg.m_Settings = m_Comm.getPortSettings();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_Comm.Close();
                m_Comm.setPortSettings(dlg.m_Settings);
                m_Comm.Open();
            }

        }

        private void openCommBtn_Click(object sender, EventArgs e)
        {
            bool reply;
            reply = m_Comm.Open();

            if(!reply)
            {
                AppendConsoleText("Comm Port Failed to Open");
            }
            else
            {
                AppendConsoleText("Comm Opened Successfully");
                openCommBtn.Enabled = false;
            }

        }
    }
}
