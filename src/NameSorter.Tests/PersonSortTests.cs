using System.Collections.Generic;
using System.Linq;
using NameSorter.Domain;
using Xunit;

namespace NameSorter.Tests
{
    public class PersonsSortTests
    {
        [Fact]
        public void GivenEmptyNamesList_ShouldReturnEmptyList()
        {
            var persons = Enumerable.Empty<Person>().ToList();

            persons.Sort();

            Assert.Empty(persons);
        }

        [Fact]
        public void GivenDifferentLastNames_ShouldSortByLastNameFirst()
        {
            var fullNames = new List<string>
            {
                "Han Solo",
                "Luke Skywalker",
                "Boba Fett",
            };
            var persons = GetPersonsFromFullNames(fullNames);

            persons.Sort();

            var expectedPersons = new List<string>
            {
                "Boba Fett",
                "Luke Skywalker",
                "Han Solo",
            };
            Assert.Equal(expectedPersons, ConvertPersonsToStrings(persons));
        }

        [Fact]
        public void GivenSameLastNames_ShouldSortByGivenNames()
        {
            var fullNames = new List<string>
            {
                "Luke Skywalker",
                "Anakin Skywalker",
                "Leia Skywalker",
            };
            var persons = GetPersonsFromFullNames(fullNames);

            persons.Sort();

            var expectedPersons = new List<string>
            {
                "Anakin Skywalker",
                "Leia Skywalker",
                "Luke Skywalker",
            };
            Assert.Equal(expectedPersons, ConvertPersonsToStrings(persons));
        }

        [Fact]
        public void GivenVariousNames_ShouldSortCorrectly()
        {
            var fullNames = new List<string>
            {
                "Janet Parsons",
                "Vaughn Lewis",
                "Adonis Julius Archer",
                "Shelby Nathan Yoder",
                "Marin Alvarez",
                "London Lindsey",
                "Beau Tristan Bentley",
                "Leo Gardner",
                "Hunter Uriah Mathew Clarke",
                "Mikayla Lopez",
                "Frankie Conner Ritter",
            };
            var persons = GetPersonsFromFullNames(fullNames);

            persons.Sort();

            var expectedPersons = new List<string>
            {
                "Marin Alvarez",
                "Adonis Julius Archer",
                "Beau Tristan Bentley",
                "Hunter Uriah Mathew Clarke",
                "Leo Gardner",
                "Vaughn Lewis",
                "London Lindsey",
                "Mikayla Lopez",
                "Janet Parsons",
                "Frankie Conner Ritter",
                "Shelby Nathan Yoder",
            };
            Assert.Equal(expectedPersons, ConvertPersonsToStrings(persons));
        }

        private static List<Person> GetPersonsFromFullNames(IEnumerable<string> fullNames)
        {
            return fullNames.Select(Person.Parse).ToList();
        }

        private static List<string> ConvertPersonsToStrings(IEnumerable<Person> persons)
        {
            return persons.Select(person => person.ToString()).ToList();
        }
    }
}