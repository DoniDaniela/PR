using Server1.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server1.Modules
{
    public static class WorkQueue
    {
        private static ConcurrentQueue<DataItem> DataItems = new ConcurrentQueue<DataItem>();


        public static void QueueDataTiem(DataItem item)
        {
            DataItems.Enqueue(item);
        }

        public static DataItem DeQueueDataItem()
        {
            if (DataItems.TryDequeue(out var dataItem))
                return dataItem;
            return null;
        }

    }
}
