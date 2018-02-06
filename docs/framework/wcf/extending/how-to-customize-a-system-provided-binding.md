---
title: "How to: Customize a System-Provided Binding"
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
ms.assetid: f8b97862-e8bb-470d-8b96-07733c21fe26
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Customize a System-Provided Binding
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] includes several system-provided bindings that allow you to configure some of the properties of the underlying binding elements, but not all of the properties. This topic demonstrates how to set properties on the binding elements to create a custom binding.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how to directly create and configure binding elements without using the system-provided bindings, see [Custom Bindings](../../../../docs/framework/wcf/extending/custom-bindings.md).  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] creating and extending custom bindings, see [Extending Bindings](../../../../docs/framework/wcf/extending/extending-bindings.md).  
  
 In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] all bindings are made up of *binding elements*. Each binding element derives from the <xref:System.ServiceModel.Channels.BindingElement> class. System-provided bindings such as <xref:System.ServiceModel.BasicHttpBinding> create and configure their own binding elements. This topic shows you how to access and change the properties of these binding elements, which are not directly exposed on the binding; specifically, the <xref:System.ServiceModel.BasicHttpBinding> class.  
  
 The individual binding elements are contained in a collection represented by the <xref:System.ServiceModel.Channels.BindingElementCollection> class and are added in this order: Transaction Flow, Reliable Session, Security, Composite Duplex, One-way, Stream Security, Message Encoding, and Transport. Note that not all the binding elements listed are required in every binding. User-defined binding elements can also appear in this binding element collection and must appear in the same order as previously described. For example, a user-defined transport must be the last element of the binding element collection.  
  
 The <xref:System.ServiceModel.BasicHttpBinding> class contains three binding elements:  
  
1.  An optional security binding element, either the <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement> class used with the HTTP transport (message level security) or the <xref:System.ServiceModel.Channels.TransportSecurityBindingElement> class, which is used when the transport layer provides security, in which case the HTTPS transport is used.  
  
2.  A required message encoder binding element, either <xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement> or <xref:System.ServiceModel.Channels.MtomMessageEncodingBindingElement>.  
  
3.  A required transport binding element, either <xref:System.ServiceModel.Channels.HttpTransportBindingElement>, or <xref:System.ServiceModel.Channels.HttpsTransportBindingElement>.  
  
 In this example we create an instance of the binding, generate a *custom binding* from it, examine the binding elements in the custom binding, and when we find the HTTP binding element, we set its `KeepAliveEnabled` property to `false`. The `KeepAliveEnabled` property is not exposed directly on the `BasicHttpBinding`, so we must create a custom binding to navigate down to the binding element and set this property.  
  
### To modify a system-provided binding  
  
1.  Create an instance of the <xref:System.ServiceModel.BasicHttpBinding> class and set its security mode to message-level.  
  
     [!code-csharp[C_HowTo_ChangeStandardBinding#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_changestandardbinding/cs/program.cs#1)]
     [!code-vb[C_HowTo_ChangeStandardBinding#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto_changestandardbinding/vb/program.vb#1)]  
  
2.  Create a custom binding from the binding and create a <xref:System.ServiceModel.Channels.BindingElementCollection> class from one of the custom binding's properties.  
  
     [!code-csharp[C_HowTo_ChangeStandardBinding#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_changestandardbinding/cs/program.cs#2)]
     [!code-vb[C_HowTo_ChangeStandardBinding#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto_changestandardbinding/vb/program.vb#2)]  
  
3.  Loop through the <xref:System.ServiceModel.Channels.BindingElementCollection> class, and when you find the <xref:System.ServiceModel.Channels.HttpTransportBindingElement> class, set its <xref:System.ServiceModel.Channels.HttpTransportBindingElement.KeepAliveEnabled%2A> property to `false`.  
  
     [!code-csharp[C_HowTo_ChangeStandardBinding#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_changestandardbinding/cs/program.cs#3)]
     [!code-vb[C_HowTo_ChangeStandardBinding#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto_changestandardbinding/vb/program.vb#3)]  
  
## See Also  
 <xref:System.ServiceModel.Channels.HttpTransportBindingElement>  
 <xref:System.ServiceModel.BasicHttpBinding>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 [Custom Bindings](../../../../docs/framework/wcf/extending/custom-bindings.md)
