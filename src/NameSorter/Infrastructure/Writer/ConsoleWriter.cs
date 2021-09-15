using System;
using System.Collections.Generic;
using NameSorter.Domain;

namespace NameSorter.Infrastructure.Writer
{
    public class ConsoleWriter : IWriter
    {
        // Method Write writes to Console from the sorted List of Person object. 
        public void Write(IEnumerable<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}