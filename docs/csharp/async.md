---
title: Asynchronous programming - C#
description: Learn about the C# language-level asynchronous programming model provided by .NET Core.
author: cartermp
ms.date: 05/20/2020
ms.technology: csharp-async
ms.assetid: b878c34c-a78f-419e-a594-a2b44fa521a4
---
# Asynchronous programming

If you have any I/O-bound needs (such as requesting data from a network, accessing a database, or reading and writing to a file system), you'll want to utilize asynchronous programming. You could also have CPU-bound code, such as performing an expensive calculation, which is also a good scenario for writing async code.

C# has a language-level asynchronous programming model, which allows for easily writing asynchronous code without having to juggle callbacks or conform to a library that supports asynchrony. It follows what is known as the [Task-based Asynchronous Pattern (TAP)](../standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md).

## Overview of the asynchronous model

The core of async programming is the `Task` and `Task<T>` objects, which model asynchronous operations. They are supported by the `async` and `await` keywords. The model is fairly simple in most cases:

- For I/O-bound code, you await an operation that returns a `Task` or `Task<T>` inside of an `async` method.
- For CPU-bound code, you await an operation that is started on a background thread with the <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType> method.

The `await` keyword is where the magic happens. It yields control to the caller of the method that performed `await`, and it ultimately allows a UI to be responsive or a service to be elastic. While [there are ways](../standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md) to approach async code other than `async` and `await`, this article focuses on the language-level constructs.

### I/O-bound example: Download data from a web service

You may need to download some data from a web service when a button is pressed but don't want to block the UI thread. It can be accomplished like this:

```csharp
private readonly HttpClient _httpClient = new HttpClient();

downloadButton.Clicked += async (o, e) =>
{
    // This line will yield control to the UI as the request
    // from the web service is happening.
    //
    // The UI thread is now free to perform other work.
    var stringData = await _httpClient.GetStringAsync(URL);
    DoSomethingWithData(stringData);
};
```

The code expresses the intent (downloading data asynchronously) without getting bogged down in interacting with `Task` objects.

### CPU-bound example: Perform a calculation for a game

Say you're writing a mobile game where pressing a button can inflict damage on many enemies on the screen. Performing the damage calculation can be expensive, and doing it on the UI thread would make the game appear to pause as the calculation is performed!

The best way to handle this is to start a background thread, which does the work using `Task.Run`, and await its result using `await`. This allows the UI to feel smooth as the work is being done.

```csharp
private DamageResult CalculateDamageDone()
{
    // Code omitted:
    //
    // Does an expensive calculation and returns
    // the result of that calculation.
}

calculateButton.Clicked += async (o, e) =>
{
    // This line will yield control to the UI while CalculateDamageDone()
    // performs its work. The UI thread is free to perform other work.
    var damageResult = await Task.Run(() => CalculateDamageDone());
    DisplayDamage(damageResult);
};
```

This code clearly expresses the intent of the button's click event, it doesn't require managing a background thread manually, and it does so in a non-blocking way.

### What happens under the covers

There are many moving pieces where asynchronous operations are concerned. If you're curious about what's happening underneath the covers of `Task` and `Task<T>`, see the [Async in-depth](../standard/async-in-depth.md) article for more information.

On the C# side of things, the compiler transforms your code into a state machine that keeps track of things like yielding execution when an `await` is reached and resuming execution when a background job has finished.

