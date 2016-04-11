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
            Vegetable aardappel = new Vegetable("aardappel");
            Vegetable bloemkool = new Vegetable("bloemkool");
            Vegetable boerenkool = new Vegetable("boerenkool");


            Calendar manualCalendar = new Calendar();

            //January
            manualCalendar.Vegetables(1).Add(aardappel);

            //February
            manualCalendar.Vegetables(2).Add(aardappel);
            manualCalendar.Vegetables(2).Add(boerenkool);

            //March
            manualCalendar.Vegetables(3).Add(aardappel);
            manualCalendar.Vegetables(3).Add(bloemkool);


            String jsonContent = null;
            try
            {
                using (StreamReader reader = new StreamReader(@"e:\development\versdag\vegetableCalendarVelt.json"))
                {
                    jsonContent = reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                return manualCalendar;
            }


            try {
                JObject jsonObject = JObject.Parse(jsonContent);

                Calendar veltCalendar = new Calendar();

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

                return veltCalendar;
            }
            catch (JsonException)
            {
                return manualCalendar;
            }
        }
    }
}