using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.Threading;

namespace WorkflowConsoleApplication1
{
    class ExtraSnippets
    {
        Activity _wf = new DynamicActivity();

        void Snippet2()
        {

            //<snippet2>
            WorkflowInvoker.Invoke(_wf);
            //</snippet2>
        }

        void Snippet4()
        {
            //<snippet4>
            AutoResetEvent syncEvent = new AutoResetEvent(false);

            WorkflowApplication wfApp =
                new WorkflowApplication(_wf);

            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                syncEvent.Set();
            };

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

            wfApp.Run();

            //<snippet10>
            syncEvent.WaitOne();
            //</snippet10>
            //</snippet4>
        }

        void Step4Snippets()
        {
            AutoResetEvent idleEvent = new(false);

            const string connectionString = "...";

            var inputs = new Dictionary<string, object>() { { "MaxNumber", 100 } };

            //<snippet15>
            WorkflowApplication wfApp =
                new WorkflowApplication(_wf, inputs);

            SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(connectionString);
            wfApp.InstanceStore = store;
            //</snippet15>

            //<snippet16>
            // Replace the Idle handler with a PersistableIdle handler.
            //wfApp.Idle = delegate(WorkflowApplicationIdleEventArgs e)
            //{
            //    idleEvent.Set();
            //};

            wfApp.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                idleEvent.Set();
                return PersistableIdleAction.Persist;
            };
            //</snippet16>

            //<snippet17>
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
            //</snippet17>
        }
    }
}
