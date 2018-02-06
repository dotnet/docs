---
title: "PrintDialog Component Overview (Windows Forms)"
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
  - "PrintDialog"
helpviewer_keywords: 
  - "Print dialog box [Windows Forms], displaying"
  - "PrintDialog component [Windows Forms], about PrintDialog component"
ms.assetid: 8327b8ac-1017-4b5e-a88b-fea9dd56999c
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# PrintDialog Component Overview (Windows Forms)
The Windows Forms [PrintDialog](../../../../docs/framework/winforms/controls/printdialog-component-windows-forms.md) component is a pre-configured dialog box used to select a printer, choose the pages to print, and determine other print-related settings in Windows-based applications. Use it as a simple solution for printer and print-related settings selection in lieu of configuring your own dialog box. You can enable users to print many parts of their documents: print all, print a selected page range, or print a selection. By relying on standard Windows dialog boxes, you create applications whose basic functionality is immediately familiar to users. The <xref:System.Windows.Forms.PrintDialog> component inherits from the <xref:System.Windows.Forms.CommonDialog> class.  
  
## Working with the Component  
 Use the <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method to display the dialog box at run time. This component has properties that relate to either a single print job (<xref:System.Drawing.Printing.PrintDocument> class) or the settings of an individual printer (<xref:System.Drawing.Printing.PrinterSettings> class). Either of these, in turn, may be shared by multiple printers.  
  
 When it is added to a form, the <xref:System.Windows.Forms.PrintDialog> component appears in the tray at the bottom of the Windows Forms Designer.  
  
## See Also  
 <xref:System.Windows.Forms.PrintDialog>  
 [PrintDialog Component](../../../../docs/framework/winforms/controls/printdialog-component-windows-forms.md)
