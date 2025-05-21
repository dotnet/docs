---
description: "Learn more about: Using Contracts in Workflow"
title: "Using Contracts in Workflow"
ms.date: "03/30/2017"
ms.assetid: 939c64e9-e7cc-4abc-b41e-27cfce1d7e50
ms.topic: concept-article
---
# Using Contracts in Workflow

When implementing a service, you define a number of contracts that describe the service and the data that it sends and receives. The data is represented as data contracts and message contracts; both WCF and workflow services use data contract and message contract definitions as part of service descriptions. The service itself exposes metadata (in the form of WSDL) in order to describe the operations of the service. In WCF, service contracts and operation contracts define the service and the operations it supports. However, in a workflow service, these contracts are part of the business process itself; they are exposed in metadata by a process called contract inference.  
  
## Contract Inference  

 When a workflow service is hosted using <xref:System.ServiceModel.Activities.WorkflowServiceHost>, the workflow definition is examined and a contract is generated based on the set of messaging activities found in the workflow. In particular the following activities and properties are used to generate the contract:  
  
 <xref:System.ServiceModel.Activities.Receive> Activity  
  
- <xref:System.ServiceModel.Activities.Receive.ServiceContractName%2A>  
  
- <xref:System.ServiceModel.Activities.Receive.OperationName%2A>
  
- <xref:System.ServiceModel.Activities.Receive.Action%2A>

 <xref:System.ServiceModel.Activities.SendReply> Activity  
  
- <xref:System.ServiceModel.Activities.SendReply.Action%2A>  
  
 <xref:System.ServiceModel.Activities.TransactedReceiveScope> Activity  
  
 The end result of contract inference is a description of the service using the same data structures as WCF service and operation contracts. This information is then used to expose WSDL for the workflow service.  
  
## See also

- [Workflow Services](workflow-services.md)
- [Messaging Activities](messaging-activities.md)
- [How to: Create a Workflow Service with Messaging Activities](how-to-create-a-workflow-service-with-messaging-activities.md)
- [How to: Create a workflow service that consumes an existing service contract](../../windows-workflow-foundation/how-to-create-a-workflow-service-that-consumes-an-existing-service-contract.md)
