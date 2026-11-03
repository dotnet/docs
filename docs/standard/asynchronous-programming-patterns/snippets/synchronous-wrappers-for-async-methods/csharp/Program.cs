// <SyncOverAsyncTAP>
public class TapWrapper
{
    public static int Foo(Func<Task<int>> fooAsync)
    {
        return fooAsync().Result;
    }
}
// </SyncOverAsyncTAP>

// <DeadlockExample>
public static class DeadlockExample
{
    private static void Delay(int milliseconds)
    {
        DelayAsync(milliseconds).Wait();
    }

    private static async Task DelayAsync(int milliseconds)
    {
        await Task.Delay(milliseconds);
    }
}
// </DeadlockExample>

// <ThreadPoolDeadlock>
public static class ThreadPoolDeadlockExample
{
    public static int Foo(Func<Task<int>> fooAsync)
    {
        return fooAsync().Result;
    }

    public static async Task DemonstrateDeadlockRiskAsync()
    {
        var tasks = Enumerable.Range(0, 25)
            .Select(_ => Task.Run(() => Foo(() => SomeIOOperationAsync())));
        await Task.WhenAll(tasks);
    }

    private static async Task<int> SomeIOOperationAsync()
    {
        await Task.Delay(100);
        return 42;
    }
}
// </ThreadPoolDeadlock>

// <ConfigureAwaitMitigation>
public static class ConfigureAwaitMitigation
{
    public static async Task<int> LibraryMethodAsync()
    {
        await Task.Delay(100).ConfigureAwait(false);
        return 42;
    }

    public static int Sync()
    {
        return LibraryMethodAsync().GetAwaiter().GetResult();
    }
}
// </ConfigureAwaitMitigation>

// Verification entry point
public class Program
{
    public static void Main()
    {
        Console.WriteLine("--- ConfigureAwait mitigation demo ---");
        int result = ConfigureAwaitMitigation.Sync();
        Console.WriteLine($"Result: {result}");

        Console.WriteLine("Done.");
    }
}
