---
title: Asynchronous programming
description: Explore an overview of the C# language support for asynchronous programming by using async, await, Task, and Task<T>.
ms.date: 03/10/2025
---
# Asynchronous programming with async and await

The [task asynchronous programming model](task-asynchronous-programming-model.md) provides a layer of abstraction over typical asynchronous coding. In this model, you write code as a sequence of statements, the same as usual. The difference is you can read your task-based code as the compiler processes each statement and before it starts processing the next statement. To accomplish this model, the compiler performs many transformations to complete each task. Some statements can initiate work and return a <xref:System.Threading.Tasks.Task> object that represents the ongoing work and the complier must resolve these transformations. The goal of task asynchronous programming is to enable code that reads like a sequence of statements, but executes in a more complicated order. Execution is based on external resource allocation and when tasks complete.

The task asynchronous programming model is analogous to how people give instructions for processes that include asynchronous tasks. This article uses an example with instructions for making breakfast to show how the `async` and `await` keywords make it easier to reason about code that includes a series of asynchronous instructions. The instructions for making a breakfast might be provided as a list:

1. Pour a cup of coffee.
1. Heat a pan, then fry two eggs.
1. Fry three slices of bacon.
1. Toast two pieces of bread.
1. Spread butter and jam on the toast.
1. Pour a glass of orange juice.

If you have experience with cooking, you might complete these instructions **asynchronously**. You start warming the pan for eggs, then start frying the bacon. You put the bread in the toaster, then start cooking the eggs. At each step of the process, you start a task, and then transition to other tasks that are ready for your attention.

Cooking breakfast is a good example of asynchronous work that isn't parallel. One person (or thread) can handle all the tasks. One person can make breakfast asynchronously by starting the next task before the previous task completes. Each cooking task progresses regardless of whether someone is actively watching the process. As soon as you start warming the pan for the eggs, you can begin frying the bacon. After the bacon starts to cook, you can put the bread in the toaster.

For a parallel algorithm, you need multiple people who cook (or multiple threads). One person cooks the eggs, another fries the bacon, and so on. Each person focuses on their one specific task. Each person who is cooking (or thread) is blocked synchronously awaiting for the current task to complete: Bacon ready to flip, Bread ready to pop up in toaster, and so on.

:::image type="content" source="media/synchronous-breakfast.png" alt-text="Diagram that shows instructions for preparing breakfast as a list of seven sequential tasks completed in 30 minutes.":::

Consider the same list of synchronous instructions written as C# code statements:

:::code language="csharp" source="snippets/index/AsyncBreakfast-starter/Program.cs" highlight="15-34":::

When you cook the breakfast in a synchronous manner, it takes about 30 minutes to prepare. The duration is the sum of the individual task times. But computers don't interpret cooking instructions the same way people do. The computer blocks each task statement until all work completes, and then it proceeds to the next task statement. This approach can take significant time. In the breakfast example, the computer method creates an unsatisfying breakfast. Later tasks in the synchronous list like toasting the bread don't start until earlier tasks complete. Some food gets cold before the breakfast is ready to serve.

If you want the computer to execute instructions asynchronously, you must write asynchronous code. When you write client programs, you want the UI to be responsive to user input. Your application shouldn't freeze all interaction while downloading data from the web. When you write server programs, you don't want to block threads that might be serving other requests. Using synchronous code when asynchronous alternatives exist, hurts your ability to scale out less expensively. You pay for blocked threads.

Successful modern apps require asynchronous code. Without language support, writing asynchronous code requires callbacks, completion events, or other means that obscure the original intent of the code. The advantage of synchronous code is the step-by-step action that makes it easy to scan and understand. Traditional asynchronous models force you to focus on the asynchronous nature of the code, not on the fundamental actions of the code.

## Don't block, await instead

The previous code highlights an unfortunate programming practice: Writing synchronous code to perform asynchronous operations. The code blocks the current thread from doing any other work. The code doesn't interrupt the thread while there are running tasks. The outcome of this model is similar to you staring at the toaster after you put in the bread. In this scenario, you ignore any interruptions and don't start other tasks until the bread pops up. You might ignore a phone call, forget to take the butter and jam out of the fridge, or miss seeing a fire starting on the stove.

In your daily life, you don't want to overlook problems or miss opportunities. You want to both toast the bread and handle other concerns at the same time. The same is true with your code. 

You can start by updating the code so the thread doesn't block while tasks are running. The `await` keyword provides a nonblocking way to start a task, then continue execution when the task completes. A simple asynchronous version of the breakfast code looks like the following snippet:

