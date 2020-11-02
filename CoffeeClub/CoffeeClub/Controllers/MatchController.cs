using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeClub.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeClub.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        public List<Match> employees = new List<Match>
        {
            new Match(
                "Catalin",
                "Galban",
                0,
                new string[]
                {
                    "football",
                    "pizza",
                    "hiking" 
                },
                "Greater London",
                "UK",
                "London",
                "Software Engineer",
                "Research and experiences",
                "JP Morgan",
                20,
                "M"
                ),
            new Match(
                "Alexandra",
                "Savu",
                1,
                new string[]
                {
                    "maths",
                    "machine learning",
                    "reading"
                },
                "Bucharest Area",
                "Romania",
                "Bucharest",
                "Software Engineer",
                "Research and experiences",
                "Microsoft",
                25,
                "F"
                ),
        };

        // GET: api/<MatchesController>
        [HttpGet]
        public IEnumerable<Match> Get()
        {
            return this.employees;
        }

        // GET api/<MatchesController>/5
        // TODO
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
