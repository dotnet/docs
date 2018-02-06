---
title: "Property-Changed Events"
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
  - "custom controls [Windows Forms], property changes (using code)"
  - "properties [Windows Forms], changes"
ms.assetid: 268039ec-5aaa-4d76-b902-acccb036c850
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Property-Changed Events
If you want your control to send notifications when a property named *PropertyName* changes, define an event named *PropertyName*`Changed` and a method named `On`*PropertyName*`Changed` that raises the event. The naming convention in Windows Forms is to append the word *Changed* to the name of the property. The associated event delegate type for property-changed events is <xref:System.EventHandler>, and the event data type is <xref:System.EventArgs>. The base class <xref:System.Windows.Forms.Control> defines many property-changed events, such as <xref:System.Windows.Forms.Control.BackColorChanged>, <xref:System.Windows.Forms.Control.BackgroundImageChanged>, <xref:System.Windows.Forms.Control.FontChanged>, <xref:System.Windows.Forms.Control.LocationChanged>, and others. For background information about events, see [Events](../../../../docs/standard/events/index.md) and [Events in Windows Forms Controls](../../../../docs/framework/winforms/controls/events-in-windows-forms-controls.md).  
  
 Property-changed events are useful because they allow consumers of a control to attach event handlers that respond to the change. If your control needs to respond to a property-changed event that it raises, override the corresponding `On`*PropertyName*`Changed` method instead of attaching a delegate to the event. A control typically responds to a property-changed event by updating other properties or by redrawing some or all of its drawing surface.  
  
 The following example shows how the `FlashTrackBar` custom control responds to some of the property-changed events that it inherits from <xref:System.Windows.Forms.Control>. For the complete sample, see [How to: Create a Windows Forms Control That Shows Progress](../../../../docs/framework/winforms/controls/how-to-create-a-windows-forms-control-that-shows-progress.md).  
  
 [!code-csharp[System.Windows.Forms.FlashTrackBar#2](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FlashTrackBar/CS/FlashTrackBar.cs#2)]
 [!code-vb[System.Windows.Forms.FlashTrackBar#2](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FlashTrackBar/VB/FlashTrackBar.vb#2)]  
  
## See Also  
 [Events](../../../../docs/standard/events/index.md)  
 [Events in Windows Forms Controls](../../../../docs/framework/winforms/controls/events-in-windows-forms-controls.md)  
 [Properties in Windows Forms Controls](../../../../docs/framework/winforms/controls/properties-in-windows-forms-controls.md)
