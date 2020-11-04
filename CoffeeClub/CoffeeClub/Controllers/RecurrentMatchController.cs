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
    public class RecurrentMatchController : ControllerBase
    {
        private readonly IUsers users;

        public RecurrentMatchController(IUsers users)
        {
            this.users = users;
        }

        [HttpGet]
        public IEnumerable<Group> GetRecurrentMatch()
        {
            var solution = new List<Group>();
            MakeGroups(solution, new HashSet<Person>()/*change with active unpaired members*/, 2);
            return solution;
        }

        private IEnumerable<Person> GetPossibleMatches(Group group, ISet<Person> activeUnpairedMembers){
            var possibleMatches = new HashSet<Person>(activeUnpairedMembers);
            foreach (var member in group.GroupMembers)
            {
                foreach (var alreadyFriendMember in users.GetAllFriends(member))
                {
                    possibleMatches.Remove(alreadyFriendMember);
                }
            }
            return possibleMatches;
        }

        private void MakeGroups(IList<Group> currSolution, ISet<Person> activeUnpairedMembers, int normalGroupSize)
        {

        }
    }
}