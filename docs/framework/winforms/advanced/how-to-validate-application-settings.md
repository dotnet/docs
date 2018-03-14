---
title: "How to: Validate Application Settings"
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
  - "validating application settings"
  - "application settings [Windows Forms], Windows Forms"
  - "application settings [Windows Forms], validating"
ms.assetid: 9f145ada-4267-436a-aa4c-c4dcffd0afb7
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Validate Application Settings
This topic demonstrates how to validate application settings before they are persisted.  
  
 Because application settings are strongly typed, you have some confidence that users cannot assign data of an incorrect type to a given setting. However, a user still may attempt to assign a value to a setting that falls outside of acceptable bounds—for example, supplying a birth date that occurs in the future. <xref:System.Configuration.ApplicationSettingsBase>, the parent class of all application settings classes, exposes four events to enable such bounds checking. Handling these events puts all of your validation code in a single location, rather than scattering it throughout your project.  
  
 The event you use depends upon when you need to validate your settings, as described in the following table.  
  
|Event|Occurrence and use|  
|-----------|------------------------|  
|<xref:System.Configuration.ApplicationSettingsBase.SettingsLoaded>|Occurs after the initial loading of a settings property group.<br /><br /> Use this event to validate initial values for the entire property group before they are used within the application.|  
|<xref:System.Configuration.ApplicationSettingsBase.SettingChanging>|Occurs before the value of a single settings property is changed.<br /><br /> Use this event to validate a single property before it is changed. It can provide immediate feedback to users regarding their actions and choices.|  
|<xref:System.Configuration.ApplicationSettingsBase.PropertyChanged>|Occurs after the value of a single settings property is changed.<br /><br /> Use this event to validate a single property after it is changed. This event is rarely used for validation unless a lengthy, asynchronous validation process is required.|  
|<xref:System.Configuration.ApplicationSettingsBase.SettingsSaving>|Occurs before the settings property group is stored.<br /><br /> Use this event to validate values for the entire property group before they are persisted to disk.|  
  
 Typically, you will not use all of these events within the same application for validation purposes. For example, it is often possible to fulfill all validation requirements by handling only the <xref:System.Configuration.ApplicationSettingsBase.SettingChanging> event.  
  
 An event handler generally performs one of the following actions when it detects an invalid value:  
  
-   Automatically supplies a value known to be correct, such as the default value.  
  
-   Re-queries the user of server code for information.  
  
-   For events raised before their associated actions, such as <xref:System.Configuration.ApplicationSettingsBase.SettingChanging> and <xref:System.Configuration.ApplicationSettingsBase.SettingsSaving>, uses the <xref:System.ComponentModel.CancelEventArgs> argument to cancel the operation.  
  
 For more information about event handling, see [Event Handlers Overview](../../../../docs/framework/winforms/event-handlers-overview-windows-forms.md).  
  
 The following procedures show how to test for a valid birth date using either the <xref:System.Configuration.ApplicationSettingsBase.SettingChanging> or the <xref:System.Configuration.ApplicationSettingsBase.SettingsSaving> event. The procedures were written under the assumption that you have already created your application settings; in this example, we will perform bounds checking on a setting named `DateOfBirth`. For more information about creating settings, see [How to: Create Application Settings](../../../../docs/framework/winforms/advanced/how-to-create-application-settings.md).  
  
### To obtain the application settings object  
  
-   Obtain a reference to the application settings object (the wrapper instance) by completing one of the following bulleted items:  
  
    -   If you created your settings using the Visual Studio Application Settings dialog box in the **Property Editor**, you can retrieve the default settings object generated for your language through the following expression.  
  
        ```csharp  
        Configuration.Settings.Default   
        ```  
  
        ```vb  
        MySettings.Default   
        ```  
  
         -or-  
  
    -   If you are a Visual Basic developer and you created your application settings using the Project Designer, you can retrieve your settings by using the [My.Settings Object](~/docs/visual-basic/language-reference/objects/my-settings-object.md).  
  
         -or-  
  
    -   If you created your settings by deriving from <xref:System.Configuration.ApplicationSettingsBase> directly, you need to instantiate your class manually.  
  
        ```csharp  
        MyCustomSettings settings = new MyCustomSettings();  
        ```  
  
        ```vb  
        Dim Settings as New MyCustomSettings()  
        ```  
  
 The following procedures were written under the assumption that the application settings object was obtained by completing the last bulleted item in this procedure.  
  
### To validate Application Settings when a setting is changing  
  
1.  If you are a C# developer, in your form or control's `Load` event, add an event handler for the <xref:System.Configuration.ApplicationSettingsBase.SettingChanging> event.  
  
     -or-  
  
     If you are a Visual Basic developer, you should declare the `Settings` variable using the `WithEvents` keyword.  
  
    ```csharp  
    public void Form1_Load(Object sender, EventArgs e)   
    {  
        settings.SettingChanging += new SettingChangingEventHandler(MyCustomSettings_SettingChanging);  
    }  
    ```  
  
    ```vb  
    Public Sub Form1_Load(sender as Object, e as EventArgs)  
        AddHandler settings.SettingChanging, AddressOf MyCustomSettings_SettingChanging  
    End Sub   
    ```  
  
2.  Define the event handler, and write the code inside of it to perform bounds checking on the birth date.  
  
    ```csharp  
    private void MyCustomSettings_SettingChanging(Object sender, SettingChangingEventArgs e)  
    {  
        if (e.SettingName.Equals("DateOfBirth")) {  
            Date newDate = (Date)e.NewValue;  
            If (newDate > Date.Now) {  
                e.Cancel = true;  
                // Inform the user.  
            }  
        }  
    }  
    ```  
  
    ```vb  
    Private Sub MyCustomSettings_SettingChanging(sender as Object, e as SettingChangingEventArgs) Handles Settings.SettingChanging  
        If (e.SettingName.Equals("DateOfBirth")) Then  
            Dim NewDate as Date = CType(e.NewValue, Date)  
            If (NewDate > Date.Now) Then  
                e.Cancel = True  
                ' Inform the user.  
            End If  
        End If  
    End Sub  
    ```  
  
### To validate Application Settings when a Save occurs  
  
1.  In your form or control's `Load` event, add an event handler for the <xref:System.Configuration.ApplicationSettingsBase.SettingsSaving> event.  
  
    ```csharp  
    public void Form1_Load(Object sender, EventArgs e)   
    {  
        settings.SettingsSaving += new SettingsSavingEventHandler(MyCustomSettings_SettingsSaving);  
    }  
    ```  
  
    ```vb  
    Public Sub Form1_Load(Sender as Object, e as EventArgs)  
        AddHandler settings.SettingsSaving, AddressOf MyCustomSettings_SettingsSaving  
    End Sub  
    ```  
  
2.  Define the event handler, and write the code inside of it to perform bounds checking on the birth date.  
  
    ```csharp  
    private void MyCustomSettings_SettingsSaving(Object sender, SettingsSavingEventArgs e)  
    {  
        if (this["DateOfBirth"] > Date.Now) {  
            e.Cancel = true;  
        }  
    }  
    ```  
  
    ```vb  
    Private Sub MyCustomSettings_SettingsSaving(Sender as Object, e as SettingsSavingEventArgs)  
        If (Me["DateOfBirth"] > Date.Now) Then  
            e.Cancel = True  
        End If  
    End Sub  
    ```  
  
## See Also  
 [Creating Event Handlers in Windows Forms](../../../../docs/framework/winforms/creating-event-handlers-in-windows-forms.md)  
 [How to: Create Application Settings](../../../../docs/framework/winforms/advanced/how-to-create-application-settings.md)
