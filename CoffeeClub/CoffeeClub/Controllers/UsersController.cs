using System;
using System.IO;
using System.Threading.Tasks;
using CoffeeClub.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CoffeeClub.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {    

        private readonly ILogger<WeatherForecastController> _logger;

        public UsersController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<bool> Add()
        {
            var bodyStream = Request.Body;
            var streamReader = new StreamReader(bodyStream);
            var body = await streamReader.ReadToEndAsync();
            var person = JsonConvert.DeserializeObject(body) as Person;
            if (person is null)
            {
                throw new ArgumentException("Can't deserialize body to " + nameof(Person) + ".");
            }
            // try to add person to list
            throw new NotImplementedException();

        }

        [HttpPost]
        public async Task<bool> Update()
        {
            var bodyStream = Request.Body;
            var streamReader = new StreamReader(bodyStream);
            var body = await streamReader.ReadToEndAsync();
            var person = JsonConvert.DeserializeObject(body) as Person;
            if (person is null)
            {
                throw new ArgumentException("Can't deserialize body to " + nameof(Person) + ".");
            }
            // try to find person to list
            throw new NotImplementedException();

        }

        [HttpPost]
        public async Task<bool> Get()
        {
            var bodyStream = Request.Body;
            var streamReader = new StreamReader(bodyStream);
            var body = await streamReader.ReadToEndAsync();
            var personId = JsonConvert.DeserializeObject(body) as int?;
            if (personId is null)
            {
                throw new ArgumentException("Can't deserialize body to " + nameof(personId) + ".");
            }
            // try to find person to list
            throw new NotImplementedException();

        }
    }
}
