---
title: System.Boolean struct
description: Learn about the System.Boolean struct through these additional API remarks.
ms.date: 01/02/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Boolean struct

[!INCLUDE [context](includes/context.md)]

A <xref:System.Boolean> instance can have either of two values: `true` or `false`.

The <xref:System.Boolean> structure provides methods that support the following tasks:

- Converting Boolean values to strings: <xref:System.Boolean.ToString%2A>
- Parsing strings to convert them to Boolean values: <xref:System.Boolean.Parse%2A> and <xref:System.Boolean.TryParse%2A>
- Comparing values: <xref:System.Boolean.CompareTo%2A> and <xref:System.Boolean.Equals%2A>

This article explains these tasks and other usage details.

## Format Boolean values

The string representation of a <xref:System.Boolean> is either "True" for a `true` value or "False" for a `false` value. The string representation of a <xref:System.Boolean> value is defined by the read-only <xref:System.Boolean.TrueString> and <xref:System.Boolean.FalseString> fields.

You use the <xref:System.Boolean.ToString%2A> method to convert Boolean values to strings. The Boolean structure includes two <xref:System.Boolean.ToString%2A> overloads: the parameterless <xref:System.Boolean.ToString> method and the <xref:System.Boolean.ToString%28System.IFormatProvider%29> method, which includes a parameter that controls formatting. However, because this parameter is ignored, the two overloads produce identical strings. The <xref:System.Boolean.ToString%28System.IFormatProvider%29> method does not support culture-sensitive formatting.

The following example illustrates formatting with the <xref:System.Boolean.ToString%2A> method. Note that the C# and VB examples use the [composite formatting](../../standard/base-types/composite-formatting.md) feature, while the F# example uses [string interpolation](../../fsharp/language-reference/interpolated-strings.md). In both cases the <xref:System.Boolean.ToString%2A> method is called implicitly.

:::code language="csharp" source="./snippets/System/Boolean/Overview/csharp/tostring1.cs" interactive="try-dotnet" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/Boolean/Overview/fsharp/tostring1.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/Boolean/Overview/vb/tostring1.vb" id="Snippet3":::

Because the <xref:System.Boolean> structure can have only two values, it is easy to add custom formatting. For simple custom formatting in which other string literals are substituted for "True" and "False", you can use any conditional evaluation feature supported by your language, such as the [conditional operator](../../csharp/language-reference/operators/conditional-operator.md) in C# or the [If operator](../../visual-basic/language-reference/operators/if-operator.md) in Visual Basic. The following example uses this technique to format <xref:System.Boolean> values as "Yes" and "No" rather than "True" and "False".

:::code language="csharp" source="./snippets/System/Boolean/Overview/csharp/tostring2.cs" interactive="try-dotnet" id="Snippet4":::
:::code language="vb" source="./snippets/System/Boolean/Overview/vb/tostring2.vb" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/Boolean/Overview/fsharp/tostring2.fs" id="Snippet4":::

For more complex custom formatting operations, including culture-sensitive formatting, you can call the <xref:System.String.Format%28System.IFormatProvider%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> method and provide an <xref:System.ICustomFormatter> implementation. The following example implements the <xref:System.ICustomFormatter> and <xref:System.IFormatProvider> interfaces to provide culture-sensitive Boolean strings for the English (United States), French (France), and Russian (Russia) cultures.

:::code language="csharp" source="./snippets/System/Boolean/Overview/csharp/format3.cs" interactive="try-dotnet" id="Snippet5":::
:::code language="fsharp" source="./snippets/System/Boolean/Overview/fsharp/format3.fs" id="Snippet5":::
:::code language="vb" source="./snippets/System/Boolean/Overview/vb/format3.vb" id="Snippet5":::

Optionally, you can use [resource files](/dotnet/framework/resources/) to define culture-specific Boolean strings.

## Convert to and from Boolean values

The <xref:System.Boolean> structure implements the <xref:System.IConvertible> interface. As a result, you can use the <xref:System.Convert> class to perform conversions between a <xref:System.Boolean> value and any other primitive type in .NET, or you can call the <xref:System.Boolean> structure's explicit implementations. However, conversions between a <xref:System.Boolean> and the following types are not supported, so the corresponding conversion methods throw an <xref:System.InvalidCastException> exception:

- Conversion between <xref:System.Boolean> and <xref:System.Char> (the <xref:System.Convert.ToBoolean%28System.Char%29?displayProperty=nameWithType> and <xref:System.Convert.ToChar%28System.Boolean%29?displayProperty=nameWithType> methods).

- Conversion between <xref:System.Boolean> and <xref:System.DateTime> (the <xref:System.Convert.ToBoolean%28System.DateTime%29?displayProperty=nameWithType> and <xref:System.Convert.ToDateTime%28System.Boolean%29?displayProperty=nameWithType> methods).

