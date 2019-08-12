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

The following table lists the C# operators starting with the highest precedence to the lowest. The operators within each row share the same precedence level.

| Operators | Category or name |
| --------- | ---------------- |
| [x.y](member-access-operators.md#member-access-operator-), [x?.y](member-access-operators.md#null-conditional-operators--and-), [x?[y]](member-access-operators.md#null-conditional-operators--and-), [f(x)](member-access-operators.md#invocation-operator-), [a&#91;x&#93;](member-access-operators.md#indexer-operator-), [x++](arithmetic-operators.md#increment-operator-), [x--](arithmetic-operators.md#decrement-operator---), [new](new-operator.md), [typeof](type-testing-and-conversion-operators.md#typeof-operator), [checked](../keywords/checked.md), [unchecked](../keywords/unchecked.md), [default](default.md), [nameof](nameof.md), [delegate](delegate-operator.md), [sizeof](sizeof.md), [stackalloc](stackalloc.md), [->](pointer-related-operators.md#pointer-member-access-operator--) | Primary |
| [+x](addition-operator.md), [-x](subtraction-operator.md), [\!x](boolean-logical-operators.md#logical-negation-operator-), [~x](bitwise-and-shift-operators.md#bitwise-complement-operator-), [++x](arithmetic-operators.md#increment-operator-), [--x](arithmetic-operators.md#decrement-operator---), [(T)x](type-testing-and-conversion-operators.md#cast-operator-), [await](../keywords/await.md), [&x](pointer-related-operators.md#address-of-operator-), [*x](pointer-related-operators.md#pointer-indirection-operator-), [true and false](true-false-operators.md) | Unary |
| [x * y](arithmetic-operators.md#multiplication-operator-), [x / y](arithmetic-operators.md#division-operator-), [x % y](arithmetic-operators.md#remainder-operator-) | Multiplicative|
| [x + y](arithmetic-operators.md#addition-operator-), [x – y](arithmetic-operators.md#subtraction-operator--) | Additive |
| [x <\<  y](bitwise-and-shift-operators.md#left-shift-operator-), [x >> y](bitwise-and-shift-operators.md#right-shift-operator-) | Shift |
| [x \< y](comparison-operators.md#less-than-operator-), [x > y](comparison-operators.md#greater-than-operator-), [x \<= y](comparison-operators.md#less-than-or-equal-operator-), [x >= y](comparison-operators.md#greater-than-or-equal-operator-), [is](type-testing-and-conversion-operators.md#is-operator), [as](type-testing-and-conversion-operators.md#as-operator) | Relational and type-testing |
| [x == y](equality-operators.md#equality-operator-), [x != y](equality-operators.md#inequality-operator-) | Equality |
| `x & y` | [Boolean logical AND](boolean-logical-operators.md#logical-and-operator-) or [bitwise logical AND](bitwise-and-shift-operators.md#logical-and-operator-) |
| `x ^ y` | [Boolean logical XOR](boolean-logical-operators.md#logical-exclusive-or-operator-) or [bitwise logical XOR](bitwise-and-shift-operators.md#logical-exclusive-or-operator-) |
| `x | y` | [Boolean logical OR](boolean-logical-operators.md#logical-or-operator-) or [bitwise logical OR](bitwise-and-shift-operators.md#logical-or-operator-) |
| [x && y](boolean-logical-operators.md#conditional-logical-and-operator-) | Conditional AND |
| [x &#124;&#124; y](boolean-logical-operators.md#conditional-logical-or-operator-) | Conditional OR |
| [x ?? y](null-coalescing-operator.md) | Null-coalescing operator |
| [t ? x : y](conditional-operator.md) | Conditional operator |
| [x = y](assignment-operator.md), [x += y](arithmetic-operators.md#compound-assignment), [x -= y](arithmetic-operators.md#compound-assignment), [x *= y](arithmetic-operators.md#compound-assignment), [x /= y](arithmetic-operators.md#compound-assignment), [x %= y](arithmetic-operators.md#compound-assignment), [x &= y](boolean-logical-operators.md#compound-assignment), [x &#124;= y](boolean-logical-operators.md#compound-assignment), [x ^= y](boolean-logical-operators.md#compound-assignment), [x <<= y](bitwise-and-shift-operators.md#compound-assignment), [x >>= y](bitwise-and-shift-operators.md#compound-assignment), [=>](lambda-operator.md) | Assignment and lambda declaration |

## See also

- [C# reference](../index.md)
- [Operators](../../programming-guide/statements-expressions-operators/operators.md)
