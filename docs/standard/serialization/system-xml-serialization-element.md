---
title: "&lt;system.xml.serialization&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "system.xml.serialization element"
  - "XML serialization, configuration"
  - "<system.xml.serialization> element"
ms.assetid: 3ce45919-388a-418c-8968-6df0372c73ec
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# &lt;system.xml.serialization&gt; Element
The top-level element for controlling XML serialization. For more information about configuration files, see [Configuration File Schema](../../../docs/framework/configure-apps/file-schema/index.md).  
  
 \<configuration>  
\<system.xml.serialization>  
  
## Syntax  
  
```xml  
<system.xml.serialization>  
</system.xml.serialization>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<dateTimeSerialization> Element](../../../docs/standard/serialization/datetimeserialization-element.md)|Determines the serialization mode of <xref:System.DateTime> objects.|  
|[\<schemaImporterExtensions> Element](../../../docs/standard/serialization/schemaimporterextensions-element.md)|Contains types that are used by the <xref:System.Xml.Serialization.XmlSchemaImporter> for mapping of XSD types to .NET Framework types.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<configuration> Element](../../../docs/framework/configure-apps/file-schema/configuration-element.md)|The root element in every configuration file that is used by the common language runtime and .NET Framework applications.|  
  
## Example  
 The following code example illustrates how to specify the serialization mode of a <xref:System.DateTime> object, and the addition of types used by the <xref:System.Xml.Serialization.XmlSchemaImporter> when mapping XSD types to .NET Framework types.  
  
```xml  
<system.xml.serialization>  
    <xmlSerializer checkDeserializeAdvances="false" />  
    <dateTimeSerialization mode = "Local" />  
    <schemaImporterExtensions>  
        <add   
        name = "MobileCapabilities"   
        type = "System.Web.Mobile.MobileCapabilities,   
        System.Web.Mobile, Version - 2.0.0.0, Culture = neuutral,   
        PublicKeyToken = b03f5f6f11d40a3a" />  
    </schemaImporterExtensions>  
</system.sxml.serialization>  
```  
  
## See Also  
 <xref:System.Xml.Serialization.XmlSchemaImporter>  
 <xref:System.Xml.Serialization.Configuration.DateTimeSerializationSection.DateTimeSerializationMode>  
 [Configuration File Schema](../../../docs/framework/configure-apps/file-schema/index.md)  
 [\<dateTimeSerialization> Element](../../../docs/standard/serialization/datetimeserialization-element.md)  
 [\<schemaImporterExtensions> Element](../../../docs/standard/serialization/schemaimporterextensions-element.md)  
 [\<add> Element for \<xmlSchemaImporterExtensions>](../../../docs/standard/serialization/add-element-for-xmlschemaimporterextensions.md)
