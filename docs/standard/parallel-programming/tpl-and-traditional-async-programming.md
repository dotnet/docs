---
title: "TPL and Traditional .NET Framework Asynchronous Programming"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "tasks, with other asynchronous models"
ms.assetid: e7b31170-a156-433f-9f26-b1fc7cd1776f
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# TPL and Traditional .NET Framework Asynchronous Programming
The .NET Framework provides the following two standard patterns for performing I/O-bound and compute-bound asynchronous operations:  
  
-   Asynchronous Programming Model (APM), in which asynchronous operations are represented by a pair of Begin/End methods such as <xref:System.IO.FileStream.BeginRead%2A?displayProperty=nameWithType> and <xref:System.IO.Stream.EndRead%2A?displayProperty=nameWithType>.  
  
-   Event-based asynchronous pattern (EAP), in which asynchronous operations are represented by a method/event pair that are named *OperationName*Async and *OperationName*Completed, for example, <xref:System.Net.WebClient.DownloadStringAsync%2A?displayProperty=nameWithType> and <xref:System.Net.WebClient.DownloadStringCompleted?displayProperty=nameWithType>. (EAP was introduced in the .NET Framework version 2.0.)  
  
 The Task Parallel Library (TPL) can be used in various ways in conjunction with either of the asynchronous patterns. You can expose both APM and EAP operations as Tasks to library consumers, or you can expose the APM patterns but use Task objects to implement them internally. In both scenarios, by using Task objects, you can simplify the code and take advantage of the following useful functionality:  
  
-   Register callbacks, in the form of task continuations, at any time after the task has started.  
  
-   Coordinate multiple operations that execute in response to a `Begin_` method, by using the <xref:System.Threading.Tasks.TaskFactory.ContinueWhenAll%2A> and <xref:System.Threading.Tasks.TaskFactory.ContinueWhenAny%2A> methods, or the <xref:System.Threading.Tasks.Task.WaitAll%2A> method or the <xref:System.Threading.Tasks.Task.WaitAny%2A> method.  
  
-   Encapsulate asynchronous I/O-bound and compute-bound operations in the same Task object.  
  
-   Monitor the status of the Task object.  
  
-   Marshal the status of an operation to a Task object by using <xref:System.Threading.Tasks.TaskCompletionSource%601>.  
  
