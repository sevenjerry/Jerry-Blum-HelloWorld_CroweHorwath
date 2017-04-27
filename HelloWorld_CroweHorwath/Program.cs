using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld_CroweHorwath
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57203/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("api/values/1").Result;
                string textToPrint = response.Content.ReadAsStringAsync().Result;

                //App can write to console or file location, use config file to determine where to write to
                var writeLoc = ConfigurationManager.AppSettings.Get("writeLocation");
                if (writeLoc == "console")
                {
                    Console.WriteLine(textToPrint);
                    Console.ReadKey();
                }
                else if (writeLoc == "file")
                {
                    var location = ConfigurationManager.AppSettings.Get("fileLocation");

                    using (var file = new StreamWriter(location))
                    {
                        file.WriteLine(textToPrint);
                    }
                }
            }
        }
    }
}
