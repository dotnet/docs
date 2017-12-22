---
title: "Peer Channel Security"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2c59b164-3729-44f0-a967-f247c42de662
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Peer Channel Security
Peer Channel enables a variety of distributed application types that depend on multiparty messaging. Some examples include Internet-scale content distribution, where a trusted source distributes content (such as media or software updates), a group of friends exchange music and photos, or a team of colleagues collaboratively edit a document. Each of these scenarios requires a unique security model. The Peer Channel security model is designed to address these scenarios and provides a sound security model for the respective needs of different identity, authentication, and authorization models.  
  
## Security Scenarios  
 A content-distribution scenario requires that each content recipient identify the content source. Due to the distributed nature of the scenario, it is not always possible to know and trust the intermediaries that process or intercept messages. To effectively mitigate the threat that an untrusted intermediary might tamper with the messages, applications can secure the message at the sender so that any tampering attempts are easily detected. In this case, depending on the confidentiality of the content, encryption can be necessary.  
  
 Collaboration scenarios like group document collaboration often require that each member participating in the session be individually identified and authenticated. This means that a mechanism to define user groups and authenticate against those groups is necessary to have a secured session. Moreover, applications might require tracing each message by authentication at the message level. In these types of applications, performance can be sacrificed for a stronger security scheme.  
  
 A communication session among a group of casual users can require informal security models, like knowledge of a common secret among the group. For these types of applications, having a security model that is convenient to establish and configure is more important than having the strongest form of authentication or providing nonrepudiation measures. For these scenarios, a password-based authentication mechanism helps to secure the communication layer while still allowing for message authentication. Password-based security is the default setting for Peer Channel.  
  
## Token Types  
 Peer Channel recognizes a single token type for strong identification, X.509 certificates, which provide a strong identity model based on the type of authentication and authorization that can be implemented. Confidentiality and integrity are easily provided using certificates. However, X.509 certificates can be difficult to use and deploy.  
  
 Peer Channel also provides support for simple applications through the use of passwords. Applications can choose to set up quick and simple peer groups based on a supplied password. In this case, a group owner decides and communicates the password to members. Each member must sign in using this password before they can join the session. Passwords can be used only to allow entry to the session; they cannot be used to perform message authentication. This is because a symmetric token that a group of peers share is difficult and inappropriate to use for source authentication.  
  
## Security Model  
 Peer Channel provides the ability to secure the individual links between peers. This means that a message never flows on an unsecured link (from the application perspective). Internally, each link (a transport channel between two peers) is secured using Transport Layer Security (TLS). This means that when a sender composes and sends a message, it is sent over secure transport to each of its immediate peers, who access the message, and in turn send the message to their immediate peers over secure connections. This security only works at the transport level and is independent of the message security models.  
  
 Peer Channel also provides a way to secure messages independently of the transport security used. In this model, the message is secured at the source using the source’s security token, although currently only X.509 certificates are supported. The secured message is then transmitted over the peer network. Each receiving peer can verify the authenticity of the source. Note that the message is secured so that intermediaries cannot tamper with it.  
  
 To achieve confidentiality, applications can employ transport security with strong group membership schemes to prevent unauthorized access to the message.  
  
 Peer Channel does not require a specific identity model as long as the application chooses one of the supported token types. Applications completely own the life cycle of these identities and authentication decisions.  
  
## See Also  
 [Securing Peer Channel Applications](../../../../docs/framework/wcf/feature-details/securing-peer-channel-applications.md)  
 [Peer Channel Concepts](../../../../docs/framework/wcf/feature-details/peer-channel-concepts.md)  
 [Building a Peer Channel Application](../../../../docs/framework/wcf/feature-details/building-a-peer-channel-application.md)