All conversions from integral or floating-point numbers to Boolean values convert non-zero values to `true` and zero values to `false`. The following example illustrates this by calling selected overloads of the <xref:System.Convert.ToBoolean%2A?displayProperty=nameWithType> class.

:::code language="csharp" source="./snippets/System/Boolean/Overview/csharp/conversion1.cs" interactive="try-dotnet" id="Snippet6":::
:::code language="fsharp" source="./snippets/System/Boolean/Overview/fsharp/conversion1.fs" id="Snippet6":::
:::code language="vb" source="./snippets/System/Boolean/Overview/vb/conversion1.vb" id="Snippet6":::

When converting from Boolean to numeric values, the conversion methods of the <xref:System.Convert> class convert `true` to 1 and `false` to 0. However, Visual Basic conversion functions convert `true` to either 255 (for conversions to <xref:System.Byte> values) or -1 (for all other numeric conversions). The following example converts `true` to numeric values by using a <xref:System.Convert> method, and, in the case of the Visual Basic example, by using the Visual Basic language's own conversion operator.

:::code language="csharp" source="./snippets/System/Boolean/Overview/csharp/conversion3.cs" interactive="try-dotnet" id="Snippet8":::
:::code language="fsharp" source="./snippets/System/Boolean/Overview/fsharp/conversion3.fs" id="Snippet8":::
:::code language="vb" source="./snippets/System/Boolean/Overview/vb/conversion3.vb" id="Snippet8":::

