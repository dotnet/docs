---
title: "&lt;clientCredentials&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1e6eef0d-a34e-4d74-b0f7-f65d2181858d
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;clientCredentials&gt;
Specifies the credentials used to authenticate the client to a service.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<endpointBehaviors>  
\<behavior>  
\<clientCredentials>  
  
## Syntax  
  
```xml  
<clientCredentials type="String"  
      supportInteractive="Boolean" >  
   <clientCertificate>  
   </clientCertificate>  
   <digest>  
   </digest>  
   <isuedToken>  
   </isuedToken>  
   <peer>  
   </peer>  
   <serviceCertificate>  
   </serviceCertificate>  
   <windowsAuthentication>  
   </windowsAuthentication>  
</clientCredentials>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`supportInteractive`|A Boolean value that specifies whether an interactive user can be involved in selecting a client credential at runtime. The default value is `true`.|  
|`type`|A string that specifies the type of this configuration element.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<clientCertificate>](../../../../../docs/framework/configure-apps/file-schema/wcf/clientcertificate-of-clientcredentials-element.md)|Specifies the certificate used to authenticate the client to the service. This element is of type <xref:System.ServiceModel.Configuration.X509InitiatorCertificateClientElement>.|  
|[\<httpDigest>](../../../../../docs/framework/configure-apps/file-schema/wcf/httpdigest-element.md)|Specifies a digest used to authenticate the client to the service. This element is of type <xref:System.ServiceModel.Configuration.HttpDigestClientElement>.|  
|[\<issuedToken>](../../../../../docs/framework/configure-apps/file-schema/wcf/issuedtoken.md)|Specifies a custom token type used to authenticate the client to a Secure Token Service (STS). This element is of type <xref:System.ServiceModel.Configuration.IssuedTokenClientElement>.|  
|[\<peer>](../../../../../docs/framework/configure-apps/file-schema/wcf/peer-of-clientcredentials-element.md)|Specifies a current peer credential. This element is of type <xref:System.ServiceModel.Configuration.PeerCredentialElement>.|  
|[\<serviceCertificate>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicecertificate-of-clientcredentials-element.md)|Specifies the certificate used to authenticate the service to the client and provides a structure for setting certificate options. This certificate must be supplied out-of-band from the service to the client. This element is of type <xref:System.ServiceModel.Configuration.X509RecipientCertificateClientElement>.|  
|[\<windows>](../../../../../docs/framework/configure-apps/file-schema/wcf/windows-of-clientcredentials-element.md)|Specifies a Windows credential. The default is the credential of the current thread. This element is of type <xref:System.ServiceModel.Configuration.WindowsClientElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](../../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md)|Specifies an endpoint behavior.|  
  
## Remarks  
 Client credentials are used to authenticate the client to services in cases where mutual authentication is required. This configuration section can also be used to specify service certificates for scenarios where the client must secure messages to a service with the service's certificate.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ClientCredentialsElement>  
 <xref:System.ServiceModel.Description.ClientCredentials>  
 [Security Behaviors](../../../../../docs/framework/wcf/feature-details/security-behaviors-in-wcf.md)  
 [Securing Clients](../../../../../docs/framework/wcf/securing-clients.md)
