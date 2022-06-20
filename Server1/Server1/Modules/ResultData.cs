using Server1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server1.Modules
{
    public static class ResultData
    {
        public static List<DataItem> Items = new List<DataItem>();
        public static object lockObject = new object();
        public static List<DataItem> GetData()
        {
            lock (lockObject)
            {
                if (Items.Count == 0) return new List<DataItem>();
                var items = new List<DataItem>();
                items.AddRange(Items);
                Items.Clear();
                return items;
            }
        }

        public static void AddItem(DataItem item)
        {
            lock (lockObject)
            {
                Items.Add(item);
            }
        }
    }
}
