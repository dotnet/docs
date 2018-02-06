---
title: "&gt;&gt;= Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.>>="
helpviewer_keywords: 
  - "assignment statements [Visual Basic], compound"
  - "statements [Visual Basic], compound assignment"
  - "operator >>= [Visual Basic]"
  - "compound assignment statements [Visual Basic]"
  - ">>= operator [Visual Basic]"
ms.assetid: 2bcd9abb-7a8c-4229-b75d-8816ff1dc700
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# &gt;&gt;= Operator (Visual Basic)
Performs an arithmetic right shift on the value of a variable or property and assigns the result back to the variable or property.  
  
## Syntax  
  
```  
variableorproperty >>= amount  
```  
  
## Parts  
 `variableorproperty`  
 Required. Variable or property of an integral type (`SByte`, `Byte`, `Short`, `UShort`, `Integer`, `UInteger`, `Long`, or `ULong`).  
  
 `amount`  
 Required. Numeric expression of a data type that widens to `Integer`.  
  
## Remarks  
 The element on the left side of the `>>=` operator can be a simple scalar variable, a property, or an element of an array. The variable or property cannot be [ReadOnly](../../../visual-basic/language-reference/modifiers/readonly.md).  
  
 The `>>=` operator first performs an arithmetic right shift on the value of the variable or property. The operator then assigns the result of that operation back to the variable or property.  
  
 Arithmetic shifts are not circular, which means the bits shifted off one end of the result are not reintroduced at the other end. In an arithmetic right shift, the bits shifted beyond the rightmost bit position are discarded, and the leftmost bit is propagated into the bit positions vacated at the left. This means that if `variableorproperty` has a negative value, the vacated positions are set to one. If `variableorproperty` is positive, or if its data type is an unsigned type, the vacated positions are set to zero.  
  
## Overloading  
 The [>> Operator](../../../visual-basic/language-reference/operators/right-shift-operator.md) can be *overloaded*, which means that a class or structure can redefine its behavior when an operand has the type of that class or structure. Overloading the `>>` operator affects the behavior of the `>>=` operator. If your code uses `>>=` on a class or structure that overloads `>>`, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  
 The following example uses the `>>=` operator to shift the bit pattern of an `Integer` variable right by the specified amount and assign the result to the variable.  
  
 [!code-vb[VbVbalrOperators#15](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/right-shift-assignment-operator_1.vb)]  
  
## See Also  
 [>> Operator](../../../visual-basic/language-reference/operators/right-shift-operator.md)  
 [Assignment Operators](../../../visual-basic/language-reference/operators/assignment-operators.md)  
 [Bit Shift Operators](../../../visual-basic/language-reference/operators/bit-shift-operators.md)  
 [Operator Precedence in Visual Basic](../../../visual-basic/language-reference/operators/operator-precedence.md)  
 [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md)  
 [Statements](../../../visual-basic/programming-guide/language-features/statements.md)
