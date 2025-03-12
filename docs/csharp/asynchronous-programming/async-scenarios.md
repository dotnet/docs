---
title: Asynchronous programming scenarios 
description: Learn about the C# language-level asynchronous programming model provided by .NET Core and explore example code for I/O-bound and CPU-bound scenarios.
author: BillWagner
ms.date: 03/12/2025
ms.subservice: async-task-programming
---
# Asynchronous programming scenarios

If your code implements I/O-bound scenarios to support network data requests, database access, or file system read/write, asynchronous programming is the best approach. You can also write asynchronous code for CPU-bound scenarios like expensive calculations.

C# has a language-level asynchronous programming model that allows you to easily write asynchronous code without having to juggle callbacks or conform to a library that supports asynchrony. The model follows what is known as the [Task-based asynchronous pattern (TAP)](../../standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md).

## Explore the asynchronous programming model

The `Task` and `Task<T>` objects represent the core of asynchronous programming. These objects are used to model asynchronous operations by supporting the `async` and `await` keywords. In most cases, the model is fairly simple for both I/O-bound and CPU-bound scenarios:

- **I/O-bound code**: Wait on an operation to return a `Task` or `Task<T>` object inside an `async` method.
- **CPU-bound code**: Wait on an operation started on a background thread with the <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType> method.

The `await` keyword is where the magic happens. It yields control to the caller of the method that performed the `await` expression, and ultimately allows a UI to be responsive or a service to be elastic. While [there are ways](../../standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md) to approach asynchronous code other than by using the `async` and `await` expressions, this article focuses on the language-level constructs.

