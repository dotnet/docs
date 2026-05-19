---
title: "The nameof operator in C#"
description: Use the nameof operator to capture an identifier as a compile-time string for argument validation, change notifications, attributes, and logging.
ms.date: 05/08/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# The `nameof` operator

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. For the complete operator reference, see [`nameof`](../../language-reference/operators/nameof.md) in the language reference.
>
> **Coming from another language?** Other languages have similar features. Java's reflective `Class.getSimpleName()`, JavaScript's `Function.name` and `Object.keys`, Python's `__name__` and `vars()`, and Swift's `#function`/`#keyPath`. Unlike most of those, C#'s `nameof` is a pure compile-time construct. It uses no reflection, allocates nothing at runtime, and produces a constant `string` that's baked into the assembly.

The `nameof` operator returns the textual identifier of a symbol, such as a variable, parameter, type, member, or namespace, as a compile-time `string` constant. Anywhere you'd otherwise hardcode an identifier as a string, use `nameof`: the compiler verifies that the symbol exists, and rename refactorings update the result automatically.

## What `nameof` returns

`nameof` evaluates to the *final* identifier in its operand. It runs at compile time and has no runtime cost.

:::code language="csharp" source="snippets/nameof/Program.cs" ID="Basic":::

The operand can also be a *qualified expression*, one that uses the dot operator to navigate from a containing scope to a member, such as `customer.Name`, `System.Console`, or `List<int>.Enumerator`. In that case, only the last identifier is captured: `nameof(customer.Name)` returns `"Name"`, not `"customer.Name"`.

## Argument validation

The classic use is producing the parameter name in a thrown exception. Pass `nameof(parameter)` instead of the literal string `"parameter"` so a future rename can't leave the message lying:

:::code language="csharp" source="snippets/nameof/Program.cs" ID="GuardClause":::

For null checks specifically, prefer using exception helpers. These helpers, such as <xref:System.ArgumentNullException.ThrowIfNull*>, capture the argument's name automatically through <xref:System.Runtime.CompilerServices.CallerArgumentExpressionAttribute>, so a separate `nameof` isn't needed:

:::code language="csharp" source="snippets/nameof/Program.cs" ID="ThrowIfNull":::

Use `nameof` for the cases the helpers don't cover: <xref:System.ArgumentException>, <xref:System.ArgumentOutOfRangeException> (when validating something other than a single argument), and other guard messages.

## Property change notifications

Types that implement <xref:System.ComponentModel.INotifyPropertyChanged> raise an event whose payload includes the changed property's name. Hardcoding the name as a string creates a silent bug if the property is renamed and the string isn't. Use `nameof` instead:

:::code language="csharp" source="snippets/nameof/Program.cs" ID="PersonType":::

The setter calls `OnPropertyChanged(nameof(Name))` so the property name and the change notification stay in sync. Run the example to see the events fire:

:::code language="csharp" source="snippets/nameof/Program.cs" ID="PropertyChanged":::

## `nameof` in attribute arguments

`nameof` is valid inside attribute arguments. The compiler resolves identifiers in the surrounding scope, including the parameters of the method the attribute targets. This is the idiomatic way to refer to a parameter from an attribute such as <xref:System.Diagnostics.CodeAnalysis.NotNullIfNotNullAttribute>:

:::code language="csharp" source="snippets/nameof/Program.cs" ID="AttributeUsage":::

If the parameter is renamed, the `nameof` argument is updated by the same refactoring — the attribute can't fall out of date.

## Unbound generic types

Beginning in C# 14, `nameof` accepts an *unbound* generic type. The result is the simple type name without any arity or type-argument list:

:::code language="csharp" source="snippets/nameof/Program.cs" ID="UnboundGenerics":::

This is useful in logging, diagnostic messages, and attribute arguments where the generic type name matters but the type arguments don't.

## Qualified names

For any qualified expression, `nameof` returns only the *last* identifier:

:::code language="csharp" source="snippets/nameof/Program.cs" ID="QualifiedName":::

If you need the fully qualified name, use <xref:System.Type.FullName?displayProperty=nameWithType> on a `Type` instance. `nameof` is for identifiers, not paths.

## Prefer `nameof` to identifier strings

Anywhere you refer to a method, property, parameter, type, or namespace by name in code, use `nameof` instead of a string literal. Compared to a hardcoded string:

- The compiler verifies that the symbol exists. A typo becomes a build error, not a silent runtime bug.
- Rename refactorings update the result automatically. Hardcoded strings drift out of sync.
- The result is a compile-time constant, so there's no runtime cost.

This recommendation applies to logging messages, exception arguments, attribute arguments, property-change notifications, and serialization key constants tied to a member name.

## See also

- [Strings overview](index.md)
- [Raw string literals](raw-string-literals.md)
- [`nameof` operator (language reference)](../../language-reference/operators/nameof.md)
- <xref:System.ArgumentNullException.ThrowIfNull*>
- <xref:System.ComponentModel.INotifyPropertyChanged>
