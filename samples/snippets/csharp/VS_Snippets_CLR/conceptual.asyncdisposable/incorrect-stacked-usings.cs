using System;
using System.Threading.Tasks;

class ExampleIncorrectlyStackedProgram
{
    static async Task Main()
    {
        var objOne = new ThrowingAsyncDisposable("1", throwEx: true);
        var objTwo = new ThrowingAsyncDisposable("2", throwEx: false);
        
        await using (objOne.ConfigureAwait(false))
        await using (objTwo.ConfigureAwait(false))
        {
        }

        Console.ReadLine();
    }
}