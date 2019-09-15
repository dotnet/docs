---
title: "Antialiasing with Lines and Curves"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "antialiasing"
  - "antialiasing [Windows Forms], smoothing modes"
  - "GDI+, antialiasing"
ms.assetid: 810da1a4-c136-4abf-88df-68e49efdd8d4
---
# Antialiasing with Lines and Curves
When you use GDI+ to draw a line, you provide the starting point and ending point of the line, but you do not have to provide any information about the individual pixels on the line. GDI+ works in conjunction with the display driver software to determine which pixels will be turned on to show the line on a particular display device.  
  
## Aliasing  
 Consider the straight red line that goes from the point (4, 2) to the point (16, 10). Assume the coordinate system has its origin in the upper-left corner and that the unit of measure is the pixel. Also assume that the x-axis points to the right and the y-axis points down. The following illustration shows an enlarged view of the red line drawn on a multicolored background.  
  
 ![Line, no antialiasing](./media/aboutgdip02-art33.gif "AboutGdip02_Art33")  
  
 The red pixels used to render the line are opaque. There are no partially transparent pixels in the line. This type of line rendering gives the line a jagged appearance, and the line looks somewhat like a staircase. This technique of representing a line with a staircase is called aliasing; the staircase is an alias for the theoretical line.  
  
## Antialiasing  
 A more sophisticated technique for rendering a line involves using partially transparent pixels along with opaque pixels. Pixels are set to pure red, or to some blend of red and the background color, depending on how close they are to the line. This type of rendering is called antialiasing and results in a line that the human eye perceives as more smooth. The following illustration shows how certain pixels are blended with the background to produce an antialiased line.  
  
 ![Antialiasing a Line](./media/aboutgdip02-art34.gif "AboutGdip02_Art34")  
  
 Antialiasing, also called smoothing, can also be applied to curves. The following illustration shows an enlarged view of a smoothed ellipse.  
  
 ![Antialiasing Curves](./media/aboutgdip02-art35.gif "AboutGdip02_Art35")  
  
 The following illustration shows the same ellipse in its actual size, once without antialiasing and once with antialiasing.  
  
 ![Antialiasing example](./media/aboutgdip02-art36.gif "AboutGdip02_Art36")  
  
 To draw lines and curves that use antialiasing, create an instance of the <xref:System.Drawing.Graphics> class and set its <xref:System.Drawing.Graphics.SmoothingMode%2A> property to <xref:System.Drawing.Drawing2D.SmoothingMode.AntiAlias> or <xref:System.Drawing.Drawing2D.SmoothingMode.HighQuality>. Then call one of the drawing methods of that same <xref:System.Drawing.Graphics> class.  
  
 [!code-csharp[LinesCurvesAndShapes#81](~/samples/snippets/csharp/VS_Snippets_Winforms/LinesCurvesAndShapes/CS/Class1.cs#81)]
 [!code-vb[LinesCurvesAndShapes#81](~/samples/snippets/visualbasic/VS_Snippets_Winforms/LinesCurvesAndShapes/VB/Class1.vb#81)]  
  
## See also

- <xref:System.Drawing.Drawing2D.SmoothingMode?displayProperty=nameWithType>
- [Lines, Curves, and Shapes](lines-curves-and-shapes.md)
- [How to: Use Antialiasing with Text](how-to-use-antialiasing-with-text.md)
