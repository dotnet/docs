---
title: "Nested Types"
description: A type defined within a class, struct, or interface is called a nested type in C#. 
ms.date: 12/15/2025
helpviewer_keywords: 
  - "nested types [C#]"
---
# Nested types (C# programming guide)

A nested type is a type that you define within a [class](../../language-reference/keywords/class.md), [struct](../../language-reference/builtin-types/struct.md), or [interface](../../language-reference/keywords/interface.md). For example:

:::code language="csharp" source="./snippets/access-modifiers/nestedtypes.cs" id="DeclareNestedClass":::

Regardless of whether the outer type is a class, interface, or struct, nested types default to [private](../../language-reference/keywords/private.md). You can access them only from their containing type. In the preceding example, external types can't access the `Nested` class.

You can also specify an [access modifier](../../language-reference/keywords/access-modifiers.md) to define the accessibility of a nested type, as follows:

- Nested types of a **class** can be [public](../../language-reference/keywords/public.md), [protected](../../language-reference/keywords/protected.md), [internal](../../language-reference/keywords/internal.md), [protected internal](../../language-reference/keywords/protected-internal.md), [private](../../language-reference/keywords/private.md), or [private protected](../../language-reference/keywords/private-protected.md).

   However, defining a `protected`, `protected internal`, or `private protected` nested class inside a [sealed class](../../language-reference/keywords/sealed.md) generates compiler warning [CS0628](../../misc/cs0628.md), "new protected member declared in sealed class."

   Also be aware that making a nested type externally visible violates the code quality rule [CA1034](../../../fundamentals/code-analysis/quality-rules/ca1034.md) "Nested types should not be visible".

- Nested types of a **struct** can be [public](../../language-reference/keywords/public.md), [internal](../../language-reference/keywords/internal.md), or [private](../../language-reference/keywords/private.md).

The following example makes the `Nested` class public:

:::code language="csharp" source="./snippets/access-modifiers/nestedtypes.cs" id="PublicNestedClass":::

The nested, or inner, type can access the containing, or outer, type. To access the containing type, pass it as an argument to the constructor of the nested type. For example:

:::code language="csharp" source="./snippets/access-modifiers/nestedtypes.cs" id="DeclareNestedInstance":::

A nested type has access to all of the members that are accessible to its containing type. It can access private and protected members of the containing type, including any inherited protected members.

In the previous declaration, the full name of class `Nested` is `Container.Nested`. This is the name used to create a new instance of the nested class, as follows:

:::code language="csharp" source="./snippets/access-modifiers/nestedtypes.cs" id="UseNestedInstance":::

## See also

- [The C# type system](../../fundamentals/types/index.md)
- [Access Modifiers](./access-modifiers.md)
- [Constructors](./constructors.md)
- [CA1034 rule](../../../fundamentals/code-analysis/quality-rules/ca1034.md)
