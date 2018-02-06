---
title: "How to: Create a Custom Binding Using the SecurityBindingElement"
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
  - "security [WCF], creating custom bindings"
ms.assetid: 203a9f9e-3a73-427c-87aa-721c56265b29
caps.latest.revision: 19
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How to: Create a Custom Binding Using the SecurityBindingElement
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] includes several system-provided bindings that can be configured but do not provide full flexibility when configuring all the security options that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports. This topic demonstrates how to create a custom binding directly from individual binding elements and highlights some of the security settings that can be specified when creating such a binding. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] creating custom bindings, see [Extending Bindings](../../../../docs/framework/wcf/extending/extending-bindings.md).  
  
> [!WARNING]
>  <xref:System.ServiceModel.Channels.SecurityBindingElement> does not support the <xref:System.ServiceModel.Channels.IDuplexSessionChannel> channel shape, which is the default channel shape use by the TCP transport when <xref:System.ServiceModel.TransferMode> is set to <xref:System.ServiceModel.TransferMode.Buffered>. You must set <xref:System.ServiceModel.TransferMode> to <xref:System.ServiceModel.TransferMode.Streamed> in order to use <xref:System.ServiceModel.Channels.SecurityBindingElement> in this scenario.  
  
## Creating a Custom Binding  
 In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] all bindings are made up of *binding elements*. Each binding element derives from the <xref:System.ServiceModel.Channels.BindingElement> class. For the standard system-provided bindings, the binding elements are created and configured for you, although you can customize some of the property settings.  
  
 In contrast, to create a custom binding, binding elements are created and configured and a <xref:System.ServiceModel.Channels.CustomBinding> is created from the binding elements.  
  
 To do this, you add the individual binding elements to a collection represented by an instance of the <xref:System.ServiceModel.Channels.BindingElementCollection> class, and then set the `Elements` property of the `CustomBinding` equal to that object. You must add the binding elements in the following order: Transaction Flow, Reliable Session, Security, Composite Duplex, One-way, Stream Security, Message Encoding, and Transport. Note that not all the binding elements listed are required in every binding.  
  
## SecurityBindingElement  
 Three binding elements relate to message level security, all of which derive from the <xref:System.ServiceModel.Channels.SecurityBindingElement> class. The three are <xref:System.ServiceModel.Channels.TransportSecurityBindingElement>, <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement>, and <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement>. The <xref:System.ServiceModel.Channels.TransportSecurityBindingElement> is used to provide Mixed mode security. The other two elements are used when the message layer provides security.  
  
 Additional classes are used when transport level security is provided:  
  
-   <xref:System.ServiceModel.Channels.HttpsTransportBindingElement>  
  
-   <xref:System.ServiceModel.Channels.SslStreamSecurityBindingElement>  
  
-   <xref:System.ServiceModel.Channels.WindowsStreamSecurityBindingElement>  
  
## Required Binding Elements  
 There are a large number of possible binding elements that can be combined into a binding. Not all of these combinations are valid. This section describes the required elements that must be present in a security binding.  
  
 Valid security bindings depend on many factors, including the following:  
  
-   Security mode.  
  
-   Transport protocol.  
  
-   The message exchange pattern (MEP) specified in the contract.  
  
 The following table shows the valid binding element stack configurations for each combination of the preceding factors. Note that these are minimal requirements. You can add additional binding elements to the binding, such as message encoding binding elements, transaction binding elements, and other binding elements.  
  
