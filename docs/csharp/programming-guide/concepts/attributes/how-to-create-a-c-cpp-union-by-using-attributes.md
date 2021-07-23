---
title: "How to create a C/C++ union by using attributes (C#)"
description: Learn how to use attributes to customize how structs are laid out in memory in C#. This example implements the equivalent of a union from C/C++.
ms.date: 07/20/2015
ms.topic: how-to
ms.assetid: 85f35e56-26e0-4d31-9f3a-89bd4005e71a
---
# How to create a C/C++ union by using attributes (C#)

By using attributes, you can customize how structs are laid out in memory. For example, you can create what is known as a union in C/C++ by using the `StructLayout(LayoutKind.Explicit)` and `FieldOffset` attributes.

## Examples

In this code segment, all of the fields of `TestUnion` start at the same location in memory.

```csharp
// Add a using directive for System.Runtime.InteropServices.

[System.Runtime.InteropServices.StructLayout(LayoutKind.Explicit)]
struct TestUnion
{
    [System.Runtime.InteropServices.FieldOffset(0)]
    public int i;

    [System.Runtime.InteropServices.FieldOffset(0)]
    public double d;

    [System.Runtime.InteropServices.FieldOffset(0)]
    public char c;

    [System.Runtime.InteropServices.FieldOffset(0)]
    public byte b;
}
```

The following is another example where fields start at different explicitly set locations.

```csharp
// Add a using directive for System.Runtime.InteropServices.

[System.Runtime.InteropServices.StructLayout(LayoutKind.Explicit)]
struct TestExplicit
{
    [System.Runtime.InteropServices.FieldOffset(0)]
    public long lg;

    [System.Runtime.InteropServices.FieldOffset(0)]
    public int i1;

    [System.Runtime.InteropServices.FieldOffset(4)]
    public int i2;

    [System.Runtime.InteropServices.FieldOffset(8)]
    public double d;

    [System.Runtime.InteropServices.FieldOffset(12)]
    public char c;

    [System.Runtime.InteropServices.FieldOffset(14)]
    public byte b;
}
```

The two integer fields, `i1` and `i2`, share the same memory locations as `lg`. This sort of control over struct layout is useful when using platform invocation.

## See also

- <xref:System.Reflection>
- <xref:System.Attribute>
- [C# Programming Guide](../../index.md)
- [Attributes](../../../../standard/attributes/index.md)
- [Reflection (C#)](../reflection.md)
- [Attributes (C#)](index.md)
- [Creating Custom Attributes (C#)](creating-custom-attributes.md)
- [Accessing Attributes by Using Reflection (C#)](accessing-attributes-by-using-reflection.md)
