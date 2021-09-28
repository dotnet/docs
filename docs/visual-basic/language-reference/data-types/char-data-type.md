---
description: "Learn more about: Char Data Type (Visual Basic)"
title: "Char Data Type"
ms.date: 07/20/2015
f1_keywords:
  - "vb.Char"
helpviewer_keywords:
  - "literal type characters [Visual Basic], C"
  - "Char data type"
  - "C literal type character [Visual Basic]"
  - "data types [Visual Basic], assigning"
  - "Char data type [Visual Basic], character literals"
ms.assetid: cd7547a9-7855-4e8e-b216-35d74a362657
---
# Char Data Type (Visual Basic)

Holds unsigned 16-bit (2-byte) code points ranging in value from 0 through 65535. Each *code point*, or character code, represents a single Unicode character.

## Remarks

Use the `Char` data type when you need to hold only a single character and do not need the overhead of `String`. In some cases you can use `Char()`, an array of `Char` elements, to hold multiple characters.

The default value of `Char` is the character with a code point of 0.

## Unicode Characters

The first 128 code points (0–127) of Unicode correspond to the letters and symbols on a standard U.S. keyboard. These first 128 code points are the same as those the ASCII character set defines. The second 128 code points (128–255) represent special characters, such as Latin-based alphabet letters, accents, currency symbols, and fractions. Unicode uses the remaining code points (256-65535) for a wide variety of symbols, including worldwide textual characters, diacritics, and mathematical and technical symbols.

You can use methods like <xref:System.Char.IsDigit%2A> and <xref:System.Char.IsPunctuation%2A> on a `Char` variable to determine its Unicode classification.

## Type Conversions

Visual Basic does not convert directly between `Char` and the numeric types. You can use the <xref:Microsoft.VisualBasic.Strings.Asc%2A> or <xref:Microsoft.VisualBasic.Strings.AscW%2A> function to convert a `Char` value to an `Integer` that represents its code point. You can use the <xref:Microsoft.VisualBasic.Strings.Chr%2A> or <xref:Microsoft.VisualBasic.Strings.ChrW%2A> function to convert an `Integer` value to a `Char` that has that code point.

If the type checking switch (the [Option Strict Statement](../statements/option-strict-statement.md)) is on, you must append the literal type character to a single-character string literal to identify it as the `Char` data type. The following example illustrates this. The first assignment to the `charVar` variable generates compiler error [BC30512](../../misc/bc30512.md) because `Option Strict` is on. The second compiles successfully because the `c` literal type character identifies the literal as a `Char` value.

```vb
Option Strict On

Module CharType
    Public Sub Main()
        Dim charVar As Char

        ' This statement generates compiler error BC30512 because Option Strict is On.  
        charVar = "Z"  

        ' The following statement succeeds because it specifies a Char literal.  
        charVar = "Z"c
    End Sub
End Module
```

## Programming Tips

- **Negative Numbers.** `Char` is an unsigned type and cannot represent a negative value. In any case, you should not use `Char` to hold numeric values.

- **Interop Considerations.** If you interface with components not written for the .NET Framework, for example Automation or COM objects, remember that character types have a different data width (8 bits) in other environments. If you pass an 8-bit argument to such a component, declare it as `Byte` instead of `Char` in your new Visual Basic code.

- **Widening.** The `Char` data type widens to `String`. This means you can convert `Char` to `String` and will not encounter a <xref:System.OverflowException?displayProperty=nameWithType>.

- **Type Characters.** Appending the literal type character `C` to a single-character string literal forces it to the `Char` data type. `Char` has no identifier type character.

- **Framework Type.** The corresponding type in the .NET Framework is the <xref:System.Char?displayProperty=nameWithType> structure.

## See also

- <xref:System.Char?displayProperty=nameWithType>
- <xref:Microsoft.VisualBasic.Strings.Asc%2A>
- <xref:Microsoft.VisualBasic.Strings.AscW%2A>
- <xref:Microsoft.VisualBasic.Strings.Chr%2A>
- <xref:Microsoft.VisualBasic.Strings.ChrW%2A>
- [Data Types](index.md)
- [String Data Type](string-data-type.md)
- [Type Conversion Functions](../functions/type-conversion-functions.md)
- [Conversion Summary](../keywords/conversion-summary.md)
- [How to: Call a Windows Function that Takes Unsigned Types](../../programming-guide/com-interop/how-to-call-a-windows-function-that-takes-unsigned-types.md)
- [Efficient Use of Data Types](../../programming-guide/language-features/data-types/efficient-use-of-data-types.md)
