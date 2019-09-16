---
title: "How to: Draw Text at a Specified Location"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "text [Windows Forms], drawing at specified locations [Windows Forms]"
  - "drawing text"
  - "drawing text [Windows Forms], specified locations [Windows Forms]"
  - "Windows Forms, drawing text at a specified location"
ms.assetid: 60816423-1c38-465e-980d-2c2b64d74086
---
# How to: Draw Text at a Specified Location
When you perform custom drawing, you can draw text in a single horizontal line starting at a specified point. You can draw text in this manner by using the <xref:System.Drawing.Graphics.DrawString%2A> overloaded method of the <xref:System.Drawing.Graphics> class that takes a <xref:System.Drawing.Point> or <xref:System.Drawing.PointF> parameter. The <xref:System.Drawing.Graphics.DrawString%2A> method also requires a <xref:System.Drawing.Brush> and <xref:System.Drawing.Font>  
  
 You can also use the <xref:System.Windows.Forms.TextRenderer.DrawText%2A> overloaded method of the <xref:System.Windows.Forms.TextRenderer> that takes a <xref:System.Drawing.Point>. <xref:System.Windows.Forms.TextRenderer.DrawText%2A> also requires a <xref:System.Drawing.Color> and a <xref:System.Drawing.Font>.  
  
 The following illustration shows the output of text drawn at a specified point when you use the <xref:System.Drawing.Graphics.DrawString%2A> overloaded method.  
  
 ![Screenshot that shows the output of text at a specified point.](./media/how-to-draw-text-at-a-specified-location/font-text-specified-point.png)  
  
### To draw a line of text with GDI+  
  
1. Use the <xref:System.Drawing.Graphics.DrawString%2A> method, passing the text you want, <xref:System.Drawing.Point> or <xref:System.Drawing.PointF>, <xref:System.Drawing.Font>, and <xref:System.Drawing.Brush>.  
  
     [!code-csharp[System.Drawing.AlignDrawnText#30](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.AlignDrawnText/CS/Form1.cs#30)]
     [!code-vb[System.Drawing.AlignDrawnText#30](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.AlignDrawnText/VB/Form1.vb#30)]  
  
### To draw a line of text with GDI  
  
1. Use the <xref:System.Windows.Forms.TextRenderer.DrawText%2A> method, passing the text you want, <xref:System.Drawing.Point>, <xref:System.Drawing.Font>, and <xref:System.Drawing.Color>.  
  
     [!code-csharp[System.Drawing.AlignDrawnText#40](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.AlignDrawnText/CS/Form1.cs#40)]
     [!code-vb[System.Drawing.AlignDrawnText#40](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.AlignDrawnText/VB/Form1.vb#40)]  
  
## Compiling the Code  
 The previous examples require:  
  
- <xref:System.Windows.Forms.PaintEventArgs>  `e`, which is a parameter of <xref:System.Windows.Forms.PaintEventHandler>.  
  
## See also

- [How to: Draw Text with GDI](how-to-draw-text-with-gdi.md)
- [Using Fonts and Text](using-fonts-and-text.md)
- [How to: Construct Font Families and Fonts](how-to-construct-font-families-and-fonts.md)
- [How to: Draw Wrapped Text in a Rectangle](how-to-draw-wrapped-text-in-a-rectangle.md)
