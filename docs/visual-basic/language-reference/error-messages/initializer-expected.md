---
title: "Initializer expected | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbc30996"
  - "bc30996"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30996"
ms.assetid: 6e183fe0-8888-43ed-a062-01571079455f
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Initializer expected
You have tried to declare an instance of a class by using an object initializer in which the initialization list is empty, as shown in the following example.  
  
 `' Not valid.`  
  
 `' Dim aStudent As New Student With {}`  
  
 At least one field or property must be initialized in the initializer list, as shown in the following example.  
  
 `Dim aStudent As New Student With {.year = "Senior"}`  
  
 **Error ID:** BC30996  
  
## To correct this error  
  
1.  Initialize at least one field or property in the initializer, or do not use an object initializer.  
  
## See Also  
 [Object Initializers: Named and Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/object-initializers-named-and-anonymous-types.md)   
 [How to: Declare an Object by Using an Object Initializer](../../../visual-basic/programming-guide/language-features/objects-and-classes/how-to-declare-an-object-by-using-an-object-initializer.md)