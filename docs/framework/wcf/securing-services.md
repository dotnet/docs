---
title: "Securing Services"
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
  - "configuration [WCF], securing services"
  - "WCF security"
  - "WCF, security"
ms.assetid: f0ecc6f7-f4b5-42a4-9cb1-b02e28e26620
caps.latest.revision: 28
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Securing Services
Security of a [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] service consists of two primary requirements: transfer security and authorization. (A third requirement, auditing of security events, is described in [Auditing](../../../docs/framework/wcf/feature-details/auditing-security-events.md).) In brief, transfer security includes authentication (verifying the identity of both the service and the client), confidentiality (message encryption), and integrity (digital signing to detect tampering). Authorization is the control of access to resources, for example, allowing only privileged users to read a file. Using features of [!INCLUDE[indigo2](../../../includes/indigo2-md.md)], the two primary requirements are easily implemented.  
  
 With the exception of the <xref:System.ServiceModel.BasicHttpBinding> class (or the [\<basicHttpBinding>](../../../docs/framework/configure-apps/file-schema/wcf/basichttpbinding.md) element in configuration), transfer security is enabled by default for all of the predefined bindings. The topics in this section cover two basic scenarios: implementing transfer security and authorization on an intranet service hosted on Internet Information Services (IIS), and implementing transfer security and authorization on a service hosted on IIS.  
  
> [!NOTE]
>  Windows XP Home does not support Windows authentication. Therefore, you should not run a service on that system.  
  
## Security Basics  
 Security relies on *credentials*. A credential proves that an entity is who it claims to be. (An *entity* can be a person, a software process, a company, or anything that can be authorized.) For example, a client of a service makes a *claim* of *identity*, and the credential proves that claim in some manner. In a typical scenario, an exchange of credentials occurs. First, a service makes a claim of its identity and proves it to the client with a credential. Conversely, the client makes a claim of identity and presents a credential to the service. If both parties trust the other's credentials, then a *secure context* can be established in which all messages are exchanged in confidentiality, and all messages are signed to protect their integrity. After the service establishes the client's identity, it can then match the claims in the credential to a *role* or *membership* in a group. In either case, using the role or the group to which the client belongs, the service *authorizes* the client to perform a limited set of operations based on the role or group privileges.  
  
## Windows Security Mechanisms  
 If the client and the service computer are both on a Windows domain that requires both to log on to the network, the credentials are provided by Windows infrastructure. In that case, the credentials are established when a computer user logs on to the network. Every user and every computer on the network must be validated as belonging to the trusted set of users and computers. On a Windows system, every such user and computer is also known as a *security principal*.  
  
 On a Windows domain backed by a *Kerberos* controller, the Kerberos controller uses a scheme based on granting tickets to each security principal. The tickets the controller grants are trusted by other ticket granters in the system. Whenever an entity tries to perform some operation or access a *resource* (such as a file or directory on a machine), the ticket is examined for its validity and, if it passes, the principal is granted another ticket for the operation. This method of granting tickets is more efficient than the alternative of trying to validate the principal for every operation.  
  
 An older, less-secure mechanism used on Windows domains is NT LAN Manager (NTLM). In cases where Kerberos cannot be used (typically outside of a Windows domain, such as in a workgroup), NTLM can be used as an alternative. NTLM is also available as a security option for IIS.  
  
 On a Windows system, authorization works by assigning each computer and user to a set of roles and groups. For example, every Windows computer must be set up and controlled by a person (or group of people) in the role of the *administrator*. Another role is that of the *user*, which has a much more constrained set of permissions. In addition to the role, users are assigned to groups. A group allows multiple users to perform in the same role. In practice, therefore, a Windows machine is administered by assigning users to groups. For example, several users can be assigned to the group of users of a computer, and a much more constrained set of users can be assigned to the group of administrators. On a local machine, an administrator can also create new groups and assign other users (or even other groups) to the group.  
  
 On a computer running Windows, every folder in a directory can be protected. That is, you can select a folder and control who can access the files, and whether or not they can copy the file, or (in the most privileged case) change a file, delete a file, or add files to the folder. This is known as access control, and the mechanism for it is known as the access control list (ACL). When creating the ACL, you can assign access privileges to any group or groups, as well as individual members of a domain.  
  
 The [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] infrastructure is designed to use these Windows security mechanisms. Therefore, if you are creating a service that is deployed on an intranet, and whose clients are restricted to members of the Windows domain, security is easily implemented. Only valid users can log on to the domain. After users are logged on, the Kerberos controller enables each user to establish secure contexts with any other computer or application. On a local machine, groups can be easily created, and when protecting specific folders, those groups can be used to assign access privileges on the computer.  
  
