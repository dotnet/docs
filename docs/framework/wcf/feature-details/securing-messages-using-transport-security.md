---
title: "Securing Messages Using Transport Security"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9029771a-097e-448a-a13a-55d2878330b8
caps.latest.revision: 21
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Securing Messages Using Transport Security
This section discusses Message Queuing (MSMQ) transport security that you can use to secure messages sent to a queue.  
  
> [!NOTE]
>  Before reading through this topic, it is recommended that you read [Security Concepts](../../../../docs/framework/wcf/feature-details/security-concepts.md).  
  
 The following illustration provides a conceptual model of queued communication using [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)]. This illustration and terminology is used to explain transport security concepts.  
  
 ![Queued Application Diagram](../../../../docs/framework/wcf/feature-details/media/distributed-queue-figure.jpg "Distributed-Queue-Figure")  
  
 When sending queued messages using [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] with <xref:System.ServiceModel.NetMsmqBinding>, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] message is attached as a body of the MSMQ message. Transport security secures the entire MSMQ message (MSMQ message headers or properties and the message body). Because it is the body of the MSMQ message, using transport security also secures the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] message.  
  
 The key concept behind transport security is that the client has to meet security requirements to get the message to the target queue. This is unlike Message security, where the message is secured for the application that receives the message.  
  
 Transport security using <xref:System.ServiceModel.NetMsmqBinding> and <xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding> impacts how MSMQ messages are secured in-transit between the transmission queue and the target queue where secured implies:  
  
-   Signing the message to ensure it is not tampered with.  
  
-   Encrypting the message to ensure that it cannot be seen or tampered with. This is recommended but optional.  
  
-   The target queue manager that identifies the sender of the message for non-repudiation.  
  
 In MSMQ, independent of authentication, the target queue has an access control list (ACL) to check whether the client has permission to send the message to the target queue. The receiving application is also checked for permission to receive the message from the target queue.  
  
## WCF MSMQ Transport Security Properties  
 MSMQ uses Windows security for authentication. It uses the Windows security identifier (SID) to identify the client and uses Active Directory directory service as the certificate authority when authenticating the client. This requires MSMQ to be installed with Active Directory integration. Because the Windows domain SID is used to identify the client, this security option is only meaningful when both the client and service are part of the same Windows domain.  
  
 MSMQ also provides the ability to attach a certificate with the message that is not registered with Active Directory. In this case, it ensures that the message was signed using the attached certificate.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides both these options as part of MSMQ transport security and they are the key pivot for transport security.  
  
 By default, transport security is turned on.  
  
 Given these basics, the following sections detail transport security properties bundled with <xref:System.ServiceModel.NetMsmqBinding> and <xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding>.  
  
#### MSMQ Authentication Mode  
 The <xref:System.ServiceModel.MsmqTransportSecurity.MsmqAuthenticationMode%2A> dictates whether to use the Windows domain security or an external certificate-based security to secure the message. In both authentication modes, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] queued transport channel uses the `CertificateValidationMode` specified in the service configuration. The certificate validation mode specifies the mechanism used to check the validity of the certificate.  
  
 When transport security is turned on, the default setting is <xref:System.ServiceModel.MsmqAuthenticationMode.WindowsDomain>.  
  
#### Windows Domain Authentication Mode  
 The choice of using Windows security requires Active Directory integration. <xref:System.ServiceModel.MsmqAuthenticationMode.WindowsDomain> is the default transport security mode. When this is set, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] channel attaches the Windows SID to the MSMQ message and uses its internal certificate obtained from Active Directory. MSMQ uses this internal certificate to secure the message. The receiving queue manager uses Active Directory to search and find a matching certificate to authenticate the client and checks that the SID also matches that of the client. This authentication step is executed if a certificate, either internally generated in the case of `WindowsDomain` authentication mode or externally generated in the case of `Certificate` authentication mode, is attached to the message even if the target queue is not marked as requiring authentication.  
  
> [!NOTE]
>  When creating a queue, you can mark the queue as an authenticated queue to indicate that the queue requires authentication of the client sending messages to the queue. This ensures that no unauthenticated messages are accepted in the queue.  
  
 The SID attached with the message is also used to check against the target queue's ACL to ensure that the client has the authority to send messages to the queue.  
  
