---
title: "C# arithmetic, comparison, logical, and assignment operators"
description: Learn how C# arithmetic, relational, equality, logical, conditional, and assignment operators work, including integer division, short-circuit evaluation, and compound assignment.
ms.date: 08/18/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# C# operators

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from another language?** Most operators in this article (`+`, `-`, `*`, `/`, `%`, `&&`, `||`, `!`, `==`, `!=`, `<`, `>`, comparison operators, and `=`) work the same as in Java, C++, and JavaScript. The main surprises for newcomers are integer division behavior, the prefix/postfix distinction for `++`/`--`, and the way compound assignment converts back to the left-hand-side type.

An *operator* combines one or more *operands* into a single value. You already know about expressions and operator precedence from [C# expressions](index.md); this article goes deeper into the specific operators you'll use every day.

## Arithmetic operators

The five arithmetic operators perform numeric calculations.

| Operator | Name | Example | Result |
|----------|------|---------|--------|
| `+` | Addition | `10 + 3` | `13` |
| `-` | Subtraction | `10 - 3` | `7` |
| `*` | Multiplication | `10 * 3` | `30` |
| `/` | Division | `10 / 3` | `3` |
| `%` | Remainder | `10 % 3` | `1` |

:::code language="csharp" source="snippets/operators/Program.cs" ID="ArithmeticOps":::

**Integer division truncates toward zero.** When both operands are integers, `/` discards the fractional part: `7 / 2` is `3`, not `3.5`. To get a decimal result, make at least one operand a floating-point type: `7.0 / 2` is `3.5`. This differs from some languages where `/` always produces a floating-point result.

**Remainder (`%`) returns what's left over** after integer division: `10 % 3` is `1` because `10 = 3 × 3 + 1`. It's useful for cycling through a fixed range (`index % length`), testing divisibility (`n % 2 == 0`), and extracting digits.

## Unary operators

Unary operators act on a single operand.

:::code language="csharp" source="snippets/operators/Program.cs" ID="UnaryOps":::

- `+x` (unary plus) — leaves the value unchanged; rarely written explicitly but valid.
- `-x` (unary minus) — negates the value.
- `!x` (logical NOT) — flips `true` to `false` and `false` to `true`. You'll use `!` often: `if (!list.Contains(item))`.

## Increment and decrement

`++` adds 1 and `--` subtracts 1. Both have a *prefix* form and a *postfix* form that differ in which value is returned:

:::code language="csharp" source="snippets/operators/Program.cs" ID="IncrementDecrement":::

- **Prefix** (`++i`, `--i`): increments or decrements the variable first, then returns the *new* value.
- **Postfix** (`i++`, `i--`): returns the *current* value first, then increments or decrements the variable.

When `++` or `--` appears as a standalone statement (not part of a larger expression), prefix and postfix have the same effect. The distinction matters only when the result is used — for example, in an assignment or as a method argument.

## Relational operators

Relational operators compare two values and return a `bool`.

| Operator | Meaning | Example |
|----------|---------|---------|
| `<` | Less than | `speed < limit` |
| `>` | Greater than | `speed > limit` |
| `<=` | Less than or equal | `score <= 100` |
| `>=` | Greater than or equal | `score >= 0` |

:::code language="csharp" source="snippets/operators/Program.cs" ID="RelationalOps":::

Relational operators work on all numeric types and `char`. For `char`, comparison is based on the numeric Unicode code point.

## Equality operators

`==` and `!=` check whether two values are equal or not.

:::code language="csharp" source="snippets/operators/Program.cs" ID="EqualityOps":::

For numeric types and `string`, equality tests the values. For reference types, the default is identity (whether two variables point to the same object), but many types including `string` and `record` override this to compare content. For the full picture — how equality works across value types, reference types, records, and structs — see [Equality comparisons](equality.md).

> [!NOTE]
> A common source of bugs is accidentally writing `=` (assignment) where you intended `==` (equality check). The C# compiler catches the most common forms of this mistake and issues an error or warning, but it pays to double-check any `if` condition that contains `=`.

## Conditional-logical operators

`&&` (AND) and `||` (OR) combine `bool` expressions.

:::code language="csharp" source="snippets/operators/Program.cs" ID="LogicalOps":::

Both operators *short-circuit*: they skip evaluating the right operand when the result is already determined.

- `&&` returns `false` as soon as the left side is `false`. The right side is never evaluated.
- `||` returns `true` as soon as the left side is `true`. The right side is never evaluated.

Short-circuit behavior has a practical benefit: you can safely guard an operation on the right side with a null check on the left side, as the example above shows. If `items` is `null`, the `&&` stops there — `items.Count` is never called, so no `NullReferenceException` is thrown.

## Conditional operator `?:`

The conditional operator (also called the *ternary* operator) evaluates one of two expressions based on a condition:

```
condition ? value-when-true : value-when-false
```

:::code language="csharp" source="snippets/operators/Program.cs" ID="ConditionalOp":::

The `?:` operator always evaluates exactly one branch — the side that doesn't match the condition is never evaluated. This makes it safe to use an expression on one side that would fail for other inputs, as long as the condition properly guards it.

Use `?:` for simple, inline choices. For multi-way conditions or blocks of code, an `if`/`else` statement is usually clearer.

## Assignment operators

The simple assignment operator `=` stores a value in a variable:

```csharp
int level = 1;  // declaration + initialization
level = 5;      // reassignment
```

Assignment in C# is *right-associative*, which means `a = b = c = 0` evaluates right to left: `c` gets `0`, then `b` gets `0`, then `a` gets `0`.

### Compound assignment

Compound assignment operators combine a binary operation with assignment:

| Operator | Equivalent to |
|----------|---------------|
| `x += y` | `x = x + y` |
| `x -= y` | `x = x - y` |
| `x *= y` | `x = x * y` |
| `x /= y` | `x = x / y` |
| `x %= y` | `x = x % y` |

:::code language="csharp" source="snippets/operators/Program.cs" ID="AssignmentOps":::

Compound assignment is more than just a shorthand. It evaluates the left-hand side **exactly once** and then converts the result back to the left-hand-side type. This matters when the left side has side effects (like an array indexer), and it's why compound assignment on a `byte` variable compiles without an explicit cast while the expanded form does not:

:::code language="csharp" source="snippets/operators/Program.cs" ID="AssignmentChain":::

`small += 10` compiles because the compiler inserts the narrowing conversion automatically. `small = small + 10` would require an explicit `(byte)` cast, because the arithmetic promotes both operands to `int`.

## Operators not covered here

This article covers the operators you'll encounter most in everyday code. The C# language includes additional operators that are useful in specific scenarios:

- **Shift operators** (`<<`, `>>`, `>>>`) and **bitwise/integer logical operators** (`&`, `|`, `^`, `~`) — for bit-level manipulation: [Bitwise and shift operators](../../language-reference/operators/bitwise-and-shift-operators.md)
- **`checked` and `unchecked`** — for controlling integer overflow behavior: [Checked and unchecked](../../language-reference/statements/checked-and-unchecked.md)

## See also

- [C# expressions](index.md) — how expressions form and how operator precedence works
- [Equality comparisons](equality.md) — how `==`, `!=`, and `Equals` work across different types
- [C# operators and expressions (language reference)](../../language-reference/operators/index.md) — full precedence table and every operator
