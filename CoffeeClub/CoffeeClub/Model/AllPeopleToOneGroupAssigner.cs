using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeClub.Model
{
    /// <summary>
    /// For random assignment,it's sufficient to have one group.
    /// </summary>
    public class AllPeopleToOneGroupAssigner : IGroupAssignerStrategy
    {
        public List<Group> CreateGroups(List<Person> people)
        {
            List<Group> OneGroup = new List<Group>();
            Group AllPeopleGroup = new Group();
            foreach ( Person person in people)
            {
                AllPeopleGroup.AddMember(person);
            }
            OneGroup.Add(AllPeopleGroup);
            return OneGroup;
        }
    }
}
