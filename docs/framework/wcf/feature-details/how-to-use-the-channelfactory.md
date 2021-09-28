---
title: "How to: Use the ChannelFactory"
description: Learn how to create a channel factory to create more than one channel for accessing services by using a WCF client. 
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: d48f01b5-582b-4c8b-b547-8adddae7e371
---
# How to: Use the ChannelFactory

The generic <xref:System.ServiceModel.ChannelFactory%601> class is used in advanced scenarios that require the creation of a channel factory that can be used to create more than one channel.  
  
### To create and use the ChannelFactory class  
  
1. Build and run an Windows Communication Foundation (WCF) service. For more information, see [Designing and Implementing Services](../designing-and-implementing-services.md), [Configuring Services](../configuring-services.md), and [Hosting Services](../hosting-services.md).  
  
2. Use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../servicemodel-metadata-utility-tool-svcutil-exe.md) to generate the contract (interface) for the client.  
  
3. In the client code, use the <xref:System.ServiceModel.ChannelFactory%601> class to create multiple endpoint listeners.  
  
## Example  

 [!code-csharp[c_HowToUseChannelFactory#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howtousechannelfactory/cs/source.cs#1)]
 [!code-vb[c_HowToUseChannelFactory#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howtousechannelfactory/vb/source.vb#1)]
