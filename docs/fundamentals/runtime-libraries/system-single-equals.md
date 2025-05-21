---
title: System.Single.Equals method
description: Learn about the System.Single.Equals method.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Single.Equals method

[!INCLUDE [context](includes/context.md)]

The <xref:System.Single.Equals(System.Single)?displayProperty=nameWithType> method implements the <xref:System.IEquatable%601?displayProperty=nameWithType> interface, and performs slightly better than <xref:System.Single.Equals(System.Object)?displayProperty=nameWithType> because it does not have to convert the `obj` parameter to an object.

## Widening conversions

Depending on your programming language, it might be possible to code an <xref:System.Single.Equals%2A> method where the parameter type has fewer bits (is narrower) than the instance type. This is possible because some programming languages perform an implicit widening conversion that represents the parameter as a type with as many bits as the instance.

For example, suppose the instance type is <xref:System.Single> and the parameter type is <xref:System.Int32>. The Microsoft C# compiler generates instructions to represent the value of the parameter as a <xref:System.Single> object, and then generates a <xref:System.Single.Equals(System.Single)?displayProperty=nameWithType> method that compares the values of the instance and the widened representation of the parameter.

Consult your programming language's documentation to determine if its compiler performs implicit widening conversions of numeric types. For more information, see [Type Conversion Tables](../../standard/base-types/conversion-tables.md).

## Precision in comparisons

The <xref:System.Single.Equals%2A> method should be used with caution, because two apparently equivalent values can be unequal because of the differing precision of the two values. The following example reports that the <xref:System.Single> value .3333 and the <xref:System.Single> returned by dividing 1 by 3 are unequal.

:::code language="csharp" source="./snippets/System/Single/Epsilon/csharp/SingleEquals_25051.cs" interactive="try-dotnet-method" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Single/Epsilon/fsharp/SingleEquals_25051.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Single/Epsilon/vb/SingleEquals_25051.vb" id="Snippet1":::

One comparison technique that avoids the problems associated with comparing for equality involves defining an acceptable margin of difference between two values (such as .01% of one of the values). If the absolute value of the difference between the two values is less than or equal to that margin, the difference is likely to be an outcome of differences in precision and, therefore, the values are likely to be equal. The following example uses this technique to compare .33333 and 1/3, which are the two <xref:System.Single> values that the previous code example found to be unequal.

:::code language="csharp" source="./snippets/System/Single/Epsilon/csharp/SingleEquals_25051.cs" interactive="try-dotnet-method" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Single/Epsilon/fsharp/SingleEquals_25051.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Single/Epsilon/vb/SingleEquals_25051.vb" id="Snippet2":::

In this case, the values are equal.

> [!NOTE]
> Because <xref:System.Single.Epsilon> defines the minimum expression of a positive value whose range is near zero, the margin of difference must be greater than <xref:System.Single.Epsilon>. Typically, it is many times greater than <xref:System.Single.Epsilon>. Because of this, we recommend that you do not use <xref:System.Double.Epsilon> when comparing <xref:System.Double> values for equality.

A second technique that avoids the problems associated with comparing for equality involves comparing the difference between two floating-point numbers with some absolute value. If the difference is less than or equal to that absolute value, the numbers are equal. If it is greater, the numbers are not equal. One way to do this is to arbitrarily select an absolute value. However, this is problematic, because an acceptable margin of difference depends on the magnitude of the <xref:System.Single> values. A second way takes advantage of a design feature of the floating-point format: The difference between the mantissa components in the integer representations of two floating-point values indicates the number of possible floating-point values that separates the two values. For example, the difference between 0.0 and <xref:System.Single.Epsilon> is 1, because <xref:System.Single.Epsilon> is the smallest representable value when working with a <xref:System.Single> whose value is zero. The following example uses this technique to compare .33333 and 1/3, which are the two <xref:System.Double> values that the previous code example with the <xref:System.Single.Equals(System.Single)> method found to be unequal. Note that the example uses the <xref:System.BitConverter.GetBytes%2A?displayProperty=nameWithType> and <xref:System.BitConverter.ToInt32%2A?displayProperty=nameWithType> methods to convert a single-precision floating-point value to its integer representation.

:::code language="csharp" source="./snippets/System/Single/Equals/csharp/equalsabs1.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Single/Equals/fsharp/equalsabs1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Single/Equals/vb/equalsabs1.vb" id="Snippet1":::

The precision of floating-point numbers beyond the documented precision is specific to the implementation and version of .NET. Consequently, a comparison of two numbers might produce different results depending on the version of .NET, because the precision of the numbers' internal representation might change.
