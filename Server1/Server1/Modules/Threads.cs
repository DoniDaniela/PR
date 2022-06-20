using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server1.Modules
{
    public static class Threads
    {
        private static bool _initiated;

        public static void InitReadThreads()
        {
            if (_initiated) return;
            for (int i = 0; i < 2; i++)
            {
                Thread waiterThread = new Thread(new ThreadStart(QReader.ReadQueue));
                waiterThread.Start();
            }
            _initiated = true;
        }
    }
}
