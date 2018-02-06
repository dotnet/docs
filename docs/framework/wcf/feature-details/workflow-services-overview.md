---
title: "Workflow Services Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e536dda3-e286-441e-99a7-49ddc004b646
caps.latest.revision: 30
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Workflow Services Overview
Workflow services are [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]-based services that are implemented using workflows. Workflow services are workflows that use the messaging activities to send and receive [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] messages. .NET Framework 4.5 introduces a number of messaging activities that allow you send and receive messages from within a workflow. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] messaging activities and how they can be used to implement different message exchange patterns, see [Messaging Activities](../../../../docs/framework/wcf/feature-details/messaging-activities.md).  
  
## Benefits of Using Workflow Services  
 As applications become increasingly distributed, individual services become responsible for calling other services to offload some of the work. Implementing these calls as asynchronous operations introduces some complexity into the code. Error handling adds additional complexity in the form of handling exceptions and providing detailed tracking information. Some services are often long running and can take up valuable system resources while waiting for input. Because of these issues, distributed applications are often very complex and difficult to write and maintain. Workflows are a natural way to express the coordination of asynchronous work, especially calls to external services. Workflows are also effective at representing long-running business processes. It is these qualities that make the workflow a great asset to building services in a distributed environment.  
  
## Implementing a Workflow Service  
 When implementing a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service, you define a number of contracts that describe the service and the data that it sends and receives. The data is represented as data contracts and message contracts. Both WCF and workflow services use data contract and message contract definitions as part of service descriptions. The service itself exposes metadata (in the form of WSDL) to describe the operations of the service. In WCF, service contracts and operation contracts define the service and the operations it supports. However in a workflow service, these contracts are part of the business process itself. They are exposed in metadata by a process called contract inference. When a workflow service is hosted using <xref:System.ServiceModel.Activities.WorkflowServiceHost>, the workflow definition is examined and a contract is generated based on the set of messaging activities found in the workflow. In particular, the following activities and properties are used to generate the contract:  
  
 <xref:System.ServiceModel.Activities.Receive> Activity  
  
-   <xref:System.ServiceModel.Activities.Receive.ServiceContractName%2A>  
  
-   <!--zz <xref:System.ServiceModel.Activities.Receive.OperationContractName%2A>  --> `System.ServiceModel.Activities.Receive.OperationContractName`
  
-   <xref:System.ServiceModel.Activities.Receive.Action%2A>  
  
-   <!--zz <xref:System.ServiceModel.Activities.Receive.ValueType%2A>  --> `System.ServiceModel.Activities.Receive.ValueType`
  
 <xref:System.ServiceModel.Activities.SendReply> Activity  
  
-   <xref:System.ServiceModel.Activities.SendReply.Action%2A>  
  
-   <!--zz <xref:System.ServiceModel.Activities.SendReply.ValueType%2A> -->
`xref:System.ServiceModel.Activities.SendReply.ValueType`
  
 <xref:System.ServiceModel.Activities.TransactedReceiveScope> Activity  
  
 The end result of contract inference is a description of the service using the same data structures as [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services and operation contracts. This information is then used to expose WSDL for the workflow service.  
  
> [!NOTE]
>  [!INCLUDE[netfx_current_short](../../../../includes/netfx-current-short-md.md)] does not allow you to write workflow services using an existing contract definition without some additional tooling support. Workflow service contracts are created by the contract inference process discussed previously. Message contracts and data contracts are fully supported, however.  
  
## Workflow Services and MSMQ-Based Bindings  
 WCF defines two MSMQ-based bindings <xref:System.ServiceModel.NetMsmqBinding> and <xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding>.  MSMQ-based bindings are often used with workflow services because of the long-running nature of such services. The MSMQ-based bindings have a `ValidityDuration` property that specifies how long MSMQ messages can assume to be valid. Because of the long running nature of workflow services it is possible that the validity duration of a MSMQ message may elapse before the workflow service can process it. It is therefore very important to set the validity duration of a MSMQ binding to an appropriate value. This value must be chosen based on the workflow and how it processes messages. For example if you have a workflow with a <xref:System.ServiceModel.Activities.Receive> activity followed by a custom activity that takes 10 minutes to run, followed by another <xref:System.ServiceModel.Activities.Receive> activity, the correct value for `ValidityDuration` would be greater than 10 minutes.  
  
## Hosting a Workflow Service  
 Like [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services, workflow services must be hosted. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services use the <xref:System.ServiceModel.ServiceHost> class to host services and workflow services use <xref:System.ServiceModel.Activities.WorkflowServiceHost> to host services. Like [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services, workflow services can be hosted in a variety of ways, for example:  
  
-   In a managed [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] application.  
  
-   In Internet Information Services (IIS).  
  
-   In Windows Process Activation Service (WAS).  
  
-   In a managed Windows Service.  
  
 Workflow services hosted in a managed [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] application or a managed Windows service create an instance of the <xref:System.ServiceModel.Activities.WorkflowServiceHost> class and pass it an instance of the <xref:System.ServiceModel.Activities.WorkflowService> that contains the workflow definition within the <xref:System.ServiceModel.Activities.WorkflowService.Body%2A> property. A workflow definition that contains messaging activities is exposed as a workflow service.  
  
 To host a workflow service in IIS or WAS, place the .xamlx file that contains the workflow service definition into a virtual directory. A default endpoint (using <xref:System.ServiceModel.BasicHttpBinding>) is created automatically [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Simplified Configuration](../../../../docs/framework/wcf/simplified-configuration.md). You can also place a Web.config file in the virtual directory to specify your own endpoints. If your workflow definition is in an assembly you can place a .svc file in the virtual directory and the workflow assembly in the App_Code directory. The .svc file must specify the service host factory and the class that implements the workflow service. The following example shows how to specify the service host factory and specify the class that implements the workflow service.  
  
```  
<%@ServiceHost Factory=" System.ServiceModel.Activities.Activation.WorkflowServiceHostFactory  
Service="EchoService"%>  
```
