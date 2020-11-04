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
            MakeGroups(solution, new HashSet<Person>(users.GetAllUsers()), 2);
            return solution;
        }

        private IEnumerable<Person> GetPossibleMatches(Group group, ISet<Person> activeUnpairedMembers){
            var possibleMatches = new HashSet<Person>(activeUnpairedMembers);
            foreach (var member in group.GroupMembers)
                foreach (var alreadyFriendMember in users.GetAllFriends(member))
                    possibleMatches.Remove(alreadyFriendMember);
            return possibleMatches;
        }

        private void MakeGroups(IList<Group> currSolution, ISet<Person> activeUnpairedMembers, int normalGroupSize)
        {
            if (activeUnpairedMembers.Count == 0) return;
            if(currSolution.Count == 0 || currSolution.Last().Count >= normalGroupSize)
                currSolution.Add(new Group());
            var possibleMatches = GetPossibleMatches(currSolution.Last(), activeUnpairedMembers);
            foreach(var match in possibleMatches)
            {
                activeUnpairedMembers.Remove(match);
                foreach(var member in currSolution.Last().GroupMembers)
                    users.TryAddFriends(member, match);
                currSolution.Last().AddMember(match);
                MakeGroups(currSolution, activeUnpairedMembers, normalGroupSize);
                if (activeUnpairedMembers.Count == 0) return;
                currSolution.Last().RemoveMember(match);
                foreach(var member in currSolution.Last().GroupMembers)
                    users.TryRemoveFriends(member, match);
                activeUnpairedMembers.Add(match);
            }
            if (currSolution.Last().Count == 0)
                currSolution.RemoveAt(currSolution.Count - 1);
        }
    }
}