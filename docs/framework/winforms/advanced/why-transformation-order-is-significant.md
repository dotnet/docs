---
title: "Why Transformation Order Is Significant"
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
  - "transformations [Windows Forms], order signficance"
ms.assetid: 37d5f9dc-a5cf-4475-aa5d-34d714e808a9
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Why Transformation Order Is Significant
A single <xref:System.Drawing.Drawing2D.Matrix> object can store a single transformation or a sequence of transformations. The latter is called a composite transformation. The matrix of a composite transformation is obtained by multiplying the matrices of individual transformations.  
  
## Composite Transform Examples  
 In a composite transformation, the order of individual transformations is important. For example, if you first rotate, then scale, then translate, you get a different result than if you first translate, then rotate, then scale. In [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)], composite transformations are built from left to right. If S, R, and T are scale, rotation, and translation matrices respectively, then the product SRT (in that order) is the matrix of the composite transformation that first scales, then rotates, then translates. The matrix produced by the product SRT is different from the matrix produced by the product TRS.  
  
 One reason order is significant is that transformations like rotation and scaling are done with respect to the origin of the coordinate system. Scaling an object that is centered at the origin produces a different result than scaling an object that has been moved away from the origin. Similarly, rotating an object that is centered at the origin produces a different result than rotating an object that has been moved away from the origin.  
  
 The following example combines scaling, rotation and translation (in that order) to form a composite transformation. The argument <xref:System.Drawing.Drawing2D.MatrixOrder.Append> passed to the <xref:System.Drawing.Graphics.RotateTransform%2A> method indicates that the rotation will follow the scaling. Likewise, the argument <xref:System.Drawing.Drawing2D.MatrixOrder.Append> passed to the <xref:System.Drawing.Graphics.TranslateTransform%2A> method indicates that the translation will follow the rotation. <xref:System.Drawing.Drawing2D.MatrixOrder.Append> and <xref:System.Drawing.Drawing2D.MatrixOrder.Prepend> are members of the <xref:System.Drawing.Drawing2D.MatrixOrder> enumeration.  
  
 [!code-csharp[System.Drawing.MiscLegacyTopics#21](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/CS/Class1.cs#21)]
 [!code-vb[System.Drawing.MiscLegacyTopics#21](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/VB/Class1.vb#21)]  
  
 The following example makes the same method calls as the preceding example, but the order of the calls is reversed. The resulting order of operations is first translate, then rotate, then scale, which produces a very different result than first scale, then rotate, then translate.  
  
 [!code-csharp[System.Drawing.MiscLegacyTopics#22](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/CS/Class1.cs#22)]
 [!code-vb[System.Drawing.MiscLegacyTopics#22](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/VB/Class1.vb#22)]  
  
 One way to reverse the order of individual transformations in a composite transformation is to reverse the order of a sequence of method calls. A second way to control the order of operations is to change the matrix order argument. The following example is the same as the preceding example, except that <xref:System.Drawing.Drawing2D.MatrixOrder.Append> has been changed to <xref:System.Drawing.Drawing2D.MatrixOrder.Prepend>. The matrix multiplication is done in the order SRT, where S, R, and T are the matrices for scale, rotate, and translate, respectively. The order of the composite transformation is first scale, then rotate, then translate.  
  
 [!code-csharp[System.Drawing.MiscLegacyTopics#23](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/CS/Class1.cs#23)]
 [!code-vb[System.Drawing.MiscLegacyTopics#23](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/VB/Class1.vb#23)]  
  
 The result of the immediately preceding example is the same as the result of the first example in this topic. This is because we reversed both the order of the method calls and the order of the matrix multiplication.  
  
## See Also  
 <xref:System.Drawing.Drawing2D.Matrix>  
 [Coordinate Systems and Transformations](../../../../docs/framework/winforms/advanced/coordinate-systems-and-transformations.md)  
 [Using Transformations in Managed GDI+](../../../../docs/framework/winforms/advanced/using-transformations-in-managed-gdi.md)
