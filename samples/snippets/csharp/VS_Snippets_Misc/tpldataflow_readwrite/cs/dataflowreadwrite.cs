// <1>
using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

// Demonstrates a how to write to and read from a dataflow block.
class DataflowReadWrite
{
    // Demonstrates asynchronous dataflow operations.
    static async Task AsyncSendReceive(BufferBlock<int> bufferBlock)
    {
        // <5>
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

        // Output:
        //   0
        //   1
        //   2
        // </5>
    }

    static async Task Main()
    {
        // <2>
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

        // Output:
        //   0
        //   1
        //   2
        // </2>

        // <3>
        // Post more messages to the block.
        for (int i = 0; i < 3; i++)
        {
            bufferBlock.Post(i);
        }

        // Receive the messages back from the block.
        while (bufferBlock.TryReceive(out int value))
        {
            Console.WriteLine(value);
        }

        // Output:
        //   0
        //   1
        //   2
        // </3>

        // <4>
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

        await Task.WhenAll(post01, receive, post2);

        // Output:
        //   0
        //   1
        //   2
        // </4>

        // Demonstrate asynchronous dataflow operations.
        await AsyncSendReceive(bufferBlock);
    }
}
// </1>