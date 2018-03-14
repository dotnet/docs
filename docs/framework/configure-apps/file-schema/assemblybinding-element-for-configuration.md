---
title: "&lt;assemblyBinding&gt; element for &lt;configuration&gt;"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/assemblyBinding"
helpviewer_keywords: 
  - "assemblyBinding Element"
  - "<assemblyBinding> Element"
ms.assetid: 6cc55983-b894-449b-8e26-b258e53939cd
caps.latest.revision: 6
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---

# \<assemblyBinding> element for \<configuration>

Specifies assembly binding policy at the configuration level.

[**\<configuration>**](~/docs/framework/configure-apps/file-schema/configuration-element.md)   
&nbsp;&nbsp;**\<assemblyBinding>**

## Syntax

```xml
<assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
  <!-- Configuration files to include. -->
</assemblyBinding>
```

## Attribute

|           | Description |
| --------- | ----------- |
| **xmlns** | Required attribute.<br><br>Specifies the XML namespace required for assembly binding. Use the string "urn:schemas-microsoft-com:asm.v1" as the value. |

## Parent element

|     | Description |
| --- | ----------- |
| [**\<configuration>**](~/docs/framework/configure-apps/file-schema/configuration-element.md) | The root element in every configuration file used by the common language runtime and .NET Framework applications. |

## Child element

|     | Description |
| --- | ----------- |
| [**\<linkedConfiguration>**](~/docs/framework/configure-apps/file-schema/linkedconfiguration-element.md) | Specifies a configuration file to include. |

## Remarks

The [**\<linkedConfiguration>**](~/docs/framework/configure-apps/file-schema/linkedconfiguration-element.md) element simplifies the management of component assemblies by allowing application configuration files to include assembly configuration files in well-known locations, rather than duplicating assembly configuration settings.

> [!NOTE]
> The **\<linkedConfiguration>** element is not supported for applications with Windows side-by-side manifests.

## Example

The following example shows how to include a configuration file on the local hard disk:

```xml
<configuration>
  <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
    <linkedConfiguration href="file://c:\Program Files\Contoso\sharedConfig.xml" />
  </assemblyBinding>
</configuration>
```

## See also

[Configuration file schema for the .NET Framework](~/docs/framework/configure-apps/file-schema/index.md)
