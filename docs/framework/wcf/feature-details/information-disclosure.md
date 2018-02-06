---
title: "Information Disclosure"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4064c89f-afa6-444a-aa7e-807ef072131c
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Information Disclosure
Information disclosure enables an attacker to gain valuable information about a system. Therefore, always consider what information you are revealing and whether it can be used by a malicious user. The following lists possible information disclosure attacks and provides mitigations for each.  
  
## Message Security and HTTP  
 If you are using message-level security over an HTTP transport layer, be aware that message-level security does not protect HTTP headers. The only way to protect HTTP headers is to use HTTPS transport instead of HTTP. HTTPS transport causes the entire message, including the HTTP headers, to be encrypted using the Secure Sockets Layer (SSL) protocol.  
  
## Policy Information  
 Keeping policy secure is important, especially in federation scenarios where sensitive issued-token requirements or token-issuer information is exposed in policy. In these cases, the recommendation is to secure the federated service's policy endpoint to prevent attackers from obtaining information about the service, such as the type of claims to put in the issued token, or redirecting clients to malicious token issuers. For example, an attacker could discover user name/password pairs by reconfiguring the federated trust chain to terminate in an issuer that executed a man-in-the-middle attack. It is also recommended that federated clients who obtain their bindings through policy retrieval verify that they trust the issuers in the obtained federated trust chain. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] federation scenarios, see [Federation](../../../../docs/framework/wcf/feature-details/federation.md).  
  
## Memory Dumps Can Reveal Claim Information  
 When an application fails, log files, such as those produced by Dr. Watson, can contain the claim information. This information should not be exported to other entities, such as support teams; otherwise, the claim information that contains private data is also exported. You can mitigate this by not sending the log files to unknown entities. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Windows Server 2003](http://go.microsoft.com/fwlink/?LinkId=89160).  
  
## Endpoint Addresses  
 An endpoint address contains the information needed to communicate with an endpoint. SOAP security must include the address in full in the security negotiation messages that are exchanged in order to negotiate a symmetric key between a client and a server. Because security negotiation is a bootstrap process, the address headers cannot be encrypted during this process. Therefore, the address should not contain any confidential data; otherwise, it leads to information disclosure attacks.  
  
## Certificates Transferred Unencrypted  
 When you use an X.509 certificate to authenticate a client, the certificate is transferred in the clear, inside the SOAP header. Be aware of this as a potential personally identifiable information (PII) disclosure. This is not an issue for `TransportWithMessageCredential` mode, where the entire message is encrypted with transport-level security.  
  
## Service References  
 A service reference is a reference to another service. For example, a service may pass a service reference to a client in the course of an operation. The service reference is also used with a *trust identity verifier*, an internal component that ensures the identity of the target principal before disclosing information such as application data or credentials to the target. If the remote trust identity cannot be verified or is incorrect, the sender should ensure that no data was disclosed that could compromise itself, the application, or the user.  
  
 Mitigations include the following:  
  
-   Service references are assumed to be trustworthy. Take care whenever transferring service reference instances to ensure that they have not been tampered with.  
  
-   Some applications can present a user experience that allows interactive establishment of trust based on data in the service reference and trust data proven by the remote host. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides extensibility points for such a facility, but the user must implemented them.  
  
## NTLM  
 By default, in the Windows domain environment, Windows authentication uses the Kerberos protocol to authenticate and authorize users. If the Kerberos protocol cannot be used for some reason, NT LAN Manager (NTLM) is used as a fallback. You can disable this behavior by setting the <xref:System.ServiceModel.Security.WindowsClientCredential.AllowNtlm%2A> property to `false`. Issues to be aware of when allowing NTLM include:  
  
-   NTLM exposes the client user name. If the user name needs to be kept confidential, then set the `AllowNTLM` property on the binding to `false`.  
  
-   NTLM does not provide server authentication. Therefore, the client cannot ensure that it is communicating with the right service when you use NTLM as an authentication protocol.  
  
### Specifying Client Credentials or Invalid Identity Forces NTLM Usage  
 When creating a client, specifying client credentials without a domain name, or specifying an invalid server identity, causes NTLM to be used instead of the Kerberos protocol (if the `AlllowNtlm` property is set to `true`). Because  NTLM does not do server authentication, information can potentially be disclosed.  
  
 For example, it is possible to specify Windows client credentials without a domain name, as shown in the following [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)] code.  
  
```  
MyChannelFactory.Credentials.Windows.ClientCredential = new System.Net.NetworkCredential("username", "password");  
```  
  
 The code does not specify a domain name, and therefore NTLM will be used.  
  
 If the domain is specified, but an invalid service principal name is specified using the endpoint identity feature, then NTLM is used. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how endpoint identity is specified, see [Service Identity and Authentication](../../../../docs/framework/wcf/feature-details/service-identity-and-authentication.md).  
  
## See Also  
 [Security Considerations](../../../../docs/framework/wcf/feature-details/security-considerations-in-wcf.md)  
 [Elevation of Privilege](../../../../docs/framework/wcf/feature-details/elevation-of-privilege.md)  
 [Denial of Service](../../../../docs/framework/wcf/feature-details/denial-of-service.md)  
 [Tampering](../../../../docs/framework/wcf/feature-details/tampering.md)  
 [Unsupported Scenarios](../../../../docs/framework/wcf/feature-details/unsupported-scenarios.md)  
 [Replay Attacks](../../../../docs/framework/wcf/feature-details/replay-attacks.md)
