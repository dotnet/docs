using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Activities.Expressions;
using System.Activities.Hosting;
using System.Activities.Statements;
using System.Activities.Validation;
using System.Activities.XamlIntegration;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Markup;
using System.Xaml;
using Microsoft.VisualBasic.Activities;

// Snippets
// 1 WorkflowApplicationUnhandledExceptionEventArgs
// 2 IdleEventArgs
// 3  WorkflowCompleteEventArgs
// 4 WorkflowApplicationCompletedEventArgs
// 5 WorkflowApplicationAbortedEventArgs
// 6, 7, 8 - UnhandledExceptionAction
// 9 WorkflowApplication
// 10 ctor with args and Using WorkflowInvoker and WorkflowApplication
// 11 Abort
// 12 Abort with reason
// 13 Cancel
// 14 GetBookmarks
// 15 ReadLine activity
// 16, 17, 18, 19 Terminate
// 20 - Unload
// 21 ctor no args
// 22, 23, 24, 25 ResumeBookmark
// 26 - PersistableIdle
// 27 - Load
// 28 - Id property
// 29 - InstanceStore
// 30 - Input Arguments (Using WorkflowInvoker and WorkflowApplication)
// 31 - Simple WriteLine (Using Workflow Invoker and WorkflowApplication)
// 32 - WF LifeCycle events (Using WorkflowInvoker and WorkflowApplication)
// 33 - TryCatch (Exceptions)
// 34 - Persist
// 35 - 40 Cancel
// 41 - 44 Serializing Workflows to and from XAML
// 45 - 46 Activity Tree Inspection
// 47 - 55 Authoring Workflows using Imperative Code
// 56 - Getting the type of arguments for Serializing Workflows to and from XAML
// 57 - 61 Literal Expressions in a workflow
// 62 - 64 Activity example from Authoring Workflows Using Imperative Code
// 65 -    InvokeMethod and Expressions to call methods on an object
// Activity class snippets copied from WorkflowInvokerExample
// 120 Divide
// 130 DiceRoll (also used by Using WFInvoker and WFApp)

// From other projects
// 1000 - ReadInt from GettingStarted

