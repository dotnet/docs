//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Activities;
using System.Threading;

namespace Microsoft.Samples.Activities.Statements
{

    class Program
    {
        static void Main(string[] args)
        {
            AutoResetEvent syncEvent = new AutoResetEvent(false);
            
            // create the workflow app and add handlers for the Idle and Completed actions
            WorkflowApplication app = new WorkflowApplication(new Sequence1());
            app.Idle = delegate(WorkflowApplicationIdleEventArgs e)
            {
                syncEvent.Set();
            };
            app.Completed = delegate(WorkflowApplicationCompletedEventArgs e)
            {
                syncEvent.Set();
            };

            // start the application
            app.Run();
            syncEvent.WaitOne();

            // read some text from the console and resume the readText bookmark (created in the first WaitForInput activity)
            string text = Console.ReadLine();
            app.ResumeBookmark("readText", text);
            syncEvent.WaitOne();

            // read some text from the console, convert it to number, and resume the readNumber bookmark (created in the second WaitForInput activity)
            int number = ReadNumberFromConsole();
            app.ResumeBookmark("readNumber", number);
            syncEvent.WaitOne();
            
            Console.WriteLine("");
            Console.WriteLine("Press [ENTER] to exit...");
            Console.ReadLine();
        }
        
        static int ReadNumberFromConsole()
        {
            bool finished = false;
            int number = 0;

            while (!finished)
            {
                try
                {
                    number = int.Parse(Console.ReadLine());
                    finished = true;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid Input - Please enter a number...");
                }
            }
            return number;
        }
        
    } 
}
