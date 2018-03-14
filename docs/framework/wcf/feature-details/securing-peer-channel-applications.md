---
title: "Securing Peer Channel Applications"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d4a0311d-3f78-4525-9c4b-5c93c4492f28
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Securing Peer Channel Applications
Like other bindings under the [!INCLUDE[vstecwinfx](../../../../includes/vstecwinfx-md.md)], `NetPeerTcpBinding` has security enabled by default and offers both transport- and message-based security (or both). This topic discusses these two types of security. The type of security is specified by the security mode tag in the binding specification (<xref:System.ServiceModel.NetPeerTcpBinding.Security%2A>`Mode`).  
  
## Transport-Based Security  
 Peer Channel supports two types of authentication credentials for securing transport, both of which require setting out the `ClientCredentialSettings.Peer` property on the associated `ChannelFactory`:  
  
-   Password. Clients use knowledge of a secret password to authenticate connections. When this credential type is used, `ClientCredentialSettings.Peer.MeshPassword` must carry a valid password and optionally an `X509Certificate2` instance.  
  
-   Certificate. Specific application authentication is used. When this credential type is used, you must use a concrete implementation of <xref:System.IdentityModel.Selectors.X509CertificateValidator> in `ClientCredentialSettings.Peer.PeerAuthentication`.  
  
## Message-Based Security  
 Using message security, an application can sign outgoing messages so that all receiving parties can verify the message is sent by a trusted party and that the message was not tampered with. Currently, Peer Channel supports only X.509 credential message signing.  
  
## Best Practices  
  
-   This section discusses the best practices for securing Peer Channel applications.  
  
### Enable Security with Peer Channel Applications  
 Due to the distributed nature of the Peer Channel protocols, it is hard to enforce mesh membership, confidentiality, and privacy in an unsecured mesh. It is also important to remember to secure communication between clients and the resolver service. Under Peer Name Resolution Protocol (PNRP), use secure names to avoid spoofing and other common attacks. Secure a custom resolver service by enabling security on the connection clients use to contact the resolver service, including both message- and transport-based security.  
  
### Use the Strongest Possible Security Model  
 For example, if each member of the mesh needs to be individually identified, use certificate-based authentication model. If that is not possible, use password-based authentication following current recommendations to keep them secure. This includes sharing passwords only with trusted parties, transmitting passwords using a secure medium, changing passwords frequently, and ensuring that passwords are strong (at least eight characters long, include at least one letter from both cases, a digit, and a special character).  
  
### Never Accept Self-Signed Certificates  
 Never accept a certificate credential based on subject names. Note that anyone can create a certificate, and anyone can choose a name that you are validating. To avoid the possibility of spoofing, validate certificates based on issuing authority credentials (either a trusted issuer or a root certification authority).  
  
### Use Message Authentication  
 Use message authentication to verify that a message originated from a trusted source and that no one has tampered with the message during transmission. Without message authentication, it is easy for a malicious client to spoof or tamper with messages in the mesh.  
  
## Peer Channel Code Examples  
 [Peer Channel Scenarios](../../../../docs/framework/wcf/feature-details/peer-channel-scenarios.md)  
  
## See Also  
 [Peer Channel Security](../../../../docs/framework/wcf/feature-details/peer-channel-security.md)  
 [Building a Peer Channel Application](../../../../docs/framework/wcf/feature-details/building-a-peer-channel-application.md)
