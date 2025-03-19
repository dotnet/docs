using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Activities.Expressions;
using System.Text;
using System.Threading;
using System.IO;

namespace ActivityExample
{
    // Using Activity Delegates
    // 1 WriteLineWithNotification
    // 2 Using the activity from #1
    // 3 WriteFillerText
    // 4 TextGenerator
    // 5 Using 3 & 4
    // 6 ForEach activity
    // 7 ForEach activity without object initializers
    // 8 GenerateRandom (Creating Asynchronous Activities)
    // 9 GenerateRandom Max (Creating Asynchronous Activities)
    // 10 Cancel AsyncCodeActivity method (Creating Asynchronous Activities)
    // 11 DisplayRandom (Creating Asynchronous Activities)
    // 12 FileWriter (Creating Asynchronous Activities) (from Async sample)
    class Program
    {
        static void Main(string[] args)
        {
            TestAsyncActivities();
        }

        static void snippet2()
        {
            //<snippet2>
            // Create and invoke the workflow without specifying any activity action
            // for TextProcessed.
            Activity wf = new WriteLineWithNotification
            {
                Text = "Hello World."
            };

            WorkflowInvoker.Invoke(wf);

            // Output:
            // Hello World.

            // Create and Invoke the workflow with specifying an activity action
            // for TextProcessed.
            DelegateInArgument<string> msg = new DelegateInArgument<string>();
            Activity wf2 = new WriteLineWithNotification
            {
                Text = "Hello World with activity action.",
                TextProcessedAction = new ActivityAction<string>
                {
                    Argument = msg,
                    Handler = new WriteLine
                    {
                        Text = new InArgument<string>((env) => "Handler of: " + msg.Get(env))
                    }
                }
            };

            // Invoke the workflow with an activity action specified
            WorkflowInvoker.Invoke(wf2);

            // Output:
            // Hello World with activity action.
            // Handler of: Hello World with activity action.
            //</snippet2>
        }

        static void snippet5()
        {
            //<snippet5>
            DelegateInArgument<int> actionArgument = new DelegateInArgument<int>();

            Activity wf = new WriteFillerText
            {
                Quantity = 5,
                GetText = new ActivityFunc<int, string>
                {
                    Argument = actionArgument,
                    Handler = new TextGenerator
                    {
                        Quantity = new InArgument<int>(actionArgument),
                        Text = "Hello World."
                    }
                }
            };

            WorkflowInvoker.Invoke(wf);
            //</snippet5>
        }

        static void snippet6()
        {
            //<snippet6>
            DelegateInArgument<string> actionArgument = new DelegateInArgument<string>();

            Activity wf = new ForEach<string>
            {
                Body = new ActivityAction<string>
                {
                    Argument = actionArgument,
                    Handler = new WriteLine
                    {
                        Text = new InArgument<string>(actionArgument)
                    }
                }
            };

            List<string> items = new List<string>();
            items.Add("Hello");
            items.Add("World.");

            Dictionary<string, object> inputs = new Dictionary<string, object>();
            inputs.Add("Values", items);

            WorkflowInvoker.Invoke(wf, inputs);
            //</snippet6>
        }

        static void snippet7()
        {
            //<snippet7>
            DelegateInArgument<string> actionArgument = new DelegateInArgument<string>();

            WriteLine output = new WriteLine();
            output.Text = new InArgument<string>(actionArgument);

            ActivityAction<string> body = new ActivityAction<string>();
            body.Argument = actionArgument;
            body.Handler = output;

            ForEach<string> wf = new ForEach<string>();
            wf.Body = body;

            List<string> items = new List<string>();
            items.Add("Hello");
            items.Add("World.");

            Dictionary<string, object> inputs = new Dictionary<string, object>();
            inputs.Add("Values", items);

            WorkflowInvoker.Invoke(wf, inputs);
            //</snippet7>
        }

        static void TestAsyncActivities()
        {
            //int result = WorkflowInvoker.Invoke(new GenerateRandom());
            //Console.WriteLine($"GenerateRandom: {result}");

            //var inputs = new Dictionary<string, object> { { "Max", 25 } };
            //int result2 = WorkflowInvoker.Invoke(new GenerateRandomMax(), inputs);
            //Console.WriteLine($"GenerateRandomMax: {result2}");

            WorkflowInvoker.Invoke(new DisplayRandom());
        }
    }

    //<snippet1>
    public class WriteLineWithNotification : Activity
    {
        public InArgument<string> Text { get; set; }
        public ActivityAction<string> TextProcessedAction { get; set; }

        public WriteLineWithNotification()
        {
            this.Implementation = () => new Sequence
            {
                Activities =
                {
                    new WriteLine
                    {
                        Text = new InArgument<string>((env) => Text.Get(env))
                    },
                    new InvokeAction<string>
                    {
                        Action = TextProcessedAction,
                        Argument = new InArgument<string>((env) => Text.Get(env))
                    }
                }
            };
        }
    }
    //</snippet1>

    //<snippet3>
    public class WriteFillerText : Activity
    {
        public ActivityFunc<int, string> GetText { get; set; }
        public InArgument<int> Quantity { get; set; }

        Variable<string> text = new Variable<string>
        {
            Name = "Text"
        };

