---
title: "AddressOf Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "AddressOf"
  - "vb.AddressOf"
helpviewer_keywords: 
  - "AddressOf operator [Visual Basic]"
  - "addresses, passing to API procedures"
ms.assetid: 8105a59d-60d8-4ab5-b221-5899cdfacbf4
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# AddressOf Operator (Visual Basic)
Creates a procedure delegate instance that references the specific procedure.  
  
## Syntax  
  
```  
AddressOf procedurename  
```  
  
## Parts  
 `procedurename`  
 Required. Specifies the procedure to be referenced by the newly created procedure delegate.  
  
## Remarks  
 The `AddressOf` operator creates a function delegate that points to the function specified by `procedurename`. When the specified procedure is an instance method then the function delegate refers to both the instance and the method. Then, when the function delegate is invoked the specified method of the specified instance is called.  
  
 The `AddressOf` operator can be used as the operand of a delegate constructor or it can be used in a context in which the type of the delegate can be determined by the compiler.  
  
## Example  
 This example uses the `AddressOf` operator to designate a delegate to handle the `Click` event of a button.  
  
 [!code-vb[VbVbalrDelegates#8](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/addressof-operator_1.vb)]  
  
## Example  
 The following example uses the `AddressOf` operator to designate the startup function for a thread.  
  
 [!code-vb[VbVbalrDelegates#9](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/addressof-operator_2.vb)]  
  
## See Also  
 [Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md)  
 [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)  
 [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  
 [Delegates](../../../visual-basic/programming-guide/language-features/delegates/index.md)
