using System;
using System.Collections.Generic;
using System.Text;
using System.Printing;
using System.Collections;

namespace EnumerateSubsetOfPrintQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            //<SnippetListSubsetOfPrintQueues>
            // Specify that the list will contain only the print queues that are installed as local and are shared
            EnumeratedPrintQueueTypes[] enumerationFlags = {EnumeratedPrintQueueTypes.Local,
                                                            EnumeratedPrintQueueTypes.Shared};

            LocalPrintServer printServer = new LocalPrintServer();

            //Use the enumerationFlags to filter out unwanted print queues
            PrintQueueCollection printQueuesOnLocalServer = printServer.GetPrintQueues(enumerationFlags);

            Console.WriteLine("These are your shared, local print queues:\n\n");

            foreach (PrintQueue printer in printQueuesOnLocalServer)
            {
                Console.WriteLine("\tThe shared printer " + printer.Name + " is located at " + printer.Location + "\n");
            }
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
            //</SnippetListSubsetOfPrintQueues>
        }
    }
}