        public WriteFillerText()
        {
            this.Implementation = () => new Sequence
            {
                Variables =
                {
                    text
                },
                Activities =
                {
                    new InvokeFunc<int, string>
                    {
                        Func = GetText,
                        Argument = new InArgument<int>((env) => Quantity.Get(env)),
                        Result = new OutArgument<string>(text)
                    },
                    new WriteLine
                    {
                        Text = new InArgument<string>(text)
                    }
                }
            };
        }
    }
    //</snippet3>

    //<snippet4>
    public class TextGenerator : CodeActivity<string>
    {
        public InArgument<int> Quantity { get; set; }
        public InArgument<string> Text { get; set; }

        protected override string Execute(CodeActivityContext context)
        {
            // Provide a quantity of Random Text
            int q = Quantity.Get(context);
            if (q < 1)
            {
                q = 1;
            }

            string text = Text.Get(context) + " ";
            StringBuilder sb = new StringBuilder(text.Length * q);
            for (int i = 0; i < q; i++)
            {
                sb.Append(text);
            }

            return sb.ToString();
        }
    }
    //</snippet4>

    //<snippet8>
    public sealed class GenerateRandom : AsyncCodeActivity<int>
    {
        static Random r = new Random();

        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            // Create a delegate that references the method that implements
            // the asynchronous work. Assign the delegate to the UserState,
            // invoke the delegate, and return the resulting IAsyncResult.
            Func<int> GetRandomDelegate = new Func<int>(GetRandom);
            context.UserState = GetRandomDelegate;
            return GetRandomDelegate.BeginInvoke(callback, state);
        }

        protected override int EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            // Get the delegate from the UserState and call EndInvoke
            Func<int> GetRandomDelegate = (Func<int>)context.UserState;
            return (int)GetRandomDelegate.EndInvoke(result);
        }

        int GetRandom()
        {
            // This activity simulates taking a few moments
            // to generate the random number. This code runs
            // asynchronously with respect to the workflow thread.
            Thread.Sleep(5000);

            return r.Next(1, 101);
        }
    }
    //</snippet8>

    //<snippet9>
    public sealed class GenerateRandomMax : AsyncCodeActivity<int>
    {
        public InArgument<int> Max { get; set; }

        static Random r = new Random();

        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            // Create a delegate that references the method that implements
            // the asynchronous work. Assign the delegate to the UserState,
            // invoke the delegate, and return the resulting IAsyncResult.
            Func<int, int> GetRandomDelegate = new Func<int, int>(GetRandom);
            context.UserState = GetRandomDelegate;
            return GetRandomDelegate.BeginInvoke(Max.Get(context), callback, state);
        }

        protected override int EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            // Get the delegate from the UserState and call EndInvoke
            Func<int, int> GetRandomDelegate = (Func<int, int>)context.UserState;
            return (int)GetRandomDelegate.EndInvoke(result);
        }

        int GetRandom(int max)
        {
            // This activity simulates taking a few moments
            // to generate the random number. This code runs
            // asynchronously with respect to the workflow thread.
            Thread.Sleep(5000);

            return r.Next(1, max + 1);
        }
    }
    //</snippet9>

    class CancelAsyncActivity : AsyncCodeActivity
    {
        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        protected override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        //<snippet10>
        protected override void Cancel(AsyncCodeActivityContext context)
        {
            // Implement any cleanup as a result of the asynchronous work
            // being canceled, and then call MarkCanceled.
            if (context.IsCancellationRequested)
            {
                context.MarkCanceled();
            }
        }
        //</snippet10>
    }

    //<snippet11>
    public sealed class DisplayRandom : AsyncCodeActivity
    {
        static Random r = new Random();

        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            // Create a delegate that references the method that implements
            // the asynchronous work. Assign the delegate to the UserState,
            // invoke the delegate, and return the resulting IAsyncResult.
            Action GetRandomDelegate = new Action(GetRandom);
            context.UserState = GetRandomDelegate;
            return GetRandomDelegate.BeginInvoke(callback, state);
        }

        protected override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            // Get the delegate from the UserState and call EndInvoke
            Action GetRandomDelegate = (Action)context.UserState;
            GetRandomDelegate.EndInvoke(result);
        }

        void GetRandom()
        {
            // This activity simulates taking a few moments
            // to generate the random number. This code runs
            // asynchronously with respect to the workflow thread.
            Thread.Sleep(5000);

            Console.WriteLine("Random Number: {0}", r.Next(1, 101));
        }
    }
    //</snippet11>

    //<snippet12>
    public sealed class FileWriter : AsyncCodeActivity
    {
        public FileWriter()
            : base()
        {
        }

        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            string tempFileName = Path.GetTempFileName();
            Console.WriteLine("Writing to file: " + tempFileName);

            FileStream file = File.Open(tempFileName, FileMode.Create);

            context.UserState = file;

            byte[] bytes = UnicodeEncoding.Unicode.GetBytes("123456789");
            return file.BeginWrite(bytes, 0, bytes.Length, callback, state);
        }

        protected override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            FileStream file = (FileStream)context.UserState;

            try
            {
                file.EndWrite(result);
                file.Flush();
            }
            finally
            {
                file.Close();
            }
        }
    }
    //</snippet12>
}
