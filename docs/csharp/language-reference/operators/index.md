---
title: "C# operators - C# reference"
ms.date: 04/30/2019
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
# C# operators (C# reference)

C# provides a number of predefined operators supported by the built-in types. For example, [arithmetic operators](arithmetic-operators.md) perform arithmetic operations with operands of built-in numeric types and [Boolean logical operators](boolean-logical-operators.md) perform logical operations with the [bool](../keywords/bool.md) operands.

A user-defined type can overload certain operators to define the corresponding behavior for the operands of that type. For more information, see [Operator overloading](operator-overloading.md).

The following sections list the C# operators starting with the highest precedence to the lowest. The operators within each section share the same precedence level.

## Primary operators

These are the highest precedence operators.

[x.y](member-access-operators.md#member-access-operator-) – member access.

[x?.y](member-access-operators.md#null-conditional-operators--and-) – null conditional member access. Returns `null` if the left-hand operand evaluates to `null`.

[x?[y]](member-access-operators.md#null-conditional-operators--and-) - null conditional array element or type indexer access. Returns `null` if the left-hand operand evaluates to `null`.

[f(x)](member-access-operators.md#invocation-operator-) – method call or delegate invocation.

[a&#91;x&#93;](member-access-operators.md#indexer-operator-) – array element or type indexer access.

[x++](arithmetic-operators.md#increment-operator-) – postfix increment. Returns the value of x and then updates the storage location with the value of x that is one greater (typically adds the integer 1).

[x--](arithmetic-operators.md#decrement-operator---) –  postfix decrement. Returns the value of x and then updates the storage location with the value of x that is one less (typically subtracts the integer 1).

[new](new-operator.md) – type instantiation.

[typeof](type-testing-and-conversion-operators.md#typeof-operator) – returns the <xref:System.Type> object representing the operand.

[checked](../keywords/checked.md) – enables overflow checking for integer operations.

[unchecked](../keywords/unchecked.md) – disables overflow checking for integer operations. This is the default compiler behavior.

[default(T)](../../programming-guide/statements-expressions-operators/default-value-expressions.md) – produces the default value of type T.

[nameof](nameof.md) - obtains the simple (unqualified) name of a variable, type, or member as a constant string.

[delegate](delegate-operator.md) – declares and returns a delegate instance.

[sizeof](sizeof.md) – returns the size in bytes of the type operand.

[stackalloc](stackalloc.md) - allocates a block of memory on the stack.

[->](pointer-related-operators.md#pointer-member-access-operator--) – pointer indirection combined with member access.

## Unary operators

These operators have higher precedence than the next section and lower precedence than the previous section.

[+x](addition-operator.md) – returns the value of x.

[-x](subtraction-operator.md) – numeric negation.

[\!x](boolean-logical-operators.md#logical-negation-operator-) – logical negation.

[~x](bitwise-and-shift-operators.md#bitwise-complement-operator-) – bitwise complement.

[++x](arithmetic-operators.md#increment-operator-) – prefix increment. Returns the value of x after updating the storage location with the value of x that is one greater (typically adds the integer 1).

[--x](arithmetic-operators.md#decrement-operator---) – prefix decrement. Returns the value of x after updating the storage location with the value of x that is one less (typically subtracts the integer 1).

[(T)x](type-testing-and-conversion-operators.md#cast-operator-) – type casting.

[await](../keywords/await.md) – awaits a `Task`.

[&x](pointer-related-operators.md#address-of-operator-) – address of a variable.

[*x](pointer-related-operators.md#pointer-indirection-operator-) – pointer indirection, or dereference.

[true operator](true-false-operators.md) - returns the [bool](../keywords/bool.md) value `true` to indicate that an operand is definitely true.

[false operator](true-false-operators.md) - returns the [bool](../keywords/bool.md) value `true` to indicate that an operand is definitely false.

## Multiplicative operators

These operators have higher precedence than the next section and lower precedence than the previous section.

[x * y](arithmetic-operators.md#multiplication-operator-) – multiplication.

[x / y](arithmetic-operators.md#division-operator-) – division. If the operands are integers, the result is an integer truncated toward zero (for example, `-7 / 2 is -3`).

[x % y](arithmetic-operators.md#remainder-operator-) – remainder. If the operands are integers, this returns the remainder of dividing x by y.  If `q = x / y` and `r = x % y`, then `x = q * y + r`.

## Additive operators

These operators have higher precedence than the next section and lower precedence than the previous section.

[x + y](arithmetic-operators.md#addition-operator-) – addition.

[x – y](arithmetic-operators.md#subtraction-operator--) – subtraction.

## Shift operators

These operators have higher precedence than the next section and lower precedence than the previous section.

[x <\<  y](bitwise-and-shift-operators.md#left-shift-operator-) – shift bits left and fill with zero on the right.

[x >> y](bitwise-and-shift-operators.md#right-shift-operator-) – shift bits right. If the left operand is `int` or `long`, then left bits are filled with the sign bit. If the left operand is `uint` or `ulong`, then left bits are filled with zero.

## Relational and type-testing operators

These operators have higher precedence than the next section and lower precedence than the previous section.

[x \< y](comparison-operators.md#less-than-operator-) – less than (true if x is less than y).

[x > y](comparison-operators.md#greater-than-operator-) – greater than (true if x is greater than y).

[x \<= y](comparison-operators.md#less-than-or-equal-operator-) – less than or equal to.

[x >= y](comparison-operators.md#greater-than-or-equal-operator-) – greater than or equal to.

[is](type-testing-and-conversion-operators.md#is-operator) – type compatibility. Returns `true` if the evaluated left operand can be cast to the type specified by the right operand.

[as](type-testing-and-conversion-operators.md#as-operator) – type conversion. Returns the left operand cast to the type specified by the right operand, but `as` returns `null` where `(T)x` would throw an exception.

## Equality operators

These operators have higher precedence than the next section and lower precedence than the previous section.

[x == y](equality-operators.md#equality-operator-) – equality. By default, for reference types other than `string`, this returns reference equality (identity test). However, types can overload `==`, so if your intent is to test identity, it is best to use the `ReferenceEquals` method on `object`.

[x != y](equality-operators.md#inequality-operator-) – not equal. See comment for `==`. If a type overloads `==`, then it must overload `!=`.

## Logical AND operator

This operator has higher precedence than the next section and lower precedence than the previous section.

`x & y` – [logical AND](boolean-logical-operators.md#logical-and-operator-) for the `bool` operands or [bitwise logical AND](bitwise-and-shift-operators.md#logical-and-operator-) for the operands of the integral types.

## Logical XOR operator

This operator has higher precedence than the next section and lower precedence than the previous section.

`x ^ y` – [logical XOR](boolean-logical-operators.md#logical-exclusive-or-operator-) for the `bool` operands or [bitwise logical XOR](bitwise-and-shift-operators.md#logical-exclusive-or-operator-) for the operands of the integral types.

## Logical OR operator

This operator has higher precedence than the next section and lower precedence than the previous section.

`x | y` – [logical OR](boolean-logical-operators.md#logical-or-operator-) for the `bool` operands or [bitwise logical OR](bitwise-and-shift-operators.md#logical-or-operator-) for the operands of the integral types.

## Conditional AND operator

This operator has higher precedence than the next section and lower precedence than the previous section.

[x && y](boolean-logical-operators.md#conditional-logical-and-operator-) – logical AND. If `x` evaluates to `false`, then `y` is not evaluated.

## Conditional OR operator

This operator has higher precedence than the next section and lower precedence than the previous section.

[x &#124;&#124; y](boolean-logical-operators.md#conditional-logical-or-operator-) – logical OR. If `x` evaluates to `true`, then `y` is not evaluated.

## Null-coalescing operator

This operator has higher precedence than the next section and lower precedence than the previous section.

[x ?? y](null-coalescing-operator.md) – returns `x` if it is non-`null`; otherwise, returns `y`.

## Conditional operator

This operator has higher precedence than the next section and lower precedence than the previous section.

[t ? x : y](conditional-operator.md) – if test `t` evaluates to true, then evaluate and return `x`; otherwise, evaluate and return `y`.

## Assignment and lambda operators

These operators have higher precedence than the next section and lower precedence than the previous section.

[x = y](assignment-operator.md) – assignment.

[x += y](arithmetic-operators.md#compound-assignment) – increment. Add the value of `y` to the value of `x`, store the result in `x`, and return the new value. If `x` designates an [event](../keywords/event.md), then `y` must be an appropriate method that C# adds as an event handler.

[x -= y](arithmetic-operators.md#compound-assignment) – decrement. Subtract the value of `y` from the value of `x`, store the result in `x`, and return the new value. If `x` designates an [event](../keywords/event.md), then `y` must be an appropriate method that C# removes as an event handler.

[x *= y](arithmetic-operators.md#compound-assignment) – multiplication assignment. Multiply the value of `y` to the value of `x`, store the result in `x`, and return the new value.

[x /= y](arithmetic-operators.md#compound-assignment) – division assignment. Divide the value of `x` by the value of `y`, store the result in `x`, and return the new value.

[x %= y](arithmetic-operators.md#compound-assignment) – remainder assignment. Divide the value of `x` by the value of `y`, store the remainder in `x`, and return the new value.

[x &= y](boolean-logical-operators.md#compound-assignment) – AND assignment. AND the value of `y` with the value of `x`, store the result in `x`, and return the new value.

[x &#124;= y](boolean-logical-operators.md#compound-assignment) – OR assignment. OR the value of `y` with the value of `x`, store the result in `x`, and return the new value.

[x ^= y](boolean-logical-operators.md#compound-assignment) – XOR assignment. XOR the value of `y` with the value of `x`, store the result in `x`, and return the new value.

[x <<= y](bitwise-and-shift-operators.md#compound-assignment) – left-shift assignment. Shift the value of `x` left by `y` places, store the result in `x`, and return the new value.

[x >>= y](bitwise-and-shift-operators.md#compound-assignment) – right-shift assignment. Shift the value of `x` right by `y` places, store the result in `x`, and return the new value.

[=>](lambda-operator.md) – lambda declaration.

## See also

- [C# reference](../index.md)
- [Operators](../../programming-guide/statements-expressions-operators/operators.md)
