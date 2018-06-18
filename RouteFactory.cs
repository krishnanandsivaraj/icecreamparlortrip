using SolutionOfKrishnanand.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionOfKrishnanand
{
    public static class RouteFactory
    {
        public static List<string> Get(string input) {
            switch (input) {
                case "tsv":
                    IReader tsvReader = new TsvReader();
                    return tsvReader.Read();
                default:
                   return null;

            }
        }
    }
}
