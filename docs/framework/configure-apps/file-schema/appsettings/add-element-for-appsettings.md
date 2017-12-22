---
title: "&lt;add&gt; element for &lt;appSettings&gt;"
ms.date: "05/01/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/appSettings/add"
helpviewer_keywords: 
  - "add Element"
  - "<add> Element"
ms.assetid: 8734efdc-00f6-4a65-bba6-084c5bc65246
author: "guardrex"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# \<add> element for \<appSettings>

Adds a custom application setting.

[**\<configuration>**](~/docs/framework/configure-apps/file-schema/configuration-element.md)   
&nbsp;&nbsp;[**\<appSettings>**](~/docs/framework/configure-apps/file-schema/appsettings/appsettings-element-for-configuration.md)   
&nbsp;&nbsp;&nbsp;&nbsp;**\<add>**

## Syntax

```xml
<appSettings>
  <add key="Key of custom setting" value="Value of custom setting" />
</appSettings>
```

## Attributes

|           | Description |
| --------- | ----------- |
| **key**   | Required attribute.<br><br>Specifies the name of the key to add. |
| **value** | Required attribute.<br><br>Specifies the value of the key to add. |

## Parent element

|     | Description |
| --- | ----------- |
| [**\<appSettings>**](~/docs/framework/configure-apps/file-schema/appsettings/appsettings-element-for-configuration.md) | Contains custom application settings, such as file paths, XML Web service URLs, or any other custom configuration information for an application. |

## Child elements

None

## Example

The following example shows how to add a custom configuration setting for the application's name:

```xml
<appSettings>
  <add key="ApplicationName" value="MyApplication" />
</appSettings>
```

## See also

[Configuration file schema for the .NET Framework](~/docs/framework/configure-apps/file-schema/index.md)
