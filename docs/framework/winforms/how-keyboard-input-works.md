---
title: "How Keyboard Input Works"
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
  - "keyboard input [Windows Forms], about keyboard input"
  - "keyboards [Windows Forms], keyboard input"
  - "Windows Forms, keyboard input"
ms.assetid: 9a29433c-a180-49bb-b74c-d187786584c8
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How Keyboard Input Works
Windows Forms processes keyboard input by raising keyboard events in response to Windows messages. Most Windows Forms applications process keyboard input exclusively by handling the keyboard events. However, you need to understand how keyboard messages work so you can implement more advanced keyboard-input scenarios, such as intercepting keys before they reach a control. This topic describes the types of key data that Windows Forms recognizes and provides an overview of how keyboard messages are routed. For information about keyboard events, see [Using Keyboard Events](../../../docs/framework/winforms/using-keyboard-events.md).  
  
## Types of Keys  
 Windows Forms identifies keyboard input as virtual-key codes that are represented by the bitwise <xref:System.Windows.Forms.Keys> enumeration. With the <xref:System.Windows.Forms.Keys> enumeration, you can combine a series of pressed keys to result in a single value. These values correspond to the values that accompany the WM_KEYDOWN and WM_SYSKEYDOWN Windows messages. You can detect most physical key presses by handling the <xref:System.Windows.Forms.Control.KeyDown> or <xref:System.Windows.Forms.Control.KeyUp> events. Character keys are a subset of the <xref:System.Windows.Forms.Keys> enumeration and correspond to the values that accompany the WM_CHAR and WM_SYSCHAR Windows messages. If the combination of pressed keys results in a character, you can detect the character by handling the <xref:System.Windows.Forms.Control.KeyPress> event. Alternatively, you can use <xref:Microsoft.VisualBasic.Devices.Keyboard>, exposed by Visual Basic programming interface, to discover which keys were pressed and send keys. For more information, see [Accessing the Keyboard](~/docs/visual-basic/developing-apps/programming/computer-resources/accessing-the-keyboard.md).  
  
## Order of Keyboard Events  
 As listed previously, there are 3 keyboard related events that can occur on a control. The following sequence shows the general order of the events:  
  
1.  The user pushes the "a" key, the key is preprocessed, dispatched, and a <xref:System.Windows.Forms.Control.KeyDown> event occurs.  
  
2.  The user holds the "a" key, the key is preprocessed, dispatched, and a <xref:System.Windows.Forms.Control.KeyPress> event occurs.  
  
     This event occurs multiple times as the user holds a key.  
  
3.  The user releases the "a" key, the key is preprocessed, dispatched and a <xref:System.Windows.Forms.Control.KeyUp> event occurs.  
  
## Preprocessing Keys  
 Like other messages, keyboard messages are processed in the <xref:System.Windows.Forms.Control.WndProc%2A> method of a form or control. However, before keyboard messages are processed, the <xref:System.Windows.Forms.Control.PreProcessMessage%2A> method calls one or more methods that can be overridden to handle special character keys and physical keys. You can override these methods to detect and filter certain keys before the messages are processed by the control. The following table shows the action that is being performed and the related method that occurs, in the order that the method occurs.  
  
### Preprocessing for a KeyDown event  
  
|Action|Related method|Notes|  
|------------|--------------------|-----------|  
|Check for a command key such as an accelerator or menu shortcut.|<xref:System.Windows.Forms.Control.ProcessCmdKey%2A>|This method processes a command key, which takes precedence over regular keys. If this method returns `true`, the key message is not dispatched and a key event does not occur. If it returns `false`, <xref:System.Windows.Forms.Control.IsInputKey%2A> is called`.`|  
|Check for a special key that requires preprocessing or a normal character key that should raise a <xref:System.Windows.Forms.Control.KeyDown> event and be dispatched to a control.|<xref:System.Windows.Forms.Control.IsInputKey%2A>|If the method returns `true`, it means the control is a regular character and a <xref:System.Windows.Forms.Control.KeyDown> event is raised. If `false`, <xref:System.Windows.Forms.Control.ProcessDialogKey%2A> is called. **Note:**  To ensure a control gets a key or combination of keys, you can handle the <xref:System.Windows.Forms.Control.PreviewKeyDown> event and set <xref:System.Windows.Forms.PreviewKeyDownEventArgs.IsInputKey%2A> of the <xref:System.Windows.Forms.PreviewKeyDownEventArgs> to `true` for the key or keys you want.|  
|Check for a navigation key (ESC, TAB, Return, or arrow keys).|<xref:System.Windows.Forms.Control.ProcessDialogKey%2A>|This method processes a physical key that employs special functionality within the control, such as switching focus between the control and its parent. If the immediate control does not handle the key, the <xref:System.Windows.Forms.Control.ProcessDialogKey%2A> is called on the parent control and so on to the topmost control in the hierarchy. If this method returns `true`, preprocessing is complete and a key event is not generated. If it returns `false`, a <xref:System.Windows.Forms.Control.KeyDown> event occurs.|  
  
