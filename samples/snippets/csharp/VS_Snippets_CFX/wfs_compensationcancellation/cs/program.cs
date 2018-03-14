//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using Parallel = System.Activities.Statements.Parallel;

namespace Microsoft.Samples.Compensation.CancellationSample
{

    class Program
    {
        static void Main()
        {
            // Executing with cancellation where the order of process is changed. This scenario is intended to
            // demonstrate how cancellation works when the cause of the cancellation is an exception in the body of a compensable activity. 
            Console.WriteLine("************ Scenario 1 - Execution with Cancellation changing order ************");
            new WorkflowInvoker(ExceptionCausingCustomCancellation()).Invoke();

            // Executing with cancellation where the first branch timeout before the rest of the other branch 
            // completes. This scenario is intended to demonstrate how cancellation works if the activity is cancelled from an external source.
            Console.WriteLine("************ Scenario 2 - Execution with Cancellation with Delay ************");
            new WorkflowInvoker(CancellingActivityInvokesCustomCancellation()).Invoke();

            Console.WriteLine();
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }

        static Activity ExceptionCausingCustomCancellation()
        {
            // Declaring a set of tokens that can be used to refer to a particular unit of compensable work
            Variable<CompensationToken> tokenA = new Variable<CompensationToken>
            {
                Name = "Token A",
            };
            Variable<CompensationToken> tokenB = new Variable<CompensationToken>
            {
                Name = "Token B",
            };
            Variable<CompensationToken> tokenC = new Variable<CompensationToken>
            {
                Name = "Token C",
            };

            return new TryCatch
            {
                Try = new Sequence
                {
                    Activities = 
                    {
                        new WriteLine { Text = "Try: Body" },
                        // Root CompensableActivity
                        new CompensableActivity
                        {
                             Variables =
                             {
                                   tokenA,
                                   tokenB,
                                   tokenC
                             },

                            Body = new Sequence
                            {
                                Activities = 
                                {
                                    new WriteLine { Text = "  CompensableActivity1: Body" },

                                    // First CompensableActivity
                                    new CompensableActivity
                                    {
                                        Body = new WriteLine { Text = "    CompensableActivity1.A: Body" },

                                        ConfirmationHandler = new WriteLine { Text = "    CompensableActivity1.A: ConfirmationHandler" },
                                        CompensationHandler = new WriteLine { Text = "    CompensableActivity1.A: CompensationHandler" },
                                        CancellationHandler = new WriteLine { Text = "    CompensableActivity1.A: CancellationHandler" },
                                        Result = tokenA
                                    },

                                    // Second CompensableActivity
                                    new CompensableActivity
                                    {
                                        Body = new WriteLine { Text = "    CompensableActivity1.B: Body" },

                                        ConfirmationHandler = new WriteLine { Text = "    CompensableActivity1.B: ConfirmationHandler" },
                                        CompensationHandler = new WriteLine { Text = "    CompensableActivity1.B: CompensationHandler" },
                                        CancellationHandler = new WriteLine { Text = "    CompensableActivity1.B: CancellationHandler" },
                                        Result = tokenB
                                    },

                                    // Third CompensableActivity
                                    new CompensableActivity
                                    {
                                        Body = new Sequence
                                        {
                                            Activities =
                                            {
                                                new WriteLine { Text = "    CompensableActivity1.C: Body is about to throw an exception " },
                                                new Throw { Exception = new InArgument<Exception>((env) => new ApplicationException(" Something unexpected happened")),},
                                            }
                                        },
                                        ConfirmationHandler = new WriteLine { Text = "    CompensableActivity1.C: ConfirmationHandler" },
                                        CompensationHandler = new WriteLine { Text = "    CompensableActivity1.C: CompensationHandler" },
                                        CancellationHandler = new Sequence
                                        {
                                            Activities = 
                                            {
                                                new WriteLine { Text = "    CompensableActivity1.C: CancellationHandler" },
                                            }
                                        },
                                        Result = tokenC
                                    },

                                  new WriteLine { Text = "  CompensableActivity1: End of Body" }
                                }
                            },
                            CompensationHandler = new WriteLine { Text = "  CompensableActivity1: CompensationHandler" },
                            ConfirmationHandler = new WriteLine { Text = "  CompensableActivity1: ConfirmationHandler" },
                            CancellationHandler = new Sequence
                            {
                                Activities =
                                {
                                    new WriteLine { Text = "  CompensableActivity1: CancellationHandler, using CompensationToken to confirm or compensate completed children" },
                                    new Compensate
                                    {
                                        Target = tokenA
                                    },
                                    new Compensate
                                    {
                                        Target = tokenB
                                    },
                                }
                            },
                        }
                    }
                },

                Catches =
                {
                    new Catch<ApplicationException>
                    {
                        Action = new ActivityAction<ApplicationException>
                        {
                            Handler = new Sequence 
                            {
                                Activities = 
                                {
                                    new WriteLine { Text = "Try: Catch, got exception thrown by CompensableActivity1.C" },
                                }
                            }
                        }
                     }
                }
            };
        }

