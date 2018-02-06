---
title: "Windows Forms Print Support"
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
  - "Windows Forms, printing"
  - "printing [Windows Forms]"
  - "forms [Windows Forms], printing (using designer)"
  - "printing [Windows Forms], Windows Forms, support"
  - "printing [Windows Forms], print support"
ms.assetid: a4a2960c-eb70-48e2-b641-cfb222704e46
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Windows Forms Print Support
Printing in Windows Forms consists primarily of using the [PrintDocument Component](../../../../docs/framework/winforms/controls/printdocument-component-windows-forms.md) component to enable the user to print, and the [PrintPreviewDialog Control](../../../../docs/framework/winforms/controls/printpreviewdialog-control-windows-forms.md) control, [PrintDialog Component](../../../../docs/framework/winforms/controls/printdialog-component-windows-forms.md) and [PageSetupDialog Component](../../../../docs/framework/winforms/controls/pagesetupdialog-component-windows-forms.md) components to provide a familiar graphical interface to users accustomed to the Windows operating system.  
  
 Typically, you create a new instance of the <xref:System.Drawing.Printing.PrintDocument> component, set the properties that describe what to print using the <xref:System.Drawing.Printing.PrinterSettings> and <xref:System.Drawing.Printing.PageSettings> classes, and call the <xref:System.Drawing.Printing.PrintDocument.Print%2A> method to actually print the document.  
  
 During the course of printing from a Windows-based application, the <xref:System.Drawing.Printing.PrintDocument> component will show an abort print dialog box to alert users to the fact that printing is occurring and to allow the print job to be canceled.  
  
## In This Section  
 [How to: Create Standard Windows Forms Print Jobs](../../../../docs/framework/winforms/advanced/how-to-create-standard-windows-forms-print-jobs.md)  
 Explains how to use the <xref:System.Drawing.Printing.PrintDocument> component to print from a Windows Form.  
  
 [How to: Capture User Input from a PrintDialog at Run Time](../../../../docs/framework/winforms/advanced/how-to-capture-user-input-from-a-printdialog-at-run-time.md)  
 Explains how to modify selected print options programmatically using the <xref:System.Windows.Forms.PrintDialog> component.  
  
 [How to: Choose the Printers Attached to a User's Computer in Windows Forms](../../../../docs/framework/winforms/advanced/how-to-choose-the-printers-attached-to-user-computer-in-windows-forms.md)  
 Describes changing the printer to print to using the <xref:System.Windows.Forms.PrintDialog> component at run time.  
  
 [How to: Print Graphics in Windows Forms](../../../../docs/framework/winforms/advanced/how-to-print-graphics-in-windows-forms.md)  
 Describes sending graphics to the printer.  
  
 [How to: Print a Multi-Page Text File in Windows Forms](../../../../docs/framework/winforms/advanced/how-to-print-a-multi-page-text-file-in-windows-forms.md)  
 Describes sending text to the printer.  
  
 [How to: Complete Windows Forms Print Jobs](../../../../docs/framework/winforms/advanced/how-to-complete-windows-forms-print-jobs.md)  
 Explains how to alert users to the completion of a print job.  
  
 [How to: Print a Windows Form](../../../../docs/framework/winforms/advanced/how-to-print-a-windows-form.md)  
 Shows how to print a copy of the current form.  
  
 [How to: Print in Windows Forms Using Print Preview](../../../../docs/framework/winforms/advanced/how-to-print-in-windows-forms-using-print-preview.md)  
 Shows how to use a <xref:System.Windows.Forms.PrintPreviewDialog> for printing a document.  
  
## Related Sections  
 [PrintDocument Component](../../../../docs/framework/winforms/controls/printdocument-component-windows-forms.md)  
 Explains usage of the <xref:System.Drawing.Printing.PrintDocument> component.  
  
 [PrintDialog Component](../../../../docs/framework/winforms/controls/printdialog-component-windows-forms.md)  
 Explains usage of the <xref:System.Windows.Forms.PrintDialog> component.  
  
 [PrintPreviewDialog Control](../../../../docs/framework/winforms/controls/printpreviewdialog-control-windows-forms.md)  
 Explains usage of the <xref:System.Windows.Forms.PrintPreviewDialog> control.  
  
 [PageSetupDialog Component](../../../../docs/framework/winforms/controls/pagesetupdialog-component-windows-forms.md)  
 Explains usage of the <xref:System.Windows.Forms.PageSetupDialog> component.  
  
 <xref:System.Drawing.Printing>  
 Describes the classes in the <xref:System.Drawing.Printing> namespace.
