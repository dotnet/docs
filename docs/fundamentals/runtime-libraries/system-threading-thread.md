---
title: System.Threading.Thread class
description: Learn about the System.Threading.Thread class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Threading.Thread class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Threading.Thread> class creates and controls a thread, sets its priority, and gets its status.

When a process starts, the common language runtime automatically creates a single foreground thread to execute application code. Along with this main foreground thread, a process can create one or more threads to execute a portion of the program code associated with the process. These threads can execute either in the foreground or in the background. In addition, you can use the <xref:System.Threading.ThreadPool> class to execute code on worker threads that are managed by the common language runtime.

## Start a thread

You start a thread by supplying a delegate that represents the method the thread is to execute in its class constructor. You then call the <xref:System.Threading.Thread.Start%2A> method to begin execution.

The <xref:System.Threading.Thread> constructors can take either of two delegate types, depending on whether you can pass an argument to the method to be executed:

- If the method has no arguments, you pass a <xref:System.Threading.ThreadStart> delegate to the constructor. It has the signature:

    ```csharp
    public delegate void ThreadStart()
    ```

    ```vb
    Public Delegate Sub ThreadStart()
    ```

  The following example creates and starts a thread that executes the `ExecuteInForeground` method. The method displays information about some thread properties, then executes a loop in which it pauses for half a second and displays the elapsed number of seconds. When the thread has executed for at least five seconds, the loop ends and the thread terminates execution.

  :::code language="csharp" source="./snippets/System.Threading/Thread/Overview/csharp/ThreadStart1.cs" id="Snippet1":::
  :::code language="fsharp" source="./snippets/System.Threading/Thread/Overview/fsharp/ThreadStart1.fs" id="Snippet1":::
  :::code language="vb" source="./snippets/System.Threading/Thread/Overview/vb/ThreadStart1.vb" id="Snippet1":::

