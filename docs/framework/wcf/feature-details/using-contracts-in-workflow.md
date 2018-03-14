---
title: "Using Contracts in Workflow"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 939c64e9-e7cc-4abc-b41e-27cfce1d7e50
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using Contracts in Workflow
When implementing a service, you define a number of contracts that describe the service and the data that it sends and receives. The data is represented as data contracts and message contracts; both [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and workflow services use data contract and message contract definitions as part of service descriptions. The service itself exposes metadata (in the form of WSDL) in order to describe the operations of the service. In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], service contracts and operation contracts define the service and the operations it supports. However, in a workflow service, these contracts are part of the business process itself; they are exposed in metadata by a process called contract inference.  
  
## Contract Inference  
 When a workflow service is hosted using <xref:System.ServiceModel.Activities.WorkflowServiceHost>, the workflow definition is examined and a contract is generated based on the set of messaging activities found in the workflow. In particular the following activities and properties are used to generate the contract:  
  
 <xref:System.ServiceModel.Activities.Receive> Activity  
  
-   <xref:System.ServiceModel.Activities.Receive.ServiceContractName%2A>  
  
-   <xref:System.ServiceModel.Activities.Receive.OperationName%2A>
  
-   <xref:System.ServiceModel.Activities.Receive.Action%2A>   
 
 <xref:System.ServiceModel.Activities.SendReply> Activity  
  
-   <xref:System.ServiceModel.Activities.SendReply.Action%2A>  
  
 <xref:System.ServiceModel.Activities.TransactedReceiveScope> Activity  
  
 The end result of contract inference is a description of the service using the same data structures as WCF service and operation contracts. This information is then used to expose WSDL for the workflow service.  
  
## See Also  
 [Workflow Services](../../../../docs/framework/wcf/feature-details/workflow-services.md)  
 [Messaging Activities](../../../../docs/framework/wcf/feature-details/messaging-activities.md)  
 [How to: Create a Workflow Service with Messaging Activities](../../../../docs/framework/wcf/feature-details/how-to-create-a-workflow-service-with-messaging-activities.md)  
 [How to: Create a workflow service that consumes an existing service contract](../../../../docs/framework/windows-workflow-foundation/how-to-create-a-workflow-service-that-consumes-an-existing-service-contract.md)
