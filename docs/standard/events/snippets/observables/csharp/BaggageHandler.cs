namespace Observables.Example;

public sealed class BaggageHandler : IObservable<BaggageInfo>
{
    private readonly Lock _lock = new();
    private readonly HashSet<IObserver<BaggageInfo>> _observers = [];
    private readonly HashSet<BaggageInfo> _flights = [];

    public IDisposable Subscribe(IObserver<BaggageInfo> observer)
    {
        BaggageInfo[] snapshot;

        lock (_lock)
        {
            // Check whether observer is already registered. If not, add it.
            if (!_observers.Add(observer))
            {
                return new Unsubscriber<BaggageInfo>(_lock, _observers, observer);
            }

            // Snapshot existing data while holding the lock.
            snapshot = [.. _flights];
        }

        // Provide observer with existing data outside the lock.
        foreach (BaggageInfo item in snapshot)
        {
            observer.OnNext(item);
        }

        return new Unsubscriber<BaggageInfo>(_lock, _observers, observer);
    }

    // Called to indicate all baggage is now unloaded.
    public void BaggageStatus(int flightNumber) =>
        BaggageStatus(flightNumber, string.Empty, 0);

    public void BaggageStatus(int flightNumber, string from, int carousel)
    {
        var info = new BaggageInfo(flightNumber, from, carousel);
        IObserver<BaggageInfo>[] snapshot;

        // Carousel is assigned, so add new info object to list.
        if (carousel > 0)
        {
            lock (_lock)
            {
                if (!_flights.Add(info))
                {
                    return;
                }

                snapshot = [.. _observers];
            }

            foreach (IObserver<BaggageInfo> observer in snapshot)
            {
                observer.OnNext(info);
            }
        }
        else if (carousel is 0)
        {
            // Baggage claim for flight is done.
            lock (_lock)
            {
                if (_flights.RemoveWhere(
                    flight => flight.FlightNumber == info.FlightNumber) == 0)
                {
                    return;
                }

                snapshot = [.. _observers];
            }

            foreach (IObserver<BaggageInfo> observer in snapshot)
            {
                observer.OnNext(info);
            }
        }
    }

    public void LastBaggageClaimed()
    {
        IObserver<BaggageInfo>[] snapshot;

        lock (_lock)
        {
            snapshot = [.. _observers];
            _observers.Clear();
        }

        foreach (IObserver<BaggageInfo> observer in snapshot)
        {
            observer.OnCompleted();
        }
    }
}
