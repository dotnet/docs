---
title: "C# operators - C# reference"
ms.date: 08/20/2019
f1_keywords: 
  - "cs.operators"
helpviewer_keywords: 
  - "operators [C#]"
  - "operator precedence [C#]"
  - "operator associativity [C#]"
  - "expressions [C#]"
ms.assetid: 0301e31f-22ad-49af-ac3c-d5eae7f0ac43
---
# C# operators (C# reference)

C# provides a number of operators supported by the built-in types. For example, [arithmetic operators](arithmetic-operators.md) perform arithmetic operations with numeric operands and [Boolean logical operators](boolean-logical-operators.md) perform logical operations with the [bool](../keywords/bool.md) operands. Certain operators can be [overloaded](operator-overloading.md). With operator overloading, you can specify the operator behavior for the operands of a user-defined type.

In an [expression](../../programming-guide/statements-expressions-operators/expressions.md), operator precedence and associativity determine the order in which the operations are performed. You can use parentheses to change the order of evaluation imposed by operator precedence and associativity.

## Operator precedence

In an expression with multiple operators, the operators with higher precedence are evaluated before the operators with lower precedence. In the following example, the multiplication is performed first because it has higher precedence than addition:

```csharp-interactive
var a = 2 + 2 * 2;
Console.WriteLine(a); //  output: 6
```

Use parentheses to change the order of evaluation imposed by operator precedence:

```csharp-interactive
var a = (2 + 2) * 2;
Console.WriteLine(a); //  output: 8
```

The following table lists the C# operators starting with the highest precedence to the lowest. The operators within each row have the same precedence.

