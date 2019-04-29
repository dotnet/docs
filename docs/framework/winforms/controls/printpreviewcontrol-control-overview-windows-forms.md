---
title: "PrintPreviewControl Control Overview (Windows Forms)"
ms.date: "03/30/2017"
f1_keywords: 
  - "PrintPreviewControl"
helpviewer_keywords: 
  - "print preview"
  - "PrintPreviewControl control"
ms.assetid: 4513c6c7-5e9b-4f4c-82ca-00f993a26955
---
# PrintPreviewControl Control Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.PrintPreviewControl> is used to display a [PrintDocument](printdocument-component-windows-forms.md) as it will appear when printed. This control has no buttons or other user interface elements, so typically you use the <xref:System.Windows.Forms.PrintPreviewControl> only if you wish to write your own print-preview user interface. If you want the standard user interface, use a <xref:System.Windows.Forms.PrintPreviewDialog> control; see [PrintPreviewDialog Control Overview](printpreviewdialog-control-overview-windows-forms.md) for an overview.  
  
## Key Properties  
 The control's key property is <xref:System.Windows.Forms.PrintPreviewControl.Document%2A>, which sets the document to be previewed. The document must be a <xref:System.Drawing.Printing.PrintDocument> object. For an overview of creating documents for printing, see [PrintDocument Component Overview](printdocument-component-overview-windows-forms.md) and [Windows Forms Print Support](../advanced/windows-forms-print-support.md). The <xref:System.Windows.Forms.PrintPreviewControl.Columns%2A> and <xref:System.Windows.Forms.PrintPreviewControl.Rows%2A> properties determine the number of pages displayed horizontally and vertically on the control. Antialiasing can make the text appear smoother, but it can also make the display slower; to use it, set the <xref:System.Windows.Forms.PrintPreviewControl.UseAntiAlias%2A> property to `true`.  
  
## See also

- <xref:System.Windows.Forms.PrintPreviewControl>
- [PrintPreviewDialog Control Overview](printpreviewdialog-control-overview-windows-forms.md)
- [PrintPreviewControl Control](printpreviewcontrol-control-windows-forms.md)
- [Dialog-Box Controls and Components](dialog-box-controls-and-components-windows-forms.md)
