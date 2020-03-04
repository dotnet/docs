using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SequenceExamples
{
    static class IGrouping
    {
        static void Main(string[] args)
        {
            LookupExample();
        }

        // <Snippet1>
        class Package
        {
            public string Company;
            public double Weight;
            public long TrackingNumber;
        }

        public static void LookupExample()
        {
            // Create a list of Packages to put into a Lookup data structure.
            List<Package> packages = new List<Package> { new Package { Company = "Coho Vineyard", Weight = 25.2, TrackingNumber = 89453312L },
                                                         new Package { Company = "Lucerne Publishing", Weight = 18.7, TrackingNumber = 89112755L },
                                                         new Package { Company = "Wingtip Toys", Weight = 6.0, TrackingNumber = 299456122L },
                                                         new Package { Company = "Contoso Pharmaceuticals", Weight = 9.3, TrackingNumber = 670053128L },
                                                         new Package { Company = "Wide World Importers", Weight = 33.8, TrackingNumber = 4665518773L } };

            // Create a Lookup to organize the packages. Use the first character of Company as the key value.
            // Select Company appended to TrackingNumber for each element value in the Lookup.
            Lookup<char, string> lookup = (Lookup<char, string>)packages.ToLookup(p => Convert.ToChar(p.Company.Substring(0, 1)),
                                                            p => p.Company + " " + p.TrackingNumber);

            // <Snippet5>
            // Iterate through each IGrouping in the Lookup and output the contents.
            foreach (IGrouping<char, string> packageGroup in lookup)
            {
                // Print the key value of the IGrouping.
                Console.WriteLine(packageGroup.Key);
                // Iterate through each value in the IGrouping and print its value.
                foreach (string str in packageGroup)
                    Console.WriteLine("    {0}", str);
            }
            // </Snippet5>
                        
            // This code produces the following output:
            //
            // C
            //     Coho Vineyard 89453312
            //     Contoso Pharmaceuticals 670053128
            // L
            //     Lucerne Publishing 89112755
            // W
            //     Wingtip Toys 299456122
            //     Wide World Importers 4665518773

            // <Snippet2>
            // Get the number of key-collection pairs in the Lookup.
            int count = lookup.Count;
            // </Snippet2>

            // <Snippet3>
            // Select a collection of Packages by indexing directly into the Lookup.
            IEnumerable<string> cgroup = lookup['C'];
            // </Snippet3>

            // Output the results.
            Console.WriteLine("\nPackages that have a key of 'C':");
            foreach (string str in cgroup)
                Console.WriteLine(str);

            // This code produces the following output:
            //
            // Packages that have a key of 'C'
            // Coho Vineyard 89453312
            // Contoso Pharmaceuticals 670053128

            // <Snippet4>
            // Determine if there is a key with the value 'G' in the Lookup.
            bool hasG = lookup.Contains('G');
            // </Snippet4>
        }
        // </Snippet1>
    }
}
