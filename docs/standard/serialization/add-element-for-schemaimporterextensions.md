---
title: "&lt;add&gt; Element for &lt;schemaImporterExtensions&gt;"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "XML serialization, configuration"
  - "<add> element for <schemaImporterExtensions> element"
ms.assetid: c828a558-094b-441e-9065-790b87315fa0
---
# &lt;add&gt; Element for &lt;schemaImporterExtensions&gt;
Adds types used by the <xref:System.Xml.Serialization.XmlSchemaImporter> for mapping XSD types to .NET Framework types. For more information about configuration files, see [Configuration File Schema](../../../docs/framework/configure-apps/file-schema/index.md).  
  
 \<configuration>  
\<system.xml.serialization>  
\<schemaImporterExtensions>  
\<add>  
  
## Syntax  
  
```xml  
<add name = "typeName" type="fully qualified type [,Version=version number] [,Culture=culture] [,PublicKeyToken= token]"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|**name**|A simple name that is used to find the instance.|  
|**type**|Required. Specifies the schema  extension class to add. The **type** attribute value must be on one line, and include the fully qualified type name. When the assembly is placed in the Global Assembly Cache (GAC), it must also include the version, culture, and public key token of the signed assembly.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|\<schemaImporterExtensions>|Contains the types that are used by the <xref:System.Xml.Serialization.XmlSchemaImporter>.|  
  
## Example  
 The following code example adds an extension type that the XmlSchemaImporter can use when mapping types.  
  
```xml  
<configuration>  
  <system.xml.serialization>  
    <schemaImporterExtensions>  
       <add name="contoso" type="System.Web.Mobile.MobileCapabilities,   
       System.Web.Mobile, Version=2.0.0.0, Culture=neutral,   
       PublicKeyToken=b03f5f7f11d50a3a" />   
    </schemaImporterExtensions>  
  </system.xml.serialization>  
</configuration>  
```  
  
## See also

- <xref:System.Xml.Serialization.XmlSchemaImporter>  
- [\<system.xml.serialization> Element](../../../docs/standard/serialization/system-xml-serialization-element.md)  
- [\<schemaImporterExtensions> Element](../../../docs/standard/serialization/schemaimporterextensions-element.md)
