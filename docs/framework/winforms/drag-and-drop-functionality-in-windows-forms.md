---
title: "Drag-and-Drop Functionality in Windows Forms"
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
  - "drag and drop [Windows Forms], Windows Forms"
  - "Windows Forms, drag and drop"
ms.assetid: 65cd2c03-8782-474e-b958-cbe43eeb902c
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Drag-and-Drop Functionality in Windows Forms
Windows Forms includes a set of methods, events, and classes that implement drag-and-drop behavior. This topic provides an overview of the drag-and-drop support in Windows Forms.  Also see [Drag-and-Drop Operations and Clipboard Support](http://msdn.microsoft.com/library/fe5ebfwe\(v=vs.110\)).  
  
## Performing Drag-and-Drop Operations  
 To perform a drag-and-drop operation, use the <xref:System.Windows.Forms.Control.DoDragDrop%2A> method of the <xref:System.Windows.Forms.Control> class. For more information about how a drag-and-drop operation is performed, see <xref:System.Windows.Forms.Control.DoDragDrop%2A>. To get the rectangle that the mouse pointer must be dragged over before a drag-and-drop operation begins, use the <xref:System.Windows.Forms.SystemInformation.DragSize%2A> property of the <xref:System.Windows.Forms.SystemInformation> class.  
  
## Events Related to Drag-and-Drop Operations  
 There are two categories of events in a drag and drop operation: events that occur on the current target of the drag-and-drop operation, and events that occur on the source of the drag and drop operation.  
  
### Events on the Current Target  
 The following table shows the events that occur on the current target of a drag-and-drop operation.  
  
|Mouse Event|Description|  
|-----------------|-----------------|  
|<xref:System.Windows.Forms.Control.DragEnter>|This event occurs when an object is dragged into the control's bounds. The handler for this event receives an argument of type <xref:System.Windows.Forms.DragEventArgs>.|  
|<xref:System.Windows.Forms.Control.DragOver>|This event occurs when an object is dragged while the mouse pointer is within the control's bounds. The handler for this event receives an argument of type <xref:System.Windows.Forms.DragEventArgs>.|  
|<xref:System.Windows.Forms.Control.DragDrop>|This event occurs when a drag-and-drop operation is completed. The handler for this event receives an argument of type <xref:System.Windows.Forms.DragEventArgs>.|  
|<xref:System.Windows.Forms.Control.DragLeave>|This event occurs when an object is dragged out of the control's bounds. The handler for this event receives an argument of type <xref:System.EventArgs>.|  
  
 The <xref:System.Windows.Forms.DragEventArgs> class provides the location of the mouse pointer, the current state of the mouse buttons and modifier keys of the keyboard, the data being dragged, and <xref:System.Windows.Forms.DragDropEffects> values that specify the operations allowed by the source of the drag event and the target drop effect for the operation.  
  
### Events on the Source  
 The following table shows the events that occur on the source of the drag-and-drop operation.  
  
|Mouse Event|Description|  
|-----------------|-----------------|  
|<xref:System.Windows.Forms.Control.GiveFeedback>|This event occurs during a drag operation. It provides an opportunity to give a visual cue to the user that the drag-and-drop operation is occurring, such as changing the mouse pointer. The handler for this event receives an argument of type <xref:System.Windows.Forms.GiveFeedbackEventArgs>.|  
|<xref:System.Windows.Forms.Control.QueryContinueDrag>|This event is raised during a drag-and-drop operation and enables the drag source to determine whether the drag-and-drop operation should be canceled. The handler for this event receives an argument of type <xref:System.Windows.Forms.QueryContinueDragEventArgs>.|  
  
 The <xref:System.Windows.Forms.QueryContinueDragEventArgs> class provides the current state of the mouse buttons and modifier keys of the keyboard, a value specifying whether the ESC key was pressed, and a <xref:System.Windows.Forms.DragAction> value that can be set to specify whether the drag-and-drop operation should continue.  
  
## See Also  
 [Mouse Input in a Windows Forms Application](../../../docs/framework/winforms/mouse-input-in-a-windows-forms-application.md)
