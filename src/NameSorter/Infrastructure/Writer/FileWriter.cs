using System.Collections.Generic;
using System.IO;
using System.Text;
using NameSorter.Domain;

namespace NameSorter.Infrastructure.Writer
{
    public class FileWriter : IWriter
    {
        private readonly string _outputFilePath;

        public FileWriter(string outputFilePath)
        {
            _outputFilePath = outputFilePath;
        }

        // Method Write writes to the file from the sorted List of Person object. 
        // Path to the file - a parameter of FileWriter Class constructor. 
        public void Write(IEnumerable<Person> persons)
        {
            using var writer = new StreamWriter(_outputFilePath, append: false, encoding: Encoding.UTF8);
            foreach (var person in persons)
            {
                writer.WriteLine(person);
            }
        }
    }
}