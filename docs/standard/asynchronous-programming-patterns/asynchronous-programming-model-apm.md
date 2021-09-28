---
title: "Asynchronous Programming Model (APM)"
description: Learn about the Asynchronous Programming Model (APM) in .NET. Discover how to begin and end an asynchronous operation.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "ending asynchronous operations"
  - "starting asynchronous operations"
  - "beginning asynchronous operations"
  - "asynchronous programming, ending operations"
  - "asynchronous programming"
  - "stopping asynchronous operations"
  - "asynchronous programming, beginning operations"
ms.assetid: c9b3501e-6bc6-40f9-8efd-4b6d9e39ccf0
---
# Asynchronous Programming Model (APM)

An asynchronous operation that uses the <xref:System.IAsyncResult> design pattern is implemented as two methods named `BeginOperationName` and `EndOperationName` that begin and end the asynchronous operation *OperationName* respectively. For example, the <xref:System.IO.FileStream> class provides the <xref:System.IO.FileStream.BeginRead%2A> and <xref:System.IO.FileStream.EndRead%2A> methods to asynchronously read bytes from a file. These methods implement the asynchronous version of the <xref:System.IO.FileStream.Read%2A> method.  
  
> [!NOTE]
> Starting with the .NET Framework 4, the Task Parallel Library provides a new model for asynchronous and parallel programming. For more information, see [Task Parallel Library (TPL)](../parallel-programming/task-parallel-library-tpl.md) and [Task-based Asynchronous Pattern (TAP)](task-based-asynchronous-pattern-tap.md)).  
  
 After calling `BeginOperationName`, an application can continue executing instructions on the calling thread while the asynchronous operation takes place on a different thread. For each call to `BeginOperationName`, the application should also call `EndOperationName` to get the results of the operation.  
  
## Beginning an Asynchronous Operation  

 The `BeginOperationName` method begins asynchronous operation *OperationName* and returns an object that implements the <xref:System.IAsyncResult> interface. <xref:System.IAsyncResult> objects store information about an asynchronous operation. The following table shows information about an asynchronous operation.  
  
|Member|Description|  
|------------|-----------------|  
|<xref:System.IAsyncResult.AsyncState%2A>|An optional application-specific object that contains information about the asynchronous operation.|  
|<xref:System.IAsyncResult.AsyncWaitHandle%2A>|A <xref:System.Threading.WaitHandle> that can be used to block application execution until the asynchronous operation completes.|  
|<xref:System.IAsyncResult.CompletedSynchronously%2A>|A value that indicates whether the asynchronous operation completed on the thread used to call `BeginOperationName` instead of completing on a separate <xref:System.Threading.ThreadPool> thread.|  
|<xref:System.IAsyncResult.IsCompleted%2A>|A value that indicates whether the asynchronous operation has completed.|  
  
 A `BeginOperationName` method takes any parameters declared in the signature of the synchronous version of the method that are passed by value or by reference. Any out parameters are not part of the `BeginOperationName` method signature. The `BeginOperationName` method signature also includes two additional parameters. The first of these defines an <xref:System.AsyncCallback> delegate that references a method that is called when the asynchronous operation completes. The caller can specify `null` (`Nothing` in Visual Basic) if it does not want a method invoked when the operation completes. The second additional parameter is a user-defined object. This object can be used to pass application-specific state information to the method invoked when the asynchronous operation completes. If a `BeginOperationName` method takes additional operation-specific parameters, such as a byte array to store bytes read from a file, the <xref:System.AsyncCallback> and application state object are the last parameters in the `BeginOperationName` method signature.  
  
 `BeginOperationName` returns control to the calling thread immediately. If the `BeginOperationName` method throws exceptions, the exceptions are thrown before the asynchronous operation is started. If the `BeginOperationName` method throws exceptions, the callback method is not invoked.  
  
## Ending an Asynchronous Operation  

 The `EndOperationName` method ends asynchronous operation *OperationName*. The return value of the `EndOperationName` method is the same type returned by its synchronous counterpart and is specific to the asynchronous operation. For example, the <xref:System.IO.FileStream.EndRead%2A> method returns the number of bytes read from a <xref:System.IO.FileStream> and the <xref:System.Net.Dns.EndGetHostByName%2A> method returns an <xref:System.Net.IPHostEntry> object that contains information about a host computer. The `EndOperationName` method takes any out or ref parameters declared in the signature of the synchronous version of the method. In addition to the parameters from the synchronous method, the `EndOperationName` method also includes an <xref:System.IAsyncResult> parameter. Callers must pass the instance returned by the corresponding call to `BeginOperationName`.  
  
 If the asynchronous operation represented by the <xref:System.IAsyncResult> object has not completed when `EndOperationName` is called, `EndOperationName` blocks the calling thread until the asynchronous operation is complete. Exceptions thrown by the asynchronous operation are thrown from the `EndOperationName` method. The effect of calling the `EndOperationName` method multiple times with the same <xref:System.IAsyncResult> is not defined. Likewise, calling the `EndOperationName` method with an <xref:System.IAsyncResult> that was not returned by the related Begin method is also not defined.  
  
> [!NOTE]
> For either of the undefined scenarios, implementers should consider throwing <xref:System.InvalidOperationException>.  
  
> [!NOTE]
> Implementers of this design pattern should notify the caller that the asynchronous operation completed by setting <xref:System.IAsyncResult.IsCompleted%2A> to true, calling the asynchronous callback method (if one was specified) and signaling the <xref:System.IAsyncResult.AsyncWaitHandle%2A>.  
  
 Application developers have several design choices for accessing the results of the asynchronous operation. The correct choice depends on whether the application has instructions that can execute while the operation completes. If an application cannot perform any additional work until it receives the results of the asynchronous operation, the application must block until the results are available. To block until an asynchronous operation completes, you can use one of the following approaches:  
  
- Call `EndOperationName` from the application’s main thread, blocking application execution until the operation is complete. For an example that illustrates this technique, see [Blocking Application Execution by Ending an Async Operation](blocking-application-execution-by-ending-an-async-operation.md).  
  
- Use the <xref:System.IAsyncResult.AsyncWaitHandle%2A> to block application execution until one or more operations are complete. For an example that illustrates this technique, see [Blocking Application Execution Using an AsyncWaitHandle](blocking-application-execution-using-an-asyncwaithandle.md).  
  
 Applications that do not need to block while the asynchronous operation completes can use one of the following approaches:  
  
- Poll for operation completion status by checking the <xref:System.IAsyncResult.IsCompleted%2A> property periodically and calling `EndOperationName` when the operation is complete. For an example that illustrates this technique, see [Polling for the Status of an Asynchronous Operation](polling-for-the-status-of-an-asynchronous-operation.md).  
  
- Use an <xref:System.AsyncCallback> delegate to specify a method to be invoked when the operation is complete. For an example that illustrates this technique, see [Using an AsyncCallback Delegate to End an Asynchronous Operation](using-an-asynccallback-delegate-to-end-an-asynchronous-operation.md).  
  
## See also

- [Event-based Asynchronous Pattern (EAP)](event-based-asynchronous-pattern-eap.md)
- [Calling Synchronous Methods Asynchronously](calling-synchronous-methods-asynchronously.md)
- [Using an AsyncCallback Delegate and State Object](using-an-asynccallback-delegate-and-state-object.md)
