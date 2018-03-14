---
title: "Message Security in WCF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a80efb59-591a-4a37-bb3c-8fffa6ca0b7d
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Message Security in WCF
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] has two major modes for providing security (`Transport` and `Message`) and a third mode (`TransportWithMessageCredential`) that combines the two. This topic discusses message security and the reasons to use it.  
  
## What Is Message Security?  
 Message security uses the WS-Security specification to secure messages. The WS-Securityspecification describes enhancements to SOAP messaging to ensure confidentiality, integrity, and authentication at the SOAP message level (instead of the transport level).  
  
 In brief, message security differs from transport security by encapsulating the security credentials and claims with every message along with any message protection (signing or encryption). Applying the security directly to the message by modifying its content allows the secured message to be self-containing with respect to the security aspects. This enables some scenarios that are not possible when transport security is used.  
  
## Reasons to Use Message Security  
 In message-level security, all of the security information is encapsulated in the message. Securing the message with message-level security instead of transport-level security has the following advantages:  
  
-   End-to-end security. Transport security, such as Secure Sockets Layer (SSL) only secures messages when the communication is point-to-point. If the message is routed to one or more SOAP intermediaries (for example a router) before reaching the ultimate receiver, the message itself is not protected once an intermediary reads it from the wire. Additionally, the client authentication information is available only to the first intermediary and must be re-transmitted to the ultimate receiver in out-of-band fashion, if necessary. This applies even if the entire route uses SSL security between individual hops. Because message security works directly with the message and secures the XML in it, the security stays with the message regardless of how many intermediaries are involved before it reaches the ultimate receiver. This enables a true end-to-end security scenario.  
  
-   Increased flexibility. Parts of the message, instead of the entire message, can be signed or encrypted. This means that intermediaries can view the parts of the message that are intended for them. If the sender needs to make part of the information in the message visible to the intermediaries but wants to ensure that it is not tampered with, it can just sign it but leave it unencrypted. Since the signature is part of the message, the ultimate receiver can verify that the information in the message was received intact. One scenario might have a SOAP intermediary service that routes message according the Action header value. By default, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not encrypt the Action value but signs it if message security is used. Therefore, this information is available to all intermediaries, but no one can change it.  
  
-   Support for multiple transports. You can send secured messages over many different transports, such as named pipes and TCP, without having to rely on the protocol for security. With transport-level security, all the security information is scoped to a single particular transport connection and is not available from the message content itself. Message security makes the message secure regardless of what transport you use to transmit the message, and the security context is directly embedded inside the message.  
  
-   Support for a wide set of credentials and claims. The message security is based on the WS-Security specification, which provides an extensible framework capable of transmitting any type of claim inside the SOAP message. Unlike transport security, the set of authentication mechanisms, or claims, that you can use is not limited by the transport capabilities. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] message security includes multiple types of authentication and claim transmission and can be extended to support additional types as necessary. For those reasons, for example, a federated credentials scenario is not possible without message security. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] federation scenarios WCF supports, see [Federation and Issued Tokens](../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md).  
  
## How Message and Transport Security Compare  
  
### Pros and Cons of Transport-Level Security  
 Transport security has the following advantages:  
  
-   Does not require that the communicating parties understand XML-level security concepts. This can improve the interoperability, for example, when HTTPS is used to secure the communication.  
  
-   Generally improved performance.  
  
-   Hardware accelerators are available.  
  
-   Streaming is possible.  
  
 Transport security has the following disadvantages:  
  
-   Hop-to-hop only.  
  
-   Limited and inextensible set of credentials.  
  
-   Transport-dependent.  
  
### Disadvantages of Message-Level Security  
 Message security has the following disadvantages:  
  
-   Performance  
  
-   Cannot use message streaming.  
  
-   Requires implementation of XML-level security mechanisms and support for WS-Security specification. This might affect the interoperability.  
  
## See Also  
 [Securing Services and Clients](../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)  
 [Transport Security](../../../../docs/framework/wcf/feature-details/transport-security.md)  
 [How to: Use Transport Security and Message Credentials](../../../../docs/framework/wcf/feature-details/how-to-use-transport-security-and-message-credentials.md)  
 [Microsoft Patterns and Practices, Chapter 3: Implementing Transport and Message Layer Security](http://go.microsoft.com/fwlink/?LinkId=88897)
