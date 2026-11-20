---
title: Class accessibility
description: Use public, private, and internal access in C# classes, recognize the default accessibility, and understand how containing types limit access.
ms.date: 11/16/2026
ms.topic: concept-article
ai-usage: ai-generated
---

# Class accessibility

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from another language?** If you've used [Java access modifiers](https://docs.oracle.com/javase/tutorial/java/javaOO/accesscontrol.html), you'll recognize `public` and `private`. Use the C# defaults and containing-type rules below to decide where your declarations are accessible.

Use this article after [Class members and instances](index.md) to control which code can use a class and its members.

*Accessibility* determines which code can name and use a type or member. An *access modifier* is a keyword, such as `public` or `private`, that specifies that access. The [access modifiers reference](../../language-reference/keywords/access-modifiers.md) describes all supported combinations.

Start with these common access modifiers:

- [`private`](../../language-reference/keywords/private.md) limits access to the containing type.
- [`public`](../../language-reference/keywords/public.md) allows access from any code, provided the containing type is also accessible.
- [`internal`](../../language-reference/keywords/internal.md) limits access to the same *assembly*, a compiled unit of .NET code, usually a `.dll` or `.exe` file. A C# project normally produces one assembly. See [Assemblies in .NET](../../../standard/assembly/index.md).
- [`protected`](../../language-reference/keywords/protected.md) limits access to the containing class and its *derived classes*, the classes that inherit from it, even in another assembly.

## Separate public capabilities from implementation

Use `public` for the members you want callers to use and `private` for implementation details used inside the class. These public members form the class's *public interface*, the operations and values it exposes to callers. Here, "interface" describes the class's exposed members, rather than a separate C# `interface` type. For example, you can expose the counter's operations and keep its fields private:

:::code language="csharp" source="snippets/index/Program.cs" id="CounterDeclaration":::

Through the `public` methods, you can add a visit or read a count. Direct access to the `private` fields stays inside `VisitCounter`:

:::code language="csharp" source="snippets/index/Program.cs" id="PublicAccess":::

Accessibility lets you limit the scope of where change can happen. Keep fields and helper methods private when they're implementation details, so you can change them within the class while preserving its public interface. Callers then depend on the operations you expose, rather than on how you implement them. In the counter, `AddVisit` keeps the instance count and total in sync.

## Default accessibility

For clearer code, always declare accessibility explicitly. Readers can then see your intent without having to memorize the defaults.

The default accessibility for a type depends on where it's declared. Start with a class declared directly in a namespace. A namespace groups names and imposes no access restriction of its own, so the class's declared accessibility determines where you can use it:

- Use `internal` to limit access to the same assembly.
- Use `public` to make the class available to any code that references its assembly.

If you omit an access modifier on a namespace-level class, its accessibility defaults to `internal`. If you omit the modifier on a class member, including a nested type, that member defaults to `private`. For example:

:::code language="csharp" source="snippets/index/Program.cs" id="DefaultAccess":::

`LocalCounter` is internal, and `count` is private. Although `GetCount` is public, code in another assembly can't name `LocalCounter` to call it.

To access a member or nested type, your code must satisfy both its accessibility and its containing type's accessibility. Apply the same rule at every level of nesting: each containing type must also allow access. For example, a public nested type inside an internal class is available only where that containing class is accessible. See [Accessibility domain](../../language-reference/keywords/accessibility-domain.md) for the full model.

Use the same defaults for explicitly declared members of record classes. A [positional record class](../types/records.md#declare-a-record) normally generates public properties for its parameters.

## Recognize other access modifiers

You'll encounter other accessibility modifiers as you learn more about classes. The Get started [roadmap for Java developers](../../tour-of-csharp/tips-for-java-developers.md) introduces the familiar `public` and `private` keywords. Use the [access modifiers reference](../../language-reference/keywords/access-modifiers.md) for the complete set of choices.

As you work with [inheritance](../object-oriented/inheritance.md), you'll use `protected` for access within a class and its derived classes. For combinations such as `protected internal` and `private protected`, consult the [accessibility levels reference](../../language-reference/keywords/accessibility-levels.md). For a type used only within one source file, see the [`file` modifier](../../language-reference/keywords/file.md).

Accessible members must also use sufficiently accessible types. For example, a public method on a public class can't return a private nested type. Otherwise, callers could reach a method whose result type they can't name. For signature constraints and specialized cases, see [Accessibility restrictions](../../language-reference/keywords/restrictions-on-using-accessibility-levels.md).

## Next steps

- Use [Fields and constants](fields-constants.md) for state declarations.
- Use [Properties](../../programming-guide/classes-and-structs/properties.md) to expose values through accessors.
- Use the existing [accessibility guide](../../programming-guide/classes-and-structs/access-modifiers.md) for other type kinds, friend assemblies, and inheritance-related access details.
