---
description: "Accessibility Domain - C# Reference"
title: "Accessibility Domain"
ms.date: 01/21/2026
helpviewer_keywords: 
  - "accessibility domain [C#]"
---
# Accessibility domain (C# reference)

The accessibility domain of a member specifies the program sections where you can reference that member. If the member is nested within another type, both the [accessibility level](./accessibility-levels.md) of the member and the accessibility domain of the immediately containing type determine its accessibility domain.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

The accessibility domain of a top-level type always includes at least the program text of the project where you declare it. In other words, the domain includes all source files in the project. The accessibility domain of a nested type always includes at least the program text of the type where you declare it. In other words, the domain is the type body, which includes all nested types. The accessibility domain of a nested type never exceeds that of the containing type. The following example demonstrates these concepts.

This example contains a top-level type, `T1`, and two nested classes, `M1` and `M2`. The classes contain fields that have different declared accessibilities. In the `Main` method, a comment follows each statement to indicate the accessibility domain of each member. The statements that try to reference the inaccessible members are commented out. If you want to see the compiler errors caused by referencing an inaccessible member, remove the comments one at a time.

:::code language="csharp" source="snippets/csrefKeywordsModifiers.cs" id="4":::

## C# Language Specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Keywords](./index.md)
- [Access Modifiers](./access-modifiers.md)
- [Accessibility Levels](./accessibility-levels.md)
- [Restrictions on Using Accessibility Levels](./restrictions-on-using-accessibility-levels.md)
- [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md)
- [public](./public.md)
- [private](./private.md)
- [protected](./protected.md)
- [internal](./internal.md)
