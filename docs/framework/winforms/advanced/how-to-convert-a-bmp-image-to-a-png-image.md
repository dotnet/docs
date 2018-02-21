---
title: "How to: Convert a BMP image to a PNG image"
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
  - "BMP images [Windows Forms], converting to PNG"
  - "image formats [Windows Forms], converting between"
ms.assetid: 9d4a692d-73ac-4ce3-9e05-9ec321e8fbd6
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Convert a BMP image to a PNG image
Oftentimes, you will want to convert from one image file format to another. You can do this conversion easily by calling the <xref:System.Drawing.Image.Save%2A> method of the <xref:System.Drawing.Image> class and specifying the <xref:System.Drawing.Imaging.ImageFormat> for the desired image file format.  
  
## Example  
 The following example loads a BMP image from a type, and saves the image in the PNG format.  
  
 [!code-csharp[UsingImageEncodersDecoders#4](../../../../samples/snippets/csharp/VS_Snippets_Winforms/UsingImageEncodersDecoders/CS/Form1.cs#4)]
 [!code-vb[UsingImageEncodersDecoders#4](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/UsingImageEncodersDecoders/VB/Form1.vb#4)]  
  
## Compiling the Code  
 This example requires:  
  
-   A Windows Forms application.  
  
-   A reference to the `System.Drawing.Imaging` namespace.  
  
## See Also  
 [How to: List Installed Encoders](../../../../docs/framework/winforms/advanced/how-to-list-installed-encoders.md)  
 [Using Image Encoders and Decoders in Managed GDI+](../../../../docs/framework/winforms/advanced/using-image-encoders-and-decoders-in-managed-gdi.md)  
 [Types of Bitmaps](../../../../docs/framework/winforms/advanced/types-of-bitmaps.md)
