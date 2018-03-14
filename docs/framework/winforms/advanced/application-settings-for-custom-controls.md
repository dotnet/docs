---
title: "Application Settings for Custom Controls"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "custom controls [Windows Forms], application settings"
  - "application settings [Windows Forms], custom controls"
ms.assetid: f44afb74-76cc-44f2-890a-44b7cdc211a1
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Application Settings for Custom Controls
You must complete certain tasks to give your custom controls the ability to persist application settings when the controls are hosted in third-party applications.  
  
 Most of the documentation about the Application Settings feature is written under the assumption that you are creating a standalone application. However, if you are creating a control that other developers will host in their applications, you need to take a few additional steps for your control to persist its settings properly.  
  
## Application Settings and Custom Controls  
 For your control to properly persist its settings, it must encapsulate the process by creating its own dedicated applications settings wrapper class, derived from <xref:System.Configuration.ApplicationSettingsBase>. Additionally, the main control class must implement the <xref:System.Configuration.IPersistComponentSettings>. The interface contains several properties as well as two methods, <xref:System.Configuration.IPersistComponentSettings.LoadComponentSettings%2A> and <xref:System.Configuration.IPersistComponentSettings.SaveComponentSettings%2A>. If you add your control to a form using the **Windows Forms Designer** in Visual Studio, Windows Forms will call <xref:System.Configuration.IPersistComponentSettings.LoadComponentSettings%2A> automatically when the control is initialized; you must call <xref:System.Configuration.IPersistComponentSettings.SaveComponentSettings%2A> yourself in the `Dispose` method of your control.  
  
 In addition, you should implement the following in order for application settings for custom controls to work properly in design-time environments such as Visual Studio:  
  
1.  A custom application settings class with a constructor that takes an <xref:System.ComponentModel.IComponent> as a single parameter. Use this class to save and load all of your application settings. When you create a new instance of this class, pass your custom control using the constructor.  
  
2.  Create this custom settings class after the control has been created and placed on a form, such as in the form's <xref:System.Windows.Forms.Form.Load> event handler.  
  
 For instructions on creating a custom settings class, see [How to: Create Application Settings](../../../../docs/framework/winforms/advanced/how-to-create-application-settings.md).  
  
## Settings Keys and Shared Settings  
 Some controls can be used multiple times within the same form. Most of the time, you will want these controls to persist their own individual settings. With the <xref:System.Configuration.IPersistComponentSettings.SettingsKey%2A> property on <xref:System.Configuration.IPersistComponentSettings>, you can supply a unique string that acts to disambiguate multiple versions of a control on a form.  
  
 The simplest way to implement <xref:System.Configuration.IPersistComponentSettings.SettingsKey%2A> is to use the <xref:System.Windows.Forms.Control.Name%2A> property of the control for the <xref:System.Configuration.IPersistComponentSettings.SettingsKey%2A>. When you load or save the control's settings, you pass the value of <xref:System.Configuration.IPersistComponentSettings.SettingsKey%2A> on to the <xref:System.Configuration.ApplicationSettingsBase.SettingsKey%2A> property of the <xref:System.Configuration.ApplicationSettingsBase> class. Application Settings uses this unique key when it persists the user's settings to XML. The following code example shows how a `<userSettings>` section may look for an instance of a custom control named `CustomControl1` that saves a setting for its `Text` property.  
  
```xml  
<userSettings>  
    <CustomControl1>  
        <setting name="Text" serializedAs="string">  
            <value>Hello, World</value>  
        </setting>  
    </CustomControl1>  
</userSettings>  
```  
  
 Any instances of a control that do not supply a value for <xref:System.Configuration.ApplicationSettingsBase.SettingsKey%2A> will share the same settings.  
  
## See Also  
 <xref:System.Configuration.ApplicationSettingsBase>  
 <xref:System.Configuration.IPersistComponentSettings>  
 [Application Settings Architecture](../../../../docs/framework/winforms/advanced/application-settings-architecture.md)
