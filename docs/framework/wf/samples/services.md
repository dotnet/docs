---
title: "Services (Windows Workflow) | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b0f821ba-a6f1-4c87-adbd-4d7c2a2a9fa6
caps.latest.revision: 5
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# Services (Windows Workflow)
This section contains samples that demonstrate scenarios using workflow services.  
  
## In This Section  
 [OperationScope](../../../../docs/framework/wf/samples/operationscope.md)  
 Demonstrates how the messaging activities, <xref:System.ServiceModel.Activities.Receive> and <xref:System.ServiceModel.Activities.SendReply> can be used to expose an existing custom activity as an operation in a workflow service.  
  
 [Accessing OperationContext](../../../../docs/framework/wf/samples/accessing-operationcontext.md)  
 Demonstrates how the messaging activities (<xref:System.ServiceModel.Activities.Receive> and <xref:System.ServiceModel.Activities.Send>) can be used with a custom scope activity to access <xref:System.ServiceModel.OperationContext.Current%2A> and attach or retrieve a custom message header within an outgoing or incoming message.  
  
 [LINQ Message Query Correlation](../../../../docs/framework/wf/samples/linq-message-query-correlation.md)  
 Demonstrates how to do content-based correlation using a custom <xref:System.ServiceModel.Dispatcher.MessageQuery> implementation as opposed to the system-provided <xref:System.ServiceModel.XPathMessageQuery>.  
  
 [Correlated Calculator](../../../../docs/framework/wf/samples/correlated-calculator.md)  
 Demonstrates how to use the messaging activities (<xref:System.ServiceModel.Activities.Receive> and <xref:System.ServiceModel.Activities.SendReply>) in the designer with content-based correlation based on a parameter in the message.  
  
 [Securing Workflow Services](../../../../docs/framework/wf/samples/securing-workflow-services.md)  
 Demonstrates creating a basic workflow service using the <xref:System.ServiceModel.Activities.Receive> and <xref:System.ServiceModel.Activities.SendReply> activities, and using [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] configuration to define secure endpoints for use by the workflow service.  
  
 [Asynchronous Communication](../../../../docs/framework/wf/samples/asynchronous-communication.md)  
 Demonstrates how the communication between two different [!INCLUDE[wf](../../../../includes/wf-md.md)] services is done asynchronously by default.