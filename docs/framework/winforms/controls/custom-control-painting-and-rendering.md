---
title: "Custom Control Painting and Rendering"
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
  - "custom controls [Windows Forms], rendering"
  - "custom controls [Windows Forms], painting"
  - "user controls [Windows Forms], painting"
ms.assetid: a09dbf76-0966-4cbf-a66a-2083ba98e068
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Custom Control Painting and Rendering
Custom painting of controls is one of the many complicated tasks made easy by the .NET Framework. When authoring a custom control, you have many options regarding your control's graphical appearance. If you are authoring a control that inherits from the `Control`, you must provide code that allows your control to render its graphical representation. If you are creating a user control by inheriting from the `UserControl`, or are inheriting from one of the Windows Forms controls, you may override the standard graphical representation and provide your own graphics code. If you want to provide custom rendering for the constituent controls of a `UserControl` you are authoring, your options become more limited, but still allow a wide range of graphical possibilities for your controls and applications.  
  
## In This Section  
 [Rendering a Windows Forms Control](../../../../docs/framework/winforms/controls/rendering-a-windows-forms-control.md)  
 Shows how to program the logic that displays a control.  
  
 [User-Drawn Controls](../../../../docs/framework/winforms/controls/user-drawn-controls.md)  
 Gives an overview of the steps involved in writing and overriding rendering code for your control.  
  
 [Constituent Controls](../../../../docs/framework/winforms/controls/constituent-controls.md)  
 Describes how to implement custom rendering code for constituent controls in your user controls and forms.  
  
 [How to: Make Your Control Invisible at Run Time](../../../../docs/framework/winforms/controls/how-to-make-your-control-invisible-at-run-time.md)  
 Shows how to use the <xref:System.Windows.Forms.Control.Visible%2A> property to hide and show a control.  
  
 [How to: Give Your Control a Transparent Background](../../../../docs/framework/winforms/controls/how-to-give-your-control-a-transparent-background.md)  
 Shows how to use the <xref:System.Windows.Forms.Control.SetStyle%2A> method to create a background color that is opaque, transparent, or partially transparent.  
  
 [Rendering Controls with Visual Styles](../../../../docs/framework/winforms/controls/rendering-controls-with-visual-styles.md)  
 Shows how to render controls using visual styles in operating systems that support them.  
  
## Reference  
 <xref:System.Windows.Forms.Control>  
 Describes this class and has links to all of its members.  
  
 <xref:System.Windows.Forms.UserControl>  
 Describes this class and has links to all of its members.  
  
 <xref:System.Windows.Forms.Control.OnPaint%2A>  
 Describes this method.  
  
## Related Sections  
 [How to: Create Graphics Objects for Drawing](../../../../docs/framework/winforms/advanced/how-to-create-graphics-objects-for-drawing.md)  
 Introduces [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] graphics functionality from a Visual Studio perspective and gives links to more information.  
  
 [Varieties of Custom Controls](../../../../docs/framework/winforms/controls/varieties-of-custom-controls.md)  
 Describes the kinds of custom controls you can author.
