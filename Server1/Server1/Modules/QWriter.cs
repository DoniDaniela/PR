using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server1.Modules
{
    public static class QWriter
    {
        public static void WriteQueue()
        {
            var id = Guid.NewGuid().ToString();
            WorkQueue.QueueDataTiem(new Models.DataItem()
            {
                ID = id,
                Name = $"Name - {id}"
            });
        }
    }
}
