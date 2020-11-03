using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeClub.Model
{
    public interface IOnTheSpotQueue
    {
        bool TryGetMatch(Person toBeMatched, out Person match);
        bool TryAddToQueue(Person personToBeAdded);
    }

    public class OnTheSpotQueue : IOnTheSpotQueue
    {
        private readonly List<Person> queue;
        private readonly IFriends friends;

        public OnTheSpotQueue(IFriends friends)
        {
            this.friends = friends;
        }

        public bool TryAddToQueue(Person personToBeAdded)
        {
            if(queue.Contains(personToBeAdded)){
                return false;
            }
            queue.Add(personToBeAdded);
            return true;
        }

        public bool TryGetMatch(Person toBeMatched, out Person match)
        {
            foreach  (var person in queue)
            {
                if(!friends.AreFriends(person, toBeMatched))
                {
                    match = person;
                    queue.Remove(person);
                    return true;
                }
            }
            match = null;
            return false;
        }
    }
}
