using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Versdag.Models;

namespace Versdag.Controllers
{
    public class CalendarController : ApiController
    {
        private Month[] calendar; 

        public CalendarController()
        {
            calendar = CreateCalendar();
        }

        // GET api/calendar
        [ResponseType(typeof(Month))]
        public async Task<IHttpActionResult> Get(int id)
        {
            //TriviaQuestion nextQuestion = await this.NextQuestionAsync(userId);
            if ( id < 1 || id > 12)
            {
                return this.NotFound();
            }

            return this.Ok(calendar[id-1]);
        }

        private static Month[] CreateCalendar()
        {
            Vegetable aardappel = new Vegetable("aardappel");
            Vegetable bloemkool = new Vegetable("bloemkool");
            Vegetable boerenkool = new Vegetable("boerenkool");


            Month[] calendar = new Month[12];
            for (int index = 0; 
                index < calendar.Length;
                ++index)
            {
                calendar[index] = new Month();
                calendar[index].Id = index + 1;
            }

            //January
            calendar[0].VegetablesOfTheMonth.Add(aardappel);

            //February
            calendar[1].VegetablesOfTheMonth.Add(aardappel);
            calendar[1].VegetablesOfTheMonth.Add(boerenkool);

            //March
            calendar[2].VegetablesOfTheMonth.Add(aardappel);
            calendar[2].VegetablesOfTheMonth.Add(bloemkool);
            

            return calendar;
        }
    }
}
