---
description: "Learn more about: App Settings schema"
title: "App Settings schema"
ms.date: "05/01/2017"
helpviewer_keywords: 
  - "schema app settings"
  - "app settings, schema [Windows Forms]"
  - "Windows Forms, app settings schema"
  - "configuration schema [.NET Framework], app settings"
ms.assetid: 99347d62-3ea5-40b6-bfec-c31431011422
---
# App Settings schema

Contains custom application settings, such as file paths, XML Web service URLs, or any other custom configuration information for an application.

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<appSettings>**](appsettings-element-for-configuration.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<add>**](add-element-for-appsettings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<clear>**](clear-element-for-appsettings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<remove>**](remove-element-for-appsettings.md)

| Element | Description |
| ------- | ----------- |
| [**\<appSettings>**](appsettings-element-for-configuration.md) | Contains **\<add>**, **\<clear>**, and **\<remove>** tags to control application settings. Has an optional **file** attribute. |
| [**\<add>**](add-element-for-appsettings.md) | Defines a setting. Child of **\<appSettings>**. Requires **key** and **value** attributes. |
| [**\<clear>**](clear-element-for-appsettings.md) | Clears all settings. Child of **\<appSettings>**. Has no attributes. |
| [**\<remove>**](remove-element-for-appsettings.md) | Removes a setting. Child of **\<appSettings>**. Requires a **key** attribute. |

## \<appSettings> element

This element contains **\<add>**, **\<clear>**, and **\<remove>** tags to control application settings. It defines an optional attribute for **file**.

## \<add> element

Adds a custom application setting as a name/value pair to the application settings collection. It defines attributes for **key** and **value**.

## \<clear> element

Removes all references to inherited custom application settings and allows only the references that are added by **\<add>** elements following the **\<clear>** element. It defines no attributes.

## \<remove> element

Removes a reference to an inherited custom application setting from the application settings collection. It defines an attribute for **key**.

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

## See also

- [Application Settings Overview](/dotnet/desktop/winforms/advanced/application-settings-overview)
- [Application Settings Architecture](/dotnet/desktop/winforms/advanced/application-settings-architecture)
