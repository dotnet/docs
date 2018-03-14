---
title: "&lt;linkedConfiguration&gt; element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/assemblyBinding/linkedConfiguration"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#linkedConfiguration"
helpviewer_keywords: 
  - "configuration files [.NET Framework],linked configuration files"
  - "<linkedConfiguration> element"
  - "including configuration files"
  - "linked configuration files"
  - "linkedConfiguration Element"
ms.assetid: 8eb34f3b-427e-4288-a7ff-c73f489deb45
caps.latest.revision: 6
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---

# \<linkedConfiguration> element

Specifies a configuration file to include.

[**\<configuration>**](~/docs/framework/configure-apps/file-schema/configuration-element.md)   
&nbsp;&nbsp;[**\<assemblyBinding>**](~/docs/framework/configure-apps/file-schema/assemblybinding-element-for-configuration.md)   
&nbsp;&nbsp;&nbsp;&nbsp;**\<linkedConfiguration>**

## Syntax

```xml
<linkedConfiguration href="URL of linked configuration file" />
```

## Attribute

|           | Description |
| --------- | ----------- |
| **href**  | Required attribute.<br><br>The URL of the configuration file to include. The only format supported for the **href** attribute is `file://`. Local files and UNC files are supported. |

## Parent element

|     | Description |
| --- | ----------- |
| [**\<assemblyBinding>** Element](~/docs/framework/configure-apps/file-schema/assemblybinding-element-for-configuration.md) | Specifies assembly binding policy at the configuration level. |

## Child elements

None

## Remarks

The **\<linkedConfiguration>** element simplifies servicing for component assemblies. If one or more applications use an assembly that has a configuration file residing in a well-known location, the configuration files of the applications that use the assembly can use the **\<linkedConfiguration>** element to include the assembly configuration file, rather than including configuration information directly. When the component assembly is serviced, updating the common configuration file provides updated configuration information to all applications that use the assembly.

> [!NOTE]
> The **\<linkedConfiguration>** element is not supported for applications with Windows side-by-side manifests.

The following rules govern the use of linked configuration files:

- The settings in included configuration files only affect loader binding policy and are used only by the loader. The included configuration files can have settings other than binding policies, but those settings don't have any effect.

- The only format supported for the `href` attribute is `file://`. Local files and UNC files are supported.

- There is no constraint on the number of linked configurations per configuration file.

- All linked configuration files are merged to form one file, similar to the behavior of the `#include` directive in C/C++.

- The **\<linkedConfiguration>** element is allowed only in application configuration files; it's ignored in *Machine.config*.

- Circular references are detected and terminated. That is, if the **\<linkedConfiguration>** elements of a series of configuration files form a loop, the loop is detected and stopped.

## Example

The following example shows how to include configuration file from the local hard disk:

```xml
<configuration>
  <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
    <linkedConfiguration href="file://c:\Program Files\Contoso\sharedConfig.xml"/>
  </assemblyBinding>
</configuration>
```

## See also

[**\<assemblyBinding>** Element](~/docs/framework/configure-apps/file-schema/assemblybinding-element-for-configuration.md)   
[Configuration file schema for the .NET Framework](~/docs/framework/configure-apps/file-schema/index.md)
