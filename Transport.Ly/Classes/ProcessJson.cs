using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Transport.Ly.Classes;

namespace Transport.Ly.Classes
{
    class ProcessJson
    {
        /// <summary>
        /// Read the json file and deserialize the object
        /// </summary>
        /// <param name="Location">Json file location or path</param>
        /// <returns>The values and objects founded in the json file</returns>
        public Dictionary<string, object> ReadJson(string Location)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Location);
            string json = File.ReadAllText(path);
            var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            return values;
        }

        public List<jsonOrder> ConvertJsonToObject(Dictionary<string, object> Values)
        {
            List<jsonOrder> orders = new List<jsonOrder>();

            foreach (var x in Values)
            {
                jsonOrder jsonOrder = new jsonOrder();
                jsonOrder.ID = x.Key;

                var dest = JsonConvert.DeserializeObject<Dictionary<string, string>>(x.Value.ToString());

                foreach (var y in dest)
                {
                    jsonOrder.OrderDestination.Destination = y.Value;
                }

                orders.Add(jsonOrder);
            }

            return orders;
        }
    }
}
