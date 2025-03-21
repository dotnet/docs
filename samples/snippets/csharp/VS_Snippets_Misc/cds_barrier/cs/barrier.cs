//<snippet01>
//#define TRACE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarrierSimple
{
    class Program
    {
        static string[] words1 = new string[] { "brown",  "jumps", "the", "fox", "quick"};
        static string[] words2 = new string[] { "dog", "lazy","the","over"};
        static string solution = "the quick brown fox jumps over the lazy dog.";

        static bool success = false;
        static Barrier barrier = new Barrier(2, (b) =>
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < words1.Length; i++)
            {
                sb.Append(words1[i]);
                sb.Append(" ");
            }
            for (int i = 0; i < words2.Length; i++)
            {
                sb.Append(words2[i]);

                if(i < words2.Length - 1)
                    sb.Append(" ");
            }
            sb.Append(".");
#if TRACE
            System.Diagnostics.Trace.WriteLine(sb.ToString());
#endif
            Console.CursorLeft = 0;
            Console.Write("Current phase: {0}", barrier.CurrentPhaseNumber);
            if (String.CompareOrdinal(solution, sb.ToString()) == 0)
            {
                success = true;
                Console.WriteLine($"\r\nThe solution was found in {barrier.CurrentPhaseNumber} attempts");
            }
        });

        static void Main(string[] args)
        {

            Thread t1 = new Thread(() => Solve(words1));
            Thread t2 = new Thread(() => Solve(words2));
            t1.Start();
            t2.Start();

            // Keep the console window open.
            Console.ReadLine();
        }

        // Use Knuth-Fisher-Yates shuffle to randomly reorder each array.
        // For simplicity, we require that both wordArrays be solved in the same phase.
        // Success of right or left side only is not stored and does not count.
        static void Solve(string[] wordArray)
        {
            while(success == false)
            {
                Random random = new Random();
                for (int i = wordArray.Length - 1; i > 0; i--)
                {
                    int swapIndex = random.Next(i + 1);
                    string temp = wordArray[i];
                    wordArray[i] = wordArray[swapIndex];
                    wordArray[swapIndex] = temp;
                }

                // We need to stop here to examine results
                // of all thread activity. This is done in the post-phase
                // delegate that is defined in the Barrier constructor.
                barrier.SignalAndWait();
            }
        }
    }
}
//</snippet01>

class BarrierDemo
{

        static byte[][] data = new byte[10][];
        static byte[][] results = new byte[10][];

        static bool success = false;
        static bool someCondition = false;
    //<snippet02>

        // Create the Barrier object, and supply a post-phase delegate
        // to be invoked at the end of each phase.
        Barrier barrier = new Barrier(2, (bar) =>
            {
                // Examine results from all threads, determine
                // whether to continue, create inputs for next phase, etc.
                if (someCondition)
                    success = true;
            });

        // Define the work that each thread will perform. (Threads do not
        // have to all execute the same method.)
        void CrunchNumbers(int partitionNum)
        {
            // Up to System.Int64.MaxValue phases are supported. We assume
            // in this code that the problem will be solved before that.
            while (success == false)
            {
                // Begin phase:
                // Process data here on each thread, and optionally
                // store results, for example:
                results[partitionNum] = ProcessData(data[partitionNum]);

                // End phase:
                // After all threads arrive,post-phase delegate
                // is invoked, then threads are unblocked. Overloads
                // accept a timeout value and/or CancellationToken.
                barrier.SignalAndWait();
            }
        }

        // Perform n tasks to run in parallel. For simplicity
        // all threads execute the same method in this example.
        static void Main()
        {
            var app = new BarrierDemo();
            Thread t1 = new Thread(() => app.CrunchNumbers(0));
            Thread t2 = new Thread(() => app.CrunchNumbers(1));
            t1.Start();
            t2.Start();
        }
    //</snippet02>

     byte[] ProcessData(byte[] input)
        { return new byte[2]; }
}
