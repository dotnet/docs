---
title: "How to: Translate Image Colors"
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
  - "bitmaps [Windows Forms], changing colors"
  - "images [Windows Forms], changing colors"
  - "image colors [Windows Forms]"
ms.assetid: 2106fb9a-4d60-4dcf-9220-9f189a6c4d19
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Translate Image Colors
A translation adds a value to one or more of the four color components. The color matrix entries that represent translations are given in the following table.  
  
|Component to be translated|Matrix entry|  
|--------------------------------|------------------|  
|Red|[4][0]|  
|Green|[4][1]|  
|Blue|[4][2]|  
|Alpha|[4][3]|  
  
## Example  
 The following example constructs an <xref:System.Drawing.Image> object from the file ColorBars.bmp. Then the code adds 0.75 to the red component of each pixel in the image. The original image is drawn alongside the transformed image.  
  
 The following illustration shows the original image on the left and the transformed image on the right.  
  
 ![Translate Colors](../../../../docs/framework/winforms/advanced/media/colortrans2.png "colortrans2")  
  
 The following table lists the color vectors for the four bars before and after the red translation. Note that because the maximum value for a color component is 1, the red component in the second row does not change. (Similarly, the minimum value for a color component is 0.)  
  
|Original|Translated|  
|--------------|----------------|  
|Black (0, 0, 0, 1)|(0.75, 0, 0, 1)|  
|Red (1, 0, 0, 1)|(1, 0, 0, 1)|  
|Green (0, 1, 0, 1)|(0.75, 1, 0, 1)|  
|Blue (0, 0, 1, 1)|(0.75, 0, 1, 1)|  
  
 [!code-csharp[System.Drawing.RecoloringImages#11](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.RecoloringImages/CS/Class1.cs#11)]
 [!code-vb[System.Drawing.RecoloringImages#11](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.RecoloringImages/VB/Class1.vb#11)]  
  
## Compiling the Code  
 The preceding example is designed for use with Windows Forms, and it requires <xref:System.Windows.Forms.PaintEventArgs>`e`, which is a parameter of the <xref:System.Windows.Forms.Control.Paint> event handler. Replace `ColorBars.bmp` with an image file name and path that are valid on your system.  
  
## See Also  
 <xref:System.Drawing.Imaging.ColorMatrix>  
 <xref:System.Drawing.Imaging.ImageAttributes>  
 [Graphics and Drawing in Windows Forms](../../../../docs/framework/winforms/advanced/graphics-and-drawing-in-windows-forms.md)  
 [Recoloring Images](../../../../docs/framework/winforms/advanced/recoloring-images.md)
