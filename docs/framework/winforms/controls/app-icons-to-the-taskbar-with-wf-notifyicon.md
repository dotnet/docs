---
title: "How to: Add Application Icons to the TaskBar with the Windows Forms NotifyIcon Component"
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
  - "cpp"
f1_keywords: 
  - "TrayIcon"
helpviewer_keywords: 
  - "status area icons"
  - "icons [Windows Forms], adding to taskbar"
  - "NotifyIcon component"
  - "taskbar [Windows Forms], adding icons"
ms.assetid: d28c0fe6-aaf2-4df7-ad74-928d861a8510
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Add Application Icons to the TaskBar with the Windows Forms NotifyIcon Component
The Windows Forms <xref:System.Windows.Forms.NotifyIcon> component displays a single icon in the status notification area of the taskbar. To display multiple icons in the status area, you must have multiple <xref:System.Windows.Forms.NotifyIcon> components on your form. To set the icon displayed for a control, use the <xref:System.Windows.Forms.NotifyIcon.Icon%2A> property. You can also write code in the <xref:System.Windows.Forms.NotifyIcon.DoubleClick> event handler so that something happens when the user double-clicks the icon. For example, you could make a dialog box appear for the user to configure the background process represented by the icon.  
  
> [!NOTE]
>  The <xref:System.Windows.Forms.NotifyIcon> component is used for notification purposes only, to alert users that an action or event has occurred or there has been a change in status of some sort. You should use menus, toolbars, and other user-interface elements for standard interaction with applications.  
  
### To set the icon  
  
1.  Assign a value to the <xref:System.Windows.Forms.NotifyIcon.Icon%2A> property. The value must be of type `System.Drawing.Icon` and can be loaded from an .ico file. You can specify the icon file in code or by clicking the ellipsis button (![VisualStudioEllipsesButton screenshot](../../../../docs/framework/winforms/media/vbellipsesbutton.png "vbEllipsesButton")) next to the <xref:System.Windows.Forms.NotifyIcon.Icon%2A> property in the **Properties** window, and then selecting the file in the **Open** dialog box that appears.  
  
2.  Set the <xref:System.Windows.Forms.NotifyIcon.Visible%2A> property to `true`.  
  
3.  Set the <xref:System.Windows.Forms.NotifyIcon.Text%2A> property to an appropriate ToolTip string.  
  
     In the following code example, the path set for the location of the icon is the **My Documents** folder. This location is used because you can assume that most computers running the Windows operating system will include this folder. Choosing this location also enables users with minimal system access levels to safely run the application. The following example requires a form with a <xref:System.Windows.Forms.NotifyIcon> control already added. It also requires an icon file named `Icon.ico`.  
  
    ```vb  
    ' You should replace the bold icon in the sample below  
    ' with an icon of your own choosing.  
    NotifyIcon1.Icon = New _   
       System.Drawing.Icon(System.Environment.GetFolderPath _  
       (System.Environment.SpecialFolder.Personal) _  
       & "\Icon.ico")  
    NotifyIcon1.Visible = True  
    NotifyIcon1.Text = "Antivirus program"  
    ```  
  
    ```csharp  
    // You should replace the bold icon in the sample below  
    // with an icon of your own choosing.  
    // Note the escape character used (@) when specifying the path.  
    notifyIcon1.Icon =   
       new System.Drawing.Icon (System.Environment.GetFolderPath  
       (System.Environment.SpecialFolder.Personal)  
       + @"\Icon.ico");  
    notifyIcon1.Visible = true;  
    notifyIcon1.Text = "Antivirus program";  
    ```  
  
    ```cpp  
    // You should replace the bold icon in the sample below  
    // with an icon of your own choosing.  
    notifyIcon1->Icon = gcnew   
       System::Drawing::Icon(String::Concat  
       (System::Environment::GetFolderPath  
       (System::Environment::SpecialFolder::Personal),  
       "\\Icon.ico"));  
    notifyIcon1->Visible = true;  
    notifyIcon1->Text = "Antivirus program";  
    ```  
  
## See Also  
 <xref:System.Windows.Forms.NotifyIcon>  
 <xref:System.Windows.Forms.NotifyIcon.Icon%2A>  
 [How to: Associate a Shortcut Menu with a Windows Forms NotifyIcon Component](../../../../docs/framework/winforms/controls/how-to-associate-a-shortcut-menu-with-a-windows-forms-notifyicon-component.md)  
 [NotifyIcon Component](../../../../docs/framework/winforms/controls/notifyicon-component-windows-forms.md)  
 [NotifyIcon Component Overview](../../../../docs/framework/winforms/controls/notifyicon-component-overview-windows-forms.md)
