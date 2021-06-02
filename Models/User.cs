using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoSationProject.Models
{
    class User
    {

        public int _id { get; set; }
        public string _username { get; set; }
        public string _password { get; set; }
        public int _accessId { get; set; }
        public Access _access { get; set; }

        public User(int id, string username, string password, int accessId, Access access)
        {
            _id = id;
            _username = username;
            _password = password;
            _accessId = accessId;
            _access = access;
        }

        public Access Access
        {
            get { return _access; }
        }
    }
}
