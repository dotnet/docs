---
description: "Learn more about: = Operator (Visual Basic)"
title: "= Operator"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Assign"
  - "vb.="
helpviewer_keywords: 
  - "= operator [Visual Basic]"
  - "= assignment statements [Visual Basic]"
ms.assetid: 2dac2e49-86c8-42f8-80c1-458452fb5e29
---
# = Operator (Visual Basic)

Assigns a value to a variable or property.  
  
## Syntax  
  
```vb  
variableorproperty = value  
```  
  
## Parts  

 `variableorproperty`  
 Any writable variable or any property.  
  
 `value`  
 Any literal, constant, or expression.  
  
## Remarks  

 The element on the left side of the equal sign (`=`) can be a simple scalar variable, a property, or an element of an array. The variable or property cannot be [ReadOnly](../modifiers/readonly.md). The `=` operator assigns the value on its right to the variable or property on its left.  
  
> [!NOTE]
> The `=` operator is also used as a comparison operator. For details, see [Comparison Operators](comparison-operators.md).  
  
## Overloading  

 The `=` operator can be overloaded only as a relational comparison operator, not as an assignment operator. For more information, see [Operator Procedures](../../programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  

 The following example demonstrates the assignment operator. The value on the right is assigned to the variable on the left.  
  
 [!code-vb[VbVbalrOperators#9](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#9)]  
  
## See also

- [&= Operator](and-assignment-operator.md)
- [*= Operator](multiplication-assignment-operator.md)
- [+= Operator](addition-assignment-operator.md)
- [-= Operator (Visual Basic)](subtraction-assignment-operator.md)
- [/= Operator (Visual Basic)](floating-point-division-assignment-operator.md)
- [\\= Operator](integer-division-assignment-operator.md)
- [^= Operator](exponentiation-assignment-operator.md)
- [Statements](../../programming-guide/language-features/statements.md)
- [Comparison Operators](comparison-operators.md)
- [ReadOnly](../modifiers/readonly.md)
- [Local Type Inference](../../programming-guide/language-features/variables/local-type-inference.md)
