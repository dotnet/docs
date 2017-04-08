//Program.cpp file
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Text;
using namespace System::Printing;
using namespace System::Collections;
using namespace System::IO;

namespace PrinterStatusSurvey {

   private ref class TroubleSpotter {

      // <SnippetSpotTroubleUsingQueueProperties>
   internal: 
      // Check for possible trouble states of a printer using its properties
      static void SpotTroubleUsingProperties (System::String^% statusReport, System::Printing::PrintQueue^ pq) 
      {
         if (pq->HasPaperProblem)
         {
            statusReport = statusReport + "Has a paper problem. ";
         }
         if (!(pq->HasToner))
         {
            statusReport = statusReport + "Is out of toner. ";
         }
         if (pq->IsDoorOpened)
         {
            statusReport = statusReport + "Has an open door. ";
         }
         if (pq->IsInError)
         {
            statusReport = statusReport + "Is in an error state. ";
         }
         if (pq->IsNotAvailable)
         {
            statusReport = statusReport + "Is not available. ";
         }
         if (pq->IsOffline)
         {
            statusReport = statusReport + "Is off line. ";
         }
         if (pq->IsOutOfMemory)
         {
            statusReport = statusReport + "Is out of memory. ";
         }
         if (pq->IsOutOfPaper)
         {
            statusReport = statusReport + "Is out of paper. ";
         }
         if (pq->IsOutputBinFull)
         {
            statusReport = statusReport + "Has a full output bin. ";
         }
         if (pq->IsPaperJammed)
         {
            statusReport = statusReport + "Has a paper jam. ";
         }
         if (pq->IsPaused)
         {
            statusReport = statusReport + "Is paused. ";
         }
         if (pq->IsTonerLow)
         {
            statusReport = statusReport + "Is low on toner. ";
         }
         if (pq->NeedUserIntervention)
         {
            statusReport = statusReport + "Needs user intervention. ";
         }

         // Check if queue is even available at this time of day
         // The following method is defined in the complete example.
         ReportAvailabilityAtThisTime(statusReport, pq);
      };
      // </SnippetSpotTroubleUsingQueueProperties>

      // <SnippetSpotTroubleUsingQueueAttributes>
   internal: 
      // Check for possible trouble states of a printer using the flags of the QueueStatus property
      static void SpotTroubleUsingQueueAttributes (System::String^% statusReport, System::Printing::PrintQueue^ pq) 
      {
         if ((pq->QueueStatus & PrintQueueStatus::PaperProblem) == PrintQueueStatus::PaperProblem)
         {
            statusReport = statusReport + "Has a paper problem. ";
         }
         if ((pq->QueueStatus & PrintQueueStatus::NoToner) == PrintQueueStatus::NoToner)
         {
            statusReport = statusReport + "Is out of toner. ";
         }
         if ((pq->QueueStatus & PrintQueueStatus::DoorOpen) == PrintQueueStatus::DoorOpen)
         {
            statusReport = statusReport + "Has an open door. ";
         }
         if ((pq->QueueStatus & PrintQueueStatus::Error) == PrintQueueStatus::Error)
         {
            statusReport = statusReport + "Is in an error state. ";
         }
         if ((pq->QueueStatus & PrintQueueStatus::NotAvailable) == PrintQueueStatus::NotAvailable)
         {
            statusReport = statusReport + "Is not available. ";
         }
         if ((pq->QueueStatus & PrintQueueStatus::Offline) == PrintQueueStatus::Offline)
         {
            statusReport = statusReport + "Is off line. ";
         }
         if ((pq->QueueStatus & PrintQueueStatus::OutOfMemory) == PrintQueueStatus::OutOfMemory)
         {
            statusReport = statusReport + "Is out of memory. ";
         }
         if ((pq->QueueStatus & PrintQueueStatus::PaperOut) == PrintQueueStatus::PaperOut)
         {
            statusReport = statusReport + "Is out of paper. ";
         }
         if ((pq->QueueStatus & PrintQueueStatus::OutputBinFull) == PrintQueueStatus::OutputBinFull)
         {
            statusReport = statusReport + "Has a full output bin. ";
         }
         if ((pq->QueueStatus & PrintQueueStatus::PaperJam) == PrintQueueStatus::PaperJam)
         {
            statusReport = statusReport + "Has a paper jam. ";
         }
         if ((pq->QueueStatus & PrintQueueStatus::Paused) == PrintQueueStatus::Paused)
         {
            statusReport = statusReport + "Is paused. ";
         }
         if ((pq->QueueStatus & PrintQueueStatus::TonerLow) == PrintQueueStatus::TonerLow)
         {
            statusReport = statusReport + "Is low on toner. ";
         }
         if ((pq->QueueStatus & PrintQueueStatus::UserIntervention) == PrintQueueStatus::UserIntervention)
         {
            statusReport = statusReport + "Needs user intervention. ";
         }

         // Check if queue is even available at this time of day
         // The method below is defined in the complete example.
         ReportAvailabilityAtThisTime(statusReport, pq);
      };
      // </SnippetSpotTroubleUsingQueueAttributes>

      // <SnippetUsingStartAndUntilTimes>
   private: 
      static void ReportAvailabilityAtThisTime (System::String^% statusReport, System::Printing::PrintQueue^ pq) 
      {
         if (pq->StartTimeOfDay != pq->UntilTimeOfDay)
         {
            System::DateTime utcNow = DateTime::UtcNow;
            System::Int32 utcNowAsMinutesAfterMidnight = (utcNow.TimeOfDay.Hours * 60) + utcNow.TimeOfDay.Minutes;

            // If now is not within the range of available times . . .
            if (!((pq->StartTimeOfDay < utcNowAsMinutesAfterMidnight) && (utcNowAsMinutesAfterMidnight < pq->UntilTimeOfDay)))
            {
               statusReport = statusReport + " Is not available at this time of day. ";
            }
         }
      };
      // </SnippetUsingStartAndUntilTimes>
   };

