---
title: "How to: Provide Help in a Windows Application"
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
  - "Help [Windows Forms], Windows applications"
  - "HTML Help [Windows Forms], Windows Forms"
  - "Windows applications [Windows Forms], providing Help"
  - "HelpProvider component [Windows Forms]"
  - "forms [Windows Forms], providing Help"
ms.assetid: 7c4e5cec-2bd2-4f0b-8d75-c2b88929bd61
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Provide Help in a Windows Application
You can use of the <xref:System.Windows.Forms.HelpProvider> component to attach Help topics within a Help file to specific controls on Windows Forms. The Help file can be either HTML or HTMLHelp 1.x or greater format.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To provide Help  
  
1.  From the **Toolbox**, drag a <xref:System.Windows.Forms.HelpProvider> component to your form.  
  
     The component will reside in the tray at the bottom of the Windows Forms Designer.  
  
2.  In the **Properties** window, set the <xref:System.Windows.Forms.HelpProvider.HelpNamespace%2A> property to the .chm, .col, or .htm Help file.  
  
3.  Select another control you have on your form, and in the **Properties** window, set the <xref:System.Windows.Forms.HelpProvider.SetHelpKeyword%2A> property.  
  
     This is the string passed through the <xref:System.Windows.Forms.HelpProvider> component to your Help file to summon the appropriate Help topic.  
  
4.  In the **Properties** window, set the <xref:System.Windows.Forms.HelpProvider.SetHelpNavigator%2A> property to a value of the <xref:System.Windows.Forms.HelpNavigator> enumeration.  
  
     This determines the way in which the **HelpKeyword** property is passed to the Help system. The following table shows the possible settings and their descriptions.  
  
    |Member Name|Description|  
    |-----------------|-----------------|  
    |AssociateIndex|Specifies that the index for a specified topic is performed in the specified URL.|  
    |Find|Specifies that the search page of a specified URL is displayed.|  
    |Index|Specifies that the index of a specified URL is displayed.|  
    |KeywordIndex|Specifies a keyword to search for and the action to take in the specified URL.|  
    |TableOfContents|Specifies that the table of contents of the HTML 1.0 Help file is displayed.|  
    |Topic|Specifies that the topic referenced by the specified URL is displayed.|  
  
 At run time, pressing F1 when the control—for which you have set the **HelpKeyword** and **HelpNavigator** properties—has focus will open the Help file you associated with that <xref:System.Windows.Forms.HelpProvider> component.  
  
 Currently, the **HelpNamespace** property supports Help files in the following three formats: HTMLHelp 1.x, HTMLHelp 2.0, and HTML. Thus, you can set the **HelpNamespace** property to an http:// address, such as a Web page. If this is done, it will open the default browser to the Web page with the string specified in the **HelpKeyword** property used as the anchor. The anchor is used to jump to a specific part of an HTML page.  
  
> [!IMPORTANT]
>  Be careful to check any information that is sent from a client before using it in your application. Malicious users might try to send or inject executable script, SQL statements, or other code. Before you display a user's input, store it in a database, or work with it, check that it does not contain potentially unsafe information. A typical way to check is to use a regular expression to look for keywords such as "SCRIPT" when you receive input from a user.  
  
 You can also use the <xref:System.Windows.Forms.HelpProvider> component to show pop-up Help, even if you have it configured to display Help files for the controls on your Windows Forms. For more information, see [How to: Display Pop-up Help](../../../../docs/framework/winforms/advanced/how-to-display-pop-up-help.md).  
  
## See Also  
 [How to: Display Pop-up Help](../../../../docs/framework/winforms/advanced/how-to-display-pop-up-help.md)  
 [Control Help Using ToolTips](../../../../docs/framework/winforms/advanced/control-help-using-tooltips.md)  
 [Integrating User Help in Windows Forms](../../../../docs/framework/winforms/advanced/integrating-user-help-in-windows-forms.md)  
 [Windows Forms](../../../../docs/framework/winforms/index.md)
