using System.Collections.Concurrent;

// <SemaphoreSlimUsage>
public static class SemaphoreSlimDemo
{
    public static async Task RunAsync()
    {
        var semaphore = new SemaphoreSlim(3);

        Task[] tasks = Enumerable.Range(1, 6).Select(id => Task.Run(async () =>
        {
            await semaphore.WaitAsync();
            try
            {
                Console.WriteLine($"Task {id}: entered (count = {semaphore.CurrentCount})");
                await Task.Delay(100);
            }
            finally
            {
                semaphore.Release();
                Console.WriteLine($"Task {id}: released");
            }
        })).ToArray();

        await Task.WhenAll(tasks);
    }
}
// </SemaphoreSlimUsage>

// <AsyncSemaphore>
public class AsyncSemaphore
{
    private readonly Queue<TaskCompletionSource> _waiters = new();
    private int _currentCount;

    public AsyncSemaphore(int initialCount)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(initialCount, nameof(initialCount));
        _currentCount = initialCount;
    }

    public Task WaitAsync()
    {
        lock (_waiters)
        {
            if (_currentCount > 0)
            {
                _currentCount--;
                return Task.CompletedTask;
            }
            else
            {
                var waiter = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
                _waiters.Enqueue(waiter);
                return waiter.Task;
            }
        }
    }

    public void Release()
    {
        TaskCompletionSource? toRelease = null;

        lock (_waiters)
        {
            if (_waiters.Count > 0)
                toRelease = _waiters.Dequeue();
            else
                _currentCount++;
        }

        toRelease?.TrySetResult();
    }
}
// </AsyncSemaphore>

// <SemaphoreSlimAsLock>
public static class SemaphoreSlimAsLockDemo
{
    private static readonly SemaphoreSlim s_lock = new(1, 1);
    private static int s_sharedCounter;

    public static async Task RunAsync()
    {
        Task[] tasks = Enumerable.Range(1, 5).Select(_ => Task.Run(async () =>
        {
            await s_lock.WaitAsync();
            try
            {
                int before = s_sharedCounter;
                await Task.Delay(10);
                s_sharedCounter = before + 1;
            }
            finally
            {
                s_lock.Release();
            }
        })).ToArray();

        await Task.WhenAll(tasks);
        Console.WriteLine($"Counter = {s_sharedCounter} (expected 5)");
    }
}
// </SemaphoreSlimAsLock>

// <AsyncLock>
public class AsyncLock
{
    private readonly SemaphoreSlim _semaphore = new(1, 1);
    private readonly Task<Releaser> _releaser;

    public AsyncLock()
    {
        _releaser = Task.FromResult(new Releaser(this));
    }

    public Task<Releaser> LockAsync()
    {
        Task wait = _semaphore.WaitAsync();
        return wait.IsCompleted
            ? _releaser
            : wait.ContinueWith(
                  (_, state) => new Releaser((AsyncLock)state!),
                  this,
                  CancellationToken.None,
                  TaskContinuationOptions.ExecuteSynchronously,
                  TaskScheduler.Default);
    }

    public struct Releaser : IDisposable
    {
        private readonly AsyncLock? _toRelease;

        internal Releaser(AsyncLock toRelease) => _toRelease = toRelease;

        public void Dispose() => _toRelease?._semaphore.Release();
    }
}
// </AsyncLock>

// <AsyncLockUsage>
public static class AsyncLockDemo
{
    private static readonly AsyncLock s_lock = new();
    private static int s_sharedValue;

    public static async Task RunAsync()
    {
        Task[] tasks = Enumerable.Range(1, 5).Select(id => Task.Run(async () =>
        {
            using (await s_lock.LockAsync())
            {
                int before = s_sharedValue;
                await Task.Delay(10);
                s_sharedValue = before + 1;
                Console.WriteLine($"Task {id}: incremented to {s_sharedValue}");
            }
        })).ToArray();

        await Task.WhenAll(tasks);
        Console.WriteLine($"Final value = {s_sharedValue} (expected 5)");
    }
}
// </AsyncLockUsage>

// <ConcurrentExclusiveUsage>
public static class ConcurrentExclusiveDemo
{
    public static async Task RunAsync()
    {
        var pair = new ConcurrentExclusiveSchedulerPair();
        var factory = new TaskFactory(pair.ExclusiveScheduler);

        int sharedValue = 0;

        Task writerTask = factory.StartNew(() =>
        {
            sharedValue = 42;
            Console.WriteLine($"Writer: set value to {sharedValue}");
        });

        var readerFactory = new TaskFactory(pair.ConcurrentScheduler);

        Task[] readerTasks = Enumerable.Range(1, 3).Select(id =>
            readerFactory.StartNew(() =>
            {
                Console.WriteLine($"Reader {id}: value = {sharedValue}");
            })).ToArray();

        await writerTask;
        await Task.WhenAll(readerTasks);
    }
}
// </ConcurrentExclusiveUsage>

