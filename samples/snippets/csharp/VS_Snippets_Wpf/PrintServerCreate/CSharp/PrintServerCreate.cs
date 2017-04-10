using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Xml;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using System.Printing;

public class PrintServerCreate
{
    [STAThread]
    static void Main(string[] args)
    {
        PrintServerCreate psCreate = new PrintServerCreate();
        psCreate.Run();
    }

    public void Run()
    {
        // <Snippet_CreatePrintServer>

        // Create a PrintServer
        // "theServer" must be a print server to which the user has full print access.
        PrintServer myPrintServer = new PrintServer(@"\\theServer");

        // List the print server's queues
        PrintQueueCollection myPrintQueues = myPrintServer.GetPrintQueues();
        String printQueueNames = "My Print Queues:\n\n";
        foreach (PrintQueue pq in myPrintQueues)
        {
            printQueueNames += "\t" + pq.Name + "\n";
        }
        Console.WriteLine(printQueueNames);
        Console.WriteLine("\nPress Return to continue.");
        Console.ReadLine();
        
        // </Snippet_CreatePrintServer>
    }//end Run()
       
}// end:class PrintServerCreate
