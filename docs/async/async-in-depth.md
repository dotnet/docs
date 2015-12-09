# Async In Depth

By [Phillip Carter](https://github.com/cartermp)

Writing I/O-Bound or CPU-Bound asynchronous code is simple using the `async` and `await` keywords, but what's happening under the covers is fairly complex.  The two key objects involved are `Task` and `Task<T>`.

## Task and Task<T>

Tasks are constructs used to represent operations running in the background.

*   `Task` represents a single operation which does not return a value.
*   `Task<T>` represents a single operation which returns a value of type `T`.

Tasks are awaitable, meaning that using `await` will allow your application or service to perform useful work while the task is running by yielding control to its caller until the task is done. If you’re using `Task<T>`, the `await` keyword will additionally “unwrap” the value returned when the Task is complete.

It’s important to reason about Tasks as abstractions of work happening in the background, and _not_ an abstraction over multithreading. In fact, unless explicitly started on a new thread via `Task.Run`, a Task will start on the current thread and delegate work to the Operating System.

## Deeper Dive into Tasks for an I/O-Bound Operation

Here’s a 10,000 foot view of what happens with a typical async I/O call:

```csharp
public async Task<string> GetHtml()
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

The call to `GetStringAsync` makes its way through the .NET libraries until it reaches a system interop call (such as `P/Invoke` on Windows). This eventually makes the proper System API call (such as `write` to a socket file descriptor on Linux). That System API call is then dealt with in the kernel, where the I/O request is sent to the proper subsystem. Although details about scheduling the work on the appropriate device driver are different for each OS, eventually an “incomplete task” signal will be sent from the device driver, bubbling its way back up to the .NET runtime. This will be converted into a `Task` or `Task<T>` by the runtime and returned to the calling method. When `await` is encountered, execuction is yielded and the system can go do something else.

When the device driver has the data, it sends an interrupt which eventually allows the OS to bubble the result back up to the runtime, which will then queue up the result of the Task. Eventually execution will return to the method which called `GetStringAsync` at the `await`, and will “unwrap” the return value from the `Task<string>` which was being awaited. The method now has the result!

Although many details were glossed over (such as how “borrowing” compute time on a thread pool is coordinated), the important thing to recognize here is that **no thread is 100% dedicated to running the initiated task**. This allows threads in the thread pool of a system to handle a larger volume of work rather than having to wait for I/O to finish.

**TODO:** Diagram!

Although the above may seem like a lot of work to be done, when measured in terms of wall clock time, it’s miniscule compared to the time it takes to do the actual I/O work. Although not at all precise, a potential timeline for such a call would look like this:

0-1————————————————————————————————————————————————–2-3

*   Time spent from points `0` to `1` is everything up until an async method yields control to its caller.
*   Time spent from points `1` to `2` is the time spent on I/O.
*   Finally, time spent from points `2` to `3` is passing control back (and potentially a value) to the async method, at which point it is executing again.

### What does this mean for a server scenario?

This model works well with a typical server.  Because async I/O Tasks aren't an abstraction over multithreading, it means that the server threadpool can service a much higher volume of requests than if each thread were dedicated to running a particular background job.  Because a picture is worth a thousand words:

**TODO:** diagram!

As you can see, threads are free to service requests while async jobs are running in the background.  When a background job is finished, its result gets queued up and eventually serviced by the next available thread.

You can expect a server to be able to handle an order of magnitude more requests using `async` and `await` than if it were manually spawning threads to handle background jobs.

### What does this mean for client scenario?

The biggest gain for using `async` and `await` for a client app is an increase in responsiveness.  Although you can make an app responsive by spawning threads manually, the act of spawning a thread is an expensive operation relative to just using `async` and `await`.  Especially for something like a mobile game, impacting the UI thread as little as possible where I/O is concerned is crucial.

More importantly, because the vast majority of wall clock time spent on I/O-bound code is effectively *doing nothing while the I/O happens*, dedicating an entire thread to perform barely any useful work is a poor use of resources.

## Deeper Dive into Task and Task<T> for a CPU-Bound Operation

Here's a 10,000 foot view of a CPU-bound async call:

```csharp
public async Task<int> CalculateResult(InputData data)
{
	// This queues up the work on the threadpool.
	// This call is still synchronous!
	var expensiveResultTask = Task.Run(() => DoExpensiveCalculation(data));
	
	// Note that at this point, you can do some other work concurrently.
	
	// Execution of CalculateResult is yielded here!
	var result = await expensiveResultTask;
	
	return result;
}
```

`CalculateResult` executes on the main thread.  When it calls `Task.Run`, it queues the expensive CPU-bound operation, `DoExpensiveCalculation`, on the thread pool and receives a `Task<int>` handle.  `DoExpensiveCalculation` is eventually run on the next available thread in the background.  A key takeaway is that the main thread hasn't stopped executing code yet.  It's possible to do concurrent work (such as updating a UI) while `DoExpensiveCalculation` is busy on another thread.

Once `await` is encountered, the execution of `CalculateResult` is yielded to its caller, allowing other work to be done with the current thread while `DoExpensiveCalculation` is churning out a result.  Once it has finished, the result is queued up to run on the main thread.  Eventually, the main thread will return to executing `CalculateResult`, at which point it will have the result of `DoExpensiveCalculation`.

**TODO:** Diagram!

### Why does async help here?

The use of `async` and `await` in conjunction with spawning a new task with `Task.Run` is worth considering.  Ultimately, it comes down to if you require responsiveness or not.

If you *do** reuqire a responsive app or service, awaiting heavy CPU-bound work will be valuable.

If you **do not** require a responsive app or service, there is nothing to gain by using `async` and `await`.  In fact, you will be doing things inefficiently because of the overhead involved in transforming `async` methods into state machines and queuing work across threads.

### What about Parallelism?

There's a chance that if you have heavy CPU-bound work, it can be parallelized in some way.  The [Parallel Programming Guide](www.example.com) demonstrates ways to partition work across multiple threads.

There are no changes to how you do asynchronous CPU-bound work when parallelism is concerned.  Just wrap the parallel code in a `Task<T>` via `Task.Run`:

```csharp
public async Task<int> GetValue(IEnumerable<int> values)
{
	var result = await Task.Run(() =>
	{
		var subResults = values.AsParallel().Select(item => DoExpensiveWork(item));
		return subResults.Sum();
	});
	
	return result;
}
```