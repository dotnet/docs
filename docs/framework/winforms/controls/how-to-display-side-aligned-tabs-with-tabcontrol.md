---
title: "How to: Display Side-Aligned Tabs with TabControl"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "tab pages [Windows Forms], displaying side-aligned tabs"
  - "tabs [Windows Forms], displaying side-aligned tabs"
  - "TabControl control [Windows Forms], displaying side-aligned tabs"
ms.assetid: 110d5abd-3ae3-4ded-95bf-778aaac798a0
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Display Side-Aligned Tabs with TabControl
The <xref:System.Windows.Forms.TabControl.Alignment%2A> property of <xref:System.Windows.Forms.TabControl> supports displaying tabs vertically (along the left or right edge of the control), as opposed to horizontally (across the top or bottom of the control). By default, this vertical display results in a poor user experience, because the <xref:System.Windows.Forms.TabPage.Text%2A> property of the <xref:System.Windows.Forms.TabPage> object does not display in the tab when visual styles are enabled. There is also no direct way to control the direction of the text within the tab. You can use owner draw on <xref:System.Windows.Forms.TabControl> to improve this experience.  
  
 The following procedure shows how to render right-aligned tabs, with the tab text running from left to right, by using the "owner draw" feature.  
  
### To display right-aligned tabs  
  
1.  Add a <xref:System.Windows.Forms.TabControl> to your form.  
  
2.  Set the <xref:System.Windows.Forms.TabControl.Alignment%2A> property to <xref:System.Windows.Forms.TabAlignment.Right>.  
  
3.  Set the <xref:System.Windows.Forms.TabControl.SizeMode%2A> property to <xref:System.Windows.Forms.TabSizeMode.Fixed>, so that all tabs are the same width.  
  
4.  Set the <xref:System.Windows.Forms.TabControl.ItemSize%2A> property to the preferred fixed size for the tabs. Keep in mind that the <xref:System.Windows.Forms.TabControl.ItemSize%2A> property behaves as though the tabs were on top, although they are right-aligned. As a result, in order to make the tabs wider, you must change the <xref:System.Drawing.Size.Height%2A> property, and in order to make them taller, you must change the <xref:System.Drawing.Size.Width%2A> property.  
  
     For best result with the code example below, set the <xref:System.Drawing.Size.Width%2A> of the tabs to 25 and the <xref:System.Drawing.Size.Height%2A> to 100.  
  
5.  Set the <xref:System.Windows.Forms.TabControl.DrawMode%2A> property to <xref:System.Windows.Forms.TabDrawMode.OwnerDrawFixed>.  
  
6.  Define a handler for the <xref:System.Windows.Forms.TabControl.DrawItem> event of <xref:System.Windows.Forms.TabControl> that renders the text from left to right.  
  
     [!code-csharp[TabControl.RightAlignedTabs#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/TabControl.RightAlignedTabs/CS/Form1.cs#1)]
     [!code-vb[TabControl.RightAlignedTabs#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/TabControl.RightAlignedTabs/VB/Form1.vb#1)]  
  
## See Also  
 [TabControl Control](../../../../docs/framework/winforms/controls/tabcontrol-control-windows-forms.md)
