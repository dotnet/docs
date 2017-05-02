---
title: "How to: Render a Visual Style Element | Microsoft Docs"
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
  - "visual themes, applying to elements of Windows Forms applications"
  - "professional appearance, applying to elements of Windows Forms applications"
  - "visual styles, rendering Windows Forms controls"
ms.assetid: a207781b-1baa-4ce9-b788-1e951bd4b5df
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
---
# How to: Render a Visual Style Element
The <xref:System.Windows.Forms.VisualStyles?displayProperty=fullName> namespace exposes <xref:System.Windows.Forms.VisualStyles.VisualStyleElement> objects that represent the Windows user interface (UI) elements supported by visual styles. This topic demonstrates how to use the <xref:System.Windows.Forms.VisualStyles.VisualStyleRenderer> class to render the <xref:System.Windows.Forms.VisualStyles.VisualStyleElement> that represents the **Log Off** and **Shut Down** buttons of the Start menu.  
  
### To render a visual style element  
  
1.  Create a <xref:System.Windows.Forms.VisualStyles.VisualStyleRenderer> and set it to the element you want to draw. Note the use of the <xref:System.Windows.Forms.Application.RenderWithVisualStyles%2A?displayProperty=fullName> property and the <xref:System.Windows.Forms.VisualStyles.VisualStyleRenderer.IsElementDefined%2A?displayProperty=fullName> method; the <xref:System.Windows.Forms.VisualStyles.VisualStyleRenderer.%23ctor%2A> constructor will throw an exception if visual styles are disabled or an element is undefined.  
  
     [!code-cpp[System.Windows.Forms.VisualStyles.VisualStyleRenderer_Simple#4](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.VisualStyles.VisualStyleRenderer_Simple/cpp/form1.cpp#4)]
     [!code-csharp[System.Windows.Forms.VisualStyles.VisualStyleRenderer_Simple#4](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.VisualStyles.VisualStyleRenderer_Simple/CS/form1.cs#4)]
     [!code-vb[System.Windows.Forms.VisualStyles.VisualStyleRenderer_Simple#4](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.VisualStyles.VisualStyleRenderer_Simple/VB/form1.vb#4)]  
  
2.  Call the <xref:System.Windows.Forms.VisualStyles.VisualStyleRenderer.DrawBackground%2A> method to render the element that the <xref:System.Windows.Forms.VisualStyles.VisualStyleRenderer> currently represents.  
  
     [!code-cpp[System.Windows.Forms.VisualStyles.VisualStyleRenderer_Simple#6](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.VisualStyles.VisualStyleRenderer_Simple/cpp/form1.cpp#6)]
     [!code-csharp[System.Windows.Forms.VisualStyles.VisualStyleRenderer_Simple#6](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.VisualStyles.VisualStyleRenderer_Simple/CS/form1.cs#6)]
     [!code-vb[System.Windows.Forms.VisualStyles.VisualStyleRenderer_Simple#6](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.VisualStyles.VisualStyleRenderer_Simple/VB/form1.vb#6)]  
  
## Compiling the Code  
 This example requires:  
  
-   A custom control derived from the <xref:System.Windows.Forms.Control> class.  
  
-   A <xref:System.Windows.Forms.Form> that hosts the custom control.  
  
-   References to the <xref:System?displayProperty=fullName>, <xref:System.Drawing?displayProperty=fullName>, <xref:System.Windows.Forms?displayProperty=fullName>, and <xref:System.Windows.Forms.VisualStyles?displayProperty=fullName> namespaces.  
  
## See Also  
 [Rendering Controls with Visual Styles](../../../../docs/framework/winforms/controls/rendering-controls-with-visual-styles.md)