- If the method has an argument, you pass a <xref:System.Threading.ParameterizedThreadStart> delegate to the constructor. It has the signature:

    ```csharp
    public delegate void ParameterizedThreadStart(object obj)
    ```

    ```vb
    Public Delegate Sub ParameterizedThreadStart(obj As Object)
    ```

  The method executed by the delegate can then cast (in C#) or convert (in Visual Basic) the parameter to the appropriate type.

  The following example is identical to the previous one, except that it calls the <xref:System.Threading.Thread.%23ctor%28System.Threading.ParameterizedThreadStart%29> constructor. This version of the `ExecuteInForeground` method has a single parameter that represents the approximate number of milliseconds the loop is to execute.

  :::code language="csharp" source="./snippets/System.Threading/Thread/Overview/csharp/ThreadStart2.cs" id="Snippet2":::
  :::code language="fsharp" source="./snippets/System.Threading/Thread/Overview/fsharp/ThreadStart2.fs" id="Snippet2":::
  :::code language="vb" source="./snippets/System.Threading/Thread/Overview/vb/ThreadStart2.vb" id="Snippet2":::

It isn't necessary to retain a reference to a <xref:System.Threading.Thread> object once you've started the thread. The thread continues to execute until the thread procedure is complete.

## Retrieve Thread objects

You can use the static (`Shared` in Visual Basic) <xref:System.Threading.Thread.CurrentThread> property to retrieve a reference to the currently executing thread from the code that the thread is executing. The following example uses the <xref:System.Threading.Thread.CurrentThread> property to display information about the main application thread, another foreground thread, a background thread, and a thread pool thread.

:::code language="csharp" source="./snippets/System.Threading/Thread/Overview/csharp/Instance1.cs" id="Snippet4":::
:::code language="fsharp" source="./snippets/System.Threading/Thread/Overview/fsharp/Instance1.fs" id="Snippet4":::
:::code language="vb" source="./snippets/System.Threading/Thread/Overview/vb/Instance1.vb" id="Snippet4":::

## Foreground and background threads

Instances of the <xref:System.Threading.Thread> class represent either foreground threads or background threads. Background threads are identical to foreground threads with one exception: a background thread does not keep a process running if all foreground threads have terminated. Once all foreground threads have been stopped, the runtime stops all background threads and shuts down.

By default, the following threads execute in the foreground:

- The main application thread.

- All threads created by calling a <xref:System.Threading.Thread> class constructor.

The following threads execute in the background by default:

- Thread pool threads, which come from a pool of worker threads maintained by the runtime. You can configure the thread pool and schedule work on thread pool threads by using the <xref:System.Threading.ThreadPool> class.

    > [!NOTE]
    > Task-based asynchronous operations automatically execute on thread pool threads. Task-based asynchronous operations use the <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> classes to implement the [task-based asynchronous pattern](../../standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md).

- All threads that enter the managed execution environment from unmanaged code.

You can change a thread to execute in the background by setting the <xref:System.Threading.Thread.IsBackground> property at any time. Background threads are useful for any operation that should continue as long as an application is running but should not prevent the application from terminating, such as monitoring file system changes or incoming socket connections.

The following example illustrates the difference between foreground and background threads. It's like the first example in the [Start a thread](#start-a-thread) section, except that it sets the thread to execute in the background before starting it. As the output shows, the loop is interrupted before it executes for five seconds.

:::code language="csharp" source="./snippets/System.Threading/Thread/Overview/csharp/BackgroundEx1.cs" id="Snippet3":::
:::code language="fsharp" source="./snippets/System.Threading/Thread/Overview/fsharp/BackgroundEx1.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Threading/Thread/Overview/vb/BackgroundEx1.vb" id="Snippet3":::

## Culture and threads

Each thread has a culture, represented by the <xref:System.Threading.Thread.CurrentCulture> property, and a UI culture, represented by the <xref:System.Threading.Thread.CurrentUICulture> property. The current culture supports culture-sensitive operations, such as parsing and formatting, string comparison, and sorting, and also controls the writing system and calendar used by a thread. The current UI culture provides for culture-sensitive retrieval of resources in resource files.

> [!IMPORTANT]
> The <xref:System.Threading.Thread.CurrentCulture> and <xref:System.Threading.Thread.CurrentUICulture> properties don't work reliably when used with any thread other than the current thread. In .NET Framework, reading these properties is reliable, although setting these properties for a thread other than the current thread is not. On .NET Core, an <xref:System.InvalidOperationException> is thrown if a thread attempts to read or write these properties on a different thread.
> We recommend that you use the <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=nameWithType> and <xref:System.Globalization.CultureInfo.CurrentUICulture?displayProperty=nameWithType> properties to retrieve and set the current culture.

When a new thread is instantiated, its culture and UI culture are defined by the current system culture and UI culture, and not by the culture and UI culture of the thread from which the new thread is created. This means, for example, that if the current system culture is English (United States) and the current culture of the primary application thread is French (France), the culture of a new thread created by calling the   <xref:System.Threading.Thread.%23ctor%28System.Threading.ParameterizedThreadStart%29> constructor from the primary thread is English (United States), and not French (France). For more information, see the "Culture and threads" section of the <xref:System.Globalization.CultureInfo> class topic.

> [!IMPORTANT]
> This is not true of threads that execute asynchronous operations for apps that target .NET Framework 4.6 and later versions. In this case, the culture and UI culture is part of an asynchronous operation's context; the thread on which an asynchronous operation executes by default inherits the culture and UI culture of the thread from which the asynchronous operation was launched. For more information, see the "Culture and task-based asynchronous operations" section of the <xref:System.Globalization.CultureInfo> class remarks.

You can do either of the following to ensure that all of the threads executing in an application share the same culture and UI culture:

- You can pass a <xref:System.Globalization.CultureInfo> object that represents that culture to the <xref:System.Threading.ParameterizedThreadStart> delegate or the <xref:System.Threading.ThreadPool.QueueUserWorkItem%28System.Threading.WaitCallback%2CSystem.Object%29?displayProperty=nameWithType> method.

- For apps running on .NET Framework 4.5 and later versions, you can define the culture and UI culture that is to be assigned to all threads created in an application domain by setting the value of the <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture%2A?displayProperty=nameWithType> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture%2A?displayProperty=nameWithType> properties. Note that this is a per-application domain setting.

For more information and examples, see the "Culture and threads" section of the <xref:System.Globalization.CultureInfo> class remarks.

## Get information about and control threads

You can retrieve a number of property values that provide information about a thread. In some cases, you can also set these property values to control the operation of the thread. These thread properties include:

- A name. <xref:System.Threading.Thread.Name> is a write-once property that you can use to identify a thread. Its default value is `null`.

- A hash code, which you can retrieve by calling the <xref:System.Threading.Thread.GetHashCode%2A> method. The hash code can be used to uniquely identify a thread; for the lifetime of your thread, its hash code will not collide with the value from any other thread, regardless of the application domain from which you obtain the value.

- A thread ID. The value of the read-only <xref:System.Threading.Thread.ManagedThreadId> property is assigned by the runtime and uniquely identifies a thread within its process.

    > [!NOTE]
    > An operating-system [ThreadId](/windows/win32/api/processthreadsapi/nf-processthreadsapi-getthreadid) has no fixed relationship to a managed thread, because an unmanaged host can control the relationship between managed and unmanaged threads. Specifically, a sophisticated host can use the [CLR Hosting API](../../framework/unmanaged-api/hosting/index.md) to schedule many managed threads against the same operating system thread, or to move a managed thread between different operating system threads.

- The thread's current state. For the duration of its existence, a thread is always in one or more of the states defined by the <xref:System.Threading.ThreadState> property.

- A scheduling priority level, which is defined by the <xref:System.Threading.ThreadPriority> property. Although you can set this value to request a thread's priority, it is not guaranteed to be honored by the operating system.

- The read-only <xref:System.Threading.Thread.IsThreadPoolThread> property, which indicates whether a thread is a thread-pool thread.

- The <xref:System.Threading.Thread.IsBackground> property. For more information, see the [Foreground and background threads](#foreground-and-background-threads) section.

## Examples

The following example demonstrates simple threading functionality.

:::code language="csharp" source="./snippets/System.Threading/Thread/Overview/csharp/source.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System.Threading/Thread/Overview/fsharp/source.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Threading/Thread/Overview/vb/source.vb" id="Snippet1":::

This code produces output similar to the following:

```output
[VB, C++, C#]
Main thread: Start a second thread.
Main thread: Do some work.
ThreadProc: 0
Main thread: Do some work.
ThreadProc: 1
Main thread: Do some work.
ThreadProc: 2
Main thread: Do some work.
ThreadProc: 3
Main thread: Call Join(), to wait until ThreadProc ends.
ThreadProc: 4
ThreadProc: 5
ThreadProc: 6
ThreadProc: 7
ThreadProc: 8
ThreadProc: 9
Main thread: ThreadProc.Join has returned. Press Enter to end program.
```
