---
title: "How to: Create Access Keys with Windows Forms Label Controls"
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
helpviewer_keywords: 
  - "controls [Windows Forms], access keys"
  - "dialog box controls [Windows Forms], mnemonics"
  - "access keys [Windows Forms], creating for controls"
  - "Label control [Windows Forms], creating access keys"
  - "mnemonics [Windows Forms], adding to dialog box controls"
  - "mnemonics"
  - "Windows Forms controls, access keys"
  - "UseMnemonic property [Windows Forms], Label control"
  - "keyboard shortcuts [Windows Forms], creating for controls"
  - "access keys [Windows Forms], Windows Forms"
ms.assetid: 5ee8f823-80be-4a4f-96a4-412671e2e306
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create Access Keys with Windows Forms Label Controls
Windows Forms <xref:System.Windows.Forms.Label> controls can be used to define access keys for other controls. When you define an access key in a label control, the user can press the ALT key plus the character you designate to move the focus to the control that follows it in the tab order. Because labels cannot receive focus, focus automatically moves to the next control in the tab order. Use this technique to assign access keys to text boxes, combo boxes, list boxes, and data grids.  
  
### To assign an access key to a control with a label  
  
1.  Draw the label first, and then draw the other control.  
  
     -or-  
  
     Draw the controls in any order and set the <xref:System.Windows.Forms.Control.TabIndex%2A> property of the label to one less than the other control.  
  
2.  Set the label's <xref:System.Windows.Forms.Label.UseMnemonic%2A> property to `true`.  
  
3.  Use an ampersand (&) in the label's <xref:System.Windows.Forms.Label.Text%2A> property to assign the access key for the label. For more information, see [Creating Access Keys for Windows Forms Controls](../../../../docs/framework/winforms/controls/how-to-create-access-keys-for-windows-forms-controls.md).  
  
    > [!NOTE]
    >  You may want to display ampersands in a label control, rather than use them to create access keys. This may occur if you bind a label control to a field in a recordset where the data includes ampersands. To display ampersands in a label control, set the <xref:System.Windows.Forms.Label.UseMnemonic%2A> property to `false`. If you wish to display ampersands and also have an access key, set the <xref:System.Windows.Forms.Label.UseMnemonic%2A> property to `true` and indicate the access key with one ampersand (&) and the ampersand to display with two ampersands.  
  
    ```vb  
    Label1.UseMnemonic = True  
    Label1.Text = "&Print"  
    Label2.UseMnemonic = True  
    Label2.Text = "&Copy && Paste"  
    ```  
  
    ```csharp  
    label1.UseMnemonic = true;  
    label1.Text = "&Print";  
    label2.UseMnemonic = true;  
    label2.Text = "&Copy && Paste";  
    ```  
  
    ```cpp  
    label1->UseMnemonic = true;  
    label1->Text = "&Print";  
    label2->UseMnemonic = true;  
    label2->Text = "&Copy && Paste";  
    ```  
  
## See Also  
 [How to: Size a Windows Forms Label Control to Fit Its Contents](../../../../docs/framework/winforms/controls/how-to-size-a-windows-forms-label-control-to-fit-its-contents.md)  
 [Label Control Overview](../../../../docs/framework/winforms/controls/label-control-overview-windows-forms.md)  
 [Label Control](../../../../docs/framework/winforms/controls/label-control-windows-forms.md)
