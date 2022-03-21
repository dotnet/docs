---
title: External tasks and grains
description: Learn about external tasks and grains in .NET Orleans.
ms.date: 03/16/2022
---

# External tasks and grains

By design, any sub-Tasks spawned from grain code (for example, by using `await` or `ContinueWith` or `Task.Factory.StartNew`) will be dispatched on the same per-activation <xref:System.Threading.Tasks.TaskScheduler> as the parent task and therefore inherit the same *single-threaded execution model* as the rest of grain code. This is the main point behind the single-threaded execution of grain turn-based concurrency.

In some cases grain code might need to "break out" of the Orleans task scheduling model and "do something special", such as explicitly pointing a `Task` to a different task scheduler or the .NET <xref:System.Threading.ThreadPool>. An example of such a case is when grain code has to execute a synchronous remote blocking call (such as remote IO). Executing that blocking call in the grain context will block the grain and thus should never be made. Instead, the grain code can execute this piece of blocking code on the thread pool thread and join (`await`) the completion of that execution and proceed in the grain context. We expect that escaping from the Orleans scheduler will be a very advanced and seldom-required usage scenario beyond the "normal" usage patterns.

## Task-based APIs

1. [await](../../csharp/language-reference/operators/await.md), <xref:System.Threading.Tasks.TaskFactory.StartNew%2A?displayProperty=nameWithType> (see below), <xref:System.Threading.Tasks.Task.ContinueWith%2A?displayProperty=nameWithType>, <xref:System.Threading.Tasks.Task.WhenAny%2A?displayProperty=nameWithType>, <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType>, <xref:System.Threading.Tasks.Task.Delay%2A?displayProperty=nameWithType> all respect the current task scheduler. That means that using them in the default way, without passing a different <xref:System.Threading.Tasks.TaskScheduler>, will cause them to execute in the grain context.

1. Both <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType> and the `endMethod` delegate of <xref:System.Threading.Tasks.TaskFactory.FromAsync%2A?displayProperty=nameWithType> do *not* respect the current task scheduler. They both use the `TaskScheduler.Default` scheduler, which is the .NET thread pool task scheduler. Therefore, the code inside `Task.Run` and the `endMethod` in `Task.Factory.FromAsync` will *always* run on the .NET thread pool outside of the single-threaded execution model for Orleans grains. However, any code after the `await Task.Run` or `await Task.Factory.FromAsync` will run back under the scheduler at the point the task was created, which is the grain's scheduler.

1. <xref:System.Threading.Tasks.Task.ConfigureAwait%2A?displayProperty=nameWithType> with `false` is an explicit API to escape the current task scheduler. It will cause the code after an awaited Task to be executed on the <xref:System.Threading.Tasks.TaskScheduler.Default%2A?displayProperty=nameWithType> scheduler, which is the .NET thread pool, and will thus break the single-threaded execution of the grain.

    > [!CAUTION]
    > You should in general **never use `ConfigureAwait(false)` directly in grain code.**

1. Methods with the signature `async void` should not be used with grains. They are intended for graphical user interface event handlers. `async void` method can immediately crash the current process if they allow an exception to escape, with no way of handling the exception. This is also true for `List<T>.ForEach(async element => ...)` and any other method which accepts an <xref:System.Action%601>, since the asynchronous delegate will be coerced into an `async void` delegate.

### `Task.Factory.StartNew` and `async` delegates

The usual recommendation for scheduling tasks in any C# program is to use `Task.Run` in favor of `Task.Factory.StartNew`. A quick google search on the use of `Task.Factory.StartNew` will suggest [that it is dangerous](https://blog.stephencleary.com/2013/08/startnew-is-dangerous.html) and [that one should always favor `Task.Run`](https://devblogs.microsoft.com/pfxteam/task-run-vs-task-factory-startnew/). But if we want to stay in the grain's *single-threaded execution model* for our grain then we need to use it, so how do we do it correctly then? The danger when using `Task.Factory.StartNew()` is that it does not natively support async delegates. This means that this is likely a bug: `var notIntendedTask = Task.Factory.StartNew(SomeDelegateAsync)`. `notIntendedTask` is *not* a task that completes when `SomeDelegateAsync` does. Instead, one should *always* unwrap the returned task: `var task = Task.Factory.StartNew(SomeDelegateAsync).Unwrap()`.

#### Example multiple tasks and the task scheduler

Below is sample code that demonstrates the usage of `TaskScheduler.Current`, `Task.Run`, and a special custom scheduler to escape from Orleans grain context and how to get back to it.

```csharp
public async Task MyGrainMethod()
{
    // Grab the grain's task scheduler
    var orleansTS = TaskScheduler.Current;
    await TaskDelay(10_000);

    // Current task scheduler did not change, the code after await is still running
    // in the same task scheduler.
    Assert.AreEqual(orleansTS, TaskScheduler.Current);

    Task t1 = Task.Run(() =>
    {
        // This code runs on the thread pool scheduler, not on Orleans task scheduler
        Assert.AreNotEqual(orleansTS, TaskScheduler.Current);
        Assert.AreEqual(TaskScheduler.Default, TaskScheduler.Current);
    });

    await t1;

    // We are back to the Orleans task scheduler.
    // Since await was executed in Orleans task scheduler context, we are now back
    // to that context.
    Assert.AreEqual(orleansTS, TaskScheduler.Current);

    // Example of using Task.Factory.StartNew with a custom scheduler to escape from
    // the Orleans scheduler
    Task t2 = Task.Factory.StartNew(() =>
    {
        // This code runs on the MyCustomSchedulerThatIWroteMyself scheduler, not on
        // the Orleans task scheduler
        Assert.AreNotEqual(orleansTS, TaskScheduler.Current);
        Assert.AreEqual(MyCustomSchedulerThatIWroteMyself, TaskScheduler.Current);
    },
    CancellationToken.None,
    TaskCreationOptions.None,
    scheduler: MyCustomSchedulerThatIWroteMyself);

    await t2;

    // We are back to Orleans task scheduler.
    Assert.AreEqual(orleansTS, TaskScheduler.Current);
}
```

