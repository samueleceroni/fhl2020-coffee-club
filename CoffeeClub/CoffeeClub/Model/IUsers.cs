using System.Collections.Generic;

namespace CoffeeClub.Model
{
    public interface IUsers
    {
        bool TryGetPersonById(int personId, out Person person);
        bool TryAddUser(Person person);
        bool AreFriends(Person p1, Person p2);
        bool TryAddFriends(Person p1, Person p2);
        bool TryUpdateUser(Person person);
        IEnumerable<Person> GetAllFriends(Person p);
    }

    public class Users : IUsers
    {
        private readonly IDictionary<int, Person> users = new Dictionary<int, Person>{
            {
                0, new Person(
                    "Catalin",
                    "Galban",
                    0,
                    new string[]
                    {
                        "football",
                        "pizza",
                        "hiking"
                    },
                    "Greater London",
                    "UK",
                    "London",
                    "Software Engineer",
                    "Research and experiences",
                    "JP Morgan",
                    20,
                    "M"
                    )
            },
            {
                1, new Person(
                    "Alexandra",
                    "Savu",
                    1,
                    new string[]
                    {
                        "maths",
                        "machine learning",
                        "reading"
                    },
                    "Bucharest Area",
                    "Romania",
                    "Bucharest",
                    "Software Engineer",
                    "Research and experiences",
                    "Microsoft",
                    25,
                    "F"
                )
            }
        };

        private readonly IDictionary<int, IList<Person>> friends = new Dictionary<int, IList<Person>>();
        private int idCounter = 2;

        private void SortPersons(ref Person p1, ref Person p2)
        {
            if(p1 > p2)
            {
                var temp = p1;
                p1 = p2;
                p2 = temp;
            }
        }

        public bool TryAddUser(Person person)
        {
            person.Id = idCounter++;
            users.Add(person.Id, person);
            return true;
        }

        public bool AreFriends(Person p1, Person p2)
        {
            SortPersons(ref p1, ref p2);
            return friends.TryGetValue(p1.Id, out var p1Friends) && p1Friends.Contains(p2);
        }

        public bool TryAddFriends(Person p1, Person p2)
        {
            SortPersons(ref p1, ref p2);

            if (AreFriends(p1, p2))
            {
                return false;
            }

            if (!friends.ContainsKey(p1.Id))
            {
                friends.Add(p1.Id, new List<Person>());
            }
            friends[p1.Id].Add(p2);
            return true;
        }


        public bool TryRemoveFriends(Person p1, Person p2)
        {
            SortPersons(ref p1, ref p2);

            if (!AreFriends(p1, p2))
            {
                return false;
            }
            friends[p1.Id].Remove(p2);
            return true;
        }

        public IEnumerable<Person> GetAllFriends(Person p)
        {
            return friends.TryGetValue(p.Id, out var pFriends) ? new List<Person>(pFriends) : new List<Person>();
        }

        public bool TryGetPersonById(int personId, out Person person) =>
            users.TryGetValue(personId, out person);

        public bool TryUpdateUser(Person person) =>
            users.TryGetValue(person.Id, out var p) && p.TryToUpdateToPerson(person);

    }
}
