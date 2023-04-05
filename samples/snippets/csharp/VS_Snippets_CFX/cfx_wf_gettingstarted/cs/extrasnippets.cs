using System;
using System.Activities;
//<snippet14>
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.Threading;
//</snippet14>
namespace WorkflowConsoleApplication1
{
    class ExtraSnippets
    {
        void Snippet2()
        {
            //<snippet2>
            WorkflowInvoker.Invoke(new Workflow1());
            //</snippet2>
        }

        void Snippet4()
        {

            //<snippet4>
            AutoResetEvent syncEvent = new AutoResetEvent(false);

            WorkflowApplication wfApp =
                new WorkflowApplication(new Workflow1());

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
            AutoResetEvent idleEvent = new AutoResetEvent(false);

            //<snippet13>
            const string connectionString = "Server=.\\SQLEXPRESS;Initial Catalog=Persistence;Integrated Security=SSPI";
            //</snippet13>

            var inputs = new Dictionary<string, object>() { { "MaxNumber", 100 } };

            //<snippet15>
            WorkflowApplication wfApp =
                new WorkflowApplication(new Workflow1(), inputs);

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
