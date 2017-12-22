---
title: "Securing Messages Using Message Security"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a17ebe67-836b-4c52-9a81-2c3d58e225ee
caps.latest.revision: 16
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Securing Messages Using Message Security
This section discusses [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] message security when using <xref:System.ServiceModel.NetMsmqBinding>.  
  
> [!NOTE]
>  Before reading through this topic, it is recommended that you read [Security Concepts](../../../../docs/framework/wcf/feature-details/security-concepts.md).  
  
 The following illustration provides a conceptual model of queued communication using [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. This illustration and terminology are used to explain  
  
 transport security concepts.  
  
 ![Queued Application Diagram](../../../../docs/framework/wcf/feature-details/media/distributed-queue-figure.jpg "Distributed-Queue-Figure")  
  
 When sending queued messages using [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] message is attached as a body of the Message Queuing (MSMQ) message. While transport security secures the entire MSMQ message, message (or SOAP) security only secures the body of the MSMQ message.  
  
 The key concept of message security is that the client secures the message for the receiving application (service), unlike transport security where the client secures the message for the Target Queue. As such, MSMQ plays no part when securing the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] message using message security.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] message security adds security headers to the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] message that integrate with existing security infrastructures, such as a certificate or the Kerberos protocol.  
  
## Message Credential Type  
 Using message security, the service and client can present credentials to authenticate each another. You can select message security by setting the <xref:System.ServiceModel.NetMsmqBinding.Security%2A> mode to `Message` or `Both` (that is, use both transport security and message security).  
  
 The service can use the <xref:System.ServiceModel.ServiceSecurityContext.Current%2A> property to inspect the credential used to authenticate the client. This can also be used for further authorization checks that the service chooses to implement.  
  
 This section explains the different credential types and how to use them with queues.  
  
### Certificate  
 The certificate credential type uses an X.509 certificate to identify the service and the client.  
  
 In a typical scenario, the client and the service are issued a valid certificate by a trusted certification authority. Then the connection is established, the client authenticates the validity of the service using the service's certificate to decide whether it can trust the service. Similarly, the service uses the client's certificate to validate the client trust.  
  
 Given the disconnected nature of queues, the client and the service may not be online at the same time. As such, the client and service have to exchange certificates out-of-band. In particular, the client, by virtue of holding the service's certificate (which can be chained to a certification authority) in its trusted store, must trust that it is communicating with the correct service. For authenticating the client, the service uses the X.509 certificate attached with the message to matches it with the certificate in its store to verify the authenticity of the client. Again, the certificate must be chained to a certification authority.  
  
 On a computer running Windows, certificates are held in several kinds of stores. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the different stores, see [Certificate stores](http://go.microsoft.com/fwlink/?LinkId=87787).  
  
### Windows  
 Windows message credential type uses the Kerberos protocol.  
  
 The Kerberos protocol is a security mechanism that authenticates users on a domain and allows the authenticated users to establish secure contexts with other entities on a domain.  
  
 The problem with using the Kerberos protocol for queued communication is that the tickets that contain client identity that the Key Distribution Center (KDC) distributes are relatively short-lived. A *lifetime* is associated with the Kerberos ticket that indicates the validity of the ticket. As such, given high latency, you cannot be sure that the token is still valid for the service that authenticates the client.  
  
 Note that when using this credential type, the service must be running under the SERVICE account.  
  
 The Kerberos protocol is used by default when choosing message credential. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Exploring Kerberos, the Protocol for Distributed Security in Windows 2000](http://go.microsoft.com/fwlink/?LinkId=87790).  
  
### Username Password  
 Using this property, the client can authenticate to the server using a username password in the security header of the message.  
  
### IssuedToken  
 The client can use the security token service to issue a token that can then be attached to the message for the service to authenticate the client.  
  
## Using Transport and Message Security  
 When using both transport security and message security, the certificate used to secure the message both at the transport and the SOAP message level must be the same.  
  
## See Also  
 [Securing Messages Using Transport Security](../../../../docs/framework/wcf/feature-details/securing-messages-using-transport-security.md)  
 [Message Security over Message Queuing](../../../../docs/framework/wcf/samples/message-security-over-message-queuing.md)  
 [Security Concepts](../../../../docs/framework/wcf/feature-details/security-concepts.md)  
 [Securing Services and Clients](../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)
