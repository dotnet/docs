---
title: "<cryptoClasses> Element"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/mscorlib/cryptographySettings/cryptoNameMapping/cryptoClasses"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#cryptoClasses"
helpviewer_keywords: 
  - "<cryptoClasses> element"
  - "cryptoClasses element"
ms.assetid: 290d5f96-946d-4f02-babb-1d31ec0b8295
---
# \<cryptoClasses> Element
Contains a list of cryptography classes that have a mapping to a friendly name in the [\<nameEntry>](nameentry-element.md) element.  
  
 \<configuration>  
\<mscorlib>  
\<cryptographySettings>  
\<cryptoNameMapping>  
\<cryptoClasses>  
  
## Syntax  
  
```xml  
<cryptoClasses>   
</cryptoClasses>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<cryptoClass>](cryptoclass-element.md)|Contains a cryptography class that has a mapping to a friendly name in the **\<nameEntry>** element.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`cryptographySettings`|Contains cryptography settings.|  
|`cryptoNameMapping`|Contains mappings of classes to friendly names.|  
|`mscorlib`|Contains the `cryptographySettings` element.|  
  
## Example  
 The following example shows how use the **\<cryptoClass>** element to reference a cryptography class and to configure the runtime. You can then pass the string "RSA" to the <xref:System.Security.Cryptography.CryptoConfig.CreateFromName%2A?displayProperty=nameWithType> method and use the <xref:System.Security.Cryptography.AsymmetricAlgorithm.Create%2A> method to return a `MyCryptoRSAClass` object.  
  
```xml  
<configuration>  
   <mscorlib>  
      <cryptographySettings>  
         <cryptoNameMapping>  
            <cryptoClasses>  
               <cryptoClass   MyCryptoRSA="MyCryptoRSAClass, MyAssembly  
                  Culture=neutral, PublicKeyToken=a5d015c7d5a0b012,  
                  Version=1.0.0.0"/>  
               <!-- Other cryptography classes go here. -->  
            </cryptoClasses>  
            <nameEntry name="RSA" class="MyCryptoRSA"/>  
            <nameEntry name="System.Security.Cryptography.AsymmetricAlgorithm"  
                       class="MyCryptoRSA"/>  
             <!-- Mappings to other cryptography classes go here. -->  
         </cryptoNameMapping>  
      </cryptographySettings>  
   </mscorlib>  
</configuration>  
```  
  
## See also

- <xref:System.Security.Cryptography>
- [Configuration File Schema](../index.md)
- [Cryptography Settings Schema](index.md)
- [Cryptographic Services](../../../../standard/security/cryptographic-services.md)
- [System.Security.Cryptography.CryptoConfig.CreateFromName](Overload:System.Security.Cryptography.CryptoConfig.CreateFromName)
- [Configuring Cryptography Classes](../../configure-cryptography-classes.md)
