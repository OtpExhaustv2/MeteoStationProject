using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoSationProject.Globals
{
    class Path
    {

        public static readonly string ROOT_PATH = Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;

    }
}
