using System;
using System.Collections.Generic;
using System.Text;
using System.Printing;
using System.Printing.IndexedProperties;
using System.Collections;

namespace GetPrintObjectPropertiesWithoutReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //<SnippetShowPropertyTypesWithoutReflection>

            // Enumerate the properties, and their types, of a queue without using Reflection
            LocalPrintServer localPrintServer = new LocalPrintServer();
            PrintQueue defaultPrintQueue = LocalPrintServer.GetDefaultPrintQueue();

            PrintPropertyDictionary printQueueProperties = defaultPrintQueue.PropertiesCollection;

            Console.WriteLine("These are the properties, and their types, of {0}, a {1}", defaultPrintQueue.Name, defaultPrintQueue.GetType().ToString() +"\n");

            foreach (DictionaryEntry entry in printQueueProperties)
            {
                PrintProperty property = (PrintProperty)entry.Value;

                if (property.Value != null)
                {
                    Console.WriteLine(property.Name + "\t(Type: {0})", property.Value.GetType().ToString());
                }
            }
            Console.WriteLine("\n\nPress Return to continue...");
            Console.ReadLine();

            //</SnippetShowPropertyTypesWithoutReflection>
        }
    }
}
