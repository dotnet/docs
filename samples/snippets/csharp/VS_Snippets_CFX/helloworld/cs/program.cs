//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;

namespace Microsoft.Samples.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkflowInvoker.Invoke(CreateWF());

            Console.WriteLine("Press <return> to continue...");
            Console.ReadLine();
        }

        static Activity CreateWF()
        {
            Variable<string> message = new Variable<string>();

            return new Sequence()
            {
                Variables = { message },
                Activities = 
                {
                    new AppendString()
                    {
                        Name = ".NET WF",
                        Result = message
                    },
                    new PrependString()
                    {
                        Name = message,
                        Result = message,
                    },
                    new WriteLine()
                    {
                        Text = message
                    }
                }
            };
        }
    }
}
