---
title: "C# expressions overview"
description: Learn how C# expressions work, how operator precedence determines evaluation order, how to use parentheses to make intent clear, and how short-circuit evaluation works.
ms.date: 08/10/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# C# expressions

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from another language?** Expressions in C# work much as they do in Java, C++, and JavaScript. One difference worth noting: compound assignment operators like `+=` and the increment operator `++` are expressions in C#, so they can appear in larger expressions. Prefer standalone statements for clarity.

An *expression* is a piece of code that the compiler evaluates. Most expressions produce a value — a number, a string, a reference, a `bool` — that you can assign, pass, or use in a larger expression. Some expressions, such as a call to a `void` method, run for their side effects and produce no value.

```csharp
int total = 3 + 4 * 2;          // arithmetic expression → value 11
bool isReady = total > 10;       // comparison expression → value false
Console.WriteLine("done");       // void method call → no value
```

The simplest expressions are *literals* (like `42` or `"hello"`) and *variable names*. You build more complex expressions by combining these with operators.

## Operator precedence

When an expression contains multiple operators, C# follows *operator precedence* rules to decide which operation to evaluate first — the same idea as the order-of-operations rules you learned in math class.

Memorizing three tiers covers most real code:

1. **Arithmetic first** — `*`, `/`, `%` bind tighter than `+` and `-`. Multiplication and division happen before addition and subtraction.
2. **Comparison next** — `<`, `>`, `<=`, `>=`, `==`, `!=` bind less tightly than arithmetic, so arithmetic completes before the comparison.
3. **Logical last** — `&&` and `||` bind least tightly of the common operators, so comparisons complete before the logical combination.

This means the expression `score + bonus > threshold && attempts < maxAttempts` evaluates exactly as you'd read it in English: add score and bonus, compare to threshold, compare attempts to maxAttempts, then combine the two `bool` results.

The full operator precedence table — covering every operator — lives in the language reference: [C# operators and expressions](../../language-reference/operators/index.md).

### Use parentheses to make intent clear

Parentheses override precedence and document your intent at the same time. When the order isn't obvious from the three tiers above, add parentheses:

:::code language="csharp" source="snippets/expressions/Program.cs" ID="ParenthesesClarity":::

Prefer parentheses over memorizing obscure precedence rules. A reader who sees `(a | b) & c` knows exactly what you intended; `a | b & c` requires them to recall that `&` binds more tightly than `|`.

## Operand evaluation order

Regardless of precedence, C# evaluates the *operands* of most operators from left to right before applying the operator. Precedence determines which operator applies to which operands; left-to-right evaluation determines when each operand expression runs.

```csharp
int x = 1;
int result = (x++) + (x++);   // first operand: x=1→2; second operand: x=2→3; result = 1 + 2 = 3
```

This distinction rarely matters unless operands have side effects. In practice, write each side effect on its own statement for clarity.

## Associativity

When two operators have the same precedence level, *associativity* decides which one applies first. Most C# operators are *left-associative*: `a - b - c` groups as `(a - b) - c`. Assignment operators are *right-associative*: `a = b = 0` groups as `a = (b = 0)`, so `b` is set first, then `a` is set to the same value.

## Short-circuit evaluation

The logical operators `&&` (AND) and `||` (OR) are *short-circuit* operators: they stop evaluating as soon as the result is known.

- `&&` returns `false` as soon as the left side is `false`. The right side is never evaluated.
- `||` returns `true` as soon as the left side is `true`. The right side is never evaluated.

:::code language="csharp" source="snippets/expressions/Program.cs" ID="ShortCircuit":::

Short-circuit evaluation is useful for null checks: `text != null && text.Length > 0` is safe because the second condition runs only when `text` is not null. For a broader look at null-safe operators, see [C# null operators](../null-safety/null-operators.md).

The non-short-circuit alternatives `&` and `|` always evaluate both sides. Use them only when the right-side side effect must always run.

## See also

- [C# operators and expressions (language reference)](../../language-reference/operators/index.md) — full precedence table and every operator
- [Equality comparisons](equality.md) — how `==`, `!=`, and `Equals` work
- [C# null operators](../null-safety/null-operators.md) — `?.`, `??`, and `??=`
- [Boolean logical operators](../../language-reference/operators/boolean-logical-operators.md)
