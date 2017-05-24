---
title: "Application Settings Schema | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
  - "CSharp"
  - "C++"
  - "jsharp"
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
---
# Application Settings Schema
Application settings allow a Windows Forms or ASP.NET application to store and retrieve application-scoped and user-scoped settings. A "setting", in this context, is any piece of information that may be specific to the application or specific to the current user - anything from a database connection string to the user's preferred default window size.  
  
 By default, application settings in a Windows Forms application uses the <xref:System.Configuration.LocalFileSettingsProvider>, which uses the .NET configuration system to store settings in an XML configuration file. For more information about the files use by application settings, see [Application Settings Architecture](../../../../docs/framework/winforms/advanced/application-settings-architecture.md).  
  
 Application settings defines the following elements as part of the configuration files it uses.  
  
|Element|Description|  
|-------------|-----------------|  
|`<applicationSettings>` Element|Contains all `<setting>` tags specific to the application.|  
|`<userSettings>` Element|Contains all `<setting>` tags specific to the current user.|  
|`<setting>` Element|Defines a setting. Child of either `<applicationSettings>` or `<userSettings>`.|  
|`<value>` Element|Defines a setting's value. Child of `<setting>`.|  
  
## \<applicationSettings> Element  
 This element contains all \<setting> tags that are specific to an instance of the application on a client computer. It defines no attributes.  
  
## \<userSettings> Element  
 This element contains all \<setting> tags that are specific to the user who is currently using the application. It defines no attributes.  
  
## \<setting> Element  
 This element defines a setting. It has the following attributes.  
  
|Element|Description|  
|-------------|-----------------|  
|`name`|Required. The unique ID of the setting. Settings created through Visual Studio are saved with the name `ProjectName``.Properties.Settings`.|  
|`serializedAs`|Required. The format to use for serializing the value to text. Valid values are:<br /><br /> -   `string`. The value is serialized as a string using a <xref:System.ComponentModel.TypeConverter>.<br />-   `xml`. The value is serialized using XML serialization.<br />-   `binary`. The value is serialized as text-encoded binary using binary serialization.<br />-   `custom`. The settings provider has inherent knowledge of this setting, and will serialize and de-serialize it.<br />-   To use binary or custom serialization, you must define your own settings class and use the <xref:System.Configuration.SettingsSerializeAsAttribute> to specify binary or custom serialization.|  
  
## \<value> Element  
 This element contains the value of a setting.  
  
## Example  
 The following code example shows an application settings file that defines two application-scoped settings and two user-scoped settings.  
  
```  
<?xml version="1.0" encoding="utf-8" ?>  
<configuration>  
    <configSections>  
        <sectionGroup name="applicationSettings" type="System.Configuration.ApplicationSettingsGroup, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" >  
            <section name="WindowsApplication1.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />  
        </sectionGroup>  
        <sectionGroup name="userSettings" type="System.Configuration.UserSettingsGroup, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" >  
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
  
## See Also  
 [Application Settings Overview](../../../../docs/framework/winforms/advanced/application-settings-overview.md)   
 [Application Settings Architecture](../../../../docs/framework/winforms/advanced/application-settings-architecture.md)