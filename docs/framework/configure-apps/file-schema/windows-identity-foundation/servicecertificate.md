---
title: "&lt;serviceCertificate&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 42c7f291-2ec3-43c5-8872-35897ff3c660
caps.latest.revision: 5
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;serviceCertificate&gt;
Configures the X.509 certificate that is used to encrypt and decrypt tokens.  
  
 \<system.identityModel.services>  
\<federationConfiguration>  
\<serviceCertificate>  
  
## Syntax  
  
```xml  
<system.identityModel.services>  
  <federationConfiguration>  
    <serviceCertificate>  
    </serviceCertificate>  
  </federationConfiguration>  
</system.identityModel.services>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<certificateReference>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/certificatereference.md)|Specifies settings that are used to find and validate an X.509 certificate in a certificate store.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<federationConfiguration>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/federationconfiguration.md)|Contains the settings that configure the <xref:System.IdentityModel.Services.WSFederationAuthenticationModule> (WSFAM) and the <xref:System.IdentityModel.Services.SessionAuthenticationModule> (SAM).|  
  
## Example  
 The following XML shows the use of the \<serviceCertificate> element. The XML is taken from the `CustomToken` sample.  
  
```xml  
<serviceCertificate>  
  <certificateReference x509FindType="FindBySubjectName" findValue="localhost" storeLocation="LocalMachine" storeName="My"/>  
</serviceCertificate>  
```
