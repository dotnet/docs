---
title: "&lt;servicePointManager&gt; Element (Network Settings)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#servicePointManager"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/settings/servicePointManager"
helpviewer_keywords: 
  - "servicePointManager element"
  - "<servicePointManager> element"
ms.assetid: 6e5def51-3646-4ef6-a7bd-c69151321bec
caps.latest.revision: 16
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;servicePointManager&gt; Element (Network Settings)
Configures connections to network resources.  
  
 \<configuration>  
\<system.net>  
\<settings>  
\<servicePointManager>  
  
## Syntax  
  
```xml  
<servicePointManager  
  checkCertificateName="true|false"  
  checkCertificateRevocationList="true|false"  
  encryptionPolicy="AllowNoEncryption|NoEncryption|RequireEncryption"  
  expect100Continue="true|false"  
  useNagleAlgorithm="true|false"  
  enableDnsRoundRobin="true|false"  
  dnsRefreshTimeout="time"  
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Attribute**|**Description**|  
|-------------------|---------------------|  
|`checkCertificateName`|Specifies whether the system should verify that the name on the certificate matches the server host name before using the certificate. The default value is `true`.|  
|`checkCertificateRevocationList`|Specifies whether the system should check whether the certificate has been revoked before using the certificate. The default value is `false`.|  
|`dnsRefreshTimeout`|Specifies how long Domain Name Service (DNS) resolutions are cached in conjunction with the DNS Round Robin option, in milliseconds. The default value is 120,000 milliseconds (two minutes).|  
|`enableDnsRoundRobin`|Specifies whether DNS resolutions of host names with multiple Internet Protocol (IP) addresses return all the addresses, or just the first one. The default value is `false`.|  
|`encryptionPolicy`|Specifies the encryption policy applied to an SSL/TLS session on a <xref:System.Net.ServicePointManager> instance. The possible values are equivalent to the values for the <xref:System.Net.Security.EncryptionPolicy> enumeration. The use of <xref:System.Security.Authentication.CipherAlgorithmType.Null> is required when the encryption policy is set to `NoEncryption`. The default value is `RequireEncryption`.|  
|`expect100Continue`|Specifies whether POST methods should expect to receive a `100-continue` response from the server. The default value is `true`.|  
|`useNagleAlgorithm`|Specifies whether connections controlled by the service point manager use the Nagle algorithm. The default value is `true`.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[Settings](../../../../../docs/framework/configure-apps/file-schema/network/settings-element-network-settings.md)|Configures basic network options for the <xref:System.Net> namespace.|  
  
## Remarks  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## See Also  
 <xref:System.Net.ServicePointManager>  
 <xref:System.Net.Security.EncryptionPolicy>  
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
