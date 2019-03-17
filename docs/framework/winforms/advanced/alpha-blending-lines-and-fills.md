---
title: "Alpha Blending Lines and Fills"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "lines [Windows Forms], adding transparency"
  - "examples [Windows Forms], alpha blending"
  - "alpha blending [Windows Forms], using with lines"
  - "alpha blending"
  - "lines [Windows Forms], alpha blending"
  - "fills [Windows Forms], alpha blending"
  - "alpha blending [Windows Forms], using with fills"
  - "shapes [Windows Forms], adding transparency"
ms.assetid: 5440f48c-3ac9-44c3-b170-c1c110bdbab8
---
# Alpha Blending Lines and Fills
In [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)], a color is a 32-bit value with 8 bits each for alpha, red, green, and blue. The alpha value indicates the transparency of the color — the extent to which the color is blended with the background color. Alpha values range from 0 through 255, where 0 represents a fully transparent color, and 255 represents a fully opaque color.  
  
 Alpha blending is a pixel-by-pixel blending of source and background color data. Each of the three components (red, green, blue) of a given source color is blended with the corresponding component of the background color according to the following formula:  
  
 displayColor = sourceColor × alpha / 255 + backgroundColor × (255 – alpha) / 255  
  
 For example, suppose the red component of the source color is 150 and the red component of the background color is 100. If the alpha value is 200, the red component of the resultant color is calculated as follows:  
  
 150 × 200 / 255 + 100 × (255 – 200) / 255 = 139  
  
## In This Section  
 [How to: Draw Opaque and Semitransparent Lines](how-to-draw-opaque-and-semitransparent-lines.md)  
 Shows how to draw alpha-blended lines.  
  
 [How to: Draw with Opaque and Semitransparent Brushes](how-to-draw-with-opaque-and-semitransparent-brushes.md)  
 Explains how to alpha-blend with brushes.  
  
 [How to: Use Compositing Mode to Control Alpha Blending](how-to-use-compositing-mode-to-control-alpha-blending.md)  
 Describes how to control alpha blending using <xref:System.Drawing.Drawing2D.CompositingMode>.  
  
 [How to: Use a Color Matrix to Set Alpha Values in Images](how-to-use-a-color-matrix-to-set-alpha-values-in-images.md)  
 Explains how to use a <xref:System.Drawing.Imaging.ColorMatrix> object to control alpha blending.
