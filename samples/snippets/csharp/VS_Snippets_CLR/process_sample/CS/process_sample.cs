// System.Diagnostics.Process.WorkingSet
// System.Diagnostics.Process.BasePriority
// System.Diagnostics.Process.UserProcessorTime
// System.Diagnostics.Process.PrivilegedProcessorTime
// System.Diagnostics.Process.TotalProcessorTime
// System.Diagnostics.Process.ToString
// System.Diagnostics.Process.Responding
// System.Diagnostics.Process.PriorityClass
// System.Diagnostics.Process.ExitCode

// The following example starts an instance of Notepad. The example 
// then retrieves and displays various properties of the associated
// process.  The example detects when the process exits, and displays the process's exit code.

// <Snippet1>
using System;
using System.Diagnostics;
using System.Threading;

namespace ProcessSample
{
    class MyProcessClass
    {
        public static void Main()
        {
            try
            {
                using (Process myProcess = Process.Start("NotePad.exe"))
                {
                    while (!myProcess.HasExited)
                    {
                        Console.WriteLine();

                        Console.WriteLine($"Physical memory usage     : {myProcess.WorkingSet}");
                        Console.WriteLine($"Base priority             : {myProcess.BasePriority}");
                        Console.WriteLine($"Priority class            : {myProcess.PriorityClass}");
                        Console.WriteLine($"User processor time       : {myProcess.UserProcessorTime}");
                        Console.WriteLine($"Privileged processor time : {myProcess.PrivilegedProcessorTime}");
                        Console.WriteLine($"Total processor time      : {myProcess.TotalProcessorTime}");
                        Console.WriteLine($"Process's Name            : {myProcess}");
                        Console.WriteLine("-------------------------------------");

                        if (myProcess.Responding)
                        {
                            Console.WriteLine("Status:  Responding to user interface");
                            myProcess.Refresh();
                        }
                        else
                        {
                            Console.WriteLine("Status:  Not Responding");
                        }

                        Thread.Sleep(1000);
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Process exit code: {myProcess.ExitCode}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The following exception was raised: {e.Message}");
            }
        }
    }
}
// </Snippet1>
