---
title: "How to: Perform Drag-and-Drop Operations Between Applications"
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
  - "drag and drop [Windows Forms], between applications"
ms.assetid: fa347436-2b12-4dd6-8507-59d7241f6a06
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Perform Drag-and-Drop Operations Between Applications
Performing drag-and-drop operations between applications is no different than enabling this action within an application, as long as both applications involved behave according to the "contract" established between the <xref:System.Windows.Forms.DragEventArgs.AllowedEffect%2A> and <xref:System.Windows.Forms.DragEventArgs.Effect%2A> properties.  
  
 In the following procedure, you will use a Windows-based application you create and the WordPad word processor that is included with the Windows operating system to perform drag-and-drop operations between applications. WordPad has a certain set of allowed effects for text being dragged and dropped; the Windows-based application you will write code for will work with these effects so that drag-and-drop operations may be completed successfully.  
  
### To perform a drag-and-drop procedure between applications  
  
1.  Create a new Windows Forms application.  
  
2.  Add a <xref:System.Windows.Forms.TextBox> control to your form.  
  
3.  Configure the <xref:System.Windows.Forms.TextBox> control to receive dropped data.  
  
     For more information, see [Walkthrough: Performing a Drag-and-Drop Operation in Windows Forms](../../../../docs/framework/winforms/advanced/walkthrough-performing-a-drag-and-drop-operation-in-windows-forms.md).  
  
4.  Run your Windows-based application, and while the application is running, run WordPad.  
  
     WordPad is a text editor installed by Windows that allows drag-and-drop operations. It is accessible by pressing the **Start** button, selecting **Run**, and then typing `WordPad` into the text box of the **Run** dialog box and clicking **OK**.  
  
5.  Once WordPad is open, type a string of text into it.  
  
6.  Using the mouse, select the text, and then drag the selected text over to the <xref:System.Windows.Forms.TextBox> control in your Windows-based application.  
  
     Observe that when you mouse over the <xref:System.Windows.Forms.TextBox> control (and, consequently, raise the <xref:System.Windows.Forms.Control.DragEnter> event), the cursor changes, and you can drop the selected text into the <xref:System.Windows.Forms.TextBox> control.  
  
     Additionally, you can configure your <xref:System.Windows.Forms.TextBox> control to allow text strings to be dragged and dropped into WordPad. For more information, see [Walkthrough: Performing a Drag-and-Drop Operation in Windows Forms](../../../../docs/framework/winforms/advanced/walkthrough-performing-a-drag-and-drop-operation-in-windows-forms.md).  
  
## See Also  
 [How to: Add Data to the Clipboard](../../../../docs/framework/winforms/advanced/how-to-add-data-to-the-clipboard.md)  
 [How to: Retrieve Data from the Clipboard](../../../../docs/framework/winforms/advanced/how-to-retrieve-data-from-the-clipboard.md)  
 [Drag-and-Drop Operations and Clipboard Support](../../../../docs/framework/winforms/advanced/drag-and-drop-operations-and-clipboard-support.md)
