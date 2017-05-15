---
title: "How to: Use a Control Rendering Class | Microsoft Docs"
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
  - "jsharp"
helpviewer_keywords: 
  - "professional appearance, rendering Windows Forms controls"
  - "visual themes, applying to Windows Forms controls"
  - "visual styles, rendering Windows Forms controls"
ms.assetid: c0125e34-cd74-4c35-818c-3e40f462b0a3
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
---
# How to: Use a Control Rendering Class
This example demonstrates how to use the <xref:System.Windows.Forms.ComboBoxRenderer> class to render the drop-down arrow of a combo box control. The example consists of the <xref:System.Windows.Forms.Control.OnPaint%2A> method of a simple custom control. The <xref:System.Windows.Forms.ComboBoxRenderer.IsSupported%2A?displayProperty=fullName> property is used to determine whether visual styles are enabled in the client area of application windows. If visual styles are active, then the <xref:System.Windows.Forms.ComboBoxRenderer.DrawDropDownButton%2A?displayProperty=fullName> method will render the drop-down arrow with visual styles; otherwise, the <xref:System.Windows.Forms.ControlPaint.DrawComboButton%2A?displayProperty=fullName> method will render the drop-down arrow in the classic Windows style.  
  
## Example  
 [!code-cpp[System.Windows.Forms_ControlRenderer#10](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms_ControlRenderer/cpp/form1.cpp#10)]
 [!code-csharp[System.Windows.Forms_ControlRenderer#10](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms_ControlRenderer/CS/form1.cs#10)]
 [!code-vb[System.Windows.Forms_ControlRenderer#10](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms_ControlRenderer/VB/form1.vb#10)]  
  
## Compiling the Code  
 This example requires:  
  
-   A custom control derived from the <xref:System.Windows.Forms.Control> class.  
  
-   A <xref:System.Windows.Forms.Form> that hosts the custom control.  
  
-   References to the <xref:System?displayProperty=fullName>, <xref:System.Drawing?displayProperty=fullName>, <xref:System.Windows.Forms?displayProperty=fullName>, and <xref:System.Windows.Forms.VisualStyles?displayProperty=fullName> namespaces.  
  
## See Also  
 [Rendering Controls with Visual Styles](../../../../docs/framework/winforms/controls/rendering-controls-with-visual-styles.md)