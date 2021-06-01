using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoSationProject.Models
{
    class Trame
    {
        public byte ID { get; set; }
        public byte DataNbr { get; set; }
        public byte CheckSum { get; set; }
        public UInt32[] Datas { get; set; }
        public byte Type { get; set; }

        public Trame(byte iD, byte dataNbr, byte type, byte checkSum, UInt32[] datas)
        {
            ID = iD;
            DataNbr = dataNbr;
            CheckSum = checkSum;
            Datas = datas;
            Type = type;
        }

        override public String ToString()
        {
            String features = "Id: " + ID + ", DataNbr: " + DataNbr + ", Type:" + Type + ", Datas: ";

            features += "[" + String.Join("; ", Datas) + "]";

            features += ", CheckSum: " + CheckSum;

            return features;
        }

    }
}
