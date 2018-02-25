---
title: Async in depth
description: Learn how writing I/O-bound and CPU-bound asynchronous code is straightforward using the .NET Task-based async model.
keywords: .NET, .NET Core, .NET Standard
author: cartermp
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 1e38f9d9-8f84-46ee-a15f-199aec4f2e34
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Async in depth

Writing I/O- and CPU-bound asynchronous code is straightforward using the .NET Task-based async model. The model is exposed by the `Task` and `Task<T>` types and the `async` and `await` keywords in C# and Visual Basic. (Language-specific resources are found in the [See also](#see-also) section.) This article explains how to use .NET async and provides insight into the async framework used under the covers.

## Task and Task&lt;T&gt;

Tasks are constructs used to implement what is known as the [Promise Model of Concurrency](https://en.wikipedia.org/wiki/Futures_and_promises).  In short, they offer you a "promise" that work will be completed at a later point, letting you coordinate with the promise with a clean API.

*   `Task` represents a single operation which does not return a value.
*   `Task<T>` represents a single operation which returns a value of type `T`.

It’s important to reason about tasks as abstractions of work happening asynchronously, and *not* an abstraction over threading. By default, tasks execute on the current thread and delegate work to the Operating System, as appropriate. Optionally, tasks can be explicitly requested to run on a separate thread via the `Task.Run` API.

Tasks expose an API protocol for monitoring, waiting upon and accessing the result value (in the case of `Task<T>`) of a task. Language integration, with the `await` keyword, provides a higher-level abstraction for using tasks. 

Using `await` allows your application or service to perform useful work while a task is running by yielding control to its caller until the task is done. Your code does not need to rely on callbacks or events to continue execution after the task has been completed. The language and task API integration does that for you. If you’re using `Task<T>`, the `await` keyword will additionally "unwrap" the value returned when the Task is complete.  The details of how this works are explained further below.

You can learn more about tasks and the different ways to interact with them in the [Task-based Asynchronous Pattern (TAP)](~/docs/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md) topic.

## Deeper Dive into Tasks for an I/O-Bound Operation

The following section describes a 10,000 foot view of what happens with a typical async I/O call. Let's start with a couple examples.

The first example calls an async method and returns an active task, likely yet to complete.

```csharp
public Task<string> GetHtmlAsync()
{
 	// Execution is synchronous here
	var client = new HttpClient();
	
	return client.GetStringAsync("http://www.dotnetfoundation.org");
}
```

The second example adds the use of the `async` and `await` keywords to operate on the task.

```csharp
public async Task<string> GetFirstCharactersCountAsync(string url, int count)
{
	// Execution is synchronous here
	var client = new HttpClient();
	
	// Execution of GetFirstCharactersCountAsync() is yielded to the caller here
	// GetStringAsync returns a Task<string>, which is *awaited*
	var page = await client.GetStringAsync("http://www.dotnetfoundation.org");
	
	// Execution resumes when the client.GetStringAsync task completes,
    // becoming synchronous again.
	
	if (count > page.Length)
	{
		return page;
	}
	else
	{
		return page.Substring(0, count);
	}
}
```

The call to `GetStringAsync()` calls through lower-level .NET libraries (perhaps calling other async methods) until it reaches a P/Invoke interop call into a native networking library. The native library may subsequently call into a System API call (such as `write()` to a socket on Linux). A task object will be created at the native/managed boundary, possibly using [TaskCompletionSource](xref:System.Threading.Tasks.TaskCompletionSource%601.SetResult(%600)). The task object will be passed up through the layers, possibly operated on or directly returned, eventually returned to the initial caller. 

In the second example above, a `Task<T>` object will be returned from `GetStringAsync`. The use of the `await` keyword causes the method to return a newly created task object. Control returns to the caller from this location in the `GetFirstCharactersCountAsync` method. The methods and properties of the [Task&lt;T&gt;](xref:System.Threading.Tasks.Task%601) object enable callers to monitor the progress of the task, which will complete when the remaining code in GetFirstCharactersCountAsync has executed.

After the System API call, the request is now in kernel space, making its way to the networking subsystem of the OS (such as `/net` in the Linux Kernel).  Here the OS will handle the networking request *asynchronously*.  Details may be different depending on the OS used (the device driver call may be scheduled as a signal sent back to the runtime, or a device driver call may be made and *then* a signal sent back), but eventually the runtime will be informed that the networking request is in progress.  At this time, the work for the device driver will either be scheduled, in-progress, or already finished (the request is already out "over the wire") - but because this is all happening asynchronously, the device driver is able to immediately handle something else!

For example, in Windows an OS thread makes a call to the network device driver and asks it to perform the networking operation via an Interrupt Request Packet (IRP) which represents the operation.  The device driver receives the IRP, makes the call to the network, marks the IRP as "pending", and returns back to the OS.  Because the OS thread now knows that the IRP is "pending", it doesn't have any more work to do for this job and "returns" back so that it can be used to perform other work.

When the request is fulfilled and data comes back through the device driver, it notifies the CPU of new data received via an interrupt.  How this interrupt gets handled will vary depending on the OS, but eventually the data will be passed through the OS until it reaches a system interop call (for example, in Linux an interrupt handler will schedule the bottom half of the IRQ to pass the data up through the OS asynchronously).  Note that this *also* happens asynchronously!  The result is queued up until the next available thread is able execute the async method and "unwrap" the result of the completed task.

Throughout this entire process, a key takeaway is that **no thread is dedicated to running the task**.  Although work is executed in some context (that is, the OS does have to pass data to a device driver and respond to an interrupt), there is no thread dedicated to *waiting* for data from the request to come back.  This allows the system to handle a much larger volume of work rather than waiting for some I/O call to finish.

Although the above may seem like a lot of work to be done, when measured in terms of wall clock time, it’s miniscule compared to the time it takes to do the actual I/O work. Although not at all precise, a potential timeline for such a call would look like this:

0-1————————————————————————————————————————————————–2-3

*   Time spent from points `0` to `1` is everything up until an async method yields control to its caller.
*   Time spent from points `1` to `2` is the time spent on I/O, with no CPU cost.
*   Finally, time spent from points `2` to `3` is passing control back (and potentially a value) to the async method, at which point it is executing again.

### What does this mean for a server scenario?

This model works well with a typical server scenario workload.  Because there are no threads dedicated to blocking on unfinished tasks, the server threadpool can service a much higher volume of web requests.

Consider two servers: one that runs async code, and one that does not.  For the purpose of this example, each server only has 5 threads available to service requests.  Note that these numbers are imaginarily small and serve only in a demonstrative context.

Assume both servers receive 6 concurrent requests. Each request performs an I/O operation.  The server *without* async code has to queue up the 6th request until one of the 5 threads have finished the I/O-bound work and written a response. At the point that the 20th request comes in, the server might start to slow down, because the queue is getting too long.

The server *with* async code running on it still queues up the 6th request, but because it uses `async` and `await`, each of its threads are freed up when the I/O-bound work starts, rather than when it finishes.  By the time the 20th request comes in, the queue for incoming requests will be far smaller (if it has anything in it at all), and the server won't slow down.

Although this is a contrived example, it works in a very similar fashion in the real world.  In fact, you can expect a server to be able to handle an order of magnitude more requests using `async` and `await` than if it were dedicating a thread for each request it receives.

### What does this mean for client scenario?

The biggest gain for using `async` and `await` for a client app is an increase in responsiveness.  Although you can make an app responsive by spawning threads manually, the act of spawning a thread is an expensive operation relative to just using `async` and `await`.  Especially for something like a mobile game, impacting the UI thread as little as possible where I/O is concerned is crucial.

More importantly, because I/O-bound work spends virtually no time on the CPU, dedicating an entire CPU thread to perform barely any useful work would be a poor use of resources.

Additionally, dispatching work to the UI thread (such as updating a UI) is very simple with `async` methods, and does not require extra work (such as calling a thread-safe delegate).

## Deeper Dive into Task and Task<T> for a CPU-Bound Operation

CPU-bound `async` code is a bit different than I/O-bound `async` code.  Because the work is done on the CPU, there's no way to get around dedicating a thread to the computation.  The use of `async` and `await` provides you with a clean way to interact with a background thread and keep the caller of the async method responsive.  Note that this does not provide any protection for shared data.  If you are using shared data, you will still need to apply an appropriate synchronization strategy.

Here's a 10,000 foot view of a CPU-bound async call:

```csharp
public async Task<int> CalculateResult(InputData data)
{
	// This queues up the work on the threadpool.
	var expensiveResultTask = Task.Run(() => DoExpensiveCalculation(data));
	
	// Note that at this point, you can do some other work concurrently,
	// as CalculateResult() is still executing!
	
	// Execution of CalculateResult is yielded here!
	var result = await expensiveResultTask;
	
	return result;
}
```

`CalculateResult()` executes on the thread it was called on.  When it calls `Task.Run`, it queues the expensive CPU-bound operation, `DoExpensiveCalculation()`, on the thread pool and receives a `Task<int>` handle.  `DoExpensiveCalculation()` is eventually run concurrently on the next available thread, likely on another CPU core.  It's possible to do concurrent work while `DoExpensiveCalculation()` is busy on another thread, because the thread which called `CalculateResult()` is still executing.

Once `await` is encountered, the execution of `CalculateResult()` is yielded to its caller, allowing other work to be done with the current thread while `DoExpensiveCalculation()` is churning out a result.  Once it has finished, the result is queued up to run on the main thread.  Eventually, the main thread will return to executing `CalculateResult()`, at which point it will have the result of `DoExpensiveCalculation()`.

### Why does async help here?

`async` and `await` are the best practice managing CPU-bound work when you need responsiveness. There are multiple patterns for using async with CPU-bound work. It's important to note that there is a small cost to using async and it's not recommended for tight loops.  It's up to you to determine how you write your code around this new capability.

## See also

[Asynchronous programming in C#](~/docs/csharp/async.md)   
[Asynchronous programming with async and await (C#)](../csharp/programming-guide/concepts/async/index.md)  
[Async Programming in F#](~/docs/fsharp/tutorials/asynchronous-and-concurrent-programming/async.md)   
[Asynchronous Programming with Async and Await (Visual Basic)](~/docs/visual-basic/programming-guide/concepts/async/index.md)
