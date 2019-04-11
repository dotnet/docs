---
title: "Mod Operator (Visual Basic)"
ms.date: 04/24/2018
f1_keywords: 
  - "vb.Mod"
helpviewer_keywords: 
  - "remainder (Mod operator)"
  - "division operator [Visual Basic], Mod operator"
  - "modulus operator [Visual Basic], Visual Basic"
  - "Mod operator [Visual Basic]"
  - "operators [Visual Basic], division"
  - "arithmetic operators [Visual Basic], Mod"
  - "math operators [Visual Basic]"
ms.assetid: 6ff7e40e-cec8-4c77-bff6-8ddd2791c25b
---
# Mod operator (Visual Basic)
Divides two numbers and returns only the remainder.  
  
## Syntax  
  
```  
number1 Mod number2  
```  
  
## Parts  
 `number1`  
 Required. Any numeric expression.  
  
 `number2`  
 Required. Any numeric expression.  
  
## Supported types  
 All numeric types. This includes the unsigned and floating-point types and `Decimal`.  
  
## Result

The result is the remainder after `number1` is divided by `number2`. For example, the expression `14 Mod 4` evaluates to 2.  

> [!NOTE]
> There is a difference between *remainder* and *modulus* in mathematics, with different results for negative numbers. The `Mod` operator in Visual Basic, the .NET Framework `op_Modulus` operator, and the underlying [rem](<xref:System.Reflection.Emit.OpCodes.Rem>) IL instruction all perform a remainder operation.

The result of a `Mod` operation retains the sign of the dividend, `number1`, and so it may be positive or negative. The result is always in the range (-`number2`, `number2`), exclusive. For example:

```vb
Public Module Example
   Public Sub Main()
      Console.WriteLine($" 8 Mod  3 = {8 Mod 3}")
      Console.WriteLine($"-8 Mod  3 = {-8 Mod 3}")
      Console.WriteLine($" 8 Mod -3 = {8 Mod -3}")
      Console.WriteLine($"-8 Mod -3 = {-8 Mod -3}")
   End Sub
End Module
' The example displays the following output:
'       8 Mod  3 = 2
'      -8 Mod  3 = -2
'       8 Mod -3 = 2
'      -8 Mod -3 = -2
```

## Remarks  
 If either `number1` or `number2` is a floating-point value, the floating-point remainder of the division is returned. The data type of the result is the smallest data type that can hold all possible values that result from division with the data types of `number1` and `number2`.  
  
 If `number1` or `number2` evaluates to [Nothing](../../../visual-basic/language-reference/nothing.md), it is treated as zero.  
  
 Related operators include the following:  
  
-   The [\ Operator (Visual Basic)](../../../visual-basic/language-reference/operators/integer-division-operator.md) returns the integer quotient of a division. For example, the expression `14 \ 4` evaluates to 3.  
  
-   The [/ Operator (Visual Basic)](../../../visual-basic/language-reference/operators/floating-point-division-operator.md) returns the full quotient, including the remainder, as a floating-point number. For example, the expression `14 / 4` evaluates to 3.5.  
  
## Attempted division by zero  
 If `number2` evaluates to zero, the behavior of the `Mod` operator depends on the data type of the operands. An integral division throws a <xref:System.DivideByZeroException> exception. A floating-point division returns <xref:System.Double.NaN>.  
  
## Equivalent formula  
 The expression `a Mod b` is equivalent to either of the following formulas:  
  
 `a - (b * (a \ b))`  
  
 `a - (b * Fix(a / b))`  
  
## Floating-point imprecision  
 When you work with floating-point numbers, remember that they do not always have a precise decimal representation in memory. This can lead to unexpected results from certain operations, such as value comparison and the `Mod` operator. For more information, see [Troubleshooting Data Types](../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md).  
  
## Overloading  
 The `Mod` operator can be *overloaded*, which means that a class or structure can redefine its behavior. If your code applies `Mod` to an instance of a class or structure that includes such an overload, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  
 The following example uses the `Mod` operator to divide two numbers and return only the remainder. If either number is a floating-point number, the result is a floating-point number that represents the remainder.  
  
 [!code-vb[VbVbalrOperators#31](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#31)]  
  
## Example  
 The following example demonstrates the potential imprecision of floating-point operands. In the first statement, the operands are `Double`, and 0.2 is an infinitely repeating binary fraction with a stored value of 0.20000000000000001. In the second statement, the literal type character `D` forces both operands to `Decimal`, and 0.2 has a precise representation.  
  
 [!code-vb[VbVbalrOperators#32](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#32)]  
  
## See also

- <xref:Microsoft.VisualBasic.Conversion.Int%2A>
- <xref:Microsoft.VisualBasic.Conversion.Fix%2A>
- [Arithmetic Operators](../../../visual-basic/language-reference/operators/arithmetic-operators.md)
- [Operator Precedence in Visual Basic](../../../visual-basic/language-reference/operators/operator-precedence.md)
- [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md)
- [Troubleshooting Data Types](../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md)
- [Arithmetic Operators in Visual Basic](../../../visual-basic/programming-guide/language-features/operators-and-expressions/arithmetic-operators.md)
- [\ Operator (Visual Basic)](../../../visual-basic/language-reference/operators/integer-division-operator.md)
