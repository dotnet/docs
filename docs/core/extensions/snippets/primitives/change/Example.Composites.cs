using System;
using System.Threading;
using Microsoft.Extensions.Primitives;

internal static partial class Example
{
    internal static void Composite()
    {
        // <Composites>
        CancellationTokenSource firstCancellationTokenSource = new();
        CancellationChangeToken firstCancellationChangeToken = new(firstCancellationTokenSource.Token);

        CancellationTokenSource secondCancellationTokenSource = new();
        CancellationChangeToken secondCancellationChangeToken = new(secondCancellationTokenSource.Token);

        CancellationTokenSource thirdCancellationTokenSource = new();
        CancellationChangeToken thirdCancellationChangeToken = new(thirdCancellationTokenSource.Token);

        var compositeChangeToken =
            new CompositeChangeToken(
                new IChangeToken[]
                {
                    firstCancellationChangeToken,
                    secondCancellationChangeToken,
                    thirdCancellationChangeToken
                });

        Action<object?> callback = state => Console.WriteLine($"The {state} callback was invoked.");

        // 1st, 2nd, 3rd, and 4th.
        compositeChangeToken.RegisterChangeCallback(callback, "1st");
        compositeChangeToken.RegisterChangeCallback(callback, "2nd");
        compositeChangeToken.RegisterChangeCallback(callback, "3rd");
        compositeChangeToken.RegisterChangeCallback(callback, "4th");

        // It doesn't matter which cancellation source triggers the change.
        // If more than one trigger the change, each callback is only fired once.
        Random random = new();
        int index = random.Next(3);
        CancellationTokenSource[] sources = new[]
        {
            firstCancellationTokenSource,
            secondCancellationTokenSource,
            thirdCancellationTokenSource
        };
        sources[index].Cancel();

        Console.WriteLine();

        // Outputs:
        //     The 4th callback was invoked.
        //     The 3rd callback was invoked.
        //     The 2nd callback was invoked.
        //     The 1st callback was invoked.
        // </Composites>
    }
}
