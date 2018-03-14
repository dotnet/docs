---
title: "&lt;remove&gt; element for &lt;configSections&gt;"
ms.date: "05/01/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/configSections/remove"
helpviewer_keywords: 
  - "remove Element"
  - "<remove> Element"
ms.assetid: ae4d82e0-e8fe-468c-81ab-46d63c4d66a8
author: "guardrex"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# \<remove> element for \<configSections>

Removes a predefined section or section group.

[**\<configuration>**](~/docs/framework/configure-apps/file-schema/configuration-element.md)   
&nbsp;&nbsp;[**\<configSections>**](~/docs/framework/configure-apps/file-schema/configsections-element-for-configuration.md)   
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
| [**\<configSections>** Element](~/docs/framework/configure-apps/file-schema/configsections-element-for-configuration.md) | Contains configuration section and namespace declarations. |

# Child elements

None

## Remarks

You can use the **\<remove>** element to remove sections and section groups from your application that were defined at a higher level in the configuration file hierarchy.

## Example

The following example shows how to use the **\<remove>** element in an application configuration file to remove a section previously defined in the machine configuration file.

The following machine configuration file code declares the section **\<sampleSection>**:

```xml
<!-- Machine.config file -->
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

The following application configuration file code removes the **\<sampleSection>** section. After removal, the application cannot retrieve the settings in **\<sampleSection>**.

```xml
<!-- Application configuration file -->
<configuration>
  <configSections>
    <remove name="sampleSection"/>
  </configSections>
</configuration>
```

## Configuration file

This element can be used in the application configuration file, machine configuration file (*Machine.config*), and *Web.config* files that are not at the application directory level.

## See also

[Configuration file schema for the .NET Framework](~/docs/framework/configure-apps/file-schema/index.md)
