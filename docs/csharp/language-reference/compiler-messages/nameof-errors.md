---
title: "Resolve errors and warnings related to nameof expressions"
description: "This article helps you diagnose and correct compiler errors and warnings related to nameof expressions"
f1_keywords:
  - "CS8081"
  - "CS8082"
  - "CS8084"
  - "CS8093"
helpviewer_keywords:
  - "CS8081"
  - "CS8082"
  - "CS8084"
  - "CS8093"
ms.date: 10/30/2026
ai-usage: ai-assisted
---

# Resolve errors and warnings for nameof expressions

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

- [**CS8081**](#use-an-expression-that-names-a-symbol): *Expression does not have a name.*
- [**CS8082**](#use-an-expression-that-names-a-symbol): *Sub-expression cannot be used in an argument to nameof.*
- [**CS8084**](#correct-method-group-references): *Type parameters are not allowed on a method group as an argument to 'nameof'.*
- [**CS8093**](#correct-method-group-references): *Extension method groups are not allowed as an argument to 'nameof'.*

## Use an expression that names a symbol

- **CS8081**: *Expression does not have a name.*
- **CS8082**: *Sub-expression cannot be used in an argument to nameof.*

- Pass the name of a variable, type, or member rather than an expression that computes a value. For example, replace `nameof(value + 1)` with `nameof(value)` to obtain the variable's name (**CS8081**).
- Replace an invocation, element access, or other unsupported subexpression in a member reference with a type or variable name. For example, replace `nameof(GetText().Length)` with `nameof(string.Length)` to obtain the property's name without invoking a method (**CS8082**).

For valid operand forms, see the [nameof expression](../operators/nameof.md).

## Correct method-group references

- **CS8084**: *Type parameters are not allowed on a method group as an argument to 'nameof'.*
- **CS8093**: *Extension method groups are not allowed as an argument to 'nameof'.*

- Omit the method's type argument list. For a generic method declared as `Method<T>()`, use `nameof(Method)` rather than `nameof(Method<int>)` (**CS8084**). Naming a generic method is valid; supplying its type arguments in this form isn't. This restriction is separate from support for unbound generic *types*, such as `nameof(List<>)`, in C# 14 and later.
- Reference an extension method through the static class that declares it rather than through its receiver. For an extension method declared in `TextExtensions`, replace `nameof(text.Extension)` with `nameof(TextExtensions.Extension)` (**CS8093**).

For extension method declaration and invocation forms, see [Extension members](../../programming-guide/classes-and-structs/extension-methods.md).

## C# language specification

For more information, see [The nameof operator](~/_csharpstandard/standard/expressions.md#12823-the-nameof-operator) in the C# language specification.
