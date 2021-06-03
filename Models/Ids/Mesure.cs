using System;

namespace MeteoSationProject.Models.Ids
{
    class Mesure : Base
    {

        private int[] _intervalMesure = new int[2];
        private int[] _intervalAlarme = new int[2];
        private double _convertedData = 0;

        public Mesure(Trame trame) : base(trame)
        { }

        private double ConvertData()
        {
            _convertedData = 0;
            for (int i = 0; i < _dataNotConverted.Length; i++)
            {
                _convertedData += ((UInt32)_dataNotConverted[i] << 8 * i);
            }

            return _convertedData;
        }

        private int GetConvertedDataWithIntervals()
        {
            return ((int)(ConvertData() / (Math.Pow(2, _dataNumber * 8) - 1) * (_intervalMesure[1] - _intervalMesure[0])) + _intervalMesure[0]);
        }

        public override double GetConvertedData()
        {
            _convertedData = _isConfigured ? GetConvertedDataWithIntervals() : ConvertData();
            return _convertedData;
        }

        public override byte GetCalculatedCheckSum()
        {
            UInt32 somme = 0;
            Array.ForEach(_dataNotConverted, i => somme += i);
            return (byte)(_id + _dataNumber + _type + somme);
        }

        public override string GetType()
        {
            if (_type == 1) return "Temperature";
            if (_type == 2) return "Humidity";
            if (_type == 3) return "Atmospheric pressure";
            if (_type == 4) return "Luminosity";

            return null;
        }

        public override string GetState()
        {
            if (_intervalAlarme[0] != 0 && _intervalAlarme[1] != 0 && _isConfigured)
            {
                if (_convertedData < _intervalAlarme[0]) return "DOWN";
                if (_convertedData > _intervalAlarme[1]) return "UP";
            }

            return "OK";
        }

        public void UpdateIntervals(int min, int max)
        {
            _isConfigured = true;
            _intervalMesure[0] = min;
            _intervalMesure[1] = max;
        }

        public void UpdateAlarme(int min, int max)
        {
            _intervalAlarme[0] = min;
            _intervalAlarme[1] = max;
        }

        public int[] Intervals
        {
            get { return _intervalMesure; }
        }

        public int[] GetConfiguration()
        {
            return new int[] { _id, _intervalMesure[0], _intervalMesure[1], _intervalAlarme[0], _intervalAlarme[1] };
        }

    }
}
