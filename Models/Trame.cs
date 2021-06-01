using System;

namespace MeteoSationProject.Models
{
    public class Trame
    {
        public byte _id { get; set; }
        public byte _dataNumber { get; set; }
        public byte _checkSum { get; set; }
        public UInt32[] _datas { get; set; }
        public byte _type { get; set; }

        public Trame(byte iD, byte dataNumber, byte type, byte checkSum, UInt32[] datas)
        {
            _id = iD;
            _dataNumber = dataNumber;
            _checkSum = checkSum;
            _datas = datas;
            _type = type;
        }

        /*override public String ToString()
        {
            String features = "Id: " + ID + ", DataNbr: " + DataNbr + ", Type:" + Type + ", Datas: ";

            features += "[" + String.Join("; ", Datas) + "]";

            features += ", CheckSum: " + CheckSum;

            return features;
        }*/

    }
}
