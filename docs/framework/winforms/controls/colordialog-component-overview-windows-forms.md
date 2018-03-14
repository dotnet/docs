---
title: "ColorDialog Component Overview (Windows Forms)"
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
  - "ColorDialog"
helpviewer_keywords: 
  - "color dialog box [Windows Forms], about color dialog box"
  - "ColorDialog component [Windows Forms], about ColorDialog"
ms.assetid: 6dbdd8f0-f697-4728-bb09-7ea156f6d800
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ColorDialog Component Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.ColorDialog> component is a pre-configured dialog box that allows the user to select a color from a palette and to add custom colors to that palette. It is the same dialog box that you see in other Windows-based applications to select colors. Use it within your Windows-based application as a simple solution in lieu of configuring your own dialog box.  
  
 The color selected in the dialog box is returned in the <xref:System.Windows.Forms.ColorDialog.Color%2A> property. If the <xref:System.Windows.Forms.ColorDialog.AllowFullOpen%2A> property is set to `false`, the "Define Custom Colors" button is disabled and the user is restricted to the predefined colors in the palette. If the <xref:System.Windows.Forms.ColorDialog.SolidColorOnly%2A> property is set to `true`, the user cannot select dithered colors. To display the dialog box, you must call its <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method.  
  
## See Also  
 <xref:System.Windows.Forms.ColorDialog>  
 [ColorDialog Component](../../../../docs/framework/winforms/controls/colordialog-component-windows-forms.md)  
 [Dialog-Box Controls and Components](../../../../docs/framework/winforms/controls/dialog-box-controls-and-components-windows-forms.md)  
 [How to: Change the Appearance of the Windows Forms ColorDialog Component](../../../../docs/framework/winforms/controls/how-to-change-the-appearance-of-the-windows-forms-colordialog-component.md)
