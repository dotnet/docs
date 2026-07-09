namespace IterationStatements;

public static class Program
{
    public static async Task Main()
    {
        ForeachExample();
        WhileExample();
        DoWhileExample();
        ForExample();
        BreakExample();
        ContinueExample();
        await AwaitForeachExample();
    }

    private static void ForeachExample()
    {
        // <Foreach>
        string[] names = ["Ana", "Ben", "Cleo"];

        // foreach reads each element in order. It's the default loop for
        // collections: no index to manage and no off-by-one mistakes.
        foreach (string name in names)
        {
            Console.WriteLine(name); // => Ana, then Ben, then Cleo
        }
        // </Foreach>
    }

    private static void WhileExample()
    {
        // <While>
        int countdown = 3;

        // A while loop checks its condition before each iteration, so the body
        // runs zero or more times.
        while (countdown > 0)
        {
            Console.WriteLine(countdown); // => 3, then 2, then 1
            countdown--;
        }
        // </While>
    }

    private static void DoWhileExample()
    {
        // <DoWhile>
        int attempts = 0;

        // A do-while loop runs its body once, then checks the condition. Use it
        // when the body must run at least one time.
        do
        {
            attempts++;
            Console.WriteLine($"Attempt {attempts}"); // => Attempt 1
        }
        while (attempts < 1);
        // </DoWhile>
    }

    private static void ForExample()
    {
        // <For>
        // A for loop fits when you need an explicit index. The three parts are
        // the initializer, the condition, and the iterator.
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(i); // => 0, then 1, then 2
        }
        // </For>
    }

    private static void BreakExample()
    {
        // <Break>
        int[] numbers = [2, 4, 7, 8];

        // break stops the loop immediately, skipping any remaining elements.
        foreach (int number in numbers)
        {
            if (number % 2 != 0)
            {
                Console.WriteLine($"First odd number: {number}"); // => First odd number: 7
                break;
            }
        }
        // </Break>
    }

    private static void ContinueExample()
    {
        // <Continue>
        int[] values = [1, 2, 3, 4, 5];

        // continue skips the rest of the current iteration and moves to the next.
        foreach (int value in values)
        {
            if (value % 2 == 0)
            {
                continue; // skip even numbers
            }

            Console.WriteLine(value); // => 1, then 3, then 5
        }
        // </Continue>
    }

    // <AwaitForeach>
    private static async Task AwaitForeachExample()
    {
        // await foreach consumes an asynchronous stream. Each iteration can
        // suspend while the next element is produced.
        await foreach (int value in GenerateAsync())
        {
            Console.WriteLine(value); // => 0, then 1, then 2
        }
    }

    private static async IAsyncEnumerable<int> GenerateAsync()
    {
        for (int i = 0; i < 3; i++)
        {
            await Task.Delay(1); // stand-in for real asynchronous work
            yield return i;
        }
    }
    // </AwaitForeach>
}
