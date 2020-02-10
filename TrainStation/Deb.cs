using System;
using Newtonsoft.Json;

namespace TrainStation
{
    public static class Deb
    {
        public static void Print(object data, string comment = " ")
        {
            Console.WriteLine($"{comment} {JsonConvert.SerializeObject(data)}");
        }
    }
}
