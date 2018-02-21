---
title: "How to: Display Scroll Bars in the Windows Forms RichTextBox Control"
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
  - "text boxes [Windows Forms], displaying scroll bars"
  - "scroll bars [Windows Forms], displaying in controls"
  - "RichTextBox control [Windows Forms], displaying scroll bars"
ms.assetid: cdeb42e1-86e8-410c-ba46-18aec264ef5f
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Display Scroll Bars in the Windows Forms RichTextBox Control
By default, the Windows Forms <xref:System.Windows.Forms.RichTextBox> control displays horizontal and vertical scroll bars as necessary. There are seven possible values for the <xref:System.Windows.Forms.RichTextBox.ScrollBars%2A> property of the <xref:System.Windows.Forms.RichTextBox> control, which are described in the table below.  
  
### To display scroll bars in a RichTextBox control  
  
1.  Set the <xref:System.Windows.Forms.RichTextBox.Multiline%2A> property to `true`. No type of scroll bar, including horizontal, will display if the <xref:System.Windows.Forms.RichTextBox.Multiline%2A> property is set to `false`.  
  
2.  Set the <xref:System.Windows.Forms.RichTextBox.ScrollBars%2A> property to an appropriate value of the <xref:System.Windows.Forms.RichTextBoxScrollBars> enumeration.  
  
    |Value|Description|  
    |-----------|-----------------|  
    |<xref:System.Windows.Forms.RichTextBoxScrollBars.Both> (default)|Displays horizontal or vertical scroll bars, or both, only when text exceeds the width or length of the control.|  
    |<xref:System.Windows.Forms.RichTextBoxScrollBars.None>|Never displays any type of scroll bar.|  
    |<xref:System.Windows.Forms.RichTextBoxScrollBars.Horizontal>|Displays a horizontal scroll bar only when the text exceeds the width of the control. (For this to occur, the <xref:System.Windows.Forms.TextBoxBase.WordWrap%2A> property must be set to `false`.)|  
    |<xref:System.Windows.Forms.RichTextBoxScrollBars.Vertical>|Displays a vertical scroll bar only when the text exceeds the height of the control.|  
    |<xref:System.Windows.Forms.RichTextBoxScrollBars.ForcedHorizontal>|Displays a horizontal scroll bar when the <xref:System.Windows.Forms.TextBoxBase.WordWrap%2A> property is set to `false`. The scroll bar appears dimmed when text does not exceed the width of the control.|  
    |<xref:System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical>|Always displays a vertical scroll bar. The scroll bar appears dimmed when text does not exceed the length of the control.|  
    |<xref:System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth>|Always displays a vertical scrollbar. Displays a horizontal scroll bar when the <xref:System.Windows.Forms.TextBoxBase.WordWrap%2A> property is set to `false`. The scroll bars appear grayed when text does not exceed the width or length of the control.|  
  
3.  Set the <xref:System.Windows.Forms.TextBoxBase.WordWrap%2A> property to an appropriate value.  
  
    |Value|Description|  
    |-----------|-----------------|  
    |`false`|Text in the control is not automatically adjusted to fit the width of the control, so it will scroll to the right until a line break is reached. Use this value if you chose horizontal scroll bars or both, above.|  
    |`true` (default)|Text in the control is automatically adjusted to fit the width of the control. The horizontal scrollbar will not appear. Use this value if you chose vertical scroll bars or none, above, to display one or more paragraphs.|  
  
## See Also  
 <xref:System.Windows.Forms.RichTextBoxScrollBars>  
 <xref:System.Windows.Forms.RichTextBox>  
 [RichTextBox Control](../../../../docs/framework/winforms/controls/richtextbox-control-windows-forms.md)  
 [Controls to Use on Windows Forms](../../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md)
