---
title: "HelpProvider Component Overview (Windows Forms)"
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
  - "HelpProvider"
helpviewer_keywords: 
  - "HelpProvider component [Windows Forms], about HelpProvider component"
  - "Help [Windows Forms], adding to Windows applications"
  - "F1 Help [Windows Forms], adding to Windows Forms"
  - "dialog boxes [Windows Forms], context-sensitive Help"
  - "Windows Forms, context-sensitive Help"
ms.assetid: 6b10c2cc-c577-4cb5-9669-e37b33416af9
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# HelpProvider Component Overview (Windows Forms)
The Windows Forms [HelpProvider](../../../../docs/framework/winforms/controls/helpprovider-component-windows-forms.md) component is used to associate an HTML Help 1.x Help file (either a .chm file, produced with the HTML Help Workshop, or an .htm file) with your Windows application. You can provide help in a variety of ways:  
  
-   Provide context-sensitive Help for controls on Windows Forms.  
  
-   Provide context-sensitive Help on a particular dialog box or specific controls on a dialog box.  
  
-   Open a Help file to specific areas, such as the main page of a Table of Contents, the Index, or a search function.  
  
## Using the Help Provider  
 Adding a <xref:System.Windows.Forms.HelpProvider> component to your Windows Form allows the other controls on the form to expose the Help properties of the <xref:System.Windows.Forms.HelpProvider> component. This enables you to provide help for the controls on your Windows Form. You can associate a Help file with the <xref:System.Windows.Forms.HelpProvider> component using the <xref:System.Windows.Forms.HelpProvider.HelpNamespace%2A> property. You specify the type of Help provided by calling <xref:System.Windows.Forms.HelpProvider.SetHelpNavigator%2A> and providing a value from the <xref:System.Windows.Forms.HelpNavigator> enumeration for the specified control. You provide the keyword or topic for Help by calling the <xref:System.Windows.Forms.HelpProvider.SetHelpKeyword%2A> method.  
  
 Optionally, to associate a specific Help string with another control, use the <xref:System.Windows.Forms.HelpProvider.SetHelpString%2A> method. The string that you associate with a control using this method is displayed in a pop-up window when the user presses the F1 key while the control has focus.  
  
 If <xref:System.Windows.Forms.HelpProvider.HelpNamespace%2A> has not been set, you must use <xref:System.Windows.Forms.HelpProvider.SetHelpString%2A> to provide the Help text. If you have set both <xref:System.Windows.Forms.HelpProvider.HelpNamespace%2A> and the Help string, Help based on <xref:System.Windows.Forms.HelpProvider.HelpNamespace%2A> will take precedence.  
  
> [!NOTE]
>  You may encounter problems using the relative path when specifiying the path to the Help file in the <xref:System.Windows.Forms.Help.ShowHelp%2A> method or <xref:System.Windows.Forms.HelpProvider.HelpNamespace%2A> property of the <xref:System.Windows.Forms.HelpProvider> control. As such, be sure to use the absolute file path to specify the Help file.  
  
## See Also  
 [Help Systems in Windows Forms Applications](../../../../docs/framework/winforms/advanced/help-systems-in-windows-forms-applications.md)
