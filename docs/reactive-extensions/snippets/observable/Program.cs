using System;
using static System.Console;
using static System.Reactive.Linq.Observable;

using IDisposable subscription =
    Range(1, 5).Subscribe(
        value => WriteLine($"OnNext: {value}"),
        ex => WriteLine($"OnError: {ex.Message}"),
        () => WriteLine("OnCompleted"));
