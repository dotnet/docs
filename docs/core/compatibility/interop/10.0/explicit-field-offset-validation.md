---
title: "Breaking change: Disallow loading non-Explicit types with explicit field offsets"
description: "Learn about the breaking change in .NET 10 where the runtime enforces stricter validation for type layouts and throws TypeLoadException if non-explicit layout types specify explicit field offsets."
ms.date: 10/13/2025
ai-usage: ai-assisted
---

# Disallow loading non-Explicit types with explicit field offsets

The .NET runtime now enforces stricter validation for type layouts. Specifically, the runtime throws a <xref:System.TypeLoadException> if a type with a non-explicit layout (for example, <xref:System.Runtime.InteropServices.LayoutKind.Auto> or <xref:System.Runtime.InteropServices.LayoutKind.Sequential>) specifies explicit field offsets using <xref:System.Runtime.InteropServices.FieldOffsetAttribute>. This change aligns the runtime's behavior with the ECMA-335 specification, which only permits explicit field offsets for types with an `Explicit` layout.

## Version introduced

.NET 10 Preview 4

## Previous behavior

In earlier versions of .NET, the runtime ignored explicit field offsets on types with `Auto` or `Sequential` layouts. For example, the following code executed without error, and the `[FieldOffset]` attributes were ignored:

```csharp
using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct MyStruct
{
    [FieldOffset(0)] // Ignored prior to .NET 10.
    public int Field1;

    [FieldOffset(4)] // Ignored prior to .NET 10.
    public int Field2;
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Struct loaded successfully.");
    }
}
```

## New behavior

Starting in .NET 10, the runtime enforces the ECMA-335 specification and throws a <xref:System.TypeLoadException> if a type with `Auto` or `Sequential` layout specifies explicit field offsets. The following code now throws an exception:

```csharp
using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct MyStruct
{
    [FieldOffset(0)] // TypeLoadException.
    public int Field1;

    [FieldOffset(4)] // TypeLoadException.
    public int Field2;
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Struct loaded successfully.");
    }
}
```

**Exception thrown:**

```output
System.TypeLoadException: Explicit field offsets are not allowed on types with Sequential or Auto layout.
```

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility) and is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was introduced to align the .NET runtime with the ECMA-335 specification, which explicitly disallows explicit field offsets on types with `Auto` or `Sequential` layouts. The previous behavior of ignoring these offsets was non-compliant and could lead to unexpected behavior or incorrect assumptions about memory layout.

## Recommended action

To resolve this issue, update your code to use <xref:System.Runtime.InteropServices.LayoutKind.Explicit?displayProperty=nameWithType> for types that specify explicit field offsets. For example:

```csharp
using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)] // Use Explicit layout
public struct MyStruct
{
    [FieldOffset(0)]
    public int Field1;

    [FieldOffset(4)]
    public int Field2;
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Struct loaded successfully.");
    }
}
```

Alternatively, if explicit field offsets aren't required, remove the <xref:System.Runtime.InteropServices.FieldOffsetAttribute> attributes and rely on the default behavior of `Sequential` or `Auto` layout.

## Affected APIs

This change does not directly affect specific APIs but impacts the run-time behavior of types defined with the following attributes:

- `[StructLayout(LayoutKind.Sequential)]`
- `[StructLayout(LayoutKind.Auto)]`
- `[FieldOffset]`

## See also

- [ECMA-335 specification](https://www.ecma-international.org/publications-and-standards/standards/ecma-335/)
- [Customize structure marshalling](../../../../standard/native-interop/customize-struct-marshalling.md)