For conversions from <xref:System.Boolean> to string values, see the [Format Boolean values](#format-boolean-values) section. For conversions from strings to <xref:System.Boolean> values, see the [Parse Boolean values](#parse-boolean-values) section.

## Parse Boolean values

The <xref:System.Boolean> structure includes two static parsing methods, <xref:System.Boolean.Parse%2A> and <xref:System.Boolean.TryParse%2A>, that convert a string to a Boolean value. The string representation of a Boolean value is defined by the case-insensitive equivalents of the values of the <xref:System.Boolean.TrueString> and <xref:System.Boolean.FalseString> fields, which are "True" and "False", respectively. In other words, the only strings that parse successfully are "True", "False", "true", "false", or some mixed-case equivalent. You cannot successfully parse numeric strings such as "0" or "1". Leading or trailing white-space characters are not considered when performing the string comparison.

The following example uses the <xref:System.Boolean.Parse%2A> and <xref:System.Boolean.TryParse%2A> methods to parse a number of strings. Note that only the case-insensitive equivalents of "True" and "False" can be successfully parsed.

:::code language="csharp" source="./snippets/System/Boolean/Overview/csharp/parse2.cs" interactive="try-dotnet" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Boolean/Overview/fsharp/parse2.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Boolean/Overview/vb/parse2.vb" id="Snippet2":::

If you're programming in Visual Basic, you can use the `CBool` function to convert the string representation of a number to a Boolean value. "0" is converted to `false`, and the string representation of any non-zero value is converted to `true`. If you're not programming in Visual Basic, you must convert your numeric string to a number before converting it to a Boolean. The following example illustrates this by converting an array of integers to Boolean values.

:::code language="csharp" source="./snippets/System/Boolean/Overview/csharp/parse3.cs" interactive="try-dotnet" id="Snippet9":::
:::code language="fsharp" source="./snippets/System/Boolean/Overview/fsharp/parse3.fs" id="Snippet9":::
:::code language="vb" source="./snippets/System/Boolean/Overview/vb/parse3.vb" id="Snippet9":::

## Compare Boolean values

Because Boolean values are either `true` or `false`, there is little reason to explicitly call the <xref:System.Boolean.CompareTo%2A> method, which indicates whether an instance is greater than, less than, or equal to a specified value. Typically, to compare two Boolean variables, you call the <xref:System.Boolean.Equals%2A> method or use your language's equality operator.

However, when you want to compare a Boolean variable with the literal Boolean value `true` or `false`, it's not necessary to do an explicit comparison, because the result of evaluating a Boolean value is that Boolean value. For example, the following two expressions are equivalent, but the second is more compact. However, both techniques offer comparable performance.

:::code language="csharp" source="./snippets/System/Boolean/Overview/csharp/operations1.cs" id="Snippet11":::
:::code language="fsharp" source="./snippets/System/Boolean/Overview/fsharp/operations1.fs" id="Snippet11":::
:::code language="vb" source="./snippets/System/Boolean/Overview/vb/operations1.vb" id="Snippet11":::

:::code language="csharp" source="./snippets/System/Boolean/Overview/csharp/operations1.cs" id="Snippet12":::
:::code language="fsharp" source="./snippets/System/Boolean/Overview/fsharp/operations1.fs" id="Snippet12":::
:::code language="vb" source="./snippets/System/Boolean/Overview/vb/operations1.vb" id="Snippet12":::

## Work with Booleans as binary values

A Boolean value occupies one byte of memory, as the following example shows. The C# example must be compiled with the `/unsafe` switch.

:::code language="csharp" source="./snippets/System/Boolean/Overview/csharp/size1.cs" id="Snippet14":::
:::code language="fsharp" source="./snippets/System/Boolean/Overview/fsharp/size1.fs" id="Snippet14":::

The byte's low-order bit is used to represent its value. A value of 1 represents `true`; a value of 0 represents `false`.

> [!TIP]
> You can use the <xref:System.Collections.Specialized.BitVector32?displayProperty=nameWithType> structure to work with sets of Boolean values.

You can convert a Boolean value to its binary representation by calling the <xref:System.BitConverter.GetBytes%28System.Boolean%29?displayProperty=nameWithType> method. The method returns a byte array with a single element. To restore a Boolean value from its binary representation, you can call the <xref:System.BitConverter.ToBoolean%28System.Byte%5B%5D%2CSystem.Int32%29?displayProperty=nameWithType> method.

The following example calls the <xref:System.BitConverter.GetBytes%2A?displayProperty=nameWithType> method to convert a Boolean value to its binary representation and displays the individual bits of the value, and then calls the <xref:System.BitConverter.ToBoolean%2A?displayProperty=nameWithType> method to restore the value from its binary representation.

:::code language="csharp" source="./snippets/System/Boolean/Overview/csharp/binary1.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Boolean/Overview/fsharp/binary1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Boolean/Overview/vb/binary1.vb" id="Snippet1":::

## Perform operations with Boolean values

This section illustrates how Boolean values are used in apps. The first section discusses its use as a flag. The second illustrates its use for arithmetic operations.

### Boolean values as flags

Boolean variables are most commonly used as flags, to signal the presence or absence of some condition. For example, in the <xref:System.String.Compare%28System.String%2CSystem.String%2CSystem.Boolean%29?displayProperty=nameWithType> method, the final parameter, `ignoreCase`, is a flag that indicates whether the comparison of two strings is case-insensitive (`ignoreCase` is `true`) or case-sensitive (`ignoreCase` is `false`). The value of the flag can then be evaluated in a conditional statement.

The following example uses a simple console app to illustrate the use of Boolean variables as flags. The app accepts command-line parameters that enable output to be redirected to a specified file (the `/f` switch), and that enable output to be sent both to a specified file and to the console (the `/b` switch). The app defines a flag named `isRedirected` to indicate whether output is to be sent to a file, and a flag named `isBoth` to indicate that output should be sent to the console. The F# example uses a [recursive function](../../fsharp/language-reference/functions/recursive-functions-the-rec-keyword.md) to parse the arguments.

:::code language="csharp" source="./snippets/System/Boolean/Overview/csharp/operations1.cs" id="Snippet10":::
:::code language="fsharp" source="./snippets/System/Boolean/Overview/fsharp/operations1.fs" id="Snippet10":::
:::code language="vb" source="./snippets/System/Boolean/Overview/vb/operations1.vb" id="Snippet10":::

### Booleans and arithmetic operations

A Boolean value is sometimes used to indicate the presence of a condition that triggers a mathematical calculation. For example, a `hasShippingCharge` variable might serve as a flag to indicate whether to add shipping charges to an invoice amount.

Because an operation with a `false` value has no effect on the result of an operation, it's not necessary to convert the Boolean to an integral value to use in the mathematical operation. Instead, you can use conditional logic.

The following example computes an amount that consists of a subtotal, a shipping charge, and an optional service charge. The `hasServiceCharge` variable determines whether the service charge is applied. Instead of converting `hasServiceCharge` to a numeric value and multiplying it by the amount of the service charge, the example uses conditional logic to add the service charge amount if it is applicable.

:::code language="csharp" source="./snippets/System/Boolean/Overview/csharp/operations2.cs" id="Snippet13":::
:::code language="fsharp" source="./snippets/System/Boolean/Overview/fsharp/operations2.fs" id="Snippet13":::
:::code language="vb" source="./snippets/System/Boolean/Overview/vb/operations2.vb" id="Snippet13":::

### Booleans and interop

While marshaling base data types to COM is generally straightforward, the <xref:System.Boolean> data type is an exception. You can apply the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute to marshal the <xref:System.Boolean> type to any of the following representations:

|Enumeration type|Unmanaged format|
|----------------------|----------------------|
|<xref:System.Runtime.InteropServices.UnmanagedType.Bool?displayProperty=nameWithType>|A 4-byte integer value, where any nonzero value represents `true` and 0 represents `false`. This is the default format of a <xref:System.Boolean> field in a structure and of a <xref:System.Boolean> parameter in platform invoke calls.|
|<xref:System.Runtime.InteropServices.UnmanagedType.U1?displayProperty=nameWithType>|A 1-byte integer value, where the 1 represents `true` and 0 represents `false`.|
|<xref:System.Runtime.InteropServices.UnmanagedType.VariantBool?displayProperty=nameWithType>|A 2-byte integer value, where -1 represents `true` and 0 represents `false`. This is the default format of a <xref:System.Boolean> parameter in COM interop calls.|
