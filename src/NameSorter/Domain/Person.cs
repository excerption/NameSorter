using System;

namespace NameSorter.Domain
{
    public class Person : IComparable
    {
        public Person(string givenNames, string lastName)
        {
            GivenNames = givenNames;
            LastName = lastName;
        }

        public string GivenNames { get; }
        public string LastName { get; }

        public override string ToString()
        {
            return $"{GivenNames} {LastName}";
        }

        // Method CompareTo compares two objects (type Person) by Surname.
        // If the object has the same Surname, the method compares the Fist names of the objects.
        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (!(obj is Person otherPerson))
            {
                throw new ArgumentException("Object is not a Person");
            }

            var lastNameComparison =
                string.Compare(LastName, otherPerson.LastName, StringComparison.InvariantCulture);
            return lastNameComparison == 0
                ? string.Compare(GivenNames, otherPerson.GivenNames, StringComparison.InvariantCulture)
                : lastNameComparison;
        }
        // Method Parse divides full name to first name(s) and second name. 
        // Creates and retuns an instance of Class Person.
        public static Person Parse(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentNullException(fullName, "Person full name is empty");
            }

            var nameParts = fullName.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length == 1 || nameParts.Length > 4)
            {
                throw new ArgumentException("Person full name should contain given names (1 to 3) and the last name.",
                    fullName);
            }

            var givenNames = string.Join(" ", nameParts[..^1]);
            var lastName = nameParts[^1];

            return new Person(
                givenNames: givenNames,
                lastName: lastName
            );
        }
    }
}