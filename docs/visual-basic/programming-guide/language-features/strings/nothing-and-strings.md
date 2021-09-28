---
description: "Learn more about: Nothing and Strings in Visual Basic"
title: "Nothing and Strings"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "strings [Visual Basic], Nothing"
ms.assetid: 261380af-2024-4ecf-823b-43b1034d92cd
---
# Nothing and Strings in Visual Basic

The Visual Basic runtime and the .NET Framework evaluate `Nothing` differently when it comes to strings.  
  
## Visual Basic Runtime and the .NET Framework  

 Consider the following example:  
  
 [!code-vb[VbVbalrStrings#47](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStrings/VB/Class2.vb#47)]  
  
 The Visual Basic runtime usually evaluates `Nothing` as an empty string (""). The .NET Framework does not, however, and throws an exception whenever an attempt is made to perform a string operation on `Nothing`.  
  
## See also

- [Introduction to Strings in Visual Basic](introduction-to-strings.md)
