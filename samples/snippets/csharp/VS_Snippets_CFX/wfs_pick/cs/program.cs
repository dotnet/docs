//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.Threading;

namespace Microsoft.Samples.PickUsage
{
    public class PickSample
    {
        static string bookmarkName = "UserName";
        static WorkflowApplication application;
        
        public static void Main(string[] args)
        {
            application = new WorkflowApplication(CreateWF());

            // Notify when the workflow completes.
            ManualResetEvent completedEvent = new ManualResetEvent(false);
            application.Completed += delegate(WorkflowApplicationCompletedEventArgs e)
            {
                completedEvent.Set();
            };

            // Run the workflow.
            application.Run();

            // Get user input from the console and send it to the workflow instance.
            // This is done in a separate thread in order to not block current execution.
            ThreadPool.QueueUserWorkItem(ReadName);

            // Wait until the workflow completes.
            completedEvent.WaitOne();

            Console.WriteLine("Workflow completed.  Waiting 10 seconds before exiting...");
            Thread.Sleep(10000);
        }

        static void ReadName(object state)
        {
            string text = Console.ReadLine();

            // Resume the Activity that set this bookmark (ReadString).
            application.ResumeBookmark(bookmarkName, text);
        }
//<Snippet1>
        static Activity CreateWF()
        {
            Variable<string> name = new Variable<string>();
            Sequence body = new Sequence
            {
                Variables = { name },
                Activities = 
                {
                    new WriteLine { Text = "What is your name? (You have 5 seconds to answer)" },
                    new Pick
                    {
                       Branches = 
                       {
                           new PickBranch
                            {
                               Trigger = new ReadString
                               {
                                   Result = name,
                                   BookmarkName = bookmarkName
                               },
                               Action = new WriteLine 
                               { 
                                   Text = new InArgument<string>(env => "Hello " + name.Get(env)) 
                               }
                           },
                           new PickBranch
                            {
                               Trigger = new Delay
                               {
                                   Duration = TimeSpan.FromSeconds(5)
                               },
                               Action = new WriteLine
                               {
                                   Text = "Time is up."
                               }
                           }
                       }
                   }
               }
            };

            return body;
        }
//</Snippet1>
    }
}
