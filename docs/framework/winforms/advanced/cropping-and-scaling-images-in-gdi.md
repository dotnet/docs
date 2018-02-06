---
title: "Cropping and Scaling Images in GDI+"
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
  - "GDI+, scaling images"
  - "GDI+, cropping images"
  - "images [Windows Forms], cropping"
  - "compressing data [Windows Forms], images"
  - "images [Windows Forms], expansion"
  - "images [Windows Forms], scaling"
  - "rectangles [Windows Forms], source"
  - "rectangles [Windows Forms], destination"
  - "images [Windows Forms], compression"
ms.assetid: ad5daf26-005f-45bc-a2af-e0e97777a21a
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Cropping and Scaling Images in GDI+
You can use the <xref:System.Drawing.Graphics.DrawImage%2A> method of the <xref:System.Drawing.Graphics> class to draw and position vector images and raster images. <xref:System.Drawing.Graphics.DrawImage%2A> is an overloaded method, so there are several ways you can supply it with arguments.  
  
## DrawImage Variations  
 One variation of the <xref:System.Drawing.Graphics.DrawImage%2A> method receives a <xref:System.Drawing.Bitmap> and a <xref:System.Drawing.Rectangle>. The rectangle specifies the destination for the drawing operation; that is, it specifies the rectangle in which to draw the image. If the size of the destination rectangle is different from the size of the original image, the image is scaled to fit the destination rectangle. The following code example shows how to draw the same image three times: once with no scaling, once with an expansion, and once with a compression:  
  
 [!code-csharp[System.Drawing.ImagesBitmapsMetafiles#31](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.ImagesBitmapsMetafiles/CS/Class1.cs#31)]
 [!code-vb[System.Drawing.ImagesBitmapsMetafiles#31](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.ImagesBitmapsMetafiles/VB/Class1.vb#31)]  
  
 The following illustration shows the three pictures.  
  
 ![Scaling](../../../../docs/framework/winforms/advanced/media/aboutgdip03-art06.gif "AboutGdip03_Art06")  
  
 Some variations of the <xref:System.Drawing.Graphics.DrawImage%2A> method have a source-rectangle parameter as well as a destination-rectangle parameter. The source-rectangle parameter specifies the portion of the original image to draw. The destination rectangle specifies the rectangle in which to draw that portion of the image. If the size of the destination rectangle is different from the size of the source rectangle, the picture is scaled to fit the destination rectangle.  
  
 The following code example shows how to construct a <xref:System.Drawing.Bitmap> from the file Runner.jpg. The entire image is drawn with no scaling at (0, 0). Then a small portion of the image is drawn twice: once with a compression and once with an expansion.  
  
 [!code-csharp[System.Drawing.ImagesBitmapsMetafiles#32](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.ImagesBitmapsMetafiles/CS/Class1.cs#32)]
 [!code-vb[System.Drawing.ImagesBitmapsMetafiles#32](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.ImagesBitmapsMetafiles/VB/Class1.vb#32)]  
  
 The following illustration shows the unscaled image, and the compressed and expanded image portions.  
  
 ![Cropping and Scaling](../../../../docs/framework/winforms/advanced/media/aboutgdip03-art07.gif "AboutGdip03_Art07")  
  
## See Also  
 [Images, Bitmaps, and Metafiles](../../../../docs/framework/winforms/advanced/images-bitmaps-and-metafiles.md)  
 [Working with Images, Bitmaps, Icons, and Metafiles](../../../../docs/framework/winforms/advanced/working-with-images-bitmaps-icons-and-metafiles.md)
