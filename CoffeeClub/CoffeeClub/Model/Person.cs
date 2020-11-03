using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeClub.Model
{
    public class Person : IComparable<Person>
    {
        public Person(
            string FirstName,
            string SecondName,
            int Id,
            string[] Interests,
            string Region,
            string Country,
            string City,
            string Role,
            string Department,
            string Organization,
            int Age,
            string Sex
            )
        {
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.Id = Id;
            this.Interests = Interests;
            this.Region = Region;
            this.Country = Country;
            this.City = City;
            this.Role = Role;
            this.Department = Department;
            this.Organization = Organization;
            this.Age = Age;
            this.Sex = Sex;
        }

        /// <summary>
        /// The first name of the employee.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The second name of the employee.
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// The identifier used in the api to match the person.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of interests the person has.
        /// </summary>
        public string[] Interests { get; set; }

        /// <summary>
        /// The region where the person lives.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// The country where the person lives.
        /// </summary>

        public string Country { get; set; }

        /// <summary>
        /// The city where the person lives.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The role of the person within company.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// The department of the person.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// The organization of the person.
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// The age of the person.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// The sex of the person.
        /// </summary>
        public string Sex { get; set; }
        
        public override string ToString()
        {
            return "The first name of the person is " + this.FirstName + "\n"
                + "The second name of the person is " + this.SecondName + "\n"
                + "The age of the person is " + this.Age + "\n"
                + "The role is " + this.Role;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Person;

            if (item == null)
            {
                return false;
            }

            return this.Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public int CompareTo([AllowNull] Person other)
        {
            return Id - other.Id;
        }

        public static bool operator >(Person a, Person b) => a.Id > b.Id;
        public static bool operator <(Person a, Person b) => a.Id < b.Id;
        public static bool operator ==(Person a, Person b) => a.Id == b.Id;
        public static bool operator !=(Person a, Person b) => !(a == b);

    }
}
