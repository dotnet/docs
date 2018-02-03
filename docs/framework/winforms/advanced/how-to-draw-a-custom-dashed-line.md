---
title: "How to: Draw a Custom Dashed Line"
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
  - "lines [Windows Forms], custom"
  - "lines [Windows Forms], drawing"
  - "lines [Windows Forms], dashed"
ms.assetid: cd0ed96a-cce4-47b9-b58a-3bae2e3d1bee
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Draw a Custom Dashed Line
[!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] provides several dash styles that are listed in the <xref:System.Drawing.Drawing2D.DashStyle> enumeration. If those standard dash styles do not suit your needs, you can create a custom dash pattern.  
  
## Example  
 To draw a custom dashed line, put the lengths of the dashes and spaces in an array and assign the array as the value of the <xref:System.Drawing.Pen.DashPattern%2A> property of a <xref:System.Drawing.Pen> object. The following example draws a custom dashed line based on the array `{5, 2, 15, 4}`. If you multiply the elements of the array by the pen width of 5, you get `{25, 10, 75, 20}`. The displayed dashes alternate in length between 25 and 75, and the spaces alternate in length between 10 and 20.  
  
 The following illustration shows the resulting dashed line. Note that the final dash has to be shorter than 25 units so that the line can end at (405, 5).  
  
 ![Pens](../../../../docs/framework/winforms/advanced/media/pens6.gif "pens6")  
  
 [!code-csharp[System.Drawing.UsingAPen#51](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.UsingAPen/CS/Class1.cs#51)]
 [!code-vb[System.Drawing.UsingAPen#51](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.UsingAPen/VB/Class1.vb#51)]  
  
## Compiling the Code  
 Create a Windows Form and handle the form's <xref:System.Windows.Forms.Control.Paint> event. Paste the preceding code into the <xref:System.Windows.Forms.Control.Paint> event handler.  
  
## See Also  
 [Using a Pen to Draw Lines and Shapes](../../../../docs/framework/winforms/advanced/using-a-pen-to-draw-lines-and-shapes.md)
