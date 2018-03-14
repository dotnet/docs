---
title: "&lt;remove&gt; element for NameValueSectionHandler and DictionarySectionHandler"
ms.date: "05/01/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/sectionName/remove"
helpviewer_keywords: 
  - "remove Element"
  - "<remove> Element"
ms.assetid: 8d8af7f5-26c9-4db9-bbe4-b2a4e6949568
author: "guardrex"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# \<remove> element for NameValueSectionHandler and DictionarySectionHandler

Removes a previously defined setting.

[**\<configuration>**](~/docs/framework/configure-apps/file-schema/configuration-element.md)   
&nbsp;&nbsp;[**\<sectionName>**](~/docs/framework/configure-apps/file-schema/custom-element-2.md)   
&nbsp;&nbsp;&nbsp;&nbsp;**\<remove>**

## Syntax

```xml
<add remove="key" />
```

## Attribute

|           | Description |
| --------- | ----------- |
| **key**   | Required attribute.<br><br>Specifies the name of the setting to remove. |

## Parent element

| Element | Description |
| ------- | ------------|
| [**\<sectionName>** Element](~/docs/framework/configure-apps/file-schema/custom-element-2.md) | Defines settings for custom configuration sections that use the <xref:System.Configuration.NameValueSectionHandler> and <xref:System.Configuration.DictionarySectionHandler> classes. |

## Child elements

None

## Remarks

You can use the **\<remove>** element to remove settings from your application that were defined at a higher level in the configuration file hierarchy.

## Example

The following example shows how to use the **\<remove>** element in an application configuration file to remove settings previously defined in the machine configuration file.

The following machine configuration file code declares the section **\<mySection>** and adds two settings, `key1` and `key2`, to it:

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

The following application configuration file code removes the `key2` setting from **\<mySection>**:

```xml
<!--Application configuration file -->
<configuration>
  <mySection>
    <remove key="key2" />
  </mySection>
</configuration>
```

## Configuration file

This element can be used in the application configuration file, machine configuration file (*Machine.config*), and *Web.config* files that are not at the application directory level.

## See also

[Configuration file schema for the .NET Framework](~/docs/framework/configure-apps/file-schema/index.md)
