---
title: System.Byte struct
description: Learn about the System.Byte struct through these additional API remarks.
ms.date: 01/02/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
---
# System.Byte struct

[!INCLUDE [context](includes/context.md)]

<xref:System.Byte> is an immutable value type that represents unsigned integers with values that range from 0 (which is represented by the <xref:System.Byte.MinValue?displayProperty=nameWithType> constant) to 255 (which is represented by the <xref:System.Byte.MaxValue?displayProperty=nameWithType> constant). .NET also includes a signed 8-bit integer value type, <xref:System.SByte>, which represents values that range from -128 to 127.

## Instantiate a Byte value

You can instantiate a <xref:System.Byte> value in several ways:

- You can declare a <xref:System.Byte> variable and assign it a literal integer value that is within the range of the <xref:System.Byte> data type. The following example declares two <xref:System.Byte> variables and assigns them values in this way.

  :::code language="csharp" source="./snippets/System/Byte/Overview/csharp/byteinstantiation1.cs" id="Snippet1":::
  :::code language="fsharp" source="./snippets/System/Byte/Overview/fsharp/byteinstantiation1.fs" id="Snippet1":::
  :::code language="vb" source="./snippets/System/Byte/Overview/vb/byteinstantiate1.vb" id="Snippet1":::

- You can assign a non-byte numeric value to a byte. This is a narrowing conversion, so it requires a cast operator in C# and F#, or a conversion method in Visual Basic if `Option Strict` is on. If the non-byte value is a <xref:System.Single>, <xref:System.Double>, or <xref:System.Decimal> value that includes a fractional component, the handling of its fractional part depends on the compiler performing the conversion. The following example assigns several numeric values to <xref:System.Byte> variables.

  :::code language="csharp" source="./snippets/System/Byte/Overview/csharp/byteinstantiation1.cs" interactive="try-dotnet-method" id="Snippet2":::
  :::code language="fsharp" source="./snippets/System/Byte/Overview/fsharp/byteinstantiation1.fs" id="Snippet2":::
  :::code language="vb" source="./snippets/System/Byte/Overview/vb/byteinstantiate1.vb" id="Snippet2":::

- You can call a method of the <xref:System.Convert> class to convert any supported type to a <xref:System.Byte> value. This is possible because <xref:System.Byte> supports the <xref:System.IConvertible> interface. The following example illustrates the conversion of an array of <xref:System.Int32> values to <xref:System.Byte> values.

  :::code language="csharp" source="./snippets/System/Byte/Overview/csharp/tobyte1.cs" interactive="try-dotnet-method" id="Snippet4":::
  :::code language="fsharp" source="./snippets/System/Byte/Overview/fsharp/tobyte1.fs" id="Snippet4":::
  :::code language="vb" source="./snippets/System/Convert/Overview/vb/tobyte1.vb" id="Snippet4":::

- You can call the <xref:System.Byte.Parse%2A> or <xref:System.Byte.TryParse%2A> method to convert the string representation of a <xref:System.Byte> value to a <xref:System.Byte>. The string can contain either decimal or hexadecimal digits. The following example illustrates the parse operation by using both a decimal and a hexadecimal string.

  :::code language="csharp" source="./snippets/System/Byte/Overview/csharp/byteinstantiation1.cs" interactive="try-dotnet-method" id="Snippet3":::
  :::code language="fsharp" source="./snippets/System/Byte/Overview/fsharp/byteinstantiation1.fs" id="Snippet3":::
  :::code language="vb" source="./snippets/System/Byte/Overview/vb/byteinstantiate1.vb" id="Snippet3":::

## Perform operations on Byte values

The <xref:System.Byte> type supports standard mathematical operations such as addition, subtraction, division, multiplication, subtraction, negation, and unary negation. Like the other integral types, the <xref:System.Byte> type also supports the bitwise `AND`, `OR`, `XOR`, left shift, and right shift operators.

