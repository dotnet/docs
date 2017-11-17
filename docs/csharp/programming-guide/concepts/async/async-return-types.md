---
title: "Async Return Types (C#)"
ms.custom: ""
ms.date: 05/29/2017
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: ddb2539c-c898-48c1-ad92-245e4a996df8
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Async Return Types (C#)
Async methods can have the following return types:

- <xref:System.Threading.Tasks.Task%601>, for an async method that returns a value. 
 
-  <xref:System.Threading.Tasks.Task>, for an async method that performs an operation but returns no value.

- `void`, for an event handler. 

- Starting with C# 7, any type that has an accessible `GetAwaiter` method. The object returned by the `GetAwaiter` method must implement the <xref:System.Runtime.CompilerServices.ICriticalNotifyCompletion?displayProperty=nameWithType> interface.
  
For more information about async methods, see [Asynchronous Programming with async and await (C#)](../../../../csharp/programming-guide/concepts/async/index.md).  
  
Each return type is examined in one of the following sections, and you can find a full example that uses all three types at the end of the topic.  
  
##  <a name="BKMK_TaskTReturnType"></a> Task(T) Return Type  
The <xref:System.Threading.Tasks.Task%601> return type is used for an async method that contains a [return](../../../../csharp/language-reference/keywords/return.md) (C#) statement in which the operand has type `TResult`.  
  
In the following example, the `GetLeisureHours` async method contains a `return` statement that returns an integer. Therefore, the method declaration must specify a return type of `Task<int>`.  The <xref:System.Threading.Tasks.Task.FromResult%2A> async method is a placeholder for an operation that returns a string.
  
[!code-csharp[return-value](../../../../../samples/snippets/csharp/programming-guide/async/async-returns1.cs)]

When `GetLeisureHours` is called from within an await expression in the `ShowTodaysInfo` method, the await expression retrieves the integer value (the value of `leisureHours`) that's stored in the task returned by the `GetLeisureHours` method. For more information about await expressions, see [await](../../../../csharp/language-reference/keywords/await.md).  
  
You can better understand how this happens by separating the call to `GetLeisureHours` from the application of `await`, as the following code shows. A call to method `TaskOfT_MethodAsync` that isn't immediately awaited returns a `Task<int>`, as you would expect from the declaration of the method. The task is assigned to the `integerTask` variable in the example. Because `integerTask` is a <xref:System.Threading.Tasks.Task%601>, it contains a <xref:System.Threading.Tasks.Task%601.Result> property of type `TResult`. In this case, TResult represents an integer type. When `await` is applied to `integerTask`, the await expression evaluates to the contents of the <xref:System.Threading.Tasks.Task%601.Result%2A> property of `integerTask`. The value is assigned to the `result2` variable.  
  
> [!IMPORTANT]
>  The <xref:System.Threading.Tasks.Task%601.Result%2A> property is a blocking property. If you try to access it before its task is finished, the thread that's currently active is blocked until the task completes and the value is available. In most cases, you should access the value by using `await` instead of accessing the property directly. <br/> The previous example retrieved the value of the <xref:System.Threading.Tasks.Task%601.Result%2A> property to block the main thread so that the `ShowTodaysInfo` method could finish execution before the application ended.  

[!code-csharp[return-value](../../../../../samples/snippets/csharp/programming-guide/async/async-returns1a.cs#1)]
  
##  <a name="BKMK_TaskReturnType"></a> Task Return Type  
Async methods that don't contain a `return` statement or that contain a `return` statement that doesn't return an operand usually have a return type of <xref:System.Threading.Tasks.Task>. Such methods return `void` if they run synchronously. If you use a <xref:System.Threading.Tasks.Task> return type for an async method, a calling method can use an `await` operator to suspend the caller's completion until the called async method has finished.  
  
In the following example, the `WaitAndApologize` async method doesn't contain a `return` statement, so the method returns a <xref:System.Threading.Tasks.Task> object. This enables `WaitAndApologize` to be awaited. Note that the <xref:System.Threading.Tasks.Task> type doesn't include a `Result` property because it has no return value.  

[!code-csharp[return-value](../../../../../samples/snippets/csharp/programming-guide/async/async-returns2.cs)]  
  
`WaitAndApologize` is awaited by using an await statement instead of an await expression, similar to the calling statement for a synchronous void-returning method. The application of an await operator in this case doesn't produce a value.  
  
As in the previous <xref:System.Threading.Tasks.Task%601> example, you can separate the call to `Task_MethodAsync` from the application of an await operator, as the following code shows. However, remember that a `Task` doesn't have a `Result` property, and that no value is produced when an await operator is applied to a `Task`.  
  
The following code separates calling the `WaitAndApologize` method from awaiting the task that the method returns.  
 
[!code-csharp[return-value](../../../../../samples/snippets/csharp/programming-guide/async/async-returns2a.cs#1)]  
 
##  <a name="BKMK_VoidReturnType"></a> Void return type  
You use the `void` return type in asynchronous event handlers, which require a `void` return type. For methods other than event handlers don't return a value, you should return a <xref:System.Threading.Tasks.Task> instead, because an async method that returns `void` can't be awaited. Any caller of such a method must be able to continue to completion without waiting for the called async method to finish, and the caller must be independent of any values or exceptions that the async method generates.  
  
The caller of a void-returning async method can't catch exceptions that are thrown from the method, and such unhandled exceptions are likely to cause your application to fail. If an exception occurs in an async method that returns a <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601>, the exception is stored in the returned task and is rethrown when the task is awaited. Therefore, make sure that any async method that can produce an exception has a return type of <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> and that calls to the method are awaited.  
  
For more information about how to catch exceptions in async methods, see [try-catch](../../../../csharp/language-reference/keywords/try-catch.md) .  
  
The following eample defines an async event handler.  
 
[!code-csharp[return-value](../../../../../samples/snippets/csharp/programming-guide/async/async-returns3.cs)]  
 
## Generalized async return types and ValueTask<T>

Starting with C# 7, an async method can return any type that has an accessible `GetAwaiter` method.
 
Because <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> are reference types, memory allocation in performance-critical paths, particularly when allocations occur in tight loops, can adversely affect performance. Support for generalized return types means that you can return a lightweight value type instead of a reference type to avoid additional memory allocations. 

.NET provides the <xref:System.Threading.Tasks.ValueTask%601?displayProperty=nameWithType> structure as a light-weight implementation of a generalized task-returning value. To use the <xref:System.Threading.Tasks.ValueTask%601?displayProperty=nameWithType> type, you must add the `System.Threading.Tasks.Extensions` NuGet package to your project. The following example uses the <xref:System.Threading.Tasks.ValueTask%601> structure to retrieve the value of two dice rolls. 
  
[!code-csharp[return-value](../../../../../samples/snippets/csharp/programming-guide/async/async-valuetask.cs)]

## See also  
<xref:System.Threading.Tasks.Task.FromResult%2A>   
[Walkthrough: Accessing the Web by Using async and await (C#)](../../../../csharp/programming-guide/concepts/async/walkthrough-accessing-the-web-by-using-async-and-await.md)   
[Control Flow in Async Programs (C#)](../../../../csharp/programming-guide/concepts/async/control-flow-in-async-programs.md)   
[async](../../../../csharp/language-reference/keywords/async.md)   
[await](../../../../csharp/language-reference/keywords/await.md)
