---
title: "SaveFileDialog Component Overview (Windows Forms)"
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
  - "SaveFileDialog"
helpviewer_keywords: 
  - "Save File dialog box [Windows Forms], displaying"
  - "SaveFileDialog component [Windows Forms], about SaveFileDialog"
ms.assetid: be7a625f-46fd-4d06-9985-b613dcbf9bd2
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# SaveFileDialog Component Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.SaveFileDialog> component is a pre-configured dialog box. It is the same as the standard **Save File** dialog box used by Windows. It inherits from the <xref:System.Windows.Forms.CommonDialog> class.  
  
## Working with the SaveFileDialog Component  
 Use it as a simple solution for enabling users to save files instead of configuring your own dialog box. By relying on standard Windows dialog boxes, the basic functionality of applications you create is immediately familiar to users. Be aware, however, that when using the <xref:System.Windows.Forms.SaveFileDialog> component, you must write your own file-saving logic.  
  
 You can use the <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method to display the dialog box at run time. You can open a file in read/write mode using the <xref:System.Windows.Forms.SaveFileDialog.OpenFile%2A> method.  
  
 When it is added to a form, the <xref:System.Windows.Forms.SaveFileDialog> component appears in the tray at the bottom of the Windows Forms Designer.  
  
## See Also  
 <xref:System.Windows.Forms.SaveFileDialog>  
 [SaveFileDialog Component](../../../../docs/framework/winforms/controls/savefiledialog-component-windows-forms.md)
