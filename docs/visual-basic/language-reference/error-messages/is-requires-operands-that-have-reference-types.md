---
title: "&#39;Is&#39; requires operands that have reference types, but this operand has the value type &#39;&lt;typename&gt;&#39;"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc30020"
  - "vbc30020"
helpviewer_keywords: 
  - "BC30020"
ms.assetid: 228afebd-1203-4bd3-8d7a-c5c56f3cedc4
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# &#39;Is&#39; requires operands that have reference types, but this operand has the value type &#39;&lt;typename&gt;&#39;
The `Is` comparison operator determines whether two object variables refer to the same instance. This comparison is not defined for value types.  
  
 **Error ID:** BC30020  
  
## To correct this error  
  
-   Use the appropriate arithmetic comparison operator or the `Like` operator to compare two value types.  
  
## See Also  
 [Is Operator](../../../visual-basic/language-reference/operators/is-operator.md)  
 [Like Operator](../../../visual-basic/language-reference/operators/like-operator.md)  
 [Comparison Operators](../../../visual-basic/language-reference/operators/comparison-operators.md)
