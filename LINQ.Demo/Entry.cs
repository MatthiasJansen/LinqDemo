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
            //ShowFilteredAndGrouped();
            ShowImmutability();

            Console.ReadKey();
        }

        private static void ShowFilteredAndGrouped()
        {
            var itaGroups = FilterAndGroupingA();
            //var itaGroups = FilterAndGroupingB();

            foreach (var itaGroup in itaGroups)
            {
                Console.WriteLine(itaGroup.Key);

                foreach (var user in itaGroup)
                {
                    Console.Write("\t");
                    Console.WriteLine(user);
                }
            }
        }

        private static IEnumerable<IGrouping<char, User>> FilterAndGroupingA()
        {
            var itaGroups = 
                from user in new UserProvider().Provide()
                where user.Country == "Italy"
                group user by user.Zip.First()
                into g
                orderby g.Key
                select g;

            return itaGroups;
        }

        private static IEnumerable<IGrouping<char, User>> FilterAndGroupingB()
        {
            var users = new UserProvider().Provide();

            var itaGroups = users
                .Where(u => u.Country == "Italy")
                .GroupBy(i => i.Zip.First()).OrderBy(g => g.Key);

            return itaGroups;
        }

        private static void ShowImmutability()
        {
            var numbers = Enumerable.Range(0, 10);
            Console.WriteLine($"Numbers in the original sequence: {numbers.Count()}");
            var filter1 = numbers.Where(n => n > 4);
            Console.WriteLine($"Remaining numbers: {filter1.Count()}");
            var filter2 = filter1.Where(n => n > 4);
            Console.WriteLine($"Remaining numbers: {filter2.Count()}");


            Console.WriteLine($"Are these two enumerables reference equal? {(Equals(filter1, filter2) ? "yep" : "nah")}");
        }
    }
}
