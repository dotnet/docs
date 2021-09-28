---
description: "Learn more about: Custom element for SingleTagSectionHandler"
title: "Custom element for SingleTagSectionHandler"
ms.date: "05/01/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/sectionName"
helpviewer_keywords: 
  - "custom element"
ms.assetid: e62056c6-b351-40eb-afc0-cc13fc44e45e
---
# Custom element for SingleTagSectionHandler

Defines settings in a custom configuration section that is defined by a \<section> element and uses the <xref:System.Configuration.SingleTagSectionHandler> class.

[**\<configuration>**](configuration-element.md)
&nbsp;&nbsp;*\<sectionName>*

## Syntax

```xml
<sectionName key="value" key2="value2" />
```

## Attributes

Attributes and attribute values are user defined.

## Parent element

|     | Description |
| --- | ----------- |
| [**\<configuration>**](configuration-element.md) | The root element in every configuration file used by the common language runtime and .NET Framework applications. |

## Child elements

None

## Remarks

The **\<sectionName>** element is a custom element defined by a [**\<section>**](section-element.md) tag in the [**\<configSections>**](configsections-element-for-configuration.md) element. The configuration system returns a <xref:System.Collections.IDictionary> object when you call <xref:System.Configuration.Configuration.GetSection(System.String)?displayProperty=nameWithType>.

## Example

The following example declares a custom element called **\<sampleSection>** that contains settings read by the <xref:System.Configuration.SingleTagSectionHandler> class:

```xml
<configuration>
  <configSections>
    <section name="sampleSection"
             type="System.Configuration.SingleTagSectionHandler" />
  </configSections>
  <sampleSection setting1="Value1"
                 setting2="value two"
                 setting3="third value" />
</configuration>
```

## Configuration file

This element can be used in the application configuration file, the machine configuration file (*Machine.config*), and *Web.config* files that aren't at the application directory level.

## See also

- [Configuration file schema for the .NET Framework](index.md)
