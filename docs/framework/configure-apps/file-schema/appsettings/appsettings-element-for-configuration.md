---
title: "&lt;appSettings&gt; element for &lt;configuration&gt;"
ms.date: "05/01/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/appSettings"
helpviewer_keywords: 
  - "appSettings Element"
  - "<appSettings> Element"
ms.assetid: 39694cc4-6b84-45a6-9329-385a0d8b48fe
author: "guardrex"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# \<appSettings> element for \<configuration>

Contains custom application settings. This is a predefined configuration section provided by the .NET Framework.

[**\<configuration>**](~/docs/framework/configure-apps/file-schema/configuration-element.md)   
&nbsp;&nbsp;**\<appSettings>**

## Syntax

```xml
<appSettings>
  <!-- Elements to add, clear, or remove configuration settings -->
</appSettings>
```

## Attribute

|           | Description |
| --------- | ----------- |
| **file**  | Optional attribute.<br><br>Specifies a relative path to an external file containing custom application configuration settings. The specified file contains the same kind of settings that are specified in the **\<add>**, **\<remove>**, and **\<clear>** elements and uses the same key/value pair format as those elements.<br><br>The path specified is relative to the main configuration file. For a Windows Forms application, this is the binary folder (such as */bin/debug*), not the location of the application configuration file. For Web Forms applications, the path is relative to the application root, where the *web.config* file is located.<br><br>Note that the runtime ignores the attribute if the specified file can not be found. |

## Parent element

|     | Description |
| --- | ----------- |
| [**\<configuration>** Element](~/docs/framework/configure-apps/file-schema/configuration-element.md) | The root element in every configuration file used by the common language runtime and .NET Framework applications. |

## Child elements

|     | Description |
| --- | ----------- |
| [**\<add>**](~/docs/framework/configure-apps/file-schema/appsettings/add-element-for-appsettings.md) | Adds a custom application setting. |
| [**\<clear>**](~/docs/framework/configure-apps/file-schema/appsettings/clear-element-for-appsettings.md) | Clears all previously defined application settings. |
| [**\<remove>**](~/docs/framework/configure-apps/file-schema/appsettings/remove-element-for-appsettings.md) | Removes a previously defined application setting. |

## Remarks

The **\<appSettings>** element stores custom application configuration information, such as database connection strings, file paths, XML Web service URLs, or any other custom configuration information for an application. The key/value pairs specified in the **\<appSettings>** element are accessed in code using the <xref:System.Configuration.ConfigurationSettings> class.

You can use the **file** attribute in the **\<appSettings>** element of the *Web.config* and application configuration files. This attribute specifies a configuration file that provides additional settings or overrides the settings specified in the **\<appSettings>** element. The **file** attribute can be used in source control team development scenarios, such as when a user wants to override the project settings specified in an application configuration file.

Configuration files specified by the **file** attribute must have a root node of **\<appSettings>** rather than **\<configuration>**.

## Example

The following example shows an external application settings file (*custom.config*) that defines a custom application setting:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<appSettings>
  <add key="MyCustomSetting" value="MyCustomSettingValue" />
</appSettings>
```

The following example shows an application configuration file that consumes the setting in the external settings file and sets an application setting of its own:

```xml
<configuration>
  <appSettings file="custom.config">
    <add key="ApplicationName" value="MyApplication" />
  </appSettings>
</configuration>
```

## Configuration file

This element can be used in the application configuration file, machine configuration file (*Machine.config*), and *Web.config* files that are not at the application directory level.

## See also

[Configuration file schema for the .NET Framework](~/docs/framework/configure-apps/file-schema/index.md)
