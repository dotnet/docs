---
title: "How to: Flatten a Curved Path into a Line"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "graphics [Windows Forms], flattening curves into lines"
  - "curves [Windows Forms], flattening"
  - "GraphicsPath object"
  - "paths [Windows Forms], flattening"
  - "drawing [Windows Forms], flattening curves"
ms.assetid: e654b8de-25f4-4735-9208-42e4514a589c
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Flatten a Curved Path into a Line
A <xref:System.Drawing.Drawing2D.GraphicsPath> object stores a sequence of lines and Bézier splines. You can add several types of curves (ellipses, arcs, cardinal splines) to a path, but each curve is converted to a Bézier spline before it is stored in the path. Flattening a path consists of converting each Bézier spline in the path to a sequence of straight lines. The following illustration shows a path before and after flattening.  
  
 ![Straight Lines and Curves](../../../../docs/framework/winforms/advanced/media/aboutgdip02-art32a.gif "AboutGdip02_Art32A")  
  
### To Flatten a Path  
  
-   call the <xref:System.Drawing.Drawing2D.GraphicsPath.Flatten%2A> method of a <xref:System.Drawing.Drawing2D.GraphicsPath> object. The <xref:System.Drawing.Drawing2D.GraphicsPath.Flatten%2A> method receives a flatness argument that specifies the maximum distance between the flattened path and the original path.  
  
## See Also  
 <xref:System.Drawing.Drawing2D.GraphicsPath?displayProperty=nameWithType>  
 [Lines, Curves, and Shapes](../../../../docs/framework/winforms/advanced/lines-curves-and-shapes.md)  
 [Constructing and Drawing Paths](../../../../docs/framework/winforms/advanced/constructing-and-drawing-paths.md)
