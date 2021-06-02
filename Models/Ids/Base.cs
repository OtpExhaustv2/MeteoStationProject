using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoSationProject.Models.Ids
{
    public class Base
    {

        public int _id { get; set; }
        public int _dataNumber { get; set; }
        public int _type { get; set; }
        public int _alarmeMaxPeriod { get; set; }
        public byte _checkSum { get; set; }
        public Boolean _isConfigured { get; set; } = false;
        public UInt32[] _dataNotConverted { get; set; }

        public Base(Trame trame)
        {
            UpdateFromTrame(trame);
        }

        public Base UpdateFromTrame(Trame trame)
        {
            _id = trame._id;
            _dataNumber = trame._dataNumber;
            _type = trame._type;
            _dataNotConverted = trame._datas;
            _checkSum = trame._checkSum;

            return this;
        }

        public string IsConfigured()
        {
            return _isConfigured ? "Done" : "Not Done";
        }

        public virtual double GetConvertedData()
        {
            return 0;
        }

        public virtual string GetState()
        {
            return "";
        }

        public virtual byte GetCalculatedCheckSum()
        {
            return 0;
        }

        public new virtual string GetType()
        {
            return "Keep Alive";
        }

        public override string ToString()
        {
            return "Id: " + _id + "; Number Data: " + _dataNumber + "; Type: " + _type + "; ConvertedData: " + GetConvertedData() + "; CheckSum: " + _checkSum;
        }
    }
}