#### Example make a grain call from code that runs on a thread pool

Another scenario is a piece of grain code that needs to "break out" of the grain's task scheduling model and run on a thread pool (or some other, non-grain context), but still needs to call another grain. Grain calls can be made from non-grain contexts without extra ceremony.

The following is code that demonstrates how a grain call can be made from a piece of code that runs inside a grain but not in the grain context.

```csharp
public async Task MyGrainMethod()
{
    // Grab the Orleans task scheduler
    var orleansTS = TaskScheduler.Current;
    var fooGrain = this.GrainFactory.GetGrain<IFooGrain>(0);
    Task<int> t1 = Task.Run(async () =>
    {
        // This code runs on the thread pool scheduler,
        // not on Orleans task scheduler
        Assert.AreNotEqual(orleansTS, TaskScheduler.Current);
        int res = await fooGrain.MakeGrainCall();

        // This code continues on the thread pool scheduler,
        // not on the Orleans task scheduler
        Assert.AreNotEqual(orleansTS, TaskScheduler.Current);
        return res;
    });

    int result = await t1;

    // We are back to the Orleans task scheduler.
    // Since await was executed in the Orleans task scheduler context,
    // we are now back to that context.
    Assert.AreEqual(orleansTS, TaskScheduler.Current);
}
```

## Work with libraries

Some external libraries that your code is using might be using `ConfigureAwait(false)` internally. It is a good and correct practice in .NET to use `ConfigureAwait(false)` [when implementing general-purpose libraries](https://devblogs.microsoft.com/dotnet/configureawait-faq/#when-should-i-use-configureawaitfalse). This is not a problem in Orleans. As long as the code in the grain that invokes the library method is awaiting the library call with a regular `await`, the grain code is correct. The result will be exactly as desired – the library code will run continuations on the default scheduler (the value returned by `TaskScheduler.Default`, which does not guarantee that the continuations will run on a <xref:System.Threading.ThreadPool> thread as continuations are often inlined in the previous thread), while the grain code will run on the grain's scheduler.

Another frequently asked question is whether there is a need to execute library calls with `Task.Run` &mdash; that is, whether there is a need to explicitly offload the library code to `ThreadPool` (for grain code to do `Task.Run(() => myLibrary.FooAsync())`). The answer is no. There is no need to offload any code to `ThreadPool` except for the case of library code that is making a blocking synchronous calls. Usually, any well-written and correct .NET async library (methods that return `Task` and are named with an `Async` suffix) doesn't make blocking calls. Thus there is no need to offload anything to `ThreadPool` unless you suspect the async library is buggy or if you are deliberately using a synchronous blocking library.

## Deadlocks

Since grains execute in a single-threaded fashion, it is possible to deadlock a grain by synchronously blocking in a way that would require multiple threads to unblock. This means that code that calls any of the following methods and properties can deadlock a grain if the provided tasks have not yet been completed by the time the method or property is invoked:

* `Task.Wait()`
* `Task.Result`
* `Task.WaitAny(...)`
* `Task.WaitAll(...)`
* `task.GetAwaiter().GetResult()`

These methods should be avoided in any high-concurrency service because they can lead to poor performance and instability by starving the .NET `ThreadPool` by blocking threads that could be performing useful work and requiring the .NET `ThreadPool` to inject additional threads so that they can be completed. When executing grain code, these methods, as mentioned above, can cause the grain to deadlock, and therefore they should also be avoided in grain code.

If there is some *sync-over-async* work that cannot be avoided, it is best to move that work to a separate scheduler. The simplest way to do this is to use `await Task.Run(() => task.Wait())` for example. Please note that it is strongly recommended to avoid *sync-over-async* work since, as mentioned above, it will cause your application's scalability and performance to suffer.

## Summary working with Tasks in Orleans

| What are you trying to do? | How to do it |
|--|--|
| Run background work on .NET thread-pool threads. No grain code or grain calls are allowed. | `Task.Run` |
| Run asynchronous worker task from grain code with Orleans turn-based concurrency guarantees ([see above](#taskfactorystartnew-and-async-delegates)). | `Task.Factory.StartNew(WorkerAsync).Unwrap()` (<xref:System.Threading.Tasks.TaskExtensions.Unwrap%2A>) |
| Run synchronous worker task from grain code with Orleans turn-based concurrency guarantees. | `Task.Factory.StartNew(WorkerSync)` |
| Timeouts for executing work items | `Task.Delay` + `Task.WhenAny` |
| Call an asynchronous library method | `await` the library call |
| Use `async`/`await` | The normal .NET Task-Async programming model. Supported & recommended |
| `ConfigureAwait(false)` | Do not use inside grain code. Allowed only inside libraries. |