// <AsyncReaderWriterLock>
public class AsyncReaderWriterLock
{
    private readonly Queue<TaskCompletionSource<Releaser>> _waitingWriters = new();
    private TaskCompletionSource<Releaser> _waitingReader = new();
    private int _readersWaiting;
    private int _status; // 0 = free, -1 = writer active, >0 = reader count

    private readonly Task<Releaser> _readerReleaser;
    private readonly Task<Releaser> _writerReleaser;

    public AsyncReaderWriterLock()
    {
        _readerReleaser = Task.FromResult(new Releaser(this, isWriter: false));
        _writerReleaser = Task.FromResult(new Releaser(this, isWriter: true));
    }

    public Task<Releaser> ReaderLockAsync()
    {
        lock (_waitingWriters)
        {
            if (_status >= 0 && _waitingWriters.Count == 0)
            {
                _status++;
                return _readerReleaser;
            }
            else
            {
                _readersWaiting++;
                return _waitingReader.Task.ContinueWith(t => t.Result);
            }
        }
    }

    public Task<Releaser> WriterLockAsync()
    {
        lock (_waitingWriters)
        {
            if (_status == 0)
            {
                _status = -1;
                return _writerReleaser;
            }
            else
            {
                var waiter = new TaskCompletionSource<Releaser>();
                _waitingWriters.Enqueue(waiter);
                return waiter.Task;
            }
        }
    }

    private void ReaderRelease()
    {
        TaskCompletionSource<Releaser>? toWake = null;

        lock (_waitingWriters)
        {
            _status--;
            if (_status == 0 && _waitingWriters.Count > 0)
            {
                _status = -1;
                toWake = _waitingWriters.Dequeue();
            }
        }

        toWake?.SetResult(new Releaser(this, isWriter: true));
    }

    private void WriterRelease()
    {
        TaskCompletionSource<Releaser>? toWake = null;
        bool toWakeIsWriter = false;

        lock (_waitingWriters)
        {
            if (_waitingWriters.Count > 0)
            {
                toWake = _waitingWriters.Dequeue();
                toWakeIsWriter = true;
            }
            else if (_readersWaiting > 0)
            {
                toWake = _waitingReader;
                _status = _readersWaiting;
                _readersWaiting = 0;
                _waitingReader = new TaskCompletionSource<Releaser>();
            }
            else
            {
                _status = 0;
            }
        }

        toWake?.SetResult(new Releaser(this, toWakeIsWriter));
    }

    public struct Releaser : IDisposable
    {
        private readonly AsyncReaderWriterLock? _lock;
        private readonly bool _isWriter;

        internal Releaser(AsyncReaderWriterLock lockObj, bool isWriter)
        {
            _lock = lockObj;
            _isWriter = isWriter;
        }

        public void Dispose()
        {
            if (_lock is not null)
            {
                if (_isWriter) _lock.WriterRelease();
                else _lock.ReaderRelease();
            }
        }
    }
}
// </AsyncReaderWriterLock>

// <AsyncReaderWriterLockUsage>
public static class AsyncReaderWriterLockDemo
{
    private static readonly AsyncReaderWriterLock s_rwLock = new();
    private static string s_data = "initial";

    public static async Task RunAsync()
    {
        Task writer = Task.Run(async () =>
        {
            using (await s_rwLock.WriterLockAsync())
            {
                Console.WriteLine("Writer: acquired exclusive lock");
                await Task.Delay(50);
                s_data = "updated";
                Console.WriteLine("Writer: data updated");
            }
        });

        Task[] readers = Enumerable.Range(1, 3).Select(id => Task.Run(async () =>
        {
            await Task.Delay(10);
            using (await s_rwLock.ReaderLockAsync())
            {
                Console.WriteLine($"Reader {id}: data = {s_data}");
            }
        })).ToArray();

        await writer;
        await Task.WhenAll(readers);
    }
}
// </AsyncReaderWriterLockUsage>

public static class Program
{
    public static async Task Main()
    {
        Console.WriteLine("--- SemaphoreSlim ---");
        await SemaphoreSlimDemo.RunAsync();

        Console.WriteLine();
        Console.WriteLine("--- SemaphoreSlim as lock ---");
        await SemaphoreSlimAsLockDemo.RunAsync();

        Console.WriteLine();
        Console.WriteLine("--- AsyncLock ---");
        await AsyncLockDemo.RunAsync();

        Console.WriteLine();
        Console.WriteLine("--- ConcurrentExclusiveSchedulerPair ---");
        await ConcurrentExclusiveDemo.RunAsync();

        Console.WriteLine();
        Console.WriteLine("--- AsyncReaderWriterLock ---");
        await AsyncReaderWriterLockDemo.RunAsync();
    }
}
