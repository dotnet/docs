---
title: "How to: Fill a Shape with a Hatch Pattern"
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
  - "patterns [Windows Forms], adding to shapes"
  - "shapes [Windows Forms], filling with patterns"
  - "brushes [Windows Forms], using hatch brushes"
ms.assetid: 9c8300ff-187b-404f-af1f-ebd499f5b16f
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Fill a Shape with a Hatch Pattern
A hatch pattern is made from two colors: one for the background and one for the lines that form the pattern over the background. To fill a closed shape with a hatch pattern, use a <xref:System.Drawing.Drawing2D.HatchBrush> object. The following example demonstrates how to fill an ellipse with a hatch pattern:  
  
## Example  
 The <xref:System.Drawing.Drawing2D.HatchBrush.%23ctor%2A> constructor takes three arguments: the hatch style, the color of the hatch line, and the color of the background. The hatch style argument can be any value from the <xref:System.Drawing.Drawing2D.HatchStyle> enumeration. There are more than fifty elements in the <xref:System.Drawing.Drawing2D.HatchStyle> enumeration; a few of those elements are shown in the following list:  
  
-   <xref:System.Drawing.Drawing2D.HatchStyle.Horizontal>  
  
-   <xref:System.Drawing.Drawing2D.HatchStyle.Vertical>  
  
-   <xref:System.Drawing.Drawing2D.HatchStyle.ForwardDiagonal>  
  
-   <xref:System.Drawing.Drawing2D.HatchStyle.BackwardDiagonal>  
  
-   <xref:System.Drawing.Drawing2D.HatchStyle.Cross>  
  
-   <xref:System.Drawing.Drawing2D.HatchStyle.DiagonalCross>  
  
 The following illustration shows the filled ellipse.  
  
 ![Hatch Pattern](../../../../docs/framework/winforms/advanced/media/hatch1.png "hatch1")  
  
 [!code-csharp[System.Drawing.UsingABrush#41](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.UsingABrush/CS/Class1.cs#41)]
 [!code-vb[System.Drawing.UsingABrush#41](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.UsingABrush/VB/Class1.vb#41)]  
  
## Compiling the Code  
 The preceding example is designed for use with Windows Forms, and it requires <xref:System.Windows.Forms.PaintEventArgs>`e`, which is a parameter of the <xref:System.Windows.Forms.Control.Paint> event handler.  
  
## See Also  
 [Using a Brush to Fill Shapes](../../../../docs/framework/winforms/advanced/using-a-brush-to-fill-shapes.md)
