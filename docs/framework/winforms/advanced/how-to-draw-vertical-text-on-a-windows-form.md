---
title: "How to: Draw Vertical Text on a Windows Form"
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
  - "cpp"
f1_keywords: 
  - "StringFormat.FormatFlags"
  - "Graphics.DrawString"
helpviewer_keywords: 
  - "text [Windows Forms], drawing vertical"
  - "strings [Windows Forms], drawing vertical"
  - "text [Windows Forms], drawing"
  - "text [Windows Forms], vertical text"
ms.assetid: 717a6131-00f6-4373-b574-9894e8317799
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Draw Vertical Text on a Windows Form
The following code example shows how to draw vertical text on a form by using the <xref:System.Drawing.Graphics.DrawString%2A> method of <xref:System.Drawing.Graphics>.  
  
## Example  
 [!code-cpp[System.Drawing.ConceptualHowTos#8](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/cpp/form1.cpp#8)]
 [!code-csharp[System.Drawing.ConceptualHowTos#8](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/CS/form1.cs#8)]
 [!code-vb[System.Drawing.ConceptualHowTos#8](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/VB/form1.vb#8)]  
  
## Compiling the Code  
 You cannot call this method in the <xref:System.Windows.Forms.Form.Load> event handler. The drawn content will not be redrawn if the form is resized or obscured by another form. To make your content automatically repaint, you should override the <xref:System.Windows.Forms.Control.OnPaint%2A> method.  
  
## Robust Programming  
 The following conditions may cause an exception:  
  
-   The Arial font is not installed.  
  
## See Also  
 <xref:System.Drawing.Graphics.DrawString%2A>  
 <xref:System.Drawing.StringFormat.FormatFlags%2A>  
 <xref:System.Drawing.StringFormatFlags>  
 <xref:System.Windows.Forms.Control.OnPaint%2A>  
 [Getting Started with Graphics Programming](../../../../docs/framework/winforms/advanced/getting-started-with-graphics-programming.md)  
 [Using Fonts and Text](../../../../docs/framework/winforms/advanced/using-fonts-and-text.md)
