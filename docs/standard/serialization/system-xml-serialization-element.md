---
title: "<system.xml.serialization> Element"
description: This article describes the <system.xml.serialization> element, which is the top-level element for controlling XML serialization.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "system.xml.serialization element"
  - "XML serialization, configuration"
  - "<system.xml.serialization> element"
ms.topic: reference
---
# \<system.xml.serialization> Element

The top-level element for controlling XML serialization. For more information about configuration files, see [Configuration File Schema](../../framework/configure-apps/file-schema/index.md).

\<configuration>\
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
|[\<dateTimeSerialization> Element](datetimeserialization-element.md)|Determines the serialization mode of <xref:System.DateTime> objects.|
|[\<schemaImporterExtensions> Element](schemaimporterextensions-element.md)|Contains types that are used by the <xref:System.Xml.Serialization.XmlSchemaImporter> for mapping of XSD types to .NET types.|

### Parent Elements

|Element|Description|
|-------------|-----------------|
|[\<configuration> Element](../../framework/configure-apps/file-schema/configuration-element.md)|The root element in every configuration file that is used by the common language runtime and .NET Framework applications.|

## Example

The following code example illustrates how to specify the serialization mode of a <xref:System.DateTime> object, and the addition of types used by the <xref:System.Xml.Serialization.XmlSchemaImporter> when mapping XSD types to .NET types.

```xml
<system.xml.serialization>
    <xmlSerializer checkDeserializeAdvances="false" />
    <dateTimeSerialization mode = "Local" />
    <schemaImporterExtensions>
        <add
        name = "MobileCapabilities"
        type = "System.Web.Mobile.MobileCapabilities,
        System.Web.Mobile, Version=2.0.0.0, Culture=neutral,
        PublicKeyToken=b03f5f6f11d40a3a" />
    </schemaImporterExtensions>
</system.xml.serialization>
```

## See also

- <xref:System.Xml.Serialization.XmlSchemaImporter>
- <xref:System.Xml.Serialization.Configuration.DateTimeSerializationSection.DateTimeSerializationMode>
- [Configuration File Schema](../../framework/configure-apps/file-schema/index.md)
- [\<dateTimeSerialization> Element](datetimeserialization-element.md)
- [\<schemaImporterExtensions> Element](schemaimporterextensions-element.md)
- [\<add> Element for \<schemaImporterExtensions>](add-element-for-schemaimporterextensions.md)
