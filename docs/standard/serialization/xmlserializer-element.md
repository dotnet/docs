---
title: "&lt;xmlSerializer&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "<xmlSerializer> element"
  - "XML serialization, configuration"
  - "xmlSerializer element"
ms.assetid: d129d10c-3eb7-45d9-8098-5fa853825e47
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# &lt;xmlSerializer&gt; Element
Specifies whether an additional check of progress of the <xref:System.Xml.Serialization.XmlSerializer> is done.  
  
 \<configuration>  
\<system.xml.serialization>  
  
## Syntax  
  
```xml  
<xmlSerializer checkDeserializerAdvance = "true"|"false" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|**checkDeserializeAdvances**|Specifies whether the progress of the <xref:System.Xml.Serialization.XmlSerializer> is checked. Set the attribute to "true" or "false". The default is "true".|  
|**useLegacySerializationGeneration**|Specifies whether the <xref:System.Xml.Serialization.XmlSerializer> uses legacy serialization generation which generates assemblies by writing C# code to a file and then compiling it to an assembly. The default is **false**.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<system.xml.serialization> Element](../../../docs/standard/serialization/system-xml-serialization-element.md)|Contains configuration settings for the <xref:System.Xml.Serialization.XmlSerializer> and <xref:System.Xml.Serialization.XmlSchemaImporter> classes.|  
  
## Remarks  
 By default, the <xref:System.Xml.Serialization.XmlSerializer> provides an additional layer of security against potential denial of service attacks when deserializing untrusted data. It does so by attempting to detect infinite loops during deserialization. If such a condition is detected, an exception is thrown with the following message: "Internal error: deserialization failed to advance over underlying stream."  
  
 Receiving this message does not necessarily indicate that a denial of service attack is in progress. In some rare circumstances, the infinite loop detection mechanism produces a false positive and the exception is thrown for a legitimate incoming message. If you find that in your particular application legitimate messages are being rejected by this extra layer of protection, set **checkDeserializeAdvances** attribute to "false".  
  
## Example  
 The following code example sets the **checkDeserializeAdvances** attribute to "false".  
  
```xml  
<configuration>  
  <system.xml.serialization>  
    <xmlSerializer checkDeserializeAdvances="false" />  
  </system.xml.serialization>  
</configuration>  
```  
  
## See Also  
 <xref:System.Xml.Serialization.XmlSerializer>  
 [\<system.xml.serialization> Element](../../../docs/standard/serialization/system-xml-serialization-element.md)  
 [XML and SOAP Serialization](../../../docs/standard/serialization/xml-and-soap-serialization.md)
