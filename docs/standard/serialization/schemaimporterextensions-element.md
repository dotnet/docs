---
title: "&lt;schemaImporterExtensions&gt; Element"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "XML serialization, configuration"
  - "schemaImporterExtensions element"
  - "<schemaImporterExtensions> element"
ms.assetid: 465ef2a0-f909-4ac1-9a56-0ead5c849698
---
# &lt;schemaImporterExtensions&gt; Element
Contains types that are used by the <xref:System.Xml.Serialization.XmlSchemaImporter> for mapping of XSD types to .NET Framework types. For more information about configuration files, see [Configuration File Schema](../../../docs/framework/configure-apps/file-schema/index.md).  
  
## Syntax  
  
```xml  
<schemaImporterExtensions>  
    <!-- Add types -->  
</schemaImporterExtensions>  
```  
  
## Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<add> Element for \<schemaImporterExtensions>](../../../docs/standard/serialization/add-element-for-schemaimporterextensions.md)|Adds types that are used by the <xref:System.Xml.Serialization.XmlSchemaImporter> to create mappings.|  
  
## Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<system.xml.serialization> Element](../../../docs/standard/serialization/system-xml-serialization-element.md)|The top-level element for controlling XML serialization.|  
  
## Example  
 The following code example illustrates how to add types that are used by the <xref:System.Xml.Serialization.XmlSchemaImporter> when mapping XSD types to .NET Framework types.  
  
```xml  
<system.xml.serialization>  
    <schemaImporterExtensions>  
        <add name = "MobileCapabilities" type =   
        "System.Web.Mobile.MobileCapabilities,   
        System.Web.Mobile, Version - 2.0.0.0, Culture = neutral,   
        PublicKeyToken = b03f5f6f11d40a3a" />  
    </schemaImporterExtensions>  
</system.xml.serialization>  
```  
  
## See also

- <xref:System.Xml.Serialization.XmlSchemaImporter>  
- <xref:System.Xml.Serialization.Configuration.DateTimeSerializationSection.DateTimeSerializationMode>  
- [Configuration File Schema](../../../docs/framework/configure-apps/file-schema/index.md)  
- [\<dateTimeSerialization> Element](../../../docs/standard/serialization/datetimeserialization-element.md)  
- [\<add> Element for \<schemaImporterExtensions>](../../../docs/standard/serialization/add-element-for-schemaimporterextensions.md)  
- [\<system.xml.serialization> Element](../../../docs/standard/serialization/system-xml-serialization-element.md)
