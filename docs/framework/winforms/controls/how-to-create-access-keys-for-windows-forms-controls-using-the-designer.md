---
title: "How to: Create Access Keys for Windows Forms Controls Using the Designer"
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
  - "controls [Windows Forms], access keys"
  - "Button control [Windows Forms], access keys"
  - "dialog box controls [Windows Forms], mnemonics"
  - "access keys [Windows Forms], creating for controls"
  - "mnemonics [Windows Forms], adding to dialog box controls"
  - "ampersand character in shortcut key"
  - "Windows Forms controls, access keys"
  - "examples [Windows Forms], controls"
  - "Text property [Windows Forms], specifying access keys for controls"
  - "keyboard shortcuts [Windows Forms], creating for controls"
  - "access keys [Windows Forms], Windows Forms"
  - "ALT key"
ms.assetid: 4c374c4c-4ca9-4a68-ac96-9dc3ab0f518a
caps.latest.revision: 5
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create Access Keys for Windows Forms Controls Using the Designer
An *access key* is an underlined character in the text of a menu, menu item, or the label of a control such as a button. It enables the user to "click" a button by pressing the ALT key in combination with the predefined access key. For example, if a button runs a procedure to print a form, and therefore its `Text` property is set to "Print," adding an ampersand (&) before the letter "P" causes the letter "P" to be underlined in the button text at run time. The user can run the command associated with the button by pressing ALT+P. You cannot have an access key for a control that cannot receive focus.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To create an access key for a control  
  
1.  In the **Properties** window, set the `Text` property to a string that includes an ampersand (&) before the letter that will be the access key. For example, to set the letter "P" as the access key, type **&Print** into the grid.  
  
## See Also  
 <xref:System.Windows.Forms.Button>  
 [How to: Respond to Windows Forms Button Clicks](../../../../docs/framework/winforms/controls/how-to-respond-to-windows-forms-button-clicks.md)  
 [How to: Set the Text Displayed by a Windows Forms Control](../../../../docs/framework/winforms/controls/how-to-set-the-text-displayed-by-a-windows-forms-control.md)  
 [Labeling Individual Windows Forms Controls and Providing Shortcuts to Them](../../../../docs/framework/winforms/controls/labeling-individual-windows-forms-controls-and-providing-shortcuts-to-them.md)
