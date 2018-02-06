---
title: "Calling Synchronous Methods Asynchronously"
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
  - "cpp"
helpviewer_keywords: 
  - "asynchronous programming, delegates"
  - "asynchronous delegates"
  - "AsyncWaitHandle property"
  - "callback methods"
  - "calling synchronous methods in asynchronous manner"
  - "WaitHandle class, code examples"
  - "asynchronous programming, status polling"
  - "polling asynchronous operation status"
  - "delegates [.NET Framework], asynchronous"
  - "synchronous calling in asynchronous manner"
  - "waiting for asynchronous calls"
  - "status information [.NET Framework], asynchronous operations"
ms.assetid: 41972034-92ed-450a-9664-ab93fcc6f1fb
caps.latest.revision: 24
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Calling Synchronous Methods Asynchronously
The .NET Framework enables you to call any method asynchronously. To do this you define a delegate with the same signature as the method you want to call; the common language runtime automatically defines `BeginInvoke` and `EndInvoke` methods for this delegate, with the appropriate signatures.  
  
> [!NOTE]
>  Asynchronous delegate calls, specifically the `BeginInvoke` and `EndInvoke` methods, are not supported in the .NET Compact Framework.  
  
 The `BeginInvoke` method initiates the asynchronous call. It has the same parameters as the method that you want to execute asynchronously, plus two additional optional parameters. The first parameter is an <xref:System.AsyncCallback> delegate that references a method to be called when the asynchronous call completes. The second parameter is a user-defined object that passes information into the callback method. `BeginInvoke` returns immediately and does not wait for the asynchronous call to complete. `BeginInvoke` returns an <xref:System.IAsyncResult>, which can be used to monitor the progress of the asynchronous call.  
  
 The `EndInvoke` method retrieves the results of the asynchronous call. It can be called any time after `BeginInvoke`. If the asynchronous call has not completed, `EndInvoke` blocks the calling thread until it completes. The parameters of `EndInvoke` include the `out` and `ref` parameters (`<Out>` `ByRef` and `ByRef` in Visual Basic) of the method that you want to execute asynchronously, plus the <xref:System.IAsyncResult> returned by `BeginInvoke`.  
  
> [!NOTE]
>  The IntelliSense feature in [!INCLUDE[vsprvslong](../../../includes/vsprvslong-md.md)] displays the parameters of `BeginInvoke` and `EndInvoke`. If you are not using Visual Studio or a similar tool, or if you are using C# with [!INCLUDE[vsprvslong](../../../includes/vsprvslong-md.md)], see [Asynchronous Programming Model (APM)](../../../docs/standard/asynchronous-programming-patterns/asynchronous-programming-model-apm.md) for a description of the parameters defined for these methods.  
  
 The code examples in this topic demonstrate four common ways to use `BeginInvoke` and `EndInvoke` to make asynchronous calls. After calling `BeginInvoke` you can do the following:  
  
-   Do some work and then call `EndInvoke` to block until the call completes.  
  
-   Obtain a <xref:System.Threading.WaitHandle> using the <xref:System.IAsyncResult.AsyncWaitHandle%2A?displayProperty=nameWithType> property, use its <xref:System.Threading.WaitHandle.WaitOne%2A> method to block execution until the <xref:System.Threading.WaitHandle> is signaled, and then call `EndInvoke`.  
  
-   Poll the <xref:System.IAsyncResult> returned by `BeginInvoke` to determine when the asynchronous call has completed, and then call `EndInvoke`.  
  
-   Pass a delegate for a callback method to `BeginInvoke`. The method is executed on a <xref:System.Threading.ThreadPool> thread when the asynchronous call completes. The callback method calls `EndInvoke`.  
  
> [!IMPORTANT]
>  No matter which technique you use, always call `EndInvoke` to complete your asynchronous call.  
  
