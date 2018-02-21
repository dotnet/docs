---
title: "Using Transformations to Scale Colors"
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
  - "transformations [Windows Forms], for scaling colors"
  - "colors [Windows Forms], scaling"
ms.assetid: df23c887-7fd6-4b15-ad94-e30b5bd4b849
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Using Transformations to Scale Colors
A scaling transformation multiplies one or more of the four color components by a number. The color matrix entries that represent scaling are given in the following table.  
  
|Component to be scaled|Matrix entry|  
|----------------------------|------------------|  
|Red|[0][0]|  
|Green|[1][1]|  
|Blue|[2][2]|  
|Alpha|[3][3]|  
  
## Scaling One Color  
 The following example constructs an <xref:System.Drawing.Image> object from the file ColorBars2.bmp. Then the code scales the blue component of each pixel in the image by a factor of 2. The original image is drawn alongside the transformed image.  
  
 [!code-csharp[System.Drawing.RecoloringImages#41](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.RecoloringImages/CS/Class1.cs#41)]
 [!code-vb[System.Drawing.RecoloringImages#41](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.RecoloringImages/VB/Class1.vb#41)]  
  
 The following illustration shows the original image on the left and the scaled image on the right.  
  
 ![Scale Colors](../../../../docs/framework/winforms/advanced/media/colortrans3.png "colortrans3")  
  
 The following table lists the color vectors for the four bars before and after the blue scaling. Note that the blue component in the fourth color bar went from 0.8 to 0.6. That is because [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] retains only the fractional part of the result. For example, (2)(0.8) = 1.6, and the fractional part of 1.6 is 0.6. Retaining only the fractional part ensures that the result is always in the interval [0, 1].  
  
|Original|Scaled|  
|--------------|------------|  
|(0.4, 0.4, 0.4, 1)|(0.4, 0.4, 0.8, 1)|  
|(0.4, 0.2, 0.2, 1)|(0.4, 0.2, 0.4, 1)|  
|(0.2, 0.4, 0.2, 1)|(0.2, 0.4, 0.4, 1)|  
|(0.4, 0.4, 0.8, 1)|(0.4, 0.4, 0.6, 1)|  
  
## Scaling Multiple Colors  
 The following example constructs an <xref:System.Drawing.Image> object from the file ColorBars2.bmp. Then the code scales the red, green, and blue components of each pixel in the image. The red components are scaled down 25 percent, the green components are scaled down 35 percent, and the blue components are scaled down 50 percent.  
  
 [!code-csharp[System.Drawing.RecoloringImages#42](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.RecoloringImages/CS/Class1.cs#42)]
 [!code-vb[System.Drawing.RecoloringImages#42](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.RecoloringImages/VB/Class1.vb#42)]  
  
 The following illustration shows the original image on the left and the scaled image on the right.  
  
 ![Scale Colors](../../../../docs/framework/winforms/advanced/media/colortrans4.png "colortrans4")  
  
 The following table lists the color vectors for the four bars before and after the red, green and blue scaling.  
  
|Original|Scaled|  
|--------------|------------|  
|(0.6, 0.6, 0.6, 1)|(0.45, 0.39, 0.3, 1)|  
|(0, 1, 1, 1)|(0, 0.65, 0.5, 1)|  
|(1, 1, 0, 1)|(0.75, 0.65, 0, 1)|  
|(1, 0, 1, 1)|(0.75, 0, 0.5, 1)|  
  
## See Also  
 <xref:System.Drawing.Imaging.ColorMatrix>  
 <xref:System.Drawing.Imaging.ImageAttributes>  
 [Graphics and Drawing in Windows Forms](../../../../docs/framework/winforms/advanced/graphics-and-drawing-in-windows-forms.md)  
 [Recoloring Images](../../../../docs/framework/winforms/advanced/recoloring-images.md)
