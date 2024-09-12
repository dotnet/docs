using System;
using System.Activities;
using System.Collections.Generic;
using System.Threading;

namespace WorkflowConsoleApplication1
{
    class Program
    {
        static Activity _wf = new DynamicActivity();

        //<snippet12>
        static void Main(string[] args)
        {
            AutoResetEvent syncEvent = new AutoResetEvent(false);
            //<snippet8>
            AutoResetEvent idleEvent = new AutoResetEvent(false);
            //</snippet8>

            //<snippet6>
            var inputs = new Dictionary<string, object>() { { "MaxNumber", 100 } };

            WorkflowApplication wfApp = new(_wf, inputs)
            {
                //</snippet6>

                //<snippet7>
                Completed = delegate (WorkflowApplicationCompletedEventArgs e)
                {
                    int Turns = Convert.ToInt32(e.Outputs["Turns"]);
                    Console.WriteLine("Congratulations, you guessed the number in {0} turns.", Turns);

                    syncEvent.Set();
                },
                //</snippet7>

                Aborted = delegate (WorkflowApplicationAbortedEventArgs e)
                {
                    Console.WriteLine(e.Reason);
                    syncEvent.Set();
                },

                OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs e)
                {
                    Console.WriteLine(e.UnhandledException.ToString());
                    return UnhandledExceptionAction.Terminate;
                },

                //<snippet9>
                Idle = delegate (WorkflowApplicationIdleEventArgs e)
                {
                    idleEvent.Set();
                }
            };
            //</snippet9>

            wfApp.Run();

            //<snippet11>
            // Loop until the workflow completes.
            WaitHandle[] handles = new WaitHandle[] { syncEvent, idleEvent };
            while (WaitHandle.WaitAny(handles) != 0)
            {
                // Gather the user input and resume the bookmark.
                bool validEntry = false;
                while (!validEntry)
                {
                    if (!Int32.TryParse(Console.ReadLine(), out int Guess))
                    {
                        Console.WriteLine("Please enter an integer.");
                    }
                    else
                    {
                        validEntry = true;
                        wfApp.ResumeBookmark("EnterGuess", Guess);
                    }
                }
            }
            //</snippet11>
        }
        //</snippet12>
    }
}
