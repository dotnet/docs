using System;
using System.IO;
using System.Reactive.Linq;

using Stream inputStream = Console.OpenStandardInput();

IObservable<int> Read(byte[] bytes, int offset, int count) =>
    Observable.FromAsync<int>(
        () => inputStream.ReadAsync(bytes, offset, count));

using IDisposable subscription =
    Read(new byte[1024], 0, 1024).Subscribe(
        value => Console.WriteLine($"OnNext: bytes read={value}"),
        ex => Console.WriteLine($"OnError: {ex.Message}"),
        () => Console.WriteLine("OnCompleted"));

Console.WriteLine("Type something, then press the ENTER key.");
Console.ReadKey();
