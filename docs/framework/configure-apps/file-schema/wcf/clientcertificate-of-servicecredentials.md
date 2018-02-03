---
title: "&lt;clientCertificate&gt; of &lt;serviceCredentials&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 90ad03aa-2317-43dd-8a72-6d24cdcad15c
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;clientCertificate&gt; of &lt;serviceCredentials&gt;
Defines an X.509 certificate used to sign and encrypt messages to a client form a service in a duplex communication pattern.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<serviceBehaviors>  
\<behavior>  
\<serviceCredentials>  
\<clientCertificate>  
  
## Syntax  
  
```xml  
<clientCertificate>  
 <certificate/>  
 <authentication/>  
</clientCertificate>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<authentication>](../../../../../docs/framework/configure-apps/file-schema/wcf/authentication-of-clientcertificate-element.md)|Specifies authentication options for the client certificate.|  
|[\<certificate>](../../../../../docs/framework/configure-apps/file-schema/wcf/certificate-of-clientcertificate-element.md)|Specifies the certificate to use.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<serviceCredentials>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicecredentials.md)|Specifies the credentials to be used in authenticating the service, and the client credential validation related settings.|  
  
## Remarks  
 This element is used when the service must have the client's certificate in advance to communicate securely with the client. This occurs when using the duplex communication pattern. In the more typical request/response pattern, the client includes its certificate in the request, which the service uses to encrypt and sign its response back to the client. In the duplex communication pattern, however, the service does not have a request from the client and therefore it needs the client's certificate in advance to secure the message to the client. Therefore you must obtain the client's certificate in an out-of-band negotiation, and specify the certificate using this element. For more information about duplex services, see [How to: Create a Duplex Contract](../../../../../docs/framework/wcf/feature-details/how-to-create-a-duplex-contract.md).  
  
 The certificate set in this element is used to encrypt messages to the client only for bindings that are configured with `MutualCertificateDuplex` message security authentication mode.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.X509InitiatorCertificateServiceElement>  
 <xref:System.ServiceModel.Configuration.ServiceCredentialsElement.ClientCertificate%2A>  
 <xref:System.ServiceModel.Configuration.X509InitiatorCertificateServiceElement>  
 <xref:System.ServiceModel.Description.ServiceCredentials.ClientCertificate%2A>  
 <xref:System.ServiceModel.Security.X509CertificateInitiatorServiceCredential>  
 [How to: Create a Duplex Contract](../../../../../docs/framework/wcf/feature-details/how-to-create-a-duplex-contract.md)  
 [Security Behaviors](../../../../../docs/framework/wcf/feature-details/security-behaviors-in-wcf.md)  
 [Working with Certificates](../../../../../docs/framework/wcf/feature-details/working-with-certificates.md)
