using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebApplication1
{
    public class Item
    {
        //json object 
        public DateTime timestamp;
        public DateTime diatetime;
        public Position position;
        public float speed;
        public float speedlimit;

        public class Position
        {
            public float latitude;    //it should be under postion feild 
            public float longitude;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            JsonReader();

            CreateWebHostBuilder(args).Build().Run();
        }

        //Read data from json and deserialize 
        public static void JsonReader()
        {
            DateTime timestamp;
            using (StreamReader r = new StreamReader("waypoint.json"))
            {
                string json = r.ReadToEnd();
                JsonSerializer serializer = new JsonSerializer();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);

                Console.WriteLine("The JSON data: " ,items[0].timestamp);
                timestamp = items[0].timestamp;
                Categories(items[0].speed, items[0].timestamp);
            }
        }

        public static void Categories(double speed, DateTime time)
        {
            //•	Distance Speeding
            double distance;
            int intTime = Convert.ToInt32(time);
            //Speed = distance / time  , time = distance / speed and distance = speed * time  // this is the final calculation
            distance = Convert.ToDouble(time) * (speed);

            speed = distance / Convert.ToDouble(time);

            //time = distance / speed;
        }

        //
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
