---
title: System.Single.CompareTo methods
description: Learn about the System.Single.CompareTo methods.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Single.CompareTo methods

[!INCLUDE [context](includes/context.md)]

Values must be identical to be considered equal. Particularly when floating-point values depend on multiple mathematical operations, it's common for them to lose precision and for their values to be nearly identical except for their least significant digits. Because of this, the return value of the <xref:System.Single.CompareTo%2A> method may seem surprising at times. For example, multiplication by a particular value followed by division by the same value should produce the original value, but in the following example, the computed value turns out to be greater than the original value. Showing all significant digits of the two values by using the "R" [standard numeric format string](../../standard/base-types/standard-numeric-format-strings.md) indicates that the computed value differs from the original value in its least significant digits. For information about handling such comparisons, see the Remarks section of the <xref:System.Single.Equals(System.Single)> method.

Although an object whose value is <xref:System.Single.NaN> is not considered equal to another object whose value is <xref:System.Single.NaN> (even itself), the <xref:System.IComparable%601> interface requires that `A.CompareTo(A)` return zero.

## CompareTo(System.Object)

The `value` parameter must be `null` or an instance of <xref:System.Single>; otherwise, an exception is thrown. Any instance of <xref:System.Single>, regardless of its value, is considered greater than `null`.

:::code language="csharp" source="./snippets/System/Single/CompareTo/csharp/compareto3.cs" interactive="try-dotnet" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Single/CompareTo/fsharp/compareto3.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Single/CompareTo/vb/compareto3.vb" id="Snippet2":::

This method is implemented to support the <xref:System.IComparable> interface.

## CompareTo(System.Single)

This method implements the <xref:System.IComparable%601?displayProperty=nameWithType> interface and performs slightly better than the <xref:System.Single.CompareTo(System.Object)?displayProperty=nameWithType> overload because it doesn't have to convert the `value` parameter to an object.

:::code language="csharp" source="./snippets/System/Single/CompareTo/csharp/compareto2.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Single/CompareTo/fsharp/compareto2.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Single/CompareTo/vb/compareto2.vb" id="Snippet1":::

## Widening conversions

Depending on your programming language, it might be possible to code a <xref:System.Single.CompareTo%2A> method where the parameter type has fewer bits (is narrower) than the instance type. This is possible because some programming languages perform an implicit widening conversion that represents the parameter as a type with as many bits as the instance.

For example, suppose the instance type is <xref:System.Single> and the parameter type is <xref:System.Int32>. The Microsoft C# compiler generates instructions to represent the value of the parameter as a <xref:System.Single> object, then generates a <xref:System.Single.CompareTo(System.Single)?displayProperty=nameWithType> method that compares the values of the instance and the widened representation of the parameter.

Consult your programming language's documentation to determine if its compiler performs implicit widening conversions of numeric types. For more information, see the [Type Conversion Tables](../../standard/base-types/conversion-tables.md) topic.

## Precision in comparisons

The precision of floating-point numbers beyond the documented precision is specific to the implementation and version of .NET. Consequently, a comparison of two particular numbers might change between versions of .NET because the precision of the numbers' internal representation might change.
