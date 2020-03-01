using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace TrainStation
{
    public class SerailizationAndDeserealization
    {
        public SerailizationAndDeserealization()
        {

        }

        public void SerializeRouteAndPrice(string fileName, Dictionary<string, int> RouteAndPrice) 
        {
            using (StreamWriter writer = File.CreateText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, RouteAndPrice);
            }
        }

        public void SerializeRouteAndDate(string fileName, Dictionary<string, DateTime> RouteAndDate)
        {
            using (StreamWriter writer = File.CreateText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, RouteAndDate);
            }
        }

        public Dictionary<string, int> DeserializeRouteAndPrice(string fileName)
        {
            using (StreamReader file = File.OpenText(fileName))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Dictionary<string, int> RouteAndPrice = serializer.Deserialize<Dictionary<string, int>>(reader);
                    return RouteAndPrice;
                }
            }
        }

        public Dictionary<string, DateTime> DeserializeRouteAndDate(string fileName)
        {
            using (StreamReader file = File.OpenText(fileName)) 
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Dictionary<string, DateTime> RouteAndDate = serializer.Deserialize<Dictionary<string, System.DateTime>>(reader);
                    return RouteAndDate;
                }
            }
        }
    }
}
