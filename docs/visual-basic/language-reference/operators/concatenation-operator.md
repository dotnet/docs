---
description: "Learn more about: &amp; Operator (Visual Basic)"
title: "&amp; Operator"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.&"
helpviewer_keywords: 
  - "And (&) operator"
  - "ampersand operator (&)"
  - "& operator"
  - "concatenation operators [Visual Basic], syntax"
  - "strings [Visual Basic], concatenating"
ms.assetid: fefc3d00-cbf1-475c-8c5e-6fb213b3f85a
---
# &amp; Operator (Visual Basic)

Generates a string concatenation of two expressions.  
  
## Syntax  
  
```vb  
result = expression1 & expression2  
```  
  
## Parts  

 `result`  
 Required. Any `String` or `Object` variable.  
  
 `expression1`  
 Required. Any expression with a data type that widens to `String`.  
  
 `expression2`  
 Required. Any expression with a data type that widens to `String`.  
  
## Remarks  

 If the data type of `expression1` or `expression2` is not `String` but widens to `String`, it is converted to `String`. If either of the data types does not widen to `String`, the compiler generates an error.  
  
 The data type of `result` is `String`. If one or both expressions evaluate to [Nothing](../nothing.md) or have a value of <xref:System.DBNull.Value?displayProperty=nameWithType>, they are treated as a string with a value of "".  
  
> [!NOTE]
> The `&` operator can be *overloaded*, which means that a class or structure can redefine its behavior when an operand has the type of that class or structure. If your code uses this operator on such a class or structure, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../programming-guide/language-features/procedures/operator-procedures.md).  
  
> [!NOTE]
> The ampersand (&) character can also be used to identify variables as type `Long`. For more information, see [Type Characters](../../programming-guide/language-features/data-types/type-characters.md).  
  
## Example  

 This example uses the `&` operator to force string concatenation. The result is a string value representing the concatenation of the two string operands.  
  
 [!code-vb[VbVbalrOperators#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#2)]  
  
## See also

- [&= Operator](and-assignment-operator.md)
- [Concatenation Operators](concatenation-operators.md)
- [Operator Precedence in Visual Basic](operator-precedence.md)
- [Operators Listed by Functionality](operators-listed-by-functionality.md)
- [Concatenation Operators in Visual Basic](../../programming-guide/language-features/operators-and-expressions/concatenation-operators.md)
