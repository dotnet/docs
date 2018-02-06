---
title: "Open and Closed Curves in GDI+"
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
  - "curves [Windows Forms], filling"
  - "GDI+, curves"
  - "curves [Windows Forms], drawing"
  - "curves"
ms.assetid: 08d2cc9a-dc9d-4eed-bcbb-2c8e2ca5d3ae
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Open and Closed Curves in GDI+
The following illustration shows two curves: one open and one closed.  
  
 ![Open & Closed curves](../../../../docs/framework/winforms/advanced/media/aboutgdip02-art24.gif "Aboutgdip02_art24")  
  
## Managed Interface for Curves  
 Closed curves have an interior and therefore can be filled with a brush. The <xref:System.Drawing.Graphics> class in [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] provides the following methods for filling closed shapes and curves: <xref:System.Drawing.Graphics.FillRectangle%2A>, <xref:System.Drawing.Graphics.FillEllipse%2A>, <xref:System.Drawing.Graphics.FillPie%2A>, <xref:System.Drawing.Graphics.FillPolygon%2A>, <xref:System.Drawing.Graphics.FillClosedCurve%2A>, <xref:System.Drawing.Graphics.FillPath%2A>, and <xref:System.Drawing.Graphics.FillRegion%2A>. Whenever you call one of these methods, you must pass one of the specific brush types (<xref:System.Drawing.SolidBrush>, <xref:System.Drawing.Drawing2D.HatchBrush>, <xref:System.Drawing.TextureBrush>, <xref:System.Drawing.Drawing2D.LinearGradientBrush>, or <xref:System.Drawing.Drawing2D.PathGradientBrush>) as an argument.  
  
 The <xref:System.Drawing.Graphics.FillPie%2A> method is a companion to the <xref:System.Drawing.Graphics.DrawArc%2A> method. Just as the <xref:System.Drawing.Graphics.DrawArc%2A> method draws a portion of the outline of an ellipse, the <xref:System.Drawing.Graphics.FillPie%2A> method fills a portion of the interior of an ellipse. The following example draws an arc and fills the corresponding portion of the interior of the ellipse:  
  
 [!code-csharp[LinesCurvesAndShapes#21](../../../../samples/snippets/csharp/VS_Snippets_Winforms/LinesCurvesAndShapes/CS/Class1.cs#21)]
 [!code-vb[LinesCurvesAndShapes#21](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/LinesCurvesAndShapes/VB/Class1.vb#21)]  
  
 The following illustration shows the arc and the filled pie.  
  
 ![Open & Closed curves](../../../../docs/framework/winforms/advanced/media/aboutgdip02-art25.gif "Aboutgdip02_art25")  
  
 The <xref:System.Drawing.Graphics.FillClosedCurve%2A> method is a companion to the <xref:System.Drawing.Graphics.DrawClosedCurve%2A> method. Both methods automatically close the curve by connecting the ending point to the starting point. The following example draws a curve that passes through (0, 0), (60, 20), and (40, 50). Then, the curve is automatically closed by connecting (40, 50) to the starting point (0, 0), and the interior is filled with a solid color.  
  
 [!code-csharp[LinesCurvesAndShapes#22](../../../../samples/snippets/csharp/VS_Snippets_Winforms/LinesCurvesAndShapes/CS/Class1.cs#22)]
 [!code-vb[LinesCurvesAndShapes#22](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/LinesCurvesAndShapes/VB/Class1.vb#22)]  
  
 The <xref:System.Drawing.Graphics.FillPath%2A> method fills the interiors of the separate pieces of a path. If a piece of a path doesn't form a closed curve or shape, the <xref:System.Drawing.Graphics.FillPath%2A> method automatically closes that piece of the path before filling it. The following example draws and fills a path that consists of an arc, a cardinal spline, a string, and a pie:  
  
 [!code-csharp[LinesCurvesAndShapes#23](../../../../samples/snippets/csharp/VS_Snippets_Winforms/LinesCurvesAndShapes/CS/Class1.cs#23)]
 [!code-vb[LinesCurvesAndShapes#23](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/LinesCurvesAndShapes/VB/Class1.vb#23)]  
  
 The following illustration shows the path with and without the solid fill. Note that the text in the string is outlined, but not filled, by the <xref:System.Drawing.Graphics.DrawPath%2A> method. It is the <xref:System.Drawing.Graphics.FillPath%2A> method that paints the interiors of the characters in the string.  
  
 ![String in a path](../../../../docs/framework/winforms/advanced/media/aboutgdip02-art26.gif "Aboutgdip02_art26")  
  
## See Also  
 <xref:System.Drawing.Drawing2D.GraphicsPath?displayProperty=nameWithType>  
 <xref:System.Drawing.Pen?displayProperty=nameWithType>  
 <xref:System.Drawing.Point?displayProperty=nameWithType>  
 [Lines, Curves, and Shapes](../../../../docs/framework/winforms/advanced/lines-curves-and-shapes.md)  
 [How to: Create Graphics Objects for Drawing](../../../../docs/framework/winforms/advanced/how-to-create-graphics-objects-for-drawing.md)  
 [Constructing and Drawing Paths](../../../../docs/framework/winforms/advanced/constructing-and-drawing-paths.md)
