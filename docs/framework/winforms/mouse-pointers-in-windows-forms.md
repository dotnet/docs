---
title: "Mouse Pointers in Windows Forms"
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
  - "pointers [Windows Forms], setting"
  - "mouse pointers"
  - "mouse cursors"
  - "mouse pointers [Windows Forms], setting"
  - "cursors [Windows Forms], setting"
  - "mouse [Windows Forms], cursors"
ms.assetid: c3400d85-de5b-42e8-abc3-d6088d69ee53
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Mouse Pointers in Windows Forms
The mouse *pointer*, which is sometimes referred to as the cursor, is a bitmap that specifies a focus point on the screen for user input with the mouse. This topic provides an overview of the mouse pointer in Windows Forms and describes some of the ways to modify and control the mouse pointer.  
  
## Accessing the Mouse Pointer  
 The mouse pointer is represented by the <xref:System.Windows.Forms.Cursor> class, and each <xref:System.Windows.Forms.Control> has a <xref:System.Windows.Forms.Control.Cursor%2A?displayProperty=nameWithType> property that specifies the pointer for that control. The <xref:System.Windows.Forms.Cursor> class contains properties that describe the pointer, such as the <xref:System.Windows.Forms.Cursor.Position%2A> and <xref:System.Windows.Forms.Cursor.HotSpot%2A> properties, and methods that can modify the appearance of the pointer, such as the <xref:System.Windows.Forms.Cursor.Show%2A>, <xref:System.Windows.Forms.Cursor.Hide%2A>, and <xref:System.Windows.Forms.Cursor.DrawStretched%2A> methods.  
  
## Controlling the Mouse Pointer  
 Sometimes you may want to limit the area in which the mouse pointer can be used or change the position the mouse. You can get or set the current location of the mouse using the <xref:System.Windows.Forms.Cursor.Position%2A> property of the <xref:System.Windows.Forms.Cursor>. In addition, you can limit the area the mouse pointer can be used be setting the <xref:System.Windows.Forms.Cursor.Clip%2A> property. The clip area, by default, is the entire screen.  
  
## Changing the Mouse Pointer  
 Changing the mouse pointer is an important way of providing feedback to the user. For example, the mouse pointer can be modified in the handlers of the <xref:System.Windows.Forms.Control.MouseEnter> and <xref:System.Windows.Forms.Control.MouseLeave> events to tell the user that computations are occurring and to limit user interaction in the control. Sometimes, the mouse pointer will change because of system events, such as when your application is involved in a drag-and-drop operation.  
  
 The primary way to change the mouse pointer is by setting the <xref:System.Windows.Forms.Control.Cursor%2A?displayProperty=nameWithType> or <xref:System.Windows.Forms.Control.DefaultCursor%2A> property of a control to a new <xref:System.Windows.Forms.Cursor>. For examples of changing the mouse pointer, see the code example in the <xref:System.Windows.Forms.Cursor> class. In addition, the <xref:System.Windows.Forms.Cursors> class exposes a set of <xref:System.Windows.Forms.Cursor> objects for many different types of pointers, such as a pointer that resembles a hand. To display the wait pointer, which resembles an hourglass, whenever the mouse pointer is on the control, use the <xref:System.Windows.Forms.Control.UseWaitCursor%2A> property of the <xref:System.Windows.Forms.Control> class.  
  
## See Also  
 <xref:System.Windows.Forms.Cursor>  
 [Mouse Input in a Windows Forms Application](../../../docs/framework/winforms/mouse-input-in-a-windows-forms-application.md)  
 [Drag-and-Drop Functionality in Windows Forms](../../../docs/framework/winforms/drag-and-drop-functionality-in-windows-forms.md)
