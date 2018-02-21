---
title: "&lt;remove&gt; element for &lt;appSettings&gt;"
ms.date: "05/01/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/appSettings/remove"
helpviewer_keywords: 
  - "remove Element"
  - "<remove> Element"
ms.assetid: 218c4464-e007-4539-803f-7c8b0a909fd8
author: "guardrex"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# \<remove> element for \<appSettings>

Removes custom application settings.

[**\<configuration>**](~/docs/framework/configure-apps/file-schema/configuration-element.md)   
&nbsp;&nbsp;[**\<appSettings>**](~/docs/framework/configure-apps/file-schema/appsettings/appsettings-element-for-configuration.md)   
&nbsp;&nbsp;&nbsp;&nbsp;**\<remove>**

## Syntax

```xml
<appSettings>
  <remove key="Key of custom setting" />
</appSettings>
```

### Attribute

|         | Description |
| ------- | ----------- |
| **key** | Required attribute.<br><br>Specifies the name of the key to remove. |

### Parent element

|     | Description |
| --- | ----------- |
| [**\<appSettings>**](~/docs/framework/configure-apps/file-schema/appsettings/appsettings-element-for-configuration.md) | Contains custom application settings, such as file paths, XML Web service URLs, or any other custom configuration information for an application. |

## Child elements

None

## Example

The following example shows how to remove a custom configuration setting for `ApplicationName`:

```xml
<appSettings>
  <remove key="ApplicationName" />
</appSettings>
```

## See also

[Configuration file schema for the .NET Framework](~/docs/framework/configure-apps/file-schema/index.md)
