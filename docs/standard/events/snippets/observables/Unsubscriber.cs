namespace Observables.Example;

internal sealed class Unsubscriber<BaggageInfo> : IDisposable
{
    private readonly ISet<IObserver<BaggageInfo>> _observers;
    private readonly IObserver<BaggageInfo> _observer;

    internal Unsubscriber(
        ISet<IObserver<BaggageInfo>> observers,
        IObserver<BaggageInfo> observer) => (_observers, _observer) = (observers, observer);

    public void Dispose() => _observers.Remove(_observer);
}
