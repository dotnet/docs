---
title: "Short Data Type (Visual Basic)"
ms.date: 01/31/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
author: "rpetrusha"
ms.author: "ronpet"
f1_keywords: 
  - "vb.Short"
helpviewer_keywords: 
  - "numbers [Visual Basic], whole"
  - "whole numbers"
  - "integral data types [Visual Basic]"
  - "integer numbers"
  - "numbers [Visual Basic], integer"
  - "integers [Visual Basic], data types"
  - "integers [Visual Basic], types"
  - "data types [Visual Basic], integral"
  - "S literal type character [Visual Basic]"
  - "Short data type"
  - "literal type characters [Visual Basic], S"
ms.assetid: 65fcbcf3-a841-400e-885e-301497729a8b
author: "rpetrusha"
ms.author: "ronpet"
---
# Short data type (Visual Basic)
Holds signed 16-bit (2-byte) integers that range in value from -32,768 through 32,767.  
  
## Remarks  
 Use the `Short` data type to contain integer values that do not require the full data width of `Integer`. In some cases, the common language runtime can pack your `Short` variables closely together and save memory consumption.  
  
 The default value of `Short` is 0.  
  
## Literal assignments

You can declare and initialize a `Short` variable by assigning it a decimal literal, a hexadecimal literal, an octal literal, or (starting with Visual Basic 2017) a binary literal. If the integer literal is outside the range of `Short` (that is, if it is less than <xref:System.Int16.MinValue?displayProperty=nameWithType> or greater than <xref:System.Int16.MaxValue?displayProperty=nameWithType>, a compilation error occurs.

In the following example, integers equal to 1,034 that are represented as decimal, hexadecimal, and binary literals are implicitly converted from [Integer](integer-data-type.md) to `Short` values.

[!code-vb[Short](../../../../samples/snippets/visualbasic/language-reference/data-types/numeric-literals.vb#Short)]

> [!NOTE]
> You use the prefix `&h` or `&H` to denote a hexadecimal literal, the prefix `&b` or `&B` to denote a binary literal, and the prefix `&o` or `&O` to denote an octal literal. Decimal literals have no prefix.

Starting with Visual Basic 2017, you can also use the underscore character, `_`, as a digit separator to enhance readability, as the following example shows.

[!code-vb[Short](../../../../samples/snippets/visualbasic/language-reference/data-types/numeric-literals.vb#ShortS)]

Starting with Visual Basic 15.5, you can also use the underscore character (`_`) as a leading separator between the prefix and the hexadecimal, binary, or octal digits. For example:

```vb
Dim number As Short = &H_3264
```

[!INCLUDE [supporting-underscores](../../../../includes/vb-separator-langversion.md)]

Numeric literals can also include the `S` [type character](../../programming-guide\language-features\data-types/type-characters.md) to denote the `Short` data type, as the following example shows.

```vb
Dim number = &H_3264S
```

## Programming tips

-   **Widening.** The `Short` data type widens to `Integer`, `Long`, `Decimal`, `Single`, or `Double`. This means you can convert `Short` to any one of these types without encountering a <xref:System.OverflowException?displayProperty=nameWithType> error.  
  
-   **Type Characters.** Appending the literal type character `S` to a literal forces it to the `Short` data type. `Short` has no identifier type character.  
  
-   **Framework Type.** The corresponding type in the .NET Framework is the <xref:System.Int16?displayProperty=nameWithType> structure.  
  
## See also

 <xref:System.Int16?displayProperty=nameWithType>  
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)  
 [Conversion Summary](../../../visual-basic/language-reference/keywords/conversion-summary.md)  
 [Integer Data Type](../../../visual-basic/language-reference/data-types/integer-data-type.md)  
 [Long Data Type](../../../visual-basic/language-reference/data-types/long-data-type.md)  
 [Efficient Use of Data Types](../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)
