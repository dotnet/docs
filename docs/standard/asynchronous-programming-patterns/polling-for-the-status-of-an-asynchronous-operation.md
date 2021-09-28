---
description: "Learn more about: Polling for the Status of an Asynchronous Operation"
title: "Polling for the Status of an Asynchronous Operation"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "asynchronous programming, status polling"
  - "polling asynchronous operation status"
  - "status information [.NET], asynchronous operations"
ms.assetid: b541af31-dacb-4e20-8847-1b1ff7c35363
---
# Polling for the Status of an Asynchronous Operation

Applications that can do other work while waiting for the results of an asynchronous operation should not block waiting until the operation completes. Use one of the following options to continue executing instructions while waiting for an asynchronous operation to complete:  
  
- Use the <xref:System.IAsyncResult.IsCompleted%2A> property of the <xref:System.IAsyncResult> returned by the asynchronous operation's **Begin**_OperationName_ method to determine whether the operation has completed. This approach is known as polling and is demonstrated in this topic.  
  
- Use an <xref:System.AsyncCallback> delegate to process the results of the asynchronous operation in a separate thread. For an example that demonstrates this approach, see [Using an AsyncCallback Delegate to End an Asynchronous Operation](using-an-asynccallback-delegate-to-end-an-asynchronous-operation.md).  
  
## Example  

 The following code example demonstrates using asynchronous methods in the <xref:System.Net.Dns> class to retrieve Domain Name System information for a user-specified computer. This example starts the asynchronous operation and then prints periods (".") at the console until the operation is complete. Note that **null** (**Nothing** in Visual Basic) is passed for the <xref:System.Net.Dns.BeginGetHostByName%2A><xref:System.AsyncCallback> and <xref:System.Object> parameters because these arguments are not required when using this approach.  
  
 [!code-csharp[AsyncDesignPattern#3](../../../samples/snippets/csharp/VS_Snippets_CLR/AsyncDesignPattern/CS/Async_Poll.cs#3)]
 [!code-vb[AsyncDesignPattern#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AsyncDesignPattern/VB/Async_Poll.vb#3)]  
  
## See also

- [Event-based Asynchronous Pattern (EAP)](event-based-asynchronous-pattern-eap.md)
- [Event-based Asynchronous Pattern Overview](event-based-asynchronous-pattern-overview.md)
