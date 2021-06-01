using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoSationProject.Interfaces.Observer
{
    interface Observer<T>
    {

        void Update(T b);

    }
}
