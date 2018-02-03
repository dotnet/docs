---
title: "Best Practices for Security in WCF"
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
  - "best practices [WCF], security"
ms.assetid: 3639de41-1fa7-4875-a1d7-f393e4c8bd69
caps.latest.revision: 19
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Best Practices for Security in WCF
The following sections list the best practices to consider when creating secure applications using [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)]. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] security, see [Security Considerations](../../../../docs/framework/wcf/feature-details/security-considerations-in-wcf.md), [Security Considerations for Data](../../../../docs/framework/wcf/feature-details/security-considerations-for-data.md), and [Security Considerations with Metadata](../../../../docs/framework/wcf/feature-details/security-considerations-with-metadata.md).  
  
## Identify Services Performing Windows Authentication with SPNs  
 Services can be identified with either user principal names (UPNs) or service principal names (SPNs). Services running under machine accounts such as network service have an SPN identity corresponding to the machine they're running. Services running under user accounts have a UPN identity corresponding to the user they're running as, although the `setspn` tool can be used to assign an SPN to the user account. Configuring a service so it can be identified via SPN and configuring the clients connecting to the service to use that SPN can make certain attacks more difficult. This guidance applies to bindings using Kerberos or SSPI negotiation.  Clients should still specify an SPN in the case where SSPI falls back to NTLM.  
  
## Verify Service Identities in WSDL  
 WS-SecurityPolicy allows services to publish information about their own identities in metadata. When retrieved via `svcutil` or other methods such as <xref:System.ServiceModel.Description.WsdlImporter>, this identity information is translated to the identity properties of the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service endpoint addresses. Clients which do not verify that these service identities are correct and valid effectively bypass service authentication. A malicious service can exploit such clients to execute credential forwarding and other "man in the middle" attacks by changing the identity claimed in its WSDL.  
  
## Use X509 Certificates Instead of NTLM  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] offers two mechanisms for peer-to-peer authentication: X509 certificates (used by peer channel) and Windows authentication where an SSPI negotiation downgrades from Kerberos to NTLM.  Certificate-based authentication using key sizes of 1024 bits or more is preferred to NTLM for several reasons:  
  
-   the availability of mutual authentication,  
  
-   the use of stronger cryptographic algorithms, and  
  
-   the greater difficulty of utilizing forwarded X509 credentials.  
  
 For an overview of NTLM forwarding attacks, go to [http://msdn.microsoft.com/msdnmag/issues/06/09/SecureByDesign/default.aspx](http://go.microsoft.com/fwlink/?LinkId=109571).  
  
## Always Revert After Impersonation  
 When using APIs that enable impersonation of a client, be sure to revert to the original identity. For example, when using the <xref:System.Security.Principal.WindowsIdentity> and <xref:System.Security.Principal.WindowsImpersonationContext>, use the C# `using` statement or the [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)]`Using` statement, as shown in the following code. The <xref:System.Security.Principal.WindowsImpersonationContext> class implements the <xref:System.IDisposable> interface, and therefore the common language runtime (CLR) automatically reverts to the original identity once the code leaves the `using` block.  
  
 [!code-csharp[c_SecurityBestPractices#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_securitybestpractices/cs/source.cs#1)]
 [!code-vb[c_SecurityBestPractices#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securitybestpractices/vb/source.vb#1)]  
  
## Impersonate Only as Needed  
 Using the <xref:System.Security.Principal.WindowsIdentity.Impersonate%2A> method of the <xref:System.Security.Principal.WindowsIdentity> class, it is possible to use impersonation in a very controlled scope. This is in contrast to using the <xref:System.ServiceModel.OperationBehaviorAttribute.Impersonation%2A> property of the <xref:System.ServiceModel.OperationBehaviorAttribute>, which allows impersonation for the scope of the entire operation. Whenever possible, control the scope of impersonation by using the more precise <xref:System.Security.Principal.WindowsIdentity.Impersonate%2A> method.  
  
## Obtain Metadata from Trusted Sources  
 Be sure you trust the source of your metadata and make sure that no one has tampered with the metadata. Metadata retrieved using the HTTP protocol is sent in clear text and can be tampered with. If the service uses the <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpsGetEnabled%2A> and <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpsGetUrl%2A> properties, use the URL supplied by the service creator to download the data using the HTTPS protocol.  
  
## Publish Metadata Using Security  
 To prevent tampering with a service's published metadata, secure the metadata exchange endpoint with transport or message-level security. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Publishing Metadata Endpoints](../../../../docs/framework/wcf/publishing-metadata-endpoints.md) and [How to: Publish Metadata for a Service Using Code](../../../../docs/framework/wcf/feature-details/how-to-publish-metadata-for-a-service-using-code.md).  
  
## Ensure Use of Local Issuer  
 If an issuer address and binding are specified for a given binding, the local issuer is not used for endpoints that use that binding. Clients who expect to always use the local issuer should ensure that they do not use such a binding or that they modify the binding such that the issuer address is null.  
  
## SAML Token Size Quotas  
 When Security Assertions Markup Language (SAML) tokens are serialized in messages, either when they are issued by a Security Token Service (STS) or when clients present them to services as part of authentication, the maximum message size quota must be sufficiently large to accommodate the SAML token and the other message parts. In normal cases, the default message size quotas are sufficient. However, in cases where a SAML token is large because it contains hundreds of claims, the quotas should be increased to accommodate the serialized token. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] quotas, see [Security Considerations for Data](../../../../docs/framework/wcf/feature-details/security-considerations-for-data.md).  
  
## Set SecurityBindingElement.IncludeTimestamp to True on Custom Bindings  
 When you create a custom binding, you must set <xref:System.ServiceModel.Channels.SecurityBindingElement.IncludeTimestamp%2A> to `true`. Otherwise, if <xref:System.ServiceModel.Channels.SecurityBindingElement.IncludeTimestamp%2A> is set to `false`, and the client is using an asymmetric key-based token such as an X509 certificate, the message will not be signed.  
  
## See Also  
 [Security Considerations](../../../../docs/framework/wcf/feature-details/security-considerations-in-wcf.md)  
 [Security Considerations for Data](../../../../docs/framework/wcf/feature-details/security-considerations-for-data.md)  
 [Security Considerations with Metadata](../../../../docs/framework/wcf/feature-details/security-considerations-with-metadata.md)
