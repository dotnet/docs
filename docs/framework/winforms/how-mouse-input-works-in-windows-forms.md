---
title: "How Mouse Input Works in Windows Forms"
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
  - "Windows Forms, mouse input"
  - "mouse [Windows Forms], input"
ms.assetid: 48fc5240-75a6-44bf-9fce-6aa21b49705a
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How Mouse Input Works in Windows Forms
Receiving and handling mouse input is an important part of every Windows application. You can handle mouse events to perform an action in your application, or use mouse location information to perform hit testing or other actions. In addition, you can change the way the controls in your application handle mouse input. This topic describes these mouse events in detail, and how to obtain and change system settings for the mouse. For more information about the data provided with the mouse events and the order in which the mouse click events are raised, see [Mouse Events in Windows Forms](../../../docs/framework/winforms/mouse-events-in-windows-forms.md).  
  
## Mouse Location and Hit-Testing  
 When the user moves the mouse, the operating system moves the mouse pointer. The mouse pointer contains a single pixel, called the hot spot, which the operating system tracks and recognizes as the position of the pointer. When the user moves the mouse or presses a mouse button, the <xref:System.Windows.Forms.Control> that contains the <xref:System.Windows.Forms.Cursor.HotSpot%2A> raises the appropriate mouse event. You can obtain the current mouse position with the <xref:System.Windows.Forms.MouseEventArgs.Location%2A> property of the <xref:System.Windows.Forms.MouseEventArgs> when handling a mouse event or by using the <xref:System.Windows.Forms.Cursor.Position%2A> property of the <xref:System.Windows.Forms.Cursor> class. You can subsequently use mouse location information to perform hit-testing, and then perform an action based on the location of the mouse. Hit-testing capability is built in to several controls in Windows Forms such as the <xref:System.Windows.Forms.ListView>, <xref:System.Windows.Forms.TreeView>, <xref:System.Windows.Forms.MonthCalendar> and <xref:System.Windows.Forms.DataGridView> controls. Used with the appropriate mouse event, <xref:System.Windows.Forms.Control.MouseHover> for example, hit-testing is very useful for determining when your application should perform a specific action.  
  
## Mouse Events  
 The primary way to respond to mouse input is to handle mouse events. The following table shows the mouse events and describes when they are raised.  
  
|Mouse Event|Description|  
|-----------------|-----------------|  
|<xref:System.Windows.Forms.Control.Click>|This event occurs when the mouse button is released, typically before the <xref:System.Windows.Forms.Control.MouseUp> event. The handler for this event receives an argument of type <xref:System.EventArgs>. Handle this event when you only need to determine when a click occurs.|  
|<xref:System.Windows.Forms.Control.MouseClick>|This event occurs when the user clicks the control with the mouse. The handler for this event receives an argument of type <xref:System.Windows.Forms.MouseEventArgs>. Handle this event when you need to get information about the mouse when a click occurs.|  
|<xref:System.Windows.Forms.Control.DoubleClick>|This event occurs when the control is double-clicked. The handler for this event receives an argument of type <xref:System.EventArgs>. Handle this event when you only need to determine when a double-click occurs.|  
|<xref:System.Windows.Forms.Control.MouseDoubleClick>|This event occurs when the user double-clicks the control with the mouse. The handler for this event receives an argument of type <xref:System.Windows.Forms.MouseEventArgs>. Handle this event when you need to get information about the mouse when a double-click occurs.|  
|<xref:System.Windows.Forms.Control.MouseDown>|This event occurs when the mouse pointer is over the control and the user presses a mouse button. The handler for this event receives an argument of type <xref:System.Windows.Forms.MouseEventArgs>.|  
|<xref:System.Windows.Forms.Control.MouseEnter>|This event occurs when the mouse pointer enters the border or client area of the control, depending on the type of control. The handler for this event receives an argument of type <xref:System.EventArgs>.|  
|<xref:System.Windows.Forms.Control.MouseHover>|This event occurs when the mouse pointer stops and rests over the control. The handler for this event receives an argument of type <xref:System.EventArgs>.|  
|<xref:System.Windows.Forms.Control.MouseLeave>|This event occurs when the mouse pointer leaves the border or client area of the control, depending on the type of the control. The handler for this event receives an argument of type <xref:System.EventArgs>.|  
|<xref:System.Windows.Forms.Control.MouseMove>|This event occurs when the mouse pointer moves while it is over a control. The handler for this event receives an argument of type <xref:System.Windows.Forms.MouseEventArgs>.|  
|<xref:System.Windows.Forms.Control.MouseUp>|This event occurs when the mouse pointer is over the control and the user releases a mouse button. The handler for this event receives an argument of type <xref:System.Windows.Forms.MouseEventArgs>.|  
|<xref:System.Windows.Forms.Control.MouseWheel>|This event occurs when the user rotates the mouse wheel while the control has focus. The handler for this event receives an argument of type <xref:System.Windows.Forms.MouseEventArgs>. You can use the <xref:System.Windows.Forms.MouseEventArgs.Delta%2A> property of <xref:System.Windows.Forms.MouseEventArgs> to determine how far the mouse has scrolled.|  
  
