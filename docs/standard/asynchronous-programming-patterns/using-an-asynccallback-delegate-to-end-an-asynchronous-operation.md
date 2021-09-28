---
description: "Learn more about: Using an AsyncCallback Delegate to End an Asynchronous Operation"
title: "Using an AsyncCallback Delegate to End an Asynchronous Operation"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "ending asynchronous operations"
  - "asynchronous programming, ending operations"
  - "AsyncCallback delegate"
  - "stopping asynchronous operations"
ms.assetid: 9d97206c-8917-406c-8961-7d0909d84eeb
---
# Using an AsyncCallback Delegate to End an Asynchronous Operation

Applications that can do other work while waiting for the results of an asynchronous operation should not block waiting until the operation completes. Use one of the following options to continue executing instructions while waiting for an asynchronous operation to complete:  
  
- Use an <xref:System.AsyncCallback> delegate to process the results of the asynchronous operation in a separate thread. This approach is demonstrated in this topic.  
  
- Use the <xref:System.IAsyncResult.IsCompleted%2A> property of the <xref:System.IAsyncResult> returned by the asynchronous operation's **Begin**_OperationName_ method to determine whether the operation has completed. For an example that demonstrates this approach, see [Polling for the Status of an Asynchronous Operation](polling-for-the-status-of-an-asynchronous-operation.md).  
  
## Example  

 The following code example demonstrates using asynchronous methods in the <xref:System.Net.Dns> class to retrieve Domain Name System (DNS) information for user-specified computers. This example creates an <xref:System.AsyncCallback> delegate that references the `ProcessDnsInformation` method. This method is called once for each asynchronous request for DNS information.  
  
 Note that the user-specified host is passed to the <xref:System.Net.Dns.BeginGetHostByName%2A><xref:System.Object> parameter. For an example that demonstrates defining and using a more complex state object, see [Using an AsyncCallback Delegate and State Object](using-an-asynccallback-delegate-and-state-object.md).  
  
 [!code-csharp[AsyncDesignPattern#4](../../../samples/snippets/csharp/VS_Snippets_CLR/AsyncDesignPattern/CS/AsyncDelegateNoStateObject.cs#4)]
 [!code-vb[AsyncDesignPattern#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AsyncDesignPattern/VB/AsyncDelegateNoState.vb#4)]  
  
## See also

- [Event-based Asynchronous Pattern (EAP)](event-based-asynchronous-pattern-eap.md)
- [Event-based Asynchronous Pattern Overview](event-based-asynchronous-pattern-overview.md)
- [Calling Asynchronous Methods Using IAsyncResult](calling-asynchronous-methods-using-iasyncresult.md)
- [Using an AsyncCallback Delegate and State Object](using-an-asynccallback-delegate-and-state-object.md)
