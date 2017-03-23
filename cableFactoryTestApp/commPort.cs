using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Ports;
using System.Xml.Serialization;


namespace cableFactoryTestApp
{
    public struct SerialPortSettings
    {
        public string port_name;
        public int baud_rate;
        public int data_bits;
        public StopBits stop_bits;
        public Parity parity;
        public bool rts;
    }

    public class commPort : IDisposable
    {
        private SerialPort m_SerialPort = new SerialPort();
        private SerialPortSettings m_CommSettings;
  
        public void LoadDefaults()
        {
            m_CommSettings.data_bits = 8;
            m_CommSettings.stop_bits = StopBits.One;
            m_CommSettings.parity = Parity.None;
            m_CommSettings.port_name = "COM5";
            m_CommSettings.baud_rate = 9600;
            m_CommSettings.rts = false;
        }

        public bool Open()
        {
            bool reply;
            string comm_port_name;

            m_SerialPort.DtrEnable = true;
            m_SerialPort.PortName = m_CommSettings.port_name;
            m_SerialPort.BaudRate = m_CommSettings.baud_rate;
            m_SerialPort.Parity = m_CommSettings.parity;
            m_SerialPort.DataBits = m_CommSettings.data_bits;
            m_SerialPort.StopBits = m_CommSettings.stop_bits;   // System.IO.Ports.StopBits.One;
            m_SerialPort.Handshake = Handshake.None;

            // Set the read/write timeouts are set to 1000 milliseconds
              m_SerialPort.ReadTimeout = 1000;
              m_SerialPort.WriteTimeout = 2000;

            try
            {
                m_SerialPort.Open();
                reply = true;
            }
            catch(Exception e)
            {
                reply = false;
            }

          /*  comm_port_name = m_CommSettings.port_name;

            if (comm_port_name.Length > 4)
            {
                comm_port_name = "\\\\.\\" + comm_port_name;
            }

            comm_port_name += ":";
            */

            return (reply);
        }

        public void Close()
        {
            m_SerialPort.Close();
        }

        public void discardInBuffer()
        {
            m_SerialPort.DiscardInBuffer();
        }

        public void LoadSettings()
        {
            readCommSettingsFile();
        }

        public void SaveSettings()
        {
            writeCommSettingsFile();
        }

        private void readCommSettingsFile()
        {
            XmlSerializer serial_obj = new XmlSerializer(typeof(SerialPortSettings));

            //Create new file stream for reading XML file
            try
            {
                FileStream rd_file_stream = new FileStream(@"serial_settings.xml", FileMode.Open, FileAccess.Read, System.IO.FileShare.Read);
                m_CommSettings = (SerialPortSettings)serial_obj.Deserialize(rd_file_stream);
                rd_file_stream.Close();
            }
            catch
            {
                this.LoadDefaults();
                writeCommSettingsFile();
            }
        }

        private void writeCommSettingsFile()
        {
            XmlSerializer serial_obj = new XmlSerializer(typeof(SerialPortSettings));
            TextWriter wr_file_stream = new StreamWriter(@"serial_settings.xml");
            serial_obj.Serialize(wr_file_stream, m_CommSettings);
            wr_file_stream.Close();
        }


        public SerialPortSettings getPortSettings()
        {
            return m_CommSettings;
        }

        public void setPortSettings(SerialPortSettings settings)
        {
            m_CommSettings = settings;
            writeCommSettingsFile();
        }

        public bool isOpen()
        {
            return m_SerialPort.IsOpen;
        }


        public void write(string text)
        {
            m_SerialPort.Write(text);
        }

        //write byte
        public void write(char[] buffer, int offset, int count)
        {
            m_SerialPort.Write(buffer, offset, count);
        }
        //write char
        public void write(byte[] buffer, int offset, int count)
        {
            m_SerialPort.Write(buffer, offset, count);
        }

        public int read(byte[] buffer, int offset, int count)
        {
            return m_SerialPort.Read(buffer, offset, count);
        }

        public int read(char[] buffer, int offset, int count)
        {
            return m_SerialPort.Read(buffer, offset, count);
        }

        public String read()
        {
            return m_SerialPort.ReadLine();
        }

        public void Dispose()
        {
            Close();
        }

        /// Destructor (just in case)
        ~commPort()
        {
            Close();
        }





    }
}
