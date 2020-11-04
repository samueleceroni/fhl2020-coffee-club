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
        /// <summary>
        /// Hard coded list of employees.
        /// </summary>
        public List<Person> Employees = new List<Person>
        {
            new Person(
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
            new Person(
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
        public MatchFinder MatchFinder { get; }

        public MatchController()
        {
            this.MatchFinder = new MatchFinder(this.Employees,new AllPeopleToOneGroupAssigner());
        }

        // GET: api/<MatchesController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return this.Employees;
        }

        // GET api/<MatchesController>/5
        // TODO
        // Null check
        [HttpGet("{id}")]
        public Person Get(int Id)
        {
            Person PersonToMatch = this.FindPersonById(Id);
            return MatchFinder.GetFirstMatch(PersonToMatch);
        }

        private Person FindPersonById(int Id)
        {
            foreach (Person Person in Employees)
            {
                if (Person.Id == Id )
                {
                    return Person;
                }
            }
            return null;
        }
    }
}
