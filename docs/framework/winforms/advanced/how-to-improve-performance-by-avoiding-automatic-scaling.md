---
title: "How to: Improve Performance by Avoiding Automatic Scaling"
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
  - "automatic scaling"
  - "images [Windows Forms], improving performance"
  - "images [Windows Forms], using without automatic scaling"
  - "performance [Windows Forms], improving image"
ms.assetid: 5fe2c95d-8653-4d55-bf0d-e5afa28f223b
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Improve Performance by Avoiding Automatic Scaling
[!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] may automatically scale an image as you draw it, which would decrease performance. Alternatively, you can control the scaling of the image by passing the dimensions of the destination rectangle to the <xref:System.Drawing.Graphics.DrawImage%2A> method.  
  
 For example, the following call to the <xref:System.Drawing.Graphics.DrawImage%2A> method specifies an upper-left corner of (50, 30) but does not specify a destination rectangle.  
  
 [!code-csharp[System.Drawing.WorkingWithImages#31](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.WorkingWithImages/CS/Class1.cs#31)]
 [!code-vb[System.Drawing.WorkingWithImages#31](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.WorkingWithImages/VB/Class1.vb#31)]  
  
 Although this is the easiest version of the <xref:System.Drawing.Graphics.DrawImage%2A> method in terms of the number of required arguments, it is not necessarily the most efficient. If the resolution used by [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] (usually 96 dots per inch) is different from the resolution stored in the <xref:System.Drawing.Image> object, then the <xref:System.Drawing.Graphics.DrawImage%2A> method will scale the image. For example, suppose an <xref:System.Drawing.Image> object has a width of 216 pixels and a stored horizontal resolution value of 72 dots per inch. Because 216/72 is 3, <xref:System.Drawing.Graphics.DrawImage%2A> will scale the image so that it has a width of 3 inches at a resolution of 96 dots per inch. That is, <xref:System.Drawing.Graphics.DrawImage%2A> will display an image that has a width of 96x3 = 288 pixels.  
  
 Even if your screen resolution is different from 96 dots per inch, [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] will probably scale the image as if the screen resolution were 96 dots per inch. That is because a [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] <xref:System.Drawing.Graphics> object is associated with a device context, and when [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] queries the device context for the screen resolution, the result is usually 96, regardless of the actual screen resolution. You can avoid automatic scaling by specifying the destination rectangle in the <xref:System.Drawing.Graphics.DrawImage%2A> method.  
  
## Example  
 The following example draws the same image twice. In the first case, the width and height of the destination rectangle are not specified, and the image is automatically scaled. In the second case, the width and height (measured in pixels) of the destination rectangle are specified to be the same as the width and height of the original image. The following illustration shows the image rendered twice.  
  
 ![Scaled Texture](../../../../docs/framework/winforms/advanced/media/csscaledtexture1.png "csscaledtexture1")  
  
 [!code-csharp[System.Drawing.WorkingWithImages#32](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.WorkingWithImages/CS/Class1.cs#32)]
 [!code-vb[System.Drawing.WorkingWithImages#32](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.WorkingWithImages/VB/Class1.vb#32)]  
  
## Compiling the Code  
 The preceding example is designed for use with Windows Forms, and it requires <xref:System.Windows.Forms.PaintEventArgs> `e`, which is a parameter of the <xref:System.Windows.Forms.Control.Paint> event handler. Replace Texture.jpg with an image name and path that are valid on your system.  
  
## See Also  
 [Images, Bitmaps, and Metafiles](../../../../docs/framework/winforms/advanced/images-bitmaps-and-metafiles.md)  
 [Working with Images, Bitmaps, Icons, and Metafiles](../../../../docs/framework/winforms/advanced/working-with-images-bitmaps-icons-and-metafiles.md)
