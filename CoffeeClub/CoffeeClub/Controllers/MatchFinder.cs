using CoffeeClub.Model;
using Microsoft.AspNetCore.Identity;
using ServiceStack.Host;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
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
        /// The relationships between the users of the app.
        /// </summary>
        private IUsers UsersRelationships;

        /// <summary>
        /// Initializing a <see cref="MatchFinder.cs"/> and register all people as unassigned.
        /// </summary>
        /// <param name="UsersRelationships">The relationships between the users.</param>
        /// <param name="AssignerStrategy">The strategy for group division.</param>
        public MatchFinder(IUsers UsersRelationships, IGroupAssignerStrategy AssignerStrategy)
        {
            this.UsersRelationships = UsersRelationships;
            UnassignedPeople = new HashSet<Person>();
            var Employees = UsersRelationships.GetPeople();
            Console.Out.WriteLine(Employees[0]);
            foreach (Person Employee in Employees)
            {
                UnassignedPeople.Add(Employee);
            }
            Groups = AssignerStrategy.CreateGroups(Employees);
        }

        /// <summary>
        /// Initializing a <see cref="MatchFinder.cs"/> and register all people as unassigned.
        /// </summary>
        /// <param name="Employees">The list of all employees.</param>
        /// <param name="AssignerStrategy">The strategy for group division.</param>
        public List<Person> GetUnMatchedPeople()
        {
            return UnassignedPeople.ToList();
        }
        public Person GetFirstMatch(int Id)
        {
            Person searchedPerson; 
            if (this.UsersRelationships.TryGetPersonById(Id,out searchedPerson))
            {
                return this.GetFirstMatch(searchedPerson);
            }
            else
            {
                throw new HttpException(404,"User with id " + Id + " does not exist in the database");
            }
        }
        /// <summary>
        /// Return the first match we find.
        /// </summary>
        /// <param name="Person">The person for which we look for a match.</param>
        /// <returns>The match.</returns>
        private Person GetFirstMatch(Person Person)
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
                                if (this.UsersRelationships.AreFriends(Person, GroupMember))
                                {
                                    UnassignedPeople.Remove(GroupMember);
                                    UnassignedPeople.Remove(Person);
                                    return Person;
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
