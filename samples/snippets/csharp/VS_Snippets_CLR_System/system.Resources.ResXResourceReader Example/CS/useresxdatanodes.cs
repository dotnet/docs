//<Snippet2>
using System;
using System.Collections;
using System.Resources;
using System.ComponentModel.Design;

namespace UseDataNodesExample
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("\nEnumerating as data items...");
            EnumResourceItems("Resource1.resx", false);

            Console.WriteLine("\nEnumerating as data nodes...");
            EnumResourceItems("Resource1.resx", true);
        }

        public static void EnumResourceItems(string resxFile, bool useDataNodes)
        {
            using (ResXResourceReader reader = new ResXResourceReader(resxFile))
            {
                reader.UseResXDataNodes = useDataNodes;

                //<Snippet3>
                // Enumerate using IEnumerable.GetEnumerator().
                Console.WriteLine("\n  Default enumerator:");
                foreach (DictionaryEntry entry in reader)
                {
                    ShowResourceItem(entry, useDataNodes);
                }
                //</Snippet3>

                //<Snippet4>
                // Enumerate using GetMetadataEnumerator()
                IDictionaryEnumerator metadataEnumerator = reader.GetMetadataEnumerator();

                Console.WriteLine("\n  MetadataEnumerator:");
                while (metadataEnumerator.MoveNext())
                {
                    ShowResourceItem(metadataEnumerator.Entry, useDataNodes);
                }
                //</Snippet4>

                //<Snippet5>
                // Enumerate using GetEnumerator()
                IDictionaryEnumerator enumerator = reader.GetEnumerator();

                Console.WriteLine("\n  Enumerator:");
                while (enumerator.MoveNext())
                {
                    ShowResourceItem(enumerator.Entry, useDataNodes);
                }
                //</Snippet5>
            }
        }

        public static void ShowResourceItem(DictionaryEntry entry, bool isDataNode)
        {
            // Use a null type resolver.
            ITypeResolutionService typeres = null;
            ResXDataNode dnode;

            if (isDataNode)
            {
                // Display from node info.
                dnode = (ResXDataNode)entry.Value;
                Console.WriteLine("  {0}={1}", dnode.Name, dnode.GetValue(typeres));
            }
            else
            {
                // Display as DictionaryEntry info.
                Console.WriteLine("  {0}={1}", entry.Key, entry.Value);
            }
        }
    }
}

// The example program will have the following output:
//
// Enumerating as data items...
//
//   Default enumerator:
//   DataSample=Sample DATA value
//
//   MetadataEnumerator:
//   MetadataSample=Sample METADATA value
//
//   Enumerator:
//   DataSample=Sample DATA value
//
// Enumerating as data nodes...
//
//   Default enumerator:
//   DataSample=Sample DATA value
//   MetadataSample=Sample METADATA value
//
//   MetadataEnumerator:
//
//   Enumerator:
//   DataSample=Sample DATA value
//   MetadataSample=Sample METADATA value
//</Snippet2>