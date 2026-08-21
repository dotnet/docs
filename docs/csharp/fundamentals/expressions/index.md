---
title: "C# expressions overview"
description: Learn how C# expressions work, how operator precedence and evaluation order determine results, how to use parentheses for clarity, and how short-circuit evaluation works.
ms.date: 08/13/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# C# expressions

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from another language?** Expressions in C# work much as they do in Java, C++, and JavaScript. One difference worth noting: compound assignment operators like `+=` and the increment operator `++` are expressions in C#, so they can appear in larger expressions.

An *expression* is a piece of code that the compiler evaluates to produce a value — a number, a string, a reference, or a `bool`. For example, `3 + 4 * 2` is an expression that evaluates to the integer `11`, and `total > 10` is an expression that evaluates to `true` or `false`.

The simplest expressions are *literals* (like `42` or `"hello"`) and *variable names* (like `total`). You build more complex expressions by combining simpler ones with operators.

### Expressions and statements

An expression produces a value. A *statement* is a complete instruction that the program executes. Many statements contain expressions. For example, `int total = 3 + 4 * 2;` is a variable declaration statement. The compiler evaluates the initializer expression `3 + 4 * 2`, which produces `11`, and assigns that value to the new variable `total`. This article focuses on expressions — how they're formed, how they're evaluated, and how they combine.

## Combining expressions

Expressions can be combined. Consider `3 + 4 * 2`. This single expression actually contains two smaller expressions: the *multiplication expression* `4 * 2` and the *addition expression* `3 + <result>`. When expressions are combined, C# needs a rule to decide which one to evaluate first. That rule is *operator precedence*.

You don't need to memorize the complete precedence hierarchy. The next section summarizes the everyday groups, and parentheses always let you make the order explicit when you're unsure.

## Operator precedence

*Operator precedence* determines how a combined expression *groups* into sub-expressions. This concept is similar to the order-of-operations rules from math class. An operator with higher precedence *binds more tightly* to its operands. The expression is structured as if those operands are parenthesized together. In `3 + 4 * 2`, `*` has higher precedence than `+`, so the expression groups as `3 + (4 * 2)`, not `(3 + 4) * 2`.

C# has more precedence groups than the four summarized here. Those additional groups enforce familiar rules — for example, multiplication before addition — and cover the complete set of operators. The following groups cover what you encounter most often in everyday code:

1. **Primary, unary, and range** — these are three distinct precedence groups, all of which bind more tightly than arithmetic. This summary combines them into one step because, for practical purposes, they all apply before arithmetic.
   - *Primary* operators — member access (`x.y`), method calls (`f()`), indexing (`a[i]`), and null-conditional access (`?.`, `?[]`) — bind most tightly of all.
   - *Unary* operators act on a single operand: negation (`-x`), logical NOT (`!flag`), prefix increment (`++i`), and postfix increment (`i++`).
   - The *range* operator (`..`) builds index ranges for slice expressions, like `array[1..4]`.
2. **Arithmetic** — `*`, `/`, `%` bind more tightly than `+` and `-`. Multiplication and division happen before addition and subtraction.
3. **Comparison** — `<`, `>`, `<=`, `>=`, `==`, `!=` bind less tightly than arithmetic, so arithmetic completes before the comparison.
4. **Logical** — `&&` and `||` bind least tightly of the common operators, so comparisons complete before the logical combination.

This precedence means the expression `score + bonus > threshold && attempts < maxAttempts` evaluates exactly as you'd read it: add `score` and `bonus`, compare the sum to `threshold`, compare `attempts` to `maxAttempts`, then combine the two `bool` results with `&&`. Adding parentheses to make every grouping explicit shows the same structure: `((score + bonus) > threshold) && (attempts < maxAttempts)`.

For the complete precedence hierarchy covering every operator, see [C# operators and expressions](../../language-reference/operators/index.md).

### Use parentheses to make intent clear

Parentheses override precedence and document your intent at the same time. When the order isn't obvious from the groups above, add parentheses:

:::code language="csharp" source="snippets/expressions/Program.cs" ID="ParenthesesClarity":::

The last two lines show that parentheses can change the result, not just the style. When `&&` and `||` appear together, add parentheses to spell out which condition combines first. A reader who sees `(isAdmin && isOwner) || isSuperUser` knows the intent immediately.

## How expressions are evaluated

Understanding how C# evaluates combined expressions is easier with an analogy. Think of working through a complex math problem with pencil and paper: you identify the innermost or highest-precedence sub-expression, compute its interim value, write down the result, then repeat with the next sub-expression — continuing until you reach the final answer.

C# follows the same process, guided by two rules:

**Rule 1: Operands evaluate left to right.** For any binary expression, both operands must be fully evaluated before the operator is applied. C# evaluates the left operand first, then the right, then performs the operation.

**Rule 2: Some operators short-circuit.** Certain operators stop evaluating as soon as the result is determined, skipping any remaining operands:

- `&&` (conditional AND): returns `false` as soon as the left side is `false`. The right side is never evaluated.
- `||` (conditional OR): returns `true` as soon as the left side is `true`. The right side is never evaluated.
- `?:` (conditional/ternary): evaluates only the branch that matches the condition — the other branch is never evaluated.
- `?.` (null-conditional member access) and `?[]` (null-conditional element access): stop and return `null` immediately when the left side is `null`, skipping the member access or index.
- `??=` (null-coalescing assignment): assigns the right side only when the left side is `null`.

### Paper-and-pencil evaluation

Consider the expression `3 + 6 / 2`. Even though addition appears first in reading order, `/` has higher precedence than `+`, so `6 / 2` is the sub-expression that evaluates first. Working through it step by step — exactly as you would on paper:

```
3 + 6 / 2
      ↓   (evaluate 6 / 2 → 3)
3 +   3
  ↓   (evaluate 3 + 3 → 6)
  6
```

:::code language="csharp" source="snippets/expressions/Program.cs" ID="StepByStep":::

The interim value `3` produced by `6 / 2` becomes the right operand of `+`, and the final result is `6`. Each sub-expression produces an interim value; those interim values feed the next sub-expression, until only one value remains.

*Associativity* is a related concept: when two operators have the same precedence, associativity decides which one goes first. Most C# operators are *left-associative*, meaning they group left to right. So `a - b - c` is the same as `(a - b) - c`, not `a - (b - c)`.

### Short-circuit evaluation in practice

Short-circuit evaluation is particularly useful for null checks:

:::code language="csharp" source="snippets/expressions/Program.cs" ID="ShortCircuit":::

`text != null && text.Length > 0` is safe because the second condition runs only when `text` isn't `null`. Similarly, `?.` stops evaluation when it encounters a `null` reference, which avoids a `NullReferenceException` without an explicit `if` check.

For a broader look at null-safe operators, see [C# null operators](../null-safety/null-operators.md).

## See also

- [C# operators and expressions (language reference)](../../language-reference/operators/index.md) — full precedence table and every operator
- [Arithmetic, comparison, logical, and assignment operators](operators.md) — the everyday operators in depth
- [Equality comparisons](equality.md) — how `==`, `!=`, and `Equals` work
- [C# null operators](../null-safety/null-operators.md) — `?.`, `??`, and `??=`
- [Boolean logical operators](../../language-reference/operators/boolean-logical-operators.md)
