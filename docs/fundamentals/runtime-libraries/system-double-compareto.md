---
title: System.Double.CompareTo methods
description: Learn about the System.Double.CompareTo methods.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
---
# System.Double.CompareTo methods

[!INCLUDE [context](includes/context.md)]

## <xref:System.Double.CompareTo(System.Double)> method

Values must be identical to be considered equal. Particularly when floating-point values depend on multiple mathematical operations, it is common for them to lose precision and for their values to be nearly identical except for their least significant digits. Because of this, the return value of the <xref:System.Double.CompareTo%2A> method at times may seem surprising. For example, multiplication by a particular value followed by division by the same value should produce the original value. In the following example, however, the computed value turns out to be greater than the original value. Showing all significant digits of the two values by using the "R" [standard numeric format string](../../standard/base-types/standard-numeric-format-strings.md) indicates that the computed value differs from the original value in its least significant digits. For information on handling such comparisons, see the Remarks section of the <xref:System.Double.Equals(System.Double)> method.

:::code language="csharp" source="./snippets/System/Double/CompareTo/csharp/compareto2.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Double/CompareTo/fsharp/compareto2.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Double/CompareTo/vb/compareto2.vb" id="Snippet1":::

This method implements the <xref:System.IComparable%601?displayProperty=nameWithType> interface and performs slightly better than the <xref:System.Double.CompareTo%2A?displayProperty=nameWithType> method because it does not have to convert the `value` parameter to an object.

Note that, although an object whose value is <xref:System.Double.NaN> is not considered equal to another object whose value is <xref:System.Double.NaN> (even itself), the <xref:System.IComparable%601> interface requires that `A.CompareTo(A)` return zero.

## <xref:System.Double.CompareTo(System.Object)> method

The `value` parameter must be `null` or an instance of `Double`; otherwise, an exception is thrown. Any instance of <xref:System.Double>, regardless of its value, is considered greater than `null`.

Values must be identical to be considered equal. Particularly when floating-point values depend on multiple mathematical operations, it is common for them to lose precision and for their values to be nearly identical except for their least significant digits. Because of this, the return value of the <xref:System.Double.CompareTo%2A> method at times may seem surprising. For example, multiplication by a particular value followed by division by the same value should produce the original value. In the following example, however, the computed value turns out to be greater than the original value. Showing all significant digits of the two values by using the "R" [standard numeric format string](../../standard/base-types/standard-numeric-format-strings.md) indicates that the computed value differs from the original value in its least significant digits. For information on handling such comparisons, see the Remarks section of the <xref:System.Double.Equals(System.Double)> method.

:::code language="csharp" source="./snippets/System/Double/CompareTo/csharp/compareto3.cs" interactive="try-dotnet" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Double/CompareTo/fsharp/compareto3.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Double/CompareTo/vb/compareto3.vb" id="Snippet2":::

This method is implemented to support the <xref:System.IComparable> interface. Note that, although a <xref:System.Double.NaN> is not considered to be equal to another <xref:System.Double.NaN> (even itself), the <xref:System.IComparable> interface requires that `A.CompareTo(A)` return zero.

## Widening conversions

Depending on your programming language, it might be possible to code a <xref:System.Double.CompareTo%2A> method where the parameter type has fewer bits (is narrower) than the instance type. This is possible because some programming languages perform an implicit widening conversion that represents the parameter as a type with as many bits as the instance.

For example, suppose the instance type is <xref:System.Double> and the parameter type is <xref:System.Int32>. The Microsoft C# compiler generates instructions to represent the value of the parameter as a <xref:System.Double> object, then generates a <xref:System.Double.CompareTo(System.Double)?displayProperty=nameWithType> method that compares the values of the instance and the widened representation of the parameter.

Consult your programming language's documentation to determine if its compiler performs implicit widening conversions of numeric types. For more information, see the [Type Conversion Tables](../../standard/base-types/conversion-tables.md) topic.

## Precision in comparisons

The precision of floating-point numbers beyond the documented precision is specific to the implementation and version of .NET. Consequently, a comparison of two particular numbers might change between versions of .NET because the precision of the numbers' internal representation might change.
