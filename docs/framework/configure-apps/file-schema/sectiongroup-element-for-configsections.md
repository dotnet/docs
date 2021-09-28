---
description: "Learn more about: <sectionGroup> element for <configSections>"
title: "<sectionGroup> element for <configSections>"
ms.date: "05/01/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/configSections/sectionGroup"
helpviewer_keywords: 
  - "sectionGroup Element"
  - "<sectionGroup> Element"
ms.assetid: 6c27f9e2-809c-4bc9-aca9-72f90360e7a3
---
# \<sectionGroup> element for \<configSections>

Defines a namespace for configuration sections.

[**\<configuration>**](configuration-element.md)\
&nbsp;&nbsp;[**\<configSections>**](configsections-element-for-configuration.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<sectionGroup>**

## Syntax

```xml
<sectionGroup name="section group name">
  <!-- Configuration sections -->
</sectionGroup>
```

## Attribute

|           | Description |
| --------- | ----------- |
| **name**  | Required attribute.<br><br>Specifies the name of the section group you are defining. |

## Parent element

|     | Description |
| --- | ----------- |
| [**\<configSections>** Element](configsections-element-for-configuration.md) | Contains configuration section and namespace declarations. |

## Child elements

|     | Description |
| --- | ----------- |
| [**\<section>**](section-element.md) | Contains a configuration section declaration. |

## Remarks

Declaring a section group creates a container tag for configuration sections and ensures that there are no naming conflicts with configuration sections defined by someone else. You can nest **\<sectionGroup>** elements within each other.

## Example

The following example shows how to declare a section group and declare sections within a section group:

```xml
<configuration>
  <configSections>
    <sectionGroup name="mySectionGroup">
      <section name="mySection"
               type="System.Configuration.NameValueSectionHandler,System" />
    </sectionGroup>
  </configSections>
  <mySectionGroup>
    <mySection>
      <add key="key1" value="value1" />
    </mySection>
  </mySectionGroup>
</configuration>
```

## Configuration file

This element can be used in the application configuration file, machine configuration file (*Machine.config*), and *Web.config* files that are not at the application directory level.

## See also

- [Configuration file schema for the .NET Framework](index.md)
