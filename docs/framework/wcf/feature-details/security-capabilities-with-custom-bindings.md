---
title: "Security Capabilities with Custom Bindings"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a2425679-484a-4e6c-9c98-7da7304f1516
caps.latest.revision: 11
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Security Capabilities with Custom Bindings
You can perform most common security tasks by using one of the system-provided bindings. If you need more control, however, you can create a custom binding with a <xref:System.ServiceModel.Channels.SecurityBindingElement>, as explained in these topics. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] custom bindings, see [Custom Bindings](../../../../docs/framework/wcf/extending/custom-bindings.md).  
  
## In This Section  
 [SecurityBindingElement Authentication Modes](../../../../docs/framework/wcf/feature-details/securitybindingelement-authentication-modes.md)  
 Describes the authentication modes that are possible with a custom binding.  
  
 [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md)  
 Describes the basic steps for creating a custom binding with a security element.  
  
 [How to: Create a SecurityBindingElement for a Specified Authentication Mode](../../../../docs/framework/wcf/feature-details/how-to-create-a-securitybindingelement-for-a-specified-authentication-mode.md)  
 Describes how to create a security element for a specified authentication mode.  
  
 [How to: Disable Secure Sessions on a WSFederationHttpBinding](../../../../docs/framework/wcf/feature-details/how-to-disable-secure-sessions-on-a-wsfederationhttpbinding.md)  
 Describes how to disable secure sessions when creating a federation service.  
  
 [How to: Enable Message Replay Detection](../../../../docs/framework/wcf/feature-details/how-to-enable-message-replay-detection.md)  
 Describes how to determine when a replay attack occurs.  
  
 [How to: Create a Supporting Credential](../../../../docs/framework/wcf/feature-details/how-to-create-a-supporting-credential.md)  
 Describes how to supply a supporting credential to a service, if the service requires it.  
  
 [How to: Set Up a Signature Confirmation](../../../../docs/framework/wcf/feature-details/how-to-set-up-a-signature-confirmation.md)  
 Describes the steps to confirm signatures when digitally signing messages.  
  
 [How to: Set a Max Clock Skew](../../../../docs/framework/wcf/feature-details/how-to-set-a-max-clock-skew.md)  
 Describes how to set the maximum allowed time difference between a service and a client.  
  
 [How to: Disable Encryption of Digital Signatures](../../../../docs/framework/wcf/feature-details/how-to-disable-encryption-of-digital-signatures.md)  
 Describes how disabling encryption of digital signatures can have a performance benefit.  
  
## Reference  
 <xref:System.ServiceModel.Channels.SecurityBindingElement>  
  
 [\<security>](../../../../docs/framework/configure-apps/file-schema/wcf/security-of-custombinding.md)  
  
## Related Sections  
 [Understanding Protection Level](../../../../docs/framework/wcf/understanding-protection-level.md)  
  
 [Securing Services and Clients](../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)  
  
## See Also  
 [Bindings and Security](../../../../docs/framework/wcf/feature-details/bindings-and-security.md)  
 [Security Overview](../../../../docs/framework/wcf/feature-details/security-overview.md)  
 [System-Provided Bindings](../../../../docs/framework/wcf/system-provided-bindings.md)
