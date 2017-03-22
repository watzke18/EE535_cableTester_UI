using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace cableFactoryTestApp
{
    public partial class ConfigCOMM : Form
    {
        public SerialPortSettings m_Settings;


        private enum SelectBaudRate
        {
            BAUD_9600 = 0,
            BAUD_19200 = 1,
            BAUD_38400 = 2,
            BAUD_115200 = 3,
            BAUD_460800 = 4
        };

        private enum SelectDataBits
        {
            DATA_8 = 0
        };

        private enum SelectStopBits
        {
            STOP_1 = 0,
            STOP_2 = 1
        };

        private enum SelectParity
        {
            PARITY_NONE = 0,
            PARITY_ODD = 1,
            PARITY_EVEN = 2
        };

        public ConfigCOMM()
        {
            InitializeComponent();
        }

        private void ConfigCOMM_Load(object sender, EventArgs e)
        {
            int k, idx;

            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();

            // Add each port name to the list box, and record the index of
            //   the port name that matches the current port name. If none
            //   match, idx = -1, indicating that we need to select a default.
            //
            foreach (string port in ports)
            {
                comboCommPort.Items.Add(port);
            }

            idx = 0;  // Default comm port is the first in the list.

            for (k = 0; k < comboCommPort.Items.Count; k++)
            {
                if (comboCommPort.Items[k].ToString() == m_Settings.port_name)
                    idx = k;
            }

            if (comboCommPort.Items.Count > 0)
                comboCommPort.SelectedIndex = idx;

            switch (m_Settings.baud_rate)
            {
                case 9600:
                    comboBaudRate.SelectedIndex = (int)SelectBaudRate.BAUD_9600;
                    break;

                case 19200:
                    comboBaudRate.SelectedIndex = (int)SelectBaudRate.BAUD_19200;
                    break;

                case 38400:
                    comboBaudRate.SelectedIndex = (int)SelectBaudRate.BAUD_38400;
                    break;

                case 115200:
                    comboBaudRate.SelectedIndex = (int)SelectBaudRate.BAUD_115200;
                    break;

                case 460800:
                default:
                    comboBaudRate.SelectedIndex = (int)SelectBaudRate.BAUD_460800;
                    break;
            }

            comboDataBits.SelectedIndex = (int)SelectDataBits.DATA_8;

            switch (m_Settings.stop_bits)
            {
                case StopBits.One:
                default:
                    comboStopBits.SelectedIndex = (int)SelectStopBits.STOP_1;
                    break;

                case StopBits.Two:
                    comboStopBits.SelectedIndex = (int)SelectStopBits.STOP_2;
                    break;
            }

            switch (m_Settings.parity)
            {
                case Parity.None: //Parity.none:
                default:
                    comboParity.SelectedIndex = (int)SelectParity.PARITY_NONE;
                    break;

                case Parity.Odd: //Parity.odd:
                    comboParity.SelectedIndex = (int)SelectParity.PARITY_ODD;
                    break;

                case Parity.Even: //Parity.even:
                    comboParity.SelectedIndex = (int)SelectParity.PARITY_EVEN;
                    break;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            m_Settings.port_name = comboCommPort.SelectedItem.ToString();
            m_Settings.data_bits = 8;


            switch (comboBaudRate.SelectedIndex)
            {
                case (int)SelectBaudRate.BAUD_9600:
                    m_Settings.baud_rate = 9600;
                    break;

                case (int)SelectBaudRate.BAUD_19200:
                    m_Settings.baud_rate = 19200;
                    break;

                case (int)SelectBaudRate.BAUD_38400:
                    m_Settings.baud_rate = 38400;
                    break;

                case (int)SelectBaudRate.BAUD_115200:
                    m_Settings.baud_rate = 115200;
                    break;

                case (int)SelectBaudRate.BAUD_460800:
                default:
                    m_Settings.baud_rate = 460800;
                    break;
            }


            switch (comboStopBits.SelectedIndex)
            {
                case (int)SelectStopBits.STOP_1:
                    m_Settings.stop_bits = StopBits.One; //StopBits.one;
                    break;

                case (int)SelectStopBits.STOP_2:
                default:
                    m_Settings.stop_bits = StopBits.Two; //StopBits.two;
                    break;
            }

            switch (comboParity.SelectedIndex)
            {
                case (int)SelectParity.PARITY_NONE:
                default:
                    m_Settings.parity = Parity.None; //Parity.none;
                    break;

                case (int)SelectParity.PARITY_ODD:
                    m_Settings.parity = Parity.Odd; //Parity.odd;
                    break;

                case (int)SelectParity.PARITY_EVEN:
                    m_Settings.parity = Parity.Even; //Parity.even;
                    break;

            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
