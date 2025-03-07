---
title: "Built-in types"
description: "Learn C# built-in value and reference types"
ms.date: 03/07/2025
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
|[`delegate`](reference-types.md#the-delegate-type)|<xref:System.Delegate.displayProperty=nameWithType>|
|[`dynamic`](reference-types.md#the-dynamic-type)|<xref:System.Object?displayProperty=nameWithType>|

In the preceding tables, the C# type keyword from the left column (except [delegate](reference-types.md#the-delegate-type) and [dynamic](reference-types.md#the-dynamic-type)) is an alias for the corresponding .NET type. They're interchangeable. For example, the following declarations declare variables of the same type:

```csharp
int a = 123;
System.Int32 b = 123;
```

The `dynamic` type is similar to `object`. The main differences are:

- Operations on a `dynamic` expression are bound at runtime, not at compile time.
- You can't use `new dynamic()`.
- You can't derive a type from the `dynamic` type.

The `delegate` keyword declares a type derived from <xref:System.Delegate?displayProperty=nameWithType>. `System.Delegate` type is an abstract type.

The [`void`](void.md) keyword represents the absence of a type. You use it as the return type of a method that doesn't return a value.

The C# language includes specialized rules for the <xref:System.Span`1?displayProperty=fullName> and <xref:System.ReadOnlySpan`1?displayProperty=fullName> types. These types aren't classified as built-in types, because there aren't C# keywords that correspond to these types. The C# language defines implicit conversions from array types and the string type to `Span<T>` and `ReadOnlySpan<T>`. These conversions integrate `Span` types into more natural programming scenarios. The following conversions are defined as *implicit span conversions*:

- From any single-dimensional array with element type `E` to `System.Span<E>`
- From any single-dimensional array with element type `E` to `System.ReadOnlySpan<U>`, when `E` has covariance conversion or an identity conversion to `U`
- From `System.Span<E>` to `System.ReadOnlySpan<U>`, when `E` has a covariance conversion or an identity conversion to `U`
- From `System.ReadOnlySpan<E>` to `System.ReadOnlySpan<U>`, when `E` has a covariance conversion or an identity conversion to `U`
- From `string` to `System.ReadOnlySpan<char>`

The compiler never ignores any user defined conversion where an applicable *implicit span conversion* exists. Implicit span conversions can be applied to the first argument of [extension methods](../../programming-guide/classes-and-structs/extension-methods.md), the parameter with the `this` modifier. Implicit span conversions aren't considered for method group conversions.

## See also

- [Use language keywords instead of framework type names (style rule IDE0049)](../../../fundamentals/code-analysis/style-rules/ide0049.md)
- [Default values of C# types](default-values.md)
