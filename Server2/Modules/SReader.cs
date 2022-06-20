using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Server2.Modules
{
    public static class SReader
    {
        public static void ReadStack()
        {
            while (true)
            {
                var item = WorkStack.PopDataItem();
                if (item != null)
                {
                    using var client = new HttpClient();
                    var json = JsonConvert.SerializeObject(item);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = client.PutAsync("https://localhost:44345/home/PutData", data).Result;
                }
                
            }
        }
    }
}