:::code language="csharp" source="snippets/index/AsyncBreakfast-V2/Program.cs" ID="SnippetMain":::

The code updates the method bodies of `FryEggsAsync`, `FryBaconAsync`, and `ToastBreadAsync` to return `Task<Egg>`, `Task<Bacon>`, and `Task<Toast>` objects, respectively. The method names include the "Async" suffix. The `Main` method returns the `Task` object, although it doesn't have a `return` expression, which is by design. For more information, see [Evaluation of a void-returning async function](/dotnet/csharp/language-reference/language-specification/classes#14153-evaluation-of-a-void-returning-async-function).

> [!NOTE]
> The updated code doesn't yet take advantage of key features of asynchronous programming, which can result in shorter completion times. The code processes the tasks in roughly the same amount of time as the initial synchronous version. For the full method implementations, see the [final version](#review-final-version) later in this article. 

Let's apply the breakfast example to the updated code. The thread doesn't block while the eggs or bacon are cooking, but the code also doesn't start other tasks until the current work completes. You still put the bread in the toaster and stare at the toaster until the bread pops up, but you can now respond to interruptions. In a restaurant where multiple orders are placed, the cook can start a new order while another is already cooking.

In the updated code, the thread working on the breakfast isn't blocked while awaiting for any started task that's unfinished. For some applications, this change is all you need. You can enable your app to support user interaction while data downloads from the web. But in other scenarios, you want more. You don't want each component task to execute sequentially. A better approach is to start each component task before awaiting for the previous task to complete.

## Start tasks concurrently

For most operations, you want to start several independent tasks immediately. As each task completes, you initiate other work that's ready to start. When you apply this methodology to the breakfast example, you can prepare breakfast more quickly. You also get everything ready close to the same time, so you can enjoy a hot breakfast.

The <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> class and related types are classes you can use to apply this style of reasoning to tasks that are in progress. This approach enables you to write code that more closely resembles the way you create breakfast in real life. You start cooking the eggs, bacon, and toast at the same time. As each food item requires action, you turn your attention to that task, take care of the action, and then await for something else that requires your attention.

In your code, you start a task and hold on to the <xref:System.Threading.Tasks.Task> object that represents the work. You use the `await` method on the task to delay acting on the work until the result is ready.

Apply these changes to the breakfast code. The first step is to store the tasks for operations when they start, rather than awaiting them:

```csharp
Coffee cup = PourCoffee();
Console.WriteLine("Coffee is ready");

Task<Egg> eggsTask = FryEggsAsync(2);
Egg eggs = await eggsTask;
Console.WriteLine("Eggs are ready");

Task<Bacon> baconTask = FryBaconAsync(3);
Bacon bacon = await baconTask;
Console.WriteLine("Bacon is ready");

Task<Toast> toastTask = ToastBreadAsync(2);
Toast toast = await toastTask;
ApplyButter(toast);
ApplyJam(toast);
Console.WriteLine("Toast is ready");

Juice oj = PourOJ();
Console.WriteLine("Oj is ready");
Console.WriteLine("Breakfast is ready!");
```

These revisions don't help to get your breakfast ready any faster. The tasks are all awaited as soon as they start.

The next step is to move the `await` statements for the bacon and eggs to the end of the method, before you serve the breakfast:

```csharp
Coffee cup = PourCoffee();
Console.WriteLine("Coffee is ready");

Task<Egg> eggsTask = FryEggsAsync(2);
Task<Bacon> baconTask = FryBaconAsync(3);
Task<Toast> toastTask = ToastBreadAsync(2);

Toast toast = await toastTask;
ApplyButter(toast);
ApplyJam(toast);
Console.WriteLine("Toast is ready");
Juice oj = PourOJ();
Console.WriteLine("Oj is ready");

Egg eggs = await eggsTask;
Console.WriteLine("Eggs are ready");
Bacon bacon = await baconTask;
Console.WriteLine("Bacon is ready");

Console.WriteLine("Breakfast is ready!");
```

You now have an asynchronously prepared breakfast that takes about 20 minutes to prepare. The total cook time is reduced because some tasks run concurrently.

:::image type="content" source="media/asynchronous-breakfast.png" alt-text="Diagram that shows instructions for preparing breakfast as eight asynchronous tasks that complete in about 20 minutes, where unfortunately, the eggs and bacon burn.":::

