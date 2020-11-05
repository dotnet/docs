using System;
using static System.Reactive.Linq.Observable;

using IDisposable subscription =
    Range(7, 5).Subscribe(
        value => Console.WriteLine($"OnNext: {value}"),
        ex => Console.WriteLine($"OnError: {ex.Message}"),
        () => Console.WriteLine("OnCompleted"));
