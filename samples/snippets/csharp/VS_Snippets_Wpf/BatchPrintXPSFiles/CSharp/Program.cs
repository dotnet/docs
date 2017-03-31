using System;
using System.Collections.Generic;
using System.Text;
using System.Printing;
using System.IO;
using System.Threading;


namespace BatchPrintXPSFiles
{
    //<SnippetBatchPrintXPSFiles>
    class Program
    {
        [System.MTAThreadAttribute()] // Added for clarity, but this line is redundant because MTA is the default.
        static void Main(string[] args)
        {
            // Create the secondary thread and pass the printing method for 
            // the constructor's ThreadStart delegate parameter. The BatchXPSPrinter
            // class is defined below.
            Thread printingThread = new Thread(BatchXPSPrinter.PrintXPS);

            // Set the thread that will use PrintQueue.AddJob to single threading.
            printingThread.SetApartmentState(ApartmentState.STA);

            // Start the printing thread. The method passed to the Thread 
            // constructor will execute.
            printingThread.Start();
       
        }//end Main

    }//end Program class

    public class BatchXPSPrinter
    {
        public static void PrintXPS()
        {
            // Create print server and print queue.
            LocalPrintServer localPrintServer = new LocalPrintServer();
            PrintQueue defaultPrintQueue = LocalPrintServer.GetDefaultPrintQueue();
            
            // Prompt user to identify the directory, and then create the directory object.
            Console.Write("Enter the directory containing the XPS files: ");
            String directoryPath = Console.ReadLine();
            DirectoryInfo dir = new DirectoryInfo(directoryPath);

            // If the user mistyped, end the thread and return to the Main thread.
            if (!dir.Exists)
            {
                Console.WriteLine("There is no such directory.");
            }
            else
            {
                // If there are no XPS files in the directory, end the thread 
                // and return to the Main thread.
                if (dir.GetFiles("*.xps").Length == 0)
                {
                    Console.WriteLine("There are no XPS files in the directory.");
                }
                else
                {
                    Console.WriteLine("\nJobs will now be added to the print queue.");
                    Console.WriteLine("If the queue is not paused and the printer is working, jobs will begin printing.");
                    
                    // Batch process all XPS files in the directory.
                    foreach (FileInfo f in dir.GetFiles("*.xps"))
                    {
                        String nextFile = directoryPath + "\\" + f.Name;
                        Console.WriteLine("Adding {0} to queue.", nextFile);

                        try
                        {
                            // Print the Xps file while providing XPS validation and progress notifications.
                            PrintSystemJobInfo xpsPrintJob = defaultPrintQueue.AddJob(f.Name, nextFile, false);
                        }
                        catch (PrintJobException e)
                        {
                            Console.WriteLine("\n\t{0} could not be added to the print queue.", f.Name);
                            if (e.InnerException.Message == "File contains corrupted data.")
                            {
                                Console.WriteLine("\tIt is not a valid XPS file. Use the isXPS Conformance Tool to debug it.");
                            }
                            Console.WriteLine("\tContinuing with next XPS file.\n");
                        }

                    }// end for each XPS file
               
                }//end if there are no XPS files in the directory

            }//end if the directory does not exist

            Console.WriteLine("Press Enter to end program.");
            Console.ReadLine();

        }// end PrintXPS method

    }// end BatchXPSPrinter class
    //</SnippetBatchPrintXPSFiles>
}// end namespace
