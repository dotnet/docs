---
title: "Built-in types - C# reference"
description: "Learn C# built-in value and reference types"
ms.date: 03/15/2021
helpviewer_keywords:
  - "types [C#], built-in"
  - "built-in C# types"
---
# Built-in types (C# reference)

The following table lists the C# built-in [value](value-types.md) types:

|C# type keyword|.NET type|
|--------------|-------------------------|
|[`bool`](bool.md)|<xref:System.Boolean?displayProperty=nameWithType>|
|[`byte`](integral-numeric-types.md)|<xref:System.Byte?displayProperty=nameWithType>|
|[`sbyte`](integral-numeric-types.md)|<xref:System.SByte?displayProperty=nameWithType>|
|[`char`](char.md)|<xref:System.Char?displayProperty=nameWithType>|
|[`decimal`](floating-point-numeric-types.md)|<xref:System.Decimal?displayProperty=nameWithType>|
|[`double`](floating-point-numeric-types.md)|<xref:System.Double?displayProperty=nameWithType>|
|[`float`](floating-point-numeric-types.md)|<xref:System.Single?displayProperty=nameWithType>|
|[`int`](integral-numeric-types.md)|<xref:System.Int32?displayProperty=nameWithType>|
|[`uint`](integral-numeric-types.md)|<xref:System.UInt32?displayProperty=nameWithType>|
|[`nint`](integral-numeric-types.md)|<xref:System.IntPtr?displayProperty=nameWithType>|
|[`nuint`](integral-numeric-types.md)|<xref:System.UIntPtr?displayProperty=nameWithType>|
|[`long`](integral-numeric-types.md)|<xref:System.Int64?displayProperty=nameWithType>|
|[`ulong`](integral-numeric-types.md)|<xref:System.UInt64?displayProperty=nameWithType>|
|[`short`](integral-numeric-types.md)|<xref:System.Int16?displayProperty=nameWithType>|
|[`ushort`](integral-numeric-types.md)|<xref:System.UInt16?displayProperty=nameWithType>|

The following table lists the C# built-in [reference](../keywords/reference-types.md) types:

|C# type keyword|.NET type|
|--------------|-------------------------|
|[`object`](reference-types.md#the-object-type)|<xref:System.Object?displayProperty=nameWithType>|
|[`string`](reference-types.md#the-string-type)|<xref:System.String?displayProperty=nameWithType>|
|[`dynamic`](reference-types.md#the-dynamic-type)|<xref:System.Object?displayProperty=nameWithType>|

In the preceding tables, each C# type keyword from the left column (except [dynamic](reference-types.md#the-dynamic-type)) is an alias for the corresponding .NET type. They are interchangeable. For example, the following declarations declare variables of the same type:

```csharp
int a = 123;
System.Int32 b = 123;
```

The [`void`](void.md) keyword represents the absence of a type. You use it as the return type of a method that doesn't return a value.

## See also

- [Use language keywords instead of framework type names (style rule IDE0049)](../../../fundamentals/code-analysis/style-rules/ide0049.md)
- [C# reference](../index.md)
- [Default values of C# types](default-values.md)
