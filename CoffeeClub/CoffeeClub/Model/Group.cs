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

        public void AddMember(Person person) => GroupMembers.Add(person);

        public void RemoveMember(Person person) => GroupMembers.Remove(person);

        public bool ContainsMember(Person person) => GroupMembers.Contains(person);

        public HashSet<Person> GroupMembers { get; } = new HashSet<Person>();
        public int Count => GroupMembers.Count;
    }
}
