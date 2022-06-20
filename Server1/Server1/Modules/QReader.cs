using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Server1.Modules
{
    public static class QReader
    {
        public static void ReadQueue()
        {
            while (true)
            {
                var item = WorkQueue.DeQueueDataItem();
                if (item != null)
                {
                    using var client = new HttpClient();
                    var json = JsonConvert.SerializeObject(item);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = client.PostAsync("https://localhost:44338/api", data).Result;
                }
            }
        }
    }
}
