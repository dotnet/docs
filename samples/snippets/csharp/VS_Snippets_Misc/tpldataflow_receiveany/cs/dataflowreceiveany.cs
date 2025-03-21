// <snippet1>
using System;
using System.Threading;
using System.Threading.Tasks.Dataflow;

// Demonstrates how to unlink dataflow blocks.
class DataflowReceiveAny
{
   // Receives the value from the first provided source that has
   // a message.
   public static T ReceiveFromAny<T>(params ISourceBlock<T>[] sources)
   {
      // Create a WriteOnceBlock<T> object and link it to each source block.
      var writeOnceBlock = new WriteOnceBlock<T>(e => e);
      foreach (var source in sources)
      {
         // Setting MaxMessages to one instructs
         // the source block to unlink from the WriteOnceBlock<T> object
         // after offering the WriteOnceBlock<T> object one message.
         source.LinkTo(writeOnceBlock, new DataflowLinkOptions { MaxMessages = 1 });
      }
      // Return the first value that is offered to the WriteOnceBlock object.
      return writeOnceBlock.Receive();
   }

   // Demonstrates a function that takes several seconds to produce a result.
   static int TrySolution(int n, CancellationToken ct)
   {
      // Simulate a lengthy operation that completes within three seconds
      // or when the provided CancellationToken object is cancelled.
      SpinWait.SpinUntil(() => ct.IsCancellationRequested,
         new Random().Next(3000));

      // Return a value.
      return n + 42;
   }

   static void Main(string[] args)
   {
      // Create a shared CancellationTokenSource object to enable the
      // TrySolution method to be cancelled.
      var cts = new CancellationTokenSource();

      // Create three TransformBlock<int, int> objects.
      // Each TransformBlock<int, int> object calls the TrySolution method.
      Func<int, int> action = n => TrySolution(n, cts.Token);
      var trySolution1 = new TransformBlock<int, int>(action);
      var trySolution2 = new TransformBlock<int, int>(action);
      var trySolution3 = new TransformBlock<int, int>(action);

      // Post data to each TransformBlock<int, int> object.
      trySolution1.Post(11);
      trySolution2.Post(21);
      trySolution3.Post(31);

      // Call the ReceiveFromAny<T> method to receive the result from the
      // first TransformBlock<int, int> object to finish.
      int result = ReceiveFromAny(trySolution1, trySolution2, trySolution3);

      // Cancel all calls to TrySolution that are still active.
      cts.Cancel();

      // Print the result to the console.
      Console.WriteLine($"The solution is {result}.");

      cts.Dispose();
   }
}

/* Sample output:
The solution is 53.
*/
// </snippet1>