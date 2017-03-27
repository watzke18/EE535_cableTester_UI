﻿using CsvHelper;
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
        private string _refreshRate; //in ms
        private bool _labelToggle;


        public string[] data;
   

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

            _refreshRate = "1000ms";
            _labelToggle = false;


           
        }

        private void exportExcel()
        {
        
        }

        private void refreshData()
        {
            string msg = "";
            //this is where all updating will occur
            if(read_inputs_command(ref msg))
            {
                parseMessage(ref msg, ref data);
            }

            logData(data);
        }

        private void logData(string[] args)
        {

        }

        private string[] parseMessage(ref string msg, ref string[] data)
        {
            data = new string[5];
            return data;

         

        }
  
        public void AppendConsoleText(string str)
        {
            consoleRichTextBox.AppendText(">" + str + "\n");
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
            comboBoxRefreshRate.Enabled = true;

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
                resetTimer(); //reset timer with time entered in test setup
                startTestBtn.Enabled = true;

              
                //send data to micro

            }
        }

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
     

            /*xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 10]].Merge();
            xlWorkSheet.Range[xlWorkSheet.Cells[2, 1], xlWorkSheet.Cells[2, 20]].Merge();
            xlWorkSheet.Range[xlWorkSheet.Cells[3, 1], xlWorkSheet.Cells[3, 2]].Merge();*/


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
            xlWorkSheet.Cells[5, 5] = m_testParameters.loops;
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
        private void startTestBtn_Click(object sender, EventArgs e)
        {
            //write outputs command
            openExcelCOM();

            timeRemainingTimer.Enabled = true;
            labelTestInProgressTimer.Enabled = true;
            labelTestInProgress.Visible = true;
            abortTestBtn.Enabled = true;
            startTestBtn.Enabled = false;
            testSetupBtn.Enabled = false;
            comboBoxRefreshRate.Enabled = false;

            if(transmit_message("START"))
            {
                AppendConsoleText("Starting Test");
            }
            else
            {
                AppendConsoleText("Failed to send START command to micro");
            }




          
        }

        private void abortTestBtn_Click(object sender, EventArgs e)
        {
            if (transmit_message("STOP"))
            {
                AppendConsoleText("Stopping Test");
            }
            else
            {
                AppendConsoleText("Failed to send STOP command to micro");
            }

            startTestBtn.Enabled = true; 
            testSetupBtn.Enabled = true;
            comboBoxRefreshRate.Enabled = true;


            abortTestBtn.Enabled = false;
            timeRemainingTimer.Enabled = false;
            labelTestInProgressTimer.Enabled = false;
            labelTestInProgress.Visible = false;

            resetTimer();

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


        private void readPosBtn_Click(object sender, EventArgs e)
        {
            string pos = "";

            if(read_position_command(ref pos))
            {
                labelMotorPos.Text = pos;
            }
        }


        private void comboBoxRefreshRate_TextChanged(object sender, EventArgs e)
        {
            _refreshRate = comboBoxRefreshRate.Text;
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

        public bool read_position_command(ref string pos)
        {
            bool reply = false;

            if(transmit_message("POS"))
            {
                if(receive_message(ref pos))
                {
                    reply = true;
                }
                else
                {
                    AppendConsoleText("Failed to receive motor POS");
                    reply = false;
                }
            }
            else
            {
                AppendConsoleText("Failed to transmit command POS");
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


        /*********************************************************************
        * END MAINFORM SERIAL PORT READ/WRITE COMMANDS
        * 
        *********************************************************************/


    }

   

}