| Operators | Category or name |
| --------- | ---------------- |
| [x.y](member-access-operators.md#member-access-operator-), [x?.y](member-access-operators.md#null-conditional-operators--and-), [x?[y]](member-access-operators.md#null-conditional-operators--and-), [f(x)](member-access-operators.md#invocation-operator-), [a&#91;i&#93;](member-access-operators.md#indexer-operator-), [x++](arithmetic-operators.md#increment-operator-), [x--](arithmetic-operators.md#decrement-operator---), [new](new-operator.md), [typeof](type-testing-and-cast.md#typeof-operator), [checked](../keywords/checked.md), [unchecked](../keywords/unchecked.md), [default](default.md), [nameof](nameof.md), [delegate](delegate-operator.md), [sizeof](sizeof.md), [stackalloc](stackalloc.md), [x->y](pointer-related-operators.md#pointer-member-access-operator--) | Primary |
| [+x](arithmetic-operators.md#unary-plus-and-minus-operators), [-x](arithmetic-operators.md#unary-plus-and-minus-operators), [\!x](boolean-logical-operators.md#logical-negation-operator-), [~x](bitwise-and-shift-operators.md#bitwise-complement-operator-), [++x](arithmetic-operators.md#increment-operator-), [--x](arithmetic-operators.md#decrement-operator---), [^x](member-access-operators.md#index-from-end-operator-), [(T)x](type-testing-and-cast.md#cast-operator-), [await](await.md), [&x](pointer-related-operators.md#address-of-operator-), [*x](pointer-related-operators.md#pointer-indirection-operator-), [true and false](true-false-operators.md) | Unary |
| [x..y](member-access-operators.md#range-operator-) | Range |
| [x * y](arithmetic-operators.md#multiplication-operator-), [x / y](arithmetic-operators.md#division-operator-), [x % y](arithmetic-operators.md#remainder-operator-) | Multiplicative|
| [x + y](arithmetic-operators.md#addition-operator-), [x – y](arithmetic-operators.md#subtraction-operator--) | Additive |
| [x \<\<  y](bitwise-and-shift-operators.md#left-shift-operator-), [x >> y](bitwise-and-shift-operators.md#right-shift-operator-) | Shift |
| [x \< y](comparison-operators.md#less-than-operator-), [x > y](comparison-operators.md#greater-than-operator-), [x \<= y](comparison-operators.md#less-than-or-equal-operator-), [x >= y](comparison-operators.md#greater-than-or-equal-operator-), [is](type-testing-and-cast.md#is-operator), [as](type-testing-and-cast.md#as-operator) | Relational and type-testing |
| [x == y](equality-operators.md#equality-operator-), [x != y](equality-operators.md#inequality-operator-) | Equality |
| `x & y` | [Boolean logical AND](boolean-logical-operators.md#logical-and-operator-) or [bitwise logical AND](bitwise-and-shift-operators.md#logical-and-operator-) |
| `x ^ y` | [Boolean logical XOR](boolean-logical-operators.md#logical-exclusive-or-operator-) or [bitwise logical XOR](bitwise-and-shift-operators.md#logical-exclusive-or-operator-) |
| <code>x &#124; y</code> | [Boolean logical OR](boolean-logical-operators.md#logical-or-operator-) or [bitwise logical OR](bitwise-and-shift-operators.md#logical-or-operator-) |
| [x && y](boolean-logical-operators.md#conditional-logical-and-operator-) | Conditional AND |
| [x &#124;&#124; y](boolean-logical-operators.md#conditional-logical-or-operator-) | Conditional OR |
| [x ?? y](null-coalescing-operator.md) | Null-coalescing operator |
| [c ? t : f](conditional-operator.md) | Conditional operator |
| [x = y](assignment-operator.md), [x += y](arithmetic-operators.md#compound-assignment), [x -= y](arithmetic-operators.md#compound-assignment), [x *= y](arithmetic-operators.md#compound-assignment), [x /= y](arithmetic-operators.md#compound-assignment), [x %= y](arithmetic-operators.md#compound-assignment), [x &= y](boolean-logical-operators.md#compound-assignment), [x &#124;= y](boolean-logical-operators.md#compound-assignment), [x ^= y](boolean-logical-operators.md#compound-assignment), [x <<= y](bitwise-and-shift-operators.md#compound-assignment), [x >>= y](bitwise-and-shift-operators.md#compound-assignment), [x ??= y](null-coalescing-operator.md), [=>](lambda-operator.md) | Assignment and lambda declaration |

## Operator associativity

When operators have the same precedence, associativity of the operators determines the order in which the operations are performed:

- *Left-associative* operators are evaluated in order from left to right. Except for the [assignment operators](assignment-operator.md) and the [null-coalescing operators `??` and `??=`](null-coalescing-operator.md), all binary operators are left-associative. For example, `a + b - c` is evaluated as `(a + b) - c`.
- *Right-associative* operators are evaluated in order from right to left. The assignment operators, the null-coalescing operators `??` and `??=`, and the [conditional operator `?:`](conditional-operator.md) are right-associative. For example, `x = y = z` is evaluated as `x = (y = z)`.

Use parentheses to change the order of evaluation imposed by operator associativity:

```csharp-interactive
int a = 13 / 5 / 2;
int b = 13 / (5 / 2);
Console.WriteLine($"a = {a}, b = {b}");  // output: a = 1, b = 6
```

## Operand evaluation

Unrelated to operator precedence and associativity, operands in an expression are evaluated from left to right. The following examples demonstrate the order in which operators and operands are evaluated:

| Expression | Order of evaluation |
| ---------- | ------------------- |
|`a + b`|a, b, +|
|`a + b * c`|a, b, c, *, +|
|`a / b + c * d`|a, b, /, c, d, *, +|
|`a / (b + c) * d`|a, b, c, +, /, d, *|

Typically, all operator operands are evaluated. Some operators evaluate operands conditionally. That is, the value of the first operand of such an operator defines if (or which) other operands should be evaluated. These operators are the conditional logical [AND (`&&`)](boolean-logical-operators.md#conditional-logical-and-operator-) and [OR (`||`)](boolean-logical-operators.md#conditional-logical-or-operator-) operators, the [null-coalescing operator `??`](null-coalescing-operator.md), the [null-conditional operators `?.` and `?[]`](member-access-operators.md#null-conditional-operators--and-), and the [conditional operator `?:`](conditional-operator.md). See the description of each operator for more details.

## C# language specification

For more information, see the [Operators](~/_csharplang/spec/expressions.md#operators) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [Expressions](../../programming-guide/statements-expressions-operators/expressions.md)
