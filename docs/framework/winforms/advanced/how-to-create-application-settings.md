---
title: "How to: Create Application Settings"
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
  - "application settings [Windows Forms], Windows Forms"
  - "application settings [Windows Forms], creating"
ms.assetid: 1e7aa347-af75-41e5-89ca-f53cab704f72
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create Application Settings
Using managed code, you can create new application settings and bind them to properties on your form or your form's controls, so that these settings are loaded and saved automatically at run time.  
  
 In the following procedure, you manually create a wrapper class that derives from <xref:System.Configuration.ApplicationSettingsBase>. To this class you add a publicly accessible property for each application setting that you want to expose.  
  
 You can also perform this procedure using minimal code in the Visual Studio designer.  Also see [How to: Create Application Settings Using the Designer](http://msdn.microsoft.com/library/wabtadw6\(v=vs.110\)).  
  
### To create new Application Settings programmatically  
  
1.  Add a new class to your project, and rename it. For this procedure, we will call this class `MyUserSettings`. Change the class definition so that the class derives from <xref:System.Configuration.ApplicationSettingsBase>.  
  
2.  Define a property on this wrapper class for each application setting you require, and apply that property with either the <xref:System.Configuration.ApplicationScopedSettingAttribute> or <xref:System.Configuration.UserScopedSettingAttribute>, depending on the scope of the setting. For more information about settings scope, see [Application Settings Overview](../../../../docs/framework/winforms/advanced/application-settings-overview.md). By now, your code should look like this:  
  
     [!code-csharp[ApplicationSettings.Create#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/ApplicationSettings.Create/CS/MyAppSettings.cs#1)]
     [!code-vb[ApplicationSettings.Create#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ApplicationSettings.Create/VB/MyAppSettings.vb#1)]  
  
3.  Create an instance of this wrapper class in your application. It will commonly be a private member of the main form. Now that you have defined your class, you need to bind it to a property; in this case, the <xref:System.Windows.Forms.Form.BackColor%2A> property of your form. You can accomplish this in your form's `Load` event handler.  
  
     [!code-csharp[ApplicationSettings.Create#2](../../../../samples/snippets/csharp/VS_Snippets_Winforms/ApplicationSettings.Create/CS/Form1.cs#2)]
     [!code-vb[ApplicationSettings.Create#2](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ApplicationSettings.Create/VB/Form1.vb#2)]  
  
4.  If you provide a way to change settings at run time, you will need to save the user's current settings to disk when your form closes, or else these changes will be lost.  
  
     [!code-csharp[ApplicationSettings.Create#3](../../../../samples/snippets/csharp/VS_Snippets_Winforms/ApplicationSettings.Create/CS/Form1.cs#3)]
     [!code-vb[ApplicationSettings.Create#3](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ApplicationSettings.Create/VB/Form1.vb#3)]  
  
     You have now successfully created a new application setting and bound it to the specified property.  
  
## .NET Framework Security  
 The default settings provider, <xref:System.Configuration.LocalFileSettingsProvider>, persists information to configuration files as plain text. This limits security to the file access security provided by the operating system for the current user. Because of this, care must be taken with the information stored in configuration files. For example, one common use for application settings is to store connection strings that point to the application's data store. However, because of security concerns, such strings should not include passwords. For more information about connection strings, see <xref:System.Configuration.SpecialSetting>.  
  
## See Also  
 <xref:System.Configuration.SpecialSettingAttribute>  
 <xref:System.Configuration.LocalFileSettingsProvider>  
 [Application Settings Overview](../../../../docs/framework/winforms/advanced/application-settings-overview.md)  
 [How to: Validate Application Settings](../../../../docs/framework/winforms/advanced/how-to-validate-application-settings.md)
