---
title: "Handling User Input"
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
  - "custom controls [Windows Forms], user input using code"
  - "custom controls [Windows Forms], keyboard events using code"
  - "custom controls [Windows Forms], mouse events using code"
ms.assetid: d9b12787-86f6-4022-8e0f-e12d312c4af2
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Handling User Input
This topic describes the main keyboard and mouse events provided by <xref:System.Windows.Forms.Control?displayProperty=nameWithType>. When handling an event, control authors should override the protected `On`*EventName* method rather than attaching a delegate to the event. For a review of events, see [Raising Events from a Component](http://msdn.microsoft.com/library/9aebf605-a87d-470b-b7c8-f9abfc8360a0).  
  
> [!NOTE]
>  If there is no data associated with an event, an instance of the base class <xref:System.EventArgs> is passed as an argument to the `On`*EventName* method.  
  
## Keyboard Events  
 The common keyboard events that your control can handle are <xref:System.Windows.Forms.Control.KeyDown>, <xref:System.Windows.Forms.Control.KeyPress>, and <xref:System.Windows.Forms.Control.KeyUp>.  
  
|Event Name|Method to Override|Description of Event|  
|----------------|------------------------|--------------------------|  
|`KeyDown`|`void OnKeyDown(KeyEventArgs)`|Raised only when a key is initially pressed.|  
|`KeyPress`|`void OnKeyPress`<br /><br /> `(KeyPressEventArgs)`|Raised every time a key is pressed. If a key is held down, a <xref:System.Windows.Forms.Control.KeyPress> event is raised at the repeat rate defined by the operating system.|  
|`KeyUp`|`void OnKeyUp(KeyEventArgs)`|Raised when a key is released.|  
  
> [!NOTE]
>  Handling keyboard input is considerably more complex than overriding the events in the preceding table and is beyond the scope of this topic. For more information, see [User Input in Windows Forms](../../../../docs/framework/winforms/user-input-in-windows-forms.md).  
  
## Mouse Events  
 The mouse events that your control can handle are <xref:System.Windows.Forms.Control.MouseDown>, <xref:System.Windows.Forms.Control.MouseEnter>, <xref:System.Windows.Forms.Control.MouseHover>, <xref:System.Windows.Forms.Control.MouseLeave>, <xref:System.Windows.Forms.Control.MouseMove>, and <xref:System.Windows.Forms.Control.MouseUp>.  
  
|Event Name|Method to Override|Description of Event|  
|----------------|------------------------|--------------------------|  
|`MouseDown`|`void OnMouseDown(MouseEventArgs)`|Raised when the mouse button is pressed while the pointer is over the control.|  
|`MouseEnter`|`void OnMouseEnter(EventArgs)`|Raised when the pointer first enters the region of the control.|  
|`MouseHover`|`void OnMouseHover(EventArgs)`|Raised when the pointer hovers over the control.|  
|`MouseLeave`|`void OnMouseLeave(EventArgs)`|Raised when the pointer leaves the region of the control.|  
|`MouseMove`|`void OnMouseMove(MouseEventArgs)`|Raised when the pointer moves in the region of the control.|  
|`MouseUp`|`void OnMouseUp(MouseEventArgs)`|Raised when the mouse button is released while the pointer is over the control or the pointer leaves the region of the control.|  
  
 The following code fragment shows an example of overriding the <xref:System.Windows.Forms.Control.MouseDown> event.  
  
 [!code-csharp[System.Windows.Forms.FlashTrackBar#7](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FlashTrackBar/CS/FlashTrackBar.cs#7)]
 [!code-vb[System.Windows.Forms.FlashTrackBar#7](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FlashTrackBar/VB/FlashTrackBar.vb#7)]  
  
 The following code fragment shows an example of overriding the <xref:System.Windows.Forms.Control.MouseMove> event.  
  
 [!code-csharp[System.Windows.Forms.FlashTrackBar#8](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FlashTrackBar/CS/FlashTrackBar.cs#8)]
 [!code-vb[System.Windows.Forms.FlashTrackBar#8](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FlashTrackBar/VB/FlashTrackBar.vb#8)]  
  
 The following code fragment shows an example of overriding the <xref:System.Windows.Forms.Control.MouseUp> event.  
  
 [!code-csharp[System.Windows.Forms.FlashTrackBar#9](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FlashTrackBar/CS/FlashTrackBar.cs#9)]
 [!code-vb[System.Windows.Forms.FlashTrackBar#9](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FlashTrackBar/VB/FlashTrackBar.vb#9)]  
  
 For the complete source code for the `FlashTrackBar` sample, see [How to: Create a Windows Forms Control That Shows Progress](../../../../docs/framework/winforms/controls/how-to-create-a-windows-forms-control-that-shows-progress.md).  
  
## See Also  
 [Events in Windows Forms Controls](../../../../docs/framework/winforms/controls/events-in-windows-forms-controls.md)  
 [Defining an Event](../../../../docs/framework/winforms/controls/defining-an-event-in-windows-forms-controls.md)  
 [Events](../../../../docs/standard/events/index.md)  
 [User Input in Windows Forms](../../../../docs/framework/winforms/user-input-in-windows-forms.md)
