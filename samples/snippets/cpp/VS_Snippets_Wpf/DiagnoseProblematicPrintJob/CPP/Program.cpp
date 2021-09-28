//Program.cpp file
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Text;
using namespace System::Printing;
using namespace System::IO;

namespace DiagnoseProblematicPrintJob {

   //<SnippetTimeConverter>
   private ref class TimeConverter {

   internal: 
      static DateTime ConvertToLocalHumanReadableTime (Int32 timeInMinutesAfterUTCMidnight) 
      {
         // Construct a UTC midnight object.
         // Must start with current date so that the local Daylight Savings system, if any, will be taken into account.
         DateTime utcNow = DateTime::UtcNow;
         DateTime utcMidnight = DateTime(utcNow.Year, utcNow.Month, utcNow.Day, 0, 0, 0, DateTimeKind::Utc);

         // Add the minutes passed into the method in order to get the intended UTC time.
         Double minutesAfterUTCMidnight = ((Double)timeInMinutesAfterUTCMidnight);
         DateTime utcTime = utcMidnight.AddMinutes(minutesAfterUTCMidnight);

         // Convert to local time.
         DateTime localTime = utcTime.ToLocalTime();

         return localTime;
      };
   };
   //</SnippetTimeConverter>

   private ref class TroubleSpotter {

   internal: 
      // <SnippetSpotTroubleUsingJobProperties>
      // Check for possible trouble states of a print job using its properties
      static void SpotTroubleUsingProperties (PrintSystemJobInfo^ theJob) 
      {
         if (theJob->IsBlocked)
         {
            Console::WriteLine("The job is blocked.");
         }
         if (theJob->IsCompleted || theJob->IsPrinted)
         {
            Console::WriteLine("The job has finished. Have user recheck all output bins and be sure the correct printer is being checked.");
         }
         if (theJob->IsDeleted || theJob->IsDeleting)
         {
            Console::WriteLine("The user or someone with administration rights to the queue has deleted the job. It must be resubmitted.");
         }
         if (theJob->IsInError)
         {
            Console::WriteLine("The job has errored.");
         }
         if (theJob->IsOffline)
         {
            Console::WriteLine("The printer is offline. Have user put it online with printer front panel.");
         }
         if (theJob->IsPaperOut)
         {
            Console::WriteLine("The printer is out of paper of the size required by the job. Have user add paper.");
         }

         if (theJob->IsPaused || theJob->HostingPrintQueue->IsPaused)
         {
            HandlePausedJob(theJob);
            //HandlePausedJob is defined in the complete example.
         }

         if (theJob->IsPrinting)
         {
            Console::WriteLine("The job is printing now.");
         }
         if (theJob->IsSpooling)
         {
            Console::WriteLine("The job is spooling now.");
         }
         if (theJob->IsUserInterventionRequired)
         {
            Console::WriteLine("The printer needs human intervention.");
         }
      };
      // </SnippetSpotTroubleUsingJobProperties>

      // <SnippetSpotTroubleUsingJobAttributes>
      // Check for possible trouble states of a print job using the flags of the JobStatus property
      static void SpotTroubleUsingJobAttributes (PrintSystemJobInfo^ theJob) 
      {
         if ((theJob->JobStatus & PrintJobStatus::Blocked) == PrintJobStatus::Blocked)
         {
            Console::WriteLine("The job is blocked.");
         }
         if (((theJob->JobStatus & PrintJobStatus::Completed) == PrintJobStatus::Completed)
            || 
            ((theJob->JobStatus & PrintJobStatus::Printed) == PrintJobStatus::Printed))
         {
            Console::WriteLine("The job has finished. Have user recheck all output bins and be sure the correct printer is being checked.");
         }
         if (((theJob->JobStatus & PrintJobStatus::Deleted) == PrintJobStatus::Deleted)
            || 
            ((theJob->JobStatus & PrintJobStatus::Deleting) == PrintJobStatus::Deleting))
         {
            Console::WriteLine("The user or someone with administration rights to the queue has deleted the job. It must be resubmitted.");
         }
         if ((theJob->JobStatus & PrintJobStatus::Error) == PrintJobStatus::Error)
         {
            Console::WriteLine("The job has errored.");
         }
         if ((theJob->JobStatus & PrintJobStatus::Offline) == PrintJobStatus::Offline)
         {
            Console::WriteLine("The printer is offline. Have user put it online with printer front panel.");
         }
         if ((theJob->JobStatus & PrintJobStatus::PaperOut) == PrintJobStatus::PaperOut)
         {
            Console::WriteLine("The printer is out of paper of the size required by the job. Have user add paper.");
         }
         if (((theJob->JobStatus & PrintJobStatus::Paused) == PrintJobStatus::Paused)
            || 
            ((theJob->HostingPrintQueue->QueueStatus & PrintQueueStatus::Paused) == PrintQueueStatus::Paused))
         {
            HandlePausedJob(theJob);
            //HandlePausedJob is defined in the complete example.
         }

         if ((theJob->JobStatus & PrintJobStatus::Printing) == PrintJobStatus::Printing)
         {
            Console::WriteLine("The job is printing now.");
         }
         if ((theJob->JobStatus & PrintJobStatus::Spooling) == PrintJobStatus::Spooling)
         {
            Console::WriteLine("The job is spooling now.");
         }
         if ((theJob->JobStatus & PrintJobStatus::UserIntervention) == PrintJobStatus::UserIntervention)
         {
            Console::WriteLine("The printer needs human intervention.");
         }
      };
      // </SnippetSpotTroubleUsingJobAttributes>

      //<SnippetHandlePausedJob>
      static void HandlePausedJob (PrintSystemJobInfo^ theJob) 
      {
         // If there's no good reason for the queue to be paused, resume it and 
         // give user choice to resume or cancel the job.
         Console::WriteLine("The user or someone with administrative rights to the queue" + "\nhas paused the job or queue." + "\nResume the queue? (Has no effect if queue is not paused.)" + "\nEnter \"Y\" to resume, otherwise press return: ");
         String^ resume = Console::ReadLine();
         if (resume == "Y")
         {
            theJob->HostingPrintQueue->Resume();

            // It is possible the job is also paused. Find out how the user wants to handle that.
            Console::WriteLine("Does user want to resume print job or cancel it?" + "\nEnter \"Y\" to resume (any other key cancels the print job): ");
            String^ userDecision = Console::ReadLine();
            if (userDecision == "Y")
            {
               theJob->Resume();
            } else
            {
               theJob->Cancel();
            }
         }
      };
      //</SnippetHandlePausedJob>

      //<SnippetReportQueueAndJobAvailability>
      static void ReportQueueAndJobAvailability (PrintSystemJobInfo^ theJob) 
      {
         if (!(ReportAvailabilityAtThisTime(theJob->HostingPrintQueue) && ReportAvailabilityAtThisTime(theJob)))
         {
            if (!ReportAvailabilityAtThisTime(theJob->HostingPrintQueue))
            {
               Console::WriteLine("\nThat queue is not available at this time of day." + "\nJobs in the queue will start printing again at {0}", TimeConverter::ConvertToLocalHumanReadableTime(theJob->HostingPrintQueue->StartTimeOfDay).ToShortTimeString());
               // TimeConverter class is defined in the complete sample
            }
            if (!ReportAvailabilityAtThisTime(theJob))
            {
               Console::WriteLine("\nThat job is set to print only between {0} and {1}", TimeConverter::ConvertToLocalHumanReadableTime(theJob->StartTimeOfDay).ToShortTimeString(), TimeConverter::ConvertToLocalHumanReadableTime(theJob->UntilTimeOfDay).ToShortTimeString());
            }
            Console::WriteLine("\nThe job will begin printing as soon as it reaches the top of the queue after:");
            if (theJob->StartTimeOfDay > theJob->HostingPrintQueue->StartTimeOfDay)
            {
               Console::WriteLine(TimeConverter::ConvertToLocalHumanReadableTime(theJob->StartTimeOfDay).ToShortTimeString());
            } else
            {
               Console::WriteLine(TimeConverter::ConvertToLocalHumanReadableTime(theJob->HostingPrintQueue->StartTimeOfDay).ToShortTimeString());
            }

         }
      };
      //</SnippetReportQueueAndJobAvailability>


      //<SnippetPrintQueueStartUntil>
      static Boolean ReportAvailabilityAtThisTime (PrintQueue^ pq) 
      {
         Boolean available = true;
         if (pq->StartTimeOfDay != pq->UntilTimeOfDay)
         {
            DateTime utcNow = DateTime::UtcNow;
            Int32 utcNowAsMinutesAfterMidnight = (utcNow.TimeOfDay.Hours * 60) + utcNow.TimeOfDay.Minutes;

            // If now is not within the range of available times . . .
            if (!((pq->StartTimeOfDay < utcNowAsMinutesAfterMidnight) && (utcNowAsMinutesAfterMidnight < pq->UntilTimeOfDay)))
            {
               available = false;
            }
         }
         return available;
      };
      //</SnippetPrintQueueStartUntil>


      // <SnippetUsingJobStartAndUntilTimes>
      static Boolean ReportAvailabilityAtThisTime (PrintSystemJobInfo^ theJob) 
      {
         Boolean available = true;
         if (theJob->StartTimeOfDay != theJob->UntilTimeOfDay)
         {
            DateTime utcNow = DateTime::UtcNow;
            Int32 utcNowAsMinutesAfterMidnight = (utcNow.TimeOfDay.Hours * 60) + utcNow.TimeOfDay.Minutes;

            // If "now" is not within the range of available times . . .
            if (!((theJob->StartTimeOfDay < utcNowAsMinutesAfterMidnight) && (utcNowAsMinutesAfterMidnight < theJob->UntilTimeOfDay)))
            {
               available = false;
            }
         }
         return available;
      }
      // </SnippetUsingJobStartAndUntilTimes>

   };


