using System;
using System.Threading;
using Microsoft.Extensions.Primitives;

internal static partial class Example
{
    internal static void Composite()
    {
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
                    firstCancellationChangeToken, secondCancellationChangeToken, thirdCancellationChangeToken
                });

        Action<object?> callback = obj => Console.WriteLine($"The {obj} callback was invoked.");

        // 1st, 2nd, 3rd.
        compositeChangeToken.RegisterChangeCallback(callback, "1st");
        compositeChangeToken.RegisterChangeCallback(callback, "2nd");
        compositeChangeToken.RegisterChangeCallback(callback, "3rd");

        /// 1, 2, 3.
        firstCancellationTokenSource.Cancel();
        secondCancellationTokenSource.Cancel();
        thirdCancellationTokenSource.Cancel();

        Console.WriteLine();

        // Outputs:
        //     The 3rd callback was invoked.
        //     The 2nd callback was invoked.
        //     The 1st callback was invoked.
    }
}
