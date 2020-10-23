// <one>
using System;
using System.Threading.Tasks;

class ExampleOneStackedProgram
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
// </one>

// <two>
class ExampleTwoStackedProgram
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
class ExampleThreeStackedProgram
{
    static async Task Main()
    {
        var objOne = new ExampleAsyncDisposable();
        await using var ignored1 = objOne.ConfigureAwait(false);

        var objTwo = new ExampleAsyncDisposable();
        await using var ignored2 = objTwo.ConfigureAwait(false);

        // ...

        Console.ReadLine();
    }
}
// <three>

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
            // ...
        }

        Console.ReadLine();
    }
}
// </dontdothis>