   private ref class Program {

   public: 
      static void Main (array<String^>^ args) 
      {
         // Obtain a list of print servers.
         Console::Write("Enter path and file name of CRLF-delimited list of print servers" + "\n(press Return for default \"C:\\PrintServers.txt\"): ");
         String^ pathToListOfPrintServers = Console::ReadLine();
         if (pathToListOfPrintServers == "")
         {
            pathToListOfPrintServers = "C:\\PrintServers.txt";
         }
         StreamReader^ fileOfPrintServers = gcnew StreamReader(pathToListOfPrintServers);

         // Obtain the username of the person with the problematic print job.
         Console::Write("\nEnter username of person that submitted print job" + "\n(press Return for the current user {0}: ", Environment::UserName);
         String^ userName = Console::ReadLine();
         if (userName == "")
         {
            userName = Environment::UserName;
         }

         // Prompt user to determine the method that will be used to read the queue status.
         Console::Write("\nEnter \"Y\" to check the problematic job using its JobStatus attributes." + "\nOtherwise, press Return and the job will be checked using its specific properties: ");
         String^ useAttributesResponse = Console::ReadLine();

         // Create list of all jobs submitted by user.
         String^ line;
         Boolean atLeastOne = false;
         String^ jobList = "\n\nAll print jobs submitted by the user are listed here:\n\n";
         while ((line = fileOfPrintServers->ReadLine()) != nullptr)
         {
            PrintServer^ myPS = gcnew PrintServer(line, PrintSystemDesiredAccess::AdministrateServer);
            PrintQueueCollection^ myPrintQueues = myPS->GetPrintQueues();

            //<SnippetEnumerateJobsInQueues>
            for each (PrintQueue^ pq in myPrintQueues)
            {
               pq->Refresh();
               PrintJobInfoCollection^ jobs = pq->GetPrintJobInfoCollection();
               for each (PrintSystemJobInfo^ job in jobs)
               {
                  // Since the user may not be able to articulate which job is problematic,
                  // present information about each job the user has submitted.
                  if (job->Submitter == userName)
                  {
                     atLeastOne = true;
                     jobList = jobList + "\nServer:" + line;
                     jobList = jobList + "\n\tQueue:" + pq->Name;
                     jobList = jobList + "\n\tLocation:" + pq->Location;
                     jobList = jobList + "\n\t\tJob: " + job->JobName + " ID: " + job->JobIdentifier;
                  }
               }
            }
            //</SnippetEnumerateJobsInQueues>
         }

         fileOfPrintServers->Close();

         if (!atLeastOne)
         {
            jobList = "\n\nNo jobs submitted by " + userName + " were found.\n\n";
            Console::WriteLine(jobList);
         } else
         {
            jobList = jobList + "\n\nIf multiple jobs are listed, use the information provided" + " above and by the user to identify the job needing diagnosis.\n\n";
            Console::WriteLine(jobList);
            //<SnippetIdentifyAndDiagnoseProblematicJob>
            // When the problematic print job has been identified, enter information about it.
            Console::Write("\nEnter the print server hosting the job (including leading slashes \\\\): " + "\n(press Return for the current computer \\\\{0}): ", Environment::MachineName);
            String^ pServer = Console::ReadLine();
            if (pServer == "")
            {
               pServer = "\\\\" + Environment::MachineName;
            }
            Console::Write("\nEnter the print queue hosting the job: ");
            String^ pQueue = Console::ReadLine();
            Console::Write("\nEnter the job ID: ");
            Int16 jobID = Convert::ToInt16(Console::ReadLine());

            // Create objects to represent the server, queue, and print job.
            PrintServer^ hostingServer = gcnew PrintServer(pServer, PrintSystemDesiredAccess::AdministrateServer);
            PrintQueue^ hostingQueue = gcnew PrintQueue(hostingServer, pQueue, PrintSystemDesiredAccess::AdministratePrinter);
            PrintSystemJobInfo^ theJob = hostingQueue->GetJob(jobID);

            if (useAttributesResponse == "Y")
            {
               TroubleSpotter::SpotTroubleUsingJobAttributes(theJob);
               // TroubleSpotter class is defined in the complete example.
            } else
            {
               TroubleSpotter::SpotTroubleUsingProperties(theJob);
            }

            TroubleSpotter::ReportQueueAndJobAvailability(theJob);
            //</SnippetIdentifyAndDiagnoseProblematicJob>           
         }
         Console::WriteLine("\nPress Return to end.");
         Console::ReadLine();
      };
   };

}

//Entry Point:
int main (array<String^>^ args)
{
   DiagnoseProblematicPrintJob::Program::Main(args);
   return 0;
}
