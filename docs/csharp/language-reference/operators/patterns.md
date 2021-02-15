---
title: "Patterns - C# reference"
description: "Learn about the patterns supported by C# switch and is expressions and C# switch statement - C# reference"
ms.date: 02/15/2021
helpviewer_keywords: 
  - "pattern matching [C#]"
---
# Patterns (C# reference)

Intro.

## Declaration and type patterns

The *declaration pattern* has the following form:

```csharp
T v
```

where `T` is the name of a type or a type parameter and `v` is the name of a new local variable of type `T`.

Declaration pattern `T v` matches expression `E` when the result of `E` is non-null and any of the following conditions is true:

- the runtime type of `E` is `T`
- the runtime type of `E` derives from type `T` or implements interface `T` or there exists another [implicit reference conversion](~/_csharplang/spec/conversions.md#implicit-reference-conversions) from it to type `T`
- the runtime type of `E` is a [nullable value type](../builtin-types/nullable-value-types.md) with the underlying type `T`
- there exists a [boxing](../../programming-guide/types/boxing-and-unboxing.md#boxing) or [unboxing](../../programming-guide/types/boxing-and-unboxing.md#unboxing) conversion from the runtime type of `E` to type `T`

When `T v` matches `E`, the converted value of the result of `E` is assigned to variable `v`.

The following example demonstrates the declaration pattern with the `is` operator:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePattern.cs" id="IsExpression":::

When you use the declaration pattern with the `is` operator within the `if` statement, like in the preceding example, declared variables are assigned and can be used within the `if` statement only. For more information about the scope of variables, see the [Scope of pattern variables](~/_csharplang/proposals/csharp-7.0/pattern-matching.md#scope-of-pattern-variables) section of the [feature proposal note](~/_csharplang/proposals/csharp-7.0/pattern-matching.md).

The following example demonstrates the declaration pattern within the `switch` expression:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePattern.cs" id="SwitchExpression":::

In a `switch` expression, the scope of the declared variable is the corresponding switch expression arm. In a `switch` statement, the scope of the declared variable is the corresponding switch section.

If you want to check only the type of an expression, you can use a discard `_` in place of a variable name like the following example shows:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePattern.cs" id="DiscardVariable":::

Beginning with C# 9.0, for that purpose you can use the *type pattern* as the following example shows:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePattern.cs" id="TypePattern":::

The declaration pattern is available in C# 7.0 and later.

## C# language specification

For more information, see the following feature proposal notes:

- [Pattern matching for C# 7.0](~/_csharplang/proposals/csharp-7.0/pattern-matching.md)
- [Recursive pattern matching (introduced in C# 8.0)](~/_csharplang/proposals/csharp-8.0/patterns.md)
- [Pattern-matching changes for C# 9.0](~/_csharplang/proposals/csharp-9.0/patterns3.md)

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [Tutorial: Use pattern matching to build type-driven and data-driven algorithms](../../tutorials/pattern-matching.md)
