---
title: "+ Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.+"
helpviewer_keywords: 
  - "arithmetic operators [Visual Basic], addition"
  - "+ operator"
  - "concatenation operators [Visual Basic], syntax"
  - "strings [Visual Basic], concatenating"
  - "sum operator [Visual Basic]"
ms.assetid: 5694778f-0a2c-4539-8009-f66f318fb46d
caps.latest.revision: 26
author: dotnet-bot
ms.author: dotnetcontent
---
# + Operator (Visual Basic)
Adds two numbers or returns the positive value of a numeric expression. Can also be used to concatenate two string expressions.  
  
## Syntax  
  
```  
      expression1 + expression2  
- or -  
+ expression1  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`expression1`|Required. Any numeric or string expression.|  
|`expression2`|Required unless the `+` operator is calculating a negative value. Any numeric or string expression.|  
  
## Result  
 If `expression1` and `expression2` are both numeric, the result is their arithmetic sum.  
  
 If `expression2` is absent, the `+` operator is the *unary* identity operator for the unchanged value of an expression. In this sense, the operation consists of retaining the sign of `expression1`, so the result is negative if `expression1` is negative.  
  
 If `expression1` and `expression2` are both strings, the result is the concatenation of their values.  
  
 If `expression1` and `expression2` are of mixed types, the action taken depends on their types, their contents, and the setting of the [Option Strict Statement](../../../visual-basic/language-reference/statements/option-strict-statement.md). For more information, see the tables in "Remarks."  
  
## Supported Types  
 All numeric types, including the unsigned and floating-point types and `Decimal`, and `String`.  
  
## Remarks  
 In general, `+` performs arithmetic addition when possible, and concatenates only when both expressions are strings.  
  
 If neither expression is an `Object`, Visual Basic takes the following actions.  
  
|Data types of expressions|Action by compiler|  
|---|---|  
|Both expressions are numeric data types (`SByte`, `Byte`, `Short`, `UShort`, `Integer`, `UInteger`, `Long`, `ULong`, `Decimal`, `Single`, or `Double`)|Add. The result data type is a numeric type appropriate for the data types of `expression1` and `expression2`. See the "Integer Arithmetic" tables in [Data Types of Operator Results](../../../visual-basic/language-reference/operators/data-types-of-operator-results.md).|  
|Both expressions are of type `String`|Concatenate.|  
|One expression is a numeric data type and the other is a string|If `Option Strict` is `On`, then generate a compiler error.<br /><br /> If `Option Strict` is `Off`, then implicitly convert the `String` to `Double` and add.<br /><br /> If the `String` cannot be converted to `Double`, then throw an <xref:System.InvalidCastException> exception.|  
|One expression is a numeric data type, and the other is [Nothing](../../../visual-basic/language-reference/nothing.md)|Add, with `Nothing` valued as zero.|  
|One expression is a string, and the other is `Nothing`|Concatenate, with `Nothing` valued as "".|  
  
 If one expression is an `Object` expression, Visual Basic takes the following actions.  
  
|Data types of expressions|Action by compiler|  
|---|---|  
|`Object` expression holds a numeric value and the other is a numeric data type|If `Option Strict` is `On`, then generate a compiler error.<br /><br /> If `Option Strict` is `Off`, then add.|  
|`Object` expression holds a numeric value and the other is of type `String`|If `Option Strict` is `On`, then generate a compiler error.<br /><br /> If `Option Strict` is `Off`, then implicitly convert the `String` to `Double` and add.<br /><br /> If the `String` cannot be converted to `Double`, then throw an <xref:System.InvalidCastException> exception.|  
|`Object` expression holds a string and the other is a numeric data type|If `Option Strict` is `On`, then generate a compiler error.<br /><br /> If `Option Strict` is `Off`, then implicitly convert the string `Object` to `Double` and add.<br /><br /> If the string `Object` cannot be converted to `Double`, then throw an <xref:System.InvalidCastException> exception.|  
|`Object` expression holds a string and the other is of type `String`|If `Option Strict` is `On`, then generate a compiler error.<br /><br /> If `Option Strict` is `Off`, then implicitly convert `Object` to `String` and concatenate.|  
  
 If both expressions are `Object` expressions, Visual Basic takes the following actions (`Option Strict Off` only).  
  
|Data types of expressions|Action by compiler|  
|---|---|  
|Both `Object` expressions hold numeric values|Add.|  
|Both `Object` expressions are of type `String`|Concatenate.|  
|One `Object` expression holds a numeric value and the other holds a string|Implicitly convert the string `Object` to `Double` and add.<br /><br /> If the string `Object` cannot be converted to a numeric value, then throw an <xref:System.InvalidCastException> exception.|  
  
 If either `Object` expression evaluates to [Nothing](../../../visual-basic/language-reference/nothing.md) or <xref:System.DBNull>, the `+` operator treats it as a `String` with a value of "".  
  
> [!NOTE]
>  When you use the `+` operator, you might not be able to determine whether addition or string concatenation will occur. Use the `&` operator for concatenation to eliminate ambiguity and to provide self-documenting code.  
  
## Overloading  
 The `+` operator can be *overloaded*, which means that a class or structure can redefine its behavior when an operand has the type of that class or structure. If your code uses this operator on such a class or structure, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  
 The following example uses the `+` operator to add numbers. If the operands are both numeric, Visual Basic computes the arithmetic result. The arithmetic result represents the sum of the two operands.  
  
 [!code-vb[VbVbalrOperators#6](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/addition-operator_1.vb)]  
  
 You can also use the `+` operator to concatenate strings. If the operands are both strings, Visual Basic concatenates them. The concatenation result represents a single string consisting of the contents of the two operands one after the other.  
  
 If the operands are of mixed types, the result depends on the setting of the [Option Strict Statement](../../../visual-basic/language-reference/statements/option-strict-statement.md). The following example illustrates the result when `Option Strict` is `On`.  
  
 [!code-vb[VbVbalrOperators#53](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/addition-operator_2.vb)]  
  
 [!code-vb[VbVbalrOperators#50](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/addition-operator_3.vb)]  
[!code-vb[VbVbalrOperators#51](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/addition-operator_4.vb)]  
  
 The following example illustrates the result when `Option Strict` is `Off`.  
  
 [!code-vb[VbVbalrOperators#54](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/addition-operator_5.vb)]  
  
 [!code-vb[VbVbalrOperators#50](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/addition-operator_3.vb)]  
[!code-vb[VbVbalrOperators#52](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/addition-operator_6.vb)]  
  
 To eliminate ambiguity, you should use the `&` operator instead of `+` for concatenation.  
  
## See Also  
 [& Operator](../../../visual-basic/language-reference/operators/concatenation-operator.md)  
 [Concatenation Operators](../../../visual-basic/language-reference/operators/concatenation-operators.md)  
 [Arithmetic Operators](../../../visual-basic/language-reference/operators/arithmetic-operators.md)  
 [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md)  
 [Operator Precedence in Visual Basic](../../../visual-basic/language-reference/operators/operator-precedence.md)  
 [Arithmetic Operators in Visual Basic](../../../visual-basic/programming-guide/language-features/operators-and-expressions/arithmetic-operators.md)  
 [Option Strict Statement](../../../visual-basic/language-reference/statements/option-strict-statement.md)
