---
title: "Label Control Overview (Windows Forms)"
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
  - "Label"
helpviewer_keywords: 
  - "images [Windows Forms], displaying in labels"
  - "labels"
  - "Label control [Windows Forms], about Label control"
ms.assetid: dcad7f44-11b7-4c55-b0c0-d984ade43d7d
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Label Control Overview (Windows Forms)
Windows Forms <xref:System.Windows.Forms.Label> controls are used to display text or images that cannot be edited by the user. They are used to identify objects on a form — to provide a description of what a certain control will do if clicked, for example, or to display information in response to a run-time event or process in your application. For example, you can use labels to add descriptive captions to text boxes, list boxes, combo boxes, and so on. You can also write code that changes the text displayed by a label in response to events at run time. For example, if your application takes a few minutes to process a change, you can display a processing-status message in a label.  
  
## Working with the Label Control  
 Because the <xref:System.Windows.Forms.Label> control cannot receive the focus, it can also be used to create access keys for other controls. An access key allows a user to select the other control by pressing the ALT key with the access key. For more information, see [Creating Access Keys for Windows Forms Controls](../../../../docs/framework/winforms/controls/how-to-create-access-keys-for-windows-forms-controls.md) and [How to: Create Access Keys with Windows Forms Label Controls](../../../../docs/framework/winforms/controls/how-to-create-access-keys-with-windows-forms-label-controls.md).  
  
 The caption displayed in the label is contained in the <xref:System.Windows.Forms.Label.Text%2A> property. The <xref:System.Windows.Forms.Label.TextAlign%2A> property allows you to set the alignment of the text within the label. For more information, see [How to: Set the Text Displayed by a Windows Forms Control](../../../../docs/framework/winforms/controls/how-to-set-the-text-displayed-by-a-windows-forms-control.md).  
  
## See Also  
 <xref:System.Windows.Forms.Label>  
 [How to: Size a Windows Forms Label Control to Fit Its Contents](../../../../docs/framework/winforms/controls/how-to-size-a-windows-forms-label-control-to-fit-its-contents.md)  
 [How to: Create Access Keys with Windows Forms Label Controls](../../../../docs/framework/winforms/controls/how-to-create-access-keys-with-windows-forms-label-controls.md)
