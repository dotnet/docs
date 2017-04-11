using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using L2EMaterializationCS;

namespace DP_L2E_Materialization_Example
{
    class Program
    {
        // <SnippetMaterializationSideEffects>
        public static int count = 0;

        static void Main(string[] args)
        {
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {

                var query1 = AWEntities
                   .Contacts
                   .Where(c => c.LastName == "Jones")
                   .Select(c => new MyContact { LastName = c.LastName });

                // Execute the first query and print the count.
                query1.ToList();
                Console.WriteLine("Count: " + count);

                //Reset the count variable.
                count = 0;

                var query2 = AWEntities
                   .Contacts
                   .Where(c => c.LastName == "Jones")
                   .Select(c => new MyContact { LastName = c.LastName })
                   .Select(my => my.LastName);

                // Execute the second query and print the count.
                query2.ToList();
                Console.WriteLine("Count: " + count);

            }

            Console.WriteLine("Hit enter...");
            Console.Read();
        }
        // </SnippetMaterializationSideEffects>

        // <SnippetMyContactClass>
        public class MyContact
        {

            String _lastName;

            public string LastName
            {
                get
                {
                    return _lastName;
                }

                set
                {
                    _lastName = value;
                    count++;
                }
            }
        }
        // </SnippetMyContactClass>
    }
}
