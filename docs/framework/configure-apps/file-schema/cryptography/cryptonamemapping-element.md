---
description: "Learn more about: <cryptoNameMapping> Element"
title: "<cryptoNameMapping> Element"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#cryptoNameMapping"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/mscorlib/cryptographySettings/cryptoNameMapping"
helpviewer_keywords: 
  - "<cryptoNameMapping> element"
  - "cryptoNameMapping element"
ms.assetid: c59c9494-149b-4ce6-b38d-371f896ae85c
---
# \<cryptoNameMapping> Element

Contains mappings of classes to friendly names.  

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<mscorlib>**](mscorlib-element-for-cryptography-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<cryptographySettings>**](cryptographysettings-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<cryptoNameMapping>**

## Syntax  
  
```xml  
      <cryptoNameMapping>
</cryptoNameMapping>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  

 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`cryptoClasses`|Contains a list of cryptography classes that have a mapping to a friendly name in the **\<nameEntry>** element.|  
|`nameEntry`|Maps a class name to a friendly algorithm name, which allows one class to have many friendly names.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`cryptographySettings`|Contains cryptography settings.|  
|`cryptoNameMapping`|Contains mappings of classes to friendly names.|  
|`mscorlib`|Contains the \<cryptographySettings> element.|  
  
## Example  

 The following example shows how to use the **\<cryptoNameMapping>** element to reference a cryptography class and to configure the runtime. You can then pass the string "RSA" to the <xref:System.Security.Cryptography.CryptoConfig.CreateFromName%2A?displayProperty=nameWithType> method and use the <xref:System.Security.Cryptography.AsymmetricAlgorithm.Create%2A> method to return a `MyCryptoRSAClass` object.  
  
```xml  
<configuration>  
   <mscorlib>  
      <cryptographySettings>  
         <cryptoNameMapping>  
            <cryptoClasses>  
               <cryptoClass   MyCryptoRSA="MyCryptoRSAClass, MyAssembly  
                  Culture=neutral, PublicKeyToken=a5d015c7d5a0b012,  
                  Version=1.0.0.0"/>  
            </cryptoClasses>  
            <nameEntry name="RSA" class="MyCryptoRSA"/>  
            <nameEntry name="System.Security.Cryptography.AsymmetricAlgorithm"  
                       class="MyCryptoRSA"/>  
         </cryptoNameMapping>  
      </cryptographySettings>  
   </mscorlib>  
</configuration>  
```  
  
## See also

- [Configuration File Schema](../index.md)
- [Cryptography Settings Schema](index.md)
- [Cryptographic Services](../../../../standard/security/cryptographic-services.md)
- [Configuring Cryptography Classes](../../configure-cryptography-classes.md)
