---
description: "Learn more about: Return Statement (Visual Basic)"
title: "Return Statement"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Return"
helpviewer_keywords: 
  - "Return statement [Visual Basic], syntax"
  - "control flow [Visual Basic], returning control to expressions"
  - "Return statement [Visual Basic]"
  - "expressions [Visual Basic], returning control to"
ms.assetid: ac86e7f0-5a67-42c3-9834-0e0381efa3ec
---
# Return Statement (Visual Basic)

Returns control to the code that called a `Function`, `Sub`, `Get`, `Set`, or `Operator` procedure.  
  
## Syntax  
  
```vb  
Return  
' -or-  
Return expression  
```  
  
## Part  

 `expression`  
 Required in a `Function`, `Get`, or `Operator` procedure. Expression that represents the value to be returned to the calling code.  
  
## Remarks  

 In a `Sub` or `Set` procedure, the `Return` statement is equivalent to an `Exit Sub` or `Exit Property` statement, and `expression` must not be supplied.  
  
 In a `Function`, `Get`, or `Operator` procedure, the `Return` statement must include `expression`, and `expression` must evaluate to a data type that is convertible to the return type of the procedure. In a `Function` or `Get` procedure, you also have the alternative of assigning an expression to the procedure name to serve as the return value, and then executing an `Exit Function` or `Exit Property` statement. In an `Operator` procedure, you must use `Return expression`.  
  
 You can include as many `Return` statements as appropriate in the same procedure.  
  
> [!NOTE]
> The code in a `Finally` block runs after a `Return` statement in a `Try` or `Catch` block is encountered, but before that `Return` statement executes. A `Return` statement cannot be included in a `Finally` block.  
  
## Example  

 The following example uses the `Return` statement several times to return to the calling code when the procedure does not have to do anything else.  
  
 [!code-vb[VbVbalrStatements#53](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#53)]  
  
## See also

- [Function Statement](function-statement.md)
- [Sub Statement](sub-statement.md)
- [Get Statement](get-statement.md)
- [Set Statement](set-statement.md)
- [Operator Statement](operator-statement.md)
- [Property Statement](property-statement.md)
- [Exit Statement](exit-statement.md)
- [Try...Catch...Finally Statement](try-catch-finally-statement.md)
