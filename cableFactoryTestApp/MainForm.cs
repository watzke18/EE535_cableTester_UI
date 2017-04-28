using CsvHelper;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;



namespace cableFactoryTestApp
{
    public struct TestParameters
    {
        public string cable_description;
        public int test_duration;
        public int rest_duration;
        public float force_applied;
        public int loops_completed;
        public int total_loops;
        public int stop_on_break;
        public float data_rate;

        public string csv_save_path;
    }


    public partial class MainForm : Form
    {

        public commPort m_Comm = new commPort();
        public static TestParameters m_testParameters = new TestParameters();
        public SaveFileDialog sfd;
        public StreamWriter sw;
        public CsvWriter writer;
        public StringBuilder csv;


        private int _startTime;
        private int _restTime;
        private bool _labelToggle;
        private bool _testInProgress;
        private bool _testAborted;

 
        private int _microStatus; //holds status of microcontroller. 0 = rest, 1 = test

        public string[] data; //this array of strings will hold data temporarily until next update is received from micro


        public MainForm()
        {
            InitializeComponent();     
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_Comm.LoadSettings();

            csv = new StringBuilder();


            closeCommBtn.Enabled = false;
            testSetupBtn.Enabled = false;
            startTestBtn.Enabled = false;
            abortTestBtn.Enabled = false;
            labelRestRemaining.Enabled = false;
            labelBoxRestRemaining.Enabled = false;
            labelBoxRestRemaining.Enabled = false;

            /* set default test parameters */

            m_testParameters.cable_description = "";
            m_testParameters.test_duration = 5;
            m_testParameters.rest_duration = 3;
            m_testParameters.force_applied = 1.0F;
            m_testParameters.loops_completed = 0;
            m_testParameters.total_loops = 1;
            m_testParameters.data_rate = 1000F; //in ms
            m_testParameters.stop_on_break = 0;
            m_testParameters.csv_save_path = "";

            _labelToggle = false;
            _testInProgress = false;

            comboBoxRefreshRate.Text = "1000ms";
            timerRefresh.Interval = 1000;   
        }


        private void writeCSV(string force, string testDuration, string restDuration, int loopNumber,  int breakDetected)
        {
            csv.AppendLine(m_testParameters.cable_description + ", " + DateTime.Now.ToString() + ", " + m_testParameters.test_duration + ", " + m_testParameters.rest_duration + ", " + force + ", " + m_testParameters.loops_completed + ", " + m_testParameters.total_loops + ", " + breakDetected);
            File.AppendAllText(m_testParameters.csv_save_path, csv.ToString());

        }

        private void refreshData()
        {
            string msg = "";

            if (transmit_message("DATA"))
            {
                if(receive_message(ref msg))
                {
                    parseMessage(ref msg);

                    labelBoxLoad.Text = data[0];
                    labelMotorPos.Text = data[1];
                    labelBoxCont.Text = data[2];
                    
                    //log data here 

                   // writeCSV(data[0], )
                  

                    //could add current test loop into data string?
                }
               
            }
            else
            {
                AppendConsoleText("Error reading inputs from Arduino");
            }

            labelBoxLoops.Text = m_testParameters.loops_completed + "/" + m_testParameters.total_loops;
        }

        private void logData(string[] args)
        {

        }

        private string[] parseMessage(ref string message)
        {
            AppendConsoleText(message);
            data = message.Split(' ');
          //  labelBoxAmbientTemp.Text = data[0];
            return data; 
        }

        private string buildTestString(int lot, int lor, int testReps, float force, int spinDegree, int stopOnBreak, float dataRate)
        {
            string testString = "";
            testString = lot + " " + lor + " " + testReps + " " + force + " " + spinDegree + " " + stopOnBreak;
          //  AppendConsoleText(testString);
            return testString;

        }
  
        public void AppendConsoleText(string str)
        {
            consoleRichTextBox.Focus();
            consoleRichTextBox.AppendText(">" + str + "\n");
        }

