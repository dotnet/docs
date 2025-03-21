using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Overview
{
   class Program
   {
      static void ShowBufferBlock()
      {
         // <snippet1>
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
         // </snippet1>
      }

      static void ShowBroadcastBlock()
      {
         // <snippet2>
         // Create a BroadcastBlock<double> object.
         var broadcastBlock = new BroadcastBlock<double>(null);

         // Post a message to the block.
         broadcastBlock.Post(Math.PI);

         // Receive the messages back from the block several times.
         for (int i = 0; i < 3; i++)
         {
            Console.WriteLine(broadcastBlock.Receive());
         }

         /* Output:
            3.14159265358979
            3.14159265358979
            3.14159265358979
          */
         // </snippet2>
      }

      static void ShowWriteOnceBlock()
      {
         // <snippet3>
         // Create a WriteOnceBlock<string> object.
         var writeOnceBlock = new WriteOnceBlock<string>(null);

         // Post several messages to the block in parallel. The first
         // message to be received is written to the block.
         // Subsequent messages are discarded.
         Parallel.Invoke(
            () => writeOnceBlock.Post("Message 1"),
            () => writeOnceBlock.Post("Message 2"),
            () => writeOnceBlock.Post("Message 3"));

         // Receive the message from the block.
         Console.WriteLine(writeOnceBlock.Receive());

         /* Sample output:
            Message 2
          */
         // </snippet3>
      }

      static void ShowActionBlock()
      {
         // <snippet4>
         // Create an ActionBlock<int> object that prints values
         // to the console.
         var actionBlock = new ActionBlock<int>(n => Console.WriteLine(n));

         // Post several messages to the block.
         for (int i = 0; i < 3; i++)
         {
            actionBlock.Post(i * 10);
         }

         // Set the block to the completed state and wait for all
         // tasks to finish.
         actionBlock.Complete();
         actionBlock.Completion.Wait();

         /* Output:
            0
            10
            20
          */
         // </snippet4>
      }

      static void ShowTransformBlock()
      {
         // <snippet5>
         // Create a TransformBlock<int, double> object that
         // computes the square root of its input.
         var transformBlock = new TransformBlock<int, double>(n => Math.Sqrt(n));

         // Post several messages to the block.
         transformBlock.Post(10);
         transformBlock.Post(20);
         transformBlock.Post(30);

         // Read the output messages from the block.
         for (int i = 0; i < 3; i++)
         {
            Console.WriteLine(transformBlock.Receive());
         }

         /* Output:
            3.16227766016838
            4.47213595499958
            5.47722557505166
          */
         // </snippet5>
      }

      static void ShowTransformManyBlock()
      {
         // <snippet6>
         // Create a TransformManyBlock<string, char> object that splits
         // a string into its individual characters.
         var transformManyBlock = new TransformManyBlock<string, char>(
            s => s.ToCharArray());

         // Post two messages to the first block.
         transformManyBlock.Post("Hello");
         transformManyBlock.Post("World");

         // Receive all output values from the block.
         for (int i = 0; i < ("Hello" + "World").Length; i++)
         {
            Console.WriteLine(transformManyBlock.Receive());
         }

         /* Output:
            H
            e
            l
            l
            o
            W
            o
            r
            l
            d
          */
         // </snippet6>
      }

      static void ShowBatchBlock()
      {
         // <snippet7>
         // Create a BatchBlock<int> object that holds ten
         // elements per batch.
         var batchBlock = new BatchBlock<int>(10);

         // Post several values to the block.
         for (int i = 0; i < 13; i++)
         {
            batchBlock.Post(i);
         }
         // Set the block to the completed state. This causes
         // the block to propagate out any remaining
         // values as a final batch.
         batchBlock.Complete();

         // Print the sum of both batches.

         Console.WriteLine("The sum of the elements in batch 1 is {0}.",
            batchBlock.Receive().Sum());

         Console.WriteLine("The sum of the elements in batch 2 is {0}.",
            batchBlock.Receive().Sum());

         /* Output:
            The sum of the elements in batch 1 is 45.
            The sum of the elements in batch 2 is 33.
          */
         // </snippet7>
      }

      static void ShowJoinBlock()
      {
         // <snippet8>
         // Create a JoinBlock<int, int, char> object that requires
         // two numbers and an operator.
         var joinBlock = new JoinBlock<int, int, char>();

         // Post two values to each target of the join.

         joinBlock.Target1.Post(3);
         joinBlock.Target1.Post(6);

         joinBlock.Target2.Post(5);
         joinBlock.Target2.Post(4);

         joinBlock.Target3.Post('+');
         joinBlock.Target3.Post('-');

         // Receive each group of values and apply the operator part
         // to the number parts.

         for (int i = 0; i < 2; i++)
         {
            var data = joinBlock.Receive();
            switch (data.Item3)
            {
               case '+':
                  Console.WriteLine($"{data.Item1} + {data.Item2} = {data.Item1 + data.Item2}");
                  break;
               case '-':
                  Console.WriteLine($"{data.Item1} - {data.Item2} = {data.Item1 - data.Item2}");
                  break;
               default:
                  Console.WriteLine($"Unknown operator '{data.Item3}'.");
                  break;
            }
         }

         /* Output:
            3 + 5 = 8
            6 - 4 = 2
          */
         // </snippet8>
      }

      static void ShowBatchedJoinBlock()
      {
         // <snippet9>
         // For demonstration, create a Func<int, int> that
         // returns its argument, or throws ArgumentOutOfRangeException
         // if the argument is less than zero.
         Func<int, int> DoWork = n =>
         {
            if (n < 0)
               throw new ArgumentOutOfRangeException();
            return n;
         };

         // Create a BatchedJoinBlock<int, Exception> object that holds
         // seven elements per batch.
         var batchedJoinBlock = new BatchedJoinBlock<int, Exception>(7);

         // Post several items to the block.
         foreach (int i in new int[] { 5, 6, -7, -22, 13, 55, 0 })
         {
            try
            {
               // Post the result of the worker to the
               // first target of the block.
               batchedJoinBlock.Target1.Post(DoWork(i));
            }
            catch (ArgumentOutOfRangeException e)
            {
               // If an error occurred, post the Exception to the
               // second target of the block.
               batchedJoinBlock.Target2.Post(e);
            }
         }

         // Read the results from the block.
         var results = batchedJoinBlock.Receive();

         // Print the results to the console.

         // Print the results.
         foreach (int n in results.Item1)
         {
            Console.WriteLine(n);
         }
         // Print failures.
         foreach (Exception e in results.Item2)
         {
            Console.WriteLine(e.Message);
         }

         /* Output:
            5
            6
            13
            55
            0
            Specified argument was out of the range of valid values.
            Specified argument was out of the range of valid values.
          */
         // </snippet9>
      }

      static void ShowCompletion()
      {
         // <snippet10>
         // Create an ActionBlock<int> object that prints its input
         // and throws ArgumentOutOfRangeException if the input
         // is less than zero.
         var throwIfNegative = new ActionBlock<int>(n =>
         {
            Console.WriteLine($"n = {n}");
            if (n < 0)
            {
               throw new ArgumentOutOfRangeException();
            }
         });

         // Post values to the block.
         throwIfNegative.Post(0);
         throwIfNegative.Post(-1);
         throwIfNegative.Post(1);
         throwIfNegative.Post(-2);
         throwIfNegative.Complete();

         // Wait for completion in a try/catch block.
         try
         {
            throwIfNegative.Completion.Wait();
         }
         catch (AggregateException ae)
         {
            // If an unhandled exception occurs during dataflow processing, all
            // exceptions are propagated through an AggregateException object.
            ae.Handle(e =>
            {
               Console.WriteLine("Encountered {0}: {1}",
                  e.GetType().Name, e.Message);
               return true;
            });
         }

         /* Output:
         n = 0
         n = -1
         Encountered ArgumentOutOfRangeException: Specified argument was out of the range
          of valid values.
         */
         // </snippet10>
      }

      static void ShowCompletionStatus()
      {
         // <snippet11>
         // Create an ActionBlock<int> object that prints its input
         // and throws ArgumentOutOfRangeException if the input
         // is less than zero.
         var throwIfNegative = new ActionBlock<int>(n =>
         {
            Console.WriteLine($"n = {n}");
            if (n < 0)
            {
               throw new ArgumentOutOfRangeException();
            }
         });

         // Create a continuation task that prints the overall
         // task status to the console when the block finishes.
         throwIfNegative.Completion.ContinueWith(task =>
         {
            Console.WriteLine($"The status of the completion task is '{task.Status}'.");
         });

         // Post values to the block.
         throwIfNegative.Post(0);
         throwIfNegative.Post(-1);
         throwIfNegative.Post(1);
         throwIfNegative.Post(-2);
         throwIfNegative.Complete();

         // Wait for completion in a try/catch block.
         try
         {
            throwIfNegative.Completion.Wait();
         }
         catch (AggregateException ae)
         {
            // If an unhandled exception occurs during dataflow processing, all
            // exceptions are propagated through an AggregateException object.
            ae.Handle(e =>
            {
               Console.WriteLine("Encountered {0}: {1}",
                  e.GetType().Name, e.Message);
               return true;
            });
         }

         /* Output:
         n = 0
         n = -1
         The status of the completion task is 'Faulted'.
         Encountered ArgumentOutOfRangeException: Specified argument was out of the range
          of valid values.
         */
         // </snippet11>
      }

      static void Main(string[] args)
      {
         //ShowBufferBlock();
         //ShowBroadcastBlock();
         //ShowWriteOnceBlock();
         //ShowActionBlock();
         //ShowTransformBlock();
         //ShowTransformManyBlock();
         //ShowBatchBlock();
         //ShowJoinBlock();
         //ShowBatchedJoinBlock();

         //ShowCompletion();
         //ShowCompletionStatus();
      }
   }
}
