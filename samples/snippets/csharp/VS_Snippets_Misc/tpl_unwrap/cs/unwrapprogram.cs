using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// How to: Unwrap a Nested Task
class IntroSnippets
{
    //<snippet01>
    static Task<string> DoWorkAsync()
    {
        return Task<String>.Factory.StartNew(() =>
        {
           //...
            return "Work completed.";
        });
    }

    static void StartTask()
    {
        Task<String> t = DoWorkAsync();
        t.Wait();
        Console.WriteLine(t.Result);
    }
    //</snippet01>

    static void Main()
    {
        //<snippet02>
        // Note the type of t and t2.
        Task<Task<string>> t = Task.Factory.StartNew(() => DoWorkAsync());
        Task<Task<string>> t2 = DoWorkAsync().ContinueWith((s) => DoMoreWorkAsync());

        // Outputs: System.Threading.Tasks.Task`1[System.String]
        Console.WriteLine(t.Result);
        //</snippet02>

        //<snippet03>
        // Unwrap the inner task.
        Task<string> t3 = DoWorkAsync().ContinueWith((s) => DoMoreWorkAsync()).Unwrap();

        // Outputs "More work completed."
        Console.WriteLine(t.Result);
        //</snippet03>

        Console.ReadKey();
    }

    static Task<string> DoMoreWorkAsync()
    {
        return Task<String>.Factory.StartNew(() =>
        {
            //...
            return "More work completed.";
        });
    }
}

//<snippet04>

namespace Unwrap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    // A program whose only use is to demonstrate Unwrap.
    class Program
    {
        static void Main()
        {
            // An arbitrary threshold value.
            byte threshold = 0x40;

            // data is a Task<byte[]>
            var data = Task<byte[]>.Factory.StartNew(() =>
                {
                    return GetData();
                });

            // We want to return a task so that we can
            // continue from it later in the program.
            // Without Unwrap: stepTwo is a Task<Task<byte[]>>
            // With Unwrap: stepTwo is a Task<byte[]>
            var stepTwo = data.ContinueWith((antecedent) =>
                {
                    return Task<byte>.Factory.StartNew( () => Compute(antecedent.Result));
                })
                .Unwrap();

            // Without Unwrap: antecedent.Result = Task<byte>
            // and the following method will not compile.
            // With Unwrap: antecedent.Result = byte and
            // we can work directly with the result of the Compute method.
            var lastStep = stepTwo.ContinueWith( (antecedent) =>
                {
                    if (antecedent.Result >= threshold)
                    {
                      return Task.Factory.StartNew( () =>  Console.WriteLine($"Program complete. Final = 0x{stepTwo.Result:x} threshold = 0x{threshold):x}");
                    }
                    else
                    {
                        return DoSomeOtherAsynchronousWork(stepTwo.Result, threshold);
                    }
                });

            lastStep.Wait();
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        #region Dummy_Methods
        private static byte[] GetData()
        {
            Random rand = new Random();
            byte[] bytes = new byte[64];
            rand.NextBytes(bytes);
            return bytes;
        }

        static Task DoSomeOtherAsynchronousWork(int i, byte b2)
        {
            return Task.Factory.StartNew(() =>
                {
                    Thread.SpinWait(500000);
                    Console.WriteLine("Doing more work. Value was <= threshold");
                });
        }
        static byte Compute(byte[] data)
        {

            byte final = 0;
            foreach (byte item in data)
            {
                final ^= item;
                Console.WriteLine($"{final:x}");
            }
            Console.WriteLine("Done computing");
            return final;
        }
        #endregion
    }
}
//</snippet04>
