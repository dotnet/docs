// <Snippet102>
public static class Example
{
    // This Click event is marked with the async modifier.
    public static void Main() => DoSomethingAsync().Wait();

    private static async Task DoSomethingAsync()
    {
        var result = await DelayAsync();
        Console.WriteLine("Result: " + result);
    }

    private static async Task<int> DelayAsync()
    {
        await Task.Delay(100);
        return 5;
    }

    // Output:
    //  Result: 5
}
// The example displays the following output:
//        Result: 5
// </Snippet102>
