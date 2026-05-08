---
title: "Null safety in C#"
description: Learn how C# helps you write null-safe code using nullable value types, nullable reference types, and null operators.
ms.date: 04/30/2026
ms.topic: overview
ai-usage: ai-assisted
---

# C# null safety

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from Java or C++?** C# provides compile-time null safety through nullable reference types. The goal is similar to Java's `@NonNull` annotations but enforced by the compiler. C# also has dedicated operators like `?.` and `??` that make null-safe expressions concise.

`null` represents the absence of a value. When you try to access a member on a `null` reference, by calling a method or reading a property, the runtime throws a <xref:System.NullReferenceException>:

:::code language="csharp" source="snippets/null-safety-overview/Program.cs" ID="NullReferenceDemo":::

C# gives you three complementary tools to write null-safe code:

- **Nullable value types**: let a value type such as `int` or `bool` also hold `null`
- **Nullable reference types**: let the compiler track whether a reference might be `null`
- **Null operators**: express null-safe access and fallback logic concisely

## Nullable value types

Value types such as `int`, `double`, and `bool` can't hold `null` by default. Add `?` to the type name to create a *nullable value type* that holds either a value or `null`:

:::code language="csharp" source="snippets/null-safety-overview/Program.cs" ID="NvtIntro":::

Nullable value types are useful when an underlying value type needs to represent "no data." Common scenarios include database columns that might be absent, optional configuration settings, and sensor readings that aren't captured yet.

For full coverage of declaration, checking, and conversion, see [Nullable value types](nullable-value-types.md).

## Nullable reference types

Reference types, such as `string`, arrays, and class instances, can hold `null` at runtime. *Nullable reference types* is a compiler feature that makes null intent explicit and catches mistakes at compile time.

By using the `?` annotation, you declare your intent:

- `string?` — this reference *might* be `null`; the compiler warns if you dereference it without checking first
- `string` — this reference *should not* be `null`; the compiler warns if you assign `null` to it

:::code language="csharp" source="snippets/null-safety-overview/Program.cs" ID="NrtIntro":::

All .NET projects that modern SDK templates create enable nullable reference types by default. For complete guidance on enabling and annotating, see [Nullable reference types](../../nullable-references.md).

## Null operators

C# includes several operators that let you write null-safe code without manual `if`-null guards everywhere:

| Operator                  | Name                            | Purpose                                                |
|---------------------------|---------------------------------|--------------------------------------------------------|
| `?.`                      | Null-conditional member access  | Access a member only when the object is non-null       |
| `?[]`                     | Null-conditional indexer access | Access an element only when the collection is non-null |
| `??`                      | Null-coalescing                 | Return a fallback value when the expression is `null`  |
| `??=`                     | Null-coalescing assignment      | Assign only when the variable is `null`                |
| `is null` / `is not null` | Null pattern                    | Preferred null test                                    |

:::code language="csharp" source="snippets/null-safety-overview/Program.cs" ID="OperatorsQuickRef":::

For detailed examples of each operator, see [Null operators](null-operators.md).

## Nullable value types and nullable reference types serve different purposes

Nullable value types and nullable reference types aren't alternatives. They solve different problems:

- Use `T?` for a value type that needs to represent "no value." For example, use `int?` for an optional database column or `DateTime?` for an event that isn't scheduled yet.
- Use `string?` and other nullable reference annotations to document that a reference *might* be `null`, so the compiler can warn you before a `NullReferenceException` occurs at runtime.

Together, these features and the null operators give you a complete set of tools to write null-safe C# code.
