---
title: "Application Settings Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "ApplicationsSettingsOverview"
helpviewer_keywords: 
  - "application settings [Windows Forms], about application settings"
  - "dynamic properties"
  - "user preferences [Windows Forms], tracking"
ms.assetid: 0dd8bca5-a6bf-4ac4-8eec-5725d08b38dc
caps.latest.revision: 24
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Application Settings Overview
This topic discusses how to create and store settings data on behalf of your application and your users.  
  
 The Application Settings feature of Windows Forms makes it easy to create, store, and maintain custom application and user preferences on the client computer. With Windows Forms application settings, you can store not only application data such as database connection strings, but also user-specific data, such as user application preferences. Using Visual Studio or custom managed code, you can create new settings, read them from and write them to disk, bind them to properties on your forms, and validate settings data prior to loading and saving.  
  
 Application settings enables developers to save state in their application using very little custom code, and is a replacement for dynamic properties in previous versions of the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)]. Application settings contains many improvements over dynamic properties, which are read-only, late-bound, and require more custom programming. The dynamic property classes have been retained in [!INCLUDE[dnprdnext](../../../../includes/dnprdnext-md.md)], but they are just shell classes that thinly wrap the application settings classes.  
  
## What Are Application Settings?  
 Your Windows Forms applications will often require data that is critical to running the application, but which you do not want to include directly in the application's code. If your application uses a Web Service or a database server, you may want to store this information in a separate file, so that you can change it in the future without re-compiling. Similarly, your applications may require storing data that is specific to the current user. Most applications, for example, have user preferences that customize the application's appearance and behavior.  
  
 Application settings addresses both needs by providing an easy way to store both application-scoped and user-scoped settings on the client computer. Using Visual Studio or a code editor, you define a setting for a given property by specifying its name, data type, and scope (application or user). You can even place related settings into named groups for easier use and readability. Once defined, these settings are persisted and read back into memory automatically at run time. A pluggable architecture enables the persistence mechanism to be changed, but by default, the local file system is used.  
  
 Application settings works by persisting data as XML to different configuration (.config) files, corresponding to whether the setting is application-scoped or user-scoped. In most cases, the application-scoped settings are read-only; because they are program information, you will typically not need to overwrite them. By contrast, user-scoped settings can be read and written safely at run time, even if your application runs under partial trust. For more information about partial trust, see [Security in Windows Forms Overview](../../../../docs/framework/winforms/security-in-windows-forms-overview.md).  
  
 Settings are stored as XML fragments in configuration files. Application-scoped settings are represented by the `<application.Settings>` element, and generally are placed in *app*.exe.config, where *app* is the name of your main executable file. User-scoped settings are represented by the `<userSettings>` element and are placed in *user*.config, where *user* is the user name of the person currently running the application. You must deploy the *app*.exe.config file with your application; the settings architecture will create the *user*.config files on demand the first time the application saves settings for that user. You can also define a `<userSettings>` block within *app*.exe.config to provide default values for user-scoped settings.  
  
 Custom controls can also save their own settings by implementing the <xref:System.Configuration.IPersistComponentSettings> interface, which exposes the <xref:System.Configuration.IPersistComponentSettings.SaveSettings%2A> method. The Windows Forms <xref:System.Windows.Forms.ToolStrip> control implements this interface to save the position of toolbars and toolbar items between application sessions. For more information about custom controls and application settings, see [Application Settings for Custom Controls](../../../../docs/framework/winforms/advanced/application-settings-for-custom-controls.md).  
  
## Limitations of Application Settings  
 You cannot use application settings in an unmanaged application that hosts the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)]. Settings will not work in such environments as Visual Studio add-ins, C++ for Microsoft Office, control hosting in Internet Explorer, or Microsoft Outlook add-ins and projects.  
  
 You currently cannot bind to some properties in Windows Forms. The most notable example is the <xref:System.Windows.Forms.Form.ClientSize%2A> property, as binding to this property would cause unpredictable behavior at run time. You can usually work around these issues by saving and loading these settings programmatically.  
  
 Application settings has no built-in facility for encrypting information automatically. You should never store security-related information, such as database passwords, in clear text. If you want to store such sensitive information, you as the application developer are responsible for making sure it is secure. If you want to store connection strings, we recommend that you use Windows Integrated Security and not resort to hard-coding passwords into the URL. For more information, see [Code Access Security and ADO.NET](../../../../docs/framework/data/adonet/code-access-security.md).  
  
## Getting Started with Application Settings  
 If you use Visual Studio, you can define settings within the Windows Forms Designer using the **(ApplicationSettings)** property in the **Properties** window. When you define settings this way, Visual Studio automatically creates a custom managed wrapper class which associates each setting with a class property. Visual Studio also takes care of binding the setting to a property on a form or control so that the control's settings are restored automatically when its form is displayed, and saved automatically when the form is closed.  
  
 If you want more detailed control over your settings, you can define your own custom applications settings wrapper class. This is accomplished by deriving a class from <xref:System.Configuration.ApplicationSettingsBase>, adding a property that corresponds to each setting, and applying special attributes to these properties. For details about creating wrapper classes, see [Application Settings Architecture](../../../../docs/framework/winforms/advanced/application-settings-architecture.md).  
  
 You can also use the <xref:System.Windows.Forms.Binding> class to bind settings programmatically to properties on forms and controls.  
  
## See Also  
 <xref:System.Configuration.ApplicationSettingsBase>  
 <xref:System.Configuration.SettingsProvider>  
 <xref:System.Configuration.LocalFileSettingsProvider>  
 <xref:System.Configuration.IPersistComponentSettings>  
 [How to: Validate Application Settings](../../../../docs/framework/winforms/advanced/how-to-validate-application-settings.md)  
 [Managing Application Settings (.NET)](http://msdn.microsoft.com/library/35254321-ad14-47d9-b8c6-39ab3203c5d9)  
 [How To: Read Settings at Run Time With C#](../../../../docs/framework/winforms/advanced/how-to-read-settings-at-run-time-with-csharp.md)  
 [Using Application Settings and User Settings](../../../../docs/framework/winforms/advanced/using-application-settings-and-user-settings.md)  
 [Application Settings Architecture](../../../../docs/framework/winforms/advanced/application-settings-architecture.md)  
 [Application Settings for Custom Controls](../../../../docs/framework/winforms/advanced/application-settings-for-custom-controls.md)
