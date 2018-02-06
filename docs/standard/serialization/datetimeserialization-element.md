---
title: "&lt;dateTimeSerialization&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "dateTimeSerialization element"
  - "XML serialization, configuration"
  - "<dateTimeSerialization> element"
ms.assetid: 90fda55c-7730-41e9-bc4b-6423a4b920af
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# &lt;dateTimeSerialization&gt; Element
Determines the serialization mode of <xref:System.DateTime> objects.  
  
 \<configuration>  
\<dateTimeSerialization>  
  
## Syntax  
  
```xml  
<dateTimeSerialization  
    mode = "Roundtrip" | "Local"  
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attributes|Description|  
|----------------|-----------------|  
|`mode`|Optional. Specifies the serialization mode. Set to one of the <xref:System.Xml.Serialization.Configuration.DateTimeSerializationSection.DateTimeSerializationMode> values. The default is **RoundTrip**.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|system.xml.serialization|The top-level element for controlling XML serialization.|  
  
## Remarks  
 In versions 1.0, 1.1, 2.0 and later versions of the .NET Framework, when this property is set to **Local**, <xref:System.DateTime> objects are always formatted as the local time. That is, local time zone information is always included with the serialized data. Set this property to **Local** to ensure compatibility with older versions of the .NET Framework.  
  
 In version 2.0 and later versions of the .NET Framework that have this property set to **Roundtrip**, <xref:System.DateTime> objects are examined to determine whether they are in the local, UTC, or an unspecified time zone. The <xref:System.DateTime> objects are then serialized in such a way that this information is preserved. This is the default behavior and is the recommended behavior for all new applications that do not communicate with older versions of the framework.  
  
## See Also  
 <xref:System.DateTime>  
 <xref:System.Xml.Serialization.XmlSchemaImporter>  
 <xref:System.Xml.Serialization.Configuration.DateTimeSerializationSection.DateTimeSerializationMode>  
 [Configuration File Schema](../../../docs/framework/configure-apps/file-schema/index.md)  
 [\<schemaImporterExtensions> Element](../../../docs/standard/serialization/schemaimporterextensions-element.md)  
 [\<add> Element for \<xmlSchemaImporterExtensions>](../../../docs/standard/serialization/add-element-for-xmlschemaimporterextensions.md)  
 [\<system.xml.serialization> Element](../../../docs/standard/serialization/system-xml-serialization-element.md)
