---
title: "C# operators"
ms.date: 04/04/2018
f1_keywords: 
  - "cs.operators"
helpviewer_keywords: 
  - "boolean operators [C#]"
  - "expressions [C#], operators"
  - "logical operators [C#]"
  - "operators [C#]"
  - "Visual C#, operators"
  - "indirection operators [C#]"
  - "assignment operators [C#]"
  - "shift operators [C#]"
  - "relational operators [C#]"
  - "bitwise operators [C#]"
  - "address operators [C#]"
  - "keywords [C#], operators"
  - "arithmetic operators [C#]"
ms.assetid: 0301e31f-22ad-49af-ac3c-d5eae7f0ac43
---
# C# operators

C# provides many operators, which are symbols that specify which operations (math, indexing, function call, etc.) to perform in an expression. You can [overload](../../programming-guide/statements-expressions-operators/overloadable-operators.md) many operators to change their meaning when applied to a user-defined type.

Operations on integral types (such as `==`, `!=`, `<`, `>`, `&`, `|`) are generally allowed on enumeration (`enum`) types.

The sections below list the C# operators starting with the highest precedence to the lowest. The operators within each section share the same precedence level.

## Primary operators

These are the highest precedence operators.

[x.y](member-access-operator.md) – member access.

[x?.y](null-conditional-operators.md) – null conditional member access. Returns `null` if the left-hand operand evaluates to `null`.

[x?[y]](null-conditional-operators.md) - null conditional index access. Returns `null` if the left-hand operand evaluates to `null`.

[f(x)](invocation-operator.md) – function invocation.

