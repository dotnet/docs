---
title: "&lt;schemaImporterExtensions&gt; Element | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
  - "CSharp"
  - "C++"
  - "jsharp"
helpviewer_keywords: 
  - "XML serialization, configuration"
  - "schemaImporterExtensions element"
  - "<schemaImporterExtensions> element"
ms.assetid: 465ef2a0-f909-4ac1-9a56-0ead5c849698
caps.latest.revision: 3
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# &lt;schemaImporterExtensions&gt; Element
Contains types that are used by the <xref:System.Xml.Serialization.XmlSchemaImporter> for mapping of XSD types to .NET Framework types. For more information about configuration files, see [Configuration File Schema](../../../docs/framework/configure-apps/file-schema/index.md).  
  
## Syntax  
  
```  
  
<schemaImporterExtensions>  
    <!-- Add types -->  
</SchemaImporterExtension>  
```  
  
## Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<add> Element for \<xmlSchemaImporterExtensions>](../../../docs/framework/serialization/add-element-for-xmlschemaimporterextensions.md)|Adds types that are used by the <xref:System.Xml.Serialization.XmlSchemaImporter> to create mappings.|  
  
## Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<system.xml.serialization> Element](../../../docs/framework/serialization/system-xml-serialization-element.md)|The top-level element for controlling XML serialization.|  
  
## Example  
 The following code example illustrates how to add types that are used by the <xref:System.Xml.Serialization.XmlSchemaImporter> when mapping XSD types to .NET Framework types.  
  
```  
<system.xml.serialization>  
    <schemaImporterExtensions>  
        <add name = "MobileCapabilities" type =   
        "System.Web.Mobile.MobileCapabilities,   
        System.Web.Mobile, Version - 2.0.0.0, Culture = neutral,   
        PublicKeyToken = b03f5f6f11d40a3a" />  
    </schemaImporterExtensions>  
/system.sxml.serializaiton>  
```  
  
## See Also  
 <xref:System.Xml.Serialization.XmlSchemaImporter>   
 <xref:System.Xml.Serialization.Configuration.DateTimeSerializationSection.DateTimeSerializationMode>   
 [Configuration File Schema](../../../docs/framework/configure-apps/file-schema/index.md)   
 [\<dateTimeSerialization> Element](../../../docs/framework/serialization/datetimeserialization-element.md)   
 [\<add> Element for \<xmlSchemaImporterExtensions>](../../../docs/framework/serialization/add-element-for-xmlschemaimporterextensions.md)   
 [\<system.xml.serialization> Element](../../../docs/framework/serialization/system-xml-serialization-element.md)