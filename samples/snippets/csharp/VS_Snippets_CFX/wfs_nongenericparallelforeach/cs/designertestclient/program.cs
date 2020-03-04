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
            WorkflowInvoker.Invoke(new Workflow1());

            Console.WriteLine("");
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }

    public class Helper
    {
        public static void ShowThreadId(string text)
        {
            Console.WriteLine(string.Format("Showing '{0}' in thread: {1}", text, Thread.CurrentThread.ManagedThreadId.ToString()));
            Thread.Sleep(1000);
        }
    }
}
