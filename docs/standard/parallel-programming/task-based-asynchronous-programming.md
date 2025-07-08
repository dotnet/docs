---
title: "Task-based asynchronous programming - .NET"
description: In this article, learn about task-based asynchronous programming through the Task Parallel Library (TPL) in .NET.
ms.date: 06/03/2024
ms.custom: devdivchpfy22
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "parallelism, task"
ms.assetid: 458b5e69-5210-45e5-bc44-3888f86abd6f
---
# Task-based asynchronous programming

The Task Parallel Library (TPL) is based on the concept of a *task*, which represents an asynchronous operation. In some ways, a task resembles a thread or <xref:System.Threading.ThreadPool> work item but at a higher level of abstraction. The term *task parallelism* refers to one or more independent tasks running concurrently. Tasks provide two primary benefits:

- More efficient and more scalable use of system resources.

     Behind the scenes, tasks are queued to the <xref:System.Threading.ThreadPool>, which has been enhanced with algorithms that determine and adjust to the number of threads. These algorithms provide load balancing to maximize throughput. This process makes tasks relatively lightweight, and you can create many of them to enable fine-grained parallelism.

- More programmatic control than is possible with a thread or work item.

     Tasks and the framework built around them provide a rich set of APIs that support waiting, cancellation, continuations, robust exception handling, detailed status, custom scheduling, and more.

For both reasons, TPL is the preferred API for writing multi-threaded, asynchronous, and parallel code in .NET.

## Creating and running tasks implicitly

The <xref:System.Threading.Tasks.Parallel.Invoke%2A?displayProperty=nameWithType> method provides a convenient way to run any number of arbitrary statements concurrently. Just pass in an <xref:System.Action> delegate for each item of work. The easiest way to create these delegates is to use lambda expressions. The lambda expression can either call a named method or provide the code inline. The following example shows a basic <xref:System.Threading.Tasks.Parallel.Invoke%2A> call that creates and starts two tasks that run concurrently. The first task is represented by a lambda expression that calls a method named `DoSomeWork`, and the second task is represented by a lambda expression that calls a method named `DoSomeOtherWork`.

> [!NOTE]
> This documentation uses lambda expressions to define delegates in TPL. If you aren't familiar with lambda expressions in C# or Visual Basic, see [Lambda Expressions in PLINQ and TPL](lambda-expressions-in-plinq-and-tpl.md).

