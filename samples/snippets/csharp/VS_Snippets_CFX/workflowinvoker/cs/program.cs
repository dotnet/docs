//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Collections.Generic;

namespace Microsoft.Samples.WorkflowModel
{

    class Program
    {
        static void Main(string[] args)
        {
            int x = 1, y = 2;

            Console.WriteLine("Invoking Add");

            int result = WorkflowInvoker.Invoke(new Add(), new Dictionary<string, object> { { "X", x }, { "Y", y } });

            Console.WriteLine("{0} + {1} = {2}", x, y, result);
            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
        }
    }
}