## Changing Mouse Input and Detecting System Settings  
 You can detect and change the way a control handles mouse input by deriving from the control and using the <xref:System.Windows.Forms.Control.GetStyle%2A> and <xref:System.Windows.Forms.Control.SetStyle%2A> methods. The <xref:System.Windows.Forms.Control.SetStyle%2A> method takes a bitwise combination of <xref:System.Windows.Forms.ControlStyles> values to determine whether the control will have standard click or double-click behavior or if the control will handle its own mouse processing. In addition, the <xref:System.Windows.Forms.SystemInformation> class includes properties that describe the capabilities of the mouse and specify how the mouse interacts with the operating system. The following table summarizes these properties.  
  
|Property|Description|  
|--------------|-----------------|  
|<xref:System.Windows.Forms.SystemInformation.DoubleClickSize%2A>|Gets the dimensions, in pixels, of the area in which the user must click twice for the operating system to consider the two clicks a double-click.|  
|<xref:System.Windows.Forms.SystemInformation.DoubleClickTime%2A>|Gets the maximum number of milliseconds that can elapse between a first click and a second click for the operating system to consider the mouse action a double-click.|  
|<xref:System.Windows.Forms.SystemInformation.MouseButtons%2A>|Gets the number of buttons on the mouse.|  
|<xref:System.Windows.Forms.SystemInformation.MouseButtonsSwapped%2A>|Gets a value indicating whether the functions of the left and right mouse buttons have been swapped.|  
|<xref:System.Windows.Forms.SystemInformation.MouseHoverSize%2A>|Gets the dimensions, in pixels, of the rectangle within which the mouse pointer has to stay for the mouse hover time before a mouse hover message is generated.|  
|<xref:System.Windows.Forms.SystemInformation.MouseHoverTime%2A>|Gets the time, in milliseconds, that the mouse pointer has to stay in the hover rectangle before a mouse hover message is generated.|  
|<xref:System.Windows.Forms.SystemInformation.MousePresent%2A>|Gets a value indicating whether a mouse is installed.|  
|<xref:System.Windows.Forms.SystemInformation.MouseSpeed%2A>|Gets a value indicating the current mouse speed, from 1 to 20.|  
|<xref:System.Windows.Forms.SystemInformation.MouseWheelPresent%2A>|Gets a value indicating whether a mouse with a mouse wheel is installed.|  
|<xref:System.Windows.Forms.SystemInformation.MouseWheelScrollDelta%2A>|Gets the amount of the delta value of the increment of a single mouse wheel rotation.|  
|<xref:System.Windows.Forms.SystemInformation.MouseWheelScrollLines%2A>|Gets the number of lines to scroll when the mouse wheel is rotated.|  
  
## See Also  
 [Mouse Input in a Windows Forms Application](../../../docs/framework/winforms/mouse-input-in-a-windows-forms-application.md)  
 [Mouse Capture in Windows Forms](../../../docs/framework/winforms/mouse-capture-in-windows-forms.md)  
 [Mouse Pointers in Windows Forms](../../../docs/framework/winforms/mouse-pointers-in-windows-forms.md)
