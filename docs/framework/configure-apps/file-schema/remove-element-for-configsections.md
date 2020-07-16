---
title: "<remove> element for <configSections>"
ms.date: "05/01/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/configSections/remove"
helpviewer_keywords: 
  - "remove Element"
  - "<remove> Element"
ms.assetid: ae4d82e0-e8fe-468c-81ab-46d63c4d66a8
---
# \<remove> element for \<configSections>

No impact on section or section group.

[**\<configuration>**](configuration-element.md)\
&nbsp;&nbsp;[**\<configSections>**](configsections-element-for-configuration.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<remove>**

## Syntax

```xml
<remove name="section name or section group name" />
```

## Attribute

|           | Description |
| --------- | ----------- |
| **name**  | Required attribute.<br><br>Specifies the name of the section or section group to remove. |

## Parent element

|     | Description |
| --- | ----------- |
| [**\<configSections>** Element](configsections-element-for-configuration.md) | Contains configuration section and namespace declarations. |

## Child elements

None

## Remarks

The **\<remove>** element has no impact on sections and section groups.

## Configuration file

This element can be used in the application configuration file, machine configuration file (*Machine.config*), and *Web.config* files that are not at the application directory level.

## See also

- [Configuration file schema for the .NET Framework](index.md)
