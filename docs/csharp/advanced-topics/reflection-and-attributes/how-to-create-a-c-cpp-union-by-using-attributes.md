---
title: "How to create a C/C++ union by using attributes (C#)"
description: Learn how to use attributes to customize how structs are laid out in memory in C#. This example implements the equivalent of a union from C/C++.
ms.date: 03/15/2023
ms.topic: how-to
---
# How to create a C/C++ union by using attributes in C\#

By using attributes, you can customize how structs are laid out in memory. For example, you can create what is known as a union in C/C++ by using the `StructLayout(LayoutKind.Explicit)` and `FieldOffset` attributes.

In this code segment, all of the fields of `TestUnion` start at the same location in memory.

:::code language="csharp" source="./snippets/conceptual/CStyleUnion.cs" id="SameLocation":::

The following code is another example where fields start at different explicitly set locations.

:::code language="csharp" source="./snippets/conceptual/CStyleUnion.cs" id="ExplicitLayout":::

The two integer fields, `i1` and `i2` combined, share the same memory locations as `lg`. Either `lg` uses the first 8 bytes, or `i1` uses the first 4 bytes and `i2` uses the next 4 bytes. This sort of control over struct layout is useful when using platform invocation.

## See also

- <xref:System.Reflection>
- <xref:System.Attribute>
- [Attributes](../../../standard/attributes/index.md)
