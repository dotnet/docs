---
title: "Cardinal Splines in GDI+"
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
  - "splines [Windows Forms], cardinal"
  - "GDI+, cardinal splines"
  - "cardinal splines"
ms.assetid: 09b3797a-6294-422d-9adf-a5a0a7695c0c
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Cardinal Splines in GDI+
A cardinal spline is a sequence of individual curves joined to form a larger curve. The spline is specified by an array of points and a tension parameter. A cardinal spline passes smoothly through each point in the array; there are no sharp corners and no abrupt changes in the tightness of the curve. The following illustration shows a set of points and a cardinal spline that passes through each point in the set.  
  
 ![Cardinal Spline](../../../../docs/framework/winforms/advanced/media/aboutgdip02-art09.gif "Aboutgdip02_art09")  
  
## Physical and Mathematical Splines  
 A physical spline is a thin piece of wood or other flexible material. Before the advent of mathematical splines, designers used physical splines to draw curves. A designer would place the spline on a piece of paper and anchor it to a given set of points. The designer could then create a curve by drawing along the spline with a pen or pencil. A given set of points could yield a variety of curves, depending on the properties of the physical spline. For example, a spline with a high resistance to bending would produce a different curve than an extremely flexible spline.  
  
 The formulas for mathematical splines are based on the properties of flexible rods, so the curves produced by mathematical splines are similar to the curves that were once produced by physical splines. Just as physical splines of different tension will produce different curves through a given set of points, mathematical splines with different values for the tension parameter will produce different curves through a given set of points. The following illustration shows four cardinal splines passing through the same set of points. The tension is shown for each spline. A tension of 0 corresponds to infinite physical tension, forcing the curve to take the shortest way (straight lines) between points. A tension of 1 corresponds to no physical tension, allowing the spline to take the path of least total bend. With tension values greater than 1, the curve behaves like a compressed spring, pushed to take a longer path.  
  
 ![Cardinal Splines](../../../../docs/framework/winforms/advanced/media/aboutgdip02-art10.gif "Aboutgdip02_art10")  
  
 The four splines in the preceding illustration share the same tangent line at the starting point. The tangent is the line drawn from the starting point to the next point along the curve. Likewise, the shared tangent at the ending point is the line drawn from the ending point to the previous point on the curve.  
  
 To draw a cardinal spline, you need an instance of the <xref:System.Drawing.Graphics> class, a <xref:System.Drawing.Pen>, and an array of <xref:System.Drawing.Point> objects The instance of the <xref:System.Drawing.Graphics> class provides the <xref:System.Drawing.Graphics.DrawCurve%2A> method, which draws the spline, and the <xref:System.Drawing.Pen> stores attributes of the spline, such as line width and color. The array of <xref:System.Drawing.Point> objects stores the points that the curve will pass through. The following code example shows how to draw a cardinal spline that passes through the points in `myPointArray`. The third parameter is the tension.  
  
 [!code-csharp[LinesCurvesAndShapes#31](../../../../samples/snippets/csharp/VS_Snippets_Winforms/LinesCurvesAndShapes/CS/Class1.cs#31)]
 [!code-vb[LinesCurvesAndShapes#31](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/LinesCurvesAndShapes/VB/Class1.vb#31)]  
  
## See Also  
 [Lines, Curves, and Shapes](../../../../docs/framework/winforms/advanced/lines-curves-and-shapes.md)  
 [Constructing and Drawing Curves](../../../../docs/framework/winforms/advanced/constructing-and-drawing-curves.md)
