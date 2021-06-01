using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoSationProject.Models.Ids
{
    class IdFactory
    {

        private static IdFactory _instance = null;

        private static readonly object _lock = new object();

        private IdFactory() { }

        /**
         * Singleton pattern
         */
        public static IdFactory GetInstance()
        {
            if (_instance == null)
            {
                // Thread safe instanciation
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        IdFactory._instance = new IdFactory();
                    }
                }
            }

            return IdFactory._instance;
        }

        public Base GetBase(int id)
        {
            if (id == 0) return new Base();
            if (id <= 10 && id >= 1) return new Mesure();
            if (id == 50) return new Alarme();

            return null;
        }

    }
}