#### Certificate Authentication Mode  
 The choice of using certificate authentication mode does not require Active Directory integration. In fact, in some cases, such as when MSMQ is installed in workgroup mode (without Active Directory integration) or when using the SOAP Reliable Messaging Protocol (SRMP) transfer protocol to send messages to the queue, only <xref:System.ServiceModel.MsmqAuthenticationMode.Certificate> works.  
  
 When sending a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] message with <xref:System.ServiceModel.MsmqAuthenticationMode.Certificate>, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] channel does not attach a Windows SID to the MSMQ message. As such, the target queue ACL must allow for `Anonymous` user access to send to the queue. The receiving queue manager checks whether the MSMQ message was signed with the certificate but does not perform any authentication.  
  
 The certificate with its claims and identity information is populated in the <xref:System.ServiceModel.ServiceSecurityContext> by the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] queued transport channel. The service can use this information to perform its own authentication of the sender.  
  
### MSMQ Protection Level  
 The protection level dictates how to protect the MSMQ message to ensure that it is not tampered with. It is specified in the <xref:System.ServiceModel.MsmqTransportSecurity.MsmqProtectionLevel%2A> property. The default value is <xref:System.Net.Security.ProtectionLevel.Sign>.  
  
#### Sign Protection Level  
 The MSMQ message is signed using the internally generated certificate when using `WindowsDomain` authentication mode or an externally generated certificate when using `Certificate` authentication mode.  
  
#### Sign and Encrypt Protection Level  
 The MSMQ message is signed using the internally generated certificate when using `WindowsDomain` authentication mode or externally generated certificate when using `Certificate` authentication mode.  
  
 In addition to signing the message, the MSMQ message is encrypted using the public key of the certificate obtained from Active Directory that belongs to the receiving queue manager that hosts the target queue. The sending queue manager ensures that the MSMQ message is encrypted in transit. The receiving queue manager decrypts the MSMQ message using the private key of its internal certificate and stores the message in the queue (if authenticated and authorized) in clear text.  
  
> [!NOTE]
>  To encrypt the message, Active Directory access is required (`UseActiveDirectory` property of <xref:System.ServiceModel.NetMsmqBinding> must be set to `true`) and can be used with both <xref:System.ServiceModel.MsmqAuthenticationMode.Certificate> and <xref:System.ServiceModel.MsmqAuthenticationMode.WindowsDomain>.  
  
#### None Protection Level  
 This is implied when <xref:System.ServiceModel.MsmqTransportSecurity.MsmqProtectionLevel%2A> is set to <xref:System.Net.Security.ProtectionLevel.None>. This cannot be a valid value for any other authentication modes.  
  
> [!NOTE]
>  If the MSMQ message is signed, MSMQ checks whether the message is signed with the attached certificate (internal or external) independent of the state of the queue, that is, authenticated queue or not.  
  
### MSMQ Encryption Algorithm  
 The encryption algorithm specifies the algorithm to use to encrypt the MSMQ message on the wire. This property is used only if <xref:System.ServiceModel.MsmqTransportSecurity.MsmqProtectionLevel%2A> is set to <xref:System.Net.Security.ProtectionLevel.EncryptAndSign>.  
  
 The supported algorithms are `RC4Stream` and `AES` and the default is `RC4Stream`.  
  
 You can use the `AES` algorithm only if the sender has MSMQ 4.0 installed. In addition, the target queue must also be hosted on MSMQ 4.0.  
  
### MSMQ Hash Algorithm  
 The hash algorithm specifies the algorithm used to create a digital signature of the MSMQ message. The receiving queue manager uses this same algorithm to authenticate the MSMQ message. This property is used only if <xref:System.ServiceModel.MsmqTransportSecurity.MsmqProtectionLevel%2A> is set to <xref:System.Net.Security.ProtectionLevel.Sign> or <xref:System.Net.Security.ProtectionLevel.EncryptAndSign>.  
  
 The supported algorithms are `MD5`, `SHA1`, `SHA256`, and `SHA512`. The default is `SHA1`.  
  
## See Also  
 [Message Queuing](http://msdn.microsoft.com/library/ff917e87-05d5-478f-9430-0f560675ece1)  
 [Security Concepts](../../../../docs/framework/wcf/feature-details/security-concepts.md)  
 [Securing Services and Clients](../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)
