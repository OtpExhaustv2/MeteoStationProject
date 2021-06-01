using MeteoSationProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeteoSationProject.Services.SerialHandler
{
    class SerialPortHandler
    {
        private readonly int MAX_OCTETS = 14;

        private SerialPort _serial;
        private byte[] bufferSerie;

        public SerialPortHandler()
        {
            _serial = new SerialPort();
            _serial.PortName = "COM3";
            _serial.Open();
            _serial.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
        }

        public void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = _serial.BytesToRead;
            bufferSerie = new byte[bytes];
            _serial.Read(bufferSerie, 0, bytes);
            ReadDatas();
        }

        private void ReadDatas()
        {
            List<byte> currentDatas = new List<byte>();

            foreach (byte bit in bufferSerie)
            {
                currentDatas.Add(bit);
                Console.Write(bit + " ");
            }
            Console.WriteLine();

            GetTrame(currentDatas);
            currentDatas.Clear();
        }

        private Trame GetTrame(List<byte> datas)
        {
            Trame trame = null;

            byte[] beginSequence = new byte[] { 85, 170, 85 };
            byte[] endSequence = new byte[] { 170, 85, 170 };

            

            /*
                        List<byte> infos = new List<byte>();

                        for (int i = 3; i < datas.Count - 3; i++)
                        {
                            infos.Add(datas[i]);
                        }

                        UInt32[] bytes = new UInt32[infos[1]];

                        for (int i = 0; i < infos[1]; i++)
                        {
                            bytes[i] = infos[i + 3];
                        }

                        return new Trame(infos[0], infos[1], infos[2], infos[infos.Count - 1], bytes);*/
            return trame;
        }


        public void PortName(String portName)
        {
            _serial.Close();
            _serial.PortName = portName;

            try
            {
                _serial.Open();
            }
            catch (IOException)
            {
                MessageBox.Show("The port " + portName + " does not exist!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("The port " + portName + " is already in use!");
            }
        }

    }
}
