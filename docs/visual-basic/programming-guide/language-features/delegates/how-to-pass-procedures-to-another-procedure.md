---
title: "How to: Pass Procedures to Another Procedure in Visual Basic"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "AddressOf operator [Visual Basic]"
  - "delegates [Visual Basic], passing procedures"
ms.assetid: 5adbba15-5a1d-413f-ab3e-3ff6cc0a4669
---
# How to: Pass Procedures to Another Procedure in Visual Basic
This example shows how to use delegates to pass a procedure to another procedure.  
  
 A delegate is a type that you can use like any other type in Visual Basic. The `AddressOf` operator returns a delegate object when applied to a procedure name.  
  
 This example has a procedure with a delegate parameter that can take a reference to another procedure, obtained with the `AddressOf` operator.  
  
### Create the delegate and matching procedures  
  
1.  Create a delegate named `MathOperator`.  
  
     [!code-vb[VbVbalrDelegates#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDelegates/VB/Class1.vb#1)]  
  
2.  Create a procedure named `AddNumbers` with parameters and return value that match those of `MathOperator`, so that the signatures match.  
  
     [!code-vb[VbVbalrDelegates#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDelegates/VB/Class1.vb#2)]  
  
3.  Create a procedure named `SubtractNumbers` with a signature that matches `MathOperator`.  
  
     [!code-vb[VbVbalrDelegates#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDelegates/VB/Class1.vb#3)]  
  
4.  Create a procedure named `DelegateTest` that takes a delegate as a parameter.  
  
     This procedure can accept a reference to `AddNumbers` or `SubtractNumbers`, because their signatures match the `MathOperator` signature.  
  
     [!code-vb[VbVbalrDelegates#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDelegates/VB/Class1.vb#4)]  
  
5.  Create a procedure named `Test` that calls `DelegateTest` once with the delegate for `AddNumbers` as a parameter, and again with the delegate for `SubtractNumbers` as a parameter.  
  
     [!code-vb[VbVbalrDelegates#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDelegates/VB/Class1.vb#5)]  
  
     When `Test` is called, it first displays the result of `AddNumbers` acting on `5` and `3`, which is 8. Then the result of `SubtractNumbers` acting on `9` and `3` is displayed, which is 6.  
  
## See also

- [Delegates](../../../../visual-basic/programming-guide/language-features/delegates/index.md)
- [AddressOf Operator](../../../../visual-basic/language-reference/operators/addressof-operator.md)
- [Delegate Statement](../../../../visual-basic/language-reference/statements/delegate-statement.md)
- [How to: Invoke a Delegate Method](../../../../visual-basic/programming-guide/language-features/delegates/how-to-invoke-a-delegate-method.md)
