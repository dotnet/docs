---
title: Asynchronous programming in C#
description: An overview of the C# language support for asynchronous programming using async, await, Task and Task<T>
ms.date: 02/10/2019
---
# The Task asynchronous programming model in C# #

<<<<<<< HEAD
    -   Any other type that has a `GetAwaiter` method (starting with C# 7.0).
  
     For more information, see the [Return Types and Parameters](#BKMK_ReturnTypesandParameters) section.  
  
-   The method usually includes at least one await expression, which marks a point where the method can't continue until the awaited asynchronous operation is complete. In the meantime, the method is suspended, and control returns to the method's caller. The next section of this topic illustrates what happens at the suspension point.  
  
 In async methods, you use the provided keywords and types to indicate what you want to do, and the compiler does the rest, including keeping track of what must happen when control returns to an await point in a suspended method. Some routine processes, such as loops and exception handling, can be difficult to handle in traditional asynchronous code. In an async method, you write these elements much as you would in a synchronous solution, and the problem is solved.  
  
 For more information about asynchrony in previous versions of the .NET Framework, see [TPL and Traditional .NET Framework Asynchronous Programming](../../../../standard/parallel-programming/tpl-and-traditional-async-programming.md).  
  
## <a name="BKMK_WhatHappensUnderstandinganAsyncMethod"></a> What happens in an async method  
 The most important thing to understand in asynchronous programming is how the control flow moves from method to method. The following diagram leads you through the process:  
  
 ![Diagram that shows tracing an async program.](./media/index/navigation-trace-async-program.png)  
  
 The numbers in the diagram correspond to the following steps.  
  
1.  An event handler calls and awaits the  `AccessTheWebAsync` async method.  
  
2.  `AccessTheWebAsync` creates an <xref:System.Net.Http.HttpClient> instance and calls the <xref:System.Net.Http.HttpClient.GetStringAsync%2A> asynchronous method to download the contents of a website as a string.  
  
3.  Something happens in `GetStringAsync` that suspends its progress. Perhaps it must wait for a website to download or some other blocking activity. To avoid blocking resources, `GetStringAsync` yields control to its caller, `AccessTheWebAsync`.  
  
     `GetStringAsync` returns a <xref:System.Threading.Tasks.Task%601> where `TResult` is a string, and `AccessTheWebAsync` assigns the task to the `getStringTask` variable. The task represents the ongoing process for the call to `GetStringAsync`, with a commitment to produce an actual string value when the work is complete.  
  
4.  Because `getStringTask` hasn't been awaited yet, `AccessTheWebAsync` can continue with other work that doesn't depend on the final result from `GetStringAsync`. That work is represented by a call to the synchronous method `DoIndependentWork`.  
  
5.  `DoIndependentWork` is a synchronous method that does its work and returns to its caller.  
  
6.  `AccessTheWebAsync` has run out of work that it can do without a result from `getStringTask`. `AccessTheWebAsync` next wants to calculate and return the length of the downloaded string, but the method can't calculate that value until the method has the string.  
  
     Therefore, `AccessTheWebAsync` uses an await operator to suspend its progress and to yield control to the method that called `AccessTheWebAsync`. `AccessTheWebAsync` returns a `Task<int>` to the caller. The task represents a promise to produce an integer result that's the length of the downloaded string.  
  
    > [!NOTE]
    >  If `GetStringAsync` (and therefore `getStringTask`) is complete before `AccessTheWebAsync` awaits it, control remains in `AccessTheWebAsync`. The expense of suspending and then returning to `AccessTheWebAsync` would be wasted if the called asynchronous process (`getStringTask`) has already completed and `AccessTheWebSync` doesn't have to wait for the final result.  
  
     Inside the caller (the event handler in this example), the processing pattern continues. The caller might do other work that doesn't depend on the result from `AccessTheWebAsync` before awaiting that result, or the caller might await immediately.   The event handler is waiting for `AccessTheWebAsync`, and `AccessTheWebAsync` is waiting for `GetStringAsync`.  
  
7.  `GetStringAsync` completes and produces a string result. The string result isn't returned by the call to `GetStringAsync` in the way that you might expect. (Remember that the method already returned a task in step 3.) Instead, the string result is stored in the task that represents the completion of the method, `getStringTask`. The await operator retrieves the result from `getStringTask`. The assignment statement assigns the retrieved result to `urlContents`.  
  
8.  When `AccessTheWebAsync` has the string result, the method can calculate the length of the string. Then the work of `AccessTheWebAsync` is also complete, and the waiting event handler can resume. In the full example at the end of the topic, you can confirm that the event handler retrieves and prints the value of the length result.    
If you are new to asynchronous programming, take a minute to consider the difference between synchronous and asynchronous behavior. A synchronous method returns when its work is complete (step 5), but an async method returns a task value when its work is suspended (steps 3 and 6). When the async method eventually completes its work, the task is marked as completed and the result, if any, is stored in the task.  
  
For more information about control flow, see [Control Flow in Async Programs (C#)](../../../../csharp/programming-guide/concepts/async/control-flow-in-async-programs.md).  
  
## <a name="BKMK_APIAsyncMethods"></a> API async methods  
 You might be wondering where to find methods such as `GetStringAsync` that support async programming. The  .NET Framework 4.5 or higher and .NET Core contain many members that work with `async` and `await`. You can recognize them by the "Async" suffix that’s appended to the member name, and by their return type of <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601>. For example, the `System.IO.Stream` class contains methods such as <xref:System.IO.Stream.CopyToAsync%2A>, <xref:System.IO.Stream.ReadAsync%2A>, and <xref:System.IO.Stream.WriteAsync%2A> alongside the synchronous methods <xref:System.IO.Stream.CopyTo%2A>, <xref:System.IO.Stream.Read%2A>, and <xref:System.IO.Stream.Write%2A>.  
  
 The Windows Runtime also contains many methods that you can use with `async` and `await` in Windows apps. For more information, see [Threading and async programming](/windows/uwp/threading-async/) for UWP development, and [Asynchronous programming (Windows Store apps)](https://docs.microsoft.com/previous-versions/windows/apps/hh464924(v=win.10)) and [Quickstart: Calling asynchronous APIs in C# or Visual Basic](https://docs.microsoft.com/previous-versions/windows/apps/hh452713(v=win.10)) if you use earlier versions of the Windows Runtime.  
  
## <a name="BKMK_Threads"></a> Threads  
Async methods are intended to be non-blocking operations. An `await` expression in an async method doesn’t block the current thread while the awaited task is running. Instead, the expression signs up the rest of the method as a continuation and returns control to the caller of the async method.  
  
The `async` and `await` keywords don't cause additional threads to be created. Async methods don't require multithreading because an async method doesn't run on its own thread. The method runs on the current synchronization context and uses time on the thread only when the method is active. You can use <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType> to move CPU-bound work to a background thread, but a background thread doesn't help with a process that's just waiting for results to become available.  
  
The async-based approach to asynchronous programming is preferable to existing approaches in almost every case. In particular, this approach is better than the <xref:System.ComponentModel.BackgroundWorker> class for I/O-bound operations because the code is simpler and you don't have to guard against race conditions. In combination with the <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType> method, async programming is better than <xref:System.ComponentModel.BackgroundWorker> for CPU-bound operations because async programming separates the coordination details of running your code from the work that `Task.Run` transfers to the threadpool.  
  
## <a name="BKMK_AsyncandAwait"></a> async and await  
 If you specify that a method is an async method by using the [async](../../../../csharp/language-reference/keywords/async.md) modifier, you enable the following two capabilities.  
  
-   The marked async method can use [await](../../../../csharp/language-reference/keywords/await.md) to designate suspension points. The `await` operator tells the compiler that the async method can't continue past that point until the awaited asynchronous process is complete. In the meantime, control returns to the caller of the async method.  
  
     The suspension of an async method at an `await` expression doesn't constitute an exit from the method, and `finally` blocks don’t run.  
  
-   The marked async method can itself be awaited by methods that call it.  
  
An async method typically contains one or more occurrences of an `await` operator, but the absence of `await` expressions doesn’t cause a compiler error. If an async method doesn’t use an `await` operator to mark a suspension point, the method executes as a synchronous method does, despite the `async` modifier. The compiler issues a warning for such methods.  
  
 `async` and `await` are contextual keywords. For more information and examples, see the following topics:  
  
-   [async](../../../../csharp/language-reference/keywords/async.md)  
  
-   [await](../../../../csharp/language-reference/keywords/await.md)  
  
## <a name="BKMK_ReturnTypesandParameters"></a> Return types and parameters  
An async method typically returns a <xref:System.Threading.Tasks.Task> or a <xref:System.Threading.Tasks.Task%601>. Inside an async method, an `await` operator is applied to a task that's returned from a call to another async method.  
  
You specify <xref:System.Threading.Tasks.Task%601> as the return type if the method contains a [return](../../../../csharp/language-reference/keywords/return.md) statement that specifies an operand of type `TResult`. 
  
You use <xref:System.Threading.Tasks.Task>  as the return type if the method has no return statement or has a return statement that doesn't return an operand.  
=======
The Task asynchronous programming model (TAP) provides an abstraction over asynchronous code. You write code as a sequence of statements, just like always. You can read that code as though each statement completes before the next begins. The compiler performs a number of transformations because some of those statements may start work and return a <xref:System.Threading.Tasks.Task> that represents the ongoing work.
>>>>>>> interim checkin to switch branches

That's the goal of this syntax: enable code that reads like a sequence of statements, but executes in a much more complicated order based on external resource allocation and when tasks complete.

It's analogous to how people give instructions for processes that include asynchronous tasks. As an example, consider making breakfast. You'd write the instructions something like the following list:

1. Pour a cup of coffee.
1. Heat up a pan, then fry two eggs.
1. Fry three slices of bacon.
1. Toast two pieces of bread.
1. Add butter and jam to the toast.
1. Pour a glass of orange juice.

Read those instructions as though they were the description of a computer algorithm. Imagine a person following them exactly as written. That would created an unsatisfying breakfast. The later tasks would not be started until the earlier tasks had completed. It would take much longer to create the breakfast, and some items would have gotten cold before being served. Thankfully, most people would interpret those instructions differently. They would naturally perform those tasks asynchronously.

Now, consider those same instructions written as C# statements:

```csharp
Coffee cup = PourCoffee();
Console.WriteLine("coffee is ready");
Egg eggs = FryEggs(2);
Console.WriteLine("eggs are ready");
Bacon bacon = FryBacon(3);
Console.WriteLine("bacon is ready");
Toast toast = ToastBread(2);
ApplyButter(toast);
ApplyJam(toast);
Console.WriteLine("toast is ready");
Juice oj = PourOJ();
Console.WriteLine("oj is ready");

Console.WriteLine("Breakfast is ready!");
```

Computers do not interpret those instructions the same way people do. The computer will block on each statement until the work is complete before moving on to the next statement. You get a cold breakfast, and it takes longer than it should to arrive. If you want the computer to execute the above instructions asynchronously, you must write asynchronous code.

Asynchronous code is not the same as parallel code. Continuing the breakfast analogy, one person can make breakfast asynchronously by starting the next task before the first completes. As soon as you start warming the pan for the eggs, you can begin frying the bacon. Once the bacon starts, you can put the bread into the toaster.

For a parallel algorithm, you'd need multiple cooks (or threads). One would make the eggs, one the bacon, and so on. Each one would be focused on just that one task. Each cook (or thread) would be blocked synchronously waiting for bacon to be ready to flip, or the toast to pop. 

These concerns are important for the programs you write today. When you write client programs, you want the UI to be responsive to user input. Your application shouldn't make a phone appear frozen while it's downloading data from the web. When you write server programs, you don't want threads blocked. Those threads could be serving other requests. Using synchronous code when asynchronous alternatives exist hurts your ability to scale out less expensively. You need to pay for those blocked threads.

Successful modern applications require asynchronous code. Too often, though, writing asynchronous code required callbacks, completion events, or other means that obscured the original intent of the code. The advantage of the synchronous code is that it's easy to understand. The step-by-step actions make it easy to scan and understand.

## Create an asynchronous alternative

The `await` keyword provides a non-blocking way to start a task, then continue execution when that task completes. A simple asynchronous version of the make a breakfast code would look like the following snippet:

```csharp
Coffee cup = PourCoffee();
Console.WriteLine("coffee is ready");
Egg eggs = await FryEggs(2);
Console.WriteLine("eggs are ready");
Bacon bacon = await FryBacon(3);
Console.WriteLine("bacon is ready");
Toast toast = await ToastBread(2);
ApplyButter(toast);
ApplyJam(toast);
Console.WriteLine("toast is ready");
Juice oj = PourOJ();
Console.WriteLine("oj is ready");

Console.WriteLine("Breakfast is ready!");
```

For many applications, this change is all that's needed. Now, the thread working on the breakfast is freed to do other work while awaiting any started task that hasn't yet finished. If this is a restaurant where multiple orders are placed, the cook could start another breakfast while the first is cooking. 



## Start multiple tasks

Do the next step

## Composition

async composition is Task, Task<T>. It contrasts with sync composition of void, T

## Lessons learned

