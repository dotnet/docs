---
title: "How to: Draw Text with GDI"
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
  - "GDI [Windows Forms], drawing text [Windows Forms]"
  - "text [Windows Forms], drawing with TextRenderer"
  - "drawing [Windows Forms], text"
  - "Windows Forms, drawing text with GDI"
ms.assetid: 2a19fe5d-2ace-451c-94db-01cb1118ef7b
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Draw Text with GDI
With the <xref:System.Windows.Forms.TextRenderer.DrawText%2A> method in the <xref:System.Windows.Forms.TextRenderer> class, you can access [!INCLUDE[ndptecgdi](../../../../includes/ndptecgdi-md.md)] functionality for drawing text on a form or control. [!INCLUDE[ndptecgdi](../../../../includes/ndptecgdi-md.md)] text rendering typically offers better performance and more accurate text measuring than [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)].  
  
> [!NOTE]
>  The <xref:System.Windows.Forms.TextRenderer.DrawText%2A> methods of the <xref:System.Windows.Forms.TextRenderer> class are not supported for printing. When printing, always use the <xref:System.Drawing.Graphics.DrawString%2A> methods of the <xref:System.Drawing.Graphics> class.  
  
## Example  
 The following code example demonstrates how to draw text on multiple lines within a rectangle using the <xref:System.Windows.Forms.TextRenderer.DrawText%2A> method.  
  
 [!code-csharp[System.Windows.Forms.TextRendererExamples#7](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.TextRendererExamples/CS/Form1.cs#7)]
 [!code-vb[System.Windows.Forms.TextRendererExamples#7](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.TextRendererExamples/VB/Form1.vb#7)]  
  
 To render text with the <xref:System.Windows.Forms.TextRenderer> class, you need an <xref:System.Drawing.IDeviceContext>, such as a <xref:System.Drawing.Graphics> and a <xref:System.Drawing.Font>, a location to draw the text, and the color in which it should be drawn. Optionally, you can specify the text formatting by using the <xref:System.Windows.Forms.TextFormatFlags> enumeration.  
  
 For more information about obtaining a <xref:System.Drawing.Graphics>, see [How to: Create Graphics Objects for Drawing](../../../../docs/framework/winforms/advanced/how-to-create-graphics-objects-for-drawing.md). For more information about constructing a <xref:System.Drawing.Font>, see [How to: Construct Font Families and Fonts](../../../../docs/framework/winforms/advanced/how-to-construct-font-families-and-fonts.md).  
  
## Compiling the Code  
 The preceding code example is designed for use with Windows Forms, and it requires the <xref:System.Windows.Forms.PaintEventArgs>`e`, which is a parameter of <xref:System.Windows.Forms.PaintEventHandler>.  
  
## See Also  
 <xref:System.Windows.Forms.TextRenderer>  
 <xref:System.Drawing.Font>  
 <xref:System.Drawing.Color>  
 <xref:System.Drawing.Color>  
 [Using Fonts and Text](../../../../docs/framework/winforms/advanced/using-fonts-and-text.md)
