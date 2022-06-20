using Server2.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server2.Modules
{
    public static class WorkStack
    {
        private static ConcurrentStack<DataItem> DataItems = new ConcurrentStack<DataItem>();

        public static void PushDataItem(DataItem item)
        {
            DataItems.Push(item);
        }

        public static DataItem PopDataItem()
        {
            if (DataItems.TryPop(out var dataItem))
                return dataItem;
            return null;
        }
        
    }
}