[a&#91;x&#93;](index-operator.md) – aggregate object indexing.

[x++](increment-operator.md) – postfix increment. Returns the value of x and then updates the storage location with the value of x that is one greater (typically adds the integer 1).

[x--](decrement-operator.md) –  postfix decrement. Returns the value of x and then updates the storage location with the value of x that is one less (typically subtracts the integer 1).

[new](../keywords/new-operator.md) – type instantiation.

[typeof](../keywords/typeof.md) – returns the <xref:System.Type> object representing the operand.

[checked](../keywords/checked.md) – enables overflow checking for integer operations.

[unchecked](../keywords/unchecked.md) – disables overflow checking for integer operations. This is the default compiler behavior.

[default(T)](../../programming-guide/statements-expressions-operators/default-value-expressions.md) – produces the default value of type T.

[delegate](../../programming-guide/statements-expressions-operators/anonymous-methods.md) – declares and returns a delegate instance.

[sizeof](../keywords/sizeof.md) – returns the size in bytes of the type operand.

[->](dereference-operator.md) – pointer dereferencing combined with member access.

## Unary operators

These operators have higher precedence than the next section and lower precedence than the previous section.

[+x](addition-operator.md) – returns the value of x.

[-x](subtraction-operator.md) – numeric negation.

[\!x](logical-negation-operator.md) – logical negation.

[~x](bitwise-complement-operator.md) – bitwise complement.

[++x](increment-operator.md) – prefix increment. Returns the value of x after updating the storage location with the value of x that is one greater (typically adds the integer 1).

[--x](decrement-operator.md) – prefix decrement. Returns the value of x after updating the storage location with the value of x that is one less (typically subtracts the integer 1).

[(T)x](invocation-operator.md) – type casting.

[await](../keywords/await.md) – awaits a `Task`.

[&x](and-operator.md) – address of.

[*x](multiplication-operator.md) – dereferencing.

## Multiplicative operators

These operators have higher precedence than the next section and lower precedence than the previous section.

[x * y](multiplication-operator.md) – multiplication.

[x / y](division-operator.md) – division. If the operands are integers, the result is an integer truncated toward zero (for example, `-7 / 2 is -3`).

[x % y](remainder-operator.md) – remainder. If the operands are integers, this returns the remainder of dividing x by y.  If `q = x / y` and `r = x % y`, then `x = q * y + r`.

## Additive operators

These operators have higher precedence than the next section and lower precedence than the previous section.

[x + y](addition-operator.md) – addition.

[x – y](subtraction-operator.md) – subtraction.

## Shift operators

These operators have higher precedence than the next section and lower precedence than the previous section.

[x <\<  y](left-shift-operator.md) – shift bits left and fill with zero on the right.

[x >> y](right-shift-operator.md) – shift bits right. If the left operand is `int` or `long`, then left bits are filled with the sign bit. If the left operand is `uint` or `ulong`, then left bits are filled with zero.

## Relational and type-testing operators

These operators have higher precedence than the next section and lower precedence than the previous section.

[x \< y](less-than-operator.md) – less than (true if x is less than y).

[x > y](greater-than-operator.md) – greater than (true if x is greater than y).

[x \<= y](less-than-equal-operator.md) – less than or equal to.

[x >= y](greater-than-equal-operator.md) – greater than or equal to.

[is](../keywords/is.md) – type compatibility. Returns true if the evaluated left operand can be cast to the type specified in the right operand (a static type).

[as](../keywords/as.md) – type conversion. Returns the left operand cast to the type specified by the right operand (a static type), but `as` returns `null` where `(T)x` would throw an exception.

## Equality operators

These operators have higher precedence than the next section and lower precedence than the previous section.

[x == y](equality-comparison-operator.md) – equality. By default, for reference types other than `string`, this returns reference equality (identity test). However, types can overload `==`, so if your intent is to test identity, it is best to use the `ReferenceEquals` method on `object`.

[x != y](not-equal-operator.md) – not equal. See comment for `==`. If a type overloads `==`, then it must overload `!=`.

## Logical AND operator

This operator has higher precedence than the next section and lower precedence than the previous section.

[x & y](and-operator.md) – logical or bitwise AND. You can generally use this with integer types and `enum` types.

## Logical XOR operator

This operator has higher precedence than the next section and lower precedence than the previous section.

[x ^ y](xor-operator.md) – logical or bitwise XOR. You can generally use this with integer types and `enum` types.

## Logical OR operator

This operator has higher precedence than the next section and lower precedence than the previous section.

[x &#124; y](or-operator.md) – logical or bitwise OR. You can generally use this with integer types and `enum` types.

## Conditional AND operator

This operator has higher precedence than the next section and lower precedence than the previous section.

[x && y](conditional-and-operator.md) – logical AND. If the first operand evaluates to false, then C# does not evaluate the second operand.

## Conditional OR operator

This operator has higher precedence than the next section and lower precedence than the previous section.

[x &#124;&#124; y](conditional-or-operator.md) – logical OR. If the first operand evaluates to true, then C# does not evaluate the second operand.

## Null-coalescing operator

This operator has higher precedence than the next section and lower precedence than the previous section.

[x ?? y](null-coalescing-operator.md) – returns `x` if it is non-`null`; otherwise, returns `y`.

## Conditional operator

This operator has higher precedence than the next section and lower precedence than the previous section.

[t ? x : y](conditional-operator.md) – if test `t` evaluates to true, then evaluate and return `x`; otherwise, evaluate and return `y`.

## Assignment and Lambda operators

These operators have higher precedence than the next section and lower precedence than the previous section.

[x = y](assignment-operator.md) – assignment.

[x += y](addition-assignment-operator.md) – increment. Add the value of `y` to the value of `x`, store the result in `x`, and return the new value. If `x` designates an `event`, then `y` must be an appropriate function that C# adds as an event handler.

[x -= y](subtraction-assignment-operator.md) – decrement. Subtract the value of `y` from the value of `x`, store the result in `x`, and return the new value. If `x` designates an `event`, then `y` must be an appropriate function that C# removes as an event handler

[x *= y](multiplication-assignment-operator.md) – multiplication assignment. Multiply the value of `y` to the value of `x`, store the result in `x`, and return the new value.

[x /= y](division-assignment-operator.md) – division assignment. Divide the value of `x` by the value of `y`, store the result in `x`, and return the new value.

[x %= y](remainder-assignment-operator.md) – remainder assignment. Divide the value of `x` by the value of `y`, store the remainder in `x`, and return the new value.

[x &= y](and-assignment-operator.md) – AND assignment. AND the value of `y` with the value of `x`, store the result in `x`, and return the new value.

[x &#124;= y](or-assignment-operator.md) – OR assignment. OR the value of `y` with the value of `x`, store the result in `x`, and return the new value.

[x ^= y](xor-assignment-operator.md) – XOR assignment. XOR the value of `y` with the value of `x`, store the result in `x`, and return the new value.

[x <<= y](left-shift-assignment-operator.md) – left-shift assignment. Shift the value of `x` left by `y` places, store the result in `x`, and return the new value.

[x >>= y](right-shift-assignment-operator.md) – right-shift assignment. Shift the value of `x` right by `y` places, store the result in `x`, and return the new value.

[=>](lambda-operator.md) – lambda declaration.

## Arithmetic overflow

The arithmetic operators ([+](addition-operator.md), [-](subtraction-operator.md), [*](multiplication-operator.md), [/](division-operator.md)) can produce results that are outside the range of possible values for the numeric type involved. You should refer to the section on a particular operator for details, but in general:

- Integer arithmetic overflow either throws an <xref:System.OverflowException> or discards the most significant bits of the result. Integer division by zero always throws a <xref:System.DivideByZeroException>.

   When integer overflow occurs, what happens depends on the execution context, which can be [checked or unchecked](../keywords/checked-and-unchecked.md). In a checked context, an <xref:System.OverflowException> is thrown. In an unchecked context, the most significant bits of the result are discarded and execution continues. Thus, C# gives you the choice of handling or ignoring overflow. By default, arithmetic operations occur in an *unchecked* context.

   In addition to the arithmetic operations, integral-type to integral-type casts can cause overflow (such as when you cast a [long](../keywords/long.md) to an [int](../keywords/int.md)), and are subject to checked or unchecked execution. However, bitwise operators and shift operators never cause overflow.

- Floating-point arithmetic overflow or division by zero never throws an exception, because floating-point types are based on IEEE 754 and so have provisions for representing infinity and NaN (Not a Number).

- [Decimal](../keywords/decimal.md) arithmetic overflow always throws an <xref:System.OverflowException>. Decimal division by zero always throws a <xref:System.DivideByZeroException>.

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C#](../../index.md)
- [Overloadable Operators](../../programming-guide/statements-expressions-operators/overloadable-operators.md)
- [C# Keywords](../keywords/index.md)