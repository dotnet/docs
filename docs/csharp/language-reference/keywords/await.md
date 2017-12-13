---
title: "await (C# Reference)"
ms.date: 05/22/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "await_CSharpKeyword"
helpviewer_keywords: 
  - "await keyword [C#]"
  - "await [C#]"
ms.assetid: 50725c24-ac76-4ca7-bca1-dd57642ffedb
caps.latest.revision: 36
author: "BillWagner"
ms.author: "wiwagn"
---
# await (C# Reference)
The `await` operator is applied to a task in an asynchronous method to insert a suspension point in the execution of the method until the awaited task completes. The task represents ongoing work.  
  
`await` can only be used in an asynchronous method modified by the [async](../../../csharp/language-reference/keywords/async.md) keyword. Such a method, defined by using the `async` modifier and usually containing one or more `await` expressions, is referred to as an *async method*.  
  
> [!NOTE]
>  The `async` and `await` keywords were introduced in C# 5. For an introduction to async programming, see [Asynchronous Programming with async and await](../../../csharp/programming-guide/concepts/async/index.md).  
  
The task to which the `await` operator is applied typically is returned by a call to a method that implements the [Task-Based Asynchronous Pattern](../../../standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md). They include methods that return <xref:System.Threading.Tasks.Task>, <xref:System.Threading.Tasks.Task%601>, and `System.Threading.Tasks.ValueType<TResult>` objects.  

  
 In the following example, the <xref:System.Net.Http.HttpClient.GetByteArrayAsync%2A?displayProperty=nameWithType> method returns a `Task<byte[]>`. The task is a promise to produce the actual byte array when the task is complete. The `await` operator suspends execution until the work of the <xref:System.Net.Http.HttpClient.GetByteArrayAsync%2A> method is complete. In the meantime, control is returned to the caller of `GetPageSizeAsync`. When the task finishes execution, the `await` expression evaluates to a byte array.  

[!code-csharp[await-example](../../../../samples/snippets/csharp/language-reference/keywords/await/await1.cs)]  

> [!IMPORTANT]
>  For the complete example, see [Walkthrough: Accessing the Web by Using Async and Await](../../../csharp/programming-guide/concepts/async/walkthrough-accessing-the-web-by-using-async-and-await.md). You can download the sample from [Developer Code Samples](https://code.msdn.microsoft.com/Async-Sample-Accessing-the-9c10497f) on the Microsoft website. The example is in the AsyncWalkthrough_HttpClient project.  
  
As shown in the previous example, if `await` is applied to the result of a method call that returns a `Task<TResult>`, then the type of the `await` expression is `TResult`. If `await` is applied to the result of a method call that returns a `Task`, then the type of the `await` expression is `void`. The following example illustrates the difference.  
  
```csharp  
// await keyword used with a method that returns a Task<TResult>.  
TResult result = await AsyncMethodThatReturnsTaskTResult();  
  
// await keyword used with a method that returns a Task.  
await AsyncMethodThatReturnsTask();  

// await keyword used with a method that returns a ValueTask<TResult>.
TResult result = await AsyncMethodThatReturnsValueTaskTResult();
```  
  
An `await` expression does not block the thread on which it is executing. Instead, it causes the compiler to sign up the rest of the async method as a continuation on the awaited task. Control then returns to the caller of the async method. When the task completes, it invokes its continuation, and execution of the async method resumes where it left off.  
  
An `await` expression can occur only in the body of its enclosing method, lambda expression, or anonymous method, which must be marked with an `async` modifier. The term *await* serves as a keyword only in that context. Elsewhere, it is interpreted as an identifier. Within the method, lambda expression, or anonymous method, an `await` expression cannot occur in the body of a synchronous function, in a query expression, in the block of a [lock statement](../../../csharp/language-reference/keywords/lock-statement.md), or in an [unsafe](../../../csharp/language-reference/keywords/unsafe.md) context.  
  
## Exceptions  
Most async methods return a <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601>. The properties of the returned task carry information about its status and history, such as whether the task is complete, whether the async method caused an exception or was canceled, and what the final result is. The `await` operator accesses those properties by calling methods on the object returned by the `GetAwaiter` method.  
  
If you await a task-returning async method that causes an exception, the `await` operator rethrows the exception.  
  
If you await a task-returning async method that's canceled, the `await` operator rethrows an <xref:System.OperationCanceledException>.  
  
A single task that is in a faulted state can reflect multiple exceptions. For example, the task might be the result of a call to <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType>. When you await such a task, the await operation rethrows only one of the exceptions. However, you can't predict which of the exceptions is rethrown.  
  
For examples of error handling in async methods, see [try-catch](../../../csharp/language-reference/keywords/try-catch.md).  
  
## Example  
The following example returns the total number of characters in the pages whose URLs are passed to it as command line arguments. The example calls the `GetPageLengthsAsync` method, which is marked with the `async` keyword. The `GetPageLengthsAsync` method in turn uses the `await` keyword to await calls to the <xref:System.Net.Http.HttpClient.GetStringAsync%2A?displayProperty=nameWithType> method.  

[!code-csharp[await-example](../../../../samples/snippets/csharp/language-reference/keywords/await/await2.cs)]  

Because the use of `async` and `await` in an application entry point is not supported, we cannot apply the `async` attribute to the `Main` method, nor can we await the `GetPageLengthsAsync` method call. We can ensure that the `Main` method waits for the async operation to complete by retrieving the value of the <xref:System.Threading.Tasks.Task%601.Result?displayProperty=nameWithType> property. For tasks that do not return a value, you can call the <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> method. 

## See also  
[Asynchronous Programming with async and await](../../../csharp/programming-guide/concepts/async/index.md)   
[Walkthrough: Accessing the Web by Using Async and Await](../../../csharp/programming-guide/concepts/async/walkthrough-accessing-the-web-by-using-async-and-await.md)   
[async](../../../csharp/language-reference/keywords/async.md)
