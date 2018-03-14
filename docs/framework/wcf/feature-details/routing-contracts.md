---
title: "Routing Contracts"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9ceea7ae-ea19-4cf9-ba4f-d071e236546d
caps.latest.revision: 7
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Routing Contracts
Routing contracts define the message patterns that the Routing Service can process.  Each contract is typeless and allows the service to receive a message without knowledge of the message schema or action. This allows the Routing Service to generically route messages without additional configuration for the specifics of the underlying messages being routed.  
  
## Routing Contracts  
 Because the Routing Service accepts a generic WCF Message object, the most important consideration when selecting a contract is the shape of the channel that will be used when communicating with the clients and services. When processing messages, the Routing Service uses symmetrical message pumps, so generally the shape of the inbound contract must match the shape of the outbound contract. However, there are cases where the Service Model’s dispatcher can modify the shapes, such as when the dispatcher converts a duplex channel into a request-reply channel, or removes the session support from a channel when it is not required and is not being used (that is, when **SessionMode.Allowed**, converting an **IInputSessionChannel** into an **IInputChannel**).  
  
 To support these message pumps, the Routing Service provides contracts in the <xref:System.ServiceModel.Routing> namespace, which must be used when defining the service endpoints used by the Routing Service. These contracts are typeless, which allows the receipt of any message type or action, and allows the Routing Service to handle messages without knowledge of the specific message schema. For more information about the contracts used by the Routing Service, see [Routing Contracts](../../../../docs/framework/wcf/feature-details/routing-contracts.md).  
  
 The contracts provided by the Routing Service are located in the <xref:System.ServiceModel.Routing> namespace, and are described in the following table.  
  
|Contract|Shape|Channel Shape|  
|--------------|-----------|-------------------|  
|<xref:System.ServiceModel.Routing.ISimplexDatagramRouter>|SessionMode = SessionMode.Allowed<br /><br /> AsyncPattern = true<br /><br /> IsOneWay = true|IInputChannel -> IOutputChannel|  
|<xref:System.ServiceModel.Routing.ISimplexSessionRouter>|SessionMode = SessionMode.Required<br /><br /> AsyncPattern = true<br /><br /> IsOneWay = true|IInputSessionChannel -> IOutputSessionChannel|  
|<xref:System.ServiceModel.Routing.IRequestReplyRouter>|SessionMode = SessionMode.Allowed<br /><br /> AsyncPattern = true|IReplyChannel -> IRequestChannel|  
|<xref:System.ServiceModel.Routing.IDuplexSessionRouter>|SessionMode=SessionMode.Required<br /><br /> CallbackContract=typeof(ISimplexSession)<br /><br /> AsyncPattern = true<br /><br /> IsOneWay = true<br /><br /> TransactionFlow(TransactionFlowOption.Allowed)|IDuplexSessionChannel -> IDuplexSessionChannel|  
  
## See Also  
 [Routing Service](http://msdn.microsoft.com/library/5ac8718c-bcef-456f-bfd5-1e60a30d6eaa)  
 [Routing Introduction](../../../../docs/framework/wcf/feature-details/routing-introduction.md)
