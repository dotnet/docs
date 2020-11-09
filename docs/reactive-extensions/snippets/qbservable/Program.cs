using System;
using System.Reactive.Linq;

IObservable<long> source =
    Observable.Interval(TimeSpan.FromSeconds(1));
IQbservable<long> qbservable = source.AsQbservable();

Console.WriteLine(qbservable.ToString());

using IDisposable subscription =
    qbservable.Subscribe(Console.WriteLine);

Console.ReadKey();
