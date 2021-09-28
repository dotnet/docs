---
description: "Learn more about: Denial of Service"
title: "Denial of Service"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "denial of service [WCF]"
ms.assetid: dfb150f3-d598-4697-a5e6-6779e4f9b600
---
# Denial of Service

Denial of service occurs when a system is overwhelmed in such a way that messages cannot be processed, or they are processed extremely slowly.  
  
## Excess Memory Consumption  

 A problem can occur when reading an XML document with a large number of unique local names, namespaces, or prefixes. If you are using a class that derives from <xref:System.Xml.XmlReader>, and you call either the <xref:System.Xml.XmlReader.LocalName%2A>, <xref:System.Xml.XmlReader.Prefix%2A> or <xref:System.Xml.XmlReader.NamespaceURI%2A> property for each item, the returned string is added to a <xref:System.Xml.NameTable>. The collection held by the <xref:System.Xml.NameTable> never decreases in size, creating a virtual "memory leak" of the string handles.  
  
 Mitigations include:  
  
- Derive from the <xref:System.Xml.NameTable> class and enforce a maximum size quota. (You cannot prevent the use of a <xref:System.Xml.NameTable> or switch the <xref:System.Xml.NameTable> when it is full.)  
  
- Avoid using the properties mentioned and instead use the <xref:System.Xml.XmlReader.MoveToAttribute%2A> method with the <xref:System.Xml.XmlReader.IsStartElement%2A> method where possible; those methods do not return strings and thus avoid the problem of overfilling the <xref:System.Xml.NameTable> collection.  
  
## Malicious Client Sends Excessive License Requests to Service  

 If a malicious client bombards a service with excessive license requests, it can cause the server to use excessive memory.  
  
 Mitigation: Use the following properties of the <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings> class:  
  
- <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings.MaxCachedCookies%2A>: controls the maximum number of time-bounded `SecurityContextToken`s that the server caches after `SPNego` or `SSL` negotiation.  
  
- <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings.IssuedCookieLifetime%2A>: controls the lifetime of the `SecurityContextTokens` that the server issues following `SPNego` or `SSL` negotiation. The server caches the `SecurityContextToken`s for this period of time.  
  
- <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings.MaxPendingSessions%2A>: controls the maximum number of secure conversations that are established at the server but for which no application messages have been processed. This quota prevents clients from establishing secure conversations at the service, thereby causing the service to maintain state per client, but never using them.  
  
- <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings.InactivityTimeout%2A>:  controls the maximum time the service keeps a secure conversation alive without receiving an application message from the client for the conversation. This quota prevents clients from establishing secure conversations at the service, thereby causing the service to maintain state per client, but never using them.  
  
## WSDualHttpBinding or Dual Custom Bindings Require Client Authentication  

 By default, the <xref:System.ServiceModel.WSDualHttpBinding> has security enabled. It is possible, however, that if the client authentication is disabled by setting the <xref:System.ServiceModel.MessageSecurityOverHttp.ClientCredentialType%2A> property to <xref:System.ServiceModel.MessageCredentialType.None>, a malicious user can cause a denial of service attack on a third service. This can occur because a malicious client can direct the service to send a stream of messages to a third service.  
  
 To mitigate this, do not set the property to `None`. Also be aware of this possibility when creating a custom binding that has a dual message pattern.  
  
## Auditing Event Log Can Be Filled  

 If a malicious user understands that auditing is enabled, that attacker can send invalid messages that cause audit entries to be written. If the audit log is filled in this manner, the auditing system fails.  
  
 To mitigate this, set the <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior.SuppressAuditFailure%2A> property to `true` and use the properties of the Event Viewer to control the auditing behavior. For more information about using the Event Viewer to view and manage event logs, see [Event Viewer](/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/cc766042(v=ws.11)). For more information, see [Auditing](auditing-security-events.md).  
  
