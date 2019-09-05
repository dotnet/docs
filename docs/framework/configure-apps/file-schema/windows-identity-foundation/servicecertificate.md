---
title: "<serviceCertificate>"
ms.date: "03/30/2017"
ms.assetid: 42c7f291-2ec3-43c5-8872-35897ff3c660
author: "BrucePerlerMS"
---
# \<serviceCertificate>
Configures the X.509 certificate that is used to encrypt and decrypt tokens.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.identityModel.services>**](system-identitymodel-services.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<federationConfiguration>**](federationconfiguration.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<serviceCertificate>**  
  
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
|[\<certificateReference>](certificatereference.md)|Specifies settings that are used to find and validate an X.509 certificate in a certificate store.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<federationConfiguration>](federationconfiguration.md)|Contains the settings that configure the <xref:System.IdentityModel.Services.WSFederationAuthenticationModule> (WSFAM) and the <xref:System.IdentityModel.Services.SessionAuthenticationModule> (SAM).|  
  
## Example  
 The following XML shows the use of the \<serviceCertificate> element. The XML is taken from the `CustomToken` sample.  
  
```xml  
<serviceCertificate>  
  <certificateReference x509FindType="FindBySubjectName" findValue="localhost" storeLocation="LocalMachine" storeName="My"/>  
</serviceCertificate>  
```
