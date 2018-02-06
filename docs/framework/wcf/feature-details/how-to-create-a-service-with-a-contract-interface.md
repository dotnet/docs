---
title: "How to: Create a Service with a Contract Interface"
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
ms.assetid: 7b6803f6-d6f9-4cc2-9f1b-6f4c920475d5
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a Service with a Contract Interface
The preferred way to create a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] contract is by using an interface. This contract specifies the collection and structure of messages required to access the operations the service offers. This interface defines the input and output types by applying the <xref:System.ServiceModel.ServiceContractAttribute> class to the interface and the <xref:System.ServiceModel.OperationContractAttribute> class to the methods that you want to expose.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] service contracts, see [Designing Service Contracts](../../../../docs/framework/wcf/designing-service-contracts.md).  
  
### Creating a WCF contract with an interface  
  
1.  Create a new interface using [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)], C#, or any other common language runtime language.  
  
2.  Apply the <xref:System.ServiceModel.ServiceContractAttribute> class to the interface.  
  
3.  Define the methods in the interface.  
  
4.  Apply the <xref:System.ServiceModel.OperationContractAttribute> class to each method that must be exposed as part of the public [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] contract.  
  
## Example  
 The following code example shows an interface that defines a service contract.  
  
 [!code-csharp[c_HowTo_CreateContractWithInterface#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_createcontractwithinterface/cs/source.cs#1)]
 [!code-vb[c_HowTo_CreateContractWithInterface#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto_createcontractwithinterface/vb/source.vb#1)]  
  
 The methods that have the <xref:System.ServiceModel.OperationContractAttribute> class applied use a request-reply message pattern by default. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] this message pattern, see [How to: Create a Request-Reply Contract](../../../../docs/framework/wcf/feature-details/how-to-create-a-request-reply-contract.md). You can also create and use other message patterns by setting properties of the attribute. For more examples, see [How to: Create a One-Way Contract](../../../../docs/framework/wcf/feature-details/how-to-create-a-one-way-contract.md) and [How to: Create a Duplex Contract](../../../../docs/framework/wcf/feature-details/how-to-create-a-duplex-contract.md).  
  
## See Also  
 <xref:System.ServiceModel.ServiceContractAttribute>  
 <xref:System.ServiceModel.OperationContractAttribute>
