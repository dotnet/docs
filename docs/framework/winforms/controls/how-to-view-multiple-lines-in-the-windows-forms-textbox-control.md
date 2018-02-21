---
title: "How to: View Multiple Lines in the Windows Forms TextBox Control"
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
  - "newline"
  - "end of line"
  - "ScrollBars property [Windows Forms], in TextBox control"
  - "CRLF"
  - "MultiLine property in TextBox control"
  - "line-feed"
  - "TextBox control [Windows Forms], viewing multiple lines"
  - "carriage return"
ms.assetid: 43173201-0b74-4067-a472-605029ca5f35
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: View Multiple Lines in the Windows Forms TextBox Control
By default, the Windows Forms <xref:System.Windows.Forms.TextBox> control displays a single line of text and does not display scroll bars. If the text is longer than the available space, only part of the text is visible. You can change this default behavior by setting the <xref:System.Windows.Forms.TextBox.Multiline%2A>, <xref:System.Windows.Forms.TextBoxBase.WordWrap%2A>, and <xref:System.Windows.Forms.TextBox.ScrollBars%2A> properties to appropriate values.  
  
### To display a carriage return in the TextBox control  
  
-   To display a carriage return in a multi-line <xref:System.Windows.Forms.TextBox>, use the <xref:System.Environment.NewLine%2A> property.  
  
     Be aware that the interpretation of escape characters (\\) is language-specific. Visual Basic uses `Chr$(13) & Chr$(10)` for the carriage return and linefeed character combination.  
  
### To view multiple lines in the TextBox control  
  
1.  Set the <xref:System.Windows.Forms.TextBox.Multiline%2A> property to `true`. If <xref:System.Windows.Forms.TextBoxBase.WordWrap%2A> is `true` (the default), then the text in the control will appear as one or more paragraphs; otherwise it will appear as a list, in which some lines may be clipped at the edge of the control.  
  
2.  Set the <xref:System.Windows.Forms.TextBox.ScrollBars%2A> property to an appropriate value.  
  
    |Value|Description|  
    |-----------|-----------------|  
    |<xref:System.Windows.Forms.ScrollBars.None>|Use this value if the text will be a paragraph that almost always fits the control. The user can use the mouse pointer to move around inside the control if the text is too long to display all at once.|  
    |<xref:System.Windows.Forms.ScrollBars.Horizontal>|Use this value if you want to display a list of lines, some of which may be longer than the width of the <xref:System.Windows.Forms.TextBox> control.|  
    |<xref:System.Windows.Forms.ScrollBars.Both>|Use this value if the list may be longer than the height of the control.|  
  
3.  Set the <xref:System.Windows.Forms.TextBoxBase.WordWrap%2A> property to an appropriate value.  
  
    |Value|Description|  
    |-----------|-----------------|  
    |`false`|Text in the control will not automatically be wrapped, so it will scroll to the right until a line break is reached. Use this value if you chose <xref:System.Windows.Forms.ScrollBars.Horizontal> scroll bars or <xref:System.Windows.Forms.ScrollBars.Both>, above.|  
    |`true` (default)|The horizontal scrollbar will not appear. Use this value if you chose <xref:System.Windows.Forms.ScrollBars.Vertical> scroll bars or <xref:System.Windows.Forms.ScrollBars.None>, above, to display one or more paragraphs.|  
  
## See Also  
 <xref:System.Windows.Forms.TextBox>  
 [TextBox Control Overview](../../../../docs/framework/winforms/controls/textbox-control-overview-windows-forms.md)  
 [How to: Control the Insertion Point in a Windows Forms TextBox Control](../../../../docs/framework/winforms/controls/how-to-control-the-insertion-point-in-a-windows-forms-textbox-control.md)  
 [How to: Create a Password Text Box with the Windows Forms TextBox Control](../../../../docs/framework/winforms/controls/how-to-create-a-password-text-box-with-the-windows-forms-textbox-control.md)  
 [How to: Create a Read-Only Text Box](../../../../docs/framework/winforms/controls/how-to-create-a-read-only-text-box-windows-forms.md)  
 [How to: Put Quotation Marks in a String](../../../../docs/framework/winforms/controls/how-to-put-quotation-marks-in-a-string-windows-forms.md)  
 [How to: Select Text in the Windows Forms TextBox Control](../../../../docs/framework/winforms/controls/how-to-select-text-in-the-windows-forms-textbox-control.md)  
 [TextBox Control](../../../../docs/framework/winforms/controls/textbox-control-windows-forms.md)
