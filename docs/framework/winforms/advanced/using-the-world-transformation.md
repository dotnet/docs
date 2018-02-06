---
title: "Using the World Transformation"
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
  - "graphics [Windows Forms], world transformation"
  - "world transformation [Windows Forms], examples"
ms.assetid: 1e717711-1361-448e-aa49-0f3ec43110c9
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Using the World Transformation
The world transformation is a property of the <xref:System.Drawing.Graphics> class. The numbers that specify the world transformation are stored in a <xref:System.Drawing.Drawing2D.Matrix> object, which represents a 3×3 matrix. The <xref:System.Drawing.Drawing2D.Matrix> and <xref:System.Drawing.Graphics> classes have several methods for setting the numbers in the world transformation matrix.  
  
## Different Types of Transformations  
 In the following example, the code first creates a 50×50 rectangle and locates it at the origin (0, 0). The origin is at the upper-left corner of the client area.  
  
 [!code-csharp[System.Drawing.MiscLegacyTopics#11](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/CS/Class1.cs#11)]
 [!code-vb[System.Drawing.MiscLegacyTopics#11](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/VB/Class1.vb#11)]  
  
 The following code applies a scaling transformation that expands the rectangle by a factor of 1.75 in the x direction and shrinks the rectangle by a factor of 0.5 in the y direction:  
  
 [!code-csharp[System.Drawing.MiscLegacyTopics#12](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/CS/Class1.cs#12)]
 [!code-vb[System.Drawing.MiscLegacyTopics#12](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/VB/Class1.vb#12)]  
  
 The result is a rectangle that is longer in the x direction and shorter in the y direction than the original.  
  
 To rotate the rectangle instead of scaling it, use the following code:  
  
 [!code-csharp[System.Drawing.MiscLegacyTopics#13](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/CS/Class1.cs#13)]
 [!code-vb[System.Drawing.MiscLegacyTopics#13](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/VB/Class1.vb#13)]  
  
 To translate the rectangle, use the following code:  
  
 [!code-csharp[System.Drawing.MiscLegacyTopics#14](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/CS/Class1.cs#14)]
 [!code-vb[System.Drawing.MiscLegacyTopics#14](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/VB/Class1.vb#14)]  
  
## See Also  
 <xref:System.Drawing.Drawing2D.Matrix>  
 [Coordinate Systems and Transformations](../../../../docs/framework/winforms/advanced/coordinate-systems-and-transformations.md)  
 [Using Transformations in Managed GDI+](../../../../docs/framework/winforms/advanced/using-transformations-in-managed-gdi.md)
