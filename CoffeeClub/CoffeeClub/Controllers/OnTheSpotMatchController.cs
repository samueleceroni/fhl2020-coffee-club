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

        private Person IdToPerson(int id) => null;

        public OnTheSpotMatchController(IOnTheSpotQueue queue)
        {
            this.queue = queue;
        }

        [HttpPost]
        public Person Get()
        {
            var personId = int.Parse(Request.Headers["id"]);
            var personToBeMatched = IdToPerson(personId);
            if(!queue.TryGetMatch(personToBeMatched, out var matchedPerson) && !queue.TryAddToQueue(personToBeMatched))
            {
                throw new NotImplementedException();
            }
            return matchedPerson;
        }
    }
}