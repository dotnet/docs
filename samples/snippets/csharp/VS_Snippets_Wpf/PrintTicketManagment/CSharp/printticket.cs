/*
 * Copyright (c) 1990 - 2005  Microsoft Corporation.
 * All Rights Reserved.
 *
 * This sample application shows how to use the .Net 3.0 API to query printer's PrintCapabilities
 * and to change printer's user-default PrintTicket setting.
 */

using System;
using System.Printing;

namespace PrintTicketSample
{
    class Application
    {
        //<SnippetUsingMergeAndValidate>
        /// <summary>
        /// Changes the user-default PrintTicket setting of the specified print queue.
        /// </summary>
        /// <param name="queue">the printer whose user-default PrintTicket setting needs to be changed</param>
        static private void ChangePrintTicketSetting(PrintQueue queue)
        {
            //
            // Obtain the printer's PrintCapabilities so we can determine whether or not
            // duplexing printing is supported by the printer.
            //
            PrintCapabilities printcap = queue.GetPrintCapabilities();

            //
            // The printer's duplexing capability is returned as a read-only collection of duplexing options
            // that can be supported by the printer. If the collection returned contains the duplexing
            // option we want to set, it means the duplexing option we want to set is supported by the printer,
            // so we can make the user-default PrintTicket setting change.
            //
            if (printcap.DuplexingCapability.Contains(Duplexing.TwoSidedLongEdge))
            {
                //
                // To change the user-default PrintTicket, we can first create a delta PrintTicket with
                // the new duplexing setting.
                //
                PrintTicket deltaTicket = new PrintTicket();
                deltaTicket.Duplexing = Duplexing.TwoSidedLongEdge;

                //
                // Then merge the delta PrintTicket onto the printer's current user-default PrintTicket,
                // and validate the merged PrintTicket to get the new PrintTicket we want to set as the
                // printer's new user-default PrintTicket.
                //
                ValidationResult result = queue.MergeAndValidatePrintTicket(queue.UserPrintTicket, deltaTicket);

                //
                // The duplexing option we want to set could be constrained by other PrintTicket settings
                // or device settings. We can check the validated merged PrintTicket to see whether the
                // the validation process has kept the duplexing option we want to set unchanged.
                //
                if (result.ValidatedPrintTicket.Duplexing == Duplexing.TwoSidedLongEdge)
                {
                    //
                    // Set the printer's user-default PrintTicket and commit the set operation.
                    //
                    queue.UserPrintTicket = result.ValidatedPrintTicket;
                    queue.Commit();
                    Console.WriteLine("PrintTicket new duplexing setting is set on '{0}'.", queue.FullName);
                }
                else
                {
                    //
                    // The duplexing option we want to set has been changed by the validation process
                    // when it was resolving setting constraints.
                    //
                    Console.WriteLine("PrintTicket new duplexing setting is constrained on '{0}'.", queue.FullName);
                }
            }
            else
            {
                //
                // If the printer doesn't support the duplexing option we want to set, skip it.
                //
                Console.WriteLine("PrintTicket new duplexing setting is not supported on '{0}'.", queue.FullName);
            }
        }
		//</SnippetUsingMergeAndValidate>

        //<SnippetUIForMergeAndValidatePTUtility>
        /// <summary>
        /// Displays the correct command line syntax to run this sample program.
        /// </summary>
        static private void DisplayUsage()
        {
            Console.WriteLine();
            Console.WriteLine("Usage #1: printticket.exe -l \"<printer_name>\"");
            Console.WriteLine("      Run program on the specified local printer");
            Console.WriteLine();
            Console.WriteLine("      Quotation marks may be omitted if there are no spaces in printer_name.");
            Console.WriteLine();
            Console.WriteLine("Usage #2: printticket.exe -r \"\\\\<server_name>\\<printer_name>\"");
            Console.WriteLine("      Run program on the specified network printer");
            Console.WriteLine();
            Console.WriteLine("      Quotation marks may be omitted if there are no spaces in server_name or printer_name.");
            Console.WriteLine();
            Console.WriteLine("Usage #3: printticket.exe -a");
            Console.WriteLine("      Run program on all installed printers");
            Console.WriteLine();
        }


        [STAThread]
        static public void Main(string[] args)
        {
            try
            {
                if ((args.Length == 1) && (args[0] == "-a"))
                {
                    //
                    // Change PrintTicket setting for all local and network printer connections.
                    //
                    LocalPrintServer server = new LocalPrintServer();

                    EnumeratedPrintQueueTypes[] queue_types = {EnumeratedPrintQueueTypes.Local,
                                                               EnumeratedPrintQueueTypes.Connections};

                    //
                    // Enumerate through all the printers.
                    //
                    foreach (PrintQueue queue in server.GetPrintQueues(queue_types))
                    {
                        //
                        // Change the PrintTicket setting queue by queue.
                        //
                        ChangePrintTicketSetting(queue);
                    }
                }//end if -a

                else if ((args.Length == 2) && (args[0] == "-l"))
                {
                    //
                    // Change PrintTicket setting only for the specified local printer.
                    //
                    LocalPrintServer server = new LocalPrintServer();
                    PrintQueue queue = new PrintQueue(server, args[1]);
                    ChangePrintTicketSetting(queue);
                }//end if -l
                    
                else if ((args.Length == 2) && (args[0] == "-r"))
                {
                    //
                    // Change PrintTicket setting only for the specified remote printer.
                    //
                    String serverName = args[1].Remove(args[1].LastIndexOf(@"\"));
                    String printerName = args[1].Remove(0, args[1].LastIndexOf(@"\")+1);
                    PrintServer ps = new PrintServer(serverName);
                    PrintQueue queue = new PrintQueue(ps, printerName);
                    ChangePrintTicketSetting(queue);
                 }//end if -r
               
                else
                {
                    //
                    // Unrecognized command line.
                    // Show user the correct command line syntax to run this sample program.
                    //
                    DisplayUsage();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                //
                // Show inner exception information if it's provided.
                //
                if (e.InnerException != null)
                {
                    Console.WriteLine("--- Inner Exception ---");
                    Console.WriteLine(e.InnerException.Message);
                    Console.WriteLine(e.InnerException.StackTrace);
                }
            }
            finally
            {
                Console.WriteLine("Press Return to continue...");
                Console.ReadLine();
            }
        }//end Main
        //</SnippetUIForMergeAndValidatePTUtility>

    }//end Application class
}//end namespace