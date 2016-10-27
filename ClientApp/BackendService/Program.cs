using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace BackendService
{
    class Program
    {
        static void Main(string[] args)
        {

            string deviceID = (args.Count() > 0) ? args[0] : "device1";
            

            var message = new DeviceMessage()
            {
                DeviceID = deviceID
            };

          //  StringContent content = new StringContent(JsonConvert.SerializeObject(message));

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8257/");
            client.DefaultRequestHeaders.Accept.Clear();
          
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // List all Names.  
            HttpContent content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8,"application/json"); 

            HttpResponseMessage response = client.PostAsync("api/Values", content).Result;

        }

        public class DeviceMessage
        {
           public string DeviceID { get; set; }
        }

    }
}
