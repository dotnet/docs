---
description: "Learn more about: Call Statement (Visual Basic)"
title: "Call Statement"
ms.date: 07/20/2015
f1_keywords:
  - "vb.Call"
helpviewer_keywords:
  - "procedures [Visual Basic], Call statement"
  - "Call statement [Visual Basic]"
  - "procedures [Visual Basic], calling"
ms.assetid: e5b31571-6867-406f-b8e7-a3f9aae4723a
---
# Call Statement (Visual Basic)

Transfers control to a `Function`, `Sub`, or dynamic-link library (DLL) procedure.  
  
## Syntax  
  
```vb  
[ Call ] procedureName [ (argumentList) ]  
```  
  
## Parts  

| Part | Description |
|---|---|
|`procedureName`|Required. Name of the procedure to call.|
|`argumentList`|Optional. List of variables or expressions representing arguments that are passed to the procedure when it is called. Multiple arguments are separated by commas. If you include `argumentList`, you must enclose it in parentheses.|
  
## Remarks

 You can use the `Call` keyword when you call a procedure. For most procedure calls, you aren’t required to use this  keyword.

 You typically use the `Call` keyword when the called expression doesn’t start with an identifier. Use of the `Call` keyword for other uses isn't recommended.

 If the procedure returns a value, the `Call` statement discards it.

## Example

 The following code shows two examples where the `Call` keyword is necessary to call a procedure. In both examples, the called expression doesn't start with an identifier.

 [!code-vb[VbVbalrStatements#97](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#97)]  
  
## See also

- [Function Statement](function-statement.md)
- [Sub Statement](sub-statement.md)
- [Declare Statement](declare-statement.md)
- [Lambda Expressions](../../programming-guide/language-features/procedures/lambda-expressions.md)
