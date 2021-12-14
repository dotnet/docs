---
description: Learn about the built-in nint and nuint types in C#
title: "nint and nuint types - C# reference"
ms.date: 03/15/2021
f1_keywords: 
  - nint_CSharpKeyword
  - nuint_CSharpKeyword
helpviewer_keywords: 
  - "nint data type [C#]"
  - "nuint data type [C#]"
---
# `nint` and `nuint` types (C# reference)

Starting in C# 9.0, you can use the `nint` and `nuint` keywords to define *native-sized integers*. These are 32-bit integers when running in a 32-bit process, or 64-bit integers when running in a 64-bit process. They can be used for interop scenarios, low-level libraries, and to optimize performance in scenarios where integer math is used extensively.

The native-sized integer types are represented internally as the .NET types <xref:System.IntPtr?displayProperty=nameWithType> and <xref:System.UIntPtr?displayProperty=nameWithType>. Unlike other numeric types, the keywords are not simply aliases for the types. The following statements are not equivalent:

```csharp
nint a = 1;
System.IntPtr a = 1;
```

The compiler provides operations and conversions for `nint` and `nuint` that are appropriate for integer types.

## Run-time native integer size

To get the size of a native-sized integer at run time, you can use `sizeof()`. However, the code must be compiled in an unsafe context. For example:

:::code language="csharp" source="snippets/shared/NativeIntegerTypes.cs" id="SizeOf":::

You can also get the equivalent value from the static <xref:System.IntPtr.Size?displayProperty=nameWithType> and <xref:System.UIntPtr.Size?displayProperty=nameWithType> properties.

## MinValue and MaxValue

To get the minimum and maximum values of native-sized integers at run time, use `MinValue` and `MaxValue` as static properties with the `nint` and `nuint` keywords, as in the following example:

:::code language="csharp" source="snippets/shared/NativeIntegerTypes.cs" id="MinMax":::

## Constants

You can use constant values in the following ranges:

* For `nint`: <xref:System.Int32.MinValue?displayProperty=nameWithType> to <xref:System.Int32.MaxValue?displayProperty=nameWithType>.
* For `nuint`: <xref:System.UInt32.MinValue?displayProperty=nameWithType> to <xref:System.UInt32.MaxValue?displayProperty=nameWithType>.

## Conversions

The compiler provides implicit and explicit conversions to other numeric types. For more information, see [Built-in numeric conversions](numeric-conversions.md).

## Literals

There's no direct syntax for native-sized integer literals. There's no suffix to indicate that a literal is a native-sized integer, such as `L` to indicate a `long`. You can use implicit or explicit casts of other integer values instead. For example:

```csharp
nint a = 42
nint a = (nint)42;
```

## Unsupported IntPtr/UIntPtr members

The following members of <xref:System.IntPtr> and <xref:System.UIntPtr> aren't supported for `nint` and `nuint` types:

* Parameterized constructors
* <xref:System.IntPtr.Add(System.IntPtr,System.Int32)>
* <xref:System.IntPtr.CompareTo%2A>
* <xref:System.IntPtr.Size> - Use [sizeof()](#run-time-native-integer-size) instead. Although `nint.Size` isn't supported, you can use `IntPtr.Size` to get an equivalent value.
* <xref:System.IntPtr.Subtract(System.IntPtr,System.Int32)>
* <xref:System.IntPtr.ToInt32%2A>
* <xref:System.IntPtr.ToInt64%2A>
* <xref:System.IntPtr.ToPointer%2A>
* <xref:System.IntPtr.Zero> - Use 0 instead.

## C# language specification

For more information, see the [C# language specification](~/_csharplang/spec/introduction.md) and the [Native-sized integers](~/_csharplang/proposals/csharp-9.0/native-integers.md) section of the C# 9.0 feature proposal notes.

## See also

- [C# reference](../index.md)
- [Value types](value-types.md)
- [Integral numeric types](integral-numeric-types.md)
- [Built-in numeric conversions](numeric-conversions.md)
