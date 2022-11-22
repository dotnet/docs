class ExampleUsingDeclarationProgram
{
    static async Task Main()
    {
        await using var exampleAsyncDisposable = new ExampleAsyncDisposable();

        // Interact with the exampleAsyncDisposable instance.

        Console.ReadLine();
    }
}
