using System;
using System.Activities;
//</snippet3>
//<snippet5>
using System.Collections.Generic;
//<snippet3>
using System.Threading;
//</snippet5>

namespace WorkflowConsoleApplication1
{
    class Program
    {
        //<snippet12>
        static void Main(string[] args)
        {
            AutoResetEvent syncEvent = new AutoResetEvent(false);
            //<snippet8>
            AutoResetEvent idleEvent = new AutoResetEvent(false);
            //</snippet8>

            //<snippet6>
            var inputs = new Dictionary<string, object>() { { "MaxNumber", 100 } };

            WorkflowApplication wfApp =
                new WorkflowApplication(new Workflow1(), inputs);
            //</snippet6>

            //<snippet7>
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                int Turns = Convert.ToInt32(e.Outputs["Turns"]);
                Console.WriteLine("Congratulations, you guessed the number in {0} turns.", Turns);

                syncEvent.Set();
            };
            //</snippet7>

            wfApp.Aborted = delegate (WorkflowApplicationAbortedEventArgs e)
            {
                Console.WriteLine(e.Reason);
                syncEvent.Set();
            };

            wfApp.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                Console.WriteLine(e.UnhandledException.ToString());
                return UnhandledExceptionAction.Terminate;
            };

            //<snippet9>
            wfApp.Idle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                idleEvent.Set();
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
                    int Guess;
                    if (!Int32.TryParse(Console.ReadLine(), out Guess))
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
