---
title: "How to: Pad a Number with Leading Zeros"
ms.date: "02/25/2019"
ms.technology: dotnet-standard
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "numeric format strings [.NET Framework]"
  - "formatting [.NET Framework], numbers"
  - "number formatting [.NET Framework]"
  - "numbers [.NET Framework], format strings"
ms.assetid: 0b2c2cb5-c580-4891-8d81-cb632f5ec384
author: "rpetrusha"
ms.author: "ronpet"
---

# How to: Pad a Number with Leading Zeros

You can add leading zeros to an integer by using the "D" [standard numeric format string](../../../docs/standard/base-types/standard-numeric-format-strings.md) with a precision specifier. You can add leading zeros to both integer and floating-point numbers by using a [custom numeric format string](../../../docs/standard/base-types/custom-numeric-format-strings.md). This article shows how to use both methods to pad a number with leading zeros.

## To pad an integer with leading zeros to a specific length

1. Determine the minimum number of digits you want the integer value to display. Include any leading digits in this number.

1. Determine whether you want to display the integer as a decimal value or a hexadecimal value.

    - To display the integer as a decimal value, call its `ToString(String)` method, and pass the string "D*n*" as the value of the `format` parameter, where *n* represents the minimum length of the string.

    - To display the integer as a hexadecimal value, call its `ToString(String)` method and pass the string "X*n*" as the value of the format parameter, where *n* represents the minimum length of the string.

You can also use the format string in an interpolated string in both [C#](../../csharp/language-reference/tokens/interpolated.md) and [Visual Basic](../../visual-basic/programming-guide/language-features/strings/interpolated-strings.md), or you can call a method, such as <xref:System.String.Format%2A?displayProperty=nameWithType> or <xref:System.Console.WriteLine%2A?displayProperty=nameWithType>, that uses [composite formatting](../../../docs/standard/base-types/composite-formatting.md).

The following example formats several integer values with leading zeros so that the total length of the formatted number is at least eight characters.

[!code-csharp[Formatting.HowTo.PadNumber#1](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.PadNumber/cs/Pad1.cs#1)]
[!code-vb[Formatting.HowTo.PadNumber#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.PadNumber/vb/Pad1.vb#1)]

## To pad an integer with a specific number of leading zeros

1. Determine how many leading zeros you want the integer value to display.

1. Determine whether you want to display the integer as a decimal value or a hexadecimal value.

    - Formatting it as a decimal value requires that you use the "D" standard format specifier.

    - Formatting it as a hexadecimal value requires that you use the "X" standard format specifier.

1. Determine the length of the unpadded numeric string by calling the integer value's `ToString("D").Length` or `ToString("X").Length` method.

1. Add the number of leading zeros that you want to include in the formatted string to the length of the unpadded numeric string. Adding the number of leading zeros defines the total length of the padded string.

1. Call the integer value's `ToString(String)` method, and pass the string "D*n*" for decimal strings and "X*n*" for hexadecimal strings, where *n* represents the total length of the padded string. You can also use the "D*n*" or "X*n*" format string in a method that supports composite formatting.

The following example pads an integer value with five leading zeros.

[!code-csharp[Formatting.HowTo.PadNumber#2](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.PadNumber/cs/Pad1.cs#2)]
[!code-vb[Formatting.HowTo.PadNumber#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.PadNumber/vb/Pad1.vb#2)]

## To pad a numeric value with leading zeros to a specific length

1. Determine how many digits to the left of the decimal you want the string representation of the number to have. Include any leading zeros in this total number of digits.

1. Define a custom numeric format string that uses the zero placeholder "0" to represent the minimum number of zeros.

1. Call the number's `ToString(String)` method and pass it the custom format string. You can also use the custom format string with string interpolation or with a method that supports composite formatting.

The following example formats several numeric values with leading zeros. As a result, the total length of the formatted number is at least eight digits to the left of the decimal.

[!code-csharp[Formatting.HowTo.PadNumber#3](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.PadNumber/cs/Pad1.cs#3)]
[!code-vb[Formatting.HowTo.PadNumber#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.PadNumber/vb/Pad1.vb#3)]

## To pad a numeric value with a specific number of leading zeros

1. Determine how many leading zeros you want the numeric value to have.

1. Determine the number of digits to the left of the decimal in the unpadded numeric string:

    1. Determine whether the string representation of a number includes a decimal point symbol.

    1. If it does include a decimal point symbol, determine the number of characters to the left of the decimal point.

         -or-

         If it doesn't include a decimal point symbol, determine the string's length.

1. Create a custom format string that uses:

    - The zero placeholder "0" for each of the leading zeros to appear in the string.

    - Either the zero placeholder or the digit placeholder "#" to represent each digit in the default string.

1. Supply the custom format string as a parameter either to the number's `ToString(String)` method or to a method that supports composite formatting.

The following example pads two <xref:System.Double> values with five leading zeros.

[!code-csharp[Formatting.HowTo.PadNumber#4](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.PadNumber/cs/Pad1.cs#4)]
[!code-vb[Formatting.HowTo.PadNumber#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.PadNumber/vb/Pad1.vb#4)]

## See also

- [Custom Numeric Format Strings](../../../docs/standard/base-types/custom-numeric-format-strings.md)
- [Standard Numeric Format Strings](../../../docs/standard/base-types/standard-numeric-format-strings.md)
- [Composite Formatting](../../../docs/standard/base-types/composite-formatting.md)
