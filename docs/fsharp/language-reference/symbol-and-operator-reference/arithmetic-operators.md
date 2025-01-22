---
title: Arithmetic Operators
description: Learn about the arithmetic operators that are available in the F# programming language.
ms.date: 05/28/2024
---
# Arithmetic Operators

This topic describes arithmetic operators that are available in F#.

## Summary of Binary Arithmetic Operators

Arithmetic operations in F# can be performed in two modes: **Unchecked** and **Checked**. By default, arithmetic operations use unchecked behavior, which prioritizes performance but allows overflow/underflow. Checked operators prioritize safety by throwing exceptions in such cases.

### Unchecked Arithmetic Operators

The following table summarizes the binary arithmetic operators that are available for **Unchecked Arithmetic** with unboxed integral and floating-point types.

|Binary operator|Notes|
|---------------|-----|
|`+` (addition, plus)|Unchecked. Possible overflow condition when numbers are added together and the sum exceeds the maximum absolute value supported by the type.|
|`-` (subtraction, minus)|Unchecked. Possible underflow condition when unsigned types are subtracted, or when floating-point values are too small to be represented by the type.|
|`*` (multiplication, times)|Unchecked. Possible overflow condition when numbers are multiplied and the product exceeds the maximum absolute value supported by the type.|
|`/` (division, divided by)|Division by zero causes a <xref:System.DivideByZeroException> for integral types. For floating-point types, division by zero gives you the special floating-point values `infinity` or `-infinity`. There is also a possible underflow condition when a floating-point number is too small to be represented by the type.|
|`%` (remainder, rem)|Returns the remainder of a division operation. The sign of the result is the same as the sign of the first operand.|
|`**` (exponentiation, to the power of)|Possible overflow condition when the result exceeds the maximum absolute value for the type.<br /><br />The exponentiation operator works only with floating-point types.|

The unchecked behavior does not throw exceptions when overflow or underflow occurs, making it less safe for arithmetic on large or edge-case values.

### Checked Arithmetic Operators

The following table summarizes the binary arithmetic operators that are available for **Checked Arithmetic** with unboxed integral types. Checked operators ensure that calculations are verified for overflow or underflow, providing safer arithmetic for critical applications.

| Binary Operator | Notes                                                                                  |  
|------------------|----------------------------------------------------------------------------------------|  
| `+` (addition, plus) | Throws an <xref:System.OverflowException> if the result exceeds the maximum value or goes below the minimum value supported by the type. Both **Overflow** and **Underflow** are possible. |  
| `-` (subtraction, minus) | Throws an <xref:System.OverflowException> if the result exceeds the maximum value or goes below the minimum value supported by the type. Both **Overflow** and **Underflow** are possible. |  
| `*` (multiplication, times) | Throws an <xref:System.OverflowException> if the product exceeds the maximum value or goes below the minimum value supported by the type. Both **Overflow** and **Underflow** are possible. |  

The checked operators are useful for ensuring that arithmetic overflows are caught and handled explicitly.

Here’s an example:

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet3502.fs)]

### Choosing Between Checked and Unchecked Operators

**Checked Operators:** Ideal for scenarios where overflow errors must be detected and handled explicitly.

**Unchecked Operators:** By default, F# uses unchecked arithmetic for performance reasons. These operations may silently produce incorrect results when overflow or underflow occurs. Use with caution.

## Summary of Unary Arithmetic Operators

The following table summarizes the unary arithmetic operators that are available for integral and floating-point types.

|Unary operator|Notes|
|--------------|-----|
|`+` (positive)|Can be applied to any arithmetic expression. Does not change the sign of the value.|
|`-` (negation, negative)|Can be applied to any arithmetic expression. Changes the sign of the value.|

The behavior at overflow or underflow for integral types is to wrap around. This causes an incorrect result. Integer overflow is a potentially serious problem that can contribute to security issues when software is not written to account for it. If this is a concern for your application, consider using the checked operators in `Microsoft.FSharp.Core.Operators.Checked`.

## Summary of Binary Comparison Operators

The following table shows the binary comparison operators that are available for integral and floating-point types. These operators return values of type `bool`.

Floating-point numbers should never be directly compared for equality, because the IEEE floating-point representation does not support an exact equality operation. Two numbers that you can easily verify to be equal by inspecting the code might actually have different bit representations.

|Operator|Notes|
|--------|-----|
|`=` (equality, equals)|This is not an assignment operator. It is used only for comparison. This is a generic operator.|
|`>` (greater than)|This is a generic operator.|
|`<` (less than)|This is a generic operator.|
|`>=` (greater than or equals)|This is a generic operator.|
|`<=` (less than or equals)|This is a generic operator.|
|`<>` (not equal)|This is a generic operator.|

## Overloaded and Generic Operators

All of the operators discussed in this topic are defined in the **Microsoft.FSharp.Core.Operators** namespace. Some of the operators are defined by using statically resolved type parameters. This means that there are individual definitions for each specific type that works with that operator. All of the unary and binary arithmetic and bitwise operators are in this category. The comparison operators are generic and therefore work with any type, not just primitive arithmetic types. Discriminated union and record types have their own custom implementations that are generated by the F# compiler. Class types use the method <xref:System.Object.Equals%2A>.

The generic operators are customizable. To customize the comparison functions, override <xref:System.Object.Equals%2A> to provide your own custom equality comparison, and then implement <xref:System.IComparable>. The <xref:System.IComparable?displayProperty=nameWithType> interface has a single method, the <xref:System.IComparable.CompareTo%2A> method.

## Operators and Type Inference

The use of an operator in an expression constrains type inference on that operator. Also, the use of operators prevents automatic generalization, because the use of operators implies an arithmetic type. In the absence of any other information, the F# compiler infers `int` as the type of arithmetic expressions. You can override this behavior by specifying another type. Thus the argument types and return type of `function1` in the following code are inferred to be `int`, but the types for `function2` are inferred to be `float`.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet3501.fs)]

## See also

- [Symbol and Operator Reference](index.md)
- [Operator Overloading](../operator-overloading.md)
- [Bitwise Operators](bitwise-operators.md)
- [Boolean Operators](boolean-operators.md)
