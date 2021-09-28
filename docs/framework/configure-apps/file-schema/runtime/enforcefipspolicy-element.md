---
description: "Learn more about: <enforceFIPSPolicy> Element"
title: "<enforceFIPSPolicy> Element"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "enforceFIPSPolicy element"
  - "FIPS"
  - "<enforceFIPSPolicy> element"
  - "Federal Information Processing Standards (FIPS)"
ms.assetid: c35509c4-35cf-43c0-bb47-75e4208aa24e
---
# \<enforceFIPSPolicy> Element

Specifies whether to enforce a computer configuration requirement that cryptographic algorithms must comply with the Federal Information Processing Standards (FIPS).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<enforceFIPSPolicy>**  
  
## Syntax  
  
```xml  
<enforceFIPSPolicy enabled="true|false" />  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|enabled|Required attribute.<br /><br /> Specifies whether to enable the enforcement of a computer configuration requirement that cryptographic algorithms must be compliant with FIPS.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`true`|If your computer is configured to require cryptographic algorithms to be FIPS compliant, that requirement is enforced. If a class implements an algorithm that is not compliant with FIPS, the constructors or `Create` methods for that class throw exceptions when they are run on that computer. This is the default.|  
|`false`|Cryptographic algorithms that are used by the application are not required to be compliant with FIPS, regardless of computer configuration.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  

 Starting with the .NET Framework 2.0, the creation of classes that implement cryptographic algorithms is controlled by the configuration of the computer. If the computer is configured to require algorithms to be compliant with FIPS, and a class implements an algorithm that is not compliant with FIPS, any attempt to create an instance of that class throws an exception. Constructors throw an <xref:System.InvalidOperationException> exception, and `Create` methods throw a <xref:System.Reflection.TargetInvocationException> exception with an inner <xref:System.InvalidOperationException> exception.  
  
 If your application runs on computers whose configurations require compliance with FIPS, and your application uses an algorithm that is not compliant with FIPS, you can use this element in your configuration file to prevent the common language runtime (CLR) from enforcing FIPS compliance. This element was introduced in the .NET Framework 2.0 Service Pack 1.  
  
## Example  

 The following example shows how to prevent the CLR from enforcing FIPS compliance.  
  
```xml  
<configuration>  
    <runtime>  
        <enforceFIPSPolicy enabled="false"/>  
    </runtime>  
</configuration>  
```  
  
## See also

- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
- [Cryptography Model](../../../../standard/security/cryptography-model.md)
