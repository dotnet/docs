---
title: "&lt;clear&gt; element for &lt;appSettings&gt;"
ms.date: "05/01/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/appSettings/clear"
helpviewer_keywords: 
  - "clear Element"
  - "<clear> Element"
ms.assetid: 6d18c7be-27db-438b-8fb5-765d396b0b7b
author: "guardrex"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# \<clear> element for \<appSettings>

Clears custom application settings.

[**\<configuration>**](~/docs/framework/configure-apps/file-schema/configuration-element.md)   
&nbsp;&nbsp;[**\<appSettings>**](~/docs/framework/configure-apps/file-schema/appsettings/appsettings-element-for-configuration.md)   
&nbsp;&nbsp;&nbsp;&nbsp;**\<clear>**

## Syntax

```xml
<appSettings>
  <clear />
</appSettings>
```

## Attributes

None

## Parent element

|     | Description |
| --- | ----------- |
| [**\<appSettings>**](~/docs/framework/configure-apps/file-schema/appsettings/appsettings-element-for-configuration.md) | Contains custom application settings, such as file paths, XML Web service URLs, or any other custom application configuration information. |

## Child elements

None

## Example

The following example shows how to clear custom configuration settings:

```xml
<appSettings>
  <clear />
</appSettings>
```

## See also

[Configuration file schema for the .NET Framework](~/docs/framework/configure-apps/file-schema/index.md)
