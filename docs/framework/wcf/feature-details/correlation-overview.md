---
title: "Correlation Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: edcc0315-5d26-44d6-a36d-ea554c418e9f
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Correlation Overview
Correlation is the mechanism for relating workflow service messages to each other or to the application instance state, such as a reply to an initial request, or a particular order ID to the persisted state of an order-processing workflow. This topic provides an overview of correlation. The other topics in this section provide additional information for each type of correlation.  
  
## Types of Correlation  
 Correlation can be protocol-based or content-based. Protocol-based correlations use data provided by the message delivery infrastructure to provide the mapping between messages. Messages that are correlated using protocol-based correlation are related to each other using an object in memory, such as a <xref:System.ServiceModel.Channels.RequestContext>, or by a token provided by the transport protocol. Content-based correlations relate messages to each other using application-specified data. Messages that are correlated using content-based correlation are related to each other by some application-defined data in the message, such as a customer number.  
  
 Activities that participate in correlation use a <xref:System.ServiceModel.Activities.CorrelationHandle> to tie the messaging activities together. For example, a <xref:System.ServiceModel.Activities.Send> that is used to call a service and a subsequent <xref:System.ServiceModel.Activities.Receive> that is used to receive a callback from the service, share the same <xref:System.ServiceModel.Activities.CorrelationHandle>. This basic pattern is used whether the correlation is content based or protocol based. The correlation handle can be explicitly set on each activity or the activities can be contained in a <xref:System.ServiceModel.Activities.CorrelationScope> activity. Activities contained in a <xref:System.ServiceModel.Activities.CorrelationScope> have their correlation handles managed by the <xref:System.ServiceModel.Activities.CorrelationScope> and do not require the <xref:System.ServiceModel.Activities.CorrelationHandle> to be explicitly set. A <xref:System.ServiceModel.Activities.CorrelationScope> scope provides <xref:System.ServiceModel.Activities.CorrelationHandle> management for a request-reply correlation and one additional correlation type. Workflow services hosted using <xref:System.ServiceModel.Activities.WorkflowServiceHost> have the same default correlation management as the <xref:System.ServiceModel.Activities.CorrelationScope> activity. This default correlation management generally means that in many scenarios, messaging activities in a <xref:System.ServiceModel.Activities.CorrelationScope> or a workflow service do not require their <xref:System.ServiceModel.Activities.CorrelationHandle> set unless multiple messaging activities are in parallel or overlap, such as two <xref:System.ServiceModel.Activities.Receive> activities in parallel, or two <xref:System.ServiceModel.Activities.Send> activities followed by two <xref:System.ServiceModel.Activities.Receive> activities. More information about default correlation is provided in the topics in this section that cover each specific type of correlation. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] messaging activities see [Messaging Activities](../../../../docs/framework/wcf/feature-details/messaging-activities.md) and [How to: Create a Workflow Service with Messaging Activities](../../../../docs/framework/wcf/feature-details/how-to-create-a-workflow-service-with-messaging-activities.md).  
  
## Protocol-Based Correlation  
 Protocol-based correlation uses the transport mechanism to relate messages to each other and the appropriate instance. Some system-provided protocol correlations include request-reply correlation and context-based correlation. A request-reply correlation is used to correlate a single pair of messaging activities to form a two-way operation, such as a <xref:System.ServiceModel.Activities.Send> paired with a <xref:System.ServiceModel.Activities.ReceiveReply>, or a <xref:System.ServiceModel.Activities.Receive> paired with a <xref:System.ServiceModel.Activities.SendReply>. The [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] Workflow Designer also provides a set of activity templates to quickly implement this pattern. A context-based correlation is based on the context exchange mechanism described in the [.NET Context Exchange Protocol Specification](http://go.microsoft.com/fwlink/?LinkID=166059). To use context-based correlation, a context-based binding such as <xref:System.ServiceModel.BasicHttpContextBinding>, <xref:System.ServiceModel.WSHttpContextBinding> or <xref:System.ServiceModel.NetTcpContextBinding> must be used on the endpoint.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] protocol correlation, see [Context Exchange](../../../../docs/framework/wcf/feature-details/context-exchange-correlation.md), [Durable Duplex](../../../../docs/framework/wcf/feature-details/durable-duplex-correlation.md), and [Request-Reply](../../../../docs/framework/wcf/feature-details/request-reply-correlation.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] using the [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] Workflow Designer activity templates, see [Messaging Activities](../../../../docs/framework/wcf/feature-details/messaging-activities.md). For sample code, see the [Durable Duplex &#91;WF Samples&#93;](../../../../docs/framework/windows-workflow-foundation/samples/durable-duplex.md) and [NetContextExchangeCorrelation](http://msdn.microsoft.com/library/93c74a1a-b9e2-46c6-95c0-c9b0e9472caf) samples.  
  
## Content-Based Correlation  
 Content-based correlation uses some piece of information in the message to associate it to a particular instance. Unlike protocol-based correlation, content-based correlation requires the application author to explicitly state where this data can be found in each related message. Activities that use content-based correlation specify this message data by using a <xref:System.ServiceModel.MessageQuerySet>. Content-based correlation is useful when communicating with services that do not use one of the context bindings such as <xref:System.ServiceModel.BasicHttpContextBinding>. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] content-based correlation, see [Content Based](../../../../docs/framework/wcf/feature-details/content-based-correlation.md). For sample code, see the [Content-Based Correlation](../../../../docs/framework/windows-workflow-foundation/samples/content-based-correlation.md) and [Correlated Calculator](../../../../docs/framework/windows-workflow-foundation/samples/correlated-calculator.md) samples.  
  
## See Also  
 [Content-Based Correlation](../../../../docs/framework/windows-workflow-foundation/samples/content-based-correlation.md)  
 [Correlated Calculator](../../../../docs/framework/windows-workflow-foundation/samples/correlated-calculator.md)  
 [Durable Duplex &#91;WF Samples&#93;](../../../../docs/framework/windows-workflow-foundation/samples/durable-duplex.md)  
 [NetContextExchangeCorrelation](http://msdn.microsoft.com/library/93c74a1a-b9e2-46c6-95c0-c9b0e9472caf)