## Invalid Implementations of IAuthorizationPolicy Can Cause Service to Become Unresponsive  

 Calling the <xref:System.IdentityModel.Policy.IAuthorizationPolicy.Evaluate%2A> method on a faulty implementation of the <xref:System.IdentityModel.Policy.IAuthorizationPolicy> interface can cause the service to become unresponsive.  
  
 Mitigation: Use only trusted code. That is, use only code that you have written and tested, or that comes from a trusted provider. Do not allow untrusted extensions of <xref:System.IdentityModel.Policy.IAuthorizationPolicy> to be plugged into your code without due consideration. This applies to all extensions used in a service implementation. WCF does not make any distinction between application code and foreign code that is plugged in using extensibility points.  
  
## Kerberos Maximum Token Size May Need Resizing  

 If a client belongs to a large number of groups (approximately 900, although the actual number varies depending on the groups), a problem may occur when a message header's block exceeds 64 kilobytes. In that case, you can increase the maximum Kerberos token size. You may also need to increase the maximum WCF message size to accommodate the larger Kerberos token.  
  
## Autoenrollment Results in Multiple Certificates with Same Subject Name for Machine  

 *Autoenrollment* is the capability of Windows Server 2003 to automatically enroll users and computers for certificates. When a machine is on a domain with the feature enabled, an X.509 certificate with the intended purpose of client authentication is automatically created and inserted into the local computer's Personal certificates store whenever a new machine is joined to the network. However, autoenrollment uses the same subject name for all certificates it creates in the cache.  
  
 The impact is that WCF services may fail to open on domains with autoenrollment. This occurs because the default service X.509 credential search criteria might be ambiguous because multiple certificates with the machine's fully qualified Domain Name System (DNS) name exist. One certificate originates from autoenrollment; the other might be a self-issued certificate.  
  
 To mitigate this, reference the exact certificate to use by using a more precise search criterion on the [\<serviceCredentials>](../../configure-apps/file-schema/wcf/servicecredentials.md). For example, use the <xref:System.Security.Cryptography.X509Certificates.X509FindType.FindByThumbprint> option, and specify the certificate by its unique thumbprint (hash).  
  
 For more information about the autoenrollment feature, see [Certificate Autoenrollment in Windows Server 2003](/previous-versions/windows/it-pro/windows-server-2003/cc778954(v=ws.10)).  
  
## Last of Multiple Alternative Subject Names Used for Authorization  

 In the rare case when an X.509 certificate contains multiple alternative subject names, and you authorize using the alternative subject name, authorization may fail.  
  
## Protect Configuration Files with ACLs  

 You can specify required and optional claims in code and configuration files for CardSpace issued tokens. This results in corresponding elements being emitted in `RequestSecurityToken` messages that are sent to the security token service. An attacker can modify code or configuration to remove required or optional claims, potentially getting the security token service to issue a token that does not allow access to the target service.  
  
 To mitigate: Require access to the computer to modify the configuration file. Use file access control lists (ACLs) to secure configuration files. WCF requires that code be in the application directory or the global assembly cache before it will allow such code to be loaded from configuration. Use directory ACLs to secure directories.  
  
## Maximum Number of Secure Sessions for a Service Is Reached  

 When a client is successfully authenticated by a service and a secure session is established with the service, the service keeps track of the session until the client cancels it or the session expires. Every established session counts against the limit for the maximum number of active simultaneous sessions with a service. When this limit is reached, clients that attempt to create a new session with that service are rejected until one or more active sessions expire or are canceled by a client. A client can have multiple sessions with a service, and each one of those sessions counts toward the limit.  
  
> [!NOTE]
> When you use stateful sessions, the previous paragraph does not apply. For more information about stateful sessions, see [How to: Create a Security Context Token for a Secure Session](how-to-create-a-security-context-token-for-a-secure-session.md).  
  
 To mitigate this, set the limit for the maximum number of active sessions and the maximum lifetime for a session by setting the <xref:System.ServiceModel.Channels.SecurityBindingElement> property of the <xref:System.ServiceModel.Channels.SecurityBindingElement> class.  
  
## See also

- [Security Considerations](security-considerations-in-wcf.md)
- [Information Disclosure](information-disclosure.md)
- [Elevation of Privilege](elevation-of-privilege.md)
- [Denial of Service](denial-of-service.md)
- [Replay Attacks](replay-attacks.md)
- [Tampering](tampering.md)
- [Unsupported Scenarios](unsupported-scenarios.md)
