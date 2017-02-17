using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JsonSerializationTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var status = new Status() { Content = "test", Publisher = "tester", Images = new List<string>() { "abc", "edf" } };
            var json = JsonConvert.SerializeObject(status);
            Console.WriteLine(json);


            var newJson = @"{
                'content': 'testnew',
                'publisher': 'newtester',
                'images': ['newabc','bewedf']
            }";

            var newStatus = JsonConvert.DeserializeObject<Status>(newJson);
            Console.ReadLine();
        }
    }

    public class Status
    {
        public string Content { get; set; }
        public string Publisher { get; set; }

        public List<string> Images { get; set; }
    }
}
