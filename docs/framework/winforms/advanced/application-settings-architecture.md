---
title: "Application Settings Architecture"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "application settings [Windows Forms], architecture"
ms.assetid: c8eb2ad0-fac6-4ea2-9140-675a4a44d562
caps.latest.revision: 25
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Application Settings Architecture
This topic describes how the Application Settings architecture works, and explores advanced features of the architecture, such as grouped settings and settings keys.  
  
 The application settings architecture supports defining strongly typed settings with either application or user scope, and persisting the settings between application sessions. The architecture provides a default persistence engine for saving settings to and loading them from the local file system. The architecture also defines interfaces for supplying a custom persistence engine.  
  
 Interfaces are provided that enable custom components to persist their own settings when they are hosted in an application. By using settings keys, components can keep settings for multiple instances of the component separate.  
  
## Defining Settings  
 The application settings architecture is used within both [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] and Windows Forms, and it contains a number of base classes that are shared across both environments. The most important is <xref:System.Configuration.SettingsBase>, which provides access to settings through a collection, and provides low-level methods for loading and saving settings. Each environment implements its own class derived from <xref:System.Configuration.SettingsBase> to provide additional settings functionality for that environment. In a Windows Forms-based application, all application settings must be defined on a class derived from the <xref:System.Configuration.ApplicationSettingsBase> class, which adds the following functionality to the base class:  
  
-   Higher-level loading and saving operations  
  
-   Support for user-scoped settings  
  
-   Reverting a user's settings to the predefined defaults  
  
-   Upgrading settings from a previous application version  
  
