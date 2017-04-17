---
title: "How to: Sort An Array in Visual Basic | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "Array.Sort"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "arrays [Visual Basic], sorting"
  - "examples [Visual Basic], arrays"
ms.assetid: 9289aeaa-9626-4698-94a7-1d1fd3702b87
caps.latest.revision: 19
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
# How to: Sort An Array in Visual Basic
This example declares an array of `String` objects named `zooAnimals`, populates it, and then sorts it alphabetically.  
  
## Example  
  
```  
Private Sub sortAnimals()  
    Dim zooAnimals(2) As String  
    zooAnimals(0) = "lion"  
    zooAnimals(1) = "turtle"  
    zooAnimals(2) = "ostrich"  
    Array.Sort(zooAnimals)  
End Sub  
```  
  
## Compiling the Code  
 This example requires:  
  
-   Access to Mscorlib.dll and the <xref:System> namespace.  
  
## Robust Programming  
 The following conditions may cause an exception:  
  
-   Array is empty (<xref:System.ArgumentNullException> class)  
  
-   Array is multidimensional (<xref:System.RankException> class)  
  
-   One or more elements of the array do not implement the <xref:System.IComparable> interface (<xref:System.InvalidOperationException> class)  
  
## See Also  
 <xref:System.Array.Sort%2A?displayProperty=fullName>   
 [Arrays](../../../../visual-basic/programming-guide/language-features/arrays/index.md)   
 [Troubleshooting Arrays](../../../../visual-basic/programming-guide/language-features/arrays/troubleshooting-arrays.md)   
 [Collections](http://msdn.microsoft.com/library/e76533a9-5033-4a0b-b003-9c2be60d185b)   
 [For Each...Next Statement](../../../../visual-basic/language-reference/statements/for-each-next-statement.md)