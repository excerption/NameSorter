using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NameSorter.Domain;

namespace NameSorter.Infrastructure.Reader
{
    public class FileReader : IReader
    {
        private readonly string _inputFilePath;

        public FileReader(string inputFilePath)
        {
            if (!File.Exists(inputFilePath))
            {
                throw new ArgumentException($"File doesn't exist for path {inputFilePath}");
            }

            _inputFilePath = inputFilePath;
        }

        // Method Read reads unsorted name from the file to the List of Person objects.
        // Path to the file - a parameter of FileReader Class constructor. 
        public List<Person> Read()
        {
            var persons = new List<Person>();

            using var reader = new StreamReader(_inputFilePath, encoding: Encoding.UTF8);
            string? fullName;
            while ((fullName = reader.ReadLine()) != null)
            {
                var person = Person.Parse(fullName);
                persons.Add(person);
            }

            return persons;
        }
    }
}