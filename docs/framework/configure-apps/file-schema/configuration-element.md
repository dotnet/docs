---
description: "Learn more about: <configuration> element"
title: "<configuration> element"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration"
helpviewer_keywords: 
  - "<configuration> element"
  - "configuration element"
  - "container tags, <configuration> element"
ms.assetid: 2ec1c9dc-2e5c-4ef0-9958-81670ab88449
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

| Element | Description |
| --- | ----------- |
| [**\<assemblyBinding>**](assemblybinding-element-for-configuration.md) | Specifies assembly binding policy at the configuration level.|
| [**\<startup>** Settings Schema](./startup/index.md) | All elements in the startup settings schema. |
| [**\<runtime>** Settings Schema](./runtime/index.md) | All elements in the runtime settings schema. |
| [**\<system.runtime.remoting>** Settings Schema](/previous-versions/dotnet/netframework-4.0/z415cf9a(v=vs.100)) | All elements in the remoting settings schema. |
| [**\<system.Net>** Settings Schema](./network/index.md) | All elements in the network settings schema. |
| [**\<cryptographySettings>** Settings Schema](./cryptography/index.md) | All elements in the crypto settings schema. |
| [**\<configuration>** Sections Schema](configuration-sections-schema.md) | All elements in the configuration section settings schema. |
| [Trace and Debug Settings Schema](./trace-debug/index.md) | All elements in the trace and debug settings schema. |
| [ASP.NET Configuration Settings Schema](/previous-versions/dotnet/netframework-4.0/b5ysx397(v=vs.100)) | All elements in the ASP.NET configuration schema, which includes elements for configuring ASP.NET Web sites and applications. Used in *Web.config* files. |
| [**\<webServices>** Settings Schema](/previous-versions/dotnet/netframework-4.0/cctwteet(v=vs.100)) | All elements in the Web services settings schema. |
| [Web Settings Schema](./web/index.md) | All elements in the Web settings schema, which includes elements for configuring how ASP.NET works with a host application such as IIS. Used in *aspnet.config* files. |

## Remarks

Each configuration file must contain exactly one **\<configuration>** element.

## See also

- [Configuration file schema for the .NET Framework](index.md)
