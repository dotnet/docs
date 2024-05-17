using Microsoft.Extensions.Primitives;

internal static partial class Example
{
    internal static void Cancellation()
    {
        // <Cancellation>
        CancellationTokenSource cancellationTokenSource = new();
        CancellationChangeToken cancellationChangeToken = new(cancellationTokenSource.Token);

        Console.WriteLine($"HasChanged: {cancellationChangeToken.HasChanged}");

        static void callback(object? _) =>
            Console.WriteLine("The callback was invoked.");

        using (IDisposable subscription =
            cancellationChangeToken.RegisterChangeCallback(callback, null))
        {
            cancellationTokenSource.Cancel();
        }

        Console.WriteLine($"HasChanged: {cancellationChangeToken.HasChanged}\n");

        // Outputs:
        //     HasChanged: False
        //     The callback was invoked.
        //     HasChanged: True
        // </Cancellation>
    }
}
