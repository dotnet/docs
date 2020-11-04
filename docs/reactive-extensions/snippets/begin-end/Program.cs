using System;
using System.IO;
using System.Reactive.Linq;
using static System.Console;

using Stream inputStream = OpenStandardInput();

IObservable<int> Read(byte[] bytes, int offset, int count) =>
    Observable.FromAsync<int>(
        () => inputStream.ReadAsync(bytes, offset, count));

using IDisposable subscription =
    Read(new byte[1024], 0, 1024).Subscribe(
        value => WriteLine($"OnNext: {value}"),
        ex => WriteLine($"OnError: {ex.Message}"),
        () => WriteLine("OnCompleted"));

WriteLine("Type something...");
ReadKey();
