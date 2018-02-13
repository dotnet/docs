---
title: "Integer Data Type (Visual Basic)"
ms.date: 01/31/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Integer"
  - "Integer"
helpviewer_keywords: 
  - "numbers [Visual Basic], whole"
  - "enumerated values [Visual Basic]"
  - "whole numbers"
  - "integral data types [Visual Basic]"
  - "integer numbers"
  - "numbers [Visual Basic], integer"
  - "integers [Visual Basic], data types"
  - "literal type characters [Visual Basic], I"
  - "integers [Visual Basic], types"
  - "data types [Visual Basic], integral"
  - "% identifier type character"
  - "data types [Visual Basic], assigning"
  - "identifier type characters [Visual Basic], %"
  - "I literal type character [Visual Basic]"
  - "Integer data type"
ms.assetid: a8f233b4-4be3-455c-861b-05af2fbb6c60
author: "rpetrusha"
ms.author: "ronpet"
---
# Integer data type (Visual Basic)
Holds signed 32-bit (4-byte) integers that range in value from -2,147,483,648 through 2,147,483,647.  
  
## Remarks
 The `Integer` data type provides optimal performance on a 32-bit processor. The other integral types are slower to load and store from and to memory.  
  
 The default value of `Integer` is 0.  

## Literal assignments

You can declare and initialize an `Integer` variable by assigning it a decimal literal, a hexadecimal literal, an octal literal, or (starting with Visual Basic 2017) a binary literal. If the integer literal is outside the range of `Integer` (that is, if it is less than <xref:System.Int32.MinValue?displayProperty=nameWithType> or greater than <xref:System.Int32.MaxValue?displayProperty=nameWithType>, a compilation error occurs.

In the following example, integers equal to 16,342 that are represented as decimal, hexadecimal, and binary literals are assigned to `Integer` values.

[!code-vb[integer](../../../../samples/snippets/visualbasic/language-reference/data-types/numeric-literals.vb#Int)]  

> [!NOTE]
> You use the prefix `&h` or `&H` to denote a hexadecimal literal, the prefix `&b` or `&B` to denote a binary literal, and the prefix `&o` or `&O` to denote an octal literal. Decimal literals have no prefix.

Starting with Visual Basic 2017, you can also use the underscore character, `_`, as a digit separator to enhance readability, as the following example shows.

[!code-vb[integer](../../../../samples/snippets/visualbasic/language-reference/data-types/numeric-literals.vb#IntS)]  

Starting with Visual Basic 15.5, you can also use the underscore character (`_`) as a leading separator between the prefix and the hexadecimal, binary, or octal digits. For example:

```vb
Dim number As Integer = &H_C305_F860
```

[!INCLUDE [supporting-underscores](../../../../includes/vb-separator-langversion.md)]

Numeric literals can also include the `I` [type character](../../programming-guide\language-features\data-types/type-characters.md) to denote the `Integer` data type, as the following example shows.

```vb
Dim number = &H_035826I
```

## Programming tips

-   **Interop Considerations.** If you are interfacing with components not written for the .NET Framework, such as Automation or COM objects, remember that `Integer` has a different data width (16 bits) in other environments. If you are passing a 16-bit argument to such a component, declare it as `Short` instead of `Integer` in your new Visual Basic code.  
  
-   **Widening.** The `Integer` data type widens to `Long`, `Decimal`, `Single`, or `Double`. This means you can convert `Integer` to any one of these types without encountering a <xref:System.OverflowException?displayProperty=nameWithType> error.  
  
-   **Type Characters.** Appending the literal type character `I` to a literal forces it to the `Integer` data type. Appending the identifier type character `%` to any identifier forces it to `Integer`.  
  
-   **Framework Type.** The corresponding type in the .NET Framework is the <xref:System.Int32?displayProperty=nameWithType> structure.  
  
## Range

If you try to set a variable of an integral type to a number outside the range for that type, an error occurs. If you try to set it to a fraction, the number is rounded up or down to the nearest integer value. If the number is equally close to two integer values, the value is rounded to the nearest even integer. This behavior minimizes rounding errors that result from consistently rounding a midpoint value in a single direction. The following code shows examples of rounding.  

```vb  
' The valid range of an Integer variable is -2147483648 through +2147483647.  
Dim k As Integer  
' The following statement causes an error because the value is too large.  
k = 2147483648  
' The following statement sets k to 6.  
k = 5.9  
' The following statement sets k to 4  
k = 4.5  
' The following statement sets k to 6  
' Note, Visual Basic uses banker’s rounding (toward nearest even number)  
k = 5.5  
```

## See also

<xref:System.Int32?displayProperty=nameWithType>   
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Long Data Type](../../../visual-basic/language-reference/data-types/long-data-type.md)  
 [Short Data Type](../../../visual-basic/language-reference/data-types/short-data-type.md)  
 [Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)  
 [Conversion Summary](../../../visual-basic/language-reference/keywords/conversion-summary.md)  
 [Efficient Use of Data Types](../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)