### Preprocessing for a KeyPress Event  
  
|Action|Related method|Notes|  
|------------|--------------------|-----------|  
|Check to see the key is a normal character that should be processed by the control|<xref:System.Windows.Forms.Control.IsInputChar%2A>|If the character is a normal character, this method returns `true`, the <xref:System.Windows.Forms.Control.KeyPress> event is raised and no further preprocessing occurs. Otherwise <xref:System.Windows.Forms.Control.ProcessDialogChar%2A> will be called.|  
|Check to see if the character is a mnemonic (such as &OK on a button)|<xref:System.Windows.Forms.Control.ProcessDialogChar%2A>|This method, similar to <xref:System.Windows.Forms.Control.ProcessDialogKey%2A>, will be called up the control hierarchy. If the control is a container control, it checks for mnemonics by calling <xref:System.Windows.Forms.Control.ProcessMnemonic%2A> on itself and its child controls. If <xref:System.Windows.Forms.Control.ProcessDialogChar%2A> returns `true`, a <xref:System.Windows.Forms.Control.KeyPress> event does not occur.|  
  
## Processing Keyboard Messages  
 After keyboard messages reach the <xref:System.Windows.Forms.Control.WndProc%2A> method of a form or control, they are processed by a set of methods that can be overridden. Each of these methods returns a <xref:System.Boolean> value specifying whether the keyboard message has been processed and consumed by the control. If one of the methods returns `true`, then the message is considered handled, and it is not passed to the control's base or parent for further processing. Otherwise, the message stays in the message queue and may be processed in another method in the control's base or parent. The following table presents the methods that process keyboard messages.  
  
|Method|Notes|  
|------------|-----------|  
|<xref:System.Windows.Forms.Control.ProcessKeyMessage%2A>|This method processes all keyboard messages that are received by the <xref:System.Windows.Forms.Control.WndProc%2A> method of the control.|  
|<xref:System.Windows.Forms.Control.ProcessKeyPreview%2A>|This method sends the keyboard message to the control's parent. If <xref:System.Windows.Forms.Control.ProcessKeyPreview%2A> returns `true`, no key event is generated, otherwise <xref:System.Windows.Forms.Control.ProcessKeyEventArgs%2A> is called.|  
|<xref:System.Windows.Forms.Control.ProcessKeyEventArgs%2A>|This method raises the <xref:System.Windows.Forms.Control.KeyDown>, <xref:System.Windows.Forms.Control.KeyPress>, and <xref:System.Windows.Forms.Control.KeyUp> events, as appropriate.|  
  
## Overriding Keyboard Methods  
 There are many methods available for overriding when a keyboard message is preprocessed and processed; however, some methods are much better choices than others. Following table shows tasks you might want to accomplish and the best way to override the keyboard methods. For more information on overriding methods, see [Overriding properties and methods in derived classes](~/docs/visual-basic/programming-guide/language-features/objects-and-classes/inheritance-basics.md#overriding-properties-and-methods-in-derived-classes).  
  
|Task|Method|  
|----------|------------|  
|Intercept a navigation key and raise a <xref:System.Windows.Forms.Control.KeyDown> event. For example you want TAB and Return to be handled in a text box.|Override <xref:System.Windows.Forms.Control.IsInputKey%2A>. **Note:**  Alternatively, you can handle the <xref:System.Windows.Forms.Control.PreviewKeyDown> event and set <xref:System.Windows.Forms.PreviewKeyDownEventArgs.IsInputKey%2A> of the <xref:System.Windows.Forms.PreviewKeyDownEventArgs> to `true` for the key or keys you want.|  
|Perform special input or navigation handling on a control. For example, you want the use of arrow keys in your list control to change the selected item.|Override <xref:System.Windows.Forms.Control.ProcessDialogKey%2A>|  
|Intercept a navigation key and raise a <xref:System.Windows.Forms.Control.KeyPress> event. For example in a spin-box control you want multiple arrow key presses to accelerate progression through the items.|Override <xref:System.Windows.Forms.Control.IsInputChar%2A>.|  
|Perform special input or navigation handling during a <xref:System.Windows.Forms.Control.KeyPress> event. For example, in a list control holding down the "r" key skips between items that begin with the letter r.|Override <xref:System.Windows.Forms.Control.ProcessDialogChar%2A>|  
|Perform custom mnemonic handling; for example, you want to handle mnemonics on owner-drawn buttons contained in a toolbar.|Override <xref:System.Windows.Forms.Control.ProcessMnemonic%2A>.|  
  
## See Also  
 <xref:System.Windows.Forms.Keys>  
 <xref:System.Windows.Forms.Control.WndProc%2A>  
 <xref:System.Windows.Forms.Control.PreProcessMessage%2A>  
 [My.Computer.Keyboard Object](~/docs/visual-basic/language-reference/objects/my-computer-keyboard-object.md)  
 [Accessing the Keyboard](~/docs/visual-basic/developing-apps/programming/computer-resources/accessing-the-keyboard.md)  
 [Using Keyboard Events](../../../docs/framework/winforms/using-keyboard-events.md)
