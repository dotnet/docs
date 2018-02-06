---
title: "How to: Fill a Shape with an Image Texture"
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
  - "images [Windows Forms], using with brushes"
  - "bitmaps [Windows Forms], using texture"
  - "shapes [Windows Forms], filling with images"
ms.assetid: 508da5a6-2433-4d2b-9680-eaeae4e96e3b
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Fill a Shape with an Image Texture
You can fill a closed shape with a texture by using the <xref:System.Drawing.Image> class and the <xref:System.Drawing.TextureBrush> class.  
  
## Example  
 The following example fills an ellipse with an image. The code constructs an <xref:System.Drawing.Image> object, and then passes the address of that <xref:System.Drawing.Image> object as an argument to a <xref:System.Drawing.TextureBrush.%23ctor%2A> constructor. The third statement scales the image, and the fourth statement fills the ellipse with repeated copies of the scaled image.  
  
 In the following code, the <xref:System.Drawing.TextureBrush.Transform%2A> property contains the transformation that is applied to the image before it is drawn. Assume that the original image has a width of 640 pixels and a height of 480 pixels. The transform shrinks the image to 75×75 by setting the horizontal and vertical scaling values.  
  
> [!NOTE]
>  In the following example, the image size is 75×75, and the ellipse size is 150×250. Because the image is smaller than the ellipse it is filling, the ellipse is tiled with the image. Tiling means that the image is repeated horizontally and vertically until the boundary of the shape is reached. For more information about tiling, see [How to: Tile a Shape with an Image](../../../../docs/framework/winforms/advanced/how-to-tile-a-shape-with-an-image.md).  
  
 [!code-csharp[System.Drawing.UsingABrush#21](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.UsingABrush/CS/Class1.cs#21)]
 [!code-vb[System.Drawing.UsingABrush#21](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.UsingABrush/VB/Class1.vb#21)]  
  
## Compiling the Code  
 The preceding example is designed for use with Windows Forms, and it requires <xref:System.Windows.Forms.PaintEventArgs> `e`, which is a parameter of the <xref:System.Windows.Forms.Control.Paint> event handler.  
  
## See Also  
 [Using a Brush to Fill Shapes](../../../../docs/framework/winforms/advanced/using-a-brush-to-fill-shapes.md)