For the theoretically inclined, this is an implementation of the [Promise Model of asynchrony](https://en.wikipedia.org/wiki/Futures_and_promises).

## Key pieces to understand

* Async code can be used for both I/O-bound and CPU-bound code, but differently for each scenario.
* Async code uses `Task<T>` and `Task`, which are constructs used to model work being done in the background.
* The `async` keyword turns a method into an async method, which allows you to use the `await` keyword in its body.
* When the `await` keyword is applied, it suspends the calling method and yields control back to its caller until the awaited task is complete.
* `await` can only be used inside an async method.

## Recognize CPU-bound and I/O-bound work

The first two examples of this guide showed how you could use `async` and `await` for I/O-bound and CPU-bound work. It's key that you can identify when a job you need to do is I/O-bound or CPU-bound because it can greatly affect the performance of your code and could potentially lead to misusing certain constructs.

Here are two questions you should ask before you write any code:

1. Will your code be "waiting" for something, such as data from a database?

   If your answer is "yes", then your work is **I/O-bound**.

1. Will your code be performing an expensive computation?

   If you answered "yes", then your work is **CPU-bound**.

If the work you have is **I/O-bound**, use `async` and `await` *without* `Task.Run`. You *should not* use the Task Parallel Library. The reason for this is outlined in [Async in Depth](../standard/async-in-depth.md).

If the work you have is **CPU-bound** and you care about responsiveness, use `async` and `await`, but spawn off the work on another thread *with* `Task.Run`. If the work is appropriate for concurrency and parallelism, also consider using the [Task Parallel Library](../standard/parallel-programming/task-parallel-library-tpl.md).

Additionally, you should always measure the execution of your code. For example, you may find yourself in a situation where your CPU-bound work is not costly enough compared with the overhead of context switches when multithreading. Every choice has its tradeoff, and you should pick the correct tradeoff for your situation.

## More examples

The following examples demonstrate various ways you can write async code in C#. They cover a few different scenarios you may come across.

### Extract data from a network

This snippet downloads the HTML from the homepage at <https://dotnetfoundation.org> and counts the number of times the string ".NET" occurs in the HTML. It uses ASP.NET to define a Web API controller method, which performs this task and returns the number.

> [!NOTE]
> If you plan on doing HTML parsing in production code, don't use regular expressions. Use a parsing library instead.

```csharp
private readonly HttpClient _httpClient = new HttpClient();

[HttpGet, Route("DotNetCount")]
public async Task<int> GetDotNetCount()
{
    // Suspends GetDotNetCount() to allow the caller (the web server)
    // to accept another request, rather than blocking on this one.
    var html = await _httpClient.GetStringAsync("https://dotnetfoundation.org");

    return Regex.Matches(html, @"\.NET").Count;
}
```

Here's the same scenario written for a Universal Windows App, which performs the same task when a Button is pressed:

```csharp
private readonly HttpClient _httpClient = new HttpClient();

private async void OnSeeTheDotNetsButtonClick(object sender, RoutedEventArgs e)
{
    // Capture the task handle here so we can await the background task later.
    var getDotNetFoundationHtmlTask = _httpClient.GetStringAsync("https://dotnetfoundation.org");

    // Any other work on the UI thread can be done here, such as enabling a Progress Bar.
    // This is important to do here, before the "await" call, so that the user
    // sees the progress bar before execution of this method is yielded.
    NetworkProgressBar.IsEnabled = true;
    NetworkProgressBar.Visibility = Visibility.Visible;

    // The await operator suspends OnSeeTheDotNetsButtonClick(), returning control to its caller.
    // This is what allows the app to be responsive and not block the UI thread.
    var html = await getDotNetFoundationHtmlTask;
    int count = Regex.Matches(html, @"\.NET").Count;

    DotNetCountLabel.Text = $"Number of .NETs on dotnetfoundation.org: {count}";

    NetworkProgressBar.IsEnabled = false;
    NetworkProgressBar.Visibility = Visibility.Collapsed;
}
```

### Wait for multiple tasks to complete

You may find yourself in a situation where you need to retrieve multiple pieces of data concurrently. The `Task` API contains two methods, <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Task.WhenAny%2A?displayProperty=nameWithType>, that allow you to write asynchronous code that performs a non-blocking wait on multiple background jobs.

This example shows how you might grab `User` data for a set of `userId`s.

```csharp
public async Task<User> GetUserAsync(int userId)
{
    // Code omitted:
    //
    // Given a user Id {userId}, retrieves a User object corresponding
    // to the entry in the database with {userId} as its Id.
}

public static async Task<IEnumerable<User>> GetUsersAsync(IEnumerable<int> userIds)
{
    var getUserTasks = new List<Task<User>>();
    foreach (int userId in userIds)
    {
        getUserTasks.Add(GetUserAsync(userId));
    }

    return await Task.WhenAll(getUserTasks);
}
```

Here's another way to write this more succinctly, using LINQ:

```csharp
public async Task<User> GetUserAsync(int userId)
{
    // Code omitted:
    //
    // Given a user Id {userId}, retrieves a User object corresponding
    // to the entry in the database with {userId} as its Id.
}

public static async Task<User[]> GetUsersAsync(IEnumerable<int> userIds)
{
    var getUserTasks = userIds.Select(id => GetUserAsync(id));
    return await Task.WhenAll(getUserTasks);
}
```

Although it's less code, use caution when mixing LINQ with asynchronous code. Because LINQ uses deferred (lazy) execution, async calls won't happen immediately as they do in a `foreach` loop unless you force the generated sequence to iterate with a call to `.ToList()` or `.ToArray()`.

## Important info and advice

With async programming, there are some details to keep in mind that can prevent unexpected behavior.

* `async` **methods need to have an** `await` **keyword in their body or they will never yield!**

  This is important to keep in mind. If `await` is not used in the body of an `async` method, the C# compiler generates a warning, but the code compiles and runs as if it were a normal method. This is incredibly inefficient, as the state machine generated by the C# compiler for the async method is not accomplishing anything.

* **Add "Async" as the suffix of every async method name you write.**

  This is the convention used in .NET to more easily differentiate synchronous and asynchronous methods. Certain methods that aren't explicitly called by your code (such as event handlers or web controller methods) don't necessarily apply. Because they are not explicitly called by your code, being explicit about their naming isn't as important.

* `async void` **should only be used for event handlers.**

  `async void` is the only way to allow asynchronous event handlers to work because events do not have return types (thus cannot make use of `Task` and `Task<T>`). Any other use of `async void` does not follow the TAP model and can be challenging to use, such as:

  * Exceptions thrown in an `async void` method can't be caught outside of that method.
  * `async void` methods are difficult to test.
  * `async void` methods can cause bad side effects if the caller isn't expecting them to be async.

* **Tread carefully when using async lambdas in LINQ expressions**

  Lambda expressions in LINQ use deferred execution, meaning code could end up executing at a time when you're not expecting it to. The introduction of blocking tasks into this can easily result in a deadlock if not written correctly. Additionally, the nesting of asynchronous code like this can also make it more difficult to reason about the execution of the code. Async and LINQ are powerful but should be used together as carefully and clearly as possible.

* **Write code that awaits Tasks in a non-blocking manner**

  Blocking the current thread as a means to wait for a `Task` to complete can result in deadlocks and blocked context threads and can require more complex error-handling. The following table provides guidance on how to deal with waiting for tasks in a non-blocking way:

  | Use this...          | Instead of this...           | When wishing to do this...                 |
  |----------------------|------------------------------|--------------------------------------------|
  | `await`              | `Task.Wait` or `Task.Result` | Retrieving the result of a background task |
  | `await Task.WhenAny` | `Task.WaitAny`               | Waiting for any task to complete           |
  | `await Task.WhenAll` | `Task.WaitAll`               | Waiting for all tasks to complete          |
  | `await Task.Delay`   | `Thread.Sleep`               | Waiting for a period of time               |

* **Consider using** `ValueTask` **where possible**

  Returning a `Task` object from async methods can introduce performance bottlenecks in certain paths. `Task` is a reference type, so using it means allocating an object. In cases where a method declared with the `async` modifier returns a cached result or completes synchronously, the extra allocations can become a significant time cost in performance critical sections of code. It can become costly if those allocations occur in tight loops. For more information, see [generalized async return types](language-reference/keywords/async.md#return-types).

* **Consider using** `ConfigureAwait(false)`

  A common question is, "when should I use the <xref:System.Threading.Tasks.Task.ConfigureAwait(System.Boolean)?displayProperty=nameWithType> method?". The method allows for a `Task` instance to configure its awaiter. This is an important consideration and setting it incorrectly could potentially have performance implications and even deadlocks. For more information on `ConfigureAwait`, see the [ConfigureAwait FAQ](https://devblogs.microsoft.com/dotnet/configureawait-faq).

* **Write less stateful code**

  Don't depend on the state of global objects or the execution of certain methods. Instead, depend only on the return values of methods. Why?

  * Code will be easier to reason about.
  * Code will be easier to test.
  * Mixing async and synchronous code is far simpler.
  * Race conditions can typically be avoided altogether.
  * Depending on return values makes coordinating async code simple.
  * (Bonus) it works really well with dependency injection.

A recommended goal is to achieve complete or near-complete [Referential Transparency](https://en.wikipedia.org/wiki/Referential_transparency_%28computer_science%29) in your code. Doing so will result in a predictable, testable, and maintainable codebase.

## Other resources

* [Async in-depth](../standard/async-in-depth.md) provides more information about how Tasks work.
* [The Task asynchronous programming model (C#)](./programming-guide/concepts/async/task-asynchronous-programming-model.md).
