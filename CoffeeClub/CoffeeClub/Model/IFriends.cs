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
        private readonly IDictionary<Person, IList<Person>> friends = new Dictionary<Person, IList<Person>>();

        private void SortPersons(ref Person p1, ref Person p2)
        {
            if(p1 > p2)
            {
                var temp = p1;
                p1 = p2;
                p2 = temp;
            }
        }

        public bool AreFriends(Person p1, Person p2)
        {
            SortPersons(ref p1, ref p2);
            return friends.TryGetValue(p1, out var p1Friends) && p1Friends.Contains(p2);
        }

        public bool TryAddFriends(Person p1, Person p2)
        {
            SortPersons(ref p1, ref p2);

            if(AreFriends(p1, p2))
            {
                return false;
            }

            if (!friends.ContainsKey(p1))
            {
                friends.Add(p1, new List<Person>());
            }
            friends[p1].Add(p2);
            return true;
        }
    }
}
