﻿using System;
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
    public struct TestParameters
    {
        public string cable_description;
        public string test_duration;
        public string rest_duration;
        public int force_applied;
        public int loops;
    }


    public partial class MainForm : Form
    {

        public commPort m_Comm = new commPort();
        public TestParameters m_testParameters = new TestParameters();

        public MainForm()
        {
            InitializeComponent();  
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_Comm.LoadSettings();
            closeCommBtn.Visible = false;
            testSetupBtn.Enabled = false;
            startTestBtn.Enabled = false;
            abortTestBtn.Enabled = false;

            /* set default test parameters */

            m_testParameters.cable_description = " ";
            m_testParameters.test_duration = "5:00";
            m_testParameters.rest_duration = "3:00";
            m_testParameters.force_applied = 1;
            m_testParameters.loops = 1;
        }

        public void AppendConsoleText(string str)
        {
            consoleRichTextBox.AppendText(">" + str + "\n");
        }

        /*********************************************************************
         * 
         * BEGIN MAINFORM BUTTON CLICK EVENT METHODS
         * 
         *********************************************************************/


        private void openCommBtn_Click(object sender, EventArgs e)
        {
            bool reply;
            reply = m_Comm.Open();

            if (!reply)
            {
                AppendConsoleText(m_Comm.getPortSettings().port_name + " Failed to Open");
            }
            else
            {
                AppendConsoleText(m_Comm.getPortSettings().port_name + " Opened Successfully");
                openCommBtn.Enabled = false;
                closeCommBtn.Visible = true;
                testSetupBtn.Enabled = true;
            }

        }

        private void closeCommBtn_Click(object sender, EventArgs e)
        {
            m_Comm.Close();
            AppendConsoleText(m_Comm.getPortSettings().port_name + " Closed Successfully");
            openCommBtn.Enabled = true;
            closeCommBtn.Visible = false;
            testSetupBtn.Enabled = false;
            startTestBtn.Enabled = false;
        }

        private void testSetupBtn_Click(object sender, EventArgs e)
        {
            TestSetup m_testSetup = new TestSetup();



            if (m_testSetup.ShowDialog() == DialogResult.OK) //user presses OK button in test setup form
            {
                startTestBtn.Enabled = true;
                //send data to micro

            }
        }



        private void startTestBtn_Click(object sender, EventArgs e)
        {
            timeRemainingTimer.Enabled = true;
            labelTestInProgressTimer.Enabled = true;
            labelTestInProgress.Visible = true;
            startTestBtn.Enabled = false;
            abortTestBtn.Enabled = true;
        }

        private void abortTestBtn_Click(object sender, EventArgs e)
        {

        }

        private void readTempBtn_Click(object sender, EventArgs e)
        {
            byte[] xmit_byte = new byte[1];
            xmit_byte[0] = (byte) '*';
            transmit_message(ref xmit_byte, 1);
        }

        /*********************************************************************
         * 
         * END MAINFORM BUTTON CLICK EVENT METHODS
         * 
         *********************************************************************/


        /*********************************************************************
         * 
         * BEGIN MAINFORM TIMERS
         * 
         *********************************************************************/

        private int _startTime = 300;
        private bool _testInProgress = false;

        private void timeRemainingTimer_Tick(object sender, EventArgs e)
        {
            labelBoxTimeRemaining.Text = _startTime / 60 + ":" + ((_startTime % 60) >= 10 ? (_startTime % 60).ToString() : "0" + _startTime % 60);
            _startTime--;
        }

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

        /*********************************************************************
         * 
         * END MAINFORM TIMERS
         * 
         *********************************************************************/


        /*********************************************************************
         * 
         * BEGIN MAINFORM TOOLSTRIP MENU CLICK EVENT METHODS
         * 
         *********************************************************************/


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                this.Close();
            }    
        }

   
        private void configCommPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigCOMM dlg = new ConfigCOMM();

            dlg.m_Settings = m_Comm.getPortSettings();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if(m_Comm.isOpen())
                {
                    m_Comm.Close();
                    AppendConsoleText(m_Comm.getPortSettings().port_name + " Closed Successfully");
                    m_Comm.setPortSettings(dlg.m_Settings);
                    AppendConsoleText("Click Open Comm Button to Open " + m_Comm.getPortSettings().port_name);
 
                }
                else
                { 
                    m_Comm.setPortSettings(dlg.m_Settings);
                }
                
                closeCommBtn.Visible = false;
                openCommBtn.Enabled = true;
              
                //m_Comm.Open();
            }

        }


        /*********************************************************************
         * 
         * END MAINFORM TOOLSTRIP MENU CLICK EVENT METHODS
         * 
         *********************************************************************/


        /*********************************************************************
        * 
        * BEGIN MAINFORM SERIAL PORT READ COMMANDS
        * 
        *********************************************************************/

        public bool read_temperature_command(ref string str)
        {
            bool reply = false;
            byte[] xmit_buffer = new byte[3];
            return false;//placeholder
        }


        /*********************************************************************
        * 
        * END MAINFORM SERIAL PORT READ COMMANDS
        * 
        *********************************************************************/


        /*********************************************************************
        * 
        * BEGIN MAINFORM SERIAL PORT WRITE COMMANDS
        * 
        *********************************************************************/

        private bool transmit_message(ref byte[] msg, int msg_len)
        {
            bool reply;

            try
            {
                m_Comm.write(msg, 0, msg_len);
                reply = true;
            }
            catch
            {
                AppendConsoleText("Failed to transmit message");
                reply = false;
            }

            return reply;
        }

        private bool transmit_byte(byte data)
        {
            bool reply;
            byte[] msg = new byte[1];

            msg[0] = data;

            try
            {
                m_Comm.write(msg, 0, 1);
                reply = true;
            }
            catch
            {
                reply = false;
            }

            return reply;
        }

    





        /*********************************************************************
        * END MAINFORM SERIAL PORT WRITE COMMANDS
        * 
        *********************************************************************/


    }
}
