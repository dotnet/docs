---
title: "Type patterns"
description: Learn how C# type patterns test run-time types in is expressions, switch statements, switch expressions, and generic code.
ms.date: 09/14/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Type patterns

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. Read [generic types and methods](../types/generics.md) first if type parameters such as `T` are new to you. For the complete conversion rules, see [declaration and type patterns](../../language-reference/operators/patterns.md#declaration-and-type-patterns) in the language reference.

A *type pattern* tests whether a non-null value's run-time type is compatible with a specified type. Unlike a [declaration pattern](declaration-constant-var-patterns.md#test-and-capture-a-type-with-a-declaration-pattern), a type pattern doesn't create a variable. The expressions `value is SomeType` and `value is SomeType _` perform equivalent type tests when both forms are valid:

:::code language="csharp" source="snippets/patterns/TypePatterns.cs" ID="TypePattern":::

> [!NOTE]
> Beginning with C# 15, which is currently in preview, a type pattern on a [union type](../../language-reference/builtin-types/union.md#union-pattern-matching) generally tests the union's `Value`, not the union value itself.

Use a type pattern when the type test itself is all you need. Use a declaration pattern when the matching branch needs members that are available only on the more specific type.

## Match several types

Type patterns are useful in a switch expression when the result depends on the kind of value, but not on the value's members:

:::code language="csharp" source="snippets/patterns/TypePatterns.cs" ID="TypePatternSwitch":::

The switch arms are checked from top to bottom. Put a derived type before its base type. If the `Stream` arm appeared before the `MemoryStream` arm, every `MemoryStream` value would match `Stream` first, and the compiler would report that the later arm is unreachable.

A type pattern doesn't match `null`, so the `null` arm remains distinct. The final discard arm handles every other value.

## Type compatibility

A type pattern is allowed when the input's compile-time type and the pattern type are pattern compatible. At run time, it can match when the value:

- is the specified type,
- derives from the specified class,
- implements the specified interface,
- can be boxed to or unboxed from the specified type, or
- comes from a nullable value type that contains a value compatible with the specified type.

Type patterns don't use user-defined conversions. For example, if a class defines a conversion to `string`, a `string` type pattern still doesn't match an instance of that class. The pattern tests the value's run-time type rather than asking the program to convert the value.

## Use type patterns with generics

Generic code can test a value against another type parameter. A *type parameter* is the placeholder, such as `T`, in a generic method declaration. A *type argument* is the actual type supplied when the method is called.

The following method reports whether a value of type `TInput` is also compatible with `TMatch`:

:::code language="csharp" source="snippets/patterns/TypePatterns.cs" ID="GenericTypePattern":::

The pattern works whether the type arguments are reference types or value types. It also works when `TInput` is unconstrained. The pattern returns `false` when `value` is `null`.

Use a declaration pattern instead when generic code needs the matching value with the tested type:

:::code language="csharp" source="snippets/patterns/TypePatterns.cs" ID="GenericDeclarationPattern":::

After the declaration pattern matches, `match` has the compile-time type `TMatch`, so the method can return it without a cast.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Declaration, constant, and `var` patterns](declaration-constant-var-patterns.md)
- [Generic types and methods](../types/generics.md)
- [Type-testing and cast operators](../../language-reference/operators/type-testing-and-cast.md)
- [Type pattern reference](../../language-reference/operators/patterns.md#declaration-and-type-patterns)
