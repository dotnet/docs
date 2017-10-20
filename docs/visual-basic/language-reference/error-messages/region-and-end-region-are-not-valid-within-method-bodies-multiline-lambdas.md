---
title: "&#39;#Region&#39; and &#39;#End Region&#39; statements are not valid within method bodies-multiline lambdas"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc32025"
  - "vbc32025"
helpviewer_keywords: 
  - "BC32025"
ms.assetid: 43707bf1-1c6b-4d82-b081-e5a17dca51c1
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# &#39;#Region&#39; and &#39;#End Region&#39; statements are not valid within method bodies/multiline lambdas
The `#Region` block must be declared at a class, module, or namespace level. A collapsible region can include one or more procedures, but it cannot begin or end inside of a procedure.  
  
 **Error ID:** BC32025  
  
## To correct this error  
  
1.  Ensure that the preceding procedure is properly terminated with an `End Function` or `End Sub` statement.  
  
2.  Ensure that the `#Region` and `#End Region` directives are in the same code block.  
  
## See Also  
 [#Region Directive](../../../visual-basic/language-reference/directives/region-directive.md)
