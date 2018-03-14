---
title: "Ways to Select a Windows Forms Button Control"
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
  - "Button control [Windows Forms], selecting"
ms.assetid: fe2fc058-5118-4f70-b264-6147d64a7a8d
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Ways to Select a Windows Forms Button Control
A Windows Forms button can be selected in the following ways:  
  
-   Use a mouse to click the button.  
  
-   Invoke the button's <xref:System.Windows.Forms.Control.Click> event in code.  
  
-   Move the focus to the button by pressing the TAB key, and then choose the button by pressing the SPACEBAR or ENTER.  
  
-   Press the access key (ALT + the underlined letter) for the button. For more information about access keys, see [How to: Create Access Keys for Windows Forms Controls](../../../../docs/framework/winforms/controls/how-to-create-access-keys-for-windows-forms-controls.md).  
  
-   If the button is the "accept" button of the form, pressing ENTER chooses the button, even if another control has the focus — except if that other control is another button, a multi-line text box, or a custom control that traps the enter key.  
  
-   If the button is the "cancel" button of the form, pressing ESC chooses the button, even if another control has the focus.  
  
-   Call the <xref:System.Windows.Forms.Button.PerformClick%2A> method to select the button programmatically.  
  
## See Also  
 [Button Control Overview](../../../../docs/framework/winforms/controls/button-control-overview-windows-forms.md)  
 [How to: Respond to Windows Forms Button Clicks](../../../../docs/framework/winforms/controls/how-to-respond-to-windows-forms-button-clicks.md)  
 [Button Control](../../../../docs/framework/winforms/controls/button-control-windows-forms.md)