## Implementing Windows Security on Intranet Services  
 To secure an application that runs exclusively on a Windows domain, you can use the default security settings of either the <xref:System.ServiceModel.WSHttpBinding> or the <xref:System.ServiceModel.NetTcpBinding> binding. By default, anyone on the same Windows domain can access [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services. Because those users have logged on to the network, they are trusted. The messages between a service and a client are encrypted for confidentiality and signed for integrity. [!INCLUDE[crabout](../../../includes/crabout-md.md)] how to create a service that uses Windows security, see [How to: Secure a Service with Windows Credentials](../../../docs/framework/wcf/how-to-secure-a-service-with-windows-credentials.md).  
  
### Authorization Using the PrincipalPermissionAttribute Class  
 If you need to restrict the access of resources on a computer, the easiest way is to use the <xref:System.Security.Permissions.PrincipalPermissionAttribute> class. This attribute enables you to restrict the invocation of service operations by demanding that the user be in a specified Windows group or role, or to be a specific user. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [How to: Restrict Access with the PrincipalPermissionAttribute Class](../../../docs/framework/wcf/how-to-restrict-access-with-the-principalpermissionattribute-class.md).  
  
### Impersonation  
 Impersonation is another mechanism that you can use to control access to resources. By default, a service hosted by IIS will run under the identity of the ASPNET account. The ASPNET account can access only the resources for which it has permission. However, it is possible to set the ACL for a folder to exclude the ASPNET service account, but allow certain other identities to access the folder. The question then becomes how to allow those users to access the folder if the ASPNET account is not allowed to do so. The answer is to use impersonation, whereby the service is allowed to use the credentials of the client to access a particular resource. Another example is when accessing a SQL Server database to which only certain users have permission. [!INCLUDE[crabout](../../../includes/crabout-md.md)] using impersonation, see [How to: Impersonate a Client on a Service](../../../docs/framework/wcf/how-to-impersonate-a-client-on-a-service.md) and [Delegation and Impersonation](../../../docs/framework/wcf/feature-details/delegation-and-impersonation-with-wcf.md).  
  
## Security on the Internet  
 Security on the Internet consists of the same requirements as security on an intranet. A service needs to present its credentials to prove its authenticity, and clients need to prove their identity to the service. Once a client's identity is proven, the service can control how much access the client has to resources. However, due to the heterogeneous nature of the Internet, the credentials presented differ from those used on a Windows domain. Whereas a Kerberos controller handles the authentication of users on a domain with tickets for credentials, on the Internet, services and clients rely on any one of several different ways to present credentials. The objective of this topic, however, is to present a common approach that enables you to create a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service that is accessible on the Internet.  
  
### Using IIS and ASP.NET  
 The requirements of Internet security, and the mechanisms to solve those problems, are not new. IIS is Microsoft's Web server for the Internet and has many security features that address those problems; in addition, [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] includes security features that [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services can use. To take advantage of these security features, host an [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service on IIS.  
  
#### Using ASP.NET Membership and Role Providers  
 ASP.NET includes a membership and role provider. The provider is a database of user name/password pairs for authenticating callers that also allows you to specify each caller's access privileges. With [!INCLUDE[indigo2](../../../includes/indigo2-md.md)], you can easily use a pre-existing membership and role provider through configuration. For a sample application that demonstrates this, see the [Membership and Role Provider](../../../docs/framework/wcf/samples/membership-and-role-provider.md) sample.  
  
### Credentials Used by IIS  
 Unlike a Windows domain backed by a Kerberos controller, the Internet is an environment without a single controller to manage the millions of users logging on at any time. Instead, credentials on the Internet most often are in the form of X.509 certificates (also known as Secure Sockets Layer, or SSL, certificates). These certificates are typically issued by a *certification authority*, which can be a third-party company that vouches for the authenticity of the certificate and the person it has been issued to. To expose your service on the Internet, you must also supply such a trusted certificate to authenticate your service.  
  
 The question arises at this point, how do you get such a certificate? One approach is to go to a third-party certification authority, such as Authenticode or VeriSign, when you are ready to deploy your service, and purchase a certificate for your service. However, if you are in the development phase with [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] and not yet ready to commit to purchasing a certificate, tools and techniques exist for creating X.509 certificates that you can use to simulate a production deployment. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Working with Certificates](../../../docs/framework/wcf/feature-details/working-with-certificates.md).  
  
