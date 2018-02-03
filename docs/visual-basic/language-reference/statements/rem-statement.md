---
title: "REM Statement (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.'"
  - "vb.Rem"
  - "Rem"
  - "'"
helpviewer_keywords: 
  - "REM statement [Visual Basic]"
  - "comments, Visual Basic code"
  - "code comments, Visual Basic"
  - "Visual Basic code, comments"
  - "' comment marker character [Visual Basic]"
ms.assetid: 34126d7f-e0f9-476d-91e6-b31b398615dc
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# REM Statement (Visual Basic)
Used to include explanatory remarks in the source code of a program.  
  
## Syntax  
  
```  
REM comment  
' comment  
```  
  
## Parts  
 `comment`  
 Optional. The text of any comment you want to include. A space is required between the `REM` keyword and `comment`.  
  
## Remarks  
 You can put a `REM` statement alone on a line, or you can put it on a line following another statement. The `REM` statement must be the last statement on the line. If it follows another statement, the `REM` must be separated from that statement by a space.  
  
 You can use a single quotation mark (`'`) instead of `REM`. This is true whether your comment follows another statement on the same line or sits alone on a line.  
  
> [!NOTE]
>  You cannot continue a `REM` statement by using a line-continuation sequence (`_`). Once a comment begins, the compiler does not examine the characters for special meaning. For a multiple-line comment, use another `REM` statement or a comment symbol (`'`) on each line.  
  
## Example  
 The following example illustrates the `REM` statement, which is used to include explanatory remarks in a program. It also shows the alternative of using the single quotation-mark character (`'`) instead of `REM`.  
  
 [!code-vb[VbVbalrStatements#6](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/rem-statement_1.vb)]  
  
## See Also  
 [Comments in Code](../../../visual-basic/programming-guide/program-structure/comments-in-code.md)  
 [How to: Break and Combine Statements in Code](../../../visual-basic/programming-guide/program-structure/how-to-break-and-combine-statements-in-code.md)
