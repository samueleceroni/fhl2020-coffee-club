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
            this.GroupMembers = new HashSet<Person>();
        }
        public void AddMember(Person person)
        {
            this.GroupMembers.Add(person);
        }

        public bool ContainsMember(Person person)
        {
            return this.GroupMembers.Contains(person);
        }
        public bool Notified { get; }
        public HashSet<Person> GroupMembers { get; }
    }
}
