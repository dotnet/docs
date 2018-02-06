---
title: "How to: Use a Pen to Draw Rectangles"
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
  - "rectangles [Windows Forms], drawing"
  - "pens [Windows Forms], drawing rectangles"
ms.assetid: 54a7fa14-3ad8-4d64-b424-2a12005b250c
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Use a Pen to Draw Rectangles
To draw rectangles, you need a <xref:System.Drawing.Graphics> object and a <xref:System.Drawing.Pen> object. The <xref:System.Drawing.Graphics> object provides the <xref:System.Drawing.Graphics.DrawRectangle%2A> method, and the <xref:System.Drawing.Pen> object stores features of the line, such as color and width.  
  
## Example  
 The following example draws a rectangle with its upper-left corner at (10, 10). The rectangle has a width of 100 and a height of 50. The second argument passed to the <xref:System.Drawing.Pen.%23ctor%2A> constructor indicates that the pen width is 5 pixels.  
  
 When the rectangle is drawn, the pen is centered on the rectangle's boundary. Because the pen width is 5, the sides of the rectangle are drawn 5 pixels wide, such that 1 pixel is drawn on the boundary itself, 2 pixels are drawn on the inside, and 2 pixels are drawn on the outside. For more details on pen alignment, see [How to: Set Pen Width and Alignment](../../../../docs/framework/winforms/advanced/how-to-set-pen-width-and-alignment.md).  
  
 The following illustration shows the resulting rectangle. The dotted lines show where the rectangle would have been drawn if the pen width had been one pixel. The enlarged view of the upper-left corner of the rectangle shows that the thick black lines are centered on those dotted lines.  
  
 ![Pens](../../../../docs/framework/winforms/advanced/media/pens1.gif "pens1")  
  
 [!code-csharp[System.Drawing.UsingAPen#21](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.UsingAPen/CS/Class1.cs#21)]
 [!code-vb[System.Drawing.UsingAPen#21](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.UsingAPen/VB/Class1.vb#21)]  
  
## Compiling the Code  
 The preceding example is designed for use with Windows Forms, and it requires <xref:System.Windows.Forms.PaintEventArgs>`e`, which is a parameter of the <xref:System.Windows.Forms.Control.Paint> event handler.  
  
## See Also  
 [Using a Pen to Draw Lines and Shapes](../../../../docs/framework/winforms/advanced/using-a-pen-to-draw-lines-and-shapes.md)
