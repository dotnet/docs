---
description: "Learn more about: * Operator (Visual Basic)"
title: "* Operator"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.*"
helpviewer_keywords: 
  - "arithmetic operators [Visual Basic], multiplication"
  - "operators [Visual Basic], multiplication"
  - "* operator [Visual Basic]"
  - "multiplication operator [Visual Basic], syntax"
  - "math operators [Visual Basic]"
ms.assetid: 2b210382-99da-4195-89ba-b1d06f5e89ad
---
# * Operator (Visual Basic)

Multiplies two numbers.  
  
## Syntax  
  
```vb  
number1 * number2  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`number1`|Required. Any numeric expression.|  
|`number2`|Required. Any numeric expression.|  
  
## Result  

 The result is the product of `number1` and `number2`.  
  
## Supported Types  

 All numeric types, including the unsigned and floating-point types and `Decimal`.  
  
## Remarks  

 The data type of the result depends on the types of the operands. The following table shows how the data type of the result is determined.  
  
|Operand data types|Result data type|  
|---|---|  
|Both expressions are integral data types ([SByte](../data-types/sbyte-data-type.md), [Byte](../data-types/byte-data-type.md), [Short](../data-types/short-data-type.md), [UShort](../data-types/ushort-data-type.md), [Integer](../data-types/integer-data-type.md), [UInteger](../data-types/uinteger-data-type.md), [Long](../data-types/long-data-type.md), [ULong](../data-types/ulong-data-type.md))|A numeric data type appropriate for the data types of `number1` and `number2`. See the "Integer Arithmetic" tables in [Data Types of Operator Results](data-types-of-operator-results.md).|  
|Both expressions are [Decimal](../data-types/decimal-data-type.md)|`Decimal`|  
|Both expressions are [Single](../data-types/single-data-type.md)|`Single`|  
|Either expression is a floating-point data type (`Single` or [Double](../data-types/double-data-type.md)) but not both `Single` (note `Decimal` is not a floating-point data type)|`Double`|  
  
 If an expression evaluates to [Nothing](../nothing.md), it is treated as zero.  
  
## Overloading  

 The `*` operator can be *overloaded*, which means that a class or structure can redefine its behavior when an operand has the type of that class or structure. If your code uses this operator on such a class or structure, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  

 This example uses the `*` operator to multiply two numbers. The result is the product of the two operands.  
  
 [!code-vb[VbVbalrOperators#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#4)]  
  
## See also

- [*= Operator](multiplication-assignment-operator.md)
- [Arithmetic Operators](arithmetic-operators.md)
- [Operator Precedence in Visual Basic](operator-precedence.md)
- [Operators Listed by Functionality](operators-listed-by-functionality.md)
- [Arithmetic Operators in Visual Basic](../../programming-guide/language-features/operators-and-expressions/arithmetic-operators.md)
