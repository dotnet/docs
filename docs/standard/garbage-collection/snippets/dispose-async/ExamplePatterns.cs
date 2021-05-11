// <one>
using System;
using System.Threading.Tasks;

class ExampleOneProgram
{
    static async Task Main()
    {
        var objOne = new ExampleAsyncDisposable();
        await using (objOne.ConfigureAwait(false))
        {
            // Interact with the objOne instance.

            var objTwo = new ExampleAsyncDisposable();
            await using (objTwo.ConfigureAwait(false))
            {
                // Interact with the objOne and/or objTwo instance(s).
            }
        }

        Console.ReadLine();
    }
}
// </one>

// <two>
class ExampleTwoProgram
{
    static async Task Main()
    {
        var objOne = new ExampleAsyncDisposable();
        await using (objOne.ConfigureAwait(false))
        {
            // Interact with the objOne instance.
        }

        var objTwo = new ExampleAsyncDisposable();
        await using (objTwo.ConfigureAwait(false))
        {
            // Interact with the objTwo instance.
        }

        Console.ReadLine();
    }
}
// </two>

// <three>
class ExampleThreeProgram
{
    static async Task Main()
    {
        var objOne = new ExampleAsyncDisposable();
        await using var ignored1 = objOne.ConfigureAwait(false);

        var objTwo = new ExampleAsyncDisposable();
        await using var ignored2 = objTwo.ConfigureAwait(false);

        // Interact with objOne and/or objTwo instance(s).

        Console.ReadLine();
    }
}
// </three>

// <dontdothis>
class DoNotDoThisProgram
{
    static async Task Main()
    {
        var objOne = new ExampleAsyncDisposable();
        // Exception thrown on .ctor
        var objTwo = new AnotherAsyncDisposable();

        await using (objOne.ConfigureAwait(false))
        await using (objTwo.ConfigureAwait(false))
        {
            // Neither object has its DisposeAsync called.
        }

        Console.ReadLine();
    }
}
// </dontdothis>
