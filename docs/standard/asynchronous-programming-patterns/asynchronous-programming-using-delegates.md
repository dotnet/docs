---
description: "Learn more about: Asynchronous Programming Using Delegates"
title: "Asynchronous Programming Using Delegates"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "BeginInvoke method"
  - "asynchronous programming, delegates"
  - "asynchronous delegates"
  - "calling synchronous methods in asynchronous manner"
  - "EndInvoke method"
  - "calling asynchronous methods"
  - "delegates [.NET], asynchronous"
  - "synchronous calling in asynchronous manner"
ms.assetid: 38a345ca-6963-4436-9608-5c9defef9c64
---
# Asynchronous Programming Using Delegates

Delegates enable you to call a synchronous method in an asynchronous manner. When you call a delegate synchronously, the `Invoke` method calls the target method directly on the current thread. If the `BeginInvoke` method is called, the common language runtime (CLR) queues the request and returns immediately to the caller. The target method is called asynchronously on a thread from the thread pool. The original thread, which submitted the request, is free to continue executing in parallel with the target method. If a callback method has been specified in the call to the `BeginInvoke` method, the callback method is called when the target method ends. In the callback method, the `EndInvoke` method obtains the return value and any input/output or output-only parameters. If no callback method is specified when calling `BeginInvoke`, `EndInvoke` can be called from the thread that called `BeginInvoke`.  
  
> [!IMPORTANT]
> Compilers should emit delegate classes with `Invoke`, `BeginInvoke`, and `EndInvoke` methods using the delegate signature specified by the user. The `BeginInvoke` and `EndInvoke` methods should be decorated as native. Because these methods are marked as native, the CLR automatically provides the implementation at class load time. The loader ensures that they are not overridden.  
  
## In This Section  

 [Calling Synchronous Methods Asynchronously](calling-synchronous-methods-asynchronously.md)  
 Discusses the use of delegates to make asynchronous calls to ordinary methods, and provides simple code examples that show the four ways to wait for an asynchronous call to return.  
  
## Related Sections  

 [Event-based Asynchronous Pattern (EAP)](event-based-asynchronous-pattern-eap.md)  
 Describes asynchronous programming in .NET.  
  
## See also

- <xref:System.Delegate>
