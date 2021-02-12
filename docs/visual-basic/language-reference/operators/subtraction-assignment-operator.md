---
description: "Learn more about: -= Operator (Visual Basic)"
title: "-= Operator"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.-="
helpviewer_keywords: 
  - "-= operator [Visual Basic]"
  - "assignment statements [Visual Basic], compound"
  - "statements [Visual Basic], compound assignment"
  - "operator -="
  - "compound assignment statements [Visual Basic]"
ms.assetid: 5ead0c37-ae50-48f7-8435-8e341d81cae1
---
# -= Operator (Visual Basic)

Subtracts the value of an expression from the value of a variable or property and assigns the result to the variable or property.  
  
## Syntax  
  
```vb  
variableorproperty -= expression  
```  
  
## Parts  

 `variableorproperty`  
 Required. Any numeric variable or property.  
  
 `expression`  
 Required. Any numeric expression.  
  
## Remarks  

 The element on the left side of the `-=` operator can be a simple scalar variable, a property, or an element of an array. The variable or property cannot be [ReadOnly](../modifiers/readonly.md).  
  
 The `-=` operator first subtracts the value of the expression (on the right-hand side of the operator) from the value of the variable or property (on the left-hand side of the operator). The operator then assigns the result of that operation to the variable or property.  
  
## Overloading  

 The [- Operator (Visual Basic)](subtraction-operator.md) can be *overloaded*, which means that a class or structure can redefine its behavior when an operand has the type of that class or structure. Overloading the `-` operator affects the behavior of the `-=` operator. If your code uses `-=` on a class or structure that overloads `-`, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  

 The following example uses the `-=` operator to subtract one `Integer` variable from another and assign the result to the latter variable.  
  
 [!code-vb[VbVbalrOperators#11](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#11)]  
  
## See also

- [- Operator (Visual Basic)](subtraction-operator.md)
- [Assignment Operators](assignment-operators.md)
- [Arithmetic Operators](arithmetic-operators.md)
- [Operator Precedence in Visual Basic](operator-precedence.md)
- [Operators Listed by Functionality](operators-listed-by-functionality.md)
- [Statements](../../programming-guide/language-features/statements.md)
