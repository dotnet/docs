---
title: "Range variable &lt;variable&gt; hides a variable in an enclosing block, a previously defined range variable, or an implicitly declared variable in a query expression"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc36633"
  - "vbc36633"
helpviewer_keywords: 
  - "BC36633"
ms.assetid: 5d5470e4-3de5-49c2-8831-1087625f4a77
caps.latest.revision: 5
author: dotnet-bot
ms.author: dotnetcontent
---
# Range variable &lt;variable&gt; hides a variable in an enclosing block, a previously defined range variable, or an implicitly declared variable in a query expression
A range variable name specified in a `Select`, `From`, `Aggregate`, or `Let` clause duplicates the name of a range variable already specified previously in the query, or the name of a variable that is implicitly declared by the query, such as a field name or the name of an aggregate function.  
  
 **Error ID:** BC36633  
  
## To correct this error  
  
-   Ensure that all range variables in a particular query scope have unique names. You can enclose a query in parentheses to ensure that nested queries have a unique scope.  
  
## See Also  
 [Introduction to LINQ in Visual Basic](../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)  
 [From Clause](../../../visual-basic/language-reference/queries/from-clause.md)  
 [Let Clause](../../../visual-basic/language-reference/queries/let-clause.md)  
 [Aggregate Clause](../../../visual-basic/language-reference/queries/aggregate-clause.md)  
 [Select Clause](../../../visual-basic/language-reference/queries/select-clause.md)
