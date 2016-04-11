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
    public class SuggestionController : ApiController
    {
        [ResponseType(typeof(Vegetable))]
        public async Task<IHttpActionResult> Get()
        {
            var calendar = GetCalendar(); //get the calendar from disk/repository/...
            var vegetableSelection = calendar.Vegetables(DateTime.Now.Month);

            //get random selection in selection
            var seed = new Random();
            var randomPick = seed.Next(vegetableSelection.Count);

            return this.Ok(vegetableSelection.ElementAt(randomPick));
        }

        private Calendar GetCalendar()
        {
            CalendarRepository repo = new CalendarRepository();
            return repo.GetCalendar();
        }
    }
}
