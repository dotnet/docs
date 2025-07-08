---
title: System.Threading.Tasks.TaskScheduler class
description: Learn about the System.Threading.Tasks.TaskScheduler class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
---
# System.Threading.Tasks.TaskScheduler class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Threading.Tasks.TaskScheduler> class represents a task scheduler. A task scheduler ensures that the work of a task is eventually executed.

The default task scheduler provides work-stealing for load-balancing, thread injection/retirement for maximum throughput, and overall good performance. It should be sufficient for most scenarios.

The <xref:System.Threading.Tasks.TaskScheduler> class also serves as the extension point for all customizable scheduling logic. This includes mechanisms such as how to schedule a task for execution, and how scheduled tasks should be exposed to debuggers. If you require special functionality, you can create a custom scheduler and enable it for specific tasks or queries.

## The default task scheduler and the thread pool

The default scheduler for the Task Parallel Library and PLINQ uses the .NET thread pool, which is represented by the <xref:System.Threading.ThreadPool> class, to queue and execute work. The thread pool uses the information that is provided by the <xref:System.Threading.Tasks.Task> type to efficiently     support the fine-grained parallelism (short-lived units of work) that parallel tasks and queries often represent.

### The global queue vs. local queues

The thread pool maintains a global FIFO (first-in, first-out) work queue for threads in each application domain. Whenever a program calls the <xref:System.Threading.ThreadPool.QueueUserWorkItem%2A?displayProperty=nameWithType> (or <xref:System.Threading.ThreadPool.UnsafeQueueUserWorkItem%2A?displayProperty=nameWithType>) method, the work is put on this shared queue and eventually de-queued onto the next thread that becomes available. Starting with .NET Framework 4, this queue uses a lock-free algorithm that resembles the <xref:System.Collections.Concurrent.ConcurrentQueue%601> class. By using this lock-free implementation, the thread pool spends less time when it queues and de-queues work items. This performance benefit is available to all programs that use the thread pool.

Top-level tasks, which are tasks that are not created in the context of another task, are put on the global queue just like any other work item. However, nested or child tasks, which are created in the context of another task, are handled quite differently. A child or nested task is put on a local queue that is specific to the thread on which the parent task is executing. The parent task may be a top-level task or it also may be the child of another task. When this thread is ready for more work, it first looks in the local queue. If work items are waiting there, they can be accessed quickly. The local queues are accessed in last-in, first-out order (LIFO) to preserve cache locality and reduce contention. For more information about child tasks and nested tasks, see [Attached and Detached Child Tasks](../../standard/parallel-programming/attached-and-detached-child-tasks.md).

The use of local queues not only reduces pressure on the global queue, but also takes advantage of data locality. Work items in the local queue frequently reference data structures that are physically near one another in memory. In these cases, the data is already in the cache after the first task has run and can be accessed quickly. Both [Parallel LINQ (PLINQ)](/dotnet/standard/parallel-programming/parallel-linq-plinq) and the <xref:System.Threading.Tasks.Parallel> class use nested tasks and child tasks extensively, and achieve significant speedups by using the local work queues.

### Work stealing

Starting with .NET Framework 4, the thread pool also features a work-stealing algorithm to help make sure that no threads are sitting idle while others still have work in their queues. When a thread-pool thread is ready for more work, it first looks at the head of its local queue, then in the global queue, and then in the local queues of other threads. If it finds a work item in the local queue of another thread, it first applies heuristics to make sure that it can run the work efficiently. If it can, it de-queues the work item from the tail (in FIFO order). This reduces contention on each local queue and preserves data locality. This architecture helps the thread pool load-balance work more efficiently than past versions did.

### Long-running tasks

You may want to explicitly prevent a task from being put on a local queue. For example, you may know that a particular work item will run for a relatively long time and is likely to block all other work items on the local queue. In this case, you can specify the <xref:System.Threading.Tasks.TaskCreationOptions?displayProperty=nameWithType> option, which provides a hint to the scheduler that an additional thread might be required for the task so that it does not block the forward progress of other threads or work items on the local queue. By using this option you avoid the thread pool completely, including the global and local queues.