## Wrapping APM Operations in a Task  
 Both the <xref:System.Threading.Tasks.TaskFactory?displayProperty=nameWithType> and <xref:System.Threading.Tasks.TaskFactory%601?displayProperty=nameWithType> classes provide several overloads of the <xref:System.Threading.Tasks.TaskFactory.FromAsync%2A?displayProperty=nameWithType> and <xref:System.Threading.Tasks.TaskFactory%601.FromAsync%2A?displayProperty=nameWithType> methods that let you encapsulate an APM Begin/End method pair in one <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> instance. The various overloads accommodate any Begin/End method pair that have from zero to three input parameters.  
  
 For pairs that have `End` methods that return a value (`Function` in Visual Basic), use the methods in <xref:System.Threading.Tasks.TaskFactory%601> that create a <xref:System.Threading.Tasks.Task%601>. For `End` methods that return void (`Sub` in Visual Basic), use the methods in <xref:System.Threading.Tasks.TaskFactory> that create a <xref:System.Threading.Tasks.Task>.  
  
 For those few cases in which the `Begin` method has more than three parameters or contains `ref` or `out` parameters, additional `FromAsync` overloads that encapsulate only the `End` method are provided.  
  
 The following example shows the signature for the `FromAsync` overload that matches the <xref:System.IO.FileStream.BeginRead%2A?displayProperty=nameWithType> and <xref:System.IO.FileStream.EndRead%2A?displayProperty=nameWithType> methods. This overload takes three input parameters, as follows.  
  
 [!code-csharp[FromAsync#01](../../../samples/snippets/csharp/VS_Snippets_Misc/fromasync/cs/fromasync.cs#01)]
 [!code-vb[FromAsync#01](../../../samples/snippets/visualbasic/VS_Snippets_Misc/fromasync/vb/module1.vb#01)]  
  
 The first parameter is a <xref:System.Func%606> delegate that matches the signature of the <xref:System.IO.FileStream.BeginRead%2A?displayProperty=nameWithType> method. The second parameter is a <xref:System.Func%602> delegate that takes an <xref:System.IAsyncResult> and returns a `TResult`. Because <xref:System.IO.FileStream.EndRead%2A> returns an integer, the compiler infers the type of `TResult` as <xref:System.Int32> and the type of the task as <xref:System.Threading.Tasks.Task>. The last four parameters are identical to those in the <xref:System.IO.FileStream.BeginRead%2A?displayProperty=nameWithType> method:  
  
-   The buffer in which to store the file data.  
  
-   The offset in the buffer at which to begin writing data.  
  
-   The maximum amount of data to read from the file.  
  
-   An optional object that stores user-defined state data to pass to the callback.  
  
### Using ContinueWith for the Callback Functionality  
 If you require access to the data in the file, as opposed to just the number of bytes, the <xref:System.Threading.Tasks.TaskFactory.FromAsync%2A> method is not sufficient. Instead, use <xref:System.Threading.Tasks.Task>, whose `Result` property contains the file data. You can do this by adding a continuation to the original task. The continuation performs the work that would typically be performed by the <xref:System.AsyncCallback> delegate. It is invoked when the antecedent completes, and the data buffer has been filled. (The <xref:System.IO.FileStream> object should be closed before returning.)  
  
 The following example shows how to return a <xref:System.Threading.Tasks.Task> that encapsulates the BeginRead/EndRead pair of the <xref:System.IO.FileStream> class.  
  
 [!code-csharp[FromAsync#03](../../../samples/snippets/csharp/VS_Snippets_Misc/fromasync/cs/fromasync.cs#03)]
 [!code-vb[FromAsync#03](../../../samples/snippets/visualbasic/VS_Snippets_Misc/fromasync/vb/module1.vb#03)]  
  
 The method can then be called, as follows.  
  
 [!code-csharp[FromAsync#04](../../../samples/snippets/csharp/VS_Snippets_Misc/fromasync/cs/fromasync.cs#04)]
 [!code-vb[FromAsync#04](../../../samples/snippets/visualbasic/VS_Snippets_Misc/fromasync/vb/module1.vb#04)]  
  
### Providing Custom State Data  
 In typical <xref:System.IAsyncResult> operations, if your <xref:System.AsyncCallback> delegate requires some custom state data, you have to pass it in through the last parameter in the `Begin` method, so that the data can be packaged into the <xref:System.IAsyncResult> object that is eventually passed to the callback method. This is typically not required when the `FromAsync` methods are used. If the custom data is known to the continuation, then it can be captured directly in the continuation delegate. The following example resembles the previous example, but instead of examining the `Result` property of the antecedent, the continuation examines the custom state data that is directly accessible to the user delegate of the continuation.  
  
 [!code-csharp[FromAsync#05](../../../samples/snippets/csharp/VS_Snippets_Misc/fromasync/cs/fromasync.cs#05)]
 [!code-vb[FromAsync#05](../../../samples/snippets/visualbasic/VS_Snippets_Misc/fromasync/vb/module1.vb#05)]  
  
### Synchronizing Multiple FromAsync Tasks  
 The static <xref:System.Threading.Tasks.TaskFactory.ContinueWhenAll%2A> and <xref:System.Threading.Tasks.TaskFactory.ContinueWhenAny%2A> methods provide added flexibility when used in conjunction with the `FromAsync` methods. The following example shows how to initiate multiple asynchronous I/O operations, and then wait for all of them to complete before you execute the continuation.  
  
 [!code-csharp[FromAsync#06](../../../samples/snippets/csharp/VS_Snippets_Misc/fromasync/cs/fromasync.cs#06)]
 [!code-vb[FromAsync#06](../../../samples/snippets/visualbasic/VS_Snippets_Misc/fromasync/vb/module1.vb#06)]  
  
### FromAsync Tasks For Only the End Method  
 For those few cases in which the `Begin` method requires more than three input parameters, or has `ref` or `out` parameters, you can use the `FromAsync` overloads, for example, <xref:System.Threading.Tasks.TaskFactory%601.FromAsync%28System.IAsyncResult%2CSystem.Func%7BSystem.IAsyncResult%2C%600%7D%29?displayProperty=nameWithType>, that represent only the `End` method. These methods can also be used in any scenario in which you are passed an <xref:System.IAsyncResult> and want to encapsulate it in a Task.  
  
 [!code-csharp[FromAsync#07](../../../samples/snippets/csharp/VS_Snippets_Misc/fromasync/cs/fromasync.cs#07)]
 [!code-vb[FromAsync#07](../../../samples/snippets/visualbasic/VS_Snippets_Misc/fromasync/vb/module1.vb#07)]  
  
### Starting and Canceling FromAsync Tasks  
 The task returned by a `FromAsync` method has a status of WaitingForActivation and will be started by the system at some point after the task is created. If you attempt to call Start on such a task, an exception will be raised.  
  
 You cannot cancel a `FromAsync` task, because the underlying .NET Framework APIs currently do not support in-progress cancellation of file or network I/O. You can add cancellation functionality to a method that encapsulates a `FromAsync` call, but you can only respond to the cancellation before `FromAsync` is called or after it completed (for example, in a continuation task).  
  
 Some classes that support EAP, for example, <xref:System.Net.WebClient>, do support cancellation, and you can integrate that native cancellation functionality by using cancellation tokens.  
  
## Exposing Complex EAP Operations As Tasks  
 The TPL does not provide any methods that are specifically designed to encapsulate an event-based asynchronous operation in the same way that the `FromAsync` family of methods wrap the <xref:System.IAsyncResult> pattern. However, the TPL does provide the <xref:System.Threading.Tasks.TaskCompletionSource%601?displayProperty=nameWithType> class, which can be used to represent any arbitrary set of operations as a <xref:System.Threading.Tasks.Task%601>. The operations may be synchronous or asynchronous, and may be I/O bound or compute-bound, or both.  
  
 The following example shows how to use a <xref:System.Threading.Tasks.TaskCompletionSource%601> to expose a set of asynchronous <xref:System.Net.WebClient> operations to client code as a basic <xref:System.Threading.Tasks.Task%601>. The method lets you enter an array of Web URLs, and a term or name to search for, and then returns the number of times the search term occurs on each site.  
  
 [!code-csharp[FromAsync#10](../../../samples/snippets/csharp/VS_Snippets_Misc/fromasync/cs/snippet10.cs#10)]
 [!code-vb[FromAsync#10](../../../samples/snippets/visualbasic/VS_Snippets_Misc/fromasync/vb/snippet10.vb#10)]  
  
 For a more complete example, which includes additional exception handling and shows how to call the method from client code, see [How to: Wrap EAP Patterns in a Task](../../../docs/standard/parallel-programming/how-to-wrap-eap-patterns-in-a-task.md).  
  
 Remember that any task that is created by a <xref:System.Threading.Tasks.TaskCompletionSource%601> will be started by that TaskCompletionSource and, therefore, user code should not call the Start method on that task.  
  
## Implementing the APM Pattern By Using Tasks  
 In some scenarios, it may be desirable to directly expose the <xref:System.IAsyncResult> pattern by using Begin/End method pairs in an API. For example, you may want to maintain consistency with existing APIs, or you may have automated tools that require this pattern. In such cases, you can use Tasks to simplify how the APM pattern is implemented internally.  
  
 The following example shows how to use tasks to implement an APM Begin/End method pair for a long-running compute-bound method.  
  
 [!code-csharp[FromAsync#09](../../../samples/snippets/csharp/VS_Snippets_Misc/fromasync/cs/fromasync.cs#09)]
 [!code-vb[FromAsync#09](../../../samples/snippets/visualbasic/VS_Snippets_Misc/fromasync/vb/module1.vb#09)]  
  
## Using the StreamExtensions Sample Code  
 The Streamextensions.cs file, in [Samples for Parallel Programming with the .NET Framework 4](https://code.msdn.microsoft.com/ParExtSamples), contains several reference implementations that use Task objects for asynchronous file and network I/O.  
  
## See Also  
 [Task Parallel Library (TPL)](../../../docs/standard/parallel-programming/task-parallel-library-tpl.md)
