---
title: "RichTextBox Control Overview (Windows Forms)"
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
  - "RichTextBox"
helpviewer_keywords: 
  - "RichTextBox control [Windows Forms], about RichTextBox control"
  - "text boxes [Windows Forms], about text boxes"
ms.assetid: 95081194-3dd4-4b84-9545-dd373e491eca
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# RichTextBox Control Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.RichTextBox> control is used for displaying, entering, and manipulating text with formatting. The <xref:System.Windows.Forms.RichTextBox> control does everything the <xref:System.Windows.Forms.TextBox> control does, but it can also display fonts, colors, and links; load text and embedded images from a file; and find specified characters. The <xref:System.Windows.Forms.RichTextBox> control is typically used to provide text manipulation and display features similar to word processing applications such as Microsoft Word. Like the <xref:System.Windows.Forms.TextBox> control, the <xref:System.Windows.Forms.RichTextBox> control can display scroll bars; but unlike the <xref:System.Windows.Forms.TextBox> control, its default setting is to display both horizontal and vertical scrollbars as needed, and it has additional scrollbar settings.  
  
## Working with the RichTextBox Control  
 As with the <xref:System.Windows.Forms.TextBox> control, the text displayed is set by the <xref:System.Windows.Forms.RichTextBox.Text%2A> property. The <xref:System.Windows.Forms.RichTextBox> control has numerous properties to format text. For details on these properties, see [How to: Set Font Attributes for the Windows Forms RichTextBox Control](../../../../docs/framework/winforms/controls/how-to-set-font-attributes-for-the-windows-forms-richtextbox-control.md) and [How to: Set Indents, Hanging Indents, and Bulleted Paragraphs with the Windows Forms RichTextBox Control](../../../../docs/framework/winforms/controls/set-indents-hanging-indents-bulleted-paragraphs-with-wf-richtextbox.md). To manipulate files, the <xref:System.Windows.Forms.RichTextBox.LoadFile%2A> and <xref:System.Windows.Forms.RichTextBox.SaveFile%2A> methods can display and write multiple file formats including plain text, Unicode plain text, and Rich Text Format (RTF). The possible file formats are listed in <xref:System.Windows.Forms.RichTextBoxStreamType>. You can use the <xref:System.Windows.Forms.RichTextBox.Find%2A> method to find strings of text or specific characters.  
  
 You can also use a <xref:System.Windows.Forms.RichTextBox> control for Web-style links by setting the <xref:System.Windows.Forms.RichTextBox.DetectUrls%2A> property to `true` and writing code to handle the <xref:System.Windows.Forms.RichTextBox.LinkClicked> event. For more information, see [How to: Display Web-Style Links with the Windows Forms RichTextBox Control](../../../../docs/framework/winforms/controls/how-to-display-web-style-links-with-the-windows-forms-richtextbox-control.md). You can prevent the user from manipulating some or all of the text in the control by setting the <xref:System.Windows.Forms.RichTextBox.SelectionProtected%2A> property to `true`.  
  
 You can undo and redo most edit operations in a <xref:System.Windows.Forms.RichTextBox> control by calling the <xref:System.Windows.Forms.TextBoxBase.Undo%2A> and <xref:System.Windows.Forms.RichTextBox.Redo%2A> methods. The <xref:System.Windows.Forms.RichTextBox.CanRedo%2A> method enables you to determine whether the last operation the user has undone can be reapplied to the control.  
  
## See Also  
 <xref:System.Windows.Forms.RichTextBox>  
 [RichTextBox Control](../../../../docs/framework/winforms/controls/richtextbox-control-windows-forms.md)  
 [TextBox Control Overview](../../../../docs/framework/winforms/controls/textbox-control-overview-windows-forms.md)
