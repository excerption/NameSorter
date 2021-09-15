using System.Collections.Generic;
using NameSorter.Domain;

namespace NameSorter.Infrastructure.Writer
{
    public interface IWriter
    {
        public void Write(IEnumerable<Person> persons);
    }
}