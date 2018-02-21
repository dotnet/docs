---
title: "Windows Forms Control Development Basics"
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
  - "custom controls [Windows Forms], derivation types"
  - "programming concepts [Windows Forms], Windows Forms controls"
  - "controls [Windows Forms], creating"
ms.assetid: 6277bb81-90f7-4c5b-9f4b-b02bb42dd316
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Windows Forms Control Development Basics
A Windows Forms control is a class that derives directly or indirectly from <xref:System.Windows.Forms.Control?displayProperty=nameWithType>. The following list describes common scenarios for developing Windows Forms controls:  
  
-   Combining existing controls to author a composite control.  
  
     Composite controls encapsulate a user interface that can be reused as a control. An example of a composite control is a control that consists of a text box and a reset button. Visual designers offer rich support for creating composite controls. To author a composite control, derive from <xref:System.Windows.Forms.UserControl?displayProperty=nameWithType>. The base class <xref:System.Windows.Forms.UserControl> provides keyboard routing for child controls and enables child controls to work as a group. For more information, see [Developing a Composite Windows Forms Control](../../../../docs/framework/winforms/controls/developing-a-composite-windows-forms-control.md).  
  
-   Extending an existing control to customize it or to add to its functionality.  
  
     A button whose color cannot be changed and a button that has an additional property that tracks how many times it has been clicked are examples of extended controls. You can customize any Windows Forms control by deriving from it and overriding or adding properties, methods, and events.  
  
-   Authoring a control that does not combine or extend existing controls.  
  
     In this scenario, derive your control from the base class <xref:System.Windows.Forms.Control>. You can add as well as override properties, methods, and events of the base class. To get started, see [How to: Develop a Simple Windows Forms Control](../../../../docs/framework/winforms/controls/how-to-develop-a-simple-windows-forms-control.md).  
  
 The base class for Windows Forms controls, <xref:System.Windows.Forms.Control>, provides the plumbing required for visual display in client-side Windows-based applications. <xref:System.Windows.Forms.Control> provides a window handle, handles message routing, and provides mouse and keyboard events as well as many other user interface events. It provides advanced layout and has properties specific to visual display, such as <xref:System.Windows.Forms.Control.ForeColor%2A>, <xref:System.Windows.Forms.Control.BackColor%2A>, <xref:System.Windows.Forms.Control.Height%2A>, <xref:System.Windows.Forms.Control.Width%2A>, and many others. Additionally, it provides security, threading support, and interoperability with ActiveX controls. Because so much of the infrastructure is provided by the base class, it is relatively easy to develop your own Windows Forms controls.  
  
## See Also  
 [How to: Develop a Simple Windows Forms Control](../../../../docs/framework/winforms/controls/how-to-develop-a-simple-windows-forms-control.md)  
 [Developing a Composite Windows Forms Control](../../../../docs/framework/winforms/controls/developing-a-composite-windows-forms-control.md)  
 [How to: Create a Windows Forms Control That Shows Progress](../../../../docs/framework/winforms/controls/how-to-create-a-windows-forms-control-that-shows-progress.md)  
 [Varieties of Custom Controls](../../../../docs/framework/winforms/controls/varieties-of-custom-controls.md)
