---
title: "&lt;configuration&gt; element"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration"
helpviewer_keywords: 
  - "<configuration> element"
  - "configuration element"
  - "container tags, <configuration> element"
ms.assetid: 2ec1c9dc-2e5c-4ef0-9958-81670ab88449
caps.latest.revision: 15
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---

# \<configuration> element

The root element in every configuration file used by the common language runtime and .NET Framework applications.

**\<configuration>**

## Syntax

```xml
<configuration>
  <!-- Configuration settings -->
</configuration>
```

## Attributes

None

## Parent element

None

## Child elements

|     | Description |
| --- | ----------- |
| [**\<assemblyBinding>**](~/docs/framework/configure-apps/file-schema/assemblybinding-element-for-configuration.md) | Specifies assembly binding policy at the configuration level.|
| [**\<startup>** Settings Schema](~/docs/framework/configure-apps/file-schema/startup/index.md) | All elements in the startup settings schema. |
| [**\<runtime>** Settings Schema](~/docs/framework/configure-apps/file-schema/runtime/index.md) | All elements in the runtime settings schema. |
| [**\<system.runtime.remoting>** Settings Schema](http://msdn.microsoft.com/dc2d1e62-9af7-4ca1-99fd-98b93bb4db9e) | All elements in the remoting settings schema. |
| [**\<system.Net>** Settings Schema](~/docs/framework/configure-apps/file-schema/network/index.md) | All elements in the network settings schema. |
| [**\<cryptographySettings>** Settings Schema](~/docs/framework/configure-apps/file-schema/cryptography/index.md) | All elements in the crypto settings schema. |
| [**\<configuration>** Sections Schema](~/docs/framework/configure-apps/file-schema/configuration-sections-schema.md) | All elements in the configuration section settings schema. |
| [Trace and Debug Settings Schema](~/docs/framework/configure-apps/file-schema/trace-debug/index.md) | All elements in the trace and debug settings schema. |
| [ASP.NET Configuration Settings Schema](https://msdn.microsoft.com/library/b5ysx397(v=vs.100).aspx) | All elements in the ASP.NET configuration schema, which includes elements for configuring ASP.NET Web sites and applications. Used in *Web.config* files. |
| [**\<webServices>** Settings Schema](http://msdn.microsoft.com/f84d6d55-1add-4eb7-ae46-33df5833ea2e) | All elements in the Web services settings schema. |
| [Web Settings Schema](~/docs/framework/configure-apps/file-schema/web/index.md) | All elements in the Web settings schema, which includes elements for configuring how ASP.NET works with a host application such as IIS. Used in *aspnet.config* files. |

## Remarks

Each configuration file must contain exactly one **\<configuration>** element.

## See also

[Configuration file schema for the .NET Framework](~/docs/framework/configure-apps/file-schema/index.md)
