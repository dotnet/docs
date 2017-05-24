---
title: "Cannot infer a data type for &#39;&lt;variablename&gt;&#39; because the array dimensions do not match | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "bc36909"
  - "vbc36909"
helpviewer_keywords: 
  - "BC36909"
ms.assetid: e41fec81-efec-4395-a0a5-d81906a2d4f1
caps.latest.revision: 5
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Cannot infer a data type for &#39;&lt;variablename&gt;&#39; because the array dimensions do not match
If the dimensions used to initialize an array do not match the dimensions in the declaration, the compiler cannot infer a data type for the array. For example, the following code causes this error.  
  
```vb  
' Valid. exampleArray1 is a one-dimensional array of integers.  
Dim exampleArray1() = New Integer() {1, 2, 3}  
' Not valid.  
'Dim exampleArray2(,) = New Integer() {1, 2, 3}  
'Dim exampleArray3(,) = New Integer() {}  
```  
  
 **Error ID:** BC36909  
  
## See Also  
 [Local Type Inference](../../visual-basic/programming-guide/language-features/variables/local-type-inference.md)   
 [NOTINBUILD How to: Initialize a Multidimensional Array](http://msdn.microsoft.com/en-us/502dcf8b-d86c-46f1-ad7d-3ce809645774)