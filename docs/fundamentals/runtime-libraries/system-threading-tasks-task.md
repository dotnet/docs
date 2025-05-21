---
title: System.Threading.Tasks.Task class
description: Learn about the System.Threading.Tasks.Task class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Threading.Tasks.Task class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Threading.Tasks.Task> class represents a single operation that does not return a value and that usually executes asynchronously. <xref:System.Threading.Tasks.Task> objects are one of the central components of the  [task-based asynchronous pattern](../../standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md) first introduced in .NET Framework 4. Because the work performed by a <xref:System.Threading.Tasks.Task> object typically executes asynchronously on a thread pool thread rather than synchronously on the main application thread, you can use the <xref:System.Threading.Tasks.Task.Status> property, as well as the <xref:System.Threading.Tasks.Task.IsCanceled%2A>, <xref:System.Threading.Tasks.Task.IsCompleted%2A>, and <xref:System.Threading.Tasks.Task.IsFaulted%2A> properties, to determine the   state of a task. Most commonly, a lambda expression is used to specify the work that the task is to perform.

For operations that return values, you use the <xref:System.Threading.Tasks.Task%601> class.

## Task instantiation

The following example creates and executes four tasks. Three tasks execute an <xref:System.Action%601> delegate named `action`, which accepts an argument of type <xref:System.Object>. A fourth task executes a lambda expression (an <xref:System.Action> delegate) that is defined inline in the call to the task creation method. Each task is instantiated and run in a different way:

- Task `t1` is instantiated by calling a Task class constructor, but is started by calling its <xref:System.Threading.Tasks.Task.Start> method only after task `t2` has started.

- Task `t2` is instantiated and started in a single method call by calling the <xref:System.Threading.Tasks.TaskFactory.StartNew%28System.Action%7BSystem.Object%7D%2CSystem.Object%29?displayProperty=nameWithType> method.

- Task `t3` is instantiated and started in a single method call by calling the <xref:System.Threading.Tasks.Task.Run%28System.Action%29> method.

- Task `t4` is executed synchronously on the main thread by calling the <xref:System.Threading.Tasks.Task.RunSynchronously> method.

Because task `t4` executes synchronously, it executes on the main application thread. The remaining tasks execute asynchronously typically on one or more thread pool threads.

:::code language="csharp" source="./snippets/System.Threading.Tasks/Task/Overview/csharp/startnew.cs" id="Snippet01":::
:::code language="fsharp" source="./snippets/System.Threading.Tasks/Task/Overview/fsharp/startnew.fs" id="Snippet01":::
:::code language="vb" source="./snippets/System.Threading.Tasks/Task/Overview/vb/startnew.vb" id="Snippet01":::

## Create and execute a task

You can create <xref:System.Threading.Tasks.Task> instances in a variety of ways. The most common approach is to call the static <xref:System.Threading.Tasks.Task.Run%2A> method. The <xref:System.Threading.Tasks.Task.Run%2A> method provides a simple way to start a task using default values and without requiring additional parameters. The following example uses the <xref:System.Threading.Tasks.Task.Run%28System.Action%29> method to start a task that loops and then displays the number of loop iterations:

:::code language="csharp" source="./snippets/System.Threading.Tasks/Task/Overview/csharp/run1.cs" id="Snippet6":::
:::code language="fsharp" source="./snippets/System.Threading.Tasks/Task/Overview/fsharp/run1.fs" id="Snippet6":::
:::code language="vb" source="./snippets/System.Threading.Tasks/Task/Overview/vb/run1.vb" id="Snippet6":::

An alternative is the static <xref:System.Threading.Tasks.TaskFactory.StartNew%2A?displayProperty=nameWithType> method. The <xref:System.Threading.Tasks.Task.Factory?displayProperty=nameWithType> property returns a <xref:System.Threading.Tasks.TaskFactory> object. Overloads of the <xref:System.Threading.Tasks.TaskFactory.StartNew%2A?displayProperty=nameWithType> method let you specify parameters to pass to the task creation options and a task scheduler. The following example uses the <xref:System.Threading.Tasks.TaskFactory.StartNew%2A?displayProperty=nameWithType> method to start a task. It is functionally equivalent to the code in the previous example.

