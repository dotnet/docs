---
title: Class accessibility
description: Use public, private, and internal access in C# classes, recognize the default accessibility, and understand how containing types limit access.
ms.date: 11/16/2026
ms.topic: concept-article
ai-usage: ai-generated
---

# Class accessibility

Use this article after [Class members and instances](index.md) to control which code can use a class and its members.

*Accessibility* determines which code can name and use a type or member. An *access modifier* is a keyword, such as `public` or `private`, that specifies that access. The [access modifiers reference](../../language-reference/keywords/access-modifiers.md) describes all supported combinations.

## Public operations and private state

The counter exposes operations and keeps its fields private:

:::code language="csharp" source="snippets/index/Program.cs" id="CounterDeclaration":::

The `public` methods let other code add a visit or read a count. Only code inside `VisitCounter` can directly read or assign the `private` fields:

:::code language="csharp" source="snippets/index/Program.cs" id="PublicAccess":::

If you add `counter.count = 10;` outside `VisitCounter`, the compiler reports CS0122 because `count` is inaccessible. `public` doesn't mean "instance member," and `private` doesn't mean "static member." The example contains both public instance methods and a public static method.

Private state lets the class control changes. Here, `AddVisit` updates the instance count and the total together. Code outside the class can't change one of those fields directly.

## Defaults and containing types

An *assembly* is a compiled unit of .NET code, usually a `.dll` or `.exe` file. A project normally produces an assembly. See [Assemblies in .NET](../../../standard/assembly/index.md).

For classes, recognize these everyday defaults:

- A class declared directly in a namespace defaults to `internal`. Code in the same assembly can use it.
- A class member, including a nested type, defaults to `private`.
- A `public` class declared directly in a namespace is available to other assemblies that reference its assembly.

For example:

:::code language="csharp" source="snippets/index/Program.cs" id="DefaultAccess":::

`LocalCounter` is internal, and `count` is private. Although `GetCount` is public, code in another assembly can't name `LocalCounter` to call it. A member's declared accessibility doesn't make its containing type more accessible. The same restriction applies to a public nested type inside an internal class.

The `record` modifier doesn't change these defaults for explicitly declared class members. A [positional record class](../types/records.md#declare-a-record) normally generates public properties for its parameters.

## Recognize other access modifiers

Use `internal` for access within the assembly, whether the member is static or belongs to an instance. For a type used only within one source file, see the [`file` modifier](../../language-reference/keywords/file.md).

When you read [inheritance](../object-oriented/inheritance.md), you'll also encounter `protected` for access within a class and its derived classes. `protected internal` allows access from the same assembly **or** a derived class. `private protected` restricts access to the containing class and derived classes in the same assembly. The [accessibility levels reference](../../language-reference/keywords/accessibility-levels.md) supplies the complete rules and restrictions.

Accessible members must also use sufficiently accessible types. For example, a public method on a public class can't return a private nested type. Otherwise, callers could reach a method whose result type they can't name. For signature constraints and specialized cases, see [Accessibility restrictions](../../language-reference/keywords/restrictions-on-using-accessibility-levels.md).

## Next steps

- Use [Fields and constants](fields-constants.md) for state declarations.
- Use [Properties](../../programming-guide/classes-and-structs/properties.md) to expose values through accessors.
- Use the existing [accessibility guide](../../programming-guide/classes-and-structs/access-modifiers.md) for other type kinds, friend assemblies, and inheritance-related access details.
