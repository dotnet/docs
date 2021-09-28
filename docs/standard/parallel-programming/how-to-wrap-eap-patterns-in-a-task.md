---
description: "Learn more about: How to: Wrap EAP Patterns in a Task"
title: "How to: Wrap EAP Patterns in a Task"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "tasks, how to wrap EAP patterns"
ms.assetid: f11ed467-af2f-4504-8a2e-299a6c36d44e
---
# How to: Wrap EAP Patterns in a Task

The following example shows how to expose an arbitrary sequence of Event-Based Asynchronous Pattern (EAP) operations as one task by using a <xref:System.Threading.Tasks.TaskCompletionSource%601>. The example also shows how to use a <xref:System.Threading.CancellationToken> to invoke the built-in cancellation methods on the <xref:System.Net.WebClient> objects.  
  
## Example  

 [!code-csharp[FromAsync#08](../../../samples/snippets/csharp/VS_Snippets_Misc/fromasync/cs/fromasync.cs#08)]
 [!code-vb[FromAsync#08](../../../samples/snippets/visualbasic/VS_Snippets_Misc/fromasync/vb/module1.vb#08)]  
  
## See also

- [TPL and Traditional .NET Asynchronous Programming](tpl-and-traditional-async-programming.md)
