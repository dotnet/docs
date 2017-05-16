// <snippet1>
using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

// Demonstrates a basic producer and consumer pattern that uses dataflow.
class DataflowProducerConsumer
{
   // Demonstrates the production end of the producer and consumer pattern.
   static void Produce(ITargetBlock<byte[]> target)
   {
      // Create a Random object to generate random data.
      Random rand = new Random();

      // In a loop, fill a buffer with random data and
      // post the buffer to the target block.
      for (int i = 0; i < 100; i++)
      {
         // Create an array to hold random byte data.
         byte[] buffer = new byte[1024];

         // Fill the buffer with random bytes.
         rand.NextBytes(buffer);

         // Post the result to the message block.
         target.Post(buffer);
      }

      // Set the target to the completed state to signal to the consumer
      // that no more data will be available.
      target.Complete();
   }

   // Demonstrates the consumption end of the producer and consumer pattern.
   static async Task<int> ConsumeAsync(ISourceBlock<byte[]> source)
   {
      // Initialize a counter to track the number of bytes that are processed.
      int bytesProcessed = 0;

      // Read from the source buffer until the source buffer has no 
      // available output data.
      while (await source.OutputAvailableAsync())
      {
         byte[] data = source.Receive();

         // Increment the count of bytes received.
         bytesProcessed += data.Length;
      }

      return bytesProcessed;
   }

   static void Main(string[] args)
   {
      // Create a BufferBlock<byte[]> object. This object serves as the 
      // target block for the producer and the source block for the consumer.
      var buffer = new BufferBlock<byte[]>();

      // Start the consumer. The Consume method runs asynchronously. 
      var consumer = ConsumeAsync(buffer);

      // Post source data to the dataflow block.
      Produce(buffer);

      // Wait for the consumer to process all data.
      consumer.Wait();

      // Print the count of bytes processed to the console.
      Console.WriteLine("Processed {0} bytes.", consumer.Result);
   }
}

/* Output:
Processed 102400 bytes.
*/
// </snippet1>

class Program2
{
   // <snippet2>
   // Demonstrates the consumption end of the producer and consumer pattern.
   static async Task<int> ConsumeAsync(IReceivableSourceBlock<byte[]> source)
   {
      // Initialize a counter to track the number of bytes that are processed.
      int bytesProcessed = 0;

      // Read from the source buffer until the source buffer has no 
      // available output data.
      while (await source.OutputAvailableAsync())
      {
         byte[] data;
         while (source.TryReceive(out data))
         {
            // Increment the count of bytes received.
            bytesProcessed += data.Length;
         }
      }

      return bytesProcessed;
   }
   // </snippet2>
}