:::code language="csharp" source="./snippets/System.Threading.Tasks/Task/Overview/csharp/startnew1.cs" id="Snippet7":::
:::code language="fsharp" source="./snippets/System.Threading.Tasks/Task/Overview/fsharp/startnew1.fs" id="Snippet7":::
:::code language="vb" source="./snippets/System.Threading.Tasks/Task/Overview/vb/startnew1.vb" id="Snippet7":::

For more complete examples, see [Task-based Asynchronous Programming](../../standard/parallel-programming/task-based-asynchronous-programming.md).

## Separate task creation and execution

The <xref:System.Threading.Tasks.Task> class also provides constructors that initialize the task but that do not schedule it for execution. For performance reasons, the <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType> or <xref:System.Threading.Tasks.TaskFactory.StartNew%2A?displayProperty=nameWithType> method is the preferred mechanism for creating and scheduling computational tasks, but for scenarios where creation and scheduling must be separated, you can use the constructors and then call the <xref:System.Threading.Tasks.Task.Start%2A?displayProperty=nameWithType> method to schedule the task for execution at a later time.

## Wait for a task to complete

Because tasks typically run asynchronously on a thread pool thread, the thread that creates and starts the task continues execution as soon as the task has been instantiated. In some cases, when the calling thread is the main application thread, the app may terminate before the task actually begins execution. In others, your application's logic may require that the calling thread continue execution only when one or more tasks have completed execution. You can synchronize the execution of the calling thread and the asynchronous tasks it launches by calling a `Wait` method to wait for one or more tasks to complete.

To wait for a single task to complete, you can call its <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> method. A call to the  <xref:System.Threading.Tasks.Task.Wait%2A> method blocks the calling thread until the single class instance has completed execution.

The following example calls the parameterless <xref:System.Threading.Tasks.Task.Wait> method to wait unconditionally until a task completes. The task simulates work by calling the <xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType> method to sleep for two seconds.

:::code language="csharp" source="./snippets/System.Threading.Tasks/Task/Overview/csharp/Wait1.cs" id="Snippet8":::
:::code language="fsharp" source="./snippets/System.Threading.Tasks/Task/Overview/fsharp/Wait1.fs" id="Snippet8":::
:::code language="vb" source="./snippets/System.Threading.Tasks/Task/Overview/vb/Wait1.vb" id="Snippet8":::

You can also conditionally wait for a task to complete. The <xref:System.Threading.Tasks.Task.Wait%28System.Int32%29> and <xref:System.Threading.Tasks.Task.Wait%28System.TimeSpan%29> methods block the calling thread until the task finishes or a timeout interval elapses, whichever comes first. Since the following example launches a task that sleeps for two seconds but defines a one-second timeout value, the calling thread blocks until the timeout expires and before the task has completed execution.

:::code language="csharp" source="./snippets/System.Threading.Tasks/Task/Overview/csharp/Wait2.cs" id="Snippet9":::
:::code language="fsharp" source="./snippets/System.Threading.Tasks/Task/Overview/fsharp/Wait2.fs" id="Snippet9":::
:::code language="vb" source="./snippets/System.Threading.Tasks/Task/Overview/vb/Wait2.vb" id="Snippet9":::

You can also supply a cancellation token by calling the <xref:System.Threading.Tasks.Task.Wait%28System.Threading.CancellationToken%29> and <xref:System.Threading.Tasks.Task.Wait%28System.Int32%2CSystem.Threading.CancellationToken%29> methods. If the token's <xref:System.Threading.CancellationToken.IsCancellationRequested> property is `true` or becomes `true` while the <xref:System.Threading.Tasks.Task.Wait%2A> method is executing, the method throws an <xref:System.OperationCanceledException>.