-   Validating settings, either before they are changed or before they are saved  
  
 The settings can be described using a number of attributes defined within the <xref:System.Configuration> namespace; these are described in [Application Settings Attributes](../../../../docs/framework/winforms/advanced/application-settings-attributes.md). When you define a setting, you must apply it with either <xref:System.Configuration.ApplicationScopedSettingAttribute> or <xref:System.Configuration.UserScopedSettingAttribute>, which describes whether the setting applies to the entire application or just to the current user.  
  
 The following code example defines a custom settings class with a single setting, `BackgroundColor`.  
  
 [!code-csharp[ApplicationSettings.Create#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/ApplicationSettings.Create/CS/MyAppSettings.cs#1)]
 [!code-vb[ApplicationSettings.Create#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ApplicationSettings.Create/VB/MyAppSettings.vb#1)]  
  
## Settings Persistence  
 The <xref:System.Configuration.ApplicationSettingsBase> class does not itself persist or load settings; this job falls to the settings provider, a class that derives from <xref:System.Configuration.SettingsProvider>. If a derived class of <xref:System.Configuration.ApplicationSettingsBase> does not specify a settings provider through the <xref:System.Configuration.SettingsProviderAttribute>, then the default provider, <xref:System.Configuration.LocalFileSettingsProvider>, is used.  
  
 The configuration system that was originally released with the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] supports providing static application configuration data through either the local computer's machine.config file or within an `app.`exe.config file that you deploy with your application. The <xref:System.Configuration.LocalFileSettingsProvider> class expands this native support in the following ways:  
  
-   Application-scoped settings can be stored in either the machine.config or `app.`exe.config files. Machine.config is always read-only, while `app`.exe.config is restricted by security considerations to read-only for most applications.  
  
-   User-scoped settings can be stored in `app`.exe.config files, in which case they are treated as static defaults.  
  
-   Non-default user-scoped settings are stored in a new file, *user*.config, where *user* is the user name of the person currently executing the application. You can specify a default for a user-scoped setting with <xref:System.Configuration.DefaultSettingValueAttribute>. Because user-scoped settings often change during application execution, `user`.config is always read/write.  
  
 All three configuration files store settings in XML format. The top-level XML element for application-scoped settings is `<appSettings>`, while `<userSettings>` is used for user-scoped settings. An `app`.exe.config file which contains both application-scoped settings and defaults for user-scoped settings would look like this:  
  
```xml  
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
  
 For a definition of the elements within the application settings section of a configuration file, see [Application Settings Schema](../../../../docs/framework/configure-apps/file-schema/application-settings-schema.md).  
  
### Settings Bindings  
 Application settings uses the Windows Forms data binding architecture to provide two-way communication of settings updates between the settings object and components. If you use Visual Studio to create application settings and assign them to component properties, these bindings are generated automatically.  
  
 You can only bind an application setting to a component that supports the <xref:System.Windows.Forms.IBindableComponent> interface. Also, the component must implement a change event for a specific bound property, or notify application settings that the property has changed through the <xref:System.ComponentModel.INotifyPropertyChanged> interface. If the component does not implement <xref:System.Windows.Forms.IBindableComponent> and you are binding through Visual Studio, the bound properties will be set the first time, but will not update. If the component implements <xref:System.Windows.Forms.IBindableComponent> but does not support property change notifications, the binding will not update in the settings file when the property is changed.  
  
 Some Windows Forms components, such as <xref:System.Windows.Forms.ToolStripItem>, do not support settings bindings.  
  
### Settings Serialization  
 When <xref:System.Configuration.LocalFileSettingsProvider> must save settings to disk, it performs the following actions:  
  
1.  Uses reflection to examine all of the properties defined on your <xref:System.Configuration.ApplicationSettingsBase> derived class, finding those that are applied with either <xref:System.Configuration.ApplicationScopedSettingAttribute> or <xref:System.Configuration.UserScopedSettingAttribute>.  
  
2.  Serializes the property to disk. It first attempts to call the <xref:System.ComponentModel.TypeConverter.ConvertToString%2A> or <xref:System.ComponentModel.TypeConverter.ConvertFromString%2A> on the type's associated <xref:System.ComponentModel.TypeConverter>. If this does not succeed, it uses XML serialization instead.  
  
3.  Determines which settings go in which files, based on the setting's attribute.  
  
 If you implement your own settings class, you can use the <xref:System.Configuration.SettingsSerializeAsAttribute> to mark a setting for either binary or custom serialization using the <xref:System.Configuration.SettingsSerializeAs> enumeration. For more information on creating your own settings class in code, see [How to: Create Application Settings](../../../../docs/framework/winforms/advanced/how-to-create-application-settings.md).  
  
### Settings File Locations  
 The location of the `app`.exe.config and *user*.config files will differ based on how the application is installed. For a Windows Forms-based application copied onto the local computer, `app`.exe.config will reside in the same directory as the base directory of the application's main executable file, and *user*.config will reside in the location specified by the <xref:System.Windows.Forms.Application.LocalUserAppDataPath%2A?displayProperty=nameWithType> property. For an application installed by means of [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)], both of these files will reside in the [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)] Data Directory underneath %InstallRoot%\Documents and Settings\\*username*\Local Settings.  
  
 The storage location of these files is slightly different if a user has enabled roaming profiles, which enables a user to define different Windows and application settings when he or she is using other computers within a domain. In that case, both [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)] applications and non-[!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)] applications will have their `app`.exe.config and *user*.config files stored under %InstallRoot%\Documents and Settings\\*username*\Application Data.  
  
 For more information about how the Application Settings feature works with the new deployment technology, see [ClickOnce and Application Settings](/visualstudio/deployment/clickonce-and-application-settings). For more information about the [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)] Data Directory, see [Accessing Local and Remote Data in ClickOnce Applications](/visualstudio/deployment/accessing-local-and-remote-data-in-clickonce-applications).  
  
## Application Settings and Security  
 Application settings are designed to work in partial trust, a restricted environment that is the default for Windows Forms applications hosted over the Internet or an intranet. No special permissions beyond partial trust are needed to use application settings with the default settings provider.  
  
 When application settings are used in a [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)] application, the `user`.config file is stored in the [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)] data directory. The size of the application's `user`.config file cannot exceed the data directory quota set by [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)]. For more information, see [ClickOnce and Application Settings](/visualstudio/deployment/clickonce-and-application-settings).  
  
## Custom Settings Providers  
 In the Application Settings architecture, there is a loose coupling between the applications settings wrapper class, derived from <xref:System.Configuration.ApplicationSettingsBase>, and the associated settings provider or providers, derived from <xref:System.Configuration.SettingsProvider>. This association is defined only by the <xref:System.Configuration.SettingsProviderAttribute> applied to the wrapper class or its individual properties. If a settings provider is not explicitly specified, the default provider, <xref:System.Configuration.LocalFileSettingsProvider>, is used. As a result, this architecture supports creating and using custom settings providers.  
  
 For example, suppose that you want to develop and use `SqlSettingsProvider`, a provider that will store all settings data in a Microsoft SQL Server database. Your <xref:System.Configuration.SettingsProvider>-derived class would receive this information in its `Initialize` method as a parameter of type <xref:System.Collections.Specialized.NameValueCollection?displayProperty=nameWithType>. You would then implement the <xref:System.Configuration.SettingsProvider.GetPropertyValues%2A> method to retrieve your settings from the data store, and <xref:System.Configuration.SettingsProvider.SetPropertyValues%2A> to save them. Your provider can use the <xref:System.Configuration.SettingsPropertyCollection> supplied to <xref:System.Configuration.SettingsProvider.GetPropertyValues%2A> to determine the property's name, type, and scope, as well as any other settings attributes defined for that property.  
  
 Your provider will need to implement one property and one method whose implementations may not be obvious. The <xref:System.Configuration.SettingsProvider.ApplicationName%2A> property is an abstract property of <xref:System.Configuration.SettingsProvider>; you should program it to return the following:  
  
 [!code-csharp[ApplicationSettings.Architecture#2](../../../../samples/snippets/csharp/VS_Snippets_Winforms/ApplicationSettings.Architecture/CS/DummyClass.cs#2)]
 [!code-vb[ApplicationSettings.Architecture#2](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ApplicationSettings.Architecture/VB/DummyProviderClass.vb#2)]  
  
 Your derived class must also implement an `Initialize` method that takes no arguments and returns no value. This method is not defined by <xref:System.Configuration.SettingsProvider>.  
  
 Finally, you implement <xref:System.Configuration.IApplicationSettingsProvider> on your provider to provide support for refreshing settings, reverting settings to their defaults, and upgrading settings from one application version to another.  
  
 Once you have implemented and compiled your provider, you need to instruct your settings class to use this provider instead of the default. You accomplish this through the <xref:System.Configuration.SettingsProviderAttribute>. If applied to an entire settings class, the provider is used for each setting that the class defines; if applied to individual settings, Application Settings architecture uses that provider for those settings only, and uses <xref:System.Configuration.LocalFileSettingsProvider> for the rest. The following code example shows how to instruct the settings class to use your custom provider.  
  
 [!code-csharp[ApplicationSettings.Architecture#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/ApplicationSettings.Architecture/CS/DummyClass.cs#1)]
 [!code-vb[ApplicationSettings.Architecture#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ApplicationSettings.Architecture/VB/DummyProviderClass.vb#1)]  
  
 A provider may be called from multiple threads simultaneously, but it will always write to the same storage location; therefore, the Application Settings architecture will only ever instantiate a single instance of your provider class.  
  
> [!IMPORTANT]
>  You should ensure that your provider is thread-safe, and only allows one thread at a time to write to the configuration files.  
  
 Your provider does not need to support all of the settings attributes defined in the <xref:System.Configuration?displayProperty=nameWithType> namespace, though it must at a minimum support <xref:System.Configuration.ApplicationScopedSettingAttribute> and <xref:System.Configuration.UserScopedSettingAttribute>, and should also support <xref:System.Configuration.DefaultSettingValueAttribute>. For those attributes that it does not support, your provider should just fail without notification; it should not throw an exception. If the settings class uses an invalid combination of attributes, however — such as applying <xref:System.Configuration.ApplicationScopedSettingAttribute> and <xref:System.Configuration.UserScopedSettingAttribute> to the same setting — your provider should throw an exception and cease operation.  
  
## See Also  
 <xref:System.Configuration.ApplicationSettingsBase>  
 <xref:System.Configuration.SettingsProvider>  
 <xref:System.Configuration.LocalFileSettingsProvider>  
 [Application Settings Overview](../../../../docs/framework/winforms/advanced/application-settings-overview.md)  
 [Application Settings for Custom Controls](../../../../docs/framework/winforms/advanced/application-settings-for-custom-controls.md)  
 [ClickOnce and Application Settings](/visualstudio/deployment/clickonce-and-application-settings)  
 [Application Settings Schema](../../../../docs/framework/configure-apps/file-schema/application-settings-schema.md)
