---
title: "PageSetupDialog Component Overview (Windows Forms)"
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
  - "PageSetupDialog"
helpviewer_keywords: 
  - "Page Setup dialog box [Windows Forms], displaying"
  - "PageSetupDialog component"
ms.assetid: 791caacb-a5ca-4fca-bad9-1a5721ad697c
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# PageSetupDialog Component Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.PageSetupDialog> component is a pre-configured dialog box used to set page details for printing in Windows-based applications. Use it within your Windows-based application as a simple solution for users to set page preferences in lieu of configuring your own dialog box. You can enable users to set border and margin adjustments, headers and footers, and portrait or landscape orientation. By relying on standard Windows dialog boxes, you create applications whose basic functionality is immediately familiar to users.  
  
## Key Properties and Methods  
 Use the <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method to display the dialog at run time. This component has properties you can set that relate to either a single page (<xref:System.Drawing.Printing.PrintDocument> class) or any document (<xref:System.Drawing.Printing.PageSettings> class). Additionally, the <xref:System.Windows.Forms.PageSetupDialog> component can be used to determine specific printer settings, which are stored in the <xref:System.Drawing.Printing.PrinterSettings> class.  
  
 When it is added to a form, the <xref:System.Windows.Forms.PageSetupDialog> component appears in the tray at the bottom of the Windows Forms Designer.  
  
## See Also  
 <xref:System.Windows.Forms.PageSetupDialog>  
 [PageSetupDialog Component](../../../../docs/framework/winforms/controls/pagesetupdialog-component-windows-forms.md)
