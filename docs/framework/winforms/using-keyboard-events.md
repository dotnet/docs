---
title: "Using Keyboard Events"
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
  - "KeyPress event [Windows Forms]"
  - "keyboards [Windows Forms], keyboard events"
  - "KeyUp event"
  - "KeyDown event"
  - "keyboard events"
  - "events [Windows Forms], keyboard"
ms.assetid: d3f3e14b-a459-4ee6-9875-8957e34f8ee9
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Using Keyboard Events
Most Windows Forms programs process keyboard input by handling the keyboard events. This topic provides an overview of the keyboard events, including details on when to use each event and the data that is supplied for each event.  Also see [Event Handlers Overview (Windows Forms)](http://msdn.microsoft.com/library/be6fx1bb\(v=vs.110\)), [Events Overview (Windows Forms)](http://msdn.microsoft.com/library/1h12f09z\(v=vs.110\)).  
  
## Keyboard Events  
 Windows Forms provides two events that occur when a user presses a keyboard key and one event when a user releases a keyboard key:  
  
-   The <xref:System.Windows.Forms.Control.KeyDown> event occurs once  
  
-   The <xref:System.Windows.Forms.Control.KeyPress> event, which can occur multiple times when a user holds down the same key.  
  
-   The <xref:System.Windows.Forms.Control.KeyUp> event occurs once when a user releases a key.  
  
 When a user presses a key, Windows Forms determines which event to raise based on whether the keyboard message specifies a character key or a physical key. For more information about character and physical keys, see [How Keyboard Input Works](../../../docs/framework/winforms/how-keyboard-input-works.md).  
  
 The following table describes the three keyboard events.  
  
|Keyboard event|Description|Results|  
|--------------------|-----------------|-------------|  
|<xref:System.Windows.Forms.Control.KeyDown>|This event is raised when a user presses a physical key.|The handler for <xref:System.Windows.Forms.Control.KeyDown> receives:<br /><br /> <ul><li>A <xref:System.Windows.Forms.KeyEventArgs> parameter, which provides the <xref:System.Windows.Forms.KeyEventArgs.KeyCode%2A> property (which specifies a physical keyboard button).</li><li>The <xref:System.Windows.Forms.KeyEventArgs.Modifiers%2A> property (SHIFT, CTRL, or ALT).</li><li>The <xref:System.Windows.Forms.KeyEventArgs.KeyData%2A> property (which combines the key code and modifier). The <xref:System.Windows.Forms.KeyEventArgs> parameter also provides:<br /><br /> <ul><li>The <xref:System.Windows.Forms.KeyEventArgs.Handled%2A> property, which can be set to prevent the underlying control from receiving the key.</li><li>The <xref:System.Windows.Forms.KeyEventArgs.SuppressKeyPress%2A> property, which can be used to suppress the <xref:System.Windows.Forms.Control.KeyPress> and <xref:System.Windows.Forms.Control.KeyUp> events for that keystroke.</li></ul></li></ul>|  
|<xref:System.Windows.Forms.Control.KeyPress>|This event is raised when the key or keys pressed result in a character. For example, a user presses SHIFT and the lowercase "a" keys, which result in a capital letter "A" character.|<xref:System.Windows.Forms.Control.KeyPress> is raised after <xref:System.Windows.Forms.Control.KeyDown>.<br /><br /> <ul><li>The handler for <xref:System.Windows.Forms.Control.KeyPress> receives:</li><li>A <xref:System.Windows.Forms.KeyPressEventArgs> parameter, which contains the character code of the key that was pressed. This character code is unique for every combination of a character key and a modifier key.<br /><br />     For example, the "A" key will generate:<br /><br /> <ul><li>The character code 65, if it is pressed with the SHIFT key</li><li>Or the CAPS LOCK key, 97 if it is pressed by itself,</li><li>And 1, if it is pressed with the CTRL key.</li></ul></li></ul>|  
|<xref:System.Windows.Forms.Control.KeyUp>|This event is raised when a user releases a physical key.|The handler for <xref:System.Windows.Forms.Control.KeyUp> receives:<br /><br /> <ul><li>A <xref:System.Windows.Forms.KeyEventArgs> parameter:<br /><br /> <ul><li>Which provides the <xref:System.Windows.Forms.KeyEventArgs.KeyCode%2A> property (which specifies a physical keyboard button).</li><li>The <xref:System.Windows.Forms.KeyEventArgs.Modifiers%2A> property (SHIFT, CTRL, or ALT).</li><li>The <xref:System.Globalization.SortKey.KeyData%2A> property (which combines the key code and modifier).</li></ul></li></ul>|  
  
## See Also  
 [Keyboard Input in a Windows Forms Application](../../../docs/framework/winforms/keyboard-input-in-a-windows-forms-application.md)  
 [How Keyboard Input Works](../../../docs/framework/winforms/how-keyboard-input-works.md)  
 [Mouse Input in a Windows Forms Application](../../../docs/framework/winforms/mouse-input-in-a-windows-forms-application.md)
