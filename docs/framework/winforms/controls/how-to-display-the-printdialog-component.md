---
title: "How to: Display the PrintDialog Component"
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
  - "Print dialog box [Windows Forms], displaying"
  - "PrintDialog component [Windows Forms], displaying"
  - "printing [Windows Forms], displaying print dialog box"
ms.assetid: 745a8db7-0526-4b21-b09d-18e13ed32014
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Display the PrintDialog Component
The <xref:System.Windows.Forms.PrintDialog> component is the standard Windows print dialog box that many of your users will be familiar with. Because your users will be immediately comfortable with it, it would be beneficial for you to use the <xref:System.Windows.Forms.PrintDialog> component.  
  
### To display the PrintDialog component  
  
-   Call the <xref:System.Windows.Forms.Form.ShowDialog%2A> method from within the code of your application.  
  
     Once the component is shown, users will interact with it, setting the properties of the print job. These are saved in the <!--zz <xref:System.Drawing.Printing.PrinterSetting>--> `PrinterSetting` class (and the <xref:System.Drawing.Printing.PageSettings> class, if the user accesses the [PageSetupDialog Component](../../../../docs/framework/winforms/controls/pagesetupdialog-component-windows-forms.md) through the <xref:System.Windows.Forms.PrintDialog> component) associated with that print job. You can then make calls to the properties they set to determine the specifics of the print job.  
  
## See Also  
 [How to: Create Standard Windows Forms Print Jobs](../../../../docs/framework/winforms/advanced/how-to-create-standard-windows-forms-print-jobs.md)  
 [How to: Capture User Input from a PrintDialog at Run Time](../../../../docs/framework/winforms/advanced/how-to-capture-user-input-from-a-printdialog-at-run-time.md)  
 [PrintPreviewDialog Control](../../../../docs/framework/winforms/controls/printpreviewdialog-control-windows-forms.md)  
 [PrintDialog Component](../../../../docs/framework/winforms/controls/printdialog-component-windows-forms.md)  
 [Windows Forms Print Support](../../../../docs/framework/winforms/advanced/windows-forms-print-support.md)  
 [Windows Forms Controls](../../../../docs/framework/winforms/controls/index.md)
