---
title: "Using Fonts and Text"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "GDI [Windows Forms], drawing text [Windows Forms]"
  - "text [Windows Forms], drawing in Windows Forms"
  - "examples [Windows Forms], fonts and text"
  - "fonts [Windows Forms], using in Windows Forms"
  - "strings [Windows Forms], drawing in Windows Forms"
ms.assetid: d43640f3-da94-4df2-a29d-a9d021a1c069
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Using Fonts and Text
There are several classes offered by [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] and [!INCLUDE[ndptecgdi](../../../../includes/ndptecgdi-md.md)] for drawing text on Windows Forms. The [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] <xref:System.Drawing.Graphics> class has several <xref:System.Drawing.Graphics.DrawString%2A> methods that allow you to specify various features of text, such as location, bounding rectangle, font, and format. In addition, you can draw and measure text with [!INCLUDE[ndptecgdi](../../../../includes/ndptecgdi-md.md)] using the static <xref:System.Windows.Forms.TextRenderer.DrawText%2A> and <xref:System.Windows.Forms.TextRenderer.MeasureText%2A> methods offered by the `TextRenderer` class. The [!INCLUDE[ndptecgdi](../../../../includes/ndptecgdi-md.md)] methods also allow you to specify location, font, and format. You can choose either [!INCLUDE[ndptecgdi](../../../../includes/ndptecgdi-md.md)] or [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] for text rendering; however, [!INCLUDE[ndptecgdi](../../../../includes/ndptecgdi-md.md)] generally offers better performance and more accurate text measuring. Other classes that contribute to text rendering include `FontFamily`, `Font`, <xref:System.Drawing.StringFormat>, and `TextFormatFlags`.  
  
## In This Section  
 [How to: Construct Font Families and Fonts](../../../../docs/framework/winforms/advanced/how-to-construct-font-families-and-fonts.md)  
 Shows how to create `Font` and `FontFamily` objects.  
  
 [How to: Draw Text at a Specified Location](../../../../docs/framework/winforms/advanced/how-to-draw-text-at-a-specified-location.md)  
 Describes how to draw text in a certain location using [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] and [!INCLUDE[ndptecgdi](../../../../includes/ndptecgdi-md.md)].  
  
 [How to: Draw Wrapped Text in a Rectangle](../../../../docs/framework/winforms/advanced/how-to-draw-wrapped-text-in-a-rectangle.md)  
 Explains how to draw text in a rectangle using [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] and [!INCLUDE[ndptecgdi](../../../../includes/ndptecgdi-md.md)].  
  
 [How to: Draw Text with GDI](../../../../docs/framework/winforms/advanced/how-to-draw-text-with-gdi.md)  
 Demonstrates how to use [!INCLUDE[ndptecgdi](../../../../includes/ndptecgdi-md.md)] for drawing text.  
  
 [How to: Align Drawn Text](../../../../docs/framework/winforms/advanced/how-to-align-drawn-text.md)  
 Shows how to format [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] and [!INCLUDE[ndptecgdi](../../../../includes/ndptecgdi-md.md)] text.  
  
 [How to: Create Vertical Text](../../../../docs/framework/winforms/advanced/how-to-create-vertical-text.md)  
 Describes how to draw vertically aligned text with [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)].  
  
 [How to: Set Tab Stops in Drawn Text](../../../../docs/framework/winforms/advanced/how-to-set-tab-stops-in-drawn-text.md)  
 Shows how draw text with tab stops with [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)].  
  
 [How to: Enumerate Installed Fonts](../../../../docs/framework/winforms/advanced/how-to-enumerate-installed-fonts.md)  
 Explains how to list the names of installed fonts.  
  
 [How to: Create a Private Font Collection](../../../../docs/framework/winforms/advanced/how-to-create-a-private-font-collection.md)  
 Describes how to create a <xref:System.Drawing.Text.PrivateFontCollection> object.  
  
 [How to: Obtain Font Metrics](../../../../docs/framework/winforms/advanced/how-to-obtain-font-metrics.md)  
 Shows how to obtain font metrics such as cell ascent and descent.  
  
 [How to: Use Antialiasing with Text](../../../../docs/framework/winforms/advanced/how-to-use-antialiasing-with-text.md)  
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