## Security Modes  
 Programming [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] security entails a few critical decision points. One of the most basic is the choice of *security mode*. The two major security modes are *transport mode* and *message mode*.  
  
 A third mode, which combines the semantics of both major modes, is *transport with message credentials mode*.  
  
 The security mode determines how messages are secured, and each choice has advantages and disadvantages, as explained below. [!INCLUDE[crabout](../../../includes/crabout-md.md)] setting the security mode, see [How to: Set the Security Mode](../../../docs/framework/wcf/how-to-set-the-security-mode.md).  
  
#### Transport Mode  
 There are several layers between the network and the application. One of these is the *transport* layer*,* which manages the transfer of messages between endpoints. For the present purpose, it is only required that you understand that [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] uses several transport protocols, each of which can secure the transfer of messages. ([!INCLUDE[crabout](../../../includes/crabout-md.md)] transports, see [Transports](../../../docs/framework/wcf/feature-details/transports.md).)  
  
 A commonly used protocol is HTTP; another is TCP. Each of these protocols can secure message transfer by a mechanism (or mechanisms) particular to the protocol. For example, the HTTP protocol is secured using SSL over HTTP, commonly abbreviated as "HTTPS." Thus, when you select the transport mode for security, you are choosing to use the mechanism as dictated by the protocol. For example, if you select the <xref:System.ServiceModel.WSHttpBinding> class and set its security mode to Transport, you are selecting SSL over HTTP (HTTPS) as the security mechanism. The advantage of the transport mode is that it is more efficient than message mode because security is integrated at a comparatively low level. When using transport mode, the security mechanism must be implemented according to the specification for the transport, and thus messages can flow securely only from point-to-point over the transport.  
  
#### Message Mode  
 In contrast, message mode provides security by including the security data as part of every message. Using XML and SOAP security headers, the credentials and other data needed to ensure the integrity and confidentiality of the message are included with every message. Every message includes security data, so it results in a toll on performance because each message must be individually processed. (In transport mode, once the transport layer is secured, all messages flow freely.) However, message security has one advantage over transport security: it is more flexible. That is, the security requirements are not determined by the transport. You can use any type of client credential to secure the message. (In transport mode, the transport protocol determines the type of client credential that you can use.)  
  
#### Transport with Message Credentials  
 The third mode combines the best of both transport and message security. In this mode, transport security is used to efficiently ensure the confidentiality and integrity of every message. At the same time, every message includes its credential data, which allows the message to be authenticated. With authentication, authorization can also be implemented. By authenticating a sender, access to resources can be granted (or denied) according to the sender's identity.  
  
## Specifying the Client Credential Type and Credential Value  
 After you have selected a security mode, you may also want to specify a client credential type. The client credential type specifies what type a client must use to authenticate itself to the server.  
  
 Not all scenarios require a client credential type, however. Using SSL over HTTP (HTTPS), a service authenticates itself to the client. As part of this authentication, the service's certificate is sent to the client in a process called *negotiation*. The SSL-secured transport ensures that all messages are confidential.  
  
 If you are creating a service that requires that the client be authenticated, your choice of a client credential type depends on the transport and mode selected. For example, using the HTTP transport and choosing transport mode gives you several choices, such as Basic, Digest, and others. ([!INCLUDE[crabout](../../../includes/crabout-md.md)] these credential types, see [Understanding HTTP Authentication](../../../docs/framework/wcf/feature-details/understanding-http-authentication.md).)  
  
 If you are creating a service on a Windows domain that will be available only to other users of the network, the easiest to use is the Windows client credential type. However, you may also need to provide a service with a certificate. This is shown in [How to: Specify Client Credential Values](../../../docs/framework/wcf/how-to-specify-client-credential-values.md).  
  
