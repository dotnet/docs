---
title: "&lt;add&gt; element for NameValueSectionHandler and DictionarySectionHandler"
ms.date: "05/01/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/sectionName/add"
helpviewer_keywords: 
  - "add Element"
  - "<add> Element"
ms.assetid: 0d4ddb53-eb2b-49c0-9c33-a8dec5c39b46
author: "guardrex"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# \<add> element for NameValueSectionHandler and DictionarySectionHandler

Adds custom application settings. Each **\<add>** tag contains a key/value pair.

[**\<configuration>**](~/docs/framework/configure-apps/file-schema/configuration-element.md)   
&nbsp;&nbsp;[**\<sectionName>**](~/docs/framework/configure-apps/file-schema/custom-element-2.md)   
&nbsp;&nbsp;&nbsp;&nbsp;**\<add>**

## Syntax

```xml
<add key="key" value="value" />
```

## Attributes

| Attribute | Description |
| --------- | ----------- |
| **key**   | Required attribute.<br><br>Specifies the name of the setting. |
| **value** | Required attribute.<br><br>Specifies the value of the setting. |

## Parent element

| Element | Description |
| ------- | ------------|
| [**\<sectionName>** Element](~/docs/framework/configure-apps/file-schema/custom-element-2.md) | Defines settings for custom configuration sections that use the <xref:System.Configuration.NameValueSectionHandler> and <xref:System.Configuration.DictionarySectionHandler> classes. |

## Child elements

None

## Example

The following example shows how to define a custom configuration section and use the **\<add>** element to put settings into the section:

```xml
<configuration>
  <configSections>
    <section name="dictionarySample" type="System.Configuration.DictionarySectionHandler,System" />
  </configSections>
  <dictionarySample>
    <add key="myKey" value="myValue" />
  </dictionarySample>
</configuration>
```

## Configuration file

This element can be used in the application configuration file, machine configuration file (*Machine.config*), and *Web.config* files that are not at the application directory level.

## See also

[Configuration file schema for the .NET Framework](~/docs/framework/configure-apps/file-schema/index.md)
