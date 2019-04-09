---
title: "How to: Shear Colors"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "colors [Windows Forms], transforming with color matrices"
  - "colors [Windows Forms], shearing"
ms.assetid: 0a424171-5b8b-45c4-afef-e9720a6c3e22
---
# How to: Shear Colors
Shearing increases or decreases a color component by an amount proportional to another color component. For example, consider the transformation where the red component is increased by one half the value of the blue component. Under such a transformation, the color (0.2, 0.5, 1) would become (0.7, 0.5, 1). The new red component is 0.2 + (1/2)(1) = 0.7.  
  
## Example  
 The following example constructs an <xref:System.Drawing.Image> object from the file ColorBars4.bmp. Then the code applies the shearing transformation described in the preceding paragraph to each pixel in the image.  
  
 The following illustration shows the original image on the left and the sheared image on the right: 
  
 ![Two squares with colored stripes side-by-side illustrating the original image and the sheared image.](./media/how-to-shear-colors/original-image-sheared-image.png)  
  
 The following table lists the color vectors for the four bars before and after the shearing transformation.  
  
|Original|Sheared|  
|--------------|-------------|  
|(0, 0, 1, 1)|(0.5, 0, 1, 1)|  
|(0.5, 1, 0.5, 1)|(0.75, 1, 0.5, 1)|  
|(1, 1, 0, 1)|(1, 1, 0, 1)|  
|(0.4, 0.4, 0.4, 1)|(0.6, 0.4, 0.4, 1)|  
  
 [!code-csharp[System.Drawing.Misc3#9](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.Misc3/CS/Form1.cs#9)]
 [!code-vb[System.Drawing.Misc3#9](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.Misc3/VB/Form1.vb#9)]  
  
## Compiling the Code  
 The preceding example is designed for use with Windows Forms, and it requires <xref:System.Windows.Forms.PaintEventArgs>`e`, which is a parameter of the <xref:System.Windows.Forms.Control.Paint> event handler. Replace `ColorBars.bmp` with an image name and path valid on your system.  
  
## See also

- <xref:System.Drawing.Imaging.ColorMatrix>
- <xref:System.Drawing.Imaging.ImageAttributes>
- [Graphics and Drawing in Windows Forms](graphics-and-drawing-in-windows-forms.md)
- [Recoloring Images](recoloring-images.md)
