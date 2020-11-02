using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeClub.Model
{
    /// <summary>
    /// Interface for different assigning strategies of groups.
    /// </summary>
    public interface IGroupAssignerStrategy
    {
        /// <summary>
        /// Divide people based on the metrics corresponding to the strategy adopted on matching people.
        /// </summary>
        /// <param name="people">The list of people to divide into groups.</param>
        /// <returns>A list of groups containing different people.</returns>
        public List<Group> CreateGroups(List<Person> people);
    }
}
