using System;
using System.Collections.Generic;
using System.Text;
using System.Printing;
using System.Collections;
using System.IO;

namespace PrinterStatusSurvey
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obtain a list of print servers
            Console.Write("Enter path and file name of CRLF-delimited list of print servers: ");
            String pathToListOfPrintServers = Console.ReadLine();
            StreamReader fileOfPrintServers = new StreamReader(pathToListOfPrintServers);

            // Prompt user to determine the method of reading queue status that will be used
            Console.Write("Enter \"y\" to check queues using their QueueStatus attributes.\nOtherwise, press Return and they will be checked using their specific properties: ");
            String useAttributesResponse = Console.ReadLine();

            
            //<SnippetSurveyQueues>
            // Survey queue status for every queue on every print server
            String line;
            String statusReport = "\n\nAny problem states are indicated below:\n\n";
            while ((line = fileOfPrintServers.ReadLine()) != null)
             {
                 PrintServer myPS = new PrintServer(line, PrintSystemDesiredAccess.AdministrateServer);
                 PrintQueueCollection myPrintQueues = myPS.GetPrintQueues();
                 statusReport = statusReport + "\n" + line;
                 foreach (PrintQueue pq in myPrintQueues)
                 {
                     pq.Refresh();
                     statusReport = statusReport + "\n\t" + pq.Name + ":";
                     if (useAttributesResponse == "y")
                     {
                         TroubleSpotter.SpotTroubleUsingQueueAttributes(ref statusReport, pq);
                         // TroubleSpotter class is defined in the complete example.
                     }
                     else
                     {
                         TroubleSpotter.SpotTroubleUsingProperties(ref statusReport, pq);
                     }                 

                 }// end for each print queue

             }// end while list of print servers is not yet exhausted

            fileOfPrintServers.Close();
            Console.WriteLine(statusReport);
            Console.WriteLine("\nPress Return to continue.");
            Console.ReadLine();
            
            //</SnippetSurveyQueues>

        }//end Main

    }//end Program class

    class TroubleSpotter
    {
        // <SnippetSpotTroubleUsingQueueProperties>
        // Check for possible trouble states of a printer using its properties
        internal static void SpotTroubleUsingProperties(ref String statusReport, PrintQueue pq)
        {
            if (pq.HasPaperProblem)
            {
                statusReport = statusReport + "Has a paper problem. ";
            }
            if (!(pq.HasToner))
            {
                statusReport = statusReport + "Is out of toner. ";
            }
            if (pq.IsDoorOpened)
            {
                statusReport = statusReport + "Has an open door. ";
            }
            if (pq.IsInError)
            {
                statusReport = statusReport + "Is in an error state. ";
            }
            if (pq.IsNotAvailable)
            {
                statusReport = statusReport + "Is not available. ";
            }
            if (pq.IsOffline)
            {
                statusReport = statusReport + "Is off line. ";
            }
            if (pq.IsOutOfMemory)
            {
                statusReport = statusReport + "Is out of memory. ";
            }
            if (pq.IsOutOfPaper)
            {
                statusReport = statusReport + "Is out of paper. ";
            }
            if (pq.IsOutputBinFull)
            {
                statusReport = statusReport + "Has a full output bin. ";
            }
            if (pq.IsPaperJammed)
            {
                statusReport = statusReport + "Has a paper jam. ";
            }
            if (pq.IsPaused)
            {
                statusReport = statusReport + "Is paused. ";
            }
            if (pq.IsTonerLow)
            {
                statusReport = statusReport + "Is low on toner. ";
            }
            if (pq.NeedUserIntervention)
            {
                statusReport = statusReport + "Needs user intervention. ";
            }

            // Check if queue is even available at this time of day
            // The following method is defined in the complete example.
            ReportAvailabilityAtThisTime(ref statusReport, pq);

        }//end SpotTroubleUsingProperties
        // </SnippetSpotTroubleUsingQueueProperties>

        // <SnippetSpotTroubleUsingQueueAttributes>
        // Check for possible trouble states of a printer using the flags of the QueueStatus property
        internal static void SpotTroubleUsingQueueAttributes(ref String statusReport, PrintQueue pq)
        {
            if ((pq.QueueStatus & PrintQueueStatus.PaperProblem) == PrintQueueStatus.PaperProblem)
            {
                statusReport = statusReport + "Has a paper problem. ";
            }
            if ((pq.QueueStatus & PrintQueueStatus.NoToner) == PrintQueueStatus.NoToner)
            {
                statusReport = statusReport + "Is out of toner. ";
            }
            if ((pq.QueueStatus & PrintQueueStatus.DoorOpen) == PrintQueueStatus.DoorOpen)
            {
                statusReport = statusReport + "Has an open door. ";
            }
            if ((pq.QueueStatus & PrintQueueStatus.Error) == PrintQueueStatus.Error)
            {
                statusReport = statusReport + "Is in an error state. ";
            }
            if ((pq.QueueStatus & PrintQueueStatus.NotAvailable) == PrintQueueStatus.NotAvailable)
            {
                statusReport = statusReport + "Is not available. ";
            }
            if ((pq.QueueStatus & PrintQueueStatus.Offline) == PrintQueueStatus.Offline)
            {
                statusReport = statusReport + "Is off line. ";
            }
            if ((pq.QueueStatus & PrintQueueStatus.OutOfMemory) == PrintQueueStatus.OutOfMemory)
            {
                statusReport = statusReport + "Is out of memory. ";
            }
            if ((pq.QueueStatus & PrintQueueStatus.PaperOut) == PrintQueueStatus.PaperOut)
            {
                statusReport = statusReport + "Is out of paper. ";
            }
            if ((pq.QueueStatus & PrintQueueStatus.OutputBinFull) == PrintQueueStatus.OutputBinFull)
            {
                statusReport = statusReport + "Has a full output bin. ";
            }
            if ((pq.QueueStatus & PrintQueueStatus.PaperJam) == PrintQueueStatus.PaperJam)
            {
                statusReport = statusReport + "Has a paper jam. ";
            }
            if ((pq.QueueStatus & PrintQueueStatus.Paused) == PrintQueueStatus.Paused)
            {
                statusReport = statusReport + "Is paused. ";
            }
            if ((pq.QueueStatus & PrintQueueStatus.TonerLow) == PrintQueueStatus.TonerLow)
            {
                statusReport = statusReport + "Is low on toner. ";
            }
            if ((pq.QueueStatus & PrintQueueStatus.UserIntervention) == PrintQueueStatus.UserIntervention)
            {
                statusReport = statusReport + "Needs user intervention. ";
            }

            // Check if queue is even available at this time of day
            // The method below is defined in the complete example.
            ReportAvailabilityAtThisTime(ref statusReport, pq);
        }
        // </SnippetSpotTroubleUsingQueueAttributes>

        // <SnippetUsingStartAndUntilTimes>
        private static void ReportAvailabilityAtThisTime(ref String statusReport, PrintQueue pq)
        {
            if (pq.StartTimeOfDay != pq.UntilTimeOfDay) // If the printer is not available 24 hours a day
            {
		DateTime utcNow = DateTime.UtcNow;
		Int32 utcNowAsMinutesAfterMidnight = (utcNow.TimeOfDay.Hours * 60) + utcNow.TimeOfDay.Minutes;
                
                // If now is not within the range of available times . . .
                if (!((pq.StartTimeOfDay < utcNowAsMinutesAfterMidnight) 
                   &&
                   (utcNowAsMinutesAfterMidnight < pq.UntilTimeOfDay)))
                {
                    statusReport = statusReport + " Is not available at this time of day. ";
                }
            }
        }
        // </SnippetUsingStartAndUntilTimes>

    }// end TroubleSpotter class

}//end namespace
