---
title: "How to: Disable Encryption of Digital Signatures"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fd174313-ad81-4dca-898a-016ccaff8187
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Disable Encryption of Digital Signatures
By default, a message is signed and the signature is digitally encrypted. This is controlled by creating a custom binding with an instance of the <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement> or the <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> and setting the `MessageProtectionOrder` property of either class to a <xref:System.ServiceModel.Security.MessageProtectionOrder> enumeration value. The default is <xref:System.ServiceModel.Security.MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature>. This process consumes up to 30 percent more time than simply signing and encrypting based on the overall message size (the smaller the message, the greater the performance impact). Disabling encryption of the signature, however, might allow an attacker to guess the content of the message. This is possible because the signature element contains the hash code of the plain text of every signed part in the message. For example, although the message body is encrypted by default, the unencrypted signature contains the hash code of the message body before the encryption. If the set of possible values for the signed and encrypted part is small, an attacker might be able to deduce the contents by looking at the hash value. Encrypting the signature mitigates this attack vector.  
  
 Therefore, disable encryption of the signature only when the value of the content is low or the set of possible content values is large and nondeterministic, and the performance gain is more important than mitigating the attack described above.  
  
> [!NOTE]
>  If there is nothing in the message that is encrypted, the signature element is not encrypted, even when the <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement.MessageProtectionOrder%2A?displayProperty=nameWithType> or <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement.MessageProtectionOrder%2A?displayProperty=nameWithType> property is set to <xref:System.ServiceModel.Security.MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature>. This behavior occurs even with system-provided bindings; all system-provided bindings have the message protection order set to `SignBeforeEncryptAndEncryptSignature`. However, the Web Services Description Language (WSDL) [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] generates will still contain the `<sp:EncryptSignature>` assertion.  
  
### To disable digital signing  
  
1.  Create a <xref:System.ServiceModel.Channels.CustomBinding>. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md).  
  
2.  Add either an <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement> or a <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> to the binding collection.  
  
3.  Set the <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement.MessageProtectionOrder%2A?displayProperty=nameWithType> property to <xref:System.ServiceModel.Security.MessageProtectionOrder.SignBeforeEncrypt>, or set the <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement.MessageProtectionOrder%2A?displayProperty=nameWithType> property to <xref:System.ServiceModel.Security.MessageProtectionOrder.SignBeforeEncrypt>.  
  
## See Also  
 [Security Capabilities with Custom Bindings](../../../../docs/framework/wcf/feature-details/security-capabilities-with-custom-bindings.md)
