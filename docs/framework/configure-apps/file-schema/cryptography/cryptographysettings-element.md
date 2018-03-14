---
title: "&lt;cryptographySettings&gt; Element"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/mscorlib/cryptographySettings"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#cryptographySettings"
helpviewer_keywords: 
  - "cryptographySettings element"
  - "<cryptographySettings> element"
ms.assetid: 6201b7da-bcb7-49f7-b9f5-ba1fe05573b9
caps.latest.revision: 11
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;cryptographySettings&gt; Element
Contains cryptography settings.  
  
 \<configuration>  
\<mscorlib>  
\<cryptographySettings>  
  
## Syntax  
  
```xml  
      <cryptographySettings>   
</cryptographySettings>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<cryptoNameMapping>](../../../../../docs/framework/configure-apps/file-schema/cryptography/cryptonamemapping-element.md)|Contains mappings of classes to friendly names.|  
|[\<oidMap>](../../../../../docs/framework/configure-apps/file-schema/cryptography/oidmap-element.md)|Contains ASN.1 object identifier (OID) mappings to classes.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`mscorlib`|Contains the `cryptographySettings` element.|  
  
## Example  
 The following example shows how use the **\<cryptographySettings>** element to contain cryptography name mappings and OID mappings. This example configures the runtime so that <xref:System.Security.Cryptography.HashAlgorithm.Create%2A?displayProperty=nameWithType> returns a `MyHashClass` object and the `MyCryptoClass` class maps to the object identifier 1.3.36.2.1.  
  
```xml  
<configuration>  
   <mscorlib>  
      <cryptographySettings>  
         <cryptoNameMapping>  
            <cryptoClasses>  
               <cryptoClass   MyHash="MyHashClass, MyAssembly  
                  Culture=neutral, PublicKeyToken=a5d015c7d5a0b012,  
                  Version=1.0.0.0"/>  
               <cryptoClass   MyCrypto="MyCryptoClass, MyAssembly  
                  Culture=neutral, PublicKeyToken=a5d015c7d5a0b012,  
                  Version=1.0.0.0"/>  
            </cryptoClasses>  
            <nameEntry name="System.Security.Cryptography.HashAlgorithm"  
                       class="MyHash"/>  
         </cryptoNameMapping>  
         <oidMap>  
            <oidEntry OID="1.3.36.3.2.1"   name="MyCryptoClass"/>  
         </oidMap>  
      </cryptographySettings>  
   </mscorlib>  
</configuration>  
```  
  
## See Also  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [Cryptography Settings Schema](../../../../../docs/framework/configure-apps/file-schema/cryptography/index.md)  
 [Cryptographic Services](../../../../../docs/standard/security/cryptographic-services.md)
