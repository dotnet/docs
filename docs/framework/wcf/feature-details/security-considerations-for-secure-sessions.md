---
title: "Security Considerations for Secure Sessions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0d5be591-9a7b-4a6f-a906-95d3abafe8db
caps.latest.revision: 14
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Security Considerations for Secure Sessions
You should consider the following items that affect security when implementing secure sessions. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] security considerations, see [Security Considerations](../../../../docs/framework/wcf/feature-details/security-considerations-in-wcf.md) and [Best Practices for Security](../../../../docs/framework/wcf/feature-details/best-practices-for-security-in-wcf.md).  
  
## Secure Sessions and Metadata  
 When a secure session is established and the <xref:System.ServiceModel.Security.Tokens.SecureConversationSecurityTokenParameters.RequireCancellation%2A> property is set to `false`, [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] sends an `mssp:MustNotSendCancel` assertion as part of the metadata in the Web Services Description Language (WSDL) document for the service endpoint. The `mssp:MustNotSendCancel` assertion informs clients that the service does not respond to requests to cancel the secure session. When the <xref:System.ServiceModel.Security.Tokens.SecureConversationSecurityTokenParameters.RequireCancellation%2A> property is set to `true`, then [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not emit an `mssp:MustNotSendCancel` assertion in the WSDL document. Clients are expected to send a cancel request to the service when they no longer require the secure session. When a client is generated using the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md), the client code reacts appropriately to the presence or absence of the `mssp:MustNotSendCancel` assertion.  
  
## Secure Conversations and Custom Tokens  
 There are some issues with mixing custom tokens and derived keys due to the way it is defined in the WS-SecureConversation specification. The specification says that `wsse:SecurityTokenReference` is an optional element that references the derived token: "`/wsc:DerivedKeyToken/wsse:SecurityTokenReference` This optional element is used to specify security context token, security token, or shared key/secret used for the derivation. If not specified, it is assumed that the recipient can determine the shared key from the message context. If the context cannot be determined, then a fault such as `wsc:UnknownDerivationSource` should be raised."  
  
 This means that if you want a custom token to be derived, you should wrap its clause type in a `SecurityTokenReference` element. There is an option to turn off derivation but the default is to derive keys. If you fail to wrap the key, serializing the derived key token succeeds, but attempting to deserialize it throws an exception.  
  
## See Also  
 [How to: Disable Secure Sessions on a WSFederationHttpBinding](../../../../docs/framework/wcf/feature-details/how-to-disable-secure-sessions-on-a-wsfederationhttpbinding.md)  
 [Security Considerations](../../../../docs/framework/wcf/feature-details/security-considerations-in-wcf.md)  
 [Best Practices for Security](../../../../docs/framework/wcf/feature-details/best-practices-for-security-in-wcf.md)
