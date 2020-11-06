using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

// <Timer>
using IDisposable timerSub = Observable.Timer(TimeSpan.FromSeconds(0.01))
    .Subscribe(value => Console.WriteLine($"OnNext {value}"));
// </Timer>

// <ObserveOn>
using IDisposable observeOnSub = Observable.Timer(TimeSpan.FromSeconds(0.01))
    .ObserveOn(Scheduler.CurrentThread)
    .Subscribe(value => Console.WriteLine($"OnNext {value}"));
// </ObserveOn>
