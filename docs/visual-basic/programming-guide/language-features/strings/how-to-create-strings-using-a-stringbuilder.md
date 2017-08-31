---
title: "How to: Create Strings Using a StringBuilder in Visual Basic | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "StringBuilder class"
  - "strings [Visual Basic], using StringBuilder"
ms.assetid: 9c042880-aa16-432e-9ccb-cd00abda9ae3
caps.latest.revision: 9
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# How to: Create Strings Using a StringBuilder in Visual Basic
[!INCLUDE[vs2017banner](../../../../includes/vs2017banner.md)]

This example constructs a long string from many smaller strings using the <xref:System.Text.StringBuilder> class. The <xref:System.Text.StringBuilder> class is more efficient than the `&=` operator for concatenating many strings.  
  
## Example  
 The following example creates an instance of the <xref:System.Text.StringBuilder> class, appends 1,000 strings to that instance, and then returns its string representation.  
  
 [!code-vb[VbVbalrStrings#70](../../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStrings/VB/Class2.vb#70)]  
  
## See Also  
 [Using the StringBuilder Class](../Topic/Using%20the%20StringBuilder%20Class%20in%20the%20.NET%20Framework.md)   
 [&= Operator](../../../../visual-basic/language-reference/operators/and-assignment-operator.md)   
 [Strings](../../../../visual-basic/programming-guide/language-features/strings/index.md)   
 [Creating New Strings](../Topic/Creating%20New%20Strings%20in%20the%20.NET%20Framework.md)   
 [Manipulating Strings](../Topic/Manipulating%20Strings%20in%20the%20.NET%20Framework.md)   
 [Strings Sample](http://msdn.microsoft.com/en-us/be9e82a3-dc95-4aaa-9396-61b66e467e02)