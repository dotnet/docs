---
title: "SByte Data Type (Visual Basic)"
ms.date: 04/20/2017
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.sbyte"
helpviewer_keywords: 
  - "numbers [Visual Basic], whole"
  - "whole numbers"
  - "integral data types [Visual Basic]"
  - "integer numbers"
  - "numbers [Visual Basic], integer"
  - "integers [Visual Basic], data types"
  - "integers [Visual Basic], types"
  - "data types [Visual Basic], integral"
  - "SByte data type"
ms.assetid: 5c38374a-18a1-4cc2-b493-299e3dcaa60f
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
---
# SByte data type (Visual Basic)

Holds signed 8-bit (1-byte) integers that range in value from -128 through 127.  
  
## Remarks

Use the `SByte` data type to contain integer values that do not require the full data width of `Integer` or even the half data width of `Short`. In some cases, the common language runtime might be able to pack your `SByte` variables closely together and save memory consumption.

The default value of `SByte` is 0.

## Literal assignments
  
You can declare and initialize an `SByte` variable by assigning it a decimal literal, a hexadecimal literal, an octal literal, or (starting with Visual Basic 2017) a binary literal.

In the following example, integers equal to -102 that are represented as decimal, hexadecimal, and binary literals are assigned to `SByte` values. This example requires that you compile with the `/removeintchecks` compiler switch.

[!code-vb[SByte](../../../../samples/snippets/visualbasic/language-reference/data-types/numeric-literals.vb#SByte)]  

> [!NOTE] 
> You use the prefix `&h` or `&H` to denote a hexadecimal literal, the prefix `&b` or `&B` to denote a binary literal, and the prefix `&o` or `&O` to denote an octal literal. Decimal literals have no prefix.

Starting with Visual Basic 2017, you can also use the underscore character, `_`, as a digit separator to enhance readability, as the following example shows.

[!code-vb[SByteSeparator](../../../../samples/snippets/visualbasic/language-reference/data-types/numeric-literals.vb#SByteS)]  

Starting with Visual Basic 15.5, you can also use the underscore character (`_`) as a leading separator between the prefix and the hexadecimal, binary, or octal digits. For example:

```vb
Dim number As SByte = &H_F9
```

[!INCLUDE [supporting-underscores](../../../../includes/vb-separator-langversion.md)]

If the integer literal is outside the range of `SByte` (that is, if it is less than <xref:System.SByte.MinValue?displayProperty=nameWithType> or greater than <xref:System.SByte.MaxValue?displayProperty=nameWithType>, a compilation error occurs. When an integer literal has no suffix, an [Integer](integer-data-type.md) is inferred. If the integer literal is outside the range of the `Integer` type, a [Long](long-data-type.md) is inferred. This means that, in the previous examples, the numeric literals `0x9A` and `0b10011010` are interpreted as 32-bit signed integers with a value of 156, which exceeds <xref:System.SByte.MaxValue?displayProperty=nameWithType>. To successfully compile code like this that assigns a non-decimal integer to an `SByte`, you can do either of the following:

- Disable integer bounds checks by compiling with the `/removeintchecks` compiler switch.

- Use a [type character](../../programming-guide\language-features\data-types/type-characters.md) to explicitly define the literal value that you want to assign to the `SByte`. The following example assigns a negative literal `Short` value to an `SByte`. Note that, for negative numbers, the high-order bit of the high-order word of the numeric literal must be set. In the case of our example, this is bit 15 of the literal `Short` value.

   [!code-vb[SByteTypeChars](../../../../samples/snippets/visualbasic/language-reference/data-types/sbyte-assignment.vb#1)]

## Programming tips
  
-   **CLS Compliance.** The `SByte` data type is not part of the [Common Language Specification](http://www.ecma-international.org/publications/standards/Ecma-335.htm) (CLS), so CLS-compliant code cannot consume a component that uses it.

-   **Widening.** The `SByte` data type widens to `Short`, `Integer`, `Long`, `Decimal`, `Single`, and `Double`. This means you can convert `SByte` to any of these types without encountering a <xref:System.OverflowException?displayProperty=nameWithType> error.
  
-   **Type Characters.** `SByte` has no literal type character or identifier type character.  
  
-   **Framework Type.** The corresponding type in the .NET Framework is the <xref:System.SByte?displayProperty=nameWithType> structure.
  
## See also

 <xref:System.SByte?displayProperty=nameWithType>  
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)  
 [Conversion Summary](../../../visual-basic/language-reference/keywords/conversion-summary.md)  
 [Short Data Type](../../../visual-basic/language-reference/data-types/short-data-type.md)  
 [Integer Data Type](../../../visual-basic/language-reference/data-types/integer-data-type.md)  
 [Long Data Type](../../../visual-basic/language-reference/data-types/long-data-type.md)  
 [Efficient Use of Data Types](../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)
