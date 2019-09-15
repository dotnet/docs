---
title: "Using Fonts and Text"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "GDI [Windows Forms], drawing text [Windows Forms]"
  - "text [Windows Forms], drawing in Windows Forms"
  - "examples [Windows Forms], fonts and text"
  - "fonts [Windows Forms], using in Windows Forms"
  - "strings [Windows Forms], drawing in Windows Forms"
ms.assetid: d43640f3-da94-4df2-a29d-a9d021a1c069
---
# Using Fonts and Text
There are several classes offered by GDI+ and GDI for drawing text on Windows Forms. The GDI+ <xref:System.Drawing.Graphics> class has several <xref:System.Drawing.Graphics.DrawString%2A> methods that allow you to specify various features of text, such as location, bounding rectangle, font, and format. In addition, you can draw and measure text with GDI using the static <xref:System.Windows.Forms.TextRenderer.DrawText%2A> and <xref:System.Windows.Forms.TextRenderer.MeasureText%2A> methods offered by the `TextRenderer` class. The GDI methods also allow you to specify location, font, and format. You can choose either GDI or GDI+ for text rendering; however, GDI generally offers better performance and more accurate text measuring. Other classes that contribute to text rendering include `FontFamily`, `Font`, <xref:System.Drawing.StringFormat>, and `TextFormatFlags`.  
  
## In This Section  
 [How to: Construct Font Families and Fonts](how-to-construct-font-families-and-fonts.md)  
 Shows how to create `Font` and `FontFamily` objects.  
  
 [How to: Draw Text at a Specified Location](how-to-draw-text-at-a-specified-location.md)  
 Describes how to draw text in a certain location using GDI+ and GDI.  
  
 [How to: Draw Wrapped Text in a Rectangle](how-to-draw-wrapped-text-in-a-rectangle.md)  
 Explains how to draw text in a rectangle using GDI+ and GDI.  
  
 [How to: Draw Text with GDI](how-to-draw-text-with-gdi.md)  
 Demonstrates how to use GDI for drawing text.  
  
 [How to: Align Drawn Text](how-to-align-drawn-text.md)  
 Shows how to format GDI+ and GDI text.  
  
 [How to: Create Vertical Text](how-to-create-vertical-text.md)  
 Describes how to draw vertically aligned text with GDI+.  
  
 [How to: Set Tab Stops in Drawn Text](how-to-set-tab-stops-in-drawn-text.md)  
 Shows how draw text with tab stops with GDI+.  
  
 [How to: Enumerate Installed Fonts](how-to-enumerate-installed-fonts.md)  
 Explains how to list the names of installed fonts.  
  
 [How to: Create a Private Font Collection](how-to-create-a-private-font-collection.md)  
 Describes how to create a <xref:System.Drawing.Text.PrivateFontCollection> object.  
  
 [How to: Obtain Font Metrics](how-to-obtain-font-metrics.md)  
 Shows how to obtain font metrics such as cell ascent and descent.  
  
 [How to: Use Antialiasing with Text](how-to-use-antialiasing-with-text.md)  
 Explains how to use antialiasing when drawing text.  
  
## Reference  
 <xref:System.Drawing.Font>  
 Describes this class and contains links to all of its members.  
  
 <xref:System.Drawing.FontFamily>  
 Describes this class and contains links to all of its members.  
  
 <xref:System.Drawing.Text.PrivateFontCollection>  
 Describes this class and contains links to all of its members.  
  
 <xref:System.Windows.Forms.TextRenderer>  
 Describes this class and contains links to all of its members.  
  
 <xref:System.Windows.Forms.TextFormatFlags>  
 Describes this class and contains links to all of its members.