### Task inlining

In some cases when a <xref:System.Threading.Tasks.Task> is waited on, it may be executed synchronously on the thread that is performing the wait operation. This enhances performance by preventing the need for an additional thread and instead using the existing thread, which would have blocked otherwise. To prevent errors due to reentrancy, task inlining only occurs when the wait target is found in the relevant thread's local queue.

## Specify a synchronization context

You can use the <xref:System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext%2A?displayProperty=nameWithType> method to specify that a task should be scheduled to run on a particular thread. This is useful in frameworks such as Windows Forms and Windows Presentation Foundation where access to user interface objects is often restricted to code that is running on the same thread on which the UI object was created.

The following example uses the <xref:System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext%2A?displayProperty=nameWithType> method in a Windows Presentation Foundation (WPF) app to schedule a task on the same thread that the user interface (UI) control was created on. The example creates a mosaic of images that are randomly selected from a specified directory. The WPF objects are used to load and resize the images. The raw pixels are then passed to a task that uses a <xref:System.Threading.Tasks.Parallel.For%2A> loop to write the pixel data into a large single-byte array. No synchronization is required because no two tiles occupy the same array elements. The tiles can also be written in any order because their position is calculated independently of any other tile. The large array is then passed to a task that runs on the UI thread, where the pixel data is loaded into an Image control.

The example moves data off the UI thread, modifies it by using parallel loops and <xref:System.Threading.Tasks.Task> objects, and then passes it back to a task that runs on the UI thread. This approach is useful when you have to use the Task Parallel Library to perform operations that either are not supported by the WPF API, or are not sufficiently fast. Another way to create an image mosaic in WPF is to use a <xref:System.Windows.Controls.WrapPanel?displayProperty=nameWithType> control and add images to it. The <xref:System.Windows.Controls.WrapPanel> handles the work of positioning the tiles. However, this work can only be performed on the UI thread.

:::code language="csharp" source="./snippets/System.Threading.Tasks/TaskScheduler/FromCurrentSynchronizationContext/csharp/mainwindow.xaml.cs" id="Snippet01":::
:::code language="vb" source="./snippets/System.Threading.Tasks/TaskScheduler/Overview/vb/MainWindow.xaml.vb" id="Snippet01":::

To create the example, create a WPF application project in Visual Studio and name it WPF_CS1 (for a C# WPF project) or WPF_VB1 (for a Visual Basic WPF project). Then do the following:

1. In design view, drag an <xref:System.Windows.Controls.Image> control from the **Toolbox** onto the upper left corner of the design surface. In the **Name** textbox of the **Properties** window, name the control "image".

2. Drag a <xref:System.Windows.Controls.Button> control from the **Toolbox** to the lower left part of the application window. In XAML view, specify the <xref:System.Windows.Controls.ContentControl.Content> property of the button as "Make a mosaic", and specify its <xref:System.Windows.FrameworkElement.Width> property as "100". Connect the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event with the `button_Click` event handler defined in the example's code by adding `Click="button_Click"` to the `<Button>` element. In the **Name** textbox of the **Properties** window, name the control "button".

3. Replace the entire contents of the MainWindow.xaml.cs or MainWindow.xaml.vb file with the code from this example. For a C# WPF project, make sure that the name of the workspace matches the project name.

4. The example reads JPEG images from a directory named *C:\Users\Public\Pictures\Sample Pictures*. Either create the directory and place some images in it, or change the path to refer to some other directory that contains images.

This example has some limitations. For example, only 32-bits-per-pixel images are supported; images in other formats are corrupted by the <xref:System.Windows.Media.Imaging.BitmapImage> object during the resizing operation. Also, the source images must all be larger than the tile size. As a further exercise, you can add functionality to handle multiple pixel formats and file sizes.
