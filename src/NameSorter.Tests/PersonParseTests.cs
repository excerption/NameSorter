using System;
using NameSorter.Domain;
using Xunit;
using Xunit.Sdk;

namespace NameSorter.Tests
{
    public class PersonParseTests
    {
        [Fact]
        public void GivenEmptyFullName_ShouldThrowArgumentNullException()
        {
            var fullName = string.Empty;

            Assert.Throws<ArgumentNullException>(() => Person.Parse(fullName));
        }

        [Fact]
        public void GivenNullAsFullName_ShouldThrowArgumentNullException()
        {
            string fullName = null;

            Assert.Throws<ArgumentNullException>(() => Person.Parse(fullName));
        }

        [Fact]
        public void GivenSingleWordName_ShouldThrowArgumentException()
        {
            var fullName = "Chewbacca";

            Assert.Throws<ArgumentException>(() => Person.Parse(fullName));
        }

        [Fact]
        public void GivenTooManyWordsFullName_ShouldThrowArgumentException()
        {
            // https://starwars.fandom.com/wiki/Hekis_Durumm_Perdo_Kolokk_Baldikarr_Thun
            var fullName = "Hekis Durumm Perdo Kolokk Baldikarr Thun";

            Assert.Throws<ArgumentException>(() => Person.Parse(fullName));
        }

        [Fact]
        public void GivenRegularFullName_ShouldBeParsedCorrectly()
        {
            var fullName = "Luke Skywalker";

            var person = Person.Parse(fullName);

            AssertPerson(person, expectedGivenNames: "Luke", expectedLastName: "Skywalker");
        }
        
        [Fact]
        public void GivenMultipleWordsFivenName_ShouldBeParsedCorrectly()
        {
            var fullName = "Jar Jar Binks";

            var person = Person.Parse(fullName);

            AssertPerson(person, expectedGivenNames: "Jar Jar", expectedLastName: "Binks");
        }
        
        private static void AssertPerson(Person actual, string expectedGivenNames, string expectedLastName)
        {
            if (actual.GivenNames == expectedGivenNames && actual.LastName == expectedLastName)
                return;

            throw new AssertActualExpectedException($"{expectedGivenNames} {expectedLastName}", actual,
                "Actual person contains unexpected Given or Last name");
        }
    }
}