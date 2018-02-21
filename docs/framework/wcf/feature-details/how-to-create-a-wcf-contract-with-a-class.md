---
title: "How to: Create a Windows Communication Foundation Contract with a Class"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 1ad69393-3915-4e7f-9b91-b6fc59c6f5ba
caps.latest.revision: 17
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a Windows Communication Foundation Contract with a Class
The preferred way of creating a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] contract is by using an interface. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: Define a Service Contract](../../../../docs/framework/wcf/how-to-define-a-wcf-service-contract.md). An alternative, outlined here, is to create a class and then apply the <xref:System.ServiceModel.ServiceContractAttribute> attribute to the class directly and the <xref:System.ServiceModel.OperationContractAttribute> attribute to each of the methods in the class that are part of the contract.  
  
> [!WARNING]
>  `[ServiceContract]` and `[ServiceContractAttribute]` do the same thing. The same thing it true for `[OperationContract]` and `[OperationContractAttribute]`. In each case the former is shorthand for the latter.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] service contracts, see [Designing Service Contracts](../../../../docs/framework/wcf/designing-service-contracts.md).  
  
### Creating a Windows Communication Foundation contract with a class  
  
1.  Create a new class using [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)], C#, or any other common language runtime language.  
  
2.  Apply the <xref:System.ServiceModel.ServiceContractAttribute> class to the class.  
  
3.  Create methods in the class.  
  
4.  Apply the <xref:System.ServiceModel.OperationContractAttribute> class to each method that must be exposed as part of the public [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] contract.  
  
## Example  
 The following code example shows a class that defines a service contract.  
  
 [!code-csharp[c_HowTo_CreateContractWithClass#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_createcontractwithclass/cs/source.cs#1)]
 [!code-vb[c_HowTo_CreateContractWithClass#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto_createcontractwithclass/vb/source.vb#1)]  
  
 The methods that have the <xref:System.ServiceModel.OperationContractAttribute> class applied use a request-reply message pattern by default. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] this message pattern, see [How to: Create a Request-Reply Contract](../../../../docs/framework/wcf/feature-details/how-to-create-a-request-reply-contract.md). You can also create and use other message patterns by setting properties of the attribute. For more examples, see [How to: Create a One-Way Contract](../../../../docs/framework/wcf/feature-details/how-to-create-a-one-way-contract.md) and [How to: Create a Duplex Contract](../../../../docs/framework/wcf/feature-details/how-to-create-a-duplex-contract.md).  
  
## See Also  
 <xref:System.ServiceModel.ServiceContractAttribute>  
 <xref:System.ServiceModel.OperationContractAttribute>
