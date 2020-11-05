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
        private readonly IUsers users;

        public UsersController(ILogger<WeatherForecastController> logger, IUsers users)
        {
            _logger = logger;
            this.users = users;
        }

        private async Task<T> BodyStreamToPerson<T>(Stream bodyStream)
        {
            var streamReader = new StreamReader(bodyStream);
            var body = await streamReader.ReadToEndAsync();
            Console.Out.WriteLine("Body: " + body);
            if (!(JsonConvert.DeserializeObject<T>(body) is T obj))
            {
                throw new ArgumentException("Can't deserialize body to " + typeof(T) + ".");
            }
            return obj;
        }

        [HttpPost]
        public async Task<bool> Add()
        {
            Console.WriteLine("users add called");
            var person = await BodyStreamToPerson<Person>(Request.Body);
            return users.TryAddUser(person);
        }

        [HttpPost]
        public async Task<bool> Update()
        {
            var person = await BodyStreamToPerson<Person>(Request.Body);
            return users.TryUpdateUser(person);
        }

        [HttpGet]
        public async Task<Person> Get()
        {
            var personId = await BodyStreamToPerson<int>(Request.Body);
            return users.TryGetPersonById(personId, out var person) ? person : null;
        }
    }
}