In some cases, you may want to wait for the first of a series of executing tasks to complete, but don't care which task it is. For this purpose, you can call one of the overloads of the <xref:System.Threading.Tasks.Task.WaitAny%2A?displayProperty=nameWithType> method. The following example creates three tasks, each of which sleeps for an interval determined by a random number generator. The <xref:System.Threading.Tasks.Task.WaitAny%28System.Threading.Tasks.Task%5B%5D%29> method waits for the first task to complete. The example then displays information about the status of all three tasks.

:::code language="csharp" source="./snippets/System.Threading.Tasks/Task/Overview/csharp/WhenAny1.cs" id="Snippet10":::
:::code language="fsharp" source="./snippets/System.Threading.Tasks/Task/Overview/fsharp/WhenAny1.fs" id="Snippet10":::
:::code language="vb" source="./snippets/System.Threading.Tasks/Task/Overview/vb/WaitAny1.vb" id="Snippet10":::

You can also wait for all of a series of tasks to complete by calling the <xref:System.Threading.Tasks.Task.WaitAll%2A> method. The following example creates ten tasks, waits for all ten to complete, and then displays their status.

:::code language="csharp" source="./snippets/System.Threading.Tasks/Task/Overview/csharp/WaitAll1.cs" id="Snippet11":::
:::code language="fsharp" source="./snippets/System.Threading.Tasks/Task/Overview/fsharp/WaitAll1.fs" id="Snippet11":::
:::code language="vb" source="./snippets/System.Threading.Tasks/Task/Overview/vb/WaitAll1.vb" id="Snippet11":::

Note that when you wait for one or more tasks to complete, any exceptions thrown in the running tasks are propagated on the thread that calls the `Wait` method, as the following example shows. It launches 12 tasks, three of which complete normally and three of which throw an exception. Of the remaining six tasks, three are cancelled before they start, and three are cancelled while they are executing. Exceptions are thrown in the <xref:System.Threading.Tasks.Task.WaitAll%2A> method call and are handled by a `try`/`catch` block.

:::code language="csharp" source="./snippets/System.Threading.Tasks/Task/Overview/csharp/WaitAll2.cs" id="Snippet12":::
:::code language="fsharp" source="./snippets/System.Threading.Tasks/Task/Overview/fsharp/WaitAll2.fs" id="Snippet12":::
:::code language="vb" source="./snippets/System.Threading.Tasks/Task/Overview/vb/WaitAll2.vb" id="Snippet12":::

For more information on exception handling in task-based asynchronous operations, see [Exception Handling](../../standard/parallel-programming/exception-handling-task-parallel-library.md).

## Tasks and culture

Starting with desktop apps that target .NET Framework 4.6, the culture of the thread that creates and invokes a task becomes part of the thread's context. That is, regardless of the current culture of the thread on which the task executes, the current culture of the task is the culture of the calling thread. For apps that target versions of .NET Framework prior to .NET Framework 4.6, the culture of the task is the culture of the thread on which the task executes. For more information, see the "Culture and task-based asynchronous operations" section in the <xref:System.Globalization.CultureInfo> topic.

> [!NOTE]
> Store apps follow the Windows Runtime in setting and getting the default culture.

## For debugger developers

For developers implementing custom debuggers, several internal and private members of task may be useful (these may change from release to release). The `m_taskId` field serves as the backing store for the <xref:System.Threading.Tasks.Task.Id> property, however accessing this field directly from a debugger may be more efficient than accessing the same value through the property's getter method (the `s_taskIdCounter` counter is used to retrieve the next available ID for a task). Similarly, the `m_stateFlags` field stores information about the current lifecycle stage of the task, information also accessible through the <xref:System.Threading.Tasks.Task.Status> property. The `m_action` field stores a reference to the task's delegate, and the `m_stateObject` field stores the async state passed to the task by the developer. Finally, for debuggers that parse stack frames, the `InternalWait` method serves a potential marker for when a task is entering a wait operation.
