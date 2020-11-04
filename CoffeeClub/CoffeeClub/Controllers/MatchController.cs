﻿using System;
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
        public MatchFinder MatchFinder { get; }

        public MatchController()
        {
            this.MatchFinder = new MatchFinder(new Users(),new AllPeopleToOneGroupAssigner());
        }

        // GET: api/<MatchesController>
        [HttpGet]
        public IEnumerable<Person> GetAllEmployees()
        {
            return this.MatchFinder.GetUnMatchedPeople();
        }

        // GET api/<MatchesController>/5
        [HttpGet("{id}")]
        public Person Get(int Id)
        {
            Person PersonToMatch = this.MatchFinder.GetPersonById(Id);
            return MatchFinder.GetFirstMatch(PersonToMatch);
        }
    }
}
