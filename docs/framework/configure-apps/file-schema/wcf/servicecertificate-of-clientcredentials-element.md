---
title: "&lt;serviceCertificate&gt; of &lt;clientCredentials&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e50c0ac5-f0df-4c90-b54b-fc602c1f84ea
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;serviceCertificate&gt; of &lt;clientCredentials&gt; Element
Specifies a certificate to use when authenticating a service to the client.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<endpointBehaviors>  
\<behavior>  
\<clientCredentials>  
\<serviceCertificate>  
  
## Syntax  
  
```xml  
<serviceCertificate />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<defaultCertificate>](../../../../../docs/framework/configure-apps/file-schema/wcf/defaultcertificate-element.md)|Specifies an X.509 certificate to be used when a service or STS does not provide one via a negotiation protocol.|  
|[\<scopedCertificates>](../../../../../docs/framework/configure-apps/file-schema/wcf/scopedcertificates-element.md)|Represents a collection of X.509 certificates provided by specific services (scoped) for authentication. This collection is typically used to specify the service certificates for Security Token Services in a federated scenario.|  
|[\<authentication>](../../../../../docs/framework/configure-apps/file-schema/wcf/authentication-of-servicecertificate-element.md)|Specifies authentication behaviors for service certificates used by a client.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<clientCredentials>](../../../../../docs/framework/configure-apps/file-schema/wcf/clientcredentials.md)|Specifies the credentials used by the client to authenticate itself to a service.|  
  
## Remarks  
 This configuration element specifies the settings used by the client to validate the certificate presented by the service using SSL authentication. It also contains any certificate for the service that is explicitly configured on the client to use for encrypting messages to the service using message security.  
  
 The attributes of the `serviceCertificate` element are identical to the attributes of the [\<clientCertificate>](../../../../../docs/framework/configure-apps/file-schema/wcf/clientcertificate-of-clientcredentials-element.md).  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ClientCredentialsElement>  
 <xref:System.ServiceModel.Configuration.ClientCredentialsElement.ServiceCertificate%2A>  
 <xref:System.ServiceModel.Description.ClientCredentials>  
 <xref:System.ServiceModel.Description.ClientCredentials.ServiceCertificate%2A>  
 <xref:System.ServiceModel.Configuration.X509RecipientCertificateClientElement>  
 <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential>  
 [Security Behaviors](../../../../../docs/framework/wcf/feature-details/security-behaviors-in-wcf.md)  
 [Securing Clients](../../../../../docs/framework/wcf/securing-clients.md)  
 [Working with Certificates](../../../../../docs/framework/wcf/feature-details/working-with-certificates.md)  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)
