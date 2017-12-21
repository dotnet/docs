---
title: "FontDialog Component Overview (Windows Forms)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "FontDialog"
helpviewer_keywords: 
  - "Font dialog box [Windows Forms], Windows Forms"
  - "Font dialog box"
  - "FontDialog component [Windows Forms], about FontDialog component"
ms.assetid: daf46e57-1b4b-4b7a-bad0-b50ca7ba75dc
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# FontDialog Component Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.FontDialog> component is a pre-configured dialog box, which is the standard Windows **Font** dialog box used to expose the fonts that are currently installed on the system. Use it within your Windows-based application as a simple solution for font selection in lieu of configuring your own dialog box.  
  
 By default, the dialog box shows list boxes for Font, Font style, and Size; check boxes for effects like Strikeout and Underline; a drop-down list for Script; and a sample of how the font will appear. (Script refers to different character scripts that are available for a given font, for example, Hebrew or Japanese.) To display the font dialog box, call the <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method.  
  
## Key Properties  
 The component has a number of properties that configure its appearance. The properties that set the dialog-box selections are <xref:System.Windows.Forms.FontDialog.Font%2A> and <xref:System.Windows.Forms.FontDialog.Color%2A>. The <xref:System.Windows.Forms.FontDialog.Font%2A> property sets the font, style, size, script, and effects; for example, `Arial, 10pt, style=Italic, Strikeout`.  
  
## See Also  
 <xref:System.Windows.Forms.FontDialog>  
 [FontDialog Component](../../../../docs/framework/winforms/controls/fontdialog-component-windows-forms.md)
