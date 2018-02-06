---
title: "Application Settings schema"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "schema application settings"
  - "application settings, schema [Windows Forms]"
  - "Windows Forms, application settings schema"
  - "configuration schema [.NET Framework], application settings"
ms.assetid: 5797fcff-6081-4e8c-bebf-63d9c70cf14b
caps.latest.revision: 3
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---

# Application Settings schema

Application settings allow a Windows Forms or ASP.NET application to store and retrieve application-scoped and user-scoped settings. In this context, a *setting* is any piece of information that may be specific to the application or specific to the current user — anything from a database connection string to the user's preferred default window size.

By default, application settings in a Windows Forms application uses the <xref:System.Configuration.LocalFileSettingsProvider> class, which uses the .NET configuration system to store settings in an XML configuration file. For more information about the files used by application settings, see [Application Settings Architecture](~/docs/framework/winforms/advanced/application-settings-architecture.md).

Application settings defines the following elements as part of the configuration files it uses.

| Element                    | Description                                                                           |
| -------------------------- | ------------------------------------------------------------------------------------- |
| **\<applicationSettings>** | Contains all **\<setting>** tags specific to the application.                         |
| **\<userSettings>**        | Contains all **\<setting>** tags specific to the current user.                        |
| **\<setting>**             | Defines a setting. Child of either **\<applicationSettings>** or **\<userSettings>**. |
| **\<value>**               | Defines a setting's value. Child of **\<setting>**.                                   |

## \<applicationSettings> element

This element contains all **\<setting>** tags that are specific to an instance of the application on a client computer. It defines no attributes.

## \<userSettings> element

This element contains all **\<setting>** tags that are specific to the user who is currently using the application. It defines no attributes.

## \<setting> element

This element defines a setting. It has the following attributes.

| Attribute        | Description |
| ---------------- | ----------- |
| **name**         | Required. The unique ID of the setting. Settings created through Visual Studio are saved with the name `ProjectName.Properties.Settings`. |
| **serializedAs** | Required. The format to use for serializing the value to text. Valid values are:<br><br>- `string`. The value is serialized as a string using a <xref:System.ComponentModel.TypeConverter>.<br>- `xml`. The value is serialized using XML serialization.<br>- `binary`. The value is serialized as text-encoded binary using binary serialization.<br />- `custom`. The settings provider has inherent knowledge of this setting and serializes and de-serializes it. |

## \<value> element

This element contains the value of a setting.

## Example

The following example shows an application settings file that defines two application-scoped settings and two user-scoped settings:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <sectionGroup name="applicationSettings" type="System.Configuration.ApplicationSettingsGroup, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
      <section name="WindowsApplication1.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
    </sectionGroup>
    <sectionGroup name="userSettings" type="System.Configuration.UserSettingsGroup, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
      <section name="WindowsApplication1.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" allowExeDefinition="MachineToLocalUser" />
    </sectionGroup>
  </configSections>
  <applicationSettings>
    <WindowsApplication1.Properties.Settings>
      <setting name="Cursor" serializeAs="String">
        <value>Default</value>
      </setting>
      <setting name="DoubleBuffering" serializeAs="String">
        <value>False</value>
      </setting>
    </WindowsApplication1.Properties.Settings>
  </applicationSettings>
  <userSettings>
    <WindowsApplication1.Properties.Settings>
      <setting name="FormTitle" serializeAs="String">
        <value>Form1</value>
      </setting>
      <setting name="FormSize" serializeAs="String">
        <value>595, 536</value>
      </setting>
    </WindowsApplication1.Properties.Settings>
  </userSettings>
</configuration>
```

## See also

[Application Settings Overview](~/docs/framework/winforms/advanced/application-settings-overview.md)   
[Application Settings Architecture](~/docs/framework/winforms/advanced/application-settings-architecture.md)
