// <All>
// <ObserverList>
// <ClassDeclaration>
namespace TemperatureSample;

public sealed class TemperatureMonitor : IObservable<Temperature>
{
    // </ClassDeclaration>
    private readonly List<IObserver<Temperature>> _observers = [];
    private readonly Lock _sync = new();
    // </ObserverList>

    // <Unsubscriber>
    private sealed class Unsubscriber(
        List<IObserver<Temperature>> observers,
        IObserver<Temperature> observer,
        Lock sync) : IDisposable
    {
        public void Dispose()
        {
            lock (sync)
            {
                observers.Remove(observer);
            }
        }
    }
    // </Unsubscriber>

    // <Subscribe>
    public IDisposable Subscribe(IObserver<Temperature> observer)
    {
        ArgumentNullException.ThrowIfNull(observer);

        lock (_sync)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        return new Unsubscriber(_observers, observer, _sync);
    }
    // </Subscribe>

    // <Notify>
    public async Task GetTemperatureAsync(CancellationToken cancellationToken = default)
    {
        // Sample data that mimics a temperature device. A null value signals the end of transmission.
        decimal?[] temps =
        [
            14.6m, 14.65m, 14.7m, 14.9m, 14.9m, 15.2m,
            15.25m, 15.2m, 15.4m, 15.45m, null
        ];

        decimal? previous = null;

        foreach (decimal? temp in temps)
        {
            await Task.Delay(TimeSpan.FromSeconds(2.5), cancellationToken);

            if (temp is decimal value)
            {
                // Notify only after at least a 0.1° change.
                if (previous is null || Math.Abs(value - previous.Value) >= 0.1m)
                {
                    NotifyAll(new Temperature(value, DateTime.Now));
                    previous = value;
                }
            }
            else
            {
                CompleteAll();
                break;
            }
        }
    }

    private void NotifyAll(Temperature data)
    {
        IObserver<Temperature>[] snapshot;
        lock (_sync)
        {
            snapshot = [.. _observers];
        }

        foreach (IObserver<Temperature> observer in snapshot)
            observer.OnNext(data);
    }

    private void CompleteAll()
    {
        IObserver<Temperature>[] snapshot;
        lock (_sync)
        {
            snapshot = [.. _observers];
            _observers.Clear();
        }

        foreach (IObserver<Temperature> observer in snapshot)
            observer.OnCompleted();
    }
    // </Notify>
}
// </All>