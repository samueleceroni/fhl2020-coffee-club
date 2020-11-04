using CoffeeClub.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeClub.Controllers
{
    public class MatchFinder
    {
        /// <summary>
        /// People that don't currently have a match.
        /// </summary>
        private HashSet<Person> UnassignedPeople;
        
        /// <summary>
        /// Groups based on similar interests.
        /// </summary>
        private List<Group> Groups;

        /// <summary>
        /// Initializing a <see cref="MatchFinder.cs"/> and register all people as unassigned.
        /// </summary>
        /// <param name="Employees">The list of all employees.</param>
        /// <param name="AssignerStrategy">The strategy for group division.</param>
        public MatchFinder(List<Person> Employees, IGroupAssignerStrategy AssignerStrategy)
        {
            UnassignedPeople = new HashSet<Person>();
            foreach (Person Employee in Employees)
            {
                UnassignedPeople.Add(Employee);
            }
            Groups = AssignerStrategy.CreateGroups(Employees);
        }

        /// <summary>
        /// Return the first match we find.
        /// </summary>
        /// <param name="Person">The person for which we look for a match.</param>
        /// <returns>The match.</returns>
        public Person GetFirstMatch(Person Person)
        {
            if (UnassignedPeople.Contains(Person))
            {
                foreach (Group Group in Groups)
                {
                    if (Group.ContainsMember(Person))
                    {
                        foreach (Person GroupMember in Group.GroupMembers)
                        {
                            if (UnassignedPeople.Contains(GroupMember) && !Person.Equals(GroupMember))
                            {
                                UnassignedPeople.Remove(GroupMember);
                                UnassignedPeople.Remove(Person);
                                return Person;
                            }
                        }
                    }
                }
                return null;
            }
            return null;
        }
    }
}
