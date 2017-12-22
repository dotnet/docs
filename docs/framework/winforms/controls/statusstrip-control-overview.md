---
title: "StatusStrip Control Overview"
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
  - "StatusStrip"
helpviewer_keywords: 
  - "StatusStrip control [Windows Forms], about StatusStrip control"
  - "status bars [Windows Forms], about status bars"
ms.assetid: c0d9bcbb-f8b8-46ef-bae2-4146b8c8ce99
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# StatusStrip Control Overview
A <xref:System.Windows.Forms.StatusStrip> control displays information about an object being viewed on a <xref:System.Windows.Forms.Form>, the object's components, or contextual information that relates to that object's operation within your application. Typically, a <xref:System.Windows.Forms.StatusStrip> control consists of <xref:System.Windows.Forms.ToolStripStatusLabel> objects, each of which displays text, an icon, or both. The <xref:System.Windows.Forms.StatusStrip> can also contain <xref:System.Windows.Forms.ToolStripDropDownButton>, <xref:System.Windows.Forms.ToolStripSplitButton>, and <xref:System.Windows.Forms.ToolStripProgressBar> controls.  
  
 The default <xref:System.Windows.Forms.StatusStrip> has no panels. To add panels to a <xref:System.Windows.Forms.StatusStrip>, use the <xref:System.Windows.Forms.ToolStripItemCollection.AddRange%2A?displayProperty=nameWithType> method.  
  
 There is extensive support for handling <xref:System.Windows.Forms.StatusStrip> items and common commands in Visual Studio.  
  
 Also see [StatusStrip Items Collection Editor](http://msdn.microsoft.com/library/ms233631\(v=vs.110\)), [StatusStrip Tasks Dialog Box](http://msdn.microsoft.com/library/ms233642\(v=vs.110\)).  
  
 Although <xref:System.Windows.Forms.StatusStrip> replaces and extends the <xref:System.Windows.Forms.StatusBar> control of previous versions, <xref:System.Windows.Forms.StatusBar> is retained for both backward compatibility and future use if you choose.  
  
### Important StatusStrip Members  
  
|Name|Description|  
|----------|-----------------|  
|<xref:System.Windows.Forms.StatusStrip.CanOverflow%2A>|Gets or sets a value indicating whether the <xref:System.Windows.Forms.StatusStrip> supports overflow functionality.|  
|<xref:System.Windows.Forms.StatusStrip.Stretch%2A>|Gets or sets a value indicating whether the <xref:System.Windows.Forms.StatusStrip> stretches from end to end in its <xref:System.Windows.Forms.ToolStripContainer>.|  
  
### Important StatusStrip Companion Classes  
  
|Name|Description|  
|----------|-----------------|  
|<xref:System.Windows.Forms.ToolStripStatusLabel>|Represents a panel in a <xref:System.Windows.Forms.StatusStrip> control.|  
|<xref:System.Windows.Forms.ToolStripDropDownButton>|Displays an associated <xref:System.Windows.Forms.ToolStripDropDown> from which the user can select a single item.|  
|<xref:System.Windows.Forms.ToolStripSplitButton>|Represents a two-part control that is a standard button and a drop-down menu.|  
|<xref:System.Windows.Forms.ToolStripProgressBar>|Displays the completion state of a process.|  
  
## See Also  
 <xref:System.Windows.Forms.StatusStrip>  
 <xref:System.Windows.Forms.ToolStripStatusLabel>  
 <xref:System.Windows.Forms.ToolStripStatusLabel.Spring%2A>
