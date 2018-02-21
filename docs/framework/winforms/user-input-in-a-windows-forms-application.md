---
title: "User Input in a Windows Forms Application"
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
  - "Windows Forms, user input"
ms.assetid: 9d61fa96-70f7-4754-885a-49a4a6316bdb
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# User Input in a Windows Forms Application
In Windows Forms, user input is sent to applications in the form of Windows messages. A series of overridable methods process these messages at the application, form, and control level. When these methods receive mouse and keyboard messages, they raise events that can be handled to get information about the mouse or keyboard input. In many cases, Windows Forms applications will be able to process all user input simply by handling these events. In other cases, an application may need to override one of the methods that process messages in order to intercept a particular message before it is received by the application, form, or control.  
  
## Mouse and Keyboard Events  
 All Windows Forms controls inherit a set of events related to mouse and keyboard input. For example, a control can handle the <xref:System.Windows.Forms.Control.KeyPress> event to determine the character code of a key that was pressed, or a control can handle the <xref:System.Windows.Forms.Control.MouseClick> event to determine the location of a mouse click. For more information on the mouse and keyboard events, see [Using Keyboard Events](../../../docs/framework/winforms/using-keyboard-events.md) and [Mouse Events in Windows Forms](../../../docs/framework/winforms/mouse-events-in-windows-forms.md).  
  
## Methods that Process User Input Messages  
 Forms and controls have access to the <xref:System.Windows.Forms.IMessageFilter> interface and a set of overridable methods that process Windows messages at different points in the message queue. These methods all have a <xref:System.Windows.Forms.Message> parameter, which encapsulates the low-level details of Windows messages. You can implement or override these methods to examine the message and then either consume the message or pass it on to the next consumer in the message queue. The following table presents the methods that process all Windows messages in Windows Forms.  
  
|Method|Notes|  
|------------|-----------|  
|<xref:System.Windows.Forms.IMessageFilter.PreFilterMessage%2A>|This method intercepts queued (also known as posted) Windows messages at the application level.|  
|<xref:System.Windows.Forms.Control.PreProcessMessage%2A>|This method intercepts Windows messages at the form and control level before they have been processed.|  
|<xref:System.Windows.Forms.Control.WndProc%2A>|This method processes Windows messages at the form and control level.|  
|<xref:System.Windows.Forms.Control.DefWndProc%2A>|This method performs the default processing of Windows messages at the form and control level. This provides the minimal functionality of a window.|  
|<xref:System.Windows.Forms.Control.OnNotifyMessage%2A>|This method intercepts messages at the form and control level, after they have been processed. The <xref:System.Windows.Forms.ControlStyles.EnableNotifyMessage> style bit must be set for this method to be called.|  
  
 Keyboard and mouse messages are also processed by an additional set of overridable methods that are specific to those types of messages. For more information, see [How Keyboard Input Works](../../../docs/framework/winforms/how-keyboard-input-works.md) and [How Mouse Input Works in Windows Forms](../../../docs/framework/winforms/how-mouse-input-works-in-windows-forms.md).  
  
## See Also  
 [User Input in Windows Forms](../../../docs/framework/winforms/user-input-in-windows-forms.md)  
 [Keyboard Input in a Windows Forms Application](../../../docs/framework/winforms/keyboard-input-in-a-windows-forms-application.md)  
 [Mouse Input in a Windows Forms Application](../../../docs/framework/winforms/mouse-input-in-a-windows-forms-application.md)
