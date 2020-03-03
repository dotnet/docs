//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System;
using System.Activities;

namespace Microsoft.Samples.WorkflowModel
{

    class Program
    {
        static void Main()
        {
            FileWriter writer = new FileWriter();
            WorkflowInvoker.Invoke(writer);

            Console.WriteLine("Hit <enter> to exit...");
            Console.ReadLine();
        }
    }
}
