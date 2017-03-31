//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------


using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Activities.Statements;
using System.Runtime.DurableInstancing;
using System.Threading;

namespace Microsoft.Samples.PersistenceParticipants
{

    class Program
    {
        static SqlWorkflowInstanceStore instanceStore;
        static Guid id = Guid.NewGuid();
        static Activity workflow = CreateWorkflow();

        const int totalSteps = 3;
        const string echoPromptBookmark = "EchoPrompt1";

        static void Main()
        {
            SetupInstanceStore();

            Run();

            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
        }

        static void Run()
        {
            AutoResetEvent applicationUnloaded = new AutoResetEvent(false);
            WorkflowApplication application = new WorkflowApplication(workflow);
            application.InstanceStore = instanceStore;
            SetupApplication(application, applicationUnloaded);

            StepCountExtension stepCountExtension = new StepCountExtension();
            application.Extensions.Add(stepCountExtension);

            application.Run();
            Guid id = application.Id;
            applicationUnloaded.WaitOne();

            while (stepCountExtension.CurrentCount < totalSteps)
            {
                application = new WorkflowApplication(workflow);
                application.InstanceStore = instanceStore;
                SetupApplication(application, applicationUnloaded);
            
                stepCountExtension = new StepCountExtension();
                application.Extensions.Add(stepCountExtension);
                application.Load(id);

                string input = Console.ReadLine();

                application.ResumeBookmark(echoPromptBookmark, input);
                applicationUnloaded.WaitOne();
            }
        }

        static void SetupApplication(WorkflowApplication application, AutoResetEvent applicationUnloaded)
        {
            application.PersistableIdle = workflowApplicationIdleEventArgs => PersistableIdleAction.Unload;
            application.Unloaded = workflowApplicationEventArgs => applicationUnloaded.Set();
            application.OnUnhandledException = workflowApplicationUnhandledExceptionEventArgs => 
            { 
                Console.WriteLine(workflowApplicationUnhandledExceptionEventArgs.UnhandledException); 
                return UnhandledExceptionAction.Terminate; 
            };
        }

        static Sequence CreateWorkflow()
        {
            Variable<int> count = new Variable<int> { Name = "count", Default = totalSteps };
            Variable<int> stepsCounted = new Variable<int> { Name = "stepsCounted" };

            return new Sequence()
            {
                Variables = { count, stepsCounted },
                Activities = 
                { 
                    new While((env) => count.Get(env) > 0)
                    {
                        Body = new Sequence 
                        {
                            Activities = 
                            {
                                new EchoPrompt {BookmarkName = echoPromptBookmark },
                                new IncrementStepCount(),
                                new Assign<int>{ To = new OutArgument<int>(count), Value = new InArgument<int>((context) => count.Get(context) - 1)}
                            }
                        }
                    },
                    new GetCurrentStepCount {Result = new OutArgument<int>(stepsCounted )},
                    new WriteLine { Text = new InArgument<string>((context) => "there were " + stepsCounted.Get(context) + " steps in this program")}}
            };
        }
//<Snippet1>
        static void SetupInstanceStore()
        {
            instanceStore =
                new SqlWorkflowInstanceStore(@"Data Source=.\SQLEXPRESS;Initial Catalog=SampleInstanceStore;Integrated Security=True;Asynchronous Processing=True");
            InstanceHandle handle = instanceStore.CreateInstanceHandle();
            InstanceView view = instanceStore.Execute(handle, new CreateWorkflowOwnerCommand(), TimeSpan.FromSeconds(30));
            handle.Free();
            instanceStore.DefaultInstanceOwner = view.InstanceOwner;
        }
//</Snippet1>
    }
}
