---
title: "How to: Convert Hexadecimal Strings to Numbers (Visual Basic) | Microsoft Docs"
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
  - "numbers, hexadecimals"
  - "hexadecimals, decimals"
  - "examples [Visual Basic], string conversion"
  - "decimals, hexadecimals"
  - "string conversion, hexadecimal to numbers"
ms.assetid: 76675807-eadb-4c08-bd50-e6c6ff4b8ced
caps.latest.revision: 9
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# How to: Convert Hexadecimal Strings to Numbers (Visual Basic)
[!INCLUDE[vs2017banner](../../../../includes/vs2017banner.md)]

This example converts a hexadecimal string to an integer using the <xref:System.Convert.ToInt32%2A> method.  
  
### To convert a hexadecimal string to a number  
  
-   Use the <xref:System.Convert.ToInt32%2A> method to convert the number expressed in base-16 to an integer.  
  
     The first argument of the <xref:System.Convert.ToInt32%2A> method is the string to convert. The second argument describes what base the number is expressed in; hexadecimal is base 16.  
  
     [!code-vb[VbVbalrStrings#62](../../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStrings/VB/Class2.vb#62)]  
  
## See Also  
 <xref:Microsoft.VisualBasic.Conversion.Hex%2A>   
 <xref:System.Convert.ToInt32%2A>