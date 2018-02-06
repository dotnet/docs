---
title: "Mouse Capture in Windows Forms"
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
  - "mouse [Windows Forms], capture"
ms.assetid: 8911d4b0-a4f8-4f93-8246-371aebd27d0c
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Mouse Capture in Windows Forms
*Mouse capture* refers to when a control takes command of all mouse input. When a control has captured the mouse, it receives mouse input whether or not the pointer is within its borders.  
  
## Setting Mouse Capture  
 In Windows Forms the mouse is captured by the control when the user presses a mouse button on a control, and the mouse is released by the control when the user releases the mouse button.  
  
 The <xref:System.Windows.Forms.Control.Capture%2A> property of the <xref:System.Windows.Forms.Control> class specifies whether a control has captured the mouse. To determine when a control loses mouse capture, handle the <xref:System.Windows.Forms.Control.MouseCaptureChanged> event.  
  
 Only the foreground window can capture the mouse. When a background window attempts to capture the mouse, the window receives messages only for mouse events that occur when the mouse pointer is within the visible portion of the window. Also, even if the foreground window has captured the mouse, the user can still click another window, bringing it to the foreground. When the mouse is captured, shortcut keys do not work.  
  
## See Also  
 [Mouse Input in a Windows Forms Application](../../../docs/framework/winforms/mouse-input-in-a-windows-forms-application.md)