        public void enterTestMode()
        {
            //m_Comm.discardInBuffer();
            _testInProgress = true;
            timeRemainingTimer.Enabled = true;
            labelTestInProgressTimer.Enabled = true;
            labelTestInProgress.Visible = true;
            abortTestBtn.Enabled = true;
            startTestBtn.Enabled = false;
            testSetupBtn.Enabled = false;
            comboBoxRefreshRate.Enabled = false;
            timerRefresh.Enabled = true;

            //check for data on serial port using read command

           // while(_testInProgress)
            {
               
            }


        }

        public void exitTestMode()
        {
            _testInProgress = false;

            if(_testAborted)
            {
                AppendConsoleText("Test Aborted");
            }
            else
            {
                AppendConsoleText("Test Finished");
            }

            timeRemainingTimer.Enabled = false;
            timerRestRemaining.Enabled = false;
            labelTestInProgressTimer.Enabled = false;
            labelTestInProgress.Visible = false;
            testSetupBtn.Enabled = true;
            abortTestBtn.Enabled = false;
            startTestBtn.Enabled = true;
            comboBoxRefreshRate.Enabled = true;
            timerRefresh.Enabled = false;
            resetTestTimer();
            resetRestTimer();
          

        }

        /*********************************************************************
         * 
         * BEGIN MAINFORM EVENT METHODS
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
              //  m_Comm.m_SerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
                openCommBtn.Enabled = false;
                closeCommBtn.Enabled = true;
                testSetupBtn.Enabled = true;
            }
        }

        private void closeCommBtn_Click(object sender, EventArgs e)
        {
            if(_testInProgress)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to close comm port? This will abort the current test", "!", MessageBoxButtons.YesNo);
                if(dr == DialogResult.Yes)
                {
                    m_Comm.Close();
                    AppendConsoleText(m_Comm.getPortSettings().port_name + " Closed Successfully");

                    openCommBtn.Enabled = true;
                    comboBoxRefreshRate.Enabled = true;

                    closeCommBtn.Enabled = false;
                    testSetupBtn.Enabled = false;
                    startTestBtn.Enabled = false;
                    abortTestBtn.Enabled = false;
                    timeRemainingTimer.Enabled = false;
                    labelTestInProgressTimer.Enabled = false;
                    labelTestInProgress.Visible = false;
                   
                    labelBoxLoops.Text = "";

                    AppendConsoleText("Test Finished");
                    timeRemainingTimer.Enabled = false;
                    labelTestInProgressTimer.Enabled = false;
                    abortTestBtn.Enabled = false;
                    comboBoxRefreshRate.Enabled = true;
                    timerRefresh.Enabled = false;
                    labelBoxTimeRemaining.Text = "0:00";

                    //   exitTestMode();
                }
            
            }
           else
           {
                m_Comm.Close();
                AppendConsoleText(m_Comm.getPortSettings().port_name + " Closed Successfully");

                openCommBtn.Enabled = true;
                comboBoxRefreshRate.Enabled = true;

                closeCommBtn.Enabled = false;
                testSetupBtn.Enabled = false;
                startTestBtn.Enabled = false;
                abortTestBtn.Enabled = false;
                timeRemainingTimer.Enabled = false;

                labelBoxLoops.Text = "";
                timeRemainingTimer.Enabled = false;
                labelTestInProgressTimer.Enabled = false;
                abortTestBtn.Enabled = false;
                comboBoxRefreshRate.Enabled = true;
                timerRefresh.Enabled = false;
                labelBoxTimeRemaining.Text = "0:00";
            }


        }

        public string[] toArray(String testDescription, int testDuration, int restDuration, float forceApplied)
        {
            string[] toArray = new string[4];
            toArray[0] = testDescription;
            toArray[1] = testDuration.ToString();
            toArray[2] = restDuration.ToString();
            toArray[3] = forceApplied.ToString();
            return toArray;
        }
      

        private void testSetupBtn_Click(object sender, EventArgs e)
        {
            TestSetup m_testSetup = new TestSetup();
            string testString = "";

            m_testSetup.m_testParameters = m_testParameters;

            if (m_testSetup.ShowDialog() == DialogResult.OK) //user presses OK button in test setup form
            {
                AppendConsoleText(DateTime.Now.ToString());
                if(m_testParameters.csv_save_path == "") //if save as file has not already been set, prompt user to set. 
                {
                    /*using (sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            m_testParameters = m_testSetup.m_testParameters;
                            m_testParameters.csv_save_path = Path.GetFullPath(sfd.FileName);
                            labelFilepath.Text = m_testParameters.csv_save_path;


                             csv.AppendLine("Cable ID / Description, Date/Time, Test Duration (ms), Rest Duration (ms), Force (Nm), Loop #, Total Loops, Break Detected");
                             File.WriteAllText(sfd.FileName, csv.ToString());
                             csv.Clear();

                            // using (sw = new StreamWriter(sfd.FileName))
                            //  {
                            //   writer = new CsvWriter(sw);
                            //   writer.WriteRecord(toArray(m_testParameters.cable_description, m_testParameters.test_duration, m_testParameters.rest_duration, m_testParameters.force_applied));

                            // }


                        }
                    }*/
                    saveAs();
                    m_testParameters = m_testSetup.m_testParameters;
                    m_testParameters.csv_save_path = Path.GetFullPath(sfd.FileName);

                }
                else
                {
                    m_testParameters = m_testSetup.m_testParameters;
                    labelFilepath.Text = m_testParameters.csv_save_path;

                }


                testString = buildTestString(m_testParameters.test_duration, m_testParameters.rest_duration, m_testParameters.total_loops, m_testParameters.force_applied, 720, m_testParameters.stop_on_break, m_testParameters.data_rate / 1000);

              
                resetTestTimer(); //reset timer with time entered in test setup
                resetRestTimer();
                labelBoxLoops.Text = m_testParameters.loops_completed + "/" + m_testParameters.total_loops;

                if(transmit_message("TEST " + testString))
                {
                    AppendConsoleText("Test Parameters Entered");
                    startTestBtn.Enabled = true;
                }
                else
                {
                    AppendConsoleText("Failed to send Test Parameters string");
                }
            }
        }

        private void saveAs()
        {
            using (sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
            {
                sfd.FileName = Path.GetFileName(m_testParameters.csv_save_path);

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                  //  m_testParameters = m_testSetup.m_testParameters;
                    m_testParameters.csv_save_path = Path.GetFullPath(sfd.FileName);
                    labelFilepath.Text = m_testParameters.csv_save_path;


                    csv.AppendLine("Cable ID / Description, Date/Time, Test Duration (ms), Rest Duration (ms), Force (Nm), Loop #, Total Loops, Break Detected");
                    File.WriteAllText(sfd.FileName, csv.ToString());
                    csv.Clear();

                    // using (sw = new StreamWriter(sfd.FileName))
                    //  {
                    //   writer = new CsvWriter(sw);
                    //   writer.WriteRecord(toArray(m_testParameters.cable_description, m_testParameters.test_duration, m_testParameters.rest_duration, m_testParameters.force_applied));

                    // }


                }
            }

        }

 

 
        private void startTestBtn_Click(object sender, EventArgs e)
        {
            string temp = "";
            string ready = "";
            m_testParameters.loops_completed = 0;
            // m_Comm.discardInBuffer();

           
            if (read_temperature_command(ref temp))
            {
                AppendConsoleText("Temperature and Humidity Recorded");
                labelBoxAmbientTemp.Text = temp;

                if (transmit_message("START"))
                {
                    AppendConsoleText("Starting Test");
                    _testInProgress = true;
                   // while(m_Comm.m_SerialPort.ReadLine() != "READY")
                   // {

                   // }

                    enterTestMode();
                }
                else
                {
                    AppendConsoleText("Failed to send START command to micro");
                }
            }
          
            else
            {
                AppendConsoleText("Failed to send or receive TEMP/HUMIDITY command micro");
            }
        }

        private void abortTestBtn_Click(object sender, EventArgs e)
        {
            if (transmit_message("STOP"))
            {
                _testAborted = true;
                exitTestMode();
            }
            else
            {
                AppendConsoleText("Failed to send STOP command to micro on abort! ");
            }
        }
        private void comboBoxRefreshRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxRefreshRate.SelectedIndex)
            {
                case 0:
                    timerRefresh.Interval = 100;
                    m_testParameters.data_rate = 100;
                    break;
                case 1:
                    timerRefresh.Interval = 250;
                    m_testParameters.data_rate = 250;

                    break;
                case 2:
                    timerRefresh.Interval = 500;
                    m_testParameters.data_rate = 500;
                    break;
                case 3:
                    timerRefresh.Interval = 1000;
                    m_testParameters.data_rate = 1000;
                    break;
                case 4:
                    timerRefresh.Interval = 2000;
                    m_testParameters.data_rate = 2000;
                    break;
                case 5:
                    timerRefresh.Interval = 5000;
                    m_testParameters.data_rate = 5000;
                    break;
                default:
                    timerRefresh.Interval = 1000;
                    m_testParameters.data_rate = 1000;
                    comboBoxRefreshRate.SelectedIndex = 1;
                    break;
            }
        }




        /*********************************************************************
         * 
         * END MAINFORM BUTTON EVENT METHODS
         * 
         *********************************************************************/


        /*********************************************************************
         * 
         * BEGIN MAINFORM TIMERS
         * 
         *********************************************************************/

        private void resetTestTimer()
        {
            _startTime = m_testParameters.test_duration * 60;
            labelBoxTimeRemaining.Text = _startTime / 60 + ":" + ((_startTime % 60) >= 10 ? (_startTime % 60).ToString() : "0" + _startTime % 60);
        }
        private void resetRestTimer()
        {
            _restTime = m_testParameters.rest_duration * 60;
            labelBoxRestRemaining.Text = _restTime / 60 + ":" + ((_restTime % 60) >= 10 ? (_restTime % 60).ToString() : "0" + _restTime % 60);
        }


        private void timeRemainingTimer_Tick(object sender, EventArgs e)
        {
          
            labelBoxTimeRemaining.Text = _startTime / 60 + ":" + ((_startTime % 60) >= 10 ? (_startTime % 60).ToString() : "0" + _startTime % 60);
            _startTime--;

            if(_startTime == -1)
            {
                timerRefresh.Enabled = false;
                timeRemainingTimer.Enabled = false;

                if(m_testParameters.total_loops > 1 || m_testParameters.loops_completed <= m_testParameters.total_loops)
                { 
                    if(transmit_message("REST"))
                    {
                        
                        labelBoxRestRemaining.Enabled = true;
                        labelRestRemaining.Enabled = true;
                        labelBoxTimeRemaining.Enabled = false;
                        labelTimeRemain.Enabled = false;
                        timerRestRemaining.Enabled = true;

                        string _microString = "";

                        while (_microStatus == 0)
                        {
                            if(transmit_message("STATUS"))
                            {
                                if(receive_message(ref _microString))
                                {
                                    _microStatus = Convert.ToInt32(_microString);
                                }
                            }
                        }

                        resetTestTimer();

                    }
                    else
                    {
                        AppendConsoleText("Failed to send STOP REST command at end of test rep");
                    }
                }
                else //test is over with
                {
                    if(transmit_message("STOP"))
                    {
                        exitTestMode();
                    }
                    else
                    {
                        AppendConsoleText("Failed to send STOP command at end of test");
                    }
                }
                      
            }
           
        }

        private void timerRestRemaining_Tick(object sender, EventArgs e)
        {
            labelBoxRestRemaining.Text = _restTime / 60 + ":" + ((_restTime % 60) >= 10 ? (_restTime % 60).ToString() : "0" + _restTime % 60);
            _restTime--;

            if(_restTime == -1)
            {
                m_testParameters.loops_completed++; //finished rest cycle. full loop completed

                if (m_testParameters.loops_completed <= m_testParameters.total_loops) 
                {

                    if (transmit_message("START"))
                    {

                        timerRestRemaining.Enabled = false;
                        labelBoxRestRemaining.Enabled = false;
                        labelRestRemaining.Enabled = false;
                        labelBoxTimeRemaining.Enabled = true;
                        labelTimeRemain.Enabled = true;
                        timerRefresh.Enabled = true;
                        timeRemainingTimer.Enabled = true;
                        resetRestTimer();
                    }
                    else
                    {
                        AppendConsoleText("failed to send START command at end of rest");
                    }
                }
                else
                {
                    exitTestMode();
                }
            }

        }

        private void labelTestProgressTimer_Tick(object sender, EventArgs e)
        {
            if (_labelToggle)
            {
                labelTestInProgress.Visible = true;
            }
            else
            {
                labelTestInProgress.Visible = false;
            }
            _labelToggle = !_labelToggle ;
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            refreshData();
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


        private void xlsdefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|Excel files (*.xls)|.xls";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }


        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.FileName = Path.GetFileName(m_testParameters.csv_save_path);
                        saveFileDialog1.Filter = "CSV|*.csv"; saveFileDialog1.ValidateNames = true; saveFileDialog1.RestoreDirectory = true;



                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            //System.IO.File.Move(m_testParameters.csv_save_path, saveFileDialog1.FileName);
                            m_testParameters.csv_save_path = saveFileDialog1.FileName;
                            labelFilepath.Text = m_testParameters.csv_save_path;


                            csv.AppendLine("Cable ID / Description, Date/Time, Test Duration (ms), Rest Duration (ms), Force (Nm), Loop #, Total Loops, Break Detected");
                            File.WriteAllText(saveFileDialog1.FileName, csv.ToString());

                        }*/
            saveAs();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            if(about.ShowDialog() == DialogResult.OK)
            {
               // this.Close();
            }
        }


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

            if(_testInProgress)
            {
                MessageBox.Show("Cannot configure comm port while test is in progress", "Error", MessageBoxButtons.OK);
            }
            else
            {
                ConfigCOMM dlg = new ConfigCOMM();

                dlg.m_Settings = m_Comm.getPortSettings();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (m_Comm.isOpen())
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

                    closeCommBtn.Enabled = false;
                    openCommBtn.Enabled = true;

                    //m_Comm.Open();
                }

            }
           

        }

        private void calibrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calibration calibration = new Calibration();
            if(calibration.ShowDialog() == DialogResult.OK)
            {
                
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

        public bool read_inputs_command(ref string str)
        {
            bool reply = false;

            if (transmit_message("DATA"))
            {
                if (receive_message(ref str))
                {
                    reply = true;
                }
                else
                {
                    AppendConsoleText("Failed to receive input DATA");
                    reply = false;
                }

            }

            else
            {
                AppendConsoleText("Failed to transmit command DATA");
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
         * BEGIN  MAINFORM DATA WRITE COMMANDS
         * 
       *********************************************************************/


        public bool write_outputs_command(ref string str)
        {
            bool reply = false;

            return reply;
        }


       /*********************************************************************
        * 
        * END MAINFORM DATA WRITE COMMANDS
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
                msg = m_Comm.read();
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

        private void button1_Click(object sender, EventArgs e)
        {
            consoleRichTextBox.Clear();
        }

     







        /*********************************************************************
        * END MAINFORM SERIAL PORT READ/WRITE COMMANDS
        * 
        *********************************************************************/


    }

   

}