#### Credential Values  
 A *credential value* is the actual credential the service uses. Once you have specified a credential type, you may also need to configure your service with the actual credentials. If you have selected Windows (and the service will run on a Windows domain), then you do not specify an actual credential value.  
  
## Identity  
 In [!INCLUDE[indigo2](../../../includes/indigo2-md.md)], the term *identity* has different meanings to the server and the client. In brief, when running a service, an identity is assigned to the security context after authentication. To view the actual identity, check the <xref:System.ServiceModel.ServiceSecurityContext.WindowsIdentity%2A> and <xref:System.ServiceModel.ServiceSecurityContext.PrimaryIdentity%2A> properties of the <xref:System.ServiceModel.ServiceSecurityContext> class. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [How to: Examine the Security Context](../../../docs/framework/wcf/how-to-examine-the-security-context.md).  
  
 In contrast, on the client, identity is used to validate the service. At design time, a client developer can set the [\<identity>](../../../docs/framework/configure-apps/file-schema/wcf/identity.md) element to a value obtained from the service. At run time, the client checks the value of the element against the actual identity of the service. If the check fails, the client terminates the communication. The value can be a user principal name (UPN) if the service runs under a particular user's identity or a service principal name (SPN) if the service runs under a machine account. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Service Identity and Authentication](../../../docs/framework/wcf/feature-details/service-identity-and-authentication.md). The credential could also be a certificate, or a field found on a certificate that identifies the certificate.  
  
## Protection Levels  
 The `ProtectionLevel` property occurs on several attribute classes (such as the <xref:System.ServiceModel.ServiceContractAttribute> and the <xref:System.ServiceModel.OperationContractAttribute> classes). The protection level is a value that specifies whether the messages (or message parts) that support a service are signed, signed and encrypted, or sent without signatures or encryption. [!INCLUDE[crabout](../../../includes/crabout-md.md)] the property, see [Understanding Protection Level](../../../docs/framework/wcf/understanding-protection-level.md), and for programming examples, see [How to: Set the ProtectionLevel Property](../../../docs/framework/wcf/how-to-set-the-protectionlevel-property.md). [!INCLUDE[crabout](../../../includes/crabout-md.md)] designing a service contract with the `ProtectionLevel` in context, see [Designing Service Contracts](../../../docs/framework/wcf/designing-service-contracts.md).  
  
## See Also  
 <xref:System.ServiceModel>  
 <xref:System.ServiceModel.Description.ServiceCredentials>  
 <xref:System.ServiceModel.ServiceContractAttribute>  
 <xref:System.ServiceModel.OperationContractAttribute>  
 [Service Identity and Authentication](../../../docs/framework/wcf/feature-details/service-identity-and-authentication.md)  
 [Understanding Protection Level](../../../docs/framework/wcf/understanding-protection-level.md)  
 [Delegation and Impersonation](../../../docs/framework/wcf/feature-details/delegation-and-impersonation-with-wcf.md)  
 [Designing Service Contracts](../../../docs/framework/wcf/designing-service-contracts.md)  
 [Security](../../../docs/framework/wcf/feature-details/security.md)  
 [Security Overview](../../../docs/framework/wcf/feature-details/security-overview.md)  
 [How to: Set the ProtectionLevel Property](../../../docs/framework/wcf/how-to-set-the-protectionlevel-property.md)  
 [How to: Secure a Service with Windows Credentials](../../../docs/framework/wcf/how-to-secure-a-service-with-windows-credentials.md)  
 [How to: Set the Security Mode](../../../docs/framework/wcf/how-to-set-the-security-mode.md)  
 [How to: Specify the Client Credential Type](../../../docs/framework/wcf/how-to-specify-the-client-credential-type.md)  
 [How to: Restrict Access with the PrincipalPermissionAttribute Class](../../../docs/framework/wcf/how-to-restrict-access-with-the-principalpermissionattribute-class.md)  
 [How to: Impersonate a Client on a Service](../../../docs/framework/wcf/how-to-impersonate-a-client-on-a-service.md)  
 [How to: Examine the Security Context](../../../docs/framework/wcf/how-to-examine-the-security-context.md)
