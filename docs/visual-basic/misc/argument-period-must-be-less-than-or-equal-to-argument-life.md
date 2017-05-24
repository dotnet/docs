---
title: "Argument &#39;Period&#39; must be less than or equal to argument &#39;Life&#39; | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbrFinancial_PeriodLELife"
ms.assetid: dc575d41-b376-4b05-bbbe-6de1e98385f1
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
# Argument &#39;Period&#39; must be less than or equal to argument &#39;Life&#39;
The value of the `Period` argument, which specifies the period for which asset depreciation is calculated, is greater than the value of the `Life` argument.  
  
## To correct this error  
  
-   Ensure that the `Life` and `Period` arguments are expressed in the same units. For example, if `Life` is measured in months, `Period` should be as well.  
  
## See Also  
 [NOT IN BUILD: DDB Function](http://msdn.microsoft.com/en-us/c7cf8929-d158-4399-b3cb-31d897d12556)   
 [NOT IN BUILD: SYD Function](http://msdn.microsoft.com/en-us/23c25672-f5dd-49ac-9893-4faa82634181)   
 [Passing Arguments by Value and by Reference](../../visual-basic/programming-guide/language-features/procedures/passing-arguments-by-value-and-by-reference.md)