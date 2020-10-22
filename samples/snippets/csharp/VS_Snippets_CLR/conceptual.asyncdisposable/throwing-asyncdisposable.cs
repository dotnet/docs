using System;
using System.Threading.Tasks;

public class ThrowingAsyncDisposable : IAsyncDisposable
{
    readonly string _instanceName;
    readonly bool _throwEx;

    public ThrowingAsyncDisposable(
        string instanceName, bool throwEx = false) =>
        (_instanceName, _throwEx) = (instanceName, throwEx);

    public async ValueTask DisposeAsync()
    {
        if (_throwEx)
        {
            throw new Exception("Oops...");
        }

        await new ValueTask();

        Console.WriteLine($"Successfully awaited {_instanceName} async disposable.");
    }
}
