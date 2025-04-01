// <Snippet10>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example4
{
    public static void Main()
    {
        var tasks = new Task[3];
        var rnd = new Random();
        for (int ctr = 0; ctr <= 2; ctr++)
            tasks[ctr] = Task.Run(() => Thread.Sleep(rnd.Next(500, 3000)));

        try
        {
            int index = Task.WaitAny(tasks);
            Console.WriteLine($"Task #{tasks[index].Id} completed first.\n");
            Console.WriteLine("Status of all tasks:");
            foreach (var t in tasks)
                Console.WriteLine($"   Task #{t.Id}: {t.Status}");
        }
        catch (AggregateException)
        {
            Console.WriteLine("An exception occurred.");
        }
    }
}
// The example displays output like the following:
//     Task #1 completed first.
//     
//     Status of all tasks:
//        Task #3: Running
//        Task #1: RanToCompletion
//        Task #4: Running
// </Snippet10>




//         // Wait for first task to complete.
//         Task<double>[] tasks2 = new Task<double>[3];
// 
//         // Try three different approaches to the problem. Take the first one.
//         tasks2[0] = Task<double>.Factory.StartNew(() => TrySolution1());
//         tasks2[1] = Task<double>.Factory.StartNew(() => TrySolution2());
//         tasks2[2] = Task<double>.Factory.StartNew(() => TrySolution3());
// 
// 
//         int index = Task.WaitAny(tasks2);
//         double d = tasks2[index].Result;
//         Console.WriteLine($"task[{index}] completed first with result of {d}.");
// 
//         Console.ReadKey();
//     }
// 
// 
//     static void DoSomeWork(int val)
//     {
//         // Pretend to do something.
//         Thread.SpinWait(val);
//     }
// 
//     static double TrySolution1()
//     {
//         int i = rand.Next(1000000);
//         // Simulate work by spinning
//         Thread.SpinWait(i); 
//         return DateTime.Now.Millisecond;
//     }
//     static double TrySolution2()
//     {
//         int i = rand.Next(1000000);
//         // Simulate work by spinning
//         Thread.SpinWait(i); 
//         return DateTime.Now.Millisecond;
//     }
//     static double TrySolution3()
//     {
//         int i = rand.Next(1000000);
//         // Simulate work by spinning
//         Thread.SpinWait(i); 
//         Thread.SpinWait(1000000);
//         return DateTime.Now.Millisecond;
//     }
// 
