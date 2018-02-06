---
title: "How to: Use Hit Testing with a Region"
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
  - "hit tests [Windows Forms], using regions"
  - "regions [Windows Forms], hit testing"
ms.assetid: 3a4c07cb-a40a-4d14-ad35-008f531910a8
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Use Hit Testing with a Region
The purpose of hit testing is to determine whether the cursor is over a given object, such as an icon or a button.  
  
## Example  
 The following example creates a plus-shaped region by forming the union of two rectangular regions. Assume that the variable `point` holds the location of the most recent click. The code checks to see whether `point` is in the plus-shaped region. If the point is in the region (a hit), the region is filled with an opaque red brush. Otherwise, the region is filled with a semitransparent red brush.  
  
 [!code-csharp[System.Drawing.MiscLegacyTopics#31](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/CS/Class1.cs#31)]
 [!code-vb[System.Drawing.MiscLegacyTopics#31](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/VB/Class1.vb#31)]  
  
## Compiling the Code  
 The preceding example is designed for use with Windows Forms, and it requires <xref:System.Windows.Forms.PaintEventArgs> `e`, which is a parameter of <xref:System.Windows.Forms.PaintEventHandler>.  
  
## See Also  
 <xref:System.Drawing.Region>  
 [Regions in GDI+](../../../../docs/framework/winforms/advanced/regions-in-gdi.md)  
 [How to: Use Clipping with a Region](../../../../docs/framework/winforms/advanced/how-to-use-clipping-with-a-region.md)
