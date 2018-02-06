---
title: "HScrollBar and VScrollBar Controls Overview (Windows Forms)"
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
  - "HScrollBar"
  - "VScrollBar"
helpviewer_keywords: 
  - "ScrollBar control [Windows Forms]"
  - "HScrollBar control [Windows Forms], about HScrollBar"
  - "VScrollBar control [Windows Forms], about VScrollBar control"
  - "ScrollBar control [Windows Forms], about ScrollBar control"
  - "scroll bars [Windows Forms], about scroll bars"
ms.assetid: 8b307679-1cae-41d8-99aa-3d1efd207cd6
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# HScrollBar and VScrollBar Controls Overview (Windows Forms)
Windows Forms <xref:System.Windows.Forms.ScrollBar> controls are used to provide easy navigation through a long list of items or a large amount of information by scrolling either horizontally or vertically within an application or control. Scroll bars are a common element of the Windows interface, so the <xref:System.Windows.Forms.ScrollBar> control is often used with controls that do not derive from the <xref:System.Windows.Forms.ScrollableControl> class. Similarly, many developers choose to incorporate the <xref:System.Windows.Forms.ScrollBar> control when authoring their own user controls.  
  
 The <xref:System.Windows.Forms.HScrollBar> (horizontal) and <xref:System.Windows.Forms.VScrollBar> (vertical) controls operate independently from other controls and have their own set of events, properties, and methods. <xref:System.Windows.Forms.ScrollBar> controls are not the same as the built-in scroll bars that are attached to text boxes, list boxes, combo boxes, or MDI forms (the <xref:System.Windows.Forms.TextBox> control has a <xref:System.Windows.Forms.TextBox.ScrollBars%2A> property to show or hide scroll bars that are attached to the control).  
  
 The <xref:System.Windows.Forms.ScrollBar> controls use the <xref:System.Windows.Forms.ScrollBar.Scroll> event to monitor the movement of the scroll box (sometimes referred to as the thumb) along the scroll bar. Using the <xref:System.Windows.Forms.ScrollBar.Scroll> event provides access to the scroll bar value as it is being dragged.  
  
## Value Property  
 The <xref:System.Windows.Forms.ScrollBar.Value%2A> property (which, by default, is 0) is an `integer` value corresponding to the position of the scroll box in the scroll bar. When the scroll box position is at the minimum value, it moves to the left-most position (for horizontal scroll bars) or the top position (for vertical scroll bars). When the scroll box is at the maximum value, the scroll box moves to the right-most or bottom position. Similarly, a value halfway between the bottom and top of the range places the leading edge of the scroll box in the middle of the scroll bar.  
  
 In addition to using mouse clicks to change the scroll bar value, a user can also drag the scroll box to any point along the bar. The resulting value depends on the position of the scroll box, but it is always within the range of the <xref:System.Windows.Forms.ScrollBar.Minimum%2A> to <xref:System.Windows.Forms.ScrollBar.Maximum%2A> properties set by the user.  
  
## LargeChange and SmallChange Properties  
 When the user presses the PAGE UP or PAGE DOWN key or clicks in the scroll bar track on either side of the scroll box, the <xref:System.Windows.Forms.ScrollBar.Value%2A> property changes according to the value set in the <xref:System.Windows.Forms.ScrollBar.LargeChange%2A> property.  
  
 When the user presses one of the arrow keys or clicks one of the scroll bar buttons, the <xref:System.Windows.Forms.ScrollBar.Value%2A> property changes according to the value set in the <xref:System.Windows.Forms.ScrollBar.SmallChange%2A> property.  
  
## See Also  
 <xref:System.Windows.Forms.HScrollBar>  
 <xref:System.Windows.Forms.VScrollBar>  
 [Additions to Windows Forms for the .NET Framework 2.0](http://msdn.microsoft.com/library/c61a923d-3d6a-4c8c-820c-e94c83f3f9a8)  
 [Controls to Use on Windows Forms](../../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md)
