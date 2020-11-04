using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeClub.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnTheSpotMatchController : ControllerBase
    {
        private readonly IOnTheSpotQueue queue;
        private readonly IUsers users;

        public OnTheSpotMatchController(IOnTheSpotQueue queue, IUsers users)
        {
            this.queue = queue;
            this.users = users;
        }

        [HttpPost]
        public Person Get()
        {
            var personId = int.Parse(Request.Headers["id"]);
            users.TryGetPersonById(personId, out var personToBeMatched);
            if(!queue.TryGetMatch(personToBeMatched, out var matchedPerson) && !queue.TryAddToQueue(personToBeMatched))
            {
                throw new NotImplementedException();
            }
            return matchedPerson;
        }
    }
}