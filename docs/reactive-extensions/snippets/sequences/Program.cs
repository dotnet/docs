using System;
using System.Reactive;
using System.Reactive.Linq;

IObservable<int> source = Observable.Range(1, 10);
IObserver<int> observer =
    Observer.Create<int>(
        value => Console.WriteLine("OnNext: {value}"),
        ex => Console.WriteLine("OnError: {ex.Message}"),
        () => Console.WriteLine("OnCompleted"));

using IDisposable _ = source.Subscribe(observer);

Console.WriteLine("Press any key to unsubscribe...");
Console.ReadLine();
