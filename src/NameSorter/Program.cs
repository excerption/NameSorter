using System;
using NameSorter.Infrastructure.Reader;
using NameSorter.Infrastructure.Writer;

namespace NameSorter
{
    class Program
    {
        private const string OutputFileName = "sorted-names-list.txt";

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentException("Input file name with list of names expected as a single argument");
            }
            
            try
            {
                IReader reader = new FileReader(args[0]);

                var persons = reader.Read();
                persons.Sort();

                var writers = new IWriter[]
                {
                    new FileWriter(OutputFileName),
                    new ConsoleWriter(),
                };

                foreach (var writer in writers)
                {
                    writer.Write(persons);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(-1);
            }
        }
    }
}
