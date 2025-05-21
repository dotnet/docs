---
title: System.Int64 struct
description: Learn about the System.Int64 struct.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Int64 struct

[!INCLUDE [context](includes/context.md)]

<xref:System.Int64> is an immutable value type that represents signed integers with values that range from negative 9,223,372,036,854,775,808 (which is represented by the <xref:System.Int64.MinValue?displayProperty=nameWithType> constant) through positive 9,223,372,036,854,775,807 (which is represented by the <xref:System.Int64.MaxValue?displayProperty=nameWithType> constant). .NET also includes an unsigned 64-bit integer value type, <xref:System.UInt64>, which represents values that range from 0 to 18,446,744,073,709,551,615.

## Instantiate an Int64 value

You can instantiate an <xref:System.Int64> value in several ways:

- You can declare an <xref:System.Int64> variable and assign it a literal integer value that is within the range of the <xref:System.Int64> data type. The following example declares two <xref:System.Int64> variables and assigns them values in this way.

  :::code language="csharp" source="./snippets/System/Int64/Overview/csharp/instantiate1.cs" id="Snippet1":::
  :::code language="fsharp" source="./snippets/System/Int64/Overview/fsharp/instantiate1.fs" id="Snippet1":::
  :::code language="vb" source="./snippets/System/Int64/Overview/vb/instantiate1.vb" id="Snippet1":::

- You can assign the value of an integral type whose range is a subset of the <xref:System.Int64> type. This is a widening conversion that does not require a cast operator in C# or a conversion method in Visual Basic. In F#, only the <xref:System.Int32> type can be widened automatically.

  :::code language="csharp" source="./snippets/System/Int64/Overview/csharp/instantiate1.cs" id="Snippet4":::
  :::code language="fsharp" source="./snippets/System/Int64/Overview/fsharp/instantiate1.fs" id="Snippet4":::
  :::code language="vb" source="./snippets/System/Int64/Overview/vb/instantiate1.vb" id="Snippet4":::

- You can assign the value of a numeric type whose range exceeds that of the <xref:System.Int64> type. This is a narrowing conversion, so it requires a cast operator in C# or F# and a conversion method in Visual Basic if `Option Strict` is on. If the numeric value is a <xref:System.Single>, <xref:System.Double>, or <xref:System.Decimal> value that includes a fractional component, the handling of its fractional part depends on the compiler performing the conversion. The following example performs narrowing conversions to assign several numeric values to <xref:System.Int64> variables.

  :::code language="csharp" source="./snippets/System/Int64/Overview/csharp/instantiate1.cs" id="Snippet2":::
  :::code language="fsharp" source="./snippets/System/Int64/Overview/fsharp/instantiate1.fs" id="Snippet2":::
  :::code language="vb" source="./snippets/System/Int64/Overview/vb/instantiate1.vb" id="Snippet2":::

- You can call a method of the <xref:System.Convert> class to convert any supported type to an <xref:System.Int64> value. This is possible because <xref:System.Int64> supports the <xref:System.IConvertible> interface. The following example illustrates the conversion of an array of <xref:System.Decimal> values to <xref:System.Int64> values.

  :::code language="csharp" source="./snippets/System/Convert/ToInt64/csharp/toint64_1.cs" interactive="try-dotnet-method" id="Snippet4":::
  :::code language="fsharp" source="./snippets/System/Convert/ToInt64/fsharp/toint64_1.fs" id="Snippet4":::
  :::code language="vb" source="./snippets/System/Convert/Overview/vb/toint64_1.vb" id="Snippet4":::

- You can call the <xref:System.Int64.Parse%2A> or <xref:System.Int64.TryParse%2A> method to convert the string representation of an <xref:System.Int64> value to an <xref:System.Int64>. The string can contain either decimal or hexadecimal digits. The following example illustrates the parse operation by using both a decimal and a hexadecimal string.

  :::code language="csharp" source="./snippets/System/Int64/Overview/csharp/instantiate1.cs" interactive="try-dotnet-method" id="Snippet3":::
  :::code language="fsharp" source="./snippets/System/Int64/Overview/fsharp/instantiate1.fs" id="Snippet3":::
  :::code language="vb" source="./snippets/System/Int64/Overview/vb/instantiate1.vb" id="Snippet3":::

## Perform operations on Int64 values

The <xref:System.Int64> type supports standard mathematical operations such as addition, subtraction, division, multiplication, negation, and unary negation. Like the other integral types, the <xref:System.Int64> type also supports the bitwise `AND`, `OR`, `XOR`, left shift, and right shift operators.

You can use the standard numeric operators to compare two <xref:System.Int64> values, or you can call the <xref:System.Int64.CompareTo%2A> or <xref:System.Int64.Equals%2A> method.

You can also call the members of the <xref:System.Math> class to perform a wide range of numeric operations, including getting the absolute value of a number, calculating the quotient and remainder from integral division, determining the maximum or minimum value of two long integers, getting the sign of a number, and rounding a number.

## Represent an Int64 as a string

The <xref:System.Int64> type provides full support for standard and custom numeric format strings. (For more information, see [Formatting Types](../../standard/base-types/formatting-types.md), [Standard Numeric Format Strings](../../standard/base-types/standard-numeric-format-strings.md), and [Custom Numeric Format Strings](../../standard/base-types/custom-numeric-format-strings.md).)

To format an <xref:System.Int64> value as an integral string with no leading zeros, you can call the parameterless <xref:System.Int64.ToString> method. By using the "D" format specifier, you can also include a specified number of leading zeros in the string representation. By using the "N" format specifier, you can include group separators and specify the number of decimal digits to appear in the string representation of the number. By using the "X" format specifier, you can represent an <xref:System.Int64> value as a hexadecimal string. The following example formats the elements in an array of <xref:System.Int64> values in these four ways.

:::code language="csharp" source="./snippets/System/Int64/Overview/csharp/formatting1.cs" interactive="try-dotnet-method" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Convert/ToInt64/fsharp/formatting1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Int64/Overview/vb/formatting1.vb" id="Snippet1":::

You can also format an <xref:System.Int64> value as a binary, octal, decimal, or hexadecimal string by calling the <xref:System.Convert.ToString%28System.Int64%2CSystem.Int32%29> method and supplying the base as the method's second parameter. The following example calls this method to display the binary, octal, and hexadecimal representations of an array of integer values.

:::code language="csharp" source="./snippets/System/Int64/Overview/csharp/formatting1.cs" interactive="try-dotnet-method" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Convert/ToInt64/fsharp/formatting1.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Int64/Overview/vb/formatting1.vb" id="Snippet2":::

## Work with non-decimal 32-bit integer values

In addition to working with individual long integers as decimal values, you may want to perform bitwise operations with long integer values, or work with the binary or hexadecimal representations of long integer values. <xref:System.Int64> values are represented in 63 bits, with the sixty-fourth bit used as a sign bit. Positive values are represented by using sign-and-magnitude representation. Negative values are in two's complement representation. This is important to keep in mind when you perform bitwise operations on <xref:System.Int64> values or when you work with individual bits. In order to perform a numeric, Boolean, or comparison operation on any two non-decimal values, both values must use the same representation.
