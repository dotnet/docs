---
title: "How to: Convert Hexadecimal Strings to Numbers (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "numbers [Visual Basic], hexadecimals"
  - "hexadecimals [Visual Basic], decimals"
  - "examples [Visual Basic], string conversion"
  - "decimals [Visual Basic], hexadecimals"
  - "string conversion [Visual Basic], hexadecimal to numbers"
ms.assetid: 76675807-eadb-4c08-bd50-e6c6ff4b8ced
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Convert Hexadecimal Strings to Numbers (Visual Basic)
This example converts a hexadecimal string to an integer using the <xref:System.Convert.ToInt32%2A> method.  
  
### To convert a hexadecimal string to a number  
  
-   Use the <xref:System.Convert.ToInt32%2A> method to convert the number expressed in base-16 to an integer.  
  
     The first argument of the <xref:System.Convert.ToInt32%2A> method is the string to convert. The second argument describes what base the number is expressed in; hexadecimal is base 16.  
  
     [!code-vb[VbVbalrStrings#62](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/how-to-convert-hexadecimal-strings-to-numbers_1.vb)]  
  
## See Also  
 <xref:Microsoft.VisualBasic.Conversion.Hex%2A>  
 <xref:System.Convert.ToInt32%2A>
