using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server2.Modules
{
    public static class SendThreads
    {
        private static bool _initiated;
        public static void InitThreads()
        {
            if (_initiated) return;
            for (int i = 0; i < 4; i++)
            {
                Thread waiterThread = new Thread(new ThreadStart(SReader.ReadStack));
                waiterThread.Start();
            }
            _initiated = true;
        }
    }
}