The code updates improve the preparation process by reducing the cook time, but they introduce a regression by burning the eggs and bacon. You start all the asynchronous tasks at once. You await each task only when you need the results. The code might be similar to code in a web application that makes requests to different microservices, then combines the results into a single page. You make all the requests immediately, then await all those tasks and compose the web page.

## Support composition with tasks

The previous code revisions help get everything ready for breakfast at the same time, except the toast. The process of making the toast is a _composition_ of an asynchronous operation (toast the bread) with synchronous operations (spread butter and jam on the toast). This example illustrates an important concept about asynchronous programming:

> [!IMPORTANT]
> The composition of an asynchronous operation followed by synchronous work is an asynchronous operation. Stated another way, if any portion of an operation is asynchronous, the entire operation is asynchronous.

In the previous updates, you learned how to use <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> objects to hold running tasks. You await each task before you use its result. The next step is to create methods that represent the combination of other work. Before you serve breakfast, you want to await on the task that represents toasting the bread before you spread the butter and jam.

You can represent this work with the following code:

:::code language="csharp" source="snippets/index/AsyncBreakfast-V3/Program.cs" ID="SnippetComposeToastTask":::

The `MakeToastWithButterAndJamAsync` method has the `async` modifier in its signature that signals to the compiler that the method contains an `await` statement and contains asynchronous operations. The method represents the task that toasts the bread, then spreads the butter and jam. The method returns a <xref:System.Threading.Tasks.Task%601> object that represents the composition of the three operations.

The revised main block of code now looks like this:

:::code language="csharp" source="snippets/index/AsyncBreakfast-V3/Program.cs" ID="SnippetMain":::

This code change illustrates an important technique for working with asynchronous code. You compose tasks by separating the operations into a new method that returns a task. You can choose when to await that task. You can start other tasks concurrently.

## Handle asynchronous exceptions

Up to this point, your code implicitly assumes all tasks complete successfully. Asynchronous methods throw exceptions, just like their synchronous counterparts. The goals for asynchronous support for exceptions and error handling are the same as for asynchronous support in general. The best practice is to write code that reads like a series of synchronous statements. Tasks throw exceptions when they can't complete successfully. The client code can catch those exceptions when a started task is awaited.

In the breakfast example, suppose the toaster catches fire while toasting the bread. You can simulate that problem by modifying the `ToastBreadAsync` method to match the following code:

```csharp
private static async Task<Toast> ToastBreadAsync(int slices)
{
    for (int slice = 0; slice < slices; slice++)
    {
        Console.WriteLine("Putting a slice of bread in the toaster");
    }
    Console.WriteLine("Start toasting...");
    await Task.Delay(2000);
    Console.WriteLine("Fire! Toast is ruined!");
    throw new InvalidOperationException("The toaster is on fire");
    await Task.Delay(1000);
    Console.WriteLine("Remove toast from toaster");

    return new Toast();
}
```

> [!NOTE]
> When you compile this code, you see a warning about unreachable code. This error is by design. After the toaster catches fire, operations don't proceed normally and the code returns an error.

After you make the code changes, run the application and check the output:

```console
Pouring coffee
Coffee is ready
Warming the egg pan...
putting 3 slices of bacon in the pan
Cooking first side of bacon...
Putting a slice of bread in the toaster
Putting a slice of bread in the toaster
Start toasting...
Fire! Toast is ruined!
Flipping a slice of bacon
Flipping a slice of bacon
Flipping a slice of bacon
Cooking the second side of bacon...
Cracking 2 eggs
Cooking the eggs ...
Put bacon on plate
Put eggs on plate
Eggs are ready
Bacon is ready
Unhandled exception. System.InvalidOperationException: The toaster is on fire
   at AsyncBreakfast.Program.ToastBreadAsync(Int32 slices) in Program.cs:line 65
   at AsyncBreakfast.Program.MakeToastWithButterAndJamAsync(Int32 number) in Program.cs:line 36
   at AsyncBreakfast.Program.Main(String[] args) in Program.cs:line 24
   at AsyncBreakfast.Program.<Main>(String[] args)
```

Notice that quite a few tasks finish between the time when the toaster catches fire and the system observes the exception. When a task that runs asynchronously throws an exception, that task is **faulted**. The `Task` object holds the exception thrown in the <xref:System.Threading.Tasks.Task.Exception?displayProperty=nameWithType> property. Faulted tasks throw an exception when they're awaited.

There are two important mechanisms to understand about this process:

- How an exception is stored in a faulted task
- How an exception is unpackaged and rethrown when code awaits a faulted task

