using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Threading;

// Makefile
/*
all: WorkflowInvokerExample.exe

WorkflowInvokerExample.exe: Program.cs
 csc /t:exe Program.cs /r:System.dll /r:System.Activities.dll /r:System.Xaml.dll /r:System.Xml.dll
*/

// Taken
// Snippet 1,2, 3
// Snippet 10/110
// Snippet 20,21,22,23 - 120,121
// Snippet 30,31,32,33 - 130,131
// Snippet 40
// Snippet 50, 51

namespace WorkflowInvokerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Snippet1();
            //snippet10();
            //Snippet50();
            //snippet31();

            //Snippet51();

            //snippet22();

            //WorkflowInvokerExample2.RunMyCode.
            //WorkflowInvokerExample2.RunMyCode.snippet21();
            //WorkflowInvokerExample2.RunMyCode.snippet23();

            //Snippet51();

            //snippet31();
            BeginInvokeExample();
            //snippet33();
            //snippet34();
        }

        // Using WorkflowInvoker and WorkflowApplication
        // WorkflowInvoker Overview
        static void Snippet1()
        {
            //<snippet1>
            Activity wf = new WriteLine
            {
                Text = "Hello World."
            };

            WorkflowInvoker.Invoke(wf);
            //</snippet1>
        }

        static void Snippet2()
        {
            //<snippet2>
            Activity wf = new WriteLine
            {
                Text = "Hello World."
            };

            WorkflowInvoker invoker = new WorkflowInvoker(wf);

            invoker.Invoke();
            //</snippet2>
        }

        // Using WorkflowInvoker and WorkflowApplication
        static void Snippet3()
        {
            //<snippet3>
            Activity wf = new WriteLine();

            Dictionary<string, object> inputs = new Dictionary<string, object>();
            inputs.Add("Text", "Hello World.");

            WorkflowInvoker.Invoke(wf, inputs);
            //</snippet3>
        }

        static void snippet10()
        {
            //<snippet10>
            int x = 1;
            int y = 2;

            Dictionary<string, object> arguments = new Dictionary<string, object>();
            arguments.Add("X", x);
            arguments.Add("Y", y);

            Console.WriteLine("Invoking Add.");

            int result = WorkflowInvoker.Invoke(new Add(), arguments);

            Console.WriteLine($"{x} + {y} = {result}");
            //</snippet10>
        }

        static void snippet20()
        {
            //<snippet20>
            int dividend = 500;
            int divisor = 36;

            Dictionary<string, object> arguments = new Dictionary<string, object>();
            arguments.Add("Dividend", dividend);
            arguments.Add("Divisor", divisor);

            IDictionary<string, object> outputs =
                WorkflowInvoker.Invoke(new Divide(), arguments);

            Console.WriteLine($"{dividend} / {divisor} = {outputs["Result"]} Remainder {outputs["Remainder"]}");
            //</snippet20>
        }

        static void snippet22()
        {
            //<snippet22>
            int dividend = 500;
            int divisor = 36;

            Dictionary<string, object> arguments = new Dictionary<string, object>();
            arguments.Add("Dividend", dividend);
            arguments.Add("Divisor", divisor);

            WorkflowInvoker invoker = new WorkflowInvoker(new Divide());

            IDictionary<string, object> outputs = invoker.Invoke(arguments);

            Console.WriteLine($"{dividend} / {divisor} = {outputs["Result"]} Remainder {outputs["Remainder"]}");
            //</snippet22>
        }

        static void snippet30()
        {
            //<snippet30>
            IDictionary<string, object> outputs =
                WorkflowInvoker.Invoke(new DiceRoll());

            Console.WriteLine($"The two dice are {outputs["D1"]} and {outputs["D2"]}.");
            //</snippet30>
        }

        static void snippet31()
        {
            //<snippet31>
            WorkflowInvoker invoker = new WorkflowInvoker(new DiceRoll());

            IDictionary<string, object> outputs =
                invoker.Invoke();

            Console.WriteLine($"The two dice are {outputs["D1"]} and {outputs["D2"]}.");

            outputs = invoker.Invoke();

            Console.WriteLine($"The next two dice are {outputs["D1"]} and {outputs["D2"]}.");
            //</snippet31>
        }

        // BeginInvoke with LongRunningDiceRoll
        //<snippet32>
        static void BeginInvokeExample()
        {
            WorkflowInvoker invoker = new WorkflowInvoker(new LongRunningDiceRoll());

            string userState = "BeginInvoke example";
            IAsyncResult result = invoker.BeginInvoke(new AsyncCallback(WorkflowCompletedCallback), userState);

            // You can inspect result from the host to determine if the workflow
            // is complete.
            Console.WriteLine($"result.IsCompleted: {result.IsCompleted}");

            // The results of the workflow are retrieved by calling EndInvoke, which
            // can be called from the callback or from the host. If called from the
            // host, it blocks until the workflow completes. If a callback is not
            // required, pass null for the callback parameter.
            Console.WriteLine("Waiting for the workflow to complete.");
            IDictionary<string, object> outputs = invoker.EndInvoke(result);

            Console.WriteLine($"The two dice are {outputs["D1"]} and {outputs["D2"]}.");
        }

        static void WorkflowCompletedCallback(IAsyncResult result)
        {
            Console.WriteLine("Workflow complete.");
        }
        //</snippet32>

        // InvokeAsync
        static void snippet33()
        {
            //<snippet33>
            AutoResetEvent syncEvent = new AutoResetEvent(false);

            WorkflowInvoker invoker = new WorkflowInvoker(new LongRunningDiceRoll());

            invoker.InvokeCompleted += delegate(object sender, InvokeCompletedEventArgs args)
            {
                if (args.Cancelled == true)
                {
                    Console.WriteLine("Workflow was cancelled.");
                }
                else if (args.Error != null)
                {
                    Console.WriteLine($"Exception: {args.Error.GetType().FullName}\n{args.Error.Message}");
                }
                else
                {
                    Console.WriteLine($"The two dice are {args.Outputs["D1"]} and {args.Outputs["D2"]}.");
                }

                syncEvent.Set();
            };

            invoker.InvokeAsync("InvokeAsync Example");

            Console.WriteLine("Waiting for the workflow to complete.");

            // Wait for the workflow to complete.
            syncEvent.WaitOne();

            Console.WriteLine("The workflow is complete.");
            //</snippet33>
        }

        // CancelAsync
        static void snippet34()
        {
            //<snippet34>
            AutoResetEvent syncEvent = new AutoResetEvent(false);

            WorkflowInvoker invoker = new WorkflowInvoker(new LongRunningDiceRoll());

            invoker.InvokeCompleted += delegate(object sender, InvokeCompletedEventArgs args)
            {
                if (args.Cancelled == true)
                {
                    Console.WriteLine("The workflow was cancelled.");
                }
                else if (args.Error != null)
                {
                    Console.WriteLine($"Exception: {args.Error.GetType().FullName}\n{args.Error.Message}");
                }
                else
                {
                    Console.WriteLine($"The two dice are {args.Outputs["D1"]} and {args.Outputs["D2"]}.");
                }

                syncEvent.Set();
            };

            string userState = "CancelAsync Example";
            invoker.InvokeAsync(userState);

            Console.WriteLine("Waiting for the workflow to complete.");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            Console.WriteLine("Attempting to cancel the workflow.");
            invoker.CancelAsync(userState);

            // Wait for the workflow to complete.
            syncEvent.WaitOne();

            Console.WriteLine("The workflow is either completed or cancelled.");
            //</snippet34>
        }

        // WorkflowInvoker.Extensions Property
        // Excerpts from Custom Tracking Sample
        static void snippet40()
        {
            // to get to compile, this is not a functional running snippet
            object customTrackingParticipant = new object();

            //<snippet40>
            WorkflowInvoker invoker = new WorkflowInvoker(BuildSampleWorkflow());
            invoker.Extensions.Add(customTrackingParticipant);

            invoker.Invoke();
            //</snippet40>
        }

        // unused in docs
        //<snippet41>
        static Activity BuildSampleWorkflow()
        {
            return new Sequence()
            {
                Activities =
                {
                    new WriteLine() { Text = "Begin Workflow" },
                    new CustomActivity(),
                    new WriteLine() { Text = "End Workflow" },
                }
            };
        }
        //</snippet41>
        // End WorkflowInvoker.Extensions property snippets

        // Using WorkflowInvoker and WorkflowApplication
        // Timeout interval
        static void Snippet50()
        {
            //<snippet50>
            Activity wf = new Sequence()
            {
                Activities =
                {
                    new WriteLine()
                    {
                        Text = "Before the 1 minute delay."
                    },
                    new Delay()
                    {
                        Duration = TimeSpan.FromMinutes(1)
                    },
                    new WriteLine()
                    {
                        Text = "After the 1 minute delay."
                    }
                }
            };

            // This workflow completes successfully.
            WorkflowInvoker.Invoke(wf, TimeSpan.FromMinutes(2));

            // This workflow does not complete and a TimeoutException
            // is thrown.
            try
            {
                WorkflowInvoker.Invoke(wf, TimeSpan.FromSeconds(30));
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //</snippet50>
        }

        static void Snippet51()
        {
            //<snippet51>
            Activity wf = new Sequence()
            {
                Activities =
                {
                    new WriteLine()
                    {
                        Text = "Before the 1 minute delay."
                    },
                    new Delay()
                    {
                        Duration = TimeSpan.FromMinutes(1)
                    },
                    new WriteLine()
                    {
                        Text = "After the 1 minute delay."
                    }
                }
            };

            WorkflowInvoker invoker = new WorkflowInvoker(wf);

            // This workflow completes successfully.
            invoker.Invoke(TimeSpan.FromMinutes(2));

            // This workflow does not complete and a TimeoutException
            // is thrown.
            try
            {
                invoker.Invoke(TimeSpan.FromSeconds(30));
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //</snippet51>
        }
    }

    // For Snippet 40,41 for WorkflowInvoker.Extensions
    public sealed class CustomActivity : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            throw new NotImplementedException();
        }
    }

    //<snippet110>
    public sealed class Add : CodeActivity<int>
    {
        public InArgument<int> X { get; set; }
        public InArgument<int> Y { get; set; }

        protected override int Execute(CodeActivityContext context)
        {
            int x = X.Get(context);
            int y = Y.Get(context);

            return x + y;
        }
    }
    //</snippet110>

    // From OutArgument Generic Class
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

    public sealed class RandomNumberGenerator : CodeActivity
    {
        public OutArgument<int> Result;

        protected override void Execute(CodeActivityContext context)
        {
            int result = new Random().Next(1, 101);

            Result.Set(context, result);
        }
    }

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

    // WorkflowInvoker
    // Activity.Implementation
    //<snippet131>
    public sealed class LongRunningDiceRoll : Activity
    {
        public OutArgument<int> D1 { get; set; }
        public OutArgument<int> D2 { get; set; }

        public LongRunningDiceRoll()
        {
            this.Implementation = () => new Sequence
            {
                Activities =
                {
                    new WriteLine
                    {
                        Text = "Rolling the dice for 5 seconds."
                    },
                    new Delay
                    {
                        Duration = TimeSpan.FromSeconds(5)
                    },
                    new DiceRoll
                    {
                        D1 = new OutArgument<int>(env => this.D1.Get(env)),
                        D2 = new OutArgument<int>(env => this.D2.Get(env))
                    }
                }
            };
        }
    }
    //</snippet131>

    // This was the old way, I can assign directly from
    // the DiceRoll to the out arguments without the variables
    // or the Assign activities
    //public sealed class LongRunningDiceRoll : Activity
    //{
    //    public OutArgument<int> D1 { get; set; }
    //    public OutArgument<int> D2 { get; set; }

    //    public LongRunningDiceRoll()
    //    {
    //        Variable<int> d1 = new Variable<int>();
    //        Variable<int> d2 = new Variable<int>();

    //        this.Implementation = () => new Sequence
    //        {
    //            Variables = { d1, d2 },
    //            Activities =
    //            {
    //                new WriteLine
    //                {
    //                    Text = "Rolling the dice for 5 seconds."
    //                },
    //                new Delay
    //                {
    //                    Duration = TimeSpan.FromSeconds(5)
    //                },
    //                new DiceRoll
    //                {
    //                    D1 = new OutArgument<int>(d1),
    //                    D2 = new OutArgument<int>(d2)
    //                },
    //                new Assign<int>
    //                {
    //                    Value = new InArgument<int>(d1),
    //                    To = new OutArgument<int>(env => this.D1.Get(env))
    //                },
    //                new Assign<int>
    //                {
    //                    Value = new InArgument<int>(d2),
    //                    To = new OutArgument<int>(env => this.D2.Get(env))
    //                }
    //            }
    //        };
    //    }
    //}
}

