---
title: "OpenFileDialog Component Overview (Windows Forms)"
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
  - "OpenFileDialog"
helpviewer_keywords: 
  - "OpenFileDialog component [Windows Forms], about OpenFileDialog"
  - "Open File dialog box [Windows Forms], displaying in Windows Forms"
ms.assetid: cd717300-46b6-4f82-8207-b218fa7fa407
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# OpenFileDialog Component Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.OpenFileDialog> component is a pre-configured dialog box. It is the same **Open File** dialog box exposed by the Windows operating system. It inherits from the <xref:System.Windows.Forms.CommonDialog> class.  
  
## Using this Component  
 Use this component within your Windows-based application as a simple solution for file selection in lieu of configuring your own dialog box. By relying on standard Windows dialog boxes, you create applications whose basic functionality is immediately familiar to users. Be aware, however, that when using the <xref:System.Windows.Forms.OpenFileDialog> component, you must write your own file-opening logic.  
  
 Use the <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method to display the dialog at run time. You can enable users to multi-select files to be opened with the <xref:System.Windows.Forms.OpenFileDialog.Multiselect%2A> property. Additionally, you can use the <xref:System.Windows.Forms.OpenFileDialog.ShowReadOnly%2A> property to determine if a read-only check box appears in the dialog box. The <xref:System.Windows.Forms.OpenFileDialog.ReadOnlyChecked%2A> property indicates whether the read-only check box is selected. Finally, the <xref:System.Windows.Forms.FileDialog.Filter%2A> property sets the current file name filter string, which determines the choices that appear in the "Files of type" box in the dialog box.  
  
 When it is added to a form, the <xref:System.Windows.Forms.OpenFileDialog> component appears in the tray at the bottom of the Windows Forms Designer.  
  
## See Also  
 <xref:System.Windows.Forms.OpenFileDialog>  
 [OpenFileDialog Component](../../../../docs/framework/winforms/controls/openfiledialog-component-windows-forms.md)
