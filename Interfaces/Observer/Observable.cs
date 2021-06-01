using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeteoSationProject.Interfaces.Observer;

namespace MeteoSationProject.Interfaces.Observer
{
    interface Observable<T>
    {

        void RegisterObserver(Observer<T> observer);

        void RemoveObserver(Observer<T> observer);

        void NotifyObservers();

    }
}
