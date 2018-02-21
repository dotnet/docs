---
title: "SplitContainer Control Overview (Windows Forms)"
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
  - "SplitContainer"
helpviewer_keywords: 
  - "SplitContainer control [Windows Forms], about SplitContainer control"
ms.assetid: 6de5a5f7-97a5-402d-be6d-7e2785483db5
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# SplitContainer Control Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.SplitContainer> control can be thought of as a composite; it is two panels separated by a movable bar. When the mouse pointer is over the bar, the pointer changes shape to show that the bar is movable.  
  
> [!IMPORTANT]
>  In the **Toolbox**, <xref:System.Windows.Forms.SplitContainer> control replaces the <xref:System.Windows.Forms.Splitter> control that was there in the previous version of [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)]. The <xref:System.Windows.Forms.SplitContainer> control is much preferred over the <xref:System.Windows.Forms.Splitter> control. The <xref:System.Windows.Forms.Splitter> class is still included in the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] for compatibility with existing applications, but we strongly encourage you to use the <xref:System.Windows.Forms.SplitContainer> control for new projects.  
  
 With the <xref:System.Windows.Forms.SplitContainer> control, you can create complex user interfaces; often, a selection in one panel determines what objects are shown in the other panel. This arrangement is very effective for displaying and browsing information. Having two panels lets you aggregate information in areas, and the bar, or "splitter," makes it easy for users to resize the panels.  
  
 More than one <xref:System.Windows.Forms.SplitContainer> control can also be nested, with the second <xref:System.Windows.Forms.SplitContainer> control oriented horizontally, to create top and bottom panels.  
  
 Be aware that the <xref:System.Windows.Forms.SplitContainer> control is keyboard-accessible by default; users can press the ARROW keys to move the splitter if the <xref:System.Windows.Forms.SplitContainer.IsSplitterFixed%2A> property is set to `false`.  
  
 The <xref:System.Windows.Forms.SplitContainer.Orientation%2A> property of the <xref:System.Windows.Forms.SplitContainer> control determines the direction of the splitter, not of the control itself. Hence, when this property is set to <xref:System.Windows.Forms.Orientation.Vertical>, the splitter runs from top to bottom, creating left and right panels.  
  
 Additionally, be aware that the value of the <xref:System.Windows.Forms.SplitContainer.SplitterRectangle%2A> property varies depending on the value of the <xref:System.Windows.Forms.SplitContainer.Orientation%2A> property. For more information, see <xref:System.Windows.Forms.SplitContainer.SplitterRectangle%2A> property.  
  
 You can also restrict the size and movement of the <xref:System.Windows.Forms.SplitContainer> control. The <xref:System.Windows.Forms.SplitContainer.FixedPanel%2A> property determines which panel will remain the same size after the <xref:System.Windows.Forms.SplitContainer> control is resized, and the <xref:System.Windows.Forms.SplitContainer.IsSplitterFixed%2A> property determines if the splitter is movable by the keyboard or mouse.  
  
> [!NOTE]
>  Even if the <xref:System.Windows.Forms.SplitContainer.IsSplitterFixed%2A> property is set to `true`, the splitter may still be moved programmatically; for example, by using the <xref:System.Windows.Forms.SplitContainer.SplitterDistance%2A> property.  
  
 Finally, each panel of the <xref:System.Windows.Forms.SplitContainer> control has properties to determine its individual size.  
  
## Commonly Used Properties, Methods, and Events  
  
|Name|Description|  
|----------|-----------------|  
|<xref:System.Windows.Forms.SplitContainer.FixedPanel%2A> property|Determines which panel will remain the same size after the <xref:System.Windows.Forms.SplitContainer> control is resized.|  
|<xref:System.Windows.Forms.SplitContainer.IsSplitterFixed%2A> property|Determines if the splitter can be moved with the keyboard or mouse.|  
|<xref:System.Windows.Forms.SplitContainer.Orientation%2A> property|Determines if the splitter is arranged vertically or horizontally.|  
|<xref:System.Windows.Forms.SplitContainer.SplitterDistance%2A> property|Determines the distance in pixels from the left or upper edge to the movable splitter bar.|  
|<xref:System.Windows.Forms.SplitContainer.SplitterIncrement%2A> property|Determines the minimum distance, in pixels, that the splitter can be moved by the user.|  
|<xref:System.Windows.Forms.SplitContainer.SplitterWidth%2A> property|Determines the thickness, in pixels, of the splitter.|  
|<xref:System.Windows.Forms.SplitContainer.SplitterMoving> event|Occurs when the splitter is moving.|  
|<xref:System.Windows.Forms.SplitContainer.SplitterMoved> event|Occurs when the splitter has moved.|  
  
## See Also  
 <xref:System.Windows.Forms.SplitContainer>  
 [SplitContainer Control](../../../../docs/framework/winforms/controls/splitcontainer-control-windows-forms.md)  
 [SplitContainer Control Sample](http://msdn.microsoft.com/library/9015fad0-7108-4d85-a83a-a72d038c4f65)