When code running asynchronously throws an exception, the exception is stored in the `Task` object. The <xref:System.Threading.Tasks.Task.Exception?displayProperty=nameWithType> property is a <xref:System.AggregateException?displayProperty=nameWithType> object because more than one exception might be thrown during asynchronous work. Any exception thrown is added to the <xref:System.AggregateException.InnerExceptions?displayProperty=nameWithType> collection. If the `Exception` property is null, a new `AggregateException` object is created and the thrown exception is the first item in the collection.

The most common scenario for a faulted task is that the `Exception` property contains exactly one exception. When your code awaits a faulted task, it rethrows the first <xref:System.AggregateException.InnerExceptions?displayProperty=nameWithType> exception in the collection. This result is the reason why the output from the example shows an <xref:System.InvalidOperationException?displayProperty=nameWithType> object rather than an `AggregateException` object. Extracting the first inner exception makes working with asynchronous methods as similar as possible to working with their synchronous counterparts. You can examine the `Exception` property in your code when your scenario might generate multiple exceptions.

> [!TIP]
> The recommended practice is for any argument validation exceptions to emerge *synchronously* from task-returning methods. For more information and examples, see [Exceptions in task-returning methods](../fundamentals/exceptions/creating-and-throwing-exceptions.md#exceptions-in-task-returning-methods).

Before you continue to the next section, comment out the following two statements in your `ToastBreadAsync` method. You don't want to start another fire:

```csharp
Console.WriteLine("Fire! Toast is ruined!");
throw new InvalidOperationException("The toaster is on fire");
```

## Await tasks efficiently

You can improve the series of `await` statements at the end of the previous code by using methods of the `Task` class. One API is the <xref:System.Threading.Tasks.Task.WhenAll%2A> method, which returns a <xref:System.Threading.Tasks.Task> object that completes when all the tasks in its argument list are complete. The following code demonstrates this method:

```csharp
await Task.WhenAll(eggsTask, baconTask, toastTask);
Console.WriteLine("Eggs are ready");
Console.WriteLine("Bacon is ready");
Console.WriteLine("Toast is ready");
Console.WriteLine("Breakfast is ready!");
```

Another option is to use the <xref:System.Threading.Tasks.Task.WhenAny%2A> method, which returns a `Task<Task>` object that completes when any of its arguments complete. You can await the returned task because you know the task is done. The following code shows how you can use the <xref:System.Threading.Tasks.Task.WhenAny%2A> method to await the first task to finish and then process its result. After you process the result from the completed task, you remove the completed task from the list of tasks passed to the `WhenAny` method.

```csharp
var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
while (breakfastTasks.Count > 0)
{
    Task finishedTask = await Task.WhenAny(breakfastTasks);
    if (finishedTask == eggsTask)
    {
        Console.WriteLine("Eggs are ready");
    }
    else if (finishedTask == baconTask)
    {
        Console.WriteLine("Bacon is ready");
    }
    else if (finishedTask == toastTask)
    {
        Console.WriteLine("Toast is ready");
    }
    await finishedTask;
    breakfastTasks.Remove(finishedTask);
}
```

Near the end of the code snippet, notice the `await finishedTask;` statement. The `await Task.WhenAny` statement doesn't await the finished task, but instead awaits the `Task` object returned by the `Task.WhenAny` method. The result of the `Task.WhenAny` method is the completed (or faulted) task. The best practice is to await the task again, even when you know the task is complete. In this manner, you can retrieve the task result, or ensure any exception that causes the task to fault is thrown.

### Review final code

Here's what the final version of the code looks like:

:::code language="csharp" source="snippets/index/AsyncBreakfast-final/Program.cs" highlight="16-47":::

The code completes the asynchronous breakfast tasks in about 15 minutes. The total time is reduced because some tasks run concurrently. The code simultaneously monitors multiple tasks and takes action only as needed.

:::image type="content" source="media/whenany-async-breakfast.png" alt-text="Diagram that shows instructions for preparing breakfast as six asynchronous tasks that complete in about 15 minutes, and the code monitors for possible interruptions.":::

The final code is asynchronous. It more accurately reflects how a person might cook breakfast. Compare the final code with the first code sample in the article. The core actions are still clear by reading the code. You can read the final code the same way you read the list of instructions for making a breakfast, as shown at the beginning of the article. The language features for the `async` and `await` keywords provide the translation every person makes to follow the written instructions: Start tasks as you can and don't block while waiting for tasks to complete.

## Next step

> [!div class="nextstepaction"]
> [Explore real world scenarios for asynchronous programs](async-scenarios.md)
