using System;
using System.Collections.Generic;
using System.Text;
using System.Printing;
using System.Printing.IndexedProperties;

namespace ClonePrinter
{
    class Program
    {
        static void Main(string[] args)
        {
                //<SnippetClonePrinter>
                LocalPrintServer myLocalPrintServer = new LocalPrintServer(PrintSystemDesiredAccess.AdministrateServer);
                PrintQueue sourcePrintQueue = myLocalPrintServer.DefaultPrintQueue;
                PrintPropertyDictionary myPrintProperties = sourcePrintQueue.PropertiesCollection;

                // Share the new printer using Remove/Add methods
                PrintBooleanProperty shared = new PrintBooleanProperty("IsShared", true);
                myPrintProperties.Remove("IsShared");
                myPrintProperties.Add("IsShared", shared);

                // Give the new printer its share name using SetProperty method
                PrintStringProperty theShareName = new PrintStringProperty("ShareName", "\"Son of " + sourcePrintQueue.Name +"\"");
                myPrintProperties.SetProperty("ShareName", theShareName);

                // Specify the physical location of the new printer using Remove/Add methods
                PrintStringProperty theLocation = new PrintStringProperty("Location", "the supply room");
                myPrintProperties.Remove("Location");
                myPrintProperties.Add("Location", theLocation);

                // Specify the port for the new printer
                String[] port = new String[] { "COM1:" };

                // Install the new printer on the local print server
                PrintQueue clonedPrinter = myLocalPrintServer.InstallPrintQueue("My clone of " + sourcePrintQueue.Name, "Xerox WCP 35 PS", port, "WinPrint", myPrintProperties);
                myLocalPrintServer.Commit();

                // Report outcome
                Console.WriteLine("{0} in {1} has been installed and shared as {2}", clonedPrinter.Name, clonedPrinter.Location, clonedPrinter.ShareName);
                Console.WriteLine("Press Return to continue ...");
                Console.ReadLine();
                //</SnippetClonePrinter>
        }
    }
}
