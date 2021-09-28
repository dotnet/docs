---
description: "Learn more about: ^= Operator (Visual Basic)"
title: "^= Operator"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.^="
helpviewer_keywords: 
  - "assignment statements [Visual Basic], compound"
  - "statements [Visual Basic], compound assignment"
  - "^= operator [Visual Basic]"
  - "compound assignment statements [Visual Basic]"
ms.assetid: 397da132-2d96-4a85-a7bc-f7c730a608c9
---
# ^= Operator (Visual Basic)

Raises the value of a variable or property to the power of an expression and assigns the result back to the variable or property.  
  
## Syntax  
  
```vb  
variableorproperty ^= expression  
```  
  
## Parts  

 `variableorproperty`  
 Required. Any numeric variable or property.  
  
 `expression`  
 Required. Any numeric expression.  
  
## Remarks  

 The element on the left side of the `^=` operator can be a simple scalar variable, a property, or an element of an array. The variable or property cannot be [ReadOnly](../modifiers/readonly.md).  
  
 The `^=` operator first raises the value of the variable or property (on the left-hand side of the operator) to the power of the value of the expression (on the right-hand side of the operator). The operator then assigns the result of that operation back to the variable or property.  
  
 Visual Basic always performs exponentiation in the [Double Data Type](../data-types/double-data-type.md). Operands of any different type are converted to `Double`, and the result is always `Double`.  
  
 The value of `expression` can be fractional, negative, or both.  
  
## Overloading  

 The [^ Operator](exponentiation-operator.md) can be *overloaded*, which means that a class or structure can redefine its behavior when an operand has the type of that class or structure. Overloading the `^` operator affects the behavior of the `^=` operator. If your code uses `^=` on a class or structure that overloads `^`, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  

 The following example uses the `^=` operator to raise the value of one `Integer` variable to the power of a second variable and assign the result to the first variable.  
  
 [!code-vb[VbVbalrOperators#21](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#21)]  
  
## See also

- [^ Operator](exponentiation-operator.md)
- [Assignment Operators](assignment-operators.md)
- [Arithmetic Operators](arithmetic-operators.md)
- [Operator Precedence in Visual Basic](operator-precedence.md)
- [Operators Listed by Functionality](operators-listed-by-functionality.md)
- [Statements](../../programming-guide/language-features/statements.md)