> [!NOTE]
> Some examples presented in this article use the <xref:System.Net.Http.HttpClient?displayProperty=fullName> class to download data from a web service. In the example code, the `s_httpClient` object is a static field of type `Program` class:
>
> `private static readonly HttpClient s_httpClient = new();`
> 
> For more information, see the [complete example code](#review-the-complete-example) at the end of this article.

### Review underlying concepts

When you implement asynchronous programming in your C# code, the compiler transforms your program into a state machine. This construct tracks various operations and state in your code, such as yielding execution when the code reaches an `await` expression, and resuming execution when a background job completes.

In terms of computer science theory, asynchronous programming is an implementation of the [Promise model of asynchrony](https://en.wikipedia.org/wiki/Futures_and_promises).

In the asynchronous programming model, there are several key concepts to understand:

* You can use asynchronous code for both I/O-bound and CPU-bound code, but the implementation is different.
* Asynchronous code uses `Task<T>` and `Task` objects as constructs to model work running in the background.
* The `async` keyword turns a method into an asynchronous method, which allows you to use the `await` keyword in the method body.
* When you apply the `await` keyword, the code suspends the calling method and yields control back to its caller until the task completes.
* You can only use the `await` expression in an asynchronous method.

### I/O-bound example: Download data from web service 

In this example, when the user selects a button, the app downloads data from a web service. You don't want to block the UI thread for the app during the download process. The following code accomplishes this task:

:::code language="csharp" source="snippets/async-scenarios/Program.cs" ID="UnblockingDownload":::

The code expresses the intent (downloading data asynchronously) without getting bogged down in interacting with `Task` objects.

### CPU-bound example: Run game calculation

In the next example, a mobile game inflicts damage on several agents on the screen in response to a button event. Performing the damage calculation can be expensive. Running the calculation on the UI thread can cause display and UI interaction issues during the calculation.

The best way to handle the task is to start a background thread to complete the work with the `Task.Run` method. The operation waits on the result by using an `await` expression. This approach allows the UI to run smoothly while the work completes in the background.

:::code language="csharp" source="snippets/async-scenarios/Program.cs" ID="PerformGameCalculation":::

The code clearly expresses the intent of the button `Clicked` event. It doesn't require managing a background thread manually, and it completes the task in a nonblocking manner.

## Recognize CPU-bound and I/O-bound scenarios

The previous examples demonstrated how to use the `async` and `await` expressions for I/O-bound and CPU-bound work. An example was provided for each scenario to showcase how the code is different based on where the operation is bound. To prepare for your implementation, you need to understand how to identify when an operation is I/O-bound or CPU-bound. Your implementation choice can greatly affect the performance of your code and potentially lead to misusing constructs.

There are two primary questions to address before you write any code:

| Question | Scenario | Implementation |
| --- | --- | --- |
| _Should the code wait for a result or action, such as data from a database?_ | **I/O-bound** | Use `async` and `await` expressions _without_ the `Task.Run` method. <br><br> Avoid using the Task Parallel Library. |
| _Should the code run an expensive computation?_ | **CPU-bound** | Use `async` and `await` expressions, but spawn off the work on another thread with the `Task.Run` method. This approach addresses concerns with CPU responsiveness. <br><br> If the work is appropriate for concurrency and parallelism, also consider using the [Task Parallel Library](../../standard/parallel-programming/task-parallel-library-tpl.md). |

Always measure the execution of your code. You might discover that your CPU-bound work isn't costly enough compared with the overhead of context switches when multithreading. Every choice has tradeoffs. Pick the correct tradeoff for your situation.

## Explore other examples

The examples in this section demonstrate several ways you can write asynchronous code in C#. They cover a few scenarios you might encounter.

### Extract data from a network

The following code downloads HTML from a given URL and counts the number of times the string ".NET" occurs in the HTML. The code uses ASP.NET to define a Web API controller method, which performs the task and returns the count.

> [!NOTE]
> If you plan on doing HTML parsing in production code, don't use regular expressions. Use a parsing library instead.

:::code language="csharp" source="snippets/async-scenarios/Program.cs" ID="ExtractDataFromNetwork":::

You can write similar code for a Universal Windows App and perform the counting task after a button press:

```csharp
private readonly HttpClient _httpClient = new HttpClient();

private async void OnSeeTheDotNetsButtonClick(object sender, RoutedEventArgs e)
{
    // Capture the task handle here so we can await the background task later.
    var getDotNetFoundationHtmlTask = _httpClient.GetStringAsync("https://dotnetfoundation.org");

    // Any other work on the UI thread can be done here, such as enabling a Progress Bar.
    // It's important to do the extra work here before the "await" call,
    // so the user sees the progress bar before execution of this method is yielded.
    NetworkProgressBar.IsEnabled = true;
    NetworkProgressBar.Visibility = Visibility.Visible;

    // The await operator suspends OnSeeTheDotNetsButtonClick(), returning control to its caller.
    // This action is what allows the app to be responsive and not block the UI thread.
    var html = await getDotNetFoundationHtmlTask;
    int count = Regex.Matches(html, @"\.NET").Count;

    DotNetCountLabel.Text = $"Number of .NETs on dotnetfoundation.org: {count}";

    NetworkProgressBar.IsEnabled = false;
    NetworkProgressBar.Visibility = Visibility.Collapsed;
}
```

### Wait for multiple tasks to complete

In some scenarios, the code needs to retrieve multiple pieces of data concurrently. The `Task` APIs provides methods that enable you to write asynchronous code that performs a nonblocking wait on multiple background jobs:

- <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType> method
- <xref:System.Threading.Tasks.Task.WhenAny%2A?displayProperty=nameWithType> method

The following example shows how you might grab `User` object data for a set of `userId` objects.

:::code language="csharp" source="snippets/async-scenarios/Program.cs" ID="GetUsersForDataset":::

You can write this code more succinctly by using LINQ:

:::code language="csharp" source="snippets/async-scenarios/Program.cs" ID="GetUsersForDatasetByLINQ":::

Although you write less code by using LINQ, exercise caution when mixing LINQ with asynchronous code. LINQ uses deferred (lazy) execution. Asynchronous calls don't happen immediately as they do in a `foreach` loop unless you force the generated sequence to iterate with a call to the `.ToList()` or `.ToArray()` method. This example uses the <xref:System.Linq.Enumerable.ToArray%2A?displayProperty=nameWithType> method to perform the query eagerly and store the results in an array. This approach forces the `id => GetUserAsync(id)` statement to run and initiate the task.

## Review considerations for asynchronous programming

With asynchronous programming, there are several details to keep in mind that can prevent unexpected behavior.

### Use await inside async() method body

When you use the `async` method, you must include an `await` expression in the method body. If the compiler doesn't encounter an `await` expression, the method fails to yield. Although the compiler generates a warning, the code still compiles and the compiler runs the method. The state machine generated by the C# compiler for the asynchronous method doesn't accomplish anything, so the entire process is highly inefficient.

### Add "Async" suffix to asynchronous method names

The .NET style convention is to add the "Async" suffix to all asynchronous method names. This approach helps to more easily differentiate between synchronous and asynchronous methods. Certain methods that aren't explicitly called by your code (such as event handlers or web controller methods) don't necessarily apply in this scenario. Because these items aren't explicitly called by your code, using explicit naming isn't as important.

### Use 'async void' only with event handlers

Events don't have return types and can't use and returned `Task` and `Task<T>` objects like other methods. When you write asynchronous event handlers, you need to use the `async void` statement for the handlers. Other implementations of the `async void` call don't follow the TAP model and can present challenges:

* Exceptions thrown in an `async void` method can't be caught outside of that method
* `async void` methods are difficult to test
* `async void` methods can cause bad side effects if the caller isn't expecting them to be asynchronous

### Use caution with asynchronous lambdas in LINQ

It's important to use caution when you implement asynchronous lambdas in LINQ expressions. Lambda expressions in LINQ use deferred execution, which means the code can execute at an unexpected time. The introduction of blocking tasks into this scenario can easily result in a deadlock, if the code isn't written correctly. Moreover, the nesting of asynchronous code can also make it difficult to reason about the execution of the code. Async and LINQ are powerful, but these techniques should be used together as carefully and clearly as possible.

### Wait on tasks in a nonblocking manner

If your program needs to wait on a task, write code that implements the `await` expression in a nonblocking manner. Blocking the current thread as a means to wait for a `Task` item to complete can result in deadlocks and blocked context threads. This programming approach can require more complex error-handling. The following table provides guidance on how to deal with waiting for tasks in a nonblocking way:

| Task scenario | Current code | Replace with 'await' |
| --- | --- | --- |
| _Retrieve the result of a background task_ | `Task.Wait` or `Task.Result` | `await`              |
| _Wait for any task to complete_            | `Task.WaitAny`               | `await Task.WhenAny` |
| _Wait for **all** tasks to complete_       | `Task.WaitAll`               | `await Task.WhenAll` |
| _Wait for some amount of time_             | `Thread.Sleep`               | `await Task.Delay`   |

### Call the ValueTask() method

When an asynchronous method returns a `Task` object, performance bottlenecks might be introduced in certain paths. Because `Task` is a reference type, an object is allocated when the API is referenced. If a method declared with the `async` modifier returns a cached result or completes synchronously, the extra allocations can accrue significant time costs in performance critical sections of code. This scenario can become costly when the allocations occur in tight loops. For more information, see [generalized async return types](../language-reference/keywords/async.md#return-types).

### Understand when to set ConfigureAwait(false)

Developers often inquire about when to use the <xref:System.Threading.Tasks.Task.ConfigureAwait(System.Boolean)?displayProperty=nameWithType> boolean. This API allows for a `Task` instance to configure the waiting (`await`) thread. When the boolean isn't set correctly, performance can degrade and deadlocks can occur. For more information, see [ConfigureAwait FAQ](https://devblogs.microsoft.com/dotnet/configureawait-faq).

### Write less-stateful code

Avoid writing code that depends on the state of global objects or the execution of certain methods. Instead, depend only on the return values of methods. There are many benefits to writing code that is less-stateful:

* Easier to reason about code
* Easier to test code
* More simple to mix asynchronous and synchronous code 
* Able to avoid race conditions in code
* Simple to coordinate asynchronous code that depends on return values
* (Bonus) Works well with dependency injection in code

A recommended goal is to achieve complete or near-complete [Referential Transparency](https://en.wikipedia.org/wiki/Referential_transparency) in your code. This approach results in a predictable, testable, and maintainable codebase.

## Review the complete example

The following code represents the complete example, which is available in the *Program.cs* example file.

:::code language="csharp" source="snippets/async-scenarios/Program.cs":::

## Related links

* [The Task asynchronous programming model (C#)](task-asynchronous-programming-model.md)
