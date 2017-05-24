---
title: "&#39;&lt;typename&gt;&#39; values cannot be converted to &#39;Char&#39; | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "bc32007"
  - "vbc32007"
helpviewer_keywords: 
  - "BC32007"
ms.assetid: b04212da-57ac-4493-9480-04c12b50f875
caps.latest.revision: 8
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
# &#39;&lt;typename&gt;&#39; values cannot be converted to &#39;Char&#39;
'\<typename>' values cannot be converted to Char. Use Microsoft.VisualBasic.ChrW to interpret a numeric value as a Unicode character or first convert it to 'String' to produce a digit.  
  
 An expression attempts to convert a data type other than `String` or `Object` to `Char`.  
  
 **Error ID:** BC32007  
  
## To correct this error  
  
-   Use the `ChrW` function to convert a numeric value to a Unicode character, or first convert the value to `String` and then to `Char`.  
  
## See Also  
 [NOT IN BUILD: Chr, ChrW Functions](http://msdn.microsoft.com/en-us/37f3c707-8a6f-4c51-9b02-9e634c4299ab)   
 [Implicit and Explicit Conversions](../../visual-basic/programming-guide/language-features/data-types/implicit-and-explicit-conversions.md)   
 [Char Data Type](../../visual-basic/language-reference/data-types/char-data-type.md)