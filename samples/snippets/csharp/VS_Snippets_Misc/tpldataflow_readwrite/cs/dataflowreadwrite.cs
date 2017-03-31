// <snippet1>
using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

// Demonstrates a how to write to and read from a dataflow block.
class DataflowReadWrite
{
   // Demonstrates asynchronous dataflow operations.
   static async Task AsyncSendReceive(BufferBlock<int> bufferBlock)
   {
      // <snippet5>
      // Post more messages to the block asynchronously.
      for (int i = 0; i < 3; i++)
      {
         await bufferBlock.SendAsync(i);
      }

      // Asynchronously receive the messages back from the block.
      for (int i = 0; i < 3; i++)
      {
         Console.WriteLine(await bufferBlock.ReceiveAsync());
      }

      /* Output:
         0
         1
         2
       */
      // </snippet5>
   }

   static void Main(string[] args)
   {
      // <snippet2>
      // Create a BufferBlock<int> object.
      var bufferBlock = new BufferBlock<int>();

      // Post several messages to the block.
      for (int i = 0; i < 3; i++)
      {
         bufferBlock.Post(i);
      }

      // Receive the messages back from the block.
      for (int i = 0; i < 3; i++)
      {
         Console.WriteLine(bufferBlock.Receive());
      }

      /* Output:
         0
         1
         2
       */
      // </snippet2>

      // <snippet3>
      // Post more messages to the block.
      for (int i = 0; i < 3; i++)
      {
         bufferBlock.Post(i);
      }

      // Receive the messages back from the block.
      int value;
      while (bufferBlock.TryReceive(out value))
      {
         Console.WriteLine(value);
      }

      /* Output:
         0
         1
         2
       */
      // </snippet3>

      // <snippet4>
      // Write to and read from the message block concurrently.
      var post01 = Task.Run(() =>
         {
            bufferBlock.Post(0);
            bufferBlock.Post(1);
         });
      var receive = Task.Run(() => 
         {
            for (int i = 0; i < 3; i++)
            {
               Console.WriteLine(bufferBlock.Receive());
            }
         });
      var post2 = Task.Run(() => 
         {
            bufferBlock.Post(2);
         });
      Task.WaitAll(post01, receive, post2);

      /* Sample output:
         2
         0
         1
       */
      // </snippet4>

      // Demonstrate asynchronous dataflow operations.
      AsyncSendReceive(bufferBlock).Wait();
   }
}
// </snippet1>