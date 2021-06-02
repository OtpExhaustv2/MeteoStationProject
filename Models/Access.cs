using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoSationProject.Models
{
    class Access
    {

        public string _label { get; }
        public bool _allowCreateId { get; }
        public bool _allowDestroyId { get; }
        public bool _allowConfigAlarm { get; }
        public bool _userCreation { get; }

        public Access(string label, bool allowCreateId, bool allowDestroyId, bool allowConfigAlarm, bool userCreation)
        {
            _label = label;
            _allowCreateId = allowCreateId;
            _allowDestroyId = allowDestroyId;
            _allowConfigAlarm = allowConfigAlarm;
            _userCreation = userCreation;
        }
    }
}
