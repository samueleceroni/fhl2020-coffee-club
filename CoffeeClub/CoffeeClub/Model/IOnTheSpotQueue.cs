using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeClub.Model
{
    public interface IFriends
    {
        bool AreFriends(Person p1, Person p2);
        bool TryAddFriends(Person p1, Person p2);
    }

    public class Friends : IFriends
    {
        private IDictionary<Person, IList<Person>> friends;

        public bool AreFriends(Person p1, Person p2)
        {
            if (friends.TryGetValue(p1, out var p1Friends))
            {
                 
            }
            //friends.tr
            throw new NotImplementedException();
        }

        public bool TryAddFriends(Person p1, Person p2)
        {
            throw new NotImplementedException();
        }
    }
}
