// System::Diagnostics::Process::Refresh
// System::Diagnostics::Process::HasExited
// System::Diagnostics::Process::Close
// System::Diagnostics::Process::CloseMainWindow

// The following example starts an instance of Notepad. It then
// retrieves the physical memory usage of the associated process at
// 2 second intervals for a maximum of 10 seconds.  The example detects
// whether the process exits before 10 seconds have elapsed.  
// The example closes the process if it is still running after
// 10 seconds.

// <Snippet1>

using System;
using System.Diagnostics;
using System.Threading;

namespace Process_Sample
{
   class MyProcessClass
   {
      public static void Main()
      {
         try
         {
            Process myProcess;
            myProcess = Process.Start("Notepad.exe");
            // Display physical memory usage 5 times at intervals of 2 seconds.
            for (int i = 0;i < 5; i++)
            {
               if (!myProcess.HasExited)
               {
                   // Discard cached information about the process.
                   myProcess.Refresh();
                   // Print working set to console.
                   Console.WriteLine("Physical Memory Usage: " 
                                        + myProcess.WorkingSet.ToString());
                   // Wait 2 seconds.
                   Thread.Sleep(2000);
               }
               else {
                   break;
               } 
            }

            // Close process by sending a close message to its main window.
            myProcess.CloseMainWindow();
            // Free resources associated with process.
            myProcess.Close();

         }
         catch(Exception e)
         {
            Console.WriteLine("The following exception was raised: ");
            Console.WriteLine(e.Message);
         }
      }
   }
}
// </Snippet1>