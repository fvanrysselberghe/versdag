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

        // GET api/calendar
        [ResponseType(typeof(Month))]
        public async Task<IHttpActionResult> Get()
        {
            //TriviaQuestion nextQuestion = await this.NextQuestionAsync(userId);
            Month monthData = new Month();
            monthData.Id = 1; 

            if (monthData == null)
            {
                return this.NotFound();
            }

            return this.Ok(monthData);
        }
    }
}