|Security Mode|Transport|Contract Message Exchange Pattern|Contract Message Exchange Pattern|Contract Message Exchange Pattern|  
|-------------------|---------------|---------------------------------------|---------------------------------------|---------------------------------------|  
|||`Datagram`|`Request Reply`|`Duplex`|  
|Transport|Https||||  
|||OneWayBindingElement|||  
|||HttpsTransportBindingElement|HttpsTransportBindingElement||  
||TCP||||  
|||OneWayBindingElement|||  
|||SSL or Windows StreamSecurityBindingElement|SSL or Windows StreamSecurityBindingElement|SSL or Windows StreamSecurityBindingElement|  
|||TcpTransportBindingElement|TcpTransportBindingElement|TcpTransportBindingElement|  
|Message|Http|SymmetricSecurityBindingElement|SymmetricSecurityBindingElement|SymmetricSecurityBindingElement (authentication mode = SecureConversation)|  
|||||CompositeDuplexBindingElement|  
|||OneWayBindingElement||OneWayBindingElement|  
|||HttpTransportBindingElement|HttpTransportBindingElement|HttpTransportBindingElement|  
||Tcp|SecurityBindingElement|SecurityBindingElement|SymmetricSecurityBindingElement (authentication mode = SecureConversation)|  
|||TcpTransportBindingElement|TcpTransportBindingElement|TcpTransportBindingElement|  
|Mixed (transport with message credentials)|Https|TransportSecurityBindingElement|TransportSecurityBindingElement||  
|||OneWayBindingElement|||  
|||HttpsTransportBindingElement|HttpsTransportBindingElement||  
||TCP|TransportSecurityBindingElement|SymmetricSecurityBindingElement (authentication mode = SecureConversation)|SymmetricSecurityBindingElement (authentication mode = SecureConversation)|  
|||OneWayBindingElement|||  
|||SSL or Windows StreamSecurityBindingElement|SSL or Windows StreamSecurityBindingElement|SSL or Windows StreamSecurityBindingElement|  
|||TcpTransportBindingElement|TcpTransportBindingElement|TcpTransportBindingElement|  
  
 Note that there are many configurable settings on the SecurityBindingElements. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [SecurityBindingElement Authentication Modes](../../../../docs/framework/wcf/feature-details/securitybindingelement-authentication-modes.md).  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Secure Conversations and Secure Sessions](../../../../docs/framework/wcf/feature-details/secure-conversations-and-secure-sessions.md).  
  
## Procedures  
  
#### To create a custom binding that uses a SymmetricSecurityBindingElement  
  
1.  Create an instance of the <xref:System.ServiceModel.Channels.BindingElementCollection> class with the name `outputBec`.  
  
2.  Call the static method `M:System.ServiceModel.Channels.SecurityBindingElement.CreateSspiNegotiationBindingElement(true)`, which returns an instance of the <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> class.  
  
3.  Add the <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> to the collection (`outputBec`) by calling the `Add` method of the <xref:System.Collections.ObjectModel.Collection%601> of <xref:System.ServiceModel.Channels.BindingElement> class.  
  
4.  Create an instance of the <xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement> class and add it to the collection (`outputBec`). This specifies the encoding used by the binding.  
  
5.  Create a <xref:System.ServiceModel.Channels.HttpTransportBindingElement> and add it to the collection (`outputBec`). This specifies that the binding uses the HTTP transport.  
  
6.  Create a new custom binding by creating an instance of the <xref:System.ServiceModel.Channels.CustomBinding> class and passing the collection `outputBec` to the constructor.  
  
7.  The resulting custom binding shares many of the same characteristics as the standard <xref:System.ServiceModel.WSHttpBinding>. It specifies message-level security and Windows credentials but disables secure sessions, requires that the service credential be specified out-of-band, and does not encrypt signatures. The last can be controlled only by setting the <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement.MessageProtectionOrder%2A> property as shown in step 4. The other two can be controlled using settings on the standard binding.  
  
## Example  
  
### Description  
 The following example provides a complete function to create a custom binding that uses a <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement>.  
  
### Code  
 [!code-csharp[c_CustomBinding#20](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_custombinding/cs/c_custombinding.cs#20)]
 [!code-vb[c_CustomBinding#20](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_custombinding/vb/source.vb#20)]  
  
## See Also  
 <xref:System.ServiceModel.Channels.SecurityBindingElement>  
 <xref:System.ServiceModel.Channels.TransportSecurityBindingElement>  
 <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 [Extending Bindings](../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [System-Provided Bindings](../../../../docs/framework/wcf/system-provided-bindings.md)
