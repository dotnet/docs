---
title: "Using a Gradient Brush to Fill Shapes"
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
  - "brushes [Windows Forms], gradient brushes"
  - "gradient brushes"
  - "examples [Windows Forms], gradient brushes"
ms.assetid: 2c6037b9-05bd-44c0-a22a-19584b722524
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Using a Gradient Brush to Fill Shapes
You can use a gradient brush to fill a shape with a gradually changing color. For example, you can use a horizontal gradient to fill a shape with color that changes gradually as you move from the left edge of the shape to the right edge. Imagine a rectangle with a left edge that is black (represented by red, green, and blue components 0, 0, 0) and a right edge that is red (represented by 255, 0, 0). If the rectangle is 256 pixels wide, the red component of a given pixel will be one greater than the red component of the pixel to its left. The leftmost pixel in a row has color components (0, 0, 0), the second pixel has (1, 0, 0), the third pixel has (2, 0, 0), and so on, until you get to the rightmost pixel, which has color components (255, 0, 0). These interpolated color values make up the color gradient.  
  
 A linear gradient changes color as you move horizontally, vertically, or parallel to a specified slanted line. A path gradient changes color as you move about the interior and boundary of a path. You can customize path gradients to achieve a wide variety of effects.  
  
 The following illustration shows a rectangle filled with a linear gradient brush and an ellipse filled with a path gradient brush.  
  
 ![Gradient](../../../../docs/framework/winforms/advanced/media/gradient2.png "gradient2")  
  
## In This Section  
 [How to: Create a Linear Gradient](../../../../docs/framework/winforms/advanced/how-to-create-a-linear-gradient.md)  
 Shows how to create a linear gradient using the <xref:System.Drawing.Drawing2D.LinearGradientBrush> class.  
  
 [How to: Create a Path Gradient](../../../../docs/framework/winforms/advanced/how-to-create-a-path-gradient.md)  
 Describes how to create a path gradient using the <xref:System.Drawing.Drawing2D.PathGradientBrush> class.  
  
 [How to: Apply Gamma Correction to a Gradient](../../../../docs/framework/winforms/advanced/how-to-apply-gamma-correction-to-a-gradient.md)  
 Explains how to use gamma correction with a gradient brush.  
  
## Reference  
 <xref:System.Drawing.Drawing2D.LinearGradientBrush?displayProperty=nameWithType>  
 Contains a description of this class and has links to all of its members.  
  
 <xref:System.Drawing.Drawing2D.PathGradientBrush?displayProperty=nameWithType>  
 Contains a description of this class and has links to all of its members.
