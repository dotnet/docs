---
title: "How to: Disable Secure Sessions on a WSFederationHttpBinding"
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
helpviewer_keywords: 
  - "WCF, federation"
  - "federation"
ms.assetid: 675fa143-6a4e-4be3-8afc-673334ab55ec
caps.latest.revision: 16
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How to: Disable Secure Sessions on a WSFederationHttpBinding
Some services may require federated credentials but not support secure sessions. In that case, you must disable the secure session feature. Unlike the <<!--zz xref:System.ServiceModel.WsHttpBinding --> `xref:System.ServiceModel.WsHttpBinding`>, the <xref:System.ServiceModel.WSFederationHttpBinding> class does not provide a way to disable secure sessions when communicating with a service. Instead, you must create a custom binding that replaces the secure session settings with a bootstrap.  
  
 This topic demonstrates how to modify the binding elements contained within a <xref:System.ServiceModel.WSFederationHttpBinding> to create a custom binding. The result is identical to the <xref:System.ServiceModel.WSFederationHttpBinding> except that it does not use secure sessions.  
  
### To create a custom federated binding without secure session  
  
1.  Create an instance of the <xref:System.ServiceModel.WSFederationHttpBinding> class either imperatively in code or by loading one from the configuration file.  
  
2.  Clone the <xref:System.ServiceModel.WSFederationHttpBinding> into a <xref:System.ServiceModel.Channels.CustomBinding>.  
  
3.  Find the <xref:System.ServiceModel.Channels.SecurityBindingElement> in the <xref:System.ServiceModel.Channels.CustomBinding>.  
  
4.  Find the <xref:System.ServiceModel.Security.Tokens.SecureConversationSecurityTokenParameters> in the <xref:System.ServiceModel.Channels.SecurityBindingElement>.  
  
5.  Replace the original <xref:System.ServiceModel.Channels.SecurityBindingElement> with the bootstrap security binding element from the <xref:System.ServiceModel.Security.Tokens.SecureConversationSecurityTokenParameters>.  
  
## Example  
 This following example creates a custom federated binding without secure session.  
  
 [!code-csharp[c_CustomFederationBinding#0](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customfederationbinding/cs/c_customfederationbinding.cs#0)]
 [!code-vb[c_CustomFederationBinding#0](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customfederationbinding/vb/c_customfederationbinding.vb#0)]  
  
## Compiling the Code  
  
-   To compile the code example, create a project that references the System.ServiceModel.dll assembly.  
  
## See Also  
 [Bindings and Security](../../../../docs/framework/wcf/feature-details/bindings-and-security.md)
