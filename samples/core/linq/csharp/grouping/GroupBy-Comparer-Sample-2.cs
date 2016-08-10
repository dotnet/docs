using System;
using System.Linq;

namespace Grouping
{
    public class GroupByComparer2
    {
        //This sample uses GroupBy to partition trimmed elements of an array using a 
        // custom comparer that matches words that are anagrams of each other and
        // then converts the results to uppercase.
        //Outputs the following to Console: 
        //from
        //    FROM
        //    FORM
        //--------------
        //salt
        //    SALT
        //    LAST
        //--------------
        //earn
        //    EARN
        //    NEAR
        public static void MethodSyntaxExample()
        {
            string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

            var orderGroups = anagrams.GroupBy(
                    w => w.Trim(), 
                    a => a.ToUpper(),
                    new AnagramEqualityComparer()
                );
            
            foreach (var s in orderGroups)
            {
                Console.WriteLine("--------------");
                Console.WriteLine(s.Key);
                foreach (var i in s.ToList())
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
