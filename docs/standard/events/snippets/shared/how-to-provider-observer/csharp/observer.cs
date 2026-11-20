// <All>
// <Subscribe>
// <ClassDeclaration>
namespace TemperatureSample;

public sealed class TemperatureReporter : IObserver<Temperature>
// </ClassDeclaration>
{
    private IDisposable? _unsubscriber;
    private Temperature? _last;

    public void Subscribe(IObservable<Temperature> provider)
    {
        ArgumentNullException.ThrowIfNull(provider);
        _unsubscriber = provider.Subscribe(this);
    }
    // </Subscribe>

    // <Unsubscribe>
    public void Unsubscribe() => _unsubscriber?.Dispose();
    // </Unsubscribe>

    // <ObserverMethods>
    public void OnCompleted() =>
        Console.WriteLine("Additional temperature data won't be transmitted.");

    // OnError is informational; observers shouldn't treat it as an exception to handle.
    public void OnError(Exception error) { }

    public void OnNext(Temperature value)
    {
        Console.WriteLine($"The temperature is {value.Degrees}°C at {value.Date:g}");

        if (_last is Temperature previous)
        {
            TimeSpan elapsed = value.Date.ToUniversalTime() - previous.Date.ToUniversalTime();
            Console.WriteLine($"   Change: {value.Degrees - previous.Degrees}° in {elapsed:g}");
        }

        _last = value;
    }
    // </ObserverMethods>
}
// </All>
