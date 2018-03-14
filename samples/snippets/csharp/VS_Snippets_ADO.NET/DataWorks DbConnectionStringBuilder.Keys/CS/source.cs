using System;
using System.Data;
using System.Data.Common;
using System.Collections;

namespace ConBuilderKeysCS
{
    class Program
    {
        // <Snippet1>
        static void Main()
        {
            DbConnectionStringBuilder builder = new
                DbConnectionStringBuilder();
            builder["Data Source"] = "(local)";
            builder["Integrated Security"] = true;
            builder["Initial Catalog"] = "AdventureWorks";

            // Obtain reference to the collection of keys.
            ICollection keys = builder.Keys;

            Console.WriteLine("Keys before adding TimeOut:");
            foreach (string key in keys)
                Console.WriteLine("{0}={1}", key, builder[key]);

            // Add a new item to the collection.
            builder["Timeout"] = 300;

            Console.WriteLine();
            Console.WriteLine("Keys after adding TimeOut:");

            // Because the Keys property is dynamically updated, 
            // the following loop includes the Timeout key.
            foreach (string key in keys)
                Console.WriteLine("{0}={1}", key, builder[key]);
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
        // </Snippet1>
    }
}
