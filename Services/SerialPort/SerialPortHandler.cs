using MeteoSationProject.Interfaces.Observer;
using MeteoSationProject.Models;
using MeteoSationProject.Models.Ids;
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
    class SerialPortHandler : Observable<Base>
    {
        private readonly int MAX_OCTETS = 14;

        private List<Observer<Base>> _observers = new List<Observer<Base>>();
        private List<Base> _ids = new List<Base>();

        private Boolean _isReading = false;
        private SerialPort _serial;
        private byte[] _bufferSerie;

        public SerialPortHandler()
        {
            _serial = new SerialPort();
            _serial.PortName = "COM3";
            _serial.Open();
            _serial.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
        }

        public void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_isReading)
            {
                int bytes = _serial.BytesToRead;
                _bufferSerie = new byte[bytes];
                _serial.Read(_bufferSerie, 0, bytes);
                ReadDatas();
            }
        }

        private void ReadDatas()
        {
            List<byte> currentDatas = new List<byte>();

            foreach (byte bit in _bufferSerie)
            {
                currentDatas.Add(bit);
            }

            if (currentDatas.Count <= MAX_OCTETS)
            {
                AddTrameToIdList(GetTrame(currentDatas));
            }

            currentDatas.Clear();
        }

        private void AddTrameToIdList(Trame trame)
        {
            if (!_ids.Any(id => id._id == trame._id))
            {
                _ids.Add(IdFactory.GetInstance().GetBase(trame._id, trame));
            }
            else
            {
                int index = _ids.FindIndex(id => id._id == trame._id);
                Base bTmp = _ids[index];
                _ids.RemoveAt(index);
                _ids.Add(bTmp.UpdateFromTrame(trame));
            }

            NotifyObservers();
        }

        private Trame GetTrame(List<byte> datas)
        {
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

            return new Trame(infos[0], infos[1], infos[2], infos[infos.Count - 1], bytes);
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

        public Boolean IsReading
        {
            get { return _isReading; }
            set { _isReading = value; }
        }

        public void ToggleReading()
        {
            _isReading = !_isReading;
        }

        public void RegisterObserver(Observer<Base> observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(Observer<Base> observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (Observer<Base> observer in _observers)
            {
                observer.Update(_ids[_ids.Count - 1]);
            }
        }

        public List<Base> Ids
        {
            get { return _ids; }
        }

        public void UpdateIntervalsMesure(int id, int min, int max)
        {
            Mesure mesure = (Mesure)GetBaseById(id);
            if (mesure != null)
            {
                mesure.UpdateIntervals(min, max);
            }
        }

        public void UpdateAlarmeMesure(int id, int min, int max)
        {
            Mesure mesure = (Mesure)GetBaseById(id);
            if (mesure != null)
            {
                mesure.UpdateAlarme(min, max);
            }
        }

        public Base GetBaseById(int id)
        {
            foreach (Base b in _ids)
            {
                if (b._id == id)
                {
                    return b;
                }
            }

            return null;
        }

        public List<Mesure> GetAllMesures()
        {
            List<Mesure> mesures = new List<Mesure>();
            foreach (Base b in _ids)
            {
                if (b is Mesure)
                {
                    mesures.Add((Mesure)b);
                }
            }

            return mesures;
        }
    }
}
