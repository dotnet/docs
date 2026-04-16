// <AsyncManualResetEvent>
public class AsyncManualResetEvent
{
    private volatile TaskCompletionSource _tcs = new(TaskCreationOptions.RunContinuationsAsynchronously);

    public Task WaitAsync() => _tcs.Task;

    public void Set() => _tcs.TrySetResult();

    public void Reset()
    {
        while (true)
        {
            TaskCompletionSource tcs = _tcs;
            if (!tcs.Task.IsCompleted ||
                Interlocked.CompareExchange(
                    ref _tcs,
                    new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously),
                    tcs) == tcs)
            {
                return;
            }
        }
    }
}
// </AsyncManualResetEvent>

// <AsyncManualResetEventUsage>
public static class AsyncManualResetEventDemo
{
    public static async Task RunAsync()
    {
        var gate = new AsyncManualResetEvent();

        Task waiter = Task.Run(async () =>
        {
            Console.WriteLine("Waiter: waiting for signal...");
            await gate.WaitAsync();
            Console.WriteLine("Waiter: signal received!");
        });

        await Task.Delay(100);
        Console.WriteLine("Signaler: setting the event.");
        gate.Set();

        await waiter;
    }
}
// </AsyncManualResetEventUsage>

// <AsyncAutoResetEvent>
public class AsyncAutoResetEvent
{
    private readonly Queue<TaskCompletionSource> _waiters = new();
    private bool _signaled;

    public Task WaitAsync()
    {
        lock (_waiters)
        {
            if (_signaled)
            {
                _signaled = false;
                return Task.CompletedTask;
            }
            else
            {
                var tcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
                _waiters.Enqueue(tcs);
                return tcs.Task;
            }
        }
    }

    public void Set()
    {
        TaskCompletionSource? toRelease = null;

        lock (_waiters)
        {
            if (_waiters.Count > 0)
            {
                toRelease = _waiters.Dequeue();
            }
            else if (!_signaled)
            {
                _signaled = true;
            }
        }

        toRelease?.TrySetResult();
    }
}
// </AsyncAutoResetEvent>

// <AsyncAutoResetEventUsage>
public static class AsyncAutoResetEventDemo
{
    public static async Task RunAsync()
    {
        var autoEvent = new AsyncAutoResetEvent();

        Task consumer = Task.Run(async () =>
        {
            for (int i = 0; i < 3; i++)
            {
                await autoEvent.WaitAsync();
                Console.WriteLine($"Consumer: received signal {i + 1}");
            }
        });

        for (int i = 0; i < 3; i++)
        {
            await Task.Delay(50);
            Console.WriteLine($"Producer: sending signal {i + 1}");
            autoEvent.Set();
        }

        await consumer;
    }
}
// </AsyncAutoResetEventUsage>

// <AsyncCountdownEvent>
public class AsyncCountdownEvent
{
    private readonly AsyncManualResetEvent _event = new();
    private int _count;

    public AsyncCountdownEvent(int initialCount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(initialCount, nameof(initialCount));
        _count = initialCount;
    }

    public Task WaitAsync() => _event.WaitAsync();

    public void Signal()
    {
        if (_count <= 0)
            throw new InvalidOperationException("The event is already signaled.");

        int newCount = Interlocked.Decrement(ref _count);

        if (newCount == 0)
            _event.Set();
        else if (newCount < 0)
            throw new InvalidOperationException("Too many signals.");
    }

    public Task SignalAndWait()
    {
        Signal();
        return WaitAsync();
    }
}
// </AsyncCountdownEvent>

// <AsyncCountdownEventUsage>
public static class AsyncCountdownEventDemo
{
    public static async Task RunAsync()
    {
        var countdown = new AsyncCountdownEvent(3);

        for (int i = 1; i <= 3; i++)
        {
            int id = i;
            _ = Task.Run(async () =>
            {
                await Task.Delay(id * 30);
                Console.WriteLine($"Worker {id}: done.");
                countdown.Signal();
            });
        }

        await countdown.WaitAsync();
        Console.WriteLine("All workers finished.");
    }
}
// </AsyncCountdownEventUsage>

// <AsyncBarrier>
public class AsyncBarrier
{
    private readonly int _participantCount;
    private int _remainingParticipants;
    private TaskCompletionSource _tcs = new(TaskCreationOptions.RunContinuationsAsynchronously);

    public AsyncBarrier(int participantCount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(participantCount, nameof(participantCount));
        _remainingParticipants = _participantCount = participantCount;
    }

    public Task SignalAndWait()
    {
        TaskCompletionSource tcs = _tcs;

        if (Interlocked.Decrement(ref _remainingParticipants) == 0)
        {
            _remainingParticipants = _participantCount;
            _tcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            tcs.SetResult();
        }

        return tcs.Task;
    }
}
// </AsyncBarrier>

// <AsyncBarrierUsage>
public static class AsyncBarrierDemo
{
    public static async Task RunAsync()
    {
        var barrier = new AsyncBarrier(3);
        int rounds = 2;

        Task[] participants = Enumerable.Range(1, 3).Select(id => Task.Run(async () =>
        {
            for (int round = 1; round <= rounds; round++)
            {
                Console.WriteLine($"Participant {id}: working on round {round}");
                await Task.Delay(id * 20);
                Console.WriteLine($"Participant {id}: finished round {round}, waiting at barrier");
                await barrier.SignalAndWait();
            }
        })).ToArray();

        await Task.WhenAll(participants);
        Console.WriteLine("All rounds complete.");
    }
}
// </AsyncBarrierUsage>

public static class Program
{
    public static async Task Main()
    {
        Console.WriteLine("--- AsyncManualResetEvent ---");
        await AsyncManualResetEventDemo.RunAsync();

        Console.WriteLine();
        Console.WriteLine("--- AsyncAutoResetEvent ---");
        await AsyncAutoResetEventDemo.RunAsync();

        Console.WriteLine();
        Console.WriteLine("--- AsyncCountdownEvent ---");
        await AsyncCountdownEventDemo.RunAsync();

        Console.WriteLine();
        Console.WriteLine("--- AsyncBarrier ---");
        await AsyncBarrierDemo.RunAsync();
    }
}
