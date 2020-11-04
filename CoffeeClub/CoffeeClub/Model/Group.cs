using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeClub.Model
{
    /// <summary>
    /// The group class corresponding to javascript.
    /// </summary>
    public class Group
    {

        public Group()
        {
            GroupMembers = new HashSet<Person>();
        }
        public void AddMember(Person person)
        {
            GroupMembers.Add(person);
        }

        public bool ContainsMember(Person person)
        {
            return GroupMembers.Contains(person);
        }
        public HashSet<Person> GroupMembers { get; } = new HashSet<Person>();
    }
}
