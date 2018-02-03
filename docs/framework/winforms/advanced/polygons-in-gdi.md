---
title: "Polygons in GDI+"
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
  - "polygons"
  - "drawing [Windows Forms], polygons"
  - "GDI+, polygons"
ms.assetid: a72213d2-d69a-4c2b-a75c-be7b20390c13
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Polygons in GDI+
A polygon is a closed shape with three or more straight sides. For example, a triangle is a polygon with three sides, a rectangle is a polygon with four sides, and a pentagon is a polygon with five sides. The following illustration shows several polygons.  
  
 ![Polygons](../../../../docs/framework/winforms/advanced/media/aboutgdip02-art07.gif "Aboutgdip02_art07")  
  
## Drawing a Polygon  
 To draw a polygon, you need a <xref:System.Drawing.Graphics> object, a <xref:System.Drawing.Pen> object, and an array of <xref:System.Drawing.Point> (or <xref:System.Drawing.PointF>) objects. The <xref:System.Drawing.Graphics> object provides the <xref:System.Drawing.Graphics.DrawPolygon%2A> method. The <xref:System.Drawing.Pen> object stores attributes, such as width and color, of the line used to render the polygon, and the array of <xref:System.Drawing.Point> objects stores the points to be connected by straight lines. The <xref:System.Drawing.Pen> object and the array of <xref:System.Drawing.Point> objects are passed as arguments to the <xref:System.Drawing.Graphics.DrawPolygon%2A> method. The following example draws a three-sided polygon. Note that there are only three points in `myPointArray`: (0, 0), (50, 30), and (30, 60). The <xref:System.Drawing.Graphics.DrawPolygon%2A> method automatically closes the polygon by drawing a line from (30, 60) back to the starting point (0, 0).  
  
 [!code-csharp[LinesCurvesAndShapes#111](../../../../samples/snippets/csharp/VS_Snippets_Winforms/LinesCurvesAndShapes/CS/Class1.cs#111)]
 [!code-vb[LinesCurvesAndShapes#111](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/LinesCurvesAndShapes/VB/Class1.vb#111)]  
  
 The following illustration shows the polygon.  
  
 ![Polygon](../../../../docs/framework/winforms/advanced/media/aboutgdip02-art08.gif "Aboutgdip02_art08")  
  
## See Also  
 <xref:System.Drawing.Graphics?displayProperty=nameWithType>  
 <xref:System.Drawing.Pen?displayProperty=nameWithType>  
 [Lines, Curves, and Shapes](../../../../docs/framework/winforms/advanced/lines-curves-and-shapes.md)  
 [How to: Create a Pen](../../../../docs/framework/winforms/advanced/how-to-create-a-pen.md)
