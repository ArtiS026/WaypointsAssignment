using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
            public float latitude;
            public float longitude;
        }
    }
    public class InsuranceCalculation
    {
        //Read data from json and deserialize 
        public static void JsonReader()
        {
            DateTime dttimestamp;
            double speed;
            using (StreamReader r = new StreamReader("waypoint.json"))
            {
                string json = r.ReadToEnd();
                JsonSerializer serializer = new JsonSerializer();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
                
                Console.WriteLine("The JSON data: ", items[2].timestamp.TimeOfDay);  
                dttimestamp = Convert.ToDateTime(items[2].timestamp.TimeOfDay.ToString());
                speed = Math.Round(items[2].speed, 3);
                Categories(speed, dttimestamp); //for calculation and categorization

                // for loop to calculate speed , distance and time for individual item in the json file
            }
        }

        //calculation for Distance Speeding ,Duration Speeding , Total Distance , Total Duration
        public static void Categories(double speed, DateTime time)
        {
            //•	Distance Speeding
            double distance, totalduration;
            long lngtime = time.ToFileTime();
            var vartime = DateTimeOffset.FromFileTime(lngtime).TimeOfDay;
            double hours = vartime.TotalHours; //could round it up to 3 points
            //Speed = distance / time  , time = distance / speed and distance = speed * time  // this is the final calculation
            distance = hours * speed;

            speed = distance / hours;

            totalduration = distance / speed;

            Console.WriteLine("Distance Speeding :", distance);
            Console.WriteLine("Duration Speeding :", speed);
            Console.WriteLine("Total Distance :");
            Console.WriteLine("Total Duration :", time);
        }
    }
}
