---
title: "&lt;clear&gt; element for NameValueSectionHandler and DictionarySectionHandler"
ms.date: "05/01/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/sectionName/clear"
helpviewer_keywords: 
  - "clear Element"
  - "<clear> Element"
ms.assetid: ff2294ec-fb82-4b0c-933e-ae185433fc7b
author: "guardrex"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# \<clear> element for NameValueSectionHandler and DictionarySectionHandler

Clears all previously defined settings in a section.

[**\<configuration>**](~/docs/framework/configure-apps/file-schema/configuration-element.md)   
&nbsp;&nbsp;[**\<sectionName>**](~/docs/framework/configure-apps/file-schema/custom-element-2.md)   
&nbsp;&nbsp;&nbsp;&nbsp;**\<clear>**

## Syntax

```xml
<clear />
```

## Attributes

None

## Parent element

|     | Description |
| --- | ------------|
| [**\<sectionName>** Element](~/docs/framework/configure-apps/file-schema/custom-element-2.md) | Defines settings for custom configuration sections that use the <xref:System.Configuration.NameValueSectionHandler> and <xref:System.Configuration.DictionarySectionHandler> classes. |

## Child elements

None

## Remarks

You can use the **\<clear>** element to remove all settings from your application that were defined at a higher level in the configuration file hierarchy.

## Example

This example defines a machine configuration file and an application configuration file and shows how to use the **\<clear>** element in an application configuration file to clear sections previously defined in the machine configuration file.

The following machine configuration file code declares the section **\<mySection>**:

```xml
<!-- Machine.config file -->
<configuration>
  <configSections>
    <section name="mySection" type="System.Configuration.NameValueSectionHandler,System" />
  </configSections>
  <mySection>
    <add key="key1" value="value1" />
    <add key="key2" value="value2" />
  </mySection>
</configuration>
```

The following application configuration file code removes all settings from **\<mySection>**. The application cannot retrieve any of the settings that were declared in the in the **\<mySection>** section of the machine configuration file.

```xml
<!-- Application configuration file -->
<configuration>
  <mySection>
    <clear/>
  </mySection>
</configuration>
```

## Configuration file

This element can be used in the application configuration file, machine configuration file (*Machine.config*), and *Web.config* files that are not at the application directory level.

## See also

[Configuration file schema for the .NET Framework](~/docs/framework/configure-apps/file-schema/index.md)
