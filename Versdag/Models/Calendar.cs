using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Versdag.Models
{
    /*
    A fruit/vegetable calendar that describes which fruits and vegetables grow in a specific month
    */
    public class Calendar
    {
        //Maps a month onto a list of vegetables
        private Dictionary<int, List<Vegetable>> vegetablesPerMonth = new Dictionary<int, List<Vegetable>>();

        public List<Vegetable> Vegetables(int Month)
        {
            if (!vegetablesPerMonth.ContainsKey(Month))
                return new List<Vegetable>(); //return empty list (or throw exception when pre-condition not met -- how to do asserts in C#)
            else
                return vegetablesPerMonth[Month];
        }

        public Calendar()
        {
            for (var month = 1; month <= 12; ++month)
            {
                vegetablesPerMonth.Add(month, new List<Vegetable>());
            }
        }
    }
}