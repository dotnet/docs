---
title: "Cryptography Settings Schema"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "configuration schema [.NET Framework], cryptography"
  - "elements [.NET Framework], cryptography"
  - "schema configuration settings"
  - "cryptography, settings schema"
  - "cryptography, mapping algorithm names"
  - "configuration sections [.NET Framework]"
  - "configuration settings [.NET Framework], cryptography"
ms.assetid: 1f55050a-b2a3-4868-a3c0-da20826150f3
---
# Cryptography Settings Schema
The cryptography settings schema contains elements that specify how to map friendly algorithm names to classes that implement cryptography algorithms.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<mscorlib>**](mscorlib-element-for-cryptography-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<cryptographySettings>**](cryptographysettings-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<cryptoNameMapping>**](cryptonamemapping-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<cryptoClasses>**](cryptoclasses-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<cryptoClass>**](cryptoclass-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<nameEntry>**](nameentry-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<oidMap>**](oidmap-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<oidEntry>**](oidentry-element.md)

|Element|Description|  
|-------------|-----------------|  
|[**\<cryptoClasses**>](cryptoclasses-element.md)|Contains a list of cryptography classes that have a mapping to a friendly name in the **\<nameEntry>** element.|  
|[**\<cryptoClass**>](cryptoclass-element.md)|Contains a cryptography class that has a mapping to a friendly name in the **\<nameEntry>** element.|  
|[**\<cryptographySettings**>](cryptographysettings-element.md)|Contains cryptography settings.|  
|[**\<cryptoNameMapping**>](cryptonamemapping-element.md)|Contains mappings of classes to friendly names.|  
|[**\<mscorlib>** element for cryptography settings](mscorlib-element-for-cryptography-settings.md)|Contains the **\<cryptographySettings>** element.|  
|[**\<nameEntry>**](nameentry-element.md)|Maps a class name to a friendly algorithm name, which allows one class to have many friendly names.|  
|[**\<oidEntry>**](oidentry-element.md)|Maps an ASN.1 object identifier (OID) to a friendly name.|  
|[**\<oidMap>**](oidmap-element.md)|Contains ASN.1 OID mappings to classes.|  
  
## See also

- [Configuration File Schema](../index.md)
- [Cryptographic Services](../../../../standard/security/cryptographic-services.md)