## Defining the Test Method and Asynchronous Delegate  
 The code examples that follow demonstrate various ways of calling the same long-running method, `TestMethod`, asynchronously. The `TestMethod` method displays a console message to show that it has begun processing, sleeps for a few seconds, and then ends. `TestMethod` has an `out` parameter to demonstrate the way such parameters are added to the signatures of `BeginInvoke` and `EndInvoke`. You can handle `ref` parameters similarly.  
  
 The following code example shows the definition of `TestMethod` and the delegate named `AsyncMethodCaller` that can be used to call `TestMethod` asynchronously. To compile the code examples, you must include the definitions for `TestMethod` and the `AsyncMethodCaller` delegate.  
  
 [!code-cpp[AsyncDelegateExamples#1](../../../samples/snippets/cpp/VS_Snippets_CLR/AsyncDelegateExamples/cpp/TestMethod.cpp#1)]
 [!code-csharp[AsyncDelegateExamples#1](../../../samples/snippets/csharp/VS_Snippets_CLR/AsyncDelegateExamples/CS/TestMethod.cs#1)]
 [!code-vb[AsyncDelegateExamples#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AsyncDelegateExamples/VB/TestMethod.vb#1)]  
  
## Waiting for an Asynchronous Call with EndInvoke  
 The simplest way to execute a method asynchronously is to start executing the method by calling the delegate's `BeginInvoke` method, do some work on the main thread, and then call the delegate's `EndInvoke` method. `EndInvoke` might block the calling thread because it does not return until the asynchronous call completes. This is a good technique to use with file or network operations.  
  
> [!IMPORTANT]
>  Because `EndInvoke` might block, you should never call it from threads that service the user interface.  
  
 [!code-cpp[AsyncDelegateExamples#2](../../../samples/snippets/cpp/VS_Snippets_CLR/AsyncDelegateExamples/cpp/EndInvoke.cpp#2)]
 [!code-csharp[AsyncDelegateExamples#2](../../../samples/snippets/csharp/VS_Snippets_CLR/AsyncDelegateExamples/CS/EndInvoke.cs#2)]
 [!code-vb[AsyncDelegateExamples#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AsyncDelegateExamples/VB/EndInvoke.vb#2)]  
  
## Waiting for an Asynchronous Call with WaitHandle  
 You can obtain a <xref:System.Threading.WaitHandle> by using the <xref:System.IAsyncResult.AsyncWaitHandle%2A> property of the <xref:System.IAsyncResult> returned by `BeginInvoke`. The <xref:System.Threading.WaitHandle> is signaled when the asynchronous call completes, and you can wait for it by calling the <xref:System.Threading.WaitHandle.WaitOne%2A> method.  
  
 If you use a <xref:System.Threading.WaitHandle>, you can perform additional processing before or after the asynchronous call completes, but before calling `EndInvoke` to retrieve the results.  
  
> [!NOTE]
>  The wait handle is not closed automatically when you call `EndInvoke`. If you release all references to the wait handle, system resources are freed when garbage collection reclaims the wait handle. To free the system resources as soon as you are finished using the wait handle, dispose of it by calling the <xref:System.Threading.WaitHandle.Close%2A?displayProperty=nameWithType> method. Garbage collection works more efficiently when disposable objects are explicitly disposed.  
  
 [!code-cpp[AsyncDelegateExamples#3](../../../samples/snippets/cpp/VS_Snippets_CLR/AsyncDelegateExamples/cpp/waithandle.cpp#3)]
 [!code-csharp[AsyncDelegateExamples#3](../../../samples/snippets/csharp/VS_Snippets_CLR/AsyncDelegateExamples/CS/waithandle.cs#3)]
 [!code-vb[AsyncDelegateExamples#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AsyncDelegateExamples/VB/WaitHandle.vb#3)]  
  
## Polling for Asynchronous Call Completion  
 You can use the <xref:System.IAsyncResult.IsCompleted%2A> property of the <xref:System.IAsyncResult> returned by `BeginInvoke` to discover when the asynchronous call completes. You might do this when making the asynchronous call from a thread that services the user interface. Polling for completion allows the calling thread to continue executing while the asynchronous call executes on a <xref:System.Threading.ThreadPool> thread.  
  
 [!code-cpp[AsyncDelegateExamples#4](../../../samples/snippets/cpp/VS_Snippets_CLR/AsyncDelegateExamples/cpp/polling.cpp#4)]
 [!code-csharp[AsyncDelegateExamples#4](../../../samples/snippets/csharp/VS_Snippets_CLR/AsyncDelegateExamples/CS/polling.cs#4)]
 [!code-vb[AsyncDelegateExamples#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AsyncDelegateExamples/VB/polling.vb#4)]  
  
## Executing a Callback Method When an Asynchronous Call Completes  
 If the thread that initiates the asynchronous call does not need to be the thread that processes the results, you can execute a callback method when the call completes. The callback method is executed on a <xref:System.Threading.ThreadPool> thread.  
  
 To use a callback method, you must pass `BeginInvoke` an <xref:System.AsyncCallback> delegate that represents the callback method. You can also pass an object that contains information to be used by the callback method. In the callback method, you can cast the <xref:System.IAsyncResult>, which is the only parameter of the callback method, to an <xref:System.Runtime.Remoting.Messaging.AsyncResult> object. You can then use the <xref:System.Runtime.Remoting.Messaging.AsyncResult.AsyncDelegate%2A?displayProperty=nameWithType> property to get the delegate that was used to initiate the call so that you can call `EndInvoke`.  
  
 Notes on the example:  
  
-   The `threadId` parameter of `TestMethod` is an `out` parameter ([`<Out>` `ByRef` in Visual Basic), so its input value is never used by `TestMethod`. A dummy variable is passed to the `BeginInvoke` call. If the `threadId` parameter were a `ref` parameter (`ByRef` in Visual Basic), the variable would have to be a class-level field so that it could be passed to both `BeginInvoke` and `EndInvoke`.  
  
-   The state information that is passed to `BeginInvoke` is a format string, which the callback method uses to format an output message. Because it is passed as type <xref:System.Object>, the state information must be cast to its proper type before it can be used.  
  
-   The callback is made on a <xref:System.Threading.ThreadPool> thread. <xref:System.Threading.ThreadPool> threads are background threads, which do not keep the application running if the main thread ends, so the main thread of the example has to sleep long enough for the callback to finish.  
  
 [!code-cpp[AsyncDelegateExamples#5](../../../samples/snippets/cpp/VS_Snippets_CLR/AsyncDelegateExamples/cpp/callback.cpp#5)]
 [!code-csharp[AsyncDelegateExamples#5](../../../samples/snippets/csharp/VS_Snippets_CLR/AsyncDelegateExamples/CS/callback.cs#5)]
 [!code-vb[AsyncDelegateExamples#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AsyncDelegateExamples/VB/callback.vb#5)]  
  
## See Also  
 <xref:System.Delegate>  
 [Event-based Asynchronous Pattern (EAP)](../../../docs/standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-eap.md)
