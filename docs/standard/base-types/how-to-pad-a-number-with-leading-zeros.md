---
title: "How to: Pad a Number with Leading Zeros"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "numeric format strings [.NET Framework]"
  - "formatting [.NET Framework], numbers"
  - "number formatting [.NET Framework]"
  - "numbers [.NET Framework], format strings"
ms.assetid: 0b2c2cb5-c580-4891-8d81-cb632f5ec384
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Pad a Number with Leading Zeros
You can add leading zeros to an integer by using the "D" [standard numeric format string](../../../docs/standard/base-types/standard-numeric-format-strings.md) with a precision specifier. You can add leading zeros to both integer and floating-point numbers by using a [custom numeric format string](../../../docs/standard/base-types/custom-numeric-format-strings.md). This topic shows how to use both methods to pad a number with leading zeros.  
  
### To pad an integer with leading zeros to a specific length  
  
1.  Determine the minimum number of digits you want the integer value to display. Include any leading digits in this number.  
  
2.  Determine whether you want to display the integer as a decimal value or a hexadecimal value.  
  
    -   To display the integer as a decimal value, call its `ToString(String)` method, and pass the string "D*n*" as the value of the `format` parameter, where *n* represents the minimum length of the string.  
  
    -   To display the integer as a hexadecimal value, call its `ToString(String)` method and pass the string "X*n*" as the value of the `format` parameter, where *n* represents the minimum length of the string.  
  
     You can also use the format string in a method, such as <xref:System.String.Format%2A> or <xref:System.Console.WriteLine%2A>, that uses [composite formatting](../../../docs/standard/base-types/composite-formatting.md).  
  
 The following example formats several integer values with leading zeros so that the total length of the formatted number is at least eight characters.  
  
 [!code-csharp[Formatting.HowTo.PadNumber#1](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.PadNumber/cs/Pad1.cs#1)]
 [!code-vb[Formatting.HowTo.PadNumber#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.PadNumber/vb/Pad1.vb#1)]  
  
### To pad an integer with a specific number of leading zeros  
  
1.  Determine how many leading zeros you want the integer value to display.  
  
2.  Determine whether you want to display the integer as a decimal value or a hexadecimal value. Formatting it as a decimal value requires that you use the "D" standard format specifier; formatting it as a hexadecimal value requires that you use the "X" standard format specifier.  
  
3.  Determine the length of the unpadded numeric string by calling the integer value's `ToString("D").Length` or `ToString("X").Length` method.  
  
4.  Add the number of leading zeros that you want to include in the formatted string to the length of the unpadded numeric string. This defines the total length of the padded string.  
  
5.  Call the integer value's `ToString(String)` method, and pass the string "D*n*" for decimal strings and "X*n*" for hexadecimal strings, where *n* represents the total length of the padded string. You can also use the "D*n*" or "X*n*" format string in a method that supports composite formatting.  
  
 The following example pads an integer value with five leading zeros.  
  
 [!code-csharp[Formatting.HowTo.PadNumber#2](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.PadNumber/cs/Pad1.cs#2)]
 [!code-vb[Formatting.HowTo.PadNumber#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.PadNumber/vb/Pad1.vb#2)]  
  
### To pad a numeric value with leading zeros to a specific length  
  
1.  Determine how many digits to the left of the decimal you want the string representation of the number to have. Include any leading zeros in this total number of digits.  
  
2.  Define a custom numeric format string that uses the zero placeholder ("0") to represent the minimum number of zeros.  
  
3.  Call the number's `ToString(String)` method and pass it the custom format string. You can also use the custom format string with a method that supports composite formatting.  
  
 The following example formats several numeric values with leading zeros so that the total length of the formatted number is at least eight digits to the left of the decimal.  
  
 [!code-csharp[Formatting.HowTo.PadNumber#3](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.PadNumber/cs/Pad1.cs#3)]
 [!code-vb[Formatting.HowTo.PadNumber#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.PadNumber/vb/Pad1.vb#3)]  
  
### To pad a numeric value with a specific number of leading zeros  
  
1.  Determine how many leading zeros you want the numeric value to have.  
  
2.  Determine the number of digits to the left of the decimal in the unpadded numeric string. To do this:  
  
    1.  Determine whether the string representation of a number includes a decimal point symbol.  
  
    2.  If it does include a decimal point symbol, determine the number of characters to the left of the decimal point.  
  
         -or-  
  
         If it does not include a decimal point symbol, determine the string's length.  
  
3.  Create a custom format string that uses the zero placeholder ("0") for each of the leading zeros to appear in the string, and that uses either the zero placeholder or the digit placeholder ("#") to represent each digit in the default string.  
  
4.  Supply the custom format string as a parameter either to the number's `ToString(String)` method or to a method that supports composite formatting.  
  
 The following example pads two <xref:System.Double> values with five leading zeros.  
  
 [!code-csharp[Formatting.HowTo.PadNumber#4](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.PadNumber/cs/Pad1.cs#4)]
 [!code-vb[Formatting.HowTo.PadNumber#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.PadNumber/vb/Pad1.vb#4)]  
  
## See Also  
 [Custom Numeric Format Strings](../../../docs/standard/base-types/custom-numeric-format-strings.md)  
 [Standard Numeric Format Strings](../../../docs/standard/base-types/standard-numeric-format-strings.md)  
 [Composite Formatting](../../../docs/standard/base-types/composite-formatting.md)
