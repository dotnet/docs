using System;
using System.Threading;
using Microsoft.Extensions.Primitives;

internal static partial class Example
{
    internal static void StaticOnChange()
    {
        CancellationTokenSource cancellationTokenSource = new();
        CancellationChangeToken cancellationChangeToken = new(cancellationTokenSource.Token);

        Console.WriteLine($"Initial state of HasChanged: {cancellationChangeToken.HasChanged}");

        Func<IChangeToken> producer = () =>
        {
            // The producer factory should always return a new change token.
            // If the token's already fired, get a new token.
            if (cancellationTokenSource.IsCancellationRequested)
            {
                cancellationTokenSource = new();
                cancellationChangeToken = new(cancellationTokenSource.Token);
            }

            return cancellationChangeToken;
        };

        Action consumer = () => Console.WriteLine("The callback was invoked.");

        using (ChangeToken.OnChange(producer, consumer))
        {
            cancellationTokenSource.Cancel();
        }

        Console.WriteLine($"Post state of HasChanged: {cancellationChangeToken.HasChanged}\n");

        // Outputs:
        //     HasChanged: False
        //     The callback was invoked.
        //     HasChanged: False
    }
}
