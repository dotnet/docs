---
title: System.Double.Equals method
description: Learn about the System.Double.Equals method.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Double.Equals method

Th <xref:System.Double.Equals(System.Double)?displayProperty=nameWithType> method implements the <xref:System.IEquatable%601?displayProperty=nameWithType> interface, and performs slightly better than <xref:System.Double.Equals(System.Object)?displayProperty=nameWithType> because it doesn't have to convert the `obj` parameter to an object.

## Widening conversions

Depending on your programming language, it might be possible to code a <xref:System.Double.Equals%2A> method where the parameter type has fewer bits (is narrower) than the instance type. This is possible because some programming languages perform an implicit widening conversion that represents the parameter as a type with as many bits as the instance.

For example, suppose the instance type is <xref:System.Double> and the parameter type is <xref:System.Int32>. The Microsoft C# compiler generates instructions to represent the value of the parameter as a <xref:System.Double> object, then generates a <xref:System.Double.Equals(System.Double)?displayProperty=nameWithType> method that compares the values of the instance and the widened representation of the parameter.

Consult your programming language's documentation to determine if its compiler performs implicit widening conversions of numeric types. For more information, see the [Type Conversion Tables](../../standard/base-types/conversion-tables.md) topic.

## Precision in comparisons

The <xref:System.Double.Equals%2A> method should be used with caution, because two apparently equivalent values can be unequal due to the differing precision of the two values. The following example reports that the <xref:System.Double> value .333333 and the <xref:System.Double> value returned by dividing 1 by 3 are unequal.

:::code language="csharp" source="./snippets/System/Double/Epsilon/csharp/Equals_25051.cs" interactive="try-dotnet-method" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Double/Epsilon/fsharp/Equals_25051.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Double/Epsilon/vb/Equals_25051.vb" id="Snippet1":::

Rather than comparing for equality, one technique involves defining an acceptable relative margin of difference between two values (such as .001% of one of the values). If the absolute value of the difference between the two values is less than or equal to that margin, the difference is likely to be due to differences in precision and, therefore, the values are likely to be equal. The following example uses this technique to compare .33333 and 1/3, the two <xref:System.Double> values that the previous code example found to be unequal. In this case, the values are equal.

:::code language="csharp" source="./snippets/System/Double/Epsilon/csharp/Equals_25051.cs" interactive="try-dotnet-method" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Double/Epsilon/fsharp/Equals_25051.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Double/Epsilon/vb/Equals_25051.vb" id="Snippet2":::

> [!NOTE]
> Because <xref:System.Double.Epsilon> defines the minimum expression of a positive value whose range is near zero, the margin of difference between two similar values must be greater than <xref:System.Double.Epsilon>. Typically, it is many times greater than <xref:System.Double.Epsilon>. Because of this, we recommend that you **don't** use <xref:System.Double.Epsilon> when comparing <xref:System.Double> values for equality.

A second technique involves comparing the difference between two floating-point numbers with some absolute value. If the difference is less than or equal to that absolute value, the numbers are equal. If it's greater, the numbers are not equal. One alternative is to arbitrarily select an absolute value. That's problematic, however, because an acceptable margin of difference depends on the magnitude of the <xref:System.Double> values. A second alternative takes advantage of a design feature of the floating-point format: The difference between the integer representation of two floating-point values indicates the number of possible floating-point values that separates them. For example, the difference between 0.0 and <xref:System.Double.Epsilon> is 1, because <xref:System.Double.Epsilon> is the smallest representable value when working with a <xref:System.Double> whose value is zero. The following example uses this technique to compare .33333 and 1/3, which are the two <xref:System.Double> values that the previous code example with the <xref:System.Double.Equals(System.Double)> method found to be unequal. The example uses the <xref:System.BitConverter.DoubleToInt64Bits%2A?displayProperty=nameWithType> method to convert a double-precision floating-point value to its integer representation. The example declares the values as equal if there are no possible floating-point values between their integer representations.

:::code language="csharp" source="./snippets/System/Double/Equals/csharp/equalsabs1.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Double/Equals/fsharp/equalsabs1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Double/Equals/vb/equalsabs1.vb" id="Snippet1":::

> [!NOTE]
> For some values, you might consider them equal even when there *is* a possible floating-point value between the integer representations. For example, consider the double values `0.39` and `1.69 - 1.3` (which is calculated as `0.3899999999999999`). On a little-endian computer, the integer representations of these values are `4600697235336603894` and `4600697235336603892`, respectively. The difference between the integer values is `2`, meaning there *is* a possible floating-point value between `0.39` and `1.69 - 1.3`.

### Version differences

The precision of floating-point numbers beyond the documented precision is specific to the implementation and version of .NET. Consequently, a comparison of two particular numbers might change between versions of .NET because the precision of the numbers' internal representation might change.

## NaN

If two <xref:System.Double.NaN?displayProperty=nameWithType> values are tested for equality by calling the <xref:System.Double.Equals%2A> method, the method returns `true`. However, if two <xref:System.Double.NaN?displayProperty=nameWithType> values are tested for equality by using the *equality operator*, the operator returns `false`. When you want to determine whether the value of a <xref:System.Double> is not a number (NaN), an alternative is to call the <xref:System.Double.IsNaN%2A> method.
