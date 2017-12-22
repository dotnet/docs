---
title: "&lt;oidEntry&gt; Element"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/mscorlib/cryptographySettings/oidMap/oidEntry"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#oidEntry"
helpviewer_keywords: 
  - "<oidEntry> element"
  - "oidEntry element"
ms.assetid: 22fb88b0-bf27-489c-9ca0-e65950ac136c
caps.latest.revision: 11
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;oidEntry&gt; Element
Maps an ASN.1 object identifier (OID) to a friendly name.  
  
 \<configuration>  
\<mscorlib>  
\<cryptographySettings>  
\<oidMap>  
\<oidEntry>  
  
## Syntax  
  
```xml  
<oidEntry OID="object identifier number" name="friendly name" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|**OID**|Required attribute.<br /><br /> Specifies the ASN.1 OID corresponding to the algorithm implemented by your class.|  
|**name**|Required attribute.<br /><br /> Specifies the value for the **name** attribute in the [\<nameEntry>](../../../../../docs/framework/configure-apps/file-schema/cryptography/nameentry-element.md) tag.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`cryptographySettings`|Contains cryptography settings.|  
|`mscorlib`|Contains the `cryptographySettings` element.|  
|`oidMap`|Contains ASN.1 object identifier (OID) mappings to classes.|  
  
## Remarks  
 ASN.1 object identifiers identify algorithms in some cryptographic formats. Map object identifiers to friendly names for the algorithms you want to identify.  
  
## Example  
 The following example shows how to use the **\<oidEntry>** element to map an object identifier for the RIPEMD-160 hash algorithm to an implementation of that hash algorithm.  
  
```xml  
<configuration>  
   <mscorlib>  
      <cryptographySettings>  
         <cryptoNameMapping>  
            <cryptoClasses>  
               <cryptoClass   MyCrypto="MyCryptoClass, MyAssembly  
                  Culture=neutral, PublicKeyToken=a5d015c7d5a0b012,  
                  Version=1.0.0.0"/>  
            </cryptoClasses>  
            <nameEntry name="RIPEMD-160" class="MyCrypto"/>  
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
 [Configuring Cryptography Classes](../../../../../docs/framework/configure-apps/configure-cryptography-classes.md)  
 [Mapping Object Identifiers to Cryptography Algorithms](../../../../../docs/framework/configure-apps/map-object-identifiers-to-cryptography-algorithms.md)
