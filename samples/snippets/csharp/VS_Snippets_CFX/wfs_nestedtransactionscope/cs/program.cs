//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.Threading;

namespace Microsoft.Samples.NestedTransactionScope
{

    class Program
    {
        static ManualResetEvent syncEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            WorkflowApplication application;

            //Scenario One: This scenario will illustrate the requires semantic of the TransactionScope. The workflow author does not know
            //when using the TransactionScopeTest activity if it contains another TransactionScope. When the TransactionScope in the
            //TransactionScopeTest runs it will detect and use the ambient transaction.
            Console.WriteLine("Scenario One - Successful execution");
            WorkflowInvoker.Invoke(ScenarioOne());

            //Scenario Two: The transaction will timeout after the delay has run for two seconds because the timeout on the inner TransactionScope
            //is set to two seconds. The smallest timeout in scope will be respected.
            Console.WriteLine("\n\nScenario Two - Inner timerout less than outer timerout, inner timeout exceeded");
            application = new WorkflowApplication(ScenarioTwo());
            application.Aborted = Program.OnAborted;
            application.Completed = Program.OnCompleted;
            application.OnUnhandledException = Program.OnUnhandledException;
            application.Run();
            syncEvent.WaitOne();

            //Scenario Two: The transaction will timeout but since the two second timeout of the inner TransactionScope no longer applies 
            //the transaction will timeout at five seconds when the outer TransactionScope timeout is exceded.
            Console.WriteLine("\n\nScenario Three - Inner timeout less than outer timeout, outer timeout exceeded");
            application = new WorkflowApplication(ScenarioThree());
            application.Aborted = Program.OnAborted;
            application.Completed = Program.OnCompleted;
            application.OnUnhandledException = Program.OnUnhandledException;
            syncEvent.Reset();
            application.Run();
            syncEvent.WaitOne();

            //Scenario Four: There will be a runtime exception because there is a mismatch between the AbortInstanceOnTransactionFailure flags
            //are different. If the flag of a nested TransactionScope is explicitly set it must match the flag of the root TransactionScope
            Console.WriteLine("\n\nScenario Four - AbortInstanceOnTransactionFailure are different");
            application = new WorkflowApplication(ScenarioFour());
            application.Aborted = Program.OnAborted;
            application.Completed = Program.OnCompleted;
            application.OnUnhandledException = Program.OnUnhandledException;
            syncEvent.Reset();
            application.Run();
            syncEvent.WaitOne();

            Console.WriteLine("\nPress ENTER to exit");
            Console.ReadLine();
        }

        static Activity ScenarioOne()
        {
            return new Sequence
            {
                Activities =
                {
                    new WriteLine { Text = "    Begin workflow" },
//<Snippet1>
                    new TransactionScope
                    {
                        Body = new Sequence
                        {
                            Activities = 
                            {
                                new WriteLine { Text = "    Begin TransactionScope" },

                                new PrintTransactionId(),
                                
                                new TransactionScopeTest(),

                                new WriteLine { Text = "    End TransactionScope" },
                            },
                        },
                    },
//</Snippet1>

                    new WriteLine { Text = "    End workflow" },
                }
            };
        }

        static Activity ScenarioTwo()
        {
            return new Sequence
            {
                Activities =
                {
                    new WriteLine { Text = "    Begin workflow" },

                    new TransactionScope
                    {
                        Body = new Sequence
                        {
                            Activities = 
                            {
                                new WriteLine { Text = "    Begin TransactionScope" },

                                new PrintTransactionId(),
                                
                                new TransactionScope
                                {
                                    Body = new Delay { Duration = TimeSpan.FromSeconds(5) },
                                    Timeout = TimeSpan.FromSeconds(2),
                                },

                                new WriteLine { Text = "    End TransactionScope" },
                            },
                        },
                        Timeout = TimeSpan.FromSeconds(10),
                    },

                    new WriteLine { Text = "    End workflow" },
                }
            };
        }

        static Activity ScenarioThree()
        {
            return new Sequence
            {
                Activities =
                {
                    new WriteLine { Text = "    Begin workflow" },

                    new TransactionScope
                    {
                        Body = new Sequence
                        {
                            Activities = 
                            {
                                new WriteLine { Text = "    Begin TransactionScope" },

                                new PrintTransactionId(),
                                
                                new TransactionScope
                                {
                                    Body = new WriteLine { Text = "    Inner TransactionScope" },
                                    Timeout = TimeSpan.FromSeconds(2),
                                },

                                new Delay { Duration = TimeSpan.FromSeconds(10) },

                                new WriteLine { Text = "    End TransactionScope" },
                            },
                        },
                        Timeout = TimeSpan.FromSeconds(5),
                    },

                    new WriteLine { Text = "    End workflow" },
                }
            };
        }

        static Activity ScenarioFour()
        {
            return new Sequence
            {
                Activities =
                {
                    new WriteLine { Text = "    Begin workflow" },

                    new TransactionScope
                    {
                        Body = new Sequence
                        {
                            Activities = 
                            {
                                new WriteLine { Text = "    Begin TransactionScope" },

                                new PrintTransactionId(),
                                
                                new TransactionScope
                                {
                                    Body = new WriteLine { Text = "Inner TransactionScope" },
                                    AbortInstanceOnTransactionFailure = true,
                                },

                                new WriteLine { Text = "    End TransactionScope" },
                            },
                        },
                        AbortInstanceOnTransactionFailure = false,
                    },

                    new WriteLine { Text = "    End workflow" },
                }
            };
        }

        static void OnAborted(WorkflowApplicationAbortedEventArgs e)
        {
            Console.WriteLine("Workflow aborted because: " + e.Reason.Message);
            syncEvent.Set();
        }

        static void OnCompleted(WorkflowApplicationCompletedEventArgs e)
        {
            syncEvent.Set();
        }

        static UnhandledExceptionAction OnUnhandledException(WorkflowApplicationUnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Unhandled exception: " + e.UnhandledException.Message);
            syncEvent.Set();
            return UnhandledExceptionAction.Terminate;
        }
    }
}
