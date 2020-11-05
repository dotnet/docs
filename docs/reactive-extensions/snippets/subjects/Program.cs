using System;
using System.Reactive.Subjects;

using var subject = new Subject<int>();
using IDisposable subscription = subject.Subscribe(
    value => Console.WriteLine($"OnNext: {value}"),
    () => Console.WriteLine("OnCompleted"));

subject.OnNext(7);
subject.OnNext(1984);

Console.WriteLine("Press any key to continue");
Console.ReadKey();

subject.OnCompleted();