   private ref class Program {

   public: 
      static void Main (array<System::String^>^ args) 
           {
              // Obtain a list of print servers
              Console::Write("Enter path and file name of CRLF-delimited list of print servers: ");
              System::String^ pathToListOfPrintServers = Console::ReadLine();
              System::IO::StreamReader^ fileOfPrintServers = gcnew System::IO::StreamReader(pathToListOfPrintServers);

              // Prompt user to determine the method of reading queue status that will be used
              Console::Write("Enter \"y\" to check queues using their QueueStatus attributes.\nOtherwise, press Return and they will be checked using their specific properties: ");
              System::String^ useAttributesResponse = Console::ReadLine();

              //<SnippetSurveyQueues>
              // Survey queue status for every queue on every print server
              System::String^ line;
              System::String^ statusReport = "\n\nAny problem states are indicated below:\n\n";
              while ((line = fileOfPrintServers->ReadLine()) != nullptr)
              {
                 System::Printing::PrintServer^ myPS = gcnew System::Printing::PrintServer(line, PrintSystemDesiredAccess::AdministrateServer);
                 System::Printing::PrintQueueCollection^ myPrintQueues = myPS->GetPrintQueues();
                 statusReport = statusReport + "\n" + line;
                 for each (System::Printing::PrintQueue^ pq in myPrintQueues)
                 {
                    pq->Refresh();
                    statusReport = statusReport + "\n\t" + pq->Name + ":";
                    if (useAttributesResponse == "y")
                    {
                       TroubleSpotter::SpotTroubleUsingQueueAttributes(statusReport, pq);
                       // TroubleSpotter class is defined in the complete example.
                    } else
                    {
                       TroubleSpotter::SpotTroubleUsingProperties(statusReport, pq);
                    }
                 }
              }
              fileOfPrintServers->Close();
              Console::WriteLine(statusReport);
              Console::WriteLine("\nPress Return to continue.");
              Console::ReadLine();
              //</SnippetSurveyQueues>
           };
   };

}

//Entry Point:
[System::STAThreadAttribute()]
int main (array<System::String^>^ args)
{
   PrinterStatusSurvey::Program::Main(args);
   return 0;
}
