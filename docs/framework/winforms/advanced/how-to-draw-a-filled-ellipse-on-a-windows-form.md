---
title: "How to: Draw a Filled Ellipse on a Windows Form"
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
  - "cpp"
f1_keywords: 
  - "Graphics.FillEllipse"
helpviewer_keywords: 
  - "ellipses [Windows Forms], drawing"
  - "circles [Windows Forms], drawing"
  - "circular shapes"
  - "drawing [Windows Forms], ellipses"
  - "shapes [Windows Forms], drawing"
  - "forms [Windows Forms], drawing ellipses"
ms.assetid: 781db806-950d-4c5b-b022-493f7fd0c4a8
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Draw a Filled Ellipse on a Windows Form
This example draws a filled ellipse on a form.  
  
## Example  
 [!code-cpp[System.Drawing.ConceptualHowTos#1](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/cpp/form1.cpp#1)]
 [!code-csharp[System.Drawing.ConceptualHowTos#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/CS/form1.cs#1)]
 [!code-vb[System.Drawing.ConceptualHowTos#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/VB/form1.vb#1)]  
  
## Compiling the Code  
 You cannot call this method in the <xref:System.Windows.Forms.Form.Load> event handler. The drawn content will not be redrawn if the form is resized or obscured by another form. To make your content automatically repaint, you should override the <xref:System.Windows.Forms.Control.OnPaint%2A> method.  
  
## Robust Programming  
 You should always call <xref:System.IDisposable.Dispose%2A> on any objects that consume system resources, such as <xref:System.Drawing.Brush> and <xref:System.Drawing.Graphics> objects.  
  
## See Also  
 [Graphics and Drawing in Windows Forms](../../../../docs/framework/winforms/advanced/graphics-and-drawing-in-windows-forms.md)  
 [Getting Started with Graphics Programming](../../../../docs/framework/winforms/advanced/getting-started-with-graphics-programming.md)  
 [Alpha Blending Lines and Fills](../../../../docs/framework/winforms/advanced/alpha-blending-lines-and-fills.md)  
 [Using a Brush to Fill Shapes](../../../../docs/framework/winforms/advanced/using-a-brush-to-fill-shapes.md)
