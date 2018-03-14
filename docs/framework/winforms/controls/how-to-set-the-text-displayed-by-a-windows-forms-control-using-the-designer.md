---
title: "How to: Set the Text Displayed by a Windows Forms Control Using the Designer"
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
  - "controls [Windows Forms], setting caption"
  - "Windows Forms, setting the text displayed"
ms.assetid: 9d18e0e0-f17f-4074-837d-e67ceeeaa89d
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Set the Text Displayed by a Windows Forms Control Using the Designer
Windows Forms controls typically display some text that is related to the primary function of the control. For example, a <xref:System.Windows.Forms.Button> control typically displays a caption that indicates what action will be performed when the button is clicked. For all controls, you can set or return the text by using the <xref:System.Windows.Forms.Control.Text%2A> property. You can change the font by using the <xref:System.Windows.Forms.Control.Font%2A> property.  
  
### To set the text and font with the designer  
  
1.  In the Properties window, set the <xref:System.Windows.Forms.Control.Text%2A> property of the control to an appropriate string.  
  
     To create an underlined shortcut key, includes an ampersand (&) before the letter that will be the shortcut key.  
  
2.  In the Properties window, click the ellipsis button (![VisualStudioEllipsesButton screenshot](../../../../docs/framework/winforms/media/vbellipsesbutton.png "vbEllipsesButton")) next to the <xref:System.Windows.Forms.Control.Font%2A> property.  
  
     In the standard font dialog box, select the font, font style, size, effects (such as strikeout or underline), and script that you want.  
  
## See Also  
 [How to: Set the Text Displayed by a Windows Forms Control](../../../../docs/framework/winforms/controls/how-to-set-the-text-displayed-by-a-windows-forms-control.md)  
 [Using Fonts and Text](../../../../docs/framework/winforms/advanced/using-fonts-and-text.md)  
 [Labeling Individual Windows Forms Controls and Providing Shortcuts to Them](../../../../docs/framework/winforms/controls/labeling-individual-windows-forms-controls-and-providing-shortcuts-to-them.md)
