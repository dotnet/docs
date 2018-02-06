---
title: "How to: Create a Pen"
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
helpviewer_keywords: 
  - "graphics [Windows Forms], creating pens"
  - "pens [Windows Forms], creating"
  - "Pen object"
ms.assetid: 7fbea8b7-7ac1-4413-9c17-733a850381e3
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create a Pen
This example creates a <xref:System.Drawing.Pen> object.  
  
## Example  
 [!code-cpp[System.Drawing.ConceptualHowTos#3](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/cpp/form1.cpp#3)]
 [!code-csharp[System.Drawing.ConceptualHowTos#3](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/CS/form1.cs#3)]
 [!code-vb[System.Drawing.ConceptualHowTos#3](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/VB/form1.vb#3)]  
  
## Robust Programming  
 After you have finished using objects that consume system resources, such as <xref:System.Drawing.Pen> objects, you should call <xref:System.Drawing.Pen.Dispose%2A> on them.  
  
## See Also  
 <xref:System.Drawing.Pen>  
 [Getting Started with Graphics Programming](../../../../docs/framework/winforms/advanced/getting-started-with-graphics-programming.md)  
 [Pens, Lines, and Rectangles in GDI+](../../../../docs/framework/winforms/advanced/pens-lines-and-rectangles-in-gdi.md)
