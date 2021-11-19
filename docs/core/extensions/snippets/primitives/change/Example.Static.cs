using Microsoft.Extensions.Primitives;

internal static partial class Example
{
    internal static void StaticOnChange()
    {
        // <Static>
        CancellationTokenSource cancellationTokenSource = new();
        CancellationChangeToken cancellationChangeToken = new(cancellationTokenSource.Token);

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

        // Outputs:
        //     The callback was invoked.
        // </Static>
    }
}
