using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ.Demo
{
    public class Entry
    {
        public static void Main(string[] args)
        {
            var users = new UserProvider().Provide();

            var italians = users.Where(u => u.Country == "Italy");

            foreach (var italian in italians.GroupBy(i => i.Zip.First()).OrderBy(g => g.Key))
            {
                Console.WriteLine(italian.Key);
                
                foreach (var user in italian)
                {
                    Console.Write("\t");
                    Console.WriteLine(user);
                }
            }

            Console.ReadKey();
        }
    }
}