namespace WorkflowExampleX
{
    class RunMyCode
    {
        static void SnippetX()
        {
        }
    }
}

namespace WorkflowInvokerExample2
{
    //<snippet121>
    public sealed class Divide : CodeActivity<int>
    {
        public InArgument<int> Dividend { get; set; }
        public InArgument<int> Divisor { get; set; }
        public OutArgument<int> Remainder { get; set; }

        protected override int Execute(CodeActivityContext context)
        {
            int quotient = Dividend.Get(context) / Divisor.Get(context);
            int remainder = Dividend.Get(context) % Divisor.Get(context);

            Remainder.Set(context, remainder);

            return quotient;
        }
    }
    //</snippet121>

    public sealed class RandomNumberGenerator : CodeActivity<int>
    {
        protected override int Execute(CodeActivityContext context)
        {
            return new Random().Next(1, 101);
        }
    }

    public class RunMyCode
    {
        public static void snippet21()
        {
            //<snippet21>
            int dividend = 500;
            int divisor = 36;

            Dictionary<string, object> arguments = new Dictionary<string, object>();
            arguments.Add("Dividend", dividend);
            arguments.Add("Divisor", divisor);

            Activity wf = new Divide();

            IDictionary<string, object> outputs =
                WorkflowInvoker.Invoke(wf, arguments);

            Console.WriteLine($"{dividend} / {divisor} = {outputs["Result"]} Remainder {outputs["Remainder"]}");
            //</snippet21>
        }

        public static void snippet23()
        {
            //<snippet23>
            int dividend = 500;
            int divisor = 36;

            Dictionary<string, object> arguments = new Dictionary<string, object>();
            arguments.Add("Dividend", dividend);
            arguments.Add("Divisor", divisor);

            Activity wf = new Divide();

            WorkflowInvoker invoker = new WorkflowInvoker(wf);

            IDictionary<string, object> outputs = invoker.Invoke(arguments);

            Console.WriteLine($"{dividend} / {divisor} = {outputs["Result"]} Remainder {outputs["Remainder"]}");
            //</snippet23>
        }
    }
}
