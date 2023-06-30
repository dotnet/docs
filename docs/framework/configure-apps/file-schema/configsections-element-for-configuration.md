---
description: "Learn more about: <configSections> element for <configuration>"
title: "<configSections> element for <configuration>"
ms.date: "05/01/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/configSections"
helpviewer_keywords: 
  - "configSections Element"
  - "<configSections> Element"
ms.assetid: 9f963c1b-dc3f-4220-a8b6-2dd7a5a8e039
---
# \<configSections> element for \<configuration>

Contains configuration section and namespace declarations.

[**\<configuration>**](configuration-element.md)\
&nbsp;&nbsp;**\<configSections>**

## Attributes

None

## Parent element

|     | Description |
| --- | ----------- |
| [**\<configuration>**](configuration-element.md) | The root element in every configuration file used by the common language runtime and .NET Framework applications. |

## Child elements

|     | Description |
| --- | ----------- |
| [**\<section>**](section-element.md) | Contains a configuration section declaration. |
| [**\<sectionGroup>**](sectiongroup-element-for-configsections.md) | Defines a namespace for configuration sections. |

## Remarks

If this element is in a configuration file, it must be the first child element of the **\<configuration>** element.

## Example

The following example shows how to define a configuration section and define settings for that section:

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

This element can be used in the application configuration file, machine configuration file (*Machine.config*), and *Web.config* files that are not at the application directory level.

## See also

- [Configuration file schema for the .NET Framework](index.md)
