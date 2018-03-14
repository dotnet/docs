---
title: "&lt;section&gt; element"
ms.date: "05/01/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/configSections/section"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/configSections/sectionGroup/section"
helpviewer_keywords: 
  - "section Element"
  - "<section> Element"
ms.assetid: ec7d4110-2403-47ac-8218-499bfe9d5ddb
author: "guardrex"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# \<section> element

Contains a configuration section declaration.

[**\<configuration>**](~/docs/framework/configure-apps/file-schema/configuration-element.md)   
&nbsp;&nbsp;[**\<configSections>**](~/docs/framework/configure-apps/file-schema/configsections-element-for-configuration.md)   
&nbsp;&nbsp;&nbsp;&nbsp;**\<section>**

[**\<configuration>**](~/docs/framework/configure-apps/file-schema/configuration-element.md)   
&nbsp;&nbsp;[**\<configSections>**](~/docs/framework/configure-apps/file-schema/configsections-element-for-configuration.md)   
&nbsp;&nbsp;&nbsp;&nbsp;[**\<sectionGroup>**](~/docs/framework/configure-apps/file-schema/sectiongroup-element-for-configsections.md)   
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<section>**

## Syntax

```xml
<section name="section name"
         type="configuration section handler class, assembly"
         allowDefinition="Everywhere|MachineOnly|MachineToApplication" 
         allowLocation="true|false" />
```

## Required attributes

|           | Description |
| --------- | ----------- |
| **name**  | Specifies the name of the configuration section. |
| **type**  | Specifies the name of the configuration section handler class that reads the section from the configuration file. The type value has the syntax "fully-qualified-section-handler-class-name, simple-assembly-name". The simple assembly name is the root filename without the *.dll* file extension. |

## Optional attributes

The following attributes are applicable only for ASP.NET applications. The configuration system ignores these attributes for other application types.

|                     | Description |
| ------------------- | ----------- |
| **allowDefinition** | Specifies which configuration file the section can be used in. Use one of the following values:<br><br>**Everywhere**<br>Allows the section to be used in any configuration file. This is the default.<br>**MachineOnly**<br>Allows the section to be used only in the machine configuration file (*Machine.config*).<br>**MachineToApplication**<br>Allows the section to be used in the machine configuration file or the application configuration file. |
| **allowLocation**   | Determines whether the section can be used within the **\<location>** element. Use one of the following values:<br><br>**true**<br>Allows the section to be used within the **\<location>** element. This is the default.<br>**false**<br>Does not allow the section to be used within the **\<location>** element. |

## Parent elements

|     | Description |
| --- | ----------- |
| [**\<configSections>** Element](~/docs/framework/configure-apps/file-schema/configsections-element-for-configuration.md) | Contains configuration section and namespace declarations. |
| [**\<sectionGroup>** Element](~/docs/framework/configure-apps/file-schema/sectiongroup-element-for-configsections.md) | Defines a namespace for configuration sections. |

> [!NOTE]
> A **\<section>** element is a child element of either **\<configSections>** or **\<sectionGroup>** but not both.

## Child elements

None

## Remarks

Declaring a configuration section essentially defines a new element for the configuration file. The new element contains settings that a configuration section handler (that is, a class that implements the <xref:System.Configuration.IConfigurationSectionHandler> interface) reads. The attributes and child elements of a section you define depend on the section handler you use to read your settings.

Declaring a configuration section handler in the *Machine.config* file enables you to use the configuration section in any application configuration file on that computer, unless the **allowDefinition** attribute specifies otherwise.

## Example

The following example shows how to define a configuration section and define settings for that section:

```xml
<configuration>
  <configSections>
    <section name="sampleSection"
             type="System.Configuration.SingleTagSectionHandler" 
             allowLocation="false" />
  </configSections>
  <sampleSection setting1="Value1" 
                 setting2="value two" 
                 setting3="third value" />
</configuration>
```

## Configuration file

This element can be used in the application configuration file, machine configuration file (*Machine.config*), and *Web.config* files that are not at the application directory level.

## See also

[Configuration file schema for the .NET Framework](~/docs/framework/configure-apps/file-schema/index.md)
