# Task and Task<T>

As mentioned before, Tasks are constructs used to represent operations working in the background.

*   `Task` represents a single operation which does not return a value.
*   `Task<T>` represents a single operation which returns a value of type `T`.

Tasks are awaitable, meaning that using `await` will allow your application or service to perform useful work while the task is running by yielding control to its caller until the task is done. If you’re using `Task<T>`, the `await` keyword will additionally “unwrap” the value returned when the Task is complete.

It’s important to reason about Tasks as abstractions of work happening in the background, and _not_ an abstraction over multithreading. In fact, unless explicitly started on a new thread via `Task.Run`, a Task will start on the current thread and delegate work to the Operating System.

## Deeper Dive into Tasks

Here’s a 10,000 foot view of what happens with a typical async call:

The call (such as `GetStringAsync` from `HttpClient`) makes its way through the .NET libraries until it reaches a system interop call (such as `P/Invoke` on Windows). This eventually makes the proper System API call (such as `write` to a socket file descriptor on Linux). That System API call is then dealt with in the kernel, where the I/O request is sent to the proper subsystem. Although details about scheduling the work on the appropriate device driver are different for each OS, eventually an “incomplete task” signal will be sent from the device driver, bubbling its way back up to the .NET runtime. This will be converted into a `Task` or `Task<T>` by the runtime and returned to the calling method. When `await` is encountered, execuction is yielded and the system can go do something else useful while the Task is running.

When the device driver has the data, it sends an interrupt which eventually allows the OS to bubble the result back up to the runtime, which will the queue up the result of the Task. Eventually execution will return to the method which called `GetStringAsync` at the `await`, and will “unwrap” the return value from the `Task<string>` which was being awaited. The method now has the result!

Although many details were glossed over (such as how “borrowing” compute time on a thread pool is coordinated), the important thing to recognize here is that **no thread is 100% dedicated to running the initiated task**. This allows threads in the thread pool of a system to handle a larger volume of work rather than having to wait for I/O to finish.

Although the above may seem like a lot of work to be done, when measured in terms of wall clock time, it’s miniscule compared to the time it takes to do the actual I/O work. Although not at all precise, a potential timeline for such a call would look like this:

0-1————————————————————————————————————————————————–2-3

*   Time spent from points `0` to `1` is everything up until an async method yields control to its caller.
*   Time spent from points `1` to `2` is the time spent on I/O.
*   Finally, time spent from points `2` to `3` is passing control back (and potentially a value) to the async method, at which point it is executing again.

Tasks are also used outside of the async programming model. They are the foundation of the Task Parallel Library, which supports the parallelization of CPU-bound work via [Data Parallelism](https://msdn.microsoft.com/en-us/library/dd537608%28v=vs.110%29.aspx) and [Task Parallelism](https://msdn.microsoft.com/en-us/library/dd537609%28v=vs.110%29.aspx).


### What does this mean for Server scenarios?

some stuff about stuff

### What does this mean for Client scenarios?

some stuff about stuff