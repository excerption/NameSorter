using System.Collections.Generic;
using NameSorter.Domain;

namespace NameSorter.Infrastructure.Reader
{
    public interface IReader
    {
        public List<Person> Read();
    }
}