[!code-csharp[TPL#21](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl/cs/tpl.cs#21)]
[!code-vb[TPL#21](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl/vb/tpl_vb.vb#21)]

> [!NOTE]
> The number of <xref:System.Threading.Tasks.Task> instances that are created behind the scenes by <xref:System.Threading.Tasks.Parallel.Invoke%2A> isn't necessarily equal to the number of delegates that are provided. The TPL might employ various optimizations, especially with large numbers of delegates.

For more information, see [How to: Use Parallel.Invoke to Execute Parallel Operations](how-to-use-parallel-invoke-to-execute-parallel-operations.md).

For greater control over task execution or to return a value from the task, you must work with <xref:System.Threading.Tasks.Task> objects more explicitly.

## Creating and running tasks explicitly

A task that doesn't return a value is represented by the <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> class. A task that returns a value is represented by the <xref:System.Threading.Tasks.Task%601?displayProperty=nameWithType> class, which inherits from <xref:System.Threading.Tasks.Task>. The task object handles the infrastructure details and provides methods and properties that are accessible from the calling thread throughout the lifetime of the task. For example, you can access the <xref:System.Threading.Tasks.Task.Status%2A> property of a task at any time to determine whether it has started running, ran to completion, was canceled, or has thrown an exception. The status is represented by a <xref:System.Threading.Tasks.TaskStatus> enumeration.

When you create a task, you give it a user delegate that encapsulates the code that the task will execute. The delegate can be expressed as a named delegate, an anonymous method, or a lambda expression. Lambda expressions can contain a call to a named method, as shown in the following example. The example includes a call to the <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> method to ensure that the task completes execution before the console mode application ends.

[!code-csharp[TPL_TaskIntro#1](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_taskintro/cs/lambda1.cs#1)]
[!code-vb[TPL_TaskIntro#1](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_taskintro/vb/lambda1.vb#1)]

You can also use the <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType> methods to create and start a task in one operation. To manage the task, the <xref:System.Threading.Tasks.Task.Run%2A> methods use the default task scheduler, regardless of which task scheduler is associated with the current thread. The <xref:System.Threading.Tasks.Task.Run%2A> methods are the preferred way to create and start tasks when more control over the creation and scheduling of the task isn't needed.

[!code-csharp[TPL_TaskIntro#2](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_taskintro/cs/run1.cs#2)]
[!code-vb[TPL_TaskIntro#2](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_taskintro/vb/run1.vb#2)]

You can also use the <xref:System.Threading.Tasks.TaskFactory.StartNew%2A?displayProperty=nameWithType> method to create and start a task in one operation. As shown in the following example, you can use this method when:

- Creation and scheduling don't have to be separated and you require additional task creation options or the use of a specific scheduler.

- You need to pass additional state into the task that you can retrieve through its <xref:System.Threading.Tasks.Task.AsyncState%2A?displayProperty=nameWithType> property.

[!code-csharp[TPL_TaskIntro#3](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_taskintro/cs/asyncstate.cs#23)]
[!code-vb[TPL_TaskIntro#3](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_taskintro/vb/asyncstate.vb#23)]

<xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> each expose a static <xref:System.Threading.Tasks.Task.Factory%2A> property that returns a default instance of <xref:System.Threading.Tasks.TaskFactory>, so that you can call the method as `Task.Factory.StartNew()`. Also, in the following example, because the tasks are of type <xref:System.Threading.Tasks.Task%601?displayProperty=nameWithType>, they each have a public <xref:System.Threading.Tasks.Task%601.Result%2A?displayProperty=nameWithType> property that contains the result of the computation. The tasks run asynchronously and might complete in any order. If the <xref:System.Threading.Tasks.Task%601.Result%2A> property is accessed before the computation finishes, the property blocks the calling thread until the value is available.

[!code-csharp[TPL_TaskIntro#4](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_taskintro/cs/result1.cs#4)]
[!code-vb[TPL_TaskIntro#4](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_taskintro/vb/result1.vb#4)]

For more information, see [How to: Return a Value from a Task](how-to-return-a-value-from-a-task.md).

When you use a lambda expression to create a delegate, you have access to all the variables that are visible at that point in your source code. However, in some cases, most notably within loops, a lambda doesn't capture the variable as expected. It only captures the reference of the variable, not the value, as it mutates after each iteration. The following example illustrates the problem. It passes a loop counter to a lambda expression that instantiates a `CustomData` object and uses the loop counter as the object's identifier. As the output from the example shows, each `CustomData` object has an identical identifier.

[!code-csharp[TPL_TaskIntro#22](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_taskintro/cs/iteration1b.cs#22)]
[!code-vb[TPL_TaskIntro#22](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_taskintro/vb/iteration1b.vb#22)]

You can access the value on each iteration by providing a state object to a task through its constructor. The following example modifies the previous example by using the loop counter when creating the `CustomData` object, which, in turn, is passed to the lambda expression. As the output from the example shows, each `CustomData` object now has a unique identifier based on the value of the loop counter at the time the object was instantiated.

[!code-csharp[TPL_TaskIntro#21](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_taskintro/cs/iteration1a.cs#21)]
[!code-vb[TPL_TaskIntro#21](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_taskintro/vb/iteration1a.vb#21)]

This state is passed as an argument to the task delegate, and it can be accessed from the task object by using the <xref:System.Threading.Tasks.Task.AsyncState%2A?displayProperty=nameWithType> property. The following example is a variation on the previous example. It uses the <xref:System.Threading.Tasks.Task.AsyncState%2A> property to display information about the `CustomData` objects passed to the lambda expression.

[!code-csharp[TPL_TaskIntro#23](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_taskintro/cs/asyncstate.cs#23)]
[!code-vb[TPL_TaskIntro#23](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_taskintro/vb/asyncstate.vb#23)]

## Task ID

Every task receives an integer ID that uniquely identifies it in an application domain and can be accessed by using the <xref:System.Threading.Tasks.Task.Id%2A?displayProperty=nameWithType> property. The ID is useful for viewing task information in the Visual Studio debugger **Parallel Stacks** and **Tasks** windows. The ID is created lazily, which means it isn't created until it's requested. Therefore, a task might have a different ID every time the program is run. For more information about how to view task IDs in the debugger, see [Using the Tasks Window](/visualstudio/debugger/using-the-tasks-window) and [Using the Parallel Stacks Window](/visualstudio/debugger/using-the-parallel-stacks-window).

## Task creation options

Most APIs that create tasks provide overloads that accept a <xref:System.Threading.Tasks.TaskCreationOptions> parameter. By specifying one or more of these options, you tell the task scheduler how to schedule the task on the thread pool. Options might be combined by using a bitwise **OR** operation.

The following example shows a task that has the <xref:System.Threading.Tasks.TaskCreationOptions.LongRunning> and <xref:System.Threading.Tasks.TaskCreationOptions.PreferFairness> options:

[!code-csharp[TPL_TaskIntro#03](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_taskintro/cs/taskintro.cs#03)]
[!code-vb[TPL_TaskIntro#03](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_taskintro/vb/tpl_intro.vb#03)]

## Tasks, threads, and culture

Each thread has an associated culture and UI culture, which are defined by the <xref:System.Threading.Thread.CurrentCulture%2A?displayProperty=nameWithType> and <xref:System.Threading.Thread.CurrentUICulture%2A?displayProperty=nameWithType> properties, respectively. A thread's culture is used in operations such as formatting, parsing, sorting, and string comparison operations. A thread's UI culture is used in resource lookup.

The system culture defines the default culture and UI culture of a thread. However, you can specify a default culture for all the threads in an application domain by using the <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture%2A?displayProperty=nameWithType> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture%2A?displayProperty=nameWithType> properties. If you explicitly set a thread's culture and launch a new thread, the new thread doesn't inherit the culture of the calling thread; instead, its culture is the default system culture. However, in task-based programming, tasks use the calling thread's culture, even if the task runs asynchronously on a different thread.

The following example provides a simple illustration. It changes the app's current culture to French (France). If French (France) is already the current culture, it changes to English (United States). It then invokes a delegate named `formatDelegate` that returns some numbers formatted as currency values in the new culture. Whether the delegate is invoked by a task either synchronously or asynchronously, the task uses the culture of the calling thread.

:::code language="csharp" source="snippets/cs/asyncculture1.cs" id="1":::

:::code language="vbnet" source="snippets/vb/asyncculture1.vb" id="1":::

> [!NOTE]
> In versions of .NET Framework earlier than .NET Framework 4.6, a task's culture is determined by the culture of the thread on which it runs, not the culture of the calling thread. For asynchronous tasks, the culture used by the task could be different from the calling thread's culture.

For more information on asynchronous tasks and culture, see the "Culture and asynchronous task-based operations" section in the <xref:System.Globalization.CultureInfo> article.

## Creating task continuations

The <xref:System.Threading.Tasks.Task.ContinueWith%2A?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Task%601.ContinueWith%2A?displayProperty=nameWithType> methods let you specify a task to start when the *antecedent task* finishes. The delegate of the continuation task is passed a reference to the antecedent task so that it can examine the antecedent task's status. And by retrieving the value of the <xref:System.Threading.Tasks.Task%601.Result%2A?displayProperty=nameWithType> property, you can use the output of the antecedent as input for the continuation.

In the following example, the `getData` task is started by a call to the <xref:System.Threading.Tasks.TaskFactory.StartNew%60%601%28System.Func%7B%60%600%7D%29?displayProperty=nameWithType> method. The `processData` task is started automatically when `getData` finishes, and `displayData` is started when `processData` finishes. `getData` produces an integer array, which is accessible to the `processData` task through the `getData` task's <xref:System.Threading.Tasks.Task%601.Result%2A?displayProperty=nameWithType> property. The `processData` task processes that array and returns a result whose type is inferred from the return type of the lambda expression passed to the <xref:System.Threading.Tasks.Task%601.ContinueWith%60%601%28System.Func%7BSystem.Threading.Tasks.Task%7B%600%7D%2C%60%600%7D%29?displayProperty=nameWithType> method. The `displayData` task executes automatically when `processData` finishes, and the <xref:System.Tuple%603> object returned by the `processData` lambda expression is accessible to the `displayData` task through the `processData` task's <xref:System.Threading.Tasks.Task%601.Result%2A?displayProperty=nameWithType> property. The `displayData` task takes the result of the `processData` task. It produces a result whose type is inferred in a similar manner, and which is made available to the program in the <xref:System.Threading.Tasks.Task%601.Result%2A> property.

[!code-csharp[TPL_TaskIntro#5](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_taskintro/cs/continuations1.cs#5)]
[!code-vb[TPL_TaskIntro#5](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_taskintro/vb/continuations1.vb#5)]

Because <xref:System.Threading.Tasks.Task.ContinueWith%2A?displayProperty=nameWithType> is an instance method, you can chain method calls together instead of instantiating a <xref:System.Threading.Tasks.Task%601> object for each antecedent task. The following example is functionally identical to the previous one, except that it chains together calls to the <xref:System.Threading.Tasks.Task.ContinueWith%2A?displayProperty=nameWithType> method. The <xref:System.Threading.Tasks.Task%601> object returned by the chain of method calls is the final continuation task.

[!code-csharp[TPL_TaskIntro#24](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_taskintro/cs/continuations2.cs#24)]
[!code-vb[TPL_TaskIntro#24](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_taskintro/vb/continuations2.vb#24)]

The <xref:System.Threading.Tasks.TaskFactory.ContinueWhenAll%2A> and <xref:System.Threading.Tasks.TaskFactory.ContinueWhenAny%2A> methods enable you to continue from multiple tasks.

For more information, see [Chaining Tasks by Using Continuation Tasks](chaining-tasks-by-using-continuation-tasks.md).

## Creating detached child tasks

When user code that's running in a task creates a new task and doesn't specify the <xref:System.Threading.Tasks.TaskCreationOptions.AttachedToParent> option, the new task isn't synchronized with the parent task in any special way. This type of non-synchronized task is called a *detached nested task* or *detached child task*. The following example shows a task that creates one detached child task:

[!code-csharp[TPL_TaskIntro#07](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_taskintro/cs/taskintro.cs#07)]
[!code-vb[TPL_TaskIntro#07](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_taskintro/vb/tpl_intro.vb#07)]

> [!NOTE]
> The parent task doesn't wait for the detached child task to finish.

## Creating child tasks

When user code that's running in a task creates a task with the <xref:System.Threading.Tasks.TaskCreationOptions.AttachedToParent> option, the new task is known as an *attached child task* of the parent task. You can use the <xref:System.Threading.Tasks.TaskCreationOptions.AttachedToParent> option to express structured task parallelism because the parent task implicitly waits for all attached child tasks to finish. The following example shows a parent task that creates 10 attached child tasks. The example calls the <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> method to wait for the parent task to finish. It doesn't have to explicitly wait for the attached child tasks to complete.

[!code-csharp[TPL_TaskIntro#8](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_taskintro/cs/child1.cs#8)]
[!code-vb[TPL_TaskIntro#8](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_taskintro/vb/child1.vb#8)]

A parent task can use the <xref:System.Threading.Tasks.TaskCreationOptions.DenyChildAttach?displayProperty=nameWithType> option to prevent other tasks from attaching to the parent task. For more information, see [Attached and Detached Child Tasks](attached-and-detached-child-tasks.md).

## Waiting for tasks to finish

The <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Task%601?displayProperty=nameWithType> types provide several overloads of the <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> methods that enable you to wait for a task to finish. In addition, overloads of the static <xref:System.Threading.Tasks.Task.WaitAll%2A?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Task.WaitAny%2A?displayProperty=nameWithType> methods let you wait for any or all of an array of tasks to finish.

Typically, you would wait for a task for one of these reasons:

- The main thread depends on the final result computed by a task.

- You have to handle exceptions that might be thrown from the task.

- The application might terminate before all tasks have completed execution. For example, console applications will terminate after all synchronous code in `Main` (the application entry point) has executed.

The following example shows the basic pattern that doesn't involve exception handling:

[!code-csharp[TPL_TaskIntro#06](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_taskintro/cs/taskintro.cs#06)]
[!code-vb[TPL_TaskIntro#06](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_taskintro/vb/tpl_intro.vb#06)]

For an example that shows exception handling, see [Exception Handling](exception-handling-task-parallel-library.md).

Some overloads let you specify a time-out, and others take an additional <xref:System.Threading.CancellationToken> as an input parameter so that the wait itself can be canceled either programmatically or in response to user input.

When you wait for a task, you implicitly wait for all children of that task that were created by using the <xref:System.Threading.Tasks.TaskCreationOptions.AttachedToParent?displayProperty=nameWithType> option. <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> returns immediately if the task has already completed. A <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> method will throw any exceptions raised by a task, even if the <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> method was called after the task completed.

## Composing tasks

The <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> classes provide several methods to help you compose multiple tasks. These methods implement common patterns and make better use of the asynchronous language features that are provided by C#, Visual Basic, and F#. This section describes the <xref:System.Threading.Tasks.Task.WhenAll%2A>, <xref:System.Threading.Tasks.Task.WhenAny%2A>, <xref:System.Threading.Tasks.Task.Delay%2A>, and <xref:System.Threading.Tasks.Task.FromResult%2A> methods.

### Task.WhenAll

The <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType> method asynchronously waits for multiple <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> objects to finish. It provides overloaded versions that enable you to wait for non-uniform sets of tasks. For example, you can wait for multiple <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> objects to complete from one method call.

### Task.WhenAny

The <xref:System.Threading.Tasks.Task.WhenAny%2A?displayProperty=nameWithType> method asynchronously waits for one of multiple <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> objects to finish. As in the <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType> method, this method provides overloaded versions that enable you to wait for non-uniform sets of tasks. The <xref:System.Threading.Tasks.Task.WhenAny%2A> method is especially useful in the following scenarios:

- **Redundant operations**: Consider an algorithm or operation that can be performed in many ways. You can use the <xref:System.Threading.Tasks.Task.WhenAny%2A> method to select the operation that finishes first and then cancel the remaining operations.

- **Interleaved operations**: You can start multiple operations that must finish and use the <xref:System.Threading.Tasks.Task.WhenAny%2A> method to process results as each operation finishes. After one operation finishes, you can start one or more tasks.

- **Throttled operations**: You can use the <xref:System.Threading.Tasks.Task.WhenAny%2A> method to extend the previous scenario by limiting the number of concurrent operations.

- **Expired operations**: You can use the <xref:System.Threading.Tasks.Task.WhenAny%2A> method to select between one or more tasks and a task that finishes after a specific time, such as a task that's returned by the <xref:System.Threading.Tasks.Task.Delay%2A> method. The <xref:System.Threading.Tasks.Task.Delay%2A> method is described in the following section.

### Task.Delay

The <xref:System.Threading.Tasks.Task.Delay%2A?displayProperty=nameWithType> method produces a <xref:System.Threading.Tasks.Task> object that finishes after the specified time. You can use this method to build loops that poll for data, to specify time-outs, to delay the handling of user input, and so on.

### Task(T).FromResult

By using the <xref:System.Threading.Tasks.Task.FromResult%2A?displayProperty=nameWithType> method, you can create a <xref:System.Threading.Tasks.Task%601> object that holds a pre-computed result. This method is useful when you perform an asynchronous operation that returns a <xref:System.Threading.Tasks.Task%601> object, and the result of that <xref:System.Threading.Tasks.Task%601> object is already computed. For an example that uses <xref:System.Threading.Tasks.Task.FromResult%2A> to retrieve the results of asynchronous download operations that are held in a cache, see [How to: Create Pre-Computed Tasks](how-to-create-pre-computed-tasks.md).

## Handling exceptions in tasks

When a task throws one or more exceptions, the exceptions are wrapped in an <xref:System.AggregateException> exception. That exception is propagated back to the thread that joins with the task. Typically, it's the thread waiting for the task to finish or the thread accessing the <xref:System.Threading.Tasks.Task%601.Result%2A> property. This behavior enforces the .NET Framework policy that all unhandled exceptions by default should terminate the process. The calling code can handle the exceptions by using any of the following in a `try`/`catch` block:

- The <xref:System.Threading.Tasks.Task.Wait%2A> method

- The <xref:System.Threading.Tasks.Task.WaitAll%2A> method

- The <xref:System.Threading.Tasks.Task.WaitAny%2A> method

- The <xref:System.Threading.Tasks.Task%601.Result%2A> property

The joining thread can also handle exceptions by accessing the <xref:System.Threading.Tasks.Task.Exception%2A> property before the task is garbage-collected. By accessing this property, you prevent the unhandled exception from triggering the exception propagation behavior that terminates the process when the object is finalized.

For more information about exceptions and tasks, see [Exception Handling](exception-handling-task-parallel-library.md).

## Canceling tasks

The <xref:System.Threading.Tasks.Task> class supports cooperative cancellation and is fully integrated with the <xref:System.Threading.CancellationTokenSource?displayProperty=nameWithType> and <xref:System.Threading.CancellationToken?displayProperty=nameWithType> classes, which were introduced in the .NET Framework 4. Many of the constructors in the <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> class take a <xref:System.Threading.CancellationToken> object as an input parameter. Many of the <xref:System.Threading.Tasks.TaskFactory.StartNew%2A> and <xref:System.Threading.Tasks.Task.Run%2A> overloads also include a <xref:System.Threading.CancellationToken> parameter.

You can create the token and issue the cancellation request at some later time, by using the <xref:System.Threading.CancellationTokenSource> class. Pass the token to the <xref:System.Threading.Tasks.Task> as an argument, and also reference the same token in your user delegate, which does the work of responding to a cancellation request.

For more information, see [Task Cancellation](task-cancellation.md) and [How to: Cancel a Task and Its Children](how-to-cancel-a-task-and-its-children.md).

## The TaskFactory class

The <xref:System.Threading.Tasks.TaskFactory> class provides static methods that encapsulate common patterns for creating and starting tasks and continuation tasks.

- The most common pattern is <xref:System.Threading.Tasks.TaskFactory.StartNew%2A>, which creates and starts a task in one statement.

- When you create continuation tasks from multiple antecedents, use the <xref:System.Threading.Tasks.TaskFactory.ContinueWhenAll%2A> method or <xref:System.Threading.Tasks.TaskFactory.ContinueWhenAny%2A> method or their equivalents in the <xref:System.Threading.Tasks.Task%601> class. For more information, see [Chaining Tasks by Using Continuation Tasks](chaining-tasks-by-using-continuation-tasks.md).

- To encapsulate Asynchronous Programming Model `BeginX` and `EndX` methods in a <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> instance, use the <xref:System.Threading.Tasks.TaskFactory.FromAsync%2A> methods. For more information, see [TPL and Traditional .NET Framework Asynchronous Programming](tpl-and-traditional-async-programming.md).

The default <xref:System.Threading.Tasks.TaskFactory> can be accessed as a static property on the <xref:System.Threading.Tasks.Task> class or <xref:System.Threading.Tasks.Task%601> class. You can also instantiate a <xref:System.Threading.Tasks.TaskFactory> directly and specify various options that include a <xref:System.Threading.CancellationToken>, a <xref:System.Threading.Tasks.TaskCreationOptions> option, a <xref:System.Threading.Tasks.TaskContinuationOptions> option, or a <xref:System.Threading.Tasks.TaskScheduler>. Whatever options are specified when you create the task factory will be applied to all tasks that it creates unless the <xref:System.Threading.Tasks.Task> is created by using the <xref:System.Threading.Tasks.TaskCreationOptions> enumeration, in which case the task's options override those of the task factory.

## Tasks without delegates

In some cases, you might want to use a <xref:System.Threading.Tasks.Task> to encapsulate some asynchronous operation that's performed by an external component instead of your user delegate. If the operation is based on the Asynchronous Programming Model Begin/End pattern, you can use the <xref:System.Threading.Tasks.TaskFactory.FromAsync%2A> methods. If that's not the case, you can use the <xref:System.Threading.Tasks.TaskCompletionSource%601> object to wrap the operation in a task and thereby gain some of the benefits of <xref:System.Threading.Tasks.Task> programmability. For example, support for exception propagation and continuations. For more information, see <xref:System.Threading.Tasks.TaskCompletionSource%601>.

## Custom schedulers

Most application or library developers don't care which processor the task runs on, how it synchronizes its work with other tasks, or how it's scheduled on the <xref:System.Threading.ThreadPool?displayProperty=nameWithType>. They only require that it execute as efficiently as possible on the host computer. If you require more fine-grained control over the scheduling details, the TPL lets you configure some settings on the default task scheduler, and even lets you supply a custom scheduler. For more information, see <xref:System.Threading.Tasks.TaskScheduler>.

## Related data structures

The TPL has several new public types that are useful in parallel and sequential scenarios. These include several thread-safe, fast, and scalable collection classes in the <xref:System.Collections.Concurrent?displayProperty=nameWithType> namespace and several new synchronization types. For example, <xref:System.Threading.Semaphore?displayProperty=nameWithType> and <xref:System.Threading.ManualResetEventSlim?displayProperty=nameWithType>, which are more efficient than their predecessors for specific kinds of workloads. Other new types in the .NET Framework 4, for example, <xref:System.Threading.Barrier?displayProperty=nameWithType> and <xref:System.Threading.SpinLock?displayProperty=nameWithType>, provide functionality that wasn't available in earlier releases. For more information, see [Data Structures for Parallel Programming](data-structures-for-parallel-programming.md).

## Custom task types

We recommend that you don't inherit from <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> or <xref:System.Threading.Tasks.Task%601?displayProperty=nameWithType>. Instead, we recommend that you use the <xref:System.Threading.Tasks.Task.AsyncState%2A> property to associate additional data or state with a <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> object. You can also use extension methods to extend the functionality of the <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> classes. For more information about extension methods, see [Extension Methods](../../csharp/programming-guide/classes-and-structs/extension-methods.md) and [Extension Methods](../../visual-basic/programming-guide/language-features/procedures/extension-methods.md).

If you must inherit from <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601>, you can't use <xref:System.Threading.Tasks.Task.Run%2A> or the <xref:System.Threading.Tasks.TaskFactory?displayProperty=nameWithType>, <xref:System.Threading.Tasks.TaskFactory%601?displayProperty=nameWithType>, or <xref:System.Threading.Tasks.TaskCompletionSource%601?displayProperty=nameWithType> classes to create instances of your custom task type. You can't use them because these classes create only <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> objects. In addition, you can't use the task continuation mechanisms that are provided by <xref:System.Threading.Tasks.Task>, <xref:System.Threading.Tasks.Task%601>, <xref:System.Threading.Tasks.TaskFactory>, and <xref:System.Threading.Tasks.TaskFactory%601> to create instances of your custom task type. You can't use them because these classes also create only <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> objects.

## Related sections

|Title|Description|
|-|-|
|[Chaining Tasks by Using Continuation Tasks](chaining-tasks-by-using-continuation-tasks.md)|Describes how continuations work.|
|[Attached and Detached Child Tasks](attached-and-detached-child-tasks.md)|Describes the difference between attached and detached child tasks.|
|[Task Cancellation](task-cancellation.md)|Describes the cancellation support that's built into the <xref:System.Threading.Tasks.Task> object.|
|[Exception Handling](exception-handling-task-parallel-library.md)|Describes how exceptions on concurrent threads are handled.|
|[How to: Use Parallel.Invoke to Execute Parallel Operations](how-to-use-parallel-invoke-to-execute-parallel-operations.md)|Describes how to use <xref:System.Threading.Tasks.Parallel.Invoke%2A>.|
|[How to: Return a Value from a Task](how-to-return-a-value-from-a-task.md)|Describes how to return values from tasks.|
|[How to: Cancel a Task and Its Children](how-to-cancel-a-task-and-its-children.md)|Describes how to cancel tasks.|
|[How to: Create Pre-Computed Tasks](how-to-create-pre-computed-tasks.md)|Describes how to use the <xref:System.Threading.Tasks.Task.FromResult%2A?displayProperty=nameWithType> method to retrieve the results of asynchronous download operations that are held in a cache.|
|[How to: Traverse a Binary Tree with Parallel Tasks](how-to-traverse-a-binary-tree-with-parallel-tasks.md)|Describes how to use tasks to traverse a binary tree.|
|[How to: Unwrap a Nested Task](how-to-unwrap-a-nested-task.md)|Demonstrates how to use the <xref:System.Threading.Tasks.TaskExtensions.Unwrap%2A> extension method.|
|[Data Parallelism](data-parallelism-task-parallel-library.md)|Describes how to use <xref:System.Threading.Tasks.Parallel.For%2A> and <xref:System.Threading.Tasks.Parallel.ForEach%2A> to create parallel loops over data.|
|[Parallel Programming](index.md)|Top-level node for .NET Framework parallel programming.|

## See also

- [Parallel Programming](index.md)
- [Samples for Parallel Programming with the .NET Core & .NET Standard](/samples/browse/?products=dotnet-core%2Cdotnet-standard&term=parallel)
