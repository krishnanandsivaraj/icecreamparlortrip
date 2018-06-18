using System;
using System.Collections.Generic;

namespace SolutionOfKrishnanand
{
    public static class Validators
    {

        public static bool Validated(this List<string> input,string delimiter) {
            if (input == null || input.Count==0) { Console.WriteLine("The file is empty"); return false; }
            foreach (var item in input)
            {
                //ToDO: Mapper here violates KISS, YAGNI and SRP.  Refactoring needed.
                Dictionary<string, char> mapper = new Dictionary<string, char>();
                mapper.Add("tsv",'\t');
                string[] line = item.Split(mapper[delimiter]);
                if (line.Length < 2) {Console.WriteLine("We Need atleast one departure or pickup point");return false;}
                for (int i = 1; i < line.Length; i++)
                {
                    try
                    {
                        if (CheckCoOrdinates(line, i,0) == "" || CheckCoOrdinates(line, i, 1) == "")
                        {
                            Console.WriteLine("Wrong Co-ordinates!! Check input!!");
                            Console.WriteLine($"{line[i]} is not a valid co-ordinate!!");
                            return false;
                        }
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine($"Something wrong with co-ordinates!! Check Input!! Exception: {Ex.Message}");
                        return false;
                    }
                    
                }
            }
            return true;
        }

        private static string CheckCoOrdinates(string[] line, int i,int index)
        {
            return line[i].Split(':')[1].Replace('[', ' ').Replace(']', ' ').Trim().Split(',')[index];
        }
    }
}
