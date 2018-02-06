---
title: "UShort Data Type (Visual Basic)"
ms.date: 01/31/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.ushort"
helpviewer_keywords: 
  - "numbers [Visual Basic], whole"
  - "literal type characters [Visual Basic], US"
  - "whole numbers"
  - "integral data types [Visual Basic]"
  - "integer numbers"
  - "numbers [Visual Basic], integer"
  - "integers [Visual Basic], data types"
  - "integers [Visual Basic], types"
  - "data types [Visual Basic], integral"
  - "UShort data type"
  - "US literal type characters [Visual Basic]"
ms.assetid: 138db892-665d-4ba8-9cae-d8d91c4a8f39
author: "rpetrusha"
ms.author: "ronpet"
---
# UShort data type (Visual Basic)

Holds unsigned 16-bit (2-byte) integers ranging in value from 0 through 65,535.  
  
## Remarks

 Use the `UShort` data type to contain binary data too large for `Byte`.  
  
 The default value of `UShort` is 0.  

# Literal assignments

You can declare and initialize a `UShort` variable by assigning it a decimal literal, a hexadecimal literal, an octal literal, or (starting with Visual Basic 2017) a binary literal. If the integer literal is outside the range of `UShort` (that is, if it is less than <xref:System.UInt16.MinValue?displayProperty=nameWithType> or greater than <xref:System.UInt16.MaxValue?displayProperty=nameWithType>, a compilation error occurs.

In the following example, integers equal to 65,034 that are represented as decimal, hexadecimal, and binary literals are assigned to `UShort` values.
  
[!code-vb[UShort](../../../../samples/snippets/visualbasic/language-reference/data-types/numeric-literals.vb#UShort)]

> [!NOTE]
> You use the prefix `&h` or `&H` to denote a hexadecimal literal, the prefix `&b` or `&B` to denote a binary literal, and the prefix `&o` or `&O` to denote an octal literal. Decimal literals have no prefix.

Starting with Visual Basic 2017, you can also use the underscore character, `_`, as a digit separator to enhance readability, as the following example shows.

[!code-vb[UShort](../../../../samples/snippets/visualbasic/language-reference/data-types/numeric-literals.vb#UShortS)]

Starting with Visual Basic 15.5, you can also use the underscore character (`_`) as a leading separator between the prefix and the hexadecimal, binary, or octal digits. For example:

```vb
Dim number As UShort = &H_FF8C
```

[!INCLUDE [supporting-underscores](../../../../includes/vb-separator-langversion.md)]

Numeric literals can also include the `US` or `us` [type character](../../programming-guide\language-features\data-types/type-characters.md) to denote the `UShort` data type, as the following example shows.

```vb
Dim number = &H_5826us
```

## Programming tips
  
-   **Negative Numbers.** Because `UShort` is an unsigned type, it cannot represent a negative number. If you use the unary minus (`-`) operator on an expression that evaluates to type `UShort`, Visual Basic converts the expression to `Integer` first.  
  
-   **CLS Compliance.** The `UShort` data type is not part of the [Common Language Specification](http://www.ecma-international.org/publications/standards/Ecma-335.htm) (CLS), so CLS-compliant code cannot consume a component that uses it.
  
-   **Widening.** The `UShort` data type widens to `Integer`, `UInteger`, `Long`, `ULong`, `Decimal`, `Single`, and `Double`. This means you can convert `UShort` to any of these types without encountering a <xref:System.OverflowException?displayProperty=nameWithType> error.  
  
-   **Type Characters.** Appending the literal type characters `US` to a literal forces it to the `UShort` data type. `UShort` has no identifier type character.  
  
-   **Framework Type.** The corresponding type in the .NET Framework is the <xref:System.UInt16?displayProperty=nameWithType> structure.  
  
## See Also  
 <xref:System.UInt16>  
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)  
 [Conversion Summary](../../../visual-basic/language-reference/keywords/conversion-summary.md)  
 [How to: Call a Windows Function that Takes Unsigned Types](../../../visual-basic/programming-guide/com-interop/how-to-call-a-windows-function-that-takes-unsigned-types.md)  
 [Efficient Use of Data Types](../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)
