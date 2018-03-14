---
title: "Constituent Controls"
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
  - "custom controls [Windows Forms], constituent controls"
  - "constituent controls [Windows Forms]"
  - "user controls [Windows Forms], constituent controls"
ms.assetid: 5565e720-198b-4bbd-a2bd-c447ba641798
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Constituent Controls
The controls that make up a user control, or *constituent controls* as they are termed, are relatively inflexible when it comes to custom graphics rendering. All Windows Forms controls handle their own rendering through their own <xref:System.Windows.Forms.Control.OnPaint%2A> method. Because this method is protected, it is not accessible to the developer, and thus cannot be prevented from executing when the control is painted. This does not mean, however, that you cannot add code to affect the appearance of constituent controls. Additional rendering can be accomplished by adding an event handler. For example, suppose you were authoring a <xref:System.Windows.Forms.UserControl> with a button named `MyButton`. If you wished to have additional rendering beyond what was provided by the <xref:System.Web.UI.WebControls.Button>, you would add code to your user control similar to the following:  
  
```vb  
Public Sub MyPaint(ByVal sender as Object, e as PaintEventArgs) Handles _  
   MyButton.Paint  
   'Additional rendering code goes here  
End Sub  
```  
  
```csharp  
// Add the event handler to the button's Paint event.  
MyButton.Paint +=   
   new System.Windows.Forms.PaintEventHandler (this.MyPaint);  
// Create the custom painting method.  
protected void MyPaint (object sender,   
System.Windows.Forms.PaintEventArgs e)  
{  
   // Additional rendering code goes here.  
}  
```  
  
> [!NOTE]
>  Some Windows Forms controls, such as <xref:System.Windows.Forms.TextBox>, are painted directly by Windows. In these instances, the <xref:System.Windows.Forms.Control.OnPaint%2A> method is never called, and thus the above example will never be called.  
  
 This creates a method that executes every time the `MyButton.Paint` event executes, thereby adding additional graphical representation to your control. Note that this does not prevent the execution of `MyButton.OnPaint`, and thus all of the painting usually performed by a button will still be performed in addition to your custom painting. For details about GDI+ technology and custom rendering, see the [Creating Graphical Images with GDI+](../../../../docs/framework/winforms/advanced/how-to-create-graphics-objects-for-drawing.md). If you wish to have a unique representation of your control, your best course of action is to create an inherited control, and to write custom rendering code for it. For details, see [User-Drawn Controls](../../../../docs/framework/winforms/controls/user-drawn-controls.md).  
  
## See Also  
 <xref:System.Windows.Forms.UserControl>  
 <xref:System.Windows.Forms.Control.OnPaint%2A>  
 [User-Drawn Controls](../../../../docs/framework/winforms/controls/user-drawn-controls.md)  
 [How to: Create Graphics Objects for Drawing](../../../../docs/framework/winforms/advanced/how-to-create-graphics-objects-for-drawing.md)  
 [Varieties of Custom Controls](../../../../docs/framework/winforms/controls/varieties-of-custom-controls.md)
