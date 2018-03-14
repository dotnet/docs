---
title: "How to: Create a Shaped Windows Form"
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
helpviewer_keywords: 
  - "forms [Windows Forms], rounded"
  - "Windows Forms, custom shapes"
  - "Windows Forms, shaped"
  - "shaped forms"
  - "forms [Windows Forms], changing the shape of"
  - "forms [Windows Forms], circular"
  - "forms [Windows Forms], nonrectangular"
  - "Windows Forms, nonrectangular shape"
  - "Windows Forms, rounded"
  - "Windows Forms, circular"
  - "forms [Windows Forms], custom shapes"
ms.assetid: 6e6041e0-8e67-4487-b1e9-e410dbd1ef6c
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create a Shaped Windows Form
This example gives a form an elliptical shape that resizes with the form.  
  
## Example  
 [!code-cpp[System.Drawing.ConceptualHowTos#10](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/cpp/form1.cpp#10)]
 [!code-csharp[System.Drawing.ConceptualHowTos#10](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/CS/form1.cs#10)]
 [!code-vb[System.Drawing.ConceptualHowTos#10](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/VB/form1.vb#10)]  
  
## Compiling the Code  
 This example requires:  
  
-   References to the <xref:System.Windows.Forms> and <xref:System.Drawing> namespaces.  
  
 This example overrides the <xref:System.Windows.Forms.Control.OnPaint%2A> method to change the shape of the form. To use this code, copy the method declaration as well as the drawing code inside the method.  
  
## See Also  
 <xref:System.Windows.Forms.Control.OnPaint%2A>  
 <xref:System.Drawing.Region>  
 <xref:System.Drawing>  
 <xref:System.Drawing.Drawing2D.GraphicsPath.AddEllipse%2A>  
 <xref:System.Windows.Forms.Control.Region%2A>  
 [Getting Started with Graphics Programming](../../../../docs/framework/winforms/advanced/getting-started-with-graphics-programming.md)
