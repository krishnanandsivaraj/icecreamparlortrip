using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SolutionOfKrishnanand.Readers
{
    public class TsvReader : IReader
    {
        List<string> input = new List<string>();
        public List<string> Read()
        {
            try
            {
                using (StreamReader r = new StreamReader(ConfigurationManager.AppSettings["InputPath"] + ConfigurationManager.AppSettings["fileName"]))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        input.Add(line);
                    }

                }
            }
            catch (Exception Ex)
            {

                Console.WriteLine("There is an error reading the file. Check FilePath or your input!!");
                Console.WriteLine($"Detailed Log: {Ex.Message}" );
            }
            return input;
        }
    }
}
