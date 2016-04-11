using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Versdag.Models
{
    public class CalendarRepository
    {
        public Calendar GetCalendar()
        {
                Calendar veltCalendar = new Calendar();

                using (StreamReader RawReader = new StreamReader(@"e:\development\versdag\vegetableCalendarVelt.json"))
                using (JsonReader JsonReader = new JsonTextReader(RawReader))
                {
                try
                    {
                        JObject jsonObject = (JObject)JObject.ReadFrom(JsonReader);


                        //iterate months
                        JArray rawVegetableCalendar = (JArray)jsonObject["vegetables"];
                        for (int index = 0; index < 12; index++)
                        {
                            JArray Month = (JArray)rawVegetableCalendar[index];

                            List<Vegetable> VegetablesOfMonth = veltCalendar.Vegetables(index + 1);
                            foreach (String VegetableName in Month)
                            {
                                VegetablesOfMonth.Add(new Vegetable(VegetableName));
                            }
                        }
                    }
                    catch (JsonException)
                    {
                        return new Calendar();
                    }

                return veltCalendar;
                }
            
        }
    }
}