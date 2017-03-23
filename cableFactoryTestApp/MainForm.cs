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
    public struct TestParameters
    {
        public string cable_description;
        public int test_duration;
        public int rest_duration;
        public int force_applied;
        public int loops;
        public bool stop_on_break;
    }


    public partial class MainForm : Form
    {

        public commPort m_Comm = new commPort();
        public static TestParameters m_testParameters = new TestParameters();

        private int _startTime;
        private bool _testInProgress = false;

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
            m_testParameters.test_duration = 5;
            m_testParameters.rest_duration = 3;
            m_testParameters.force_applied = 1;
            m_testParameters.loops = 0;
        }

        private void refreshData()
        {
            //this is where all updating will occur
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
            abortTestBtn.Enabled = false;

            timeRemainingTimer.Enabled = false;
            labelTestInProgressTimer.Enabled = false;
            labelTestInProgress.Visible = false;

        }

        private void testSetupBtn_Click(object sender, EventArgs e)
        {
            TestSetup m_testSetup = new TestSetup();

            m_testSetup.m_testParameters = m_testParameters;

            if (m_testSetup.ShowDialog() == DialogResult.OK) //user presses OK button in test setup form
            {
                m_testParameters = m_testSetup.m_testParameters;
                _startTime = m_testParameters.test_duration * 60;
                startTestBtn.Enabled = true;
                //send data to micro

            }
        }

        private void startTestBtn_Click(object sender, EventArgs e)
        {
            timeRemainingTimer.Enabled = true;
            labelTestInProgressTimer.Enabled = true;
            labelTestInProgress.Visible = true;
            abortTestBtn.Enabled = true;
            startTestBtn.Enabled = false;
            testSetupBtn.Enabled = false;
          
        }

        private void abortTestBtn_Click(object sender, EventArgs e)
        {
            startTestBtn.Enabled = true; 
            testSetupBtn.Enabled = true;
            abortTestBtn.Enabled = false;

            timeRemainingTimer.Enabled = false;
            labelTestInProgressTimer.Enabled = false;
            labelTestInProgress.Visible = false;

            AppendConsoleText("Test Aborted!");
         
        }

        private void readTempBtn_Click(object sender, EventArgs e)
        {
            string temp = "";

            if(read_temperature_command(ref temp))
            {
                labelAmbientTemp.Text = temp;
            }
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
        * BEGIN MAINFORM DATA READ COMMANDS
        * 
        *********************************************************************/

        public bool read_temperature_command(ref string temp)
        {
            bool reply = false;
           
            if(transmit_message("TEMP"))
            {
                if(receive_message(ref temp))
                {
                    reply = true;
                }
                else
                {
                    AppendConsoleText("Failed to receive TEMP");
                    reply = false;
                }
            }
            else
            {
                AppendConsoleText("Failed to transmit command TEMP");
                reply = false;
            }
            return reply;
        }


        /*********************************************************************
        * 
        * END MAINFORM DATA READ COMMANDS
        * 
        *********************************************************************/


        /*********************************************************************
        * 
        * BEGIN MAINFORM SERIAL PORT READ/WRITE COMMANDS
        * 
        *********************************************************************/



        private bool receive_message(ref string msg)
        {
            bool reply;

            try
            {
                m_Comm.read();
                reply = true;
            }
            catch (TimeoutException)
            {
                AppendConsoleText("Timed out while trying to receive message");
                reply = false;
            }
            catch (Exception)
            {
                AppendConsoleText("failed to receive message");
                reply = false;
            }

            return reply;
        }
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

        private bool transmit_message(string msg)
        {
            bool reply;

            try
            {
                m_Comm.write(msg);
                reply = true;
            }
            catch
            {
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
        * END MAINFORM SERIAL PORT READ/WRITE COMMANDS
        * 
        *********************************************************************/


    }
}
