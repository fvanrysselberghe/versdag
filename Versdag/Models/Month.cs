using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Versdag.Models
{
    public class Month
    {
        public int Id { get; set; }
        public List<Vegetable> VegetablesOfTheMonth { get; set; }

        public Month()
        {
            VegetablesOfTheMonth = new List<Vegetable>();
        }
    }
}