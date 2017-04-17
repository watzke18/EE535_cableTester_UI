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
    }


    public partial class MainForm : Form
    {

        public commPort m_Comm = new commPort();
        public static TestParameters m_testParameters = new TestParameters();
        public const int MAX_BUFF_SIZE = 100;


        private int _startTime;
        private bool _labelToggle;
        private bool _testInProgress;

        public string[] data; //this array of strings will hold data temporarily until next update is received from micro

        public char[] recv_buf;
        public int offset;

        public MainForm()
        {
            InitializeComponent();     
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            m_Comm.LoadSettings();
            recv_buf = new char[MAX_BUFF_SIZE];
            offset = 0;

            closeCommBtn.Enabled = false;
            testSetupBtn.Enabled = false;
            startTestBtn.Enabled = false;
            abortTestBtn.Enabled = false;

            /* set default test parameters */

            m_testParameters.cable_description = "";
            m_testParameters.test_duration = 5;
            m_testParameters.rest_duration = 3;
            m_testParameters.force_applied = 1.0F;
            m_testParameters.loops_completed = 0;
            m_testParameters.total_loops = 1;
            m_testParameters.data_rate = 1000F; //in ms
            m_testParameters.stop_on_break = 0;

            _labelToggle = false;
            _testInProgress = false;

            comboBoxRefreshRate.Text = "1000ms";
            timerRefresh.Interval = 1000;   
        }

        private static StringBuilder receiveBuffer = new StringBuilder();
        private string terminationSequence = "\r\n";
        private string rxString;

    /*    public void DataReceived(object sender, SerialDataReceivedEventArgs e) //DataReceived event - fires when data is received on serial port
        {
            int dataLength = m_Comm.m_SerialPort.BytesToRead;
            byte[] dataRec = new Byte[dataLength];
            m_Comm.m_SerialPort.Read(dataRec, 0, dataLength);

            rxString = System.Text.ASCIIEncoding.ASCII.GetString(dataRec);
            receiveBuffer.Append(rxString);

            string bufferString = receiveBuffer.ToString();

            int index = -1;

           do
            {
                index = bufferString.IndexOf(terminationSequence);
                if (index > -1)
                {
                    string message = bufferString.Substring(0, index);
                    bufferString = bufferString.Remove(0, index + terminationSequence.Length);
                   // data = parseMessage(message);

                }
            }
            while (index > -1);

            receiveBuffer = new StringBuilder(bufferString); //if termination character was not found, append this part of string to string builder.

            
        }

            */
        private void writeCSV(string time, float force, string motorPos, int contStat)
        {

        }


        private void refreshData()
        {
            string msg = "";

            if (read_inputs_command(ref msg))
            {
                parseMessage(ref msg);

                labelBoxLoad.Text = data[0];
                labelMotorPos.Text = data[1];
                labelBoxCont.Text = data[2];
            }
            else
            {
                AppendConsoleText("Error reading inputs from Arduino");
            }
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

        //    while(_testInProgress)
            {

            }


        }

        public void exitTestMode()
        {
        
                _testInProgress = false;

                AppendConsoleText("Test Finished");
                timeRemainingTimer.Enabled = false;
                labelTestInProgressTimer.Enabled = false;
                labelTestInProgress.Visible = false;
                testSetupBtn.Enabled = true;
                abortTestBtn.Enabled = false;
                startTestBtn.Enabled = true;
                comboBoxRefreshRate.Enabled = true;
                timerRefresh.Enabled = false;
                labelBoxTimeRemaining.Text = "0:00";

              //  Array.Clear(recv_buf, 0, recv_buf.Length);
          
     
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
                   
                    labelBoxTimeRemaining.Text = "";
                    labelBoxLoops.Text = "";

                    exitTestMode();
                }
            
            }
           

        }

        private void testSetupBtn_Click(object sender, EventArgs e)
        {
            TestSetup m_testSetup = new TestSetup();

            m_testSetup.m_testParameters = m_testParameters;

            if (m_testSetup.ShowDialog() == DialogResult.OK) //user presses OK button in test setup form
            {
                string testString = "";
                m_testParameters = m_testSetup.m_testParameters;
                testString = buildTestString(m_testParameters.test_duration, m_testParameters.rest_duration, m_testParameters.total_loops, m_testParameters.force_applied, 720, m_testParameters.stop_on_break, m_testParameters.data_rate / 1000);
                resetTimer(); //reset timer with time entered in test setup
                labelBoxLoops.Text = m_testParameters.loops_completed + "/" + m_testParameters.total_loops;

                if(transmit_message("TEST " + testString))
                {
                    AppendConsoleText("Test Parameters Entered");
                }
                else
                {
                    AppendConsoleText("Failed to send Test Parameters string");
                }
                startTestBtn.Enabled = true;

            }
        }

 
        private void startTestBtn_Click(object sender, EventArgs e)
        {
            string temp = "";
            if (read_temperature_command(ref temp))
            {
                AppendConsoleText("Temperature and Humidity Recorded");
                labelBoxAmbientTemp.Text = temp;

                if (transmit_message("START"))
                {
                    AppendConsoleText("Starting Test");
                    _testInProgress = true;
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
                AppendConsoleText("Test Aborted!");
                _testInProgress = false;
                exitTestMode();
            }
            else
            {
                AppendConsoleText("Failed to send STOP command to micro on abort! ");
            }

            /*
            startTestBtn.Enabled = true; 
            testSetupBtn.Enabled = true;
            comboBoxRefreshRate.Enabled = true;

            abortTestBtn.Enabled = false;
            timeRemainingTimer.Enabled = false;
            labelTestInProgressTimer.Enabled = false;
            labelTestInProgress.Visible = false;
            

            resetTimer();
         */
        }

        private void readTempBtn_Click(object sender, EventArgs e)
        {
            string temp = "";

            if(read_temperature_command(ref temp))
            {
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

        private void resetTimer()
        {
            _startTime = m_testParameters.test_duration * 60;
            labelBoxTimeRemaining.Text = _startTime / 60 + ":" + ((_startTime % 60) >= 10 ? (_startTime % 60).ToString() : "0" + _startTime % 60);
        }

        private void timeRemainingTimer_Tick(object sender, EventArgs e)
        {
          
            labelBoxTimeRemaining.Text = _startTime / 60 + ":" + ((_startTime % 60) >= 10 ? (_startTime % 60).ToString() : "0" + _startTime % 60);
            _startTime--;

            if(_startTime == -1)
            {
                exitTestMode();
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
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();


            saveFileDialog1.Filter = "Excel file (*.xls)|*.xls|Comma seperated file (*.csv)|*.csv";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    FileInfo fi = new FileInfo(saveFileDialog1.FileName);

                    string text = fi.Name;
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
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

            if(transmit_message("DATA"))
            {
                if(receive_message(ref str))
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





        /*********************************************************************
        * END MAINFORM SERIAL PORT READ/WRITE COMMANDS
        * 
        *********************************************************************/


    }

   

}


/*
private void openExcelCOM()
{
    Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

    if (xlApp == null)
    {
        MessageBox.Show("Excel is not properly installed!");
        return;
    }

    xlApp.Visible = true;

    Excel.Workbook xlWorkBook;
    Excel.Worksheet xlWorkSheet;
    object misValue = System.Reflection.Missing.Value;



    xlWorkBook = xlApp.Workbooks.Add(misValue);
    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);





    xlWorkSheet.Cells[1, 1] = "Cable Testing Data";
    xlWorkSheet.Cells[2, 1] = "Cable Type/Description: " + m_testParameters.cable_description;
    xlWorkSheet.Cells[3, 1] = "Test Parameters";
    xlWorkSheet.Cells[4, 2] = "Force Applied (kg)";
    xlWorkSheet.Cells[4, 3] = "Test Duration (min)";
    xlWorkSheet.Cells[4, 4] = "Rest Duration (min)";
    xlWorkSheet.Cells[4, 5] = "Test Repitions";
    xlWorkSheet.Cells[4, 6] = "Stop on Break";


    xlWorkSheet.Cells[5, 2] = m_testParameters.force_applied;
    xlWorkSheet.Cells[5, 3] = m_testParameters.test_duration;
    xlWorkSheet.Cells[5, 4] = m_testParameters.rest_duration;
    xlWorkSheet.Cells[5, 5] = m_testParameters.total_loops;
    xlWorkSheet.Cells[5, 6] = m_testParameters.stop_on_break;

    xlWorkSheet.Cells[6, 1] = "Raw Data";
    xlWorkSheet.Cells[7, 1] = "Time";
    xlWorkSheet.Cells[7, 2] = "Force Applied (kg)";
    xlWorkSheet.Cells[7, 3] = "Spin Motor Position";
    xlWorkSheet.Cells[7, 4] = "Continuity Status";



    Excel.Range usedrange = xlWorkSheet.UsedRange;
    usedrange.Columns.AutoFit();
    //     xlWorkBook.SaveAs("cable-tester-data1.xls");
}
*/
