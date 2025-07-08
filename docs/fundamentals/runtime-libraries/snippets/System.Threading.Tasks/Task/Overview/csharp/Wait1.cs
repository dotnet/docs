// <Snippet8>
using System;   
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static Random rand = new Random();

    static void Main()
    {
        // Wait on a single task with no timeout specified.
        Task taskA = Task.Run( () => Thread.Sleep(2000));
        Console.WriteLine($"taskA Status: {taskA.Status}");
        try {
          taskA.Wait();
          Console.WriteLine($"taskA Status: {taskA.Status}");
       } 
       catch (AggregateException) {
          Console.WriteLine("Exception in taskA.");
       }   
    }    
}
// The example displays output like the following:
//     taskA Status: WaitingToRun
//     taskA Status: RanToCompletion
// </Snippet8>