        static Activity CancellingActivityInvokesCustomCancellation()
        {
//<Snippet1>
            return new Parallel
            {
                // Timeout from branch causes other branch to cancel.
                CompletionCondition = true,

                Branches =
                {
                    // Delay Branch
                    new Sequence
                    {
                        Activities =
                        {
                            new WriteLine { Text = "Branch1: Body is about to Delay 2secs transferring execution to Branch2" },
                            new Delay
                            {
                                Duration = TimeSpan.FromSeconds(2)
                            },
                            new WriteLine { Text = "Branch1: Body is about to complete causing Branch2 to cancel.." },
                        }
                    },
//</Snippet1>
                    new Sequence
                    {
                        Activities =
                        {
                            new WriteLine { Text = "Branch2: Body" },
                            new CompensableActivity
                            {
                                Body = new Sequence()
                                {

                                    Activities =
                                    {
                                       new WriteLine { Text = "  CompensableActivity1: Body" },

                                       // First CompensableActivity
                                       new CompensableActivity
                                        {
                                            Body = new WriteLine { Text = "    CompensableActivity1.A: Body" },

                                            ConfirmationHandler = new WriteLine { Text = "    CompensableActivity1.A: ConfirmationHandler" },
                                            CompensationHandler = new WriteLine { Text = "    CompensableActivity1.A: CompensationHandler" },
                                            CancellationHandler = new WriteLine { Text = "    CompensableActivity1.A: CancellationHandler" },
                                        },

                                        // Second CompensableActivity
                                        new CompensableActivity
                                        {
                                            Body = new WriteLine { Text = "    CompensableActivity1.B: Body" },

                                            ConfirmationHandler = new WriteLine { Text = "    CompensableActivity1.B: ConfirmationHandler" },
                                            CompensationHandler = new WriteLine { Text = "    CompensableActivity1.B: CompensationHandler" },
                                            CancellationHandler = new WriteLine { Text = "    CompensableActivity1.B: CancellationHandler" },
                                        },

                                        // Third CompensableActivity
                                        new CompensableActivity
                                        {
                                            Body = new Sequence {
                                                Activities = {
                                                    new WriteLine { Text = "    CompensableActivity1.C: Body is about to Delay 3secs transferring execution to Branch1" },
                                                    new Delay
                                                    {
                                                        Duration = TimeSpan.FromSeconds(3)
                                                    },
                                                    new WriteLine { Text = "    CompensableActivity1.C: Body, this activity is never executed" },
                                                }
                                            },

                                            ConfirmationHandler = new WriteLine { Text = "    CompensableActivity1.C: ConfirmationHandler" },
                                            CompensationHandler = new WriteLine { Text = "    CompensableActivity1.C: CompensationHandler" },
                                            CancellationHandler = new WriteLine { Text = "    CompensableActivity1.C: CancellationHandler" },
                                        },
                                    }
                                },
                                CompensationHandler = new WriteLine { Text = "  CompensableActivity1: CompensationHandler" },
                                ConfirmationHandler = new WriteLine { Text = "  CompensableActivity1: ConfirmationHandler" },
                                CancellationHandler = new WriteLine { Text = "  CompensableActivity1: CancellationHandler, default is to confirm completed children" },
                            }
                        }
                    }
                }
            };
        }
    }
}