namespace WorkflowApplicationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //WorkflowInvoker.Invoke(new Workflow1());

            //snippet13_6();

            //snippet41();
            //ActivityTreeInspection();

            //snippet47();
            //snippet48();
            //snippet49();
            //snippet50();
            //snippet51();

            snippet51();
            //snippet59();
            //snippet63();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            Console.WriteLine("Waiting...");
            Console.ReadKey();
        }

        private static void RunWorkflow(Activity wf)
        {
            AutoResetEvent syncEvent = new AutoResetEvent(false);

            //Activity wf = new WriteLine()
            //{
            //    Text = "Hello World!"
            //};

            // Create the WorkflowApplication using the desired
            // workflow definition.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Handle the desired lifecycle events.
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"""
                    Exception: {e.TerminationException.GetType().FullName}
                    {e.TerminationException.Message}
                    """);
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");

                    // Retrieve the outputs of the workflow.
                    foreach (var kvp in e.Outputs)
                    {
                        Console.WriteLine($"Name: {kvp.Key} - Value {kvp.Value}");
                    }

                    // Outputs can be directly accessed by argument name.
                    Console.WriteLine($"The winner is {e.Outputs["Winner"]}.");
                }
                syncEvent.Set();
            };

            wfApp.Unloaded = delegate (WorkflowApplicationEventArgs e)
            {
                Console.WriteLine($"Workflow {e.InstanceId} unloaded.");
            };

            wfApp.Aborted = delegate (WorkflowApplicationAbortedEventArgs e)
            {
                // Display the exception that caused the workflow
                // to abort.
                Console.WriteLine($"OnAborted: {e.Reason.Message}");
            };

            wfApp.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                // Display the unhandled exception.
                Console.WriteLine($"OnUnhandledException in Workflow {e.InstanceId}: {e.UnhandledException.Message}");

                Console.WriteLine($"ExceptionSource: {e.ExceptionSource} - {e.ExceptionSourceInstanceId}");

                // Instruct the runtime to terminate the workflow.
                return UnhandledExceptionAction.Terminate;

                // Other choices are UnhandledExceptionAction.Abort and
                // UnhandledExceptionAction.Cancel
            };

            wfApp.Idle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                // Perform any processing that should occur
                // when a workflow goes idle. If the workflow can persist,
                // both Idle and PersistableIdle are called.
            };

            wfApp.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                // Instruct the runtime to persist and unload the workflow
                return PersistableIdleAction.Unload;
            };

            // Start the workflow.
            wfApp.Run();

            // Wait for Completed to arrive and signal that
            // the workflow is complete so the host can resume.
            syncEvent.WaitOne();
        }

        // WorkflowApplicationUnhandledExceptionEventArgs
        // WorkflowApplication.OnUnhandledException
        // Exceptions
        static void snippet1()
        {
            //<snippet1>
            Activity wf = new Sequence
            {
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "Starting the workflow."
                     },
                     new Throw
                    {
                        Exception = new InArgument<Exception>((env) =>
                            new ApplicationException("Something unexpected happened."))
                    },
                    new WriteLine
                     {
                         Text = "Ending the workflow."
                     }
                 }
            };

            WorkflowApplication wfApp = new WorkflowApplication(wf);

            wfApp.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                // Display the unhandled exception.
                Console.WriteLine($"OnUnhandledException in Workflow {e.InstanceId}\n{e.UnhandledException.Message}");

                Console.WriteLine($"ExceptionSource: {e.ExceptionSource.DisplayName} - {e.ExceptionSourceInstanceId}");

                // Instruct the runtime to terminate the workflow.
                return UnhandledExceptionAction.Terminate;

                // Other choices are UnhandledExceptionAction.Abort and
                // UnhandledExceptionAction.Cancel
            };

            wfApp.Run();
            //</snippet1>
        }

        // BookmarkName: EnterGuess - OwnerDisplayName: ReadInt
        // IdleArgs
        // WorkflowApplicationArgs
        // WorkflowApplication.Idle
        static void snippet2()
        {
            // Not a runnable snippet, to get to build
            WorkflowApplication wfApp = new WorkflowApplication(new WriteLine());
            AutoResetEvent idleEvent = new AutoResetEvent(false);
            // End setup

            //<snippet2>
            wfApp.Idle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                foreach (BookmarkInfo info in e.Bookmarks)
                {
                    Console.WriteLine($"BookmarkName: {info.BookmarkName} - OwnerDisplayName: {info.OwnerDisplayName}");
                }

                idleEvent.Set();
            };
            //</snippet2>

            // Output when this code is run with step 3 of the getting started tutorial
            // BookmarkName: EnterGuess - OwnerDisplayName: ReadInt

            // For snippet 3
            // WorkflowApplicationEventArgs
            // WorkflowApplication.Unloaded
            //<snippet3>
            wfApp.Unloaded = delegate (WorkflowApplicationEventArgs e)
            {
                Console.WriteLine($"Workflow {e.InstanceId} unloaded.");
            };
            //</snippet3>

            // WorkflowApplicationCompletedEventArgs
            // WorkflowApplication.Completed
            //<snippet4>
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"""
                    Exception: {e.TerminationException.GetType().FullName}
                    {e.TerminationException.Message}
                    """);
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");

                    // Retrieve the outputs of the workflow.
                    foreach (var kvp in e.Outputs)
                    {
                        Console.WriteLine($"Name: {kvp.Key} - Value {kvp.Value}");
                    }

                    // Outputs can be directly accessed by argument name.
                    Console.WriteLine($"The winner is {e.Outputs["Winner"]}.");
                }
            };
            //</snippet4>

            //<snippet26>
            wfApp.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                // Instruct the runtime to persist and unload the workflow
                return PersistableIdleAction.Unload;
            };
            //</snippet26>
        }

        static void snippet5()
        {
            Console.WriteLine("Snippet5");
            Activity wf = new Sequence
            {
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "Starting the workflow."
                     },
                     new Throw
                    {
                        Exception = new InArgument<Exception>((env) =>
                            new ApplicationException("Something unexpected happened."))
                    },
                    new WriteLine
                     {
                         Text = "Ending the workflow."
                     }
                 }
            };

            WorkflowApplication wfApp = new WorkflowApplication(wf);

            wfApp.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                // Display the unhandled exception.
                Console.WriteLine($"OnUnhandledException in Workflow {e.InstanceId}\n{e.UnhandledException.Message}");

                Console.WriteLine($"ExceptionSource: {e.ExceptionSource.DisplayName} - {e.ExceptionSourceInstanceId}");

                // Instruct the runtime to abort the workflow.
                return UnhandledExceptionAction.Abort;
            };

            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"""
                    Exception: {e.TerminationException.GetType().FullName}
                    {e.TerminationException.Message}
                    """);
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");

                    // Retrieve the outputs of the workflow.
                    foreach (var kvp in e.Outputs)
                    {
                        Console.WriteLine($"Name: {kvp.Key} - Value {kvp.Value}");
                    }

                    // Outputs can be directly accessed by argument name.
                    Console.WriteLine($"The winner is {e.Outputs["Winner"]}.");
                }
            };

            wfApp.Unloaded = delegate (WorkflowApplicationEventArgs e)
            {
                Console.WriteLine($"Workflow {e.InstanceId} unloaded.");
            };

            // WorkflowApplicationAbortedEventArgs
            // WorkflowApplication.Aborted
            //<snippet5>
            wfApp.Aborted = delegate (WorkflowApplicationAbortedEventArgs e)
            {
                // Display the exception that caused the workflow
                // to abort.
                Console.WriteLine($"Workflow {e.InstanceId} Aborted.");
                Console.WriteLine($"""
                Exception: {e.Reason.GetType().FullName}
                {e.Reason.Message}
                """);
            };
            //</snippet5>

            wfApp.Run();
        }

        static void snippet6()
        {
            //<snippet6>
            Activity wf = new Sequence
            {
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "Starting the workflow."
                     },
                     new Throw
                    {
                        Exception = new InArgument<Exception>((env) =>
                            new ApplicationException("Something unexpected happened."))
                    },
                    new WriteLine
                     {
                         Text = "Ending the workflow."
                     }
                 }
            };

            WorkflowApplication wfApp = new WorkflowApplication(wf);

            wfApp.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                // Display the unhandled exception.
                Console.WriteLine($"OnUnhandledException in Workflow {e.InstanceId}\n{e.UnhandledException.Message}");

                Console.WriteLine($"ExceptionSource: {e.ExceptionSource.DisplayName} - {e.ExceptionSourceInstanceId}");

                // Instruct the runtime to terminate the workflow.
                return UnhandledExceptionAction.Terminate;
            };

            wfApp.Aborted = delegate (WorkflowApplicationAbortedEventArgs e)
            {
                // Display the exception that caused the workflow
                // to abort.
                Console.WriteLine($"Workflow {e.InstanceId} Aborted.");
                Console.WriteLine($"""
                Exception: {e.Reason.GetType().FullName}
                {e.Reason.Message}
                """);
            };

            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"""
                    Exception: {e.TerminationException.GetType().FullName}
                    {e.TerminationException.Message}
                    """);
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");

                    // Retrieve the outputs of the workflow.
                    foreach (var kvp in e.Outputs)
                    {
                        Console.WriteLine($"Name: {kvp.Key} - Value {kvp.Value}");
                    }

                    // Outputs can be directly accessed by argument name.
                    // Console.WriteLine($"The winner is {e.Outputs["Winner"]}.");
                }
            };

            wfApp.Run();
            //</snippet6>
        }

        static void snippet7()
        {
            //<snippet7>
            Activity wf = new Sequence
            {
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "Starting the workflow."
                     },
                     new Throw
                    {
                        Exception = new InArgument<Exception>((env) =>
                            new ApplicationException("Something unexpected happened."))
                    },
                    new WriteLine
                     {
                         Text = "Ending the workflow."
                     }
                 }
            };

            WorkflowApplication wfApp = new WorkflowApplication(wf);

            wfApp.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                // Display the unhandled exception.
                Console.WriteLine($"OnUnhandledException in Workflow {e.InstanceId}\n{e.UnhandledException.Message}");

                Console.WriteLine($"ExceptionSource: {e.ExceptionSource.DisplayName} - {e.ExceptionSourceInstanceId}");

                // Instruct the runtime to abort the workflow.
                return UnhandledExceptionAction.Abort;
            };

            wfApp.Aborted = delegate (WorkflowApplicationAbortedEventArgs e)
            {
                // Display the exception that caused the workflow
                // to abort.
                Console.WriteLine($"Workflow {e.InstanceId} Aborted.");
                Console.WriteLine($"Exception: {e.Reason.GetType().FullName}\n{e.Reason.Message}");
            };

            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");

                    // Outputs can be retrieved from the Outputs dictionary,
                    // keyed by argument name.
                    // Console.WriteLine($"The winner is {e.Outputs["Winner"]}.");
                }
            };

            wfApp.Run();
            //</snippet7>
        }

        static void snippet8()
        {
            //<snippet8>
            Activity wf = new Sequence
            {
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "Starting the workflow."
                     },
                     new Throw
                    {
                        Exception = new InArgument<Exception>((env) =>
                            new ApplicationException("Something unexpected happened."))
                    },
                    new WriteLine
                     {
                         Text = "Ending the workflow."
                     }
                 }
            };

            WorkflowApplication wfApp = new WorkflowApplication(wf);

            wfApp.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                // Display the unhandled exception.
                Console.WriteLine($"OnUnhandledException in Workflow {e.InstanceId}\n{e.UnhandledException.Message}");

                Console.WriteLine($"ExceptionSource: {e.ExceptionSource.DisplayName} - {e.ExceptionSourceInstanceId}");

                // Instruct the runtime to cancel the workflow.
                return UnhandledExceptionAction.Cancel;
            };

            wfApp.Aborted = delegate (WorkflowApplicationAbortedEventArgs e)
            {
                // Display the exception that caused the workflow
                // to abort.
                Console.WriteLine($"Workflow {e.InstanceId} Aborted.");
                Console.WriteLine($"Exception: {e.Reason.GetType().FullName}\n{e.Reason.Message}");
            };

            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");

                    // Outputs can be retrieved from the Outputs dictionary,
                    // keyed by argument name.
                    // Console.WriteLine($"The winner is {e.Outputs["Winner"]}.");
                }
            };

            wfApp.Run();
            //</snippet8>
        }

        // WorkflowApplication
        static void snippet9()
        {
            //<snippet9>
            Activity wf = new Sequence
            {
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "Starting the workflow."
                     },
                     new Delay
                     {
                         Duration = TimeSpan.FromSeconds(5)
                     },
                     new WriteLine
                     {
                         Text = "Ending the workflow."
                     }
                 }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Subscribe to any desired workflow lifecycle events.
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");

                    // Outputs can be retrieved from the Outputs dictionary,
                    // keyed by argument name.
                    // Console.WriteLine($"The winner is {e.Outputs["Winner"]}.");
                }
            };

            wfApp.Aborted = delegate (WorkflowApplicationAbortedEventArgs e)
            {
                // Display the exception that caused the workflow
                // to abort.
                Console.WriteLine($"Workflow {e.InstanceId} Aborted.");
                Console.WriteLine($"Exception: {e.Reason.GetType().FullName}\n{e.Reason.Message}");
            };

            wfApp.Idle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                // Perform any processing that should occur
                // when a workflow goes idle. If the workflow can persist,
                // both Idle and PersistableIdle are called in that order.
                Console.WriteLine($"Workflow {e.InstanceId} Idle.");
            };

            wfApp.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                // Instruct the runtime to persist and unload the workflow
                return PersistableIdleAction.Unload;
            };

            wfApp.Unloaded = delegate (WorkflowApplicationEventArgs e)
            {
                Console.WriteLine($"Workflow {e.InstanceId} Unloaded.");
            };

            wfApp.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                // Display the unhandled exception.
                Console.WriteLine($"OnUnhandledException in Workflow {e.InstanceId}\n{e.UnhandledException.Message}");

                Console.WriteLine($"ExceptionSource: {e.ExceptionSource.DisplayName} - {e.ExceptionSourceInstanceId}");

                // Instruct the runtime to terminate the workflow.
                // Other choices are Abort and Cancel
                return UnhandledExceptionAction.Terminate;
            };

            // Run the workflow.
            wfApp.Run();
            //</snippet9>
        }

        // Also used by Using WorkflowInvoker and WorkflowApplication
        static void snippet10()
        {
            //<snippet10>
            int dividend = 500;
            int divisor = 36;

            Dictionary<string, object> inputs = new Dictionary<string, object>();
            inputs.Add("Dividend", dividend);
            inputs.Add("Divisor", divisor);

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(new Divide(), inputs);

            // Subscribe to any desired workflow lifecycle events.
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");

                    // Outputs can be retrieved from the Outputs dictionary,
                    // keyed by argument name.
                    Console.WriteLine($"{dividend} / {divisor} = {e.Outputs["Result"]} Remainder {e.Outputs["Remainder"]}");
                }
            };

            // Run the workflow.
            wfApp.Run();
            //</snippet10>
        }

        // Abort
        static void snippet11()
        {
            //<snippet11>
            Activity wf = new Sequence
            {
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "Starting the workflow."
                     },
                     new Delay
                     {
                         Duration = TimeSpan.FromSeconds(5)
                     },
                     new WriteLine
                     {
                         Text = "Ending the workflow."
                     }
                 }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Subscribe to any desired workflow lifecycle events.
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");

                    // Outputs can be retrieved from the Outputs dictionary,
                    // keyed by argument name.
                    // Console.WriteLine($"The winner is {e.Outputs["Winner"]}.");
                }
            };

            wfApp.Aborted = delegate (WorkflowApplicationAbortedEventArgs e)
            {
                // Display the exception that caused the workflow
                // to abort.
                Console.WriteLine($"Workflow {e.InstanceId} Aborted.");
                Console.WriteLine($"Exception: {e.Reason.GetType().FullName}\n{e.Reason.Message}");
            };

            wfApp.Idle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                // Perform any processing that should occur
                // when a workflow goes idle. If the workflow can persist,
                // both Idle and PersistableIdle are called in that order.
                Console.WriteLine($"Workflow {e.InstanceId} Idle.");
            };

            wfApp.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                // Instruct the runtime to persist and unload the workflow
                return PersistableIdleAction.Unload;
            };

            wfApp.Unloaded = delegate (WorkflowApplicationEventArgs e)
            {
                Console.WriteLine($"Workflow {e.InstanceId} Unloaded.");
            };

            wfApp.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                // Display the unhandled exception.
                Console.WriteLine($"OnUnhandledException in Workflow {e.InstanceId}\n{e.UnhandledException.Message}");

                Console.WriteLine($"ExceptionSource: {e.ExceptionSource.DisplayName} - {e.ExceptionSourceInstanceId}");

                // Instruct the runtime to terminate the workflow.
                // Other choices are Abort and Cancel
                return UnhandledExceptionAction.Terminate;
            };

            // Run the workflow.
            wfApp.Run();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            wfApp.Abort();
            //</snippet11>
        }

        // Abort with reason
        static void snippet12()
        {
            //<snippet12>
            Activity wf = new Sequence
            {
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "Starting the workflow."
                     },
                     new Delay
                     {
                         Duration = TimeSpan.FromSeconds(5)
                     },
                     new WriteLine
                     {
                         Text = "Ending the workflow."
                     }
                 }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Subscribe to any desired workflow lifecycle events.
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");

                    // Outputs can be retrieved from the Outputs dictionary,
                    // keyed by argument name.
                    // Console.WriteLine($"The winner is {e.Outputs["Winner"]}.");
                }
            };

            wfApp.Aborted = delegate (WorkflowApplicationAbortedEventArgs e)
            {
                // Display the exception that caused the workflow
                // to abort.
                Console.WriteLine($"Workflow {e.InstanceId} Aborted.");
                Console.WriteLine($"Exception: {e.Reason.GetType().FullName}\n{e.Reason.Message}");
            };

            wfApp.Idle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                // Perform any processing that should occur
                // when a workflow goes idle. If the workflow can persist,
                // both Idle and PersistableIdle are called in that order.
                Console.WriteLine($"Workflow {e.InstanceId} Idle.");
            };

            wfApp.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                // Instruct the runtime to persist and unload the workflow
                return PersistableIdleAction.Unload;
            };

            wfApp.Unloaded = delegate (WorkflowApplicationEventArgs e)
            {
                Console.WriteLine($"Workflow {e.InstanceId} Unloaded.");
            };

            wfApp.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                // Display the unhandled exception.
                Console.WriteLine($"OnUnhandledException in Workflow {e.InstanceId}\n{e.UnhandledException.Message}");

                Console.WriteLine($"ExceptionSource: {e.ExceptionSource.DisplayName} - {e.ExceptionSourceInstanceId}");

                // Instruct the runtime to terminate the workflow.
                // Other choices are Abort and Cancel
                return UnhandledExceptionAction.Terminate;
            };

            // Run the workflow.
            wfApp.Run();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            wfApp.Abort("The reason for aborting the workflow.");
            //</snippet12>
        }

        // Cancel
        static void snippet13()
        {
            //<snippet13>
            Activity wf = new Sequence
            {
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "Starting the workflow."
                     },
                     new Delay
                     {
                         Duration = TimeSpan.FromSeconds(5)
                     },
                     new WriteLine
                     {
                         Text = "Ending the workflow."
                     }
                 }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Subscribe to any desired workflow lifecycle events.
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");
                }
            };

            // Run the workflow.
            wfApp.Run();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            wfApp.Cancel();
            //</snippet13>
        }

        static void snippet35()
        {
            //<snippet35>
            Activity wf = new CancellationScope
            {
                Body = new Sequence
                {
                    Activities =
                    {
                        new WriteLine
                        {
                            Text = "Starting the workflow."
                        },
                        new Delay
                        {
                            Duration = TimeSpan.FromSeconds(5)
                        },
                        new WriteLine
                        {
                            Text = "Ending the workflow."
                        }
                    }
                },
                CancellationHandler = new WriteLine
                {
                    Text = "CancellationHandler invoked."
                }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Subscribe to any desired workflow lifecycle events.
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");
                }
            };

            // Run the workflow.
            wfApp.Run();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            wfApp.Cancel();
            //</snippet35>
        }

        static void snippet36()
        {
            //<snippet36>
            Activity wf = new CancellationScope
            {
                Body = new Sequence
                {
                    Activities =
                    {
                        new WriteLine
                        {
                            Text = "Starting the workflow."
                        },
                        new Throw
                        {
                             Exception = new InArgument<Exception>((env) =>
                                 new ApplicationException("An ApplicationException was thrown."))
                        },
                        new WriteLine
                        {
                            Text = "Ending the workflow."
                        }
                    }
                },
                CancellationHandler = new WriteLine
                {
                    Text = "CancellationHandler invoked."
                }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Subscribe to any desired workflow lifecycle events.
            wfApp.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                // Display the unhandled exception.
                Console.WriteLine($"OnUnhandledException in Workflow {e.InstanceId}\n{e.UnhandledException.Message}");

                // Instruct the runtime to cancel the workflow.
                return UnhandledExceptionAction.Cancel;
            };

            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");
                }
            };

            // Run the workflow.
            wfApp.Run();

            //</snippet36>
        }

        static void snippet37()
        {
            //<snippet37>
            Activity wf = new Parallel
            {
                CompletionCondition = true,
                Branches =
                {
                    new CancellationScope
                    {
                        Body = new Sequence
                        {
                            Activities =
                            {
                                new WriteLine
                                {
                                    Text = "Branch 1 starting."
                                },
                                new Delay
                                {
                                     Duration = TimeSpan.FromSeconds(2)
                                },
                                new WriteLine
                                {
                                    Text = "Branch 1 complete."
                                }
                            }
                        },
                        CancellationHandler = new WriteLine
                        {
                            Text = "Branch 1 canceled."
                        }
                    },
                    new WriteLine
                    {
                        Text = "Branch 2 complete."
                    }
                }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");
                }
            };

            // Run the workflow.
            wfApp.Run();

            //</snippet37>
        }

        static void snippet38()
        {
            //<snippet38>
            Activity wf = new TryCatch
            {
                Try = new Parallel
                {
                    CompletionCondition = true,
                    Branches =
                    {
                        new CancellationScope
                        {
                            Body = new Sequence
                            {
                                Activities =
                                {
                                    new WriteLine
                                    {
                                        Text = "Branch 1 starting."
                                    },
                                    new Throw
                                    {
                                         Exception = new InArgument<Exception>((env) =>
                                             new ApplicationException("An ApplicationException was thrown."))
                                    },
                                    new WriteLine
                                    {
                                        Text = "Branch 1 complete."
                                    }
                                }
                            },
                            CancellationHandler = new WriteLine
                            {
                                Text = "Branch 1 canceled."
                            }
                        },
                        new WriteLine
                        {
                            Text = "Branch 2 complete."
                        }
                    }
                },
                Catches =
                {
                    new Catch<ApplicationException>
                    {
                        Action = new ActivityAction<ApplicationException>
                        {
                            Handler  = new WriteLine
                            {
                                Text = "Exception caught."
                            }
                        }
                    }
                }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");
                }
            };

            // Run the workflow.
            wfApp.Run();

            //</snippet38>
        }

        static void snippet39()
        {
            //<snippet39>
            Activity wf = new TryCatch
            {
                Try = new CancellationScope
                {
                    Body = new Sequence
                    {
                        Activities =
                        {
                            new WriteLine
                            {
                                Text = "Sequence starting."
                            },
                            new Throw
                            {
                                 Exception = new InArgument<Exception>((env) =>
                                     new ApplicationException("An ApplicationException was thrown."))
                            },
                            new WriteLine
                            {
                                Text = "Sequence complete."
                            }
                        }
                    },
                    CancellationHandler = new WriteLine
                    {
                        Text = "Sequence canceled."
                    }
                },
                Catches =
                {
                    new Catch<ApplicationException>
                    {
                        Action = new ActivityAction<ApplicationException>
                        {
                            Handler  = new WriteLine
                            {
                                Text = "Exception caught."
                            }
                        }
                    }
                }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");
                }
            };

            // Run the workflow.
            wfApp.Run();
            //</snippet39>
        }

        // Unused
        static void snippet40()
        {
            //<snippet40>
            Activity wf = new CancellationScope
            {
                Body = new Sequence
                {
                    Activities =
                    {
                        new WriteLine
                        {
                            Text = "Starting the workflow."
                        },
                        new Throw
                        {
                             Exception = new InArgument<Exception>((env) =>
                                 new ApplicationException("An ApplicationException was thrown."))
                        },
                        new WriteLine
                        {
                            Text = "Ending the workflow."
                        }
                    }
                },
                CancellationHandler = new Throw
                {
                    Exception = new InArgument<Exception>((env) =>
                        new ApplicationException("An ApplicationException was thrown."))
                }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Subscribe to any desired workflow lifecycle events.
            wfApp.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                // Display the unhandled exception.
                Console.WriteLine($"OnUnhandledException in Workflow {e.InstanceId}\n{e.UnhandledException.Message}");

                // Instruct the runtime to cancel the workflow.
                return UnhandledExceptionAction.Cancel;
            };

            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");
                }
            };

            // Run the workflow.
            wfApp.Run();
            //</snippet40>
        }

        // ActivityBuilder
        static void snippet41()
        {
            //<snippet41>
            ActivityBuilder<int> ab = new ActivityBuilder<int>();
            ab.Name = "Add";
            ab.Properties.Add(new DynamicActivityProperty { Name = "Operand1", Type = typeof(InArgument<int>) });
            ab.Properties.Add(new DynamicActivityProperty { Name = "Operand2", Type = typeof(InArgument<int>) });
            ab.Implementation = new Sequence
            {
                Activities =
                {
                    new WriteLine
                    {
                        Text = new VisualBasicValue<string>("Operand1.ToString() + \" + \" + Operand2.ToString()")
                    },
                    new Assign<int>
                    {
                        To = new ArgumentReference<int> { ArgumentName = "Result" },
                        Value = new VisualBasicValue<int>("Operand1 + Operand2")
                    }
                }
            };
            //</snippet41>

            //<snippet42>
            // Serialize the workflow to XAML and store it in a string.
            StringBuilder sb = new StringBuilder();
            StringWriter tw = new StringWriter(sb);
            XamlWriter xw = ActivityXamlServices.CreateBuilderWriter(new XamlXmlWriter(tw, new XamlSchemaContext()));
            XamlServices.Save(xw, ab);
            string serializedAB = sb.ToString();

            // Display the XAML to the console.
            Console.WriteLine(serializedAB);

            // Serialize the workflow to XAML and save it to a file.
            StreamWriter sw = File.CreateText(@"C:\Workflows\add.xaml");
            XamlWriter xw2 = ActivityXamlServices.CreateBuilderWriter(new XamlXmlWriter(sw, new XamlSchemaContext()));
            XamlServices.Save(xw2, ab);
            sw.Close();
            //</snippet42>

            //<snippet43>
            // Load the workflow definition from XAML and invoke it.
            DynamicActivity<int> wf = ActivityXamlServices.Load(new StringReader(serializedAB)) as DynamicActivity<int>;
            Dictionary<string, object> wfParams = new Dictionary<string, object>
            {
                { "Operand1", 25 },
                { "Operand2", 15 }
            };

            int result = WorkflowInvoker.Invoke(wf, wfParams);
            Console.WriteLine(result);
            //</snippet43>

            //Activity wf = ActivityXamlServices.Load(new StringReader(serializedAB)) as Activity;
            //WorkflowInvoker.Invoke(wf);

            //<snippet44>
            // Create a new ActivityBuilder and initialize it using the serialized
            // workflow definition.
            ActivityBuilder<int> ab2 = XamlServices.Load(
                ActivityXamlServices.CreateBuilderReader(
                new XamlXmlReader(new StringReader(serializedAB)))) as ActivityBuilder<int>;

            // Now you can continue working with the ActivityBuilder, inspect
            // properties, etc...
            Console.WriteLine($"There are {ab2.Properties.Count} arguments in the activity builder.");
            foreach (var prop in ab2.Properties)
            {
                Console.WriteLine("Name: {0}, Type: {1}", prop.Name, prop.Type);
            }
            //</snippet44>

            //<snippet56>
            // Get the generic type of the InArgument<> or InOutArgument<> arguments of
            // the workflow.
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(wf);
            foreach (PropertyDescriptor property in properties)
            {
                if (property.PropertyType.IsGenericType &&
                    (property.PropertyType.GetGenericTypeDefinition() == typeof(InArgument<>) ||
                    property.PropertyType.GetGenericTypeDefinition() == typeof(InOutArgument<>)))
                {
                    Type targetType = property.PropertyType.GetGenericArguments()[0];
                    Console.WriteLine("Name: {0}, Type: {1}", property.Name, targetType);
                }
            }
            //</snippet56>
        }

        private static Activity ActivityTreeInspection()
        {
            //<snippet45>
            Variable<List<string>> items = new Variable<List<string>>
            {
                Default = new VisualBasicValue<List<string>>("New List(Of String)()")
            };

            DelegateInArgument<string> item = new DelegateInArgument<string>();

            Activity wf = new Sequence
            {
                Variables = { items },
                Activities =
                {
                    new While((env) => items.Get(env).Count < 5)
                    {
                        Body = new AddToCollection<string>
                        {
                            Collection = new InArgument<ICollection<string>>(items),
                            Item = new InArgument<string>((env) => "List Item " + (items.Get(env).Count + 1))
                        }
                    },
                    new ForEach<string>
                    {
                        Values = new InArgument<IEnumerable<string>>(items),
                        Body = new ActivityAction<string>
                        {
                            Argument = item,
                            Handler = new WriteLine
                            {
                                Text = item
                            }
                        }
                    },
                    new Sequence
                    {
                        Activities =
                        {
                            new WriteLine
                            {
                                Text = "Items added to collection."
                            }
                        }
                    }
                }
            };

            WorkflowInvoker.Invoke(wf);

            InspectActivity(wf, 0);
            //</snippet45>

            return wf;
        }

        //<snippet46>
        static void InspectActivity(Activity root, int indent)
        {
            // Inspect the activity tree using WorkflowInspectionServices.
            IEnumerator<Activity> activities =
                WorkflowInspectionServices.GetActivities(root).GetEnumerator();

            Console.WriteLine($"{new string(' ', indent)}{root.DisplayName}");

            while (activities.MoveNext())
            {
                InspectActivity(activities.Current, indent + 2);
            }
        }
        //</snippet46>

        static void snippet57()
        {
            //<snippet57>
            Variable<List<string>> items = new Variable<List<string>>();
            DelegateInArgument<string> item = new DelegateInArgument<string>();

            Activity wf = new Sequence
            {
                Variables = { items },
                Activities =
                {
                    //<snippet58>
                    new Assign
                    {
                        To = new OutArgument<List<string>>(items),
                        Value = new InArgument<List<string>>(new List<string>())
                    },
                    //</snippet58>
                    new While((env) => items.Get(env).Count < 5)
                    {
                        Body = new AddToCollection<string>
                        {
                            Collection = new InArgument<ICollection<string>>(items),
                            Item = new InArgument<string>((env) => "List Item " + (items.Get(env).Count + 1))
                        }
                    },
                    new ForEach<string>
                    {
                        Values = new InArgument<IEnumerable<string>>(items),
                        Body = new ActivityAction<string>
                        {
                            Argument = item,
                            Handler = new WriteLine
                            {
                                Text = item
                            }
                        }
                    },
                    new Sequence
                    {
                        Activities =
                        {
                            new WriteLine
                            {
                                Text = "Items added to collection."
                            }
                        }
                    }
                }
            };

            ValidationResults results = ActivityValidationServices.Validate(wf);

            if (results.Errors.Count == 0 && results.Warnings.Count == 0)
            {
                Console.WriteLine("No warnings or errors");
            }
            else
            {
                foreach (ValidationError error in results.Errors)
                {
                    Console.WriteLine($"Error: {error.Message}");
                }
                foreach (ValidationError warning in results.Warnings)
                {
                    Console.WriteLine($"Warning: {warning.Message}");
                }
            }

            WorkflowInvoker.Invoke(wf);
            //</snippet57>
        }

        static void snippet59()
        {
            //<snippet59>
            Variable<List<string>> items = new Variable<List<string>>();
            DelegateInArgument<string> item = new DelegateInArgument<string>();

            Activity wf = new Sequence
            {
                Variables = { items },
                Activities =
                {
                    //<snippet60>
                    new Assign
                    {
                        To = new OutArgument<List<string>>(items),
                        Value = new InArgument<List<string>>(new VisualBasicValue<List<string>>("New List(Of String)"))
                    },
                    //</snippet60>
                    new While((env) => items.Get(env).Count < 5)
                    {
                        Body = new AddToCollection<string>
                        {
                            Collection = new InArgument<ICollection<string>>(items),
                            Item = new InArgument<string>((env) => "List Item " + (items.Get(env).Count + 1))
                        }
                    },
                    new ForEach<string>
                    {
                        Values = new InArgument<IEnumerable<string>>(items),
                        Body = new ActivityAction<string>
                        {
                            Argument = item,
                            Handler = new WriteLine
                            {
                                Text = item
                            }
                        }
                    },
                    new Sequence
                    {
                        Activities =
                        {
                            new WriteLine
                            {
                                Text = "Items added to collection."
                            }
                        }
                    }
                }
            };

            WorkflowInvoker.Invoke(wf);
            //</snippet59>

            Activity snippet61 = new Sequence
            {
                Activities =
                {
                    //<snippet61>
                    new WriteLine
                    {
                        Text = "Hello World."
                    },
                    new WriteLine
                    {
                        Text = new Literal<string>("Hello World.")
                    }
                    //</snippet61>
                }
            };

            WorkflowInvoker.Invoke(snippet61);
        }

        static void snippet63()
        {
            //<snippet63>
            Dictionary<string, object> inputs = new Dictionary<string, object> { { "Value", 5 } };
            int result = WorkflowInvoker.Invoke(new Square(), inputs);
            Console.WriteLine($"Result: {result}");
            //</snippet63>
        }

        // Authoring Workflows using Imperative Code
        static void snippet47()
        {
            //<snippet47>
            Activity wf = new WriteLine
            {
                Text = "Hello World."
            };

            WorkflowInvoker.Invoke(wf);
            //</snippet47>
        }

        static void snippet48()
        {
            //<snippet48>
            Activity wf = new Sequence
            {
                Activities =
                {
                    new WriteLine
                    {
                        Text = "Hello"
                    },
                    new WriteLine
                    {
                        Text = "World."
                    }
                }
            };

            WorkflowInvoker.Invoke(wf);
            //</snippet48>
        }

        static void snippet49()
        {
            //<snippet49>
            WriteLine hello = new WriteLine();
            hello.Text = "Hello";

            WriteLine world = new WriteLine();
            world.Text = "World";

            Sequence wf = new Sequence();
            wf.Activities.Add(hello);
            wf.Activities.Add(world);

            WorkflowInvoker.Invoke(wf);
            //</snippet49>
        }

        static void snippet50()
        {
            //<snippet50>
            Variable<int> n = new Variable<int>
            {
                Name = "n"
            };

            Activity wf = new Sequence
            {
                Variables = { n },
                Activities =
                {
                    new Assign<int>
                    {
                        To = n,
                        Value = new Random().Next(1, 101)
                    },
                    new WriteLine
                    {
                        Text = new InArgument<string>((env) => "The number is " + n.Get(env))
                    }
                }
            };
            //</snippet50>

            WorkflowInvoker.Invoke(wf);
            Thread.Sleep(1000);
            WorkflowInvoker.Invoke(wf);
            Thread.Sleep(1000);
            WorkflowInvoker.Invoke(wf);
        }

        static void snippet51()
        {
            Variable<int> n = new Variable<int>
            {
                Name = "n"
            };

            Activity wf = new Sequence
            {
                Variables = { n },
                Activities =
                {
                    //<snippet51>
                    new Assign<int>
                    {
                        To = n,
                        Value = new VisualBasicValue<int>("New Random().Next(1, 101)")
                    }
                    //</snippet51>
                    ,
                    //<snippet65>
                    new InvokeMethod<int>
                    {
                        TargetObject = new InArgument<Random>(new VisualBasicValue<Random>("New Random()")),
                        MethodName = "Next",
                        Parameters =
                        {
                            new InArgument<int>(1),
                            new InArgument<int>(101)
                        },
                        Result = n
                    }
                    //</snippet65>
                    ,
                    //<snippet52>
                    new WriteLine
                    {
                        Text = new InArgument<string>((env) => "The number is " + n.Get(env))
                    }
                    //</snippet52>
                    ,
                    //<snippet53>
                    new WriteLine
                    {
                        //Text = new InArgument<string>((env) => "The number is " + n.Get(env))
                        Text = ExpressionServices.Convert((env) => "The number is " + n.Get(env))
                    }
                    //</snippet53>
                    ,
                    //<snippet54>
                    new WriteLine
                    {
                        //Text = new InArgument<string>((env) => "The number is " + n.Get(env))
                        //Text = ExpressionServices.Convert((env) => "The number is " + n.Get(env))
                        Text = new VisualBasicValue<string>("\"The number is \" + n.ToString()")
                    }
                    //</snippet54>
                }
            };

            WorkflowInvoker.Invoke(wf);
            Thread.Sleep(1000);
            WorkflowInvoker.Invoke(wf);
            Thread.Sleep(1000);
            WorkflowInvoker.Invoke(wf);
        }

        static void snippet55()
        {
            //<snippet55>
            InArgument<int> Operand1 = new InArgument<int>();
            InArgument<int> Operand2 = new InArgument<int>();

            DynamicActivity<int> wf = new DynamicActivity<int>
            {
                Properties =
                {
                    new DynamicActivityProperty
                    {
                        Name = "Operand1",
                        Type = typeof(InArgument<int>),
                        Value = Operand1
                    },
                    new DynamicActivityProperty
                    {
                        Name = "Operand2",
                        Type = typeof(InArgument<int>),
                        Value = Operand2
                    }
                },

                Implementation = () => new Sequence
                {
                    Activities =
                    {
                        new Assign<int>
                        {
                            To = new ArgumentReference<int> { ArgumentName = "Result" },
                            Value = new InArgument<int>((env) => Operand1.Get(env) + Operand2.Get(env))
                        }
                    }
                }
            };

            Dictionary<string, object> wfParams = new Dictionary<string, object>
            {
                { "Operand1", 25 },
                { "Operand2", 15 }
            };

            int result = WorkflowInvoker.Invoke(wf, wfParams);
            Console.WriteLine(result);
            //</snippet55>
        }

        // GetBookmarks
        static void snippet14()
        {
            //<snippet14>
            Variable<string> name = new Variable<string>();

            Activity wf = new Sequence
            {
                Variables = { name },
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "What is your name?"
                     },
                     new ReadLine
                     {
                         BookmarkName = "UserName",
                         Result = new OutArgument<string>(name)
                     },
                     new WriteLine
                     {
                         Text = new InArgument<string>((env) =>
                             ("Hello, " + name.Get(env)))
                     }
                 }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Workflow lifecycle events omitted except idle.
            AutoResetEvent idleEvent = new AutoResetEvent(false);

            wfApp.Idle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                // You can also inspect the bookmarks from the Idle handler
                // using e.Bookmarks

                idleEvent.Set();
            };

            // Run the workflow.
            wfApp.Run();

            // Wait for the workflow to go idle and give it a chance
            // to create the Bookmark.
            idleEvent.WaitOne();

            // Inspect the bookmarks
            foreach (BookmarkInfo info in wfApp.GetBookmarks())
            {
                Console.WriteLine($"BookmarkName: {info.BookmarkName} - OwnerDisplayName: {info.OwnerDisplayName}");
            }

            // Gather the user's input and resume the bookmark.
            wfApp.ResumeBookmark("UserName", Console.ReadLine());
            //</snippet14>
        }

        // Terminate
        static void snippet16()
        {
            //<snippet16>
            Activity wf = new Sequence
            {
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "Starting the workflow."
                     },
                     new Delay
                     {
                         Duration = TimeSpan.FromSeconds(5)
                     },
                     new WriteLine
                     {
                         Text = "Ending the workflow."
                     }
                 }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Subscribe to any desired workflow lifecycle events.
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");

                    // Outputs can be retrieved from the Outputs dictionary,
                    // keyed by argument name.
                    // Console.WriteLine($"The winner is {e.Outputs["Winner"]}.");
                }
            };

            wfApp.Unloaded = delegate (WorkflowApplicationEventArgs e)
            {
                Console.WriteLine($"Workflow {e.InstanceId} unloaded.");
            };

            // Run the workflow.
            wfApp.Run();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            wfApp.Terminate(new ApplicationException("Terminating the workflow."));
            //</snippet16>
        }

        // Terminate
        static void snippet17()
        {
            //<snippet17>
            Activity wf = new Sequence
            {
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "Starting the workflow."
                     },
                     new Delay
                     {
                         Duration = TimeSpan.FromSeconds(5)
                     },
                     new WriteLine
                     {
                         Text = "Ending the workflow."
                     }
                 }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Subscribe to any desired workflow lifecycle events.
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");

                    // Outputs can be retrieved from the Outputs dictionary,
                    // keyed by argument name.
                    // Console.WriteLine($"The winner is {e.Outputs["Winner"]}.");
                }
            };

            wfApp.Unloaded = delegate (WorkflowApplicationEventArgs e)
            {
                Console.WriteLine($"Workflow {e.InstanceId} unloaded.");
            };

            // Run the workflow.
            wfApp.Run();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            wfApp.Terminate(new ApplicationException("Terminating the workflow."),
                TimeSpan.FromSeconds(15));
            //</snippet17>
        }

        // Terminate
        static void snippet18()
        {
            //<snippet18>
            Activity wf = new Sequence
            {
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "Starting the workflow."
                     },
                     new Delay
                     {
                         Duration = TimeSpan.FromSeconds(5)
                     },
                     new WriteLine
                     {
                         Text = "Ending the workflow."
                     }
                 }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Subscribe to any desired workflow lifecycle events.
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");

                    // Outputs can be retrieved from the Outputs dictionary,
                    // keyed by argument name.
                    // Console.WriteLine($"The winner is {e.Outputs["Winner"]}.");
                }
            };

            wfApp.Unloaded = delegate (WorkflowApplicationEventArgs e)
            {
                Console.WriteLine($"Workflow {e.InstanceId} unloaded.");
            };

            // Run the workflow.
            wfApp.Run();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            wfApp.Terminate("Terminating the workflow.");
            //</snippet18>
        }

        // Terminate
        static void snippet19()
        {
            //<snippet19>
            Activity wf = new Sequence
            {
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "Starting the workflow."
                     },
                     new Delay
                     {
                         Duration = TimeSpan.FromSeconds(5)
                     },
                     new WriteLine
                     {
                         Text = "Ending the workflow."
                     }
                 }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Subscribe to any desired workflow lifecycle events.
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");

                    // Outputs can be retrieved from the Outputs dictionary,
                    // keyed by argument name.
                    // Console.WriteLine($"The winner is {e.Outputs["Winner"]}.");
                }
            };

            wfApp.Unloaded = delegate (WorkflowApplicationEventArgs e)
            {
                Console.WriteLine($"Workflow {e.InstanceId} unloaded.");
            };

            // Run the workflow.
            wfApp.Run();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            wfApp.Terminate("Terminating the workflow.", TimeSpan.FromSeconds(15));
            //</snippet19>
        }

        //<snippet20>
        // single interaction with the user. The user enters a string in the console and that
        // string is used to resume the ReadLine activity bookmark
        static void Interact(WorkflowApplication application, AutoResetEvent resetEvent)
        {
            Console.WriteLine("Workflow is ready for input");
            Console.WriteLine("Special commands: 'unload', 'exit'");

            bool done = false;
            while (!done)
            {
                Console.Write("> ");
                string s = Console.ReadLine();
                if (s.Equals("unload"))
                {
                    try
                    {
                        // attempt to unload will fail if the workflow is idle within a NoPersistZone
                        application.Unload(TimeSpan.FromSeconds(5));
                        done = true;
                    }
                    catch (TimeoutException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (s.Equals("exit"))
                {
                    application.ResumeBookmark("inputBookmark", s);
                    done = true;
                }
                else
                {
                    application.ResumeBookmark("inputBookmark", s);
                }
            }
            resetEvent.WaitOne();
        }
        //</snippet20>

        static void snippet21()
        {
            //<snippet21>
            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(new DiceRoll());

            // Subscribe to any desired workflow lifecycle events.
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");

                    // Outputs can be retrieved from the Outputs dictionary,
                    // keyed by argument name.
                    Console.WriteLine($"The two dice are {e.Outputs["D1"]} and {e.Outputs["D2"]}.");
                }
            };

            // Run the workflow.
            wfApp.Run();
            //</snippet21>
        }

        // ResumeBookmark
        // Using WorkflowInvoker and WorkflowApplication
        static void snippet22()
        {
            //<snippet22>
            Variable<string> name = new Variable<string>();

            Activity wf = new Sequence
            {
                Variables = { name },
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "What is your name?"
                     },
                     new ReadLine
                     {
                         BookmarkName = "UserName",
                         Result = new OutArgument<string>(name)
                     },
                     new WriteLine
                     {
                         Text = new InArgument<string>((env) =>
                             ("Hello, " + name.Get(env)))
                     }
                 }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Workflow lifecycle events omitted except idle.
            AutoResetEvent idleEvent = new AutoResetEvent(false);

            wfApp.Idle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                idleEvent.Set();
            };

            // Run the workflow.
            wfApp.Run();

            // Wait for the workflow to go idle before gathering
            // the user's input.
            idleEvent.WaitOne();

            // Gather the user's input and resume the bookmark.
            // Bookmark resumption only occurs when the workflow
            // is idle. If a call to ResumeBookmark is made and the workflow
            // is not idle, ResumeBookmark blocks until the workflow becomes
            // idle before resuming the bookmark.
            BookmarkResumptionResult result = wfApp.ResumeBookmark("UserName",
                Console.ReadLine());

            // Possible BookmarkResumptionResult values:
            // Success, NotFound, or NotReady
            Console.WriteLine($"BookmarkResumptionResult: {result}");
            //</snippet22>
        }

        // ResumeBookmark
        static void snippet23()
        {
            //<snippet23>
            Variable<string> name = new Variable<string>();

            Activity wf = new Sequence
            {
                Variables = { name },
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "What is your name?"
                     },
                     new ReadLine
                     {
                         BookmarkName = "UserName",
                         Result = new OutArgument<string>(name)
                     },
                     new WriteLine
                     {
                         Text = new InArgument<string>((env) =>
                             ("Hello, " + name.Get(env)))
                     }
                 }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Workflow lifecycle events omitted except idle.
            AutoResetEvent idleEvent = new AutoResetEvent(false);

            wfApp.Idle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                idleEvent.Set();
            };

            // Run the workflow.
            wfApp.Run();

            // Wait for the workflow to go idle before gathering
            // the user's input.
            idleEvent.WaitOne();

            // Gather the user's input and resume the bookmark.
            BookmarkResumptionResult result = wfApp.ResumeBookmark("UserName",
                Console.ReadLine(), TimeSpan.FromSeconds(15));

            // Possible BookmarkResumptionResult values:
            // Success, NotFound, or NotReady
            Console.WriteLine($"BookmarkResumptionResult: {result}");
            //</snippet23>
        }

        static void snippet24()
        {
            //<snippet24>
            Variable<string> name = new Variable<string>();

            Activity wf = new Sequence
            {
                Variables = { name },
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "What is your name?"
                     },
                     new ReadLine
                     {
                         BookmarkName = "UserName",
                         Result = new OutArgument<string>(name)
                     },
                     new WriteLine
                     {
                         Text = new InArgument<string>((env) =>
                             ("Hello, " + name.Get(env)))
                     }
                 }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Workflow lifecycle events omitted except idle.
            AutoResetEvent idleEvent = new AutoResetEvent(false);

            wfApp.Idle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                idleEvent.Set();
            };

            // Run the workflow.
            wfApp.Run();

            // Wait for the workflow to go idle before gathering
            // the user's input.
            idleEvent.WaitOne();

            // Gather the user's input and resume the bookmark.
            BookmarkResumptionResult result = wfApp.ResumeBookmark(new Bookmark("UserName"),
                Console.ReadLine());

            // Possible BookmarkResumptionResult values:
            // Success, NotFound, or NotReady
            Console.WriteLine($"BookmarkResumptionResult: {result}");
            //</snippet24>
        }

        // ResumeBookmark
        static void snippet25()
        {
            //<snippet25>
            Variable<string> name = new Variable<string>();

            Activity wf = new Sequence
            {
                Variables = { name },
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "What is your name?"
                     },
                     new ReadLine
                     {
                         BookmarkName = "UserName",
                         Result = new OutArgument<string>(name)
                     },
                     new WriteLine
                     {
                         Text = new InArgument<string>((env) =>
                             ("Hello, " + name.Get(env)))
                     }
                 }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Workflow lifecycle events omitted except idle.
            AutoResetEvent idleEvent = new AutoResetEvent(false);

            wfApp.Idle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                idleEvent.Set();
            };

            // Run the workflow.
            wfApp.Run();

            // Wait for the workflow to go idle before gathering
            // the user's input.
            idleEvent.WaitOne();

            // Gather the user's input and resume the bookmark.
            BookmarkResumptionResult result = wfApp.ResumeBookmark(new Bookmark("UserName"),
                Console.ReadLine(), TimeSpan.FromSeconds(15));

            // Possible BookmarkResumptionResult values:
            // Success, NotFound, or NotReady
            Console.WriteLine($"BookmarkResumptionResult: {result}");
            //</snippet25>
        }

        // Load, from Persisting a Workflow Instance sample

        static void LoadAndCompleteInstance()
        {
            // Support for this non running snippet

            const string readLineBookmark = "test";
            SqlWorkflowInstanceStore instanceStore = new SqlWorkflowInstanceStore();
            AutoResetEvent instanceUnloaded = new AutoResetEvent(false);
            Guid id = Guid.NewGuid();
            Sequence activity = new Sequence();

            //<snippet27>
            string input = Console.ReadLine();

            WorkflowApplication application = new WorkflowApplication(activity);
            application.InstanceStore = instanceStore;

            application.Completed = (workflowApplicationCompletedEventArgs) =>
            {
                Console.WriteLine($"\nWorkflowApplication has Completed in the {workflowApplicationCompletedEventArgs.CompletionState} state.");
            };

            application.Unloaded = (workflowApplicationEventArgs) =>
            {
                Console.WriteLine("WorkflowApplication has Unloaded\n");
                instanceUnloaded.Set();
            };

            application.Load(id);

            //this resumes the bookmark setup by readline
            application.ResumeBookmark(readLineBookmark, input);

            instanceUnloaded.WaitOne();
            //</snippet27>
        }

        static void StartAndUnloadInstance()
        {
            // Support for this non-running snippet
            Activity activity = new Sequence();
            SqlWorkflowInstanceStore instanceStore = new SqlWorkflowInstanceStore();
            AutoResetEvent instanceUnloaded = new AutoResetEvent(false);
            Guid id = Guid.NewGuid();

            //<snippet34>
            WorkflowApplication application = new WorkflowApplication(activity);

            application.InstanceStore = instanceStore;

            //returning IdleAction.Unload instructs the WorkflowApplication to persists application state and remove it from memory
            application.PersistableIdle = (e) =>
            {
                return PersistableIdleAction.Unload;
            };

            application.Unloaded = (e) =>
            {
                instanceUnloaded.Set();
            };

            //This call is not required
            //Calling persist here captures the application durably before it has been started
            application.Persist();
            id = application.Id;
            application.Run();

            instanceUnloaded.WaitOne();
            //</snippet34>
        }

        // Id property
        static void snippet28()
        {
            //<snippet28>
            Activity wf = new WriteLine
            {
                Text = "Hello world."
            };

            WorkflowApplication wfApp = new WorkflowApplication(wf);

            Console.WriteLine($"Id: {wfApp.Id}");
            //</snippet28>
        }

        // InstanceStore
        static void snippet29()
        {
            string connectionString = "...";

            //<snippet29>
            var wfparams = new Dictionary<string, object>() { { "MaxNumber", 100 } };

            WorkflowApplication wfApp =
                new WorkflowApplication(new Workflow1(), wfparams);

            SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(connectionString);
            wfApp.InstanceStore = store;
            //</snippet29>
        }

        // Using WorkflowInvoker and WorkflowApplication
        static void snippet30()
        {
            //<snippet30>
            AutoResetEvent syncEvent = new AutoResetEvent(false);

            Activity wf = new WriteLine();

            // Create the dictionary of input parameters.
            Dictionary<string, object> inputs = new Dictionary<string, object>();
            inputs.Add("Text", "Hello World!");

            // Create the WorkflowApplication using the desired
            // workflow definition and dictionary of input parameters.
            WorkflowApplication wfApp = new WorkflowApplication(wf, inputs);

            // Handle the desired lifecycle events.
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                syncEvent.Set();
            };

            // Start the workflow.
            wfApp.Run();

            // Wait for Completed to arrive and signal that
            // the workflow is complete.
            syncEvent.WaitOne();
            //</snippet30>
        }

        // Using WorkflowInvoker and WorkflowApplication
        static void snippet31()
        {
            //<snippet31>
            AutoResetEvent syncEvent = new AutoResetEvent(false);

            Activity wf = new WriteLine
            {
                Text = "Hello World."
            };

            // Create the WorkflowApplication using the desired
            // workflow definition.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Handle the desired lifecycle events.
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                syncEvent.Set();
            };

            // Start the workflow.
            wfApp.Run();

            // Wait for Completed to arrive and signal that
            // the workflow is complete.
            syncEvent.WaitOne();
            //</snippet31>
        }

        // Lifecycle events
        static void snippet32()
        {
            Activity wf = new Sequence
            {
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "Starting the workflow."
                     },
                     new Delay
                     {
                         Duration = TimeSpan.FromSeconds(5)
                     },
                     new WriteLine
                     {
                         Text = "Ending the workflow."
                     }
                 }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Subscribe to any desired workflow lifecycle events.
            //<snippet32>
            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Terminated.");
                    Console.WriteLine($"Exception: {e.TerminationException.GetType().FullName}\n{e.TerminationException.Message}");
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Canceled.");
                }
                else
                {
                    Console.WriteLine($"Workflow {e.InstanceId} Completed.");

                    // Outputs can be retrieved from the Outputs dictionary,
                    // keyed by argument name.
                    // Console.WriteLine($"The winner is {e.Outputs["Winner"]}.");
                }
            };

            wfApp.Aborted = delegate (WorkflowApplicationAbortedEventArgs e)
            {
                // Display the exception that caused the workflow
                // to abort.
                Console.WriteLine($"Workflow {e.InstanceId} Aborted.");
                Console.WriteLine($"Exception: {e.Reason.GetType().FullName}\n{e.Reason.Message}");
            };

            wfApp.Idle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                // Perform any processing that should occur
                // when a workflow goes idle. If the workflow can persist,
                // both Idle and PersistableIdle are called in that order.
                Console.WriteLine($"Workflow {e.InstanceId} Idle.");
            };

            wfApp.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs e)
            {
                // Instruct the runtime to persist and unload the workflow.
                // Choices are None, Persist, and Unload.
                return PersistableIdleAction.Unload;
            };

            wfApp.Unloaded = delegate (WorkflowApplicationEventArgs e)
            {
                Console.WriteLine($"Workflow {e.InstanceId} Unloaded.");
            };

            wfApp.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                // Display the unhandled exception.
                Console.WriteLine($"OnUnhandledException in Workflow {e.InstanceId}\n{e.UnhandledException.Message}");

                Console.WriteLine($"ExceptionSource: {e.ExceptionSource.DisplayName} - {e.ExceptionSourceInstanceId}");

                // Instruct the runtime to terminate the workflow.
                // Other choices are Abort and Cancel. Terminate
                // is the default if no OnUnhandledException handler
                // is present.
                return UnhandledExceptionAction.Terminate;
            };
            //</snippet32>

            // Run the workflow.
            wfApp.Run();
        }

        // Exceptions
        // Using Activity Delegates
        static void snippet33()
        {
            //<snippet33>
            DelegateInArgument<ApplicationException> ex = new DelegateInArgument<ApplicationException>()
            {
                Name = "ex"
            };

            Activity wf = new TryCatch
            {
                Try = new Throw()
                {
                    Exception = new InArgument<Exception>((env) => new ApplicationException("An ApplicationException was thrown."))
                },
                Catches =
                {
                    new Catch<ApplicationException>
                    {
                        Action = new ActivityAction<ApplicationException>
                        {
                            Argument = ex,
                            Handler = new WriteLine()
                            {
                                Text = new InArgument<string>((env) => ex.Get(env).Message)
                            }
                        }
                    }
                },
                Finally = new WriteLine()
                {
                    Text = "Executing in Finally."
                }
            };
            //</snippet33>

            WorkflowApplication wfApp = new WorkflowApplication(wf);

            wfApp.Run();
        }
    }

    // Support for snippets that use Workflow1
    class Workflow1 : Activity
    {
    }

    //<snippet62>
    class Square : Activity<int>
    {
        [RequiredArgument]
        public InArgument<int> Value { get; set; }

        public Square()
        {
            this.Implementation = () => new Sequence
            {
                Activities =
                {
                    new WriteLine
                    {
                        Text = new InArgument<string>((env) => "Squaring the value: " + this.Value.Get(env))
                    },
                    new Assign<int>
                    {
                        To = new OutArgument<int>((env) => this.Result.Get(env)),
                        Value = new InArgument<int>((env) => this.Value.Get(env) * this.Value.Get(env))
                    }
                }
            };
        }
    }
    //</snippet62>

    //<snippet120>
    public sealed class Divide : CodeActivity
    {
        [RequiredArgument]
        public InArgument<int> Dividend { get; set; }

        [RequiredArgument]
        public InArgument<int> Divisor { get; set; }

        public OutArgument<int> Remainder { get; set; }
        public OutArgument<int> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int quotient = Dividend.Get(context) / Divisor.Get(context);
            int remainder = Dividend.Get(context) % Divisor.Get(context);

            Result.Set(context, quotient);
            Remainder.Set(context, remainder);
        }
    }
    //</snippet120>

    // WorkflowApplication
    // Using WorkflowInvoker and WorkflowApplication
    //<snippet130>
    public sealed class DiceRoll : CodeActivity
    {
        public OutArgument<int> D1 { get; set; }
        public OutArgument<int> D2 { get; set; }

        static Random r = new Random();

        protected override void Execute(CodeActivityContext context)
        {
            D1.Set(context, r.Next(1, 7));
            D2.Set(context, r.Next(1, 7));
        }
    }
    //</snippet130>

    //<snippet1000>
    public sealed class ReadInt : NativeActivity<int>
    {
        [RequiredArgument]
        public InArgument<string> BookmarkName { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            string name = BookmarkName.Get(context);

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("BookmarkName cannot be an Empty string.");
                return;
            }

            context.CreateBookmark(name, new BookmarkCallback(OnReadComplete));
        }

        // NativeActivity derived activities that do asynchronous operations by calling
        // one of the CreateBookmark overloads defined on System.Activities.NativeActivityContext
        // must override the CanInduceIdle property and return true.
        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        void OnReadComplete(NativeActivityContext context, Bookmark bookmark, object state)
        {
            this.Result.Set(context, Convert.ToInt32(state));
        }
    }
    //</snippet1000>

    // ResumeBookmark
    // Using WorkflowInvoker and WorkflowApplication
    //<snippet15>
    public sealed class ReadLine : NativeActivity<string>
    {
        [RequiredArgument]
        public InArgument<string> BookmarkName { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            // Create a Bookmark and wait for it to be resumed.
            context.CreateBookmark(BookmarkName.Get(context),
                new BookmarkCallback(OnResumeBookmark));
        }

        // NativeActivity derived activities that do asynchronous operations by calling
        // one of the CreateBookmark overloads defined on System.Activities.NativeActivityContext
        // must override the CanInduceIdle property and return true.
        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        public void OnResumeBookmark(NativeActivityContext context, Bookmark bookmark, object obj)
        {
            // When the Bookmark is resumed, assign its value to
            // the Result argument.
            Result.Set(context, (string)obj);
        }
        //</snippet15>
    }

    // Snippet 1010, for Cancellation
    public sealed class ParallelForEach : NativeActivity
    {
        Variable<bool> hasCompleted;
        CompletionCallback<bool> onConditionComplete;

        public ParallelForEach()
            : base()
        {
        }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<IEnumerable> Values
        {
            get;
            set;
        }

        [DefaultValue(null)]
        [DependsOn("Values")]
        public Activity<bool> CompletionCondition
        {
            get;
            set;
        }

        [Browsable(false)]
        [DefaultValue(null)]
        [DependsOn("CompletionCondition")]
        public ActivityAction<object> Body
        {
            get;
            set;
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            RuntimeArgument valuesArgument = new RuntimeArgument("Values", typeof(IEnumerable), ArgumentDirection.In, true);
            metadata.Bind(this.Values, valuesArgument);
            metadata.SetArgumentsCollection(new Collection<RuntimeArgument> { valuesArgument });

            // declare the CompletionCondition as a child
            if (this.CompletionCondition != null)
            {
                metadata.SetChildrenCollection(new Collection<Activity> { this.CompletionCondition });
            }

            // declare the hasCompleted variable
            if (this.CompletionCondition != null)
            {
                this.hasCompleted ??= new Variable<bool>();

                metadata.AddImplementationVariable(this.hasCompleted);
            }

            metadata.AddDelegate(this.Body);
        }

        protected override void Execute(NativeActivityContext context)
        {
            IEnumerable values = this.Values.Get(context);
            if (values == null)
            {
                throw new InvalidOperationException("ParallelForEach requires a non-null Values argument.");
            }

            IEnumerator valueEnumerator = values.GetEnumerator();

            CompletionCallback onBodyComplete = new CompletionCallback(OnBodyComplete);
            while (valueEnumerator.MoveNext())
            {
                if (this.Body != null)
                {
                    context.ScheduleAction(this.Body, valueEnumerator.Current, onBodyComplete);
                }
            }
            IDisposable disposable = valueEnumerator as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        //<snippet1010>
        protected override void Cancel(NativeActivityContext context)
        {
            // If we do not have a completion condition then we can just
            // use default logic.
            if (this.CompletionCondition == null)
            {
                base.Cancel(context);
            }
            else
            {
                context.CancelChildren();
            }
        }
        //<</snippet1010>

        void OnBodyComplete(NativeActivityContext context, ActivityInstance completedInstance)
        {
            // for the completion condition, we handle cancelation ourselves
            if (this.CompletionCondition != null && !this.hasCompleted.Get(context))
            {
                if (completedInstance.State != ActivityInstanceState.Closed && context.IsCancellationRequested)
                {
                    // If we hadn't completed before getting canceled
                    // or one of our iteration of body cancels then we'll consider
                    // ourself canceled.
                    context.MarkCanceled();
                    this.hasCompleted.Set(context, true);
                }
                else
                {
                    this.onConditionComplete ??= new CompletionCallback<bool>(OnConditionComplete);
                    context.ScheduleActivity(CompletionCondition, this.onConditionComplete);
                }
            }
        }

        void OnConditionComplete(NativeActivityContext context, ActivityInstance completedInstance, bool result)
        {
            if (result)
            {
                context.CancelChildren();
                this.hasCompleted.Set(context, true);
            }
        }
    }

    // Snippet1020 - AsyncCodeActivity Cancellation
    // non functional class for compilation
    class Pipeline
    {
        public void Stop() { }
    }

    sealed class ExecutePowerShell : AsyncCodeActivity
    {

        //<snippet1020>
        // Called by the runtime to cancel the execution of this asynchronous activity.
        protected override void Cancel(AsyncCodeActivityContext context)
        {
            Pipeline pipeline = context.UserState as Pipeline;
            if (pipeline != null)
            {
                pipeline.Stop();
                DisposePipeline(pipeline);
            }
            base.Cancel(context);
        }
        //</snippet1020>

        private void DisposePipeline(Pipeline pipeline)
        {
            throw new NotImplementedException();
        }

        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        protected override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            throw new NotImplementedException();
        }
    }
}
