# Asynchronous programming

By [Phillip Carter](https://github.com/cartermp)

C# and Visual Basic share a language-level asynchronous programming model which allows for easily writing asynchronous code without having to juggle callbacks or conform to a library which supports asynchrony. It follows what is known as the [Task-based Asynchronous Pattern (TAP)](https://msdn.microsoft.com/library/hh873175.aspx).

The core of TAP are the `Task` and `Task<T>` objects, which model asynchronous operations, supported by the `async` and `await` keywords (`Async` and `Await` in VB), which provide a natural developer experience for interacting with Tasks. The result is the ability to write asynchronous code which cleanly expresses intent, as opposed to callbacks which express intent far less cleanly. There are other ways to approach async code than `async` and `await` outlined in the TAP article linked above, but this document will focus on the language-level constructs from this point forward.

For example, you may need to download some data from a web service when a button is pressed, but don’t want to block the UI thread. It can be accomplished simply like this:

```cs
private readonly HttpClient _httpClient = new HttpClient();

...

button.Clicked += async (o, e) =>
{
    var stringData = await _httpClient.DownloadStringAsync(URL);
    DoStuff(stringData);
};

```

And that’s it! The code expresses the intent (downloading some data asynchronously) without getting bogged down in interacting with Task objects.

For those who are more theoretically-inclined, this is an implementation of the [Future/Promise concurrency model](https://en.wikipedia.org/wiki/Futures_and_promises).

A few important things to know before continuing:

*   Async code uses `Task<T>` and `Task`, which are constructs used to model the work being done in an asynchronous context. [More on Task and Task<T>](#more-on-task-and-task-t)
*   When the `await` keyword is applied, it suspends the calling method and yields control back to its caller until the awaited task is complete. This is what allows a UI to be responsive and a service to be elastic.
*   `await` can only be used inside an async method.
*   Unless an async method has an `await` inside its body, it will never yield!
*   `async void` should **only** be used on Event Handlers (where it is required).

## Example (C#)

The following example shows how to write basic async code for both a client app and a web service. The code, in both cases, will count the number of times ”.NET” appears in the HTML of “dotnetfoundation.org”.

Client app snippet (Universal Windows App):

```cs
private readonly HttpClient _httpClient = new HttpClient();

private async void SeeTheDotNets_Click(object sender, RoutedEventArgs e)
{
    // Capture the task handle here so we can await the background task later.
    var getDotNetFoundationHtmlTask = _httpClient.GetStringAsync("http://www.dotnetfoundation.org");

    // Any other work on the UI thread can be done here, such as enabling a Progress Bar.
    // This is important to do here, before the "await" call, so that the user
    // sees the progress bar before execution of this method is yielded.
    NetworkProgressBar.IsEnabled = true;
    NetworkProgressBar.Visibility = Visibility.Visible;

    // The await operator suspends SeeTheDotNets_Click, returning control to its caller.
    // This is what allows the app to be responsive and not hang on the UI thread.
    var html = await getDotNetFoundationHtmlTask;
    int count = Regex.Matches(html, ".NET").Count;

    DotNetCountLabel.Text = $"Number of .NETs on dotnetfoundation.org: {count}";

    NetworkProgressBar.IsEnabled = false;
    NetworkProgressBar.Visbility = Visibility.Collapsed;
}

```

Web service snippet (ASP.NET MVC):

```cs
private readonly HttpClient _httpClient = new HttpClient();

[HttpGet]
[Route("DotNetCount")]
public async Task<int> GetDotNetCountAsync()
{
    // Suspends GetDotNetCountAsync() to allow the caller (the web server)
    // to accept another request, rather than blocking on this one.
    var html = await _httpClient.DownloadStringAsync("http://dotnetfoundation.org");

    return Regex.Matches(html, ".NET").Count;
}

```

## More on Task and Task<T>

As mentioned before, Tasks are constructs used to represent operations working in the background.

*   `Task` represents a single operation which does not return a value.
*   `Task<T>` represents a single operation which returns a value of type `T`.

Tasks are awaitable, meaning that using `await` will allow your application or service to perform useful work while the task is running by yielding control to its caller until the task is done. If you’re using `Task<T>`, the `await` keyword will additionally “unwrap” the value returned when the Task is complete.

It’s important to reason about Tasks as abstractions of work happening in the background, and _not_ an abstraction over multithreading. In fact, unless explicitly started on a new thread via `Task.Run`, a Task will start on the current thread and delegate work to the Operating System.

Here’s a 10,000 foot view of what happens with a typical async call:

The call (such as `GetStringAsync` from `HttpClient`) makes its way through the .NET libraries until it reaches a system interop call (such as `P/Invoke` on Windows). This eventually makes the proper System API call (such as `write` to a socket file descriptor on Linux). That System API call is then dealt with in the kernel, where the I/O request is sent to the proper subsystem. Although details about scheduling the work on the appropriate device driver are different for each OS, eventually an “incomplete task” signal will be sent from the device driver, bubbling its way back up to the .NET runtime. This will be converted into a `Task` or `Task<T>` by the runtime and returned to the calling method. When `await` is encountered, execuction is yielded and the system can go do something else useful while the Task is running.

When the device driver has the data, it sends an interrupt which eventually allows the OS to bubble the result back up to the runtime, which will the queue up the result of the Task. Eventually execution will return to the method which called `GetStringAsync` at the `await`, and will “unwrap” the return value from the `Task<string>` which was being awaited. The method now has the result!

Although many details were glossed over (such as how “borrowing” compute time on a thread pool is coordinated), the important thing to recognize here is that **no thread is 100% dedicated to running the initiated task**. This allows threads in the thread pool of a system to handle a larger volume of work rather than having to wait for I/O to finish.

Although the above may seem like a lot of work to be done, when measured in terms of wall clock time, it’s miniscule compared to the time it takes to do the actual I/O work. Although not at all precise, a potential timeline for such a call would look like this:

0-1————————————————————————————————————————————————–2-3

*   Time spent from points `0` to `1` is everything up until an async method yields control to its caller.
*   Time spent from points `1` to `2` is the time spent on I/O.
*   Finally, time spent from points `2` to `3` is passing control back (and potentially a value) to the async method, at which point it is executing again.

Tasks are also used outside of the async programming model. They are the foundation of the Task Parallel Library, which supports the parallelization of CPU-bound work via [Data Parallelism](https://msdn.microsoft.com/library/dd537608.aspx) and [Task Parallelism](https://msdn.microsoft.com/library/dd537609.aspx).

## Important Info and Advice

Although async programming is relatively straightforward, there are some details to keep in mind which can prevent unexpected behavior.

*   **You should add “Async” as the suffix of every async method name you write.**

This is the convention used in .NET to more-easily differentiate synchronous and asynchronous methods. Note that certain methods which aren’t explicitly called by your code (such as event handlers or web controller methods) don’t necessarily apply. Because these are not explicitly called by your code, being explicit about their naming isn’t as important.

*   `async void` **should only be used for event handlers.**

`async void` is the only way to allow asynchronous event handlers to work because events do not have return types (thus cannot make use of `Task` and `Task<T>`). Any other use of ``async void` does not follow the TAP model and can be challenging to use, such as:

  *   Exceptions thrown in an `async void` method can’t be caught outside of that method.
  *   `async void` methods are very difficult to test.
  *   `async void` methods can cause bad side effects if the caller isn’t expecting them to be async.

*   **Tread carefully when using async lambdas in LINQ expressions**

Lambda expressions in LINQ use deferred execution, meaning code could end up executing at a time when you’re not expecting it to. The introduction of blocking tasks into this can easily result in a deadlock if not written correctly. Additionally, the nesting of asynchronous code like this can also make it more difficult to reason about the execution of the code. Async and LINQ are powerful, but should be used together as carefully and clearly as possible.

*   **Write code that awaits Tasks in a non-blocking manner**

Blocking the current thread as a means to wait for a Task to complete can result in deadlocks and blocked context threads, and can require significantly more complex error-handling. The following table provides guidance on how to deal with waiting for Tasks in a non-blocking way:

| Use this... | Instead of this... | When wishing to do this |
| --- | --- | --- |
| `await` | `Task.Wait` or `Task.Result` | Retrieving the result of a background task |
| `await Task.WhenAny` | `Task.WaitAny` | Waiting for any task to complete |
| `await Task.WhenAll` | `Task.WaitAll` | Waiting for all tasks to complete |
| `await Task.Delay` | `Thread.Sleep` | Waiting for a period of time |

*   **Write less stateful code**

Don’t depend on the state of global objects or the execution of certain methods. Instead, depend only on the return values of methods. Why?

  *   Code will be easier to reason about.
  *   Code will be easier to test.
  *   Mixing async and synchronous code is far simpler.
  *   Race conditions can typically be avoided altogether.
  *   Depending on return values makes coordinating async code simple.
  *   (Bonus) it works really well with dependency injection.

A recommended goal is to achieve complete or near-complete [Referential Transparency](https://en.wikipedia.org/wiki/Referential_transparency_%28computer_science%29) in your code. Doing so will result in an extremely predictable, testable, and maintainable codebase.

