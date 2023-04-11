public class ExampleClass
{
    string name;

    // <ThrowExpressionCoalescing>
    public string Name
    {
        get => name;
        set => name = value ??
            throw new ArgumentNullException(paramName: nameof(value), message: "Name cannot be null");
    }
    // </ThrowExpressionCoalescing>

    public bool Busy { get; private set; }

    // <TryFinally>
    public async Task HandleRequest(int itemId, CancellationToken ct)
    {
        Busy = true;

        try
        {
            await ProcessAsync(itemId, ct);
        }
        finally
        {
            Busy = false;
        }
    }
    // </TryFinally>

    private async Task ProcessAsync(int itemId, CancellationToken ct)
    {
        await Task.Delay(100);
    }

    // <TryCatchFinally>
    public async Task ProcessRequest(int itemId, CancellationToken ct)
    {
        Busy = true;

        try
        {
            await ProcessAsync(itemId, ct);
        }
        catch (Exception e) when (e is not OperationCancelledException)
        {
            LogError(e, $"Failed to process request for item ID {itemId}.");
        }
        finally
        {
            Busy = false;
        }

    }
    // </TryCatchFinally>

    private static void LogError(Exception e, string message) {}
}