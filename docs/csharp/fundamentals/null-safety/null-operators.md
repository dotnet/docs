---
title: "Null operators in C#"
description: Learn how to use the null-conditional (?. and ?[]), null-coalescing (??), null-coalescing assignment (??=), and null pattern (is null) operators to write null-safe C# code.
ms.date: 04/30/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# C# null operators

> [!TIP]
> This article is part of the **Fundamentals** section for developers who know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. For the complete operator reference, see [Member access operators](../../language-reference/operators/member-access-operators.md) and [null-coalescing operators](../../language-reference/operators/null-coalescing-operator.md) in the language reference.

C# provides several operators that make null-safe code concise. Instead of nesting `if (x != null)` guards throughout your code, these operators let you express null-safe access, fallback values, and null tests in a single expression.

This article covers `?.` and `?[]` for null-conditional access, `??` for null-coalescing, `??=` for null-coalescing assignment, and `is null`/`is not null` for null pattern matching.

## Null-conditional member access `?.`

The `?.` operator accesses a member only when the object is non-null. When the object is `null`, the entire expression evaluates to `null` instead of throwing a <xref:System.NullReferenceException>:

:::code language="csharp" source="snippets/null-operators/Program.cs" ID="NullConditionalMember":::

The `?.` operator *short-circuits*: when the left-hand side is `null`, everything to the right is skipped. No method calls run and no side effects occur.

You can chain multiple `?.` operators in a single expression. The chain stops at the first `null` it encounters:

:::code language="csharp" source="snippets/null-operators/Program.cs" ID="NullConditionalMemberChain":::

## Null-conditional indexer access `?[]`

The `?[]` operator applies the same short-circuit behavior to indexer and array access. Use it when the collection itself might be `null`:

:::code language="csharp" source="snippets/null-operators/Program.cs" ID="NullConditionalIndexer":::

## Chain null-conditional operators

Chain multiple `?.` operators to traverse a path of potentially null references. The chain short-circuits at the first `null`:

:::code language="csharp" source="snippets/null-operators/Program.cs" ID="NullConditionalChain":::

When `Customer` is `null`, neither `Address` nor `City` is evaluated. The whole expression returns `null`.

## Thread-safe delegate invocation

`?.` provides a clean, thread-safe way to invoke a delegate or raise an event. The delegate expression is evaluated only once, so there's no window for another thread to unsubscribe between the null check and the invocation:

:::code language="csharp" source="snippets/null-operators/Program.cs" ID="NullConditionalDelegate":::

This pattern replaces the older `if (clicked != null) clicked(...)` idiom.

## Null-coalescing `??`

The `??` operator returns its left-hand operand when it's non-null, and its right-hand operand when the left is `null`. Use it to provide a default value:

:::code language="csharp" source="snippets/null-operators/Program.cs" ID="NullCoalescing":::

`??` is right-associative, so `a ?? b ?? c` evaluates as `a ?? (b ?? c)`. The first non-null value wins. A common pattern is to chain `?.` with `??`: use `?.` to safely traverse a null-possible chain, then `??` to substitute a default if the chain returned `null`. For a complete example, see [Combine null operators](#combine-null-operators).

## Null-coalescing assignment `??=`

The `??=` operator assigns the right-hand value to a variable only when the variable is `null`. Use it for lazy initialization:

:::code language="csharp" source="snippets/null-operators/Program.cs" ID="NullCoalescingAssignment":::

The right-hand expression is evaluated only when the variable is `null`. When the variable already has a value, the right side isn't evaluated at all.

## Null-conditional assignment (C# 14)

Beginning in C# 14, you can use `?.` and `?[]` as assignment targets. The assignment runs only when the left-hand object is non-null:

:::code language="csharp" source="snippets/null-operators/Program.cs" ID="NullConditionalAssignment":::

The right-hand side is evaluated only when the left-hand side is known to be non-null.

## Null pattern matching: `is null` and `is not null`

The `is null` and `is not null` patterns test whether an expression is `null`:

:::code language="csharp" source="snippets/null-operators/Program.cs" ID="IsNull":::

Prefer `is null` over `== null` for null checks. The `==` operator can be overloaded, meaning `x == null` might return `true` even when `x` isn't `null` if the type defines a custom equality operator. The `is null` pattern always tests for the actual null reference, regardless of operator overloading.

:::code language="csharp" source="snippets/null-operators/Program.cs" ID="IsNotNull":::

## Combine null operators

In practice, you often combine several of these operators. One expression can safely traverse a deep object graph, apply a fallback, and then guard on the result:

:::code language="csharp" source="snippets/null-operators/Program.cs" ID="CombinedPattern":::

## Null-forgiving operator `!`

The `!` postfix operator suppresses nullable warnings. Append `!` to tell the compiler "this expression is definitely not null." The operator has no effect at runtime. It only affects the compiler's null-state analysis.

:::code language="csharp" source="snippets/null-operators/Program.cs" ID="NullForgiving":::

Use `!` sparingly, and only when you have information the compiler doesn't. Examples include tests that intentionally pass `null` to validate argument-checking logic, or calling a method whose contract guarantees a non-null return for a known input. Overusing `!` defeats the purpose of nullable reference types. For a full explanation, see [Nullable reference types](../../nullable-references.md).

## See also

- [Null safety overview](index.md)
- [Nullable value types](nullable-value-types.md)
- [Nullable reference types](../../nullable-references.md)
- [Member access operators (language reference)](../../language-reference/operators/member-access-operators.md)
- [Null-coalescing operators (language reference)](../../language-reference/operators/null-coalescing-operator.md)
