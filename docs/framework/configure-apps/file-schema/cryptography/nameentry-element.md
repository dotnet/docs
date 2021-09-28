---
description: "Learn more about: <nameEntry> Element"
title: "<nameEntry> Element"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#nameEntry"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/mscorlib/cryptographySettings/cryptoNameMapping/nameEntry"
helpviewer_keywords: 
  - "<nameEntry> element"
  - "nameEntry element"
ms.assetid: 7d7535e9-4b4a-4b8c-82e2-e40dff5a7821
---
# \<nameEntry> Element

Maps a class name to a friendly algorithm name, which allows one class to have many friendly names.  
  
[**\<configuration>**](../configuration-element.md)  
&nbsp;&nbsp;[**\<mscorlib>**](mscorlib-element-for-cryptography-settings.md)  
&nbsp;&nbsp;&nbsp;&nbsp;[**\<cryptographySettings>**](cryptographysettings-element.md)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<cryptoNameMapping>**](cryptonamemapping-element.md)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<nameEntry>**  
  
## Syntax  
  
```xml  
<nameEntry name="friendly name" Class="class name" />  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|**name**|Required attribute.<br /><br /> Specifies the friendly name of the algorithm that the cryptography class implements.|  
|**class**|Required attribute.<br /><br /> Specifies the value for the **name** attribute in the [\<cryptoClass>](cryptoclass-element.md) element.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`system.web`|Specifies the root element for the ASP.NET configuration section.|  
  
## Remarks  

 The **name** attribute can be the name of one of the abstract classes found in the <xref:System.Security.Cryptography> namespace. When you call the **Create** method on an abstract cryptography class, the abstract class name is passed to the <xref:System.Security.Cryptography.CryptoConfig.CreateFromName%2A> method. **CreateFromName** returns an instance of the type indicated by the **class** attribute. If the **name** attribute is a short name, such as RSA, you can use that name when calling the **CreateFromName** method.  
  
## Example  

 The following example shows how to use the **\<nameEntry>** element to reference a cryptography class and to configure the runtime. You can then pass the string "RSA" to the <xref:System.Security.Cryptography.CryptoConfig.CreateFromName%2A?displayProperty=nameWithType> method and use the <xref:System.Security.Cryptography.AsymmetricAlgorithm.Create%2A> method to return a `MyCryptoRSAClass` object.  
  
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
