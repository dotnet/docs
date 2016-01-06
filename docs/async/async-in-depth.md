# Async In Depth

By [Phillip Carter](https://github.com/cartermp)

Writing I/O-Bound or CPU-Bound asynchronous code is simple using the `async` and `await` keywords.  The two key types involved are `Task` and `Task<T>`.  This article explains the fairly complex machinery used under the covers.

## Task and Task<T>

Tasks are constructs used to implement what is known as the [Promise Model of Concurrency](https://en.wikipedia.org/wiki/Futures_and_promises).  In short, they offer you a "promise" that work will be completed at a later point, letting you coordinate that with a clean API.

*   `Task` represents a single operation which does not return a value.
*   `Task<T>` represents a single operation which returns a value of type `T`.

It’s important to reason about Tasks as abstractions of work happening asynchronously, and *not* an abstraction over multithreading. In fact, unless explicitly started on a new thread via `Task.Run`, a Task will start on the current thread and delegate work to the Operating System.

You can learn more about Tasks and different ways to interact with them in the [Task-based Asynchronous Pattern (TAP) Article](https://msdn.microsoft.com/en-us/library/hh873175(v=vs.110).aspx).

Lastly, as explained in the TAP artcile, Tasks are awaitable.  This means that using `await` will allow your application or service to perform useful work while the task is running by yielding control to its caller until the task is done. If you’re using `Task<T>`, the `await` keyword will additionally “unwrap” the value returned when the Task is complete.  The details of how this works are explained further below.

## Deeper Dive into Tasks for an I/O-Bound Operation

Here’s a 10,000 foot view of what happens with a typical async I/O call:

```csharp
public async Task<string> GetHtmlAsync()
{
	var client = new HttpClient();
	
	// Execution is still synchronous here!
	// The task handle "getHtmlTask" represents the active HTTP request.
	var getHtmlTask = client.GetStringAsync("http://www.dotnetfoundation.org");
	
	// Execution of GetHtml() is yielded to the caller here!
	var html = await getHtmlTask;
	
	return html;
}
```

The call to `GetStringAsync()` makes its way through the .NET libraries and runtime (perhaps hitting other async calls) until it reaches a system interop call (such as `P/Invoke` into Windows). It's worth noting that if an `await` is ever encountered in the library layer, a `Task<T>` object will be passed back to `GetHtmlAsync()`, `GetHtmlAsync()` will reach its `await`, and control over `GetHtmlAsync()` will also be yielded.  Regardless of if this happens, The interop layer of the runtime will make the proper System API call (such as `write()` to a socket on Linux), thus leaving user space and entering kernel space.  This is where the real "magic" of async I/O happens.

After the System API call, the request is now in kernel space, making its way to the networking subsystem of the OS (such as `/net` in the Linux Kernel).  Here the OS will handle the networking request *asynchronously*.  Details may be different depending on the OS used (the device driver call may be scheduled as a signal is sent back to the runtime, or a device driver call may be made and *then* a signal sent back), but eventually the runtime will be informed that the networking request is in progress.  At this time, the work for the device driver will either be scheduled, in-progress, or already finished (the request is already out "over the wire") - but because this is all happening asynchronously, the device driver is able to immediately handle something else!

For example, in Windows an OS thread makes a call to the network device driver and asks it to perform the networking operation via an Interrupt Request Packet (IRP) which represents the operation.  The device driver recieves the IRP, makes the call to the network, marks the IRP as "pending", and returns back to the OS.  Because the OS thread now knows that the IRP is "pending", it doesn't have any more work to do for this job and "returns" back to the runtime so that it can be used to perform other work.

Once the info from the OS makes it back to the .NET runtime, the runtime will then create a `Task` or `Task<T>` which will be returned to `GetHtmlAsync()` and assigned to the `getHtmlTask` variable.  Note that at this point, although the I/O request is happening asynchronously, the system which called `GetHtmlAsync()` is still running synchronously!  When the `await` keyword is encountered, only then is execution yielded to the caller of `GetHtmlAsync()`, and the execution context that it was called in will be free to do other work.

**TODO:** Diagram of the above two paragraphs

When the request is fulfilled and data comes back through the device driver, it notifies the CPU of new data received via an interrupt.  How this interrupt gets handled will vary depending on the OS, but eventually the data will be passed through the OS until it reaches a system interop call (for example, in Linux an interrupt handler will schedule the bottom half of the IRQ to pass the data up through the OS asynchronously).  Note that this *also* happens asynchronously!

Once the data is passed into the runtime, it is then queued up as the result for the `Task<T>` which corresponds to `getHtmlTask`.  The caller of `GetHtmlAsync()` will eventually return execution to `GetHtmlAsync()`, and the result of the request is "unwrapped" into a `string`, which is then assigned to the `html` variable.

**TODO:** Diagram of the above two paragraphs

Throughout this entire process, a key takeaway is that **no thread is 100% dedicated to running the task**.  Tasks have no thread affinity.  Although work is executed in some contexts (after all, the OS does have to make its way through passing data to a device driver and responding to an interrupt), there is no thread dedicated to sitting there and *waiting* for data from the request to come back.  This allows the system to handle a much larger volume of work rather than waiting for some I/O call to finish.

Although the above may seem like a lot of work to be done, when measured in terms of wall clock time, it’s miniscule compared to the time it takes to do the actual I/O work. Although not at all precise, a potential timeline for such a call would look like this:

0-1————————————————————————————————————————————————–2-3

*   Time spent from points `0` to `1` is everything up until an async method yields control to its caller.
*   Time spent from points `1` to `2` is the time spent on I/O.
*   Finally, time spent from points `2` to `3` is passing control back (and potentially a value) to the async method, at which point it is executing again.

### What does this mean for a server scenario?

This model works well with a typical server scenario workload.  Because async I/O Tasks aren't an abstraction over threading, it means that the server threadpool can service a much higher volume of web requests than if each thread were dedicated to running a particular request.  Consider two servers: one that uses async code, and one that does not.  For the purpose of this example, each server only has 5 threads available to service requests.

Say each server receives 6 concurrent requests, which each ask for a resource that requires I/O of some sort.  The server *without* async code has to queue up the 6th request until one of the 5 threads have finished the I/O-bound work and written a response:

**TODO:** non-async diagram of server

That's not an ideal scenario.  The server *with* async still queues up the 6th request, but because it uses `async` and `await` each of its threads are freed up when the I/O-bound work starts, rather than when it finishes:

**TODO:** async diagram of same server

As you can see, the 5 threads doing I/O-bound work are freed after they start that work, allowing one of them to service the 6th request much sooner.  When an I/O-bound job is complete, its result is placed in a queue and the next available thread picks it up and the response.

Although this is a contrived example, it works in a very similar fashion in the real world.  In fact, you can expect a server to be able to handle an order of magnitude more requests using `async` and `await` than if it were dedicating a thread for each request it receives.

### What does this mean for client scenario?

The biggest gain for using `async` and `await` for a client app is an increase in responsiveness.  Although you can make an app responsive by spawning threads manually, the act of spawning a thread is an expensive operation relative to just using `async` and `await`.  Especially for something like a mobile game, impacting the UI thread as little as possible where I/O is concerned is crucial.

More importantly, because I/O-bound work spends virtually no time on the CPU, dedicating an entire CPU thread to perform barely any useful work would be a poor use of resources.

**TODO:** Diagram showing yielding I/O stuff as UI thread can now do other work

Additionally, dispatching work to the UI thread (such as updating a UI) is very simple with `async` methods, and does not require extra work (such as calling a thread-safe delegate).

## Deeper Dive into Task and Task<T> for a CPU-Bound Operation

CPU-bound `async` code is a bit different than I/O-bound `async` code.  Because the work is done on the CPU, there's no way to get around dedicating a thread to the computation.  The use of `async` and `await` here doesn't buy you anything other than a clean way to interact with a background thread and keep the caller of the async method responsive.

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

`CalculateResult()` executes on the thread it was called on.  When it calls `Task.Run`, it queues the expensive CPU-bound operation, `DoExpensiveCalculation()`, on the thread pool and receives a `Task<int>` handle.  `DoExpensiveCalculation()` is eventually run concurrently on the next available thread.  It's possible to do concurrent work while `DoExpensiveCalculation()` is busy on another thread, because the thread which called `CalculateResult()` is still executing.

Once `await` is encountered, the execution of `CalculateResult()` is yielded to its caller, allowing other work to be done with the current thread while `DoExpensiveCalculation()` is churning out a result.  Once it has finished, the result is queued up to run on the main thread.  Eventually, the main thread will return to executing `CalculateResult()`, at which point it will have the result of `DoExpensiveCalculation()`.

### Why does async help here?

`async` and `await` are the best practice for being responsive while performing CPU-bound work.  This is a decision you'll have to evaluate.  If there is value in adding responsiveness to an operationg that's CPU-bound, `async` and `await` are a great way to make that happen.

It's important to note that if you don't gain anything from adding responsiveness to your CPU-bound work, `async` and `await` will actually be a performance hit over just calling the code directly on the same thread.  This is because there is overhead in scheduling work on the threadpool and the runtime's coordination of Tasks to represent the work being done.