---
title: "Constructing and Drawing Curves"
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
  - "drawing [Windows Forms], curves"
  - "examples [Windows Forms], drawing curves"
  - "curves [Windows Forms], drawing"
ms.assetid: 76e92623-4130-4644-b867-faca58bdb3a2
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Constructing and Drawing Curves
[!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] supports several types of curves: ellipses, arcs, cardinal splines, and Bézier splines. An ellipse is defined by its bounding rectangle; an arc is a portion of an ellipse defined by a starting angle and a sweep angle. A cardinal spline is defined by an array of points and a tension parameter — the curve passes smoothly through each point in the array, and the tension parameter influences the way the curve bends. A Bézier spline is defined by two endpoints and two control points  the curve does not pass through the control points, but the control points influence the direction and bend as the curve goes from one endpoint to the other.  
  
## In This Section  
 [How to: Draw Cardinal Splines](../../../../docs/framework/winforms/advanced/how-to-draw-cardinal-splines.md)  
 Describes cardinal splines and how to draw them.  
  
 [How to: Draw a Single Bézier Spline](../../../../docs/framework/winforms/advanced/how-to-draw-a-single-bezier-spline.md)  
 Describes a Bézier spline and how to draw one.  
  
 [How to: Draw a Sequence of Bézier Splines](../../../../docs/framework/winforms/advanced/how-to-draw-a-sequence-of-bezier-splines.md)  
 Explains how to draw several Bézier splines in sequence.
