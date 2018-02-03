---
title: "Encryption of Digital Signatures"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "encryption of digital signatures [WCF]"
  - "digital signatures [WCF], encryption"
  - "digital signatures [WCF]"
ms.assetid: 0868866d-40b4-4341-8e42-eee3b7f15b69
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Encryption of Digital Signatures
By default, a message is signed and encrypted, and the signature is digitally encrypted. You can control this by creating a custom binding with an instance of the <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement> or the <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> and then setting the `MessageProtectionOrder` property of either class to a <xref:System.ServiceModel.Security.MessageProtectionOrder> enumeration value. The default is <xref:System.ServiceModel.Security.MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature>. This process takes 10 to 40 percent longer than simply signing and encrypting. Disabling encryption of the signature, however, might allow an attacker to guess the contents of the message. This is possible because the signature element contains the hash code of the plain text of every signed part in the message. For example, although the message body is encrypted by default, the unencrypted signature contains the hash code of the message body. If the message is small, an attacker might be able to deduce the contents. Encrypting the signature reduces or eliminates this possibility.  
  
 Therefore, disable encryption of the signature only when the value of the content is low, and the performance gain will be significant, for example, when sending large binary files that have no security implications.  
  
### To disable digital signing  
  
1.  Create a <xref:System.ServiceModel.Channels.CustomBinding>. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md).  
  
2.  Add either an <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement> or a <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> to the binding collection.  
  
3.  Set the <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement.MessageProtectionOrder%2A?displayProperty=nameWithType> property to <xref:System.ServiceModel.Security.MessageProtectionOrder.SignBeforeEncrypt>, or set the <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement.MessageProtectionOrder%2A?displayProperty=nameWithType> property to <xref:System.ServiceModel.Security.MessageProtectionOrder.SignBeforeEncrypt>.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] creating custom bindings, see [Creating User-Defined Bindings](../../../../docs/framework/wcf/extending/creating-user-defined-bindings.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] creating a custom binding for a specific authentication mode, see [How to: Create a SecurityBindingElement for a Specified Authentication Mode](../../../../docs/framework/wcf/feature-details/how-to-create-a-securitybindingelement-for-a-specified-authentication-mode.md).  
  
## See Also  
 <xref:System.ServiceModel.Security.MessageProtectionOrder>  
 <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement>  
 <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement>  
 [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md)  
 [Creating User-Defined Bindings](../../../../docs/framework/wcf/extending/creating-user-defined-bindings.md)  
 [How to: Create a SecurityBindingElement for a Specified Authentication Mode](../../../../docs/framework/wcf/feature-details/how-to-create-a-securitybindingelement-for-a-specified-authentication-mode.md)