You can use the standard numeric operators to compare two <xref:System.Byte> values, or you can call the <xref:System.Byte.CompareTo%2A> or <xref:System.Byte.Equals%2A> method.

You can also call the members of the <xref:System.Math> class to perform a wide range of numeric operations, including getting the absolute value of a number, calculating the quotient and remainder from integral division, determining the maximum or minimum value of two integers, getting the sign of a number, and rounding a number.

## Represent a Byte as a String

The <xref:System.Byte> type provides full support for standard and custom numeric format strings. (For more information, see [Formatting Types](../../standard/base-types/formatting-types.md), [Standard Numeric Format Strings](../../standard/base-types/standard-numeric-format-strings.md), and [Custom Numeric Format Strings](../../standard/base-types/custom-numeric-format-strings.md).) However, most commonly, byte values are represented as one-digit to three-digit values without any additional formatting, or as two-digit hexadecimal values.

To format a <xref:System.Byte> value as an integral string with no leading zeros, you can call the parameterless <xref:System.Byte.ToString> method. By using the "D" format specifier, you can also include a specified number of leading zeros in the string representation. By using the "X" format specifier, you can represent a <xref:System.Byte> value as a hexadecimal string. The following example formats the elements in an array of <xref:System.Byte> values in these three ways.

:::code language="csharp" source="./snippets/System/Byte/Overview/csharp/formatting1.cs" interactive="try-dotnet-method" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Byte/Overview/fsharp/formatting1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Byte/Overview/vb/formatting1.vb" id="Snippet1":::

You can also format a <xref:System.Byte> value as a binary, octal, decimal, or hexadecimal string by calling the <xref:System.Convert.ToString%28System.Byte%2CSystem.Int32%29> method and supplying the base as the method's second parameter. The following example calls this method to display the binary, octal, and hexadecimal representations of an array of byte values.

:::code language="csharp" source="./snippets/System/Byte/Overview/csharp/formatting1.cs" interactive="try-dotnet-method" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Byte/Overview/fsharp/formatting1.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Byte/Overview/vb/formatting1.vb" id="Snippet2":::

## Work with non-decimal Byte values

In addition to working with individual bytes as decimal values, you might want to perform bitwise operations with byte values, or work with byte arrays or with the binary or hexadecimal representations of byte values. For example, overloads of the <xref:System.BitConverter.GetBytes%2A?displayProperty=nameWithType> method can convert each of the primitive data types to a byte array, and the <xref:System.Numerics.BigInteger.ToByteArray%2A?displayProperty=nameWithType> method converts a <xref:System.Numerics.BigInteger> value to a byte array.

<xref:System.Byte> values are represented in 8 bits by their magnitude only, without a sign bit. This is important to keep in mind when you perform bitwise operations on <xref:System.Byte> values or when you work with individual bits. To perform a numeric, Boolean, or comparison operation on any two non-decimal values, both values must use the same representation.

When an operation is performed on two <xref:System.Byte> values, the values share the same representation, so the result is accurate. This is illustrated in the following example, which masks the lowest-order bit of a <xref:System.Byte> value to ensure that it is even.

:::code language="csharp" source="./snippets/System/Byte/Overview/csharp/bitwise1.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Byte/Overview/fsharp/bitwise1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Byte/Overview/vb/bitwise1.vb" id="Snippet1":::

On the other hand, when you work with both unsigned and signed bits, bitwise operations are complicated by the fact that the <xref:System.SByte> values use sign-and-magnitude representation for positive values, and two's complement representation for negative values. In order to perform a meaningful bitwise operation, the values must be converted to two equivalent representations, and information about the sign bit must be preserved. The following example does this to mask out bits 2 and 4 of an array of 8-bit signed and unsigned values.

:::code language="csharp" source="./snippets/System/Byte/Overview/csharp/bitwise2.cs" interactive="try-dotnet" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Byte/Overview/fsharp/bitwise2.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Byte/Overview/vb/bitwise2.vb" id="Snippet2":::
