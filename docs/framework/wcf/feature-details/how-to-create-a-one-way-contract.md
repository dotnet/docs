---
description: "Learn more about: How to: Create a One-Way Contract"
title: "How to: Create a One-Way Contract"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 85084cd9-31cc-4e95-b667-42ef01336622
---
# How to: Create a One-Way Contract

This topic shows the basic steps to create methods that use a one-way contract. Such methods invoke operations on a Windows Communication Foundation (WCF) service from a client but do not expect a reply. This type of contract can be used, for example, to publish notifications to many subscribers. You can also use one-way contracts when creating a duplex (two-way) contract, which allows clients and servers to communicate with each other independently so that either can initiate calls to the other. This can allow, in particular, the server to make one-way calls to the client that the client can treat as events. For detailed information about specifying one-way methods, see the <xref:System.ServiceModel.OperationContractAttribute.IsOneWay%2A> property and the <xref:System.ServiceModel.OperationContractAttribute> class.  
  
 For more information about creating a client application for a duplex contract, see [How to: Access Services with One-Way and Request-Reply Contracts](how-to-access-wcf-services-with-one-way-and-request-reply-contracts.md). For a working sample, see the [One-Way](/previous-versions/dotnet/framework/wcf/samples/one-way) sample.  
  
### To create a one-way contract  
  
1. Create the service contract by applying the <xref:System.ServiceModel.ServiceContractAttribute> class to the interface that defines the methods the service is to implement.  
  
2. Indicate which methods in the interface a client can invoked by applying the <xref:System.ServiceModel.OperationContractAttribute> class to them.  
  
3. Designate operations that must have no output (no return value and no out or ref parameters) as one-way by setting the <xref:System.ServiceModel.OperationContractAttribute.IsOneWay%2A> property to `true`. Note that the operations that carry the <xref:System.ServiceModel.OperationContractAttribute> class satisfy a request-reply contract by default because the <xref:System.ServiceModel.OperationContractAttribute.IsOneWay%2A> property is `false` by default. So you must explicitly specify the value of the attribute property to be `true` if you want a one-way contract for the method.  
  
## Example  

 The following code example defines a contract for a service that includes several one-way methods. All of the methods have one-way contracts except `Equals`, which defaults to request-reply and returns a result.  
  
 [!code-csharp[S_Service_Session#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_service_session/cs/service.cs#1)]
 [!code-vb[S_Service_Session#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_service_session/vb/service.vb#1)]  
  
## See also

- <xref:System.ServiceModel.ServiceContractAttribute>
- <xref:System.ServiceModel.OperationContractAttribute>
- [Designing and Implementing Services](../designing-and-implementing-services.md)
- [How to: Define a Service Contract](../how-to-define-a-wcf-service-contract.md)
- [Session](/previous-versions/dotnet/framework/wcf/samples/session)
- [How to: Create a Duplex Contract](how-to-create-a-duplex-contract.md)
