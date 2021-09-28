---
description: "Learn more about: Blocking Application Execution Using an AsyncWaitHandle"
title: "Blocking Application Execution Using an AsyncWaitHandle"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "blocks, asynchronous operations"
  - "ending asynchronous operations"
  - "asynchronous programming, ending operations"
  - "asynchronous programming, blocking applications"
  - "stopping asynchronous operations"
  - "blocking application execution"
ms.topic: how-to
---
# Blocking Application Execution Using an AsyncWaitHandle

Applications that cannot continue to do other work while waiting for the results of an asynchronous operation must block until the operation completes. Use one of the following options to block your application's main thread while waiting for an asynchronous operation to complete:  
  
- Use the <xref:System.IAsyncResult.AsyncWaitHandle%2A> property of the <xref:System.IAsyncResult> returned by the asynchronous operation's **Begin**_OperationName_ method. This approach is demonstrated in this topic.  
  
- Call the asynchronous operation's **End**_OperationName_ method. For an example that demonstrates this approach, see [Blocking Application Execution by Ending an Async Operation](blocking-application-execution-by-ending-an-async-operation.md).  
  
 Applications that use one or more <xref:System.Threading.WaitHandle> objects to block until an asynchronous operation is complete will typically call the **Begin**_OperationName_ method, perform any work that can be done without the results of the operation, and then block until the asynchronous operation(s) completes. An application can block on a single operation by calling one of the <xref:System.Threading.WaitHandle.WaitOne%2A> methods using the <xref:System.IAsyncResult.AsyncWaitHandle%2A>. To block while waiting for a set of asynchronous operations to complete, store the associated <xref:System.IAsyncResult.AsyncWaitHandle%2A> objects in an array and call one of the <xref:System.Threading.WaitHandle.WaitAll%2A> methods. To block while waiting for any one of a set of asynchronous operations to complete, store the associated <xref:System.IAsyncResult.AsyncWaitHandle%2A> objects in an array and call one of the <xref:System.Threading.WaitHandle.WaitAny%2A> methods.  
  
## Example  

 The following code example demonstrates using asynchronous methods in the DNS class to retrieve Domain Name System information for a user-specified computer. The example demonstrates blocking using the <xref:System.Threading.WaitHandle> associated with the asynchronous operation. Note that `null` (`Nothing` in Visual Basic) is passed for the <xref:System.Net.Dns.BeginGetHostByName%2A>`requestCallback` and `stateObject` parameters because these are not required when using this approach.  
  
 [!code-csharp[AsyncDesignPattern#2](../../../samples/snippets/csharp/VS_Snippets_CLR/AsyncDesignPattern/CS/Async_EndBlockWait.cs#2)]
 [!code-vb[AsyncDesignPattern#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AsyncDesignPattern/VB/Async_EndBlockWait.vb#2)]  
  
## See also

- [Event-based Asynchronous Pattern (EAP)](event-based-asynchronous-pattern-eap.md)
- [Event-based Asynchronous Pattern Overview](event-based-asynchronous-pattern-overview.md)
