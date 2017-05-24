---
title: "Attribute constructor has a &#39;ByRef&#39; parameter of type &#39;&lt;typename&gt;&#39;; cannot use constructors with byref parameters to apply the attribute | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "bc36006"
  - "vbc36006"
helpviewer_keywords: 
  - "BC36006"
ms.assetid: 4c4e991f-3839-4196-bcfb-eb8464aa55e5
caps.latest.revision: 9
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
# Attribute constructor has a &#39;ByRef&#39; parameter of type &#39;&lt;typename&gt;&#39;; cannot use constructors with byref parameters to apply the attribute
An attribute is applied to a programming element using an attribute constructor that takes a `ByRef` parameter.  
  
 Attributes are applied at compile time, and the compiler needs concrete values to pass to the attribute constructor. A `ByRef` parameter takes a pointer to a value, which cannot be evaluated at compile time.  
  
 You can define an attribute constructor that takes a `ByRef` parameter, and you can use it for purposes such as inheriting, but when you apply the attribute you must use a constructor that does not take any `ByRef` parameters.  
  
 **Error ID:** BC36006  
  
## To correct this error  
  
-   Apply the attribute using a constructor that does not take any `ByRef` parameters, or do not apply the attribute at all.  
  
## See Also  
 [NOT IN BUILD: Attributes Overview in Visual Basic](http://msdn.microsoft.com/en-us/0d0cff64-892d-4f57-83bd-bef388553d4f)   
 [NOT IN BUILD: Application of Attributes](http://msdn.microsoft.com/en-us/2b1703ed-4437-49b3-bc0b-568094324f47)   
 [Passing Arguments by Value and by Reference](../../visual-basic/programming-guide/language-features/procedures/passing-arguments-by-value-and-by-reference.md)   
 [ByRef](../../visual-basic/language-reference/modifiers/byref.md)