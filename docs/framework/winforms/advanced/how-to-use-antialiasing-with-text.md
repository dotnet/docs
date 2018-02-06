---
title: "How to: Use Antialiasing with Text"
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
  - "strings [Windows Forms], smoothing drawn"
  - "antialiasing [Windows Forms], using with text"
  - "text [Windows Forms], smoothing"
  - "text [Windows Forms], antialiasing"
  - "strings [Windows Forms], antialiasing when drawing"
ms.assetid: 48fc34f3-f236-4b01-a0cb-f0752e6d22ae
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Use Antialiasing with Text
*Antialiasing* refers to the smoothing of jagged edges of drawn graphics and text to improve their appearance or readability. With the managed [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] classes, you can render high quality antialiased text, as well as lower quality text. Typically, higher quality rendering takes more processing time than lower quality rendering. To set the text quality level, set the <xref:System.Drawing.Graphics.TextRenderingHint%2A> property of a <xref:System.Drawing.Graphics> to one of the elements of the <xref:System.Drawing.Text.TextRenderingHint> enumeration  
  
## Example  
 The following code example draws text with two different quality settings.  
  
 The following illustration shows the output of the cod example code.  
  
 ![Fonts Text](../../../../docs/framework/winforms/advanced/media/fontstext10.png "FontsText10")  
  
 [!code-csharp[System.Drawing.FontsAndText#21](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.FontsAndText/CS/Class1.cs#21)]
 [!code-vb[System.Drawing.FontsAndText#21](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.FontsAndText/VB/Class1.vb#21)]  
  
## Compiling the Code  
 The preceding code example is designed for use with Windows Forms, and it requires <xref:System.Windows.Forms.PaintEventArgs>`e`, which is a parameter of <xref:System.Windows.Forms.PaintEventHandler>.  
  
## See Also  
 [Using Fonts and Text](../../../../docs/framework/winforms/advanced/using-fonts-and-text.md)
