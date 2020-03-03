//<snippet1>
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

class Example
{
    // Demonstrates:
    //      ConcurrentStack<T>.Push();
    //      ConcurrentStack<T>.TryPeek();
    //      ConcurrentStack<T>.TryPop();
    //      ConcurrentStack<T>.Clear();
    //      ConcurrentStack<T>.IsEmpty;
    static async Task Main()
    {
        int items = 10000;

        ConcurrentStack<int> stack = new ConcurrentStack<int>();

        // Create an action to push items onto the stack
        Action pusher = () =>
        {
            for (int i = 0; i < items; i++)
            {
                stack.Push(i);
            }
        };

        // Run the action once
        pusher();

        if (stack.TryPeek(out int result))
        {
            Console.WriteLine($"TryPeek() saw {result} on top of the stack.");
        }
        else
        {
            Console.WriteLine("Could not peek most recently added number.");
        }

        // Empty the stack
        stack.Clear();

        if (stack.IsEmpty)
        {
            Console.WriteLine("Cleared the stack.");
        }

        // Create an action to push and pop items
        Action pushAndPop = () =>
        {
            Console.WriteLine($"Task started on {Task.CurrentId}");

            int item;
            for (int i = 0; i < items; i++)
                stack.Push(i);
            for (int i = 0; i < items; i++)
                stack.TryPop(out item);

            Console.WriteLine($"Task ended on {Task.CurrentId}");
        };

        // Spin up five concurrent tasks of the action
        var tasks = new Task[5];
        for (int i = 0; i < tasks.Length; i++)
            tasks[i] = Task.Factory.StartNew(pushAndPop);

        // Wait for all the tasks to finish up
        await Task.WhenAll(tasks);

        if (!stack.IsEmpty)
        {
            Console.WriteLine("Did not take all the items off the stack");
        }
    }
}
//</snippet1>
