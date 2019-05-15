---
title: "How to display the PrintDialog component"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Print dialog box [Windows Forms], displaying"
  - "PrintDialog component [Windows Forms], displaying"
  - "printing [Windows Forms], displaying print dialog box"
ms.assetid: 745a8db7-0526-4b21-b09d-18e13ed32014
---
# How to display the PrintDialog component

The <xref:System.Windows.Forms.PrintDialog> component is the standard Windows print dialog box that many of your users will be familiar with. Because your users will be immediately comfortable with it, it would be beneficial for you to use the <xref:System.Windows.Forms.PrintDialog> component.

## To display the PrintDialog component

- Call the <xref:System.Windows.Forms.Form.ShowDialog%2A> method from within the code of your application.

     Once the component is shown, users will interact with it, setting the properties of the print job. These are saved in the  <xref:System.Drawing.Printing.PrinterSettings> class (and the <xref:System.Drawing.Printing.PageSettings> class, if the user accesses the [PageSetupDialog Component](pagesetupdialog-component-windows-forms.md) through the <xref:System.Windows.Forms.PrintDialog> component) associated with that print job. You can then make calls to the properties they set to determine the specifics of the print job.

## See also

- [How to: Create Standard Windows Forms Print Jobs](../advanced/how-to-create-standard-windows-forms-print-jobs.md)
- [How to: Capture User Input from a PrintDialog at Run Time](../advanced/how-to-capture-user-input-from-a-printdialog-at-run-time.md)
- [PrintPreviewDialog Control](printpreviewdialog-control-windows-forms.md)
- [PrintDialog Component](printdialog-component-windows-forms.md)
- [Windows Forms Print Support](../advanced/windows-forms-print-support.md)
- [Windows Forms Controls](index.md)
