using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoSationProject.Models.Ids
{
    class Alarme : Base
    {

        public Alarme(Trame trame) : base(trame) { }

        public override byte GetCalculatedCheckSum()
        {
            UInt32 somme = 0;
            Array.ForEach(_dataNotConverted, i => somme += i);
            return (byte)(_id + _dataNumber + _type + somme);
        }

        public override string GetState()
        {
            if (_dataNotConverted[1] == 0) return "No alarm";
            if (_dataNotConverted[1] == 85) return "Overcurrent";
            if (_dataNotConverted[1] == 170) return "Overvoltage";
            if (_dataNotConverted[1] == 255) return "Overtemperature";
            return null;
        }
        public override string GetType()
        {
            return "Alarme";
        }

    }
}
