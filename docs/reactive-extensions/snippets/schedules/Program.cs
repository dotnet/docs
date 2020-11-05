using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

IObservable<long> source = Observable.Interval(TimeSpan.FromSeconds(1));
using var subject = new Subject<long>();

using IDisposable subSource = source.Subscribe(subject);

using IDisposable subSubject1 = subject.Subscribe(
    value => Console.WriteLine($"#1 OnNext: {value}"),
    () => Console.WriteLine("#1 OnCompleted"));

using IDisposable subSubject2 = subject.Subscribe(
    value => Console.WriteLine($"#2 OnNext: {value}"),
    () => Console.WriteLine("#2 OnCompleted"));

Console.WriteLine("Press any key to continue");
Console.ReadKey();

subject.OnCompleted();
