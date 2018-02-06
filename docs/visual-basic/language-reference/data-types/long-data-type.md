---
title: "Long Data Type (Visual Basic)"
ms.date: 01/31/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Long"
helpviewer_keywords: 
  - "identifier type characters [Visual Basic], &"
  - "numbers [Visual Basic], whole"
  - "whole numbers"
  - "integral data types [Visual Basic]"
  - "& identifier type character"
  - "integer numbers"
  - "literal type characters [Visual Basic], L"
  - "numbers [Visual Basic], integer"
  - "integers [Visual Basic], data types"
  - "L literal type character [Visual Basic]"
  - "integers [Visual Basic], types"
  - "Long keyword [Visual Basic]"
  - "data types [Visual Basic], integral"
  - "data types [Visual Basic], assigning"
  - "Long data type"
ms.assetid: b4770c34-1804-4f8c-b512-c10b0893e516
author: "rpetrusha"
ms.author: "ronpet"
---
# Long data type (Visual Basic)

Holds signed 64-bit (8-byte) integers ranging in value from -9,223,372,036,854,775,808 through 9,223,372,036,854,775,807 (9.2...E+18).  
  
## Remarks

 Use the `Long` data type to contain integer numbers that are too large to fit in the `Integer` data type.  
  
 The default value of `Long` is 0.

## Literal assignments 

You can declare and initialize a `Long` variable by assigning it a decimal literal, a hexadecimal literal, an octal literal, or (starting with Visual Basic 2017) a binary literal. If the integer literal is outside the range of `Long` (that is, if it is less than <xref:System.Int64.MinValue?displayProperty=nameWithType> or greater than <xref:System.Int64.MaxValue?displayProperty=nameWithType>, a compilation error occurs.

In the following example, integers equal to 4,294,967,296 that are represented as decimal, hexadecimal, and binary literals are assigned to `Long` values.
  
[!code-vb[long](../../../../samples/snippets/visualbasic/language-reference/data-types/numeric-literals.vb#Long)]  

> [!NOTE]
> You use the prefix `&h` or `&H` to denote a hexadecimal literal, the prefix `&b` or `&B` to denote a binary literal, and the prefix `&o` or `&O` to denote an octal literal. Decimal literals have no prefix.

Starting with Visual Basic 2017, you can also use the underscore character, `_`, as a digit separator to enhance readability, as the following example shows.

[!code-vb[long](../../../../samples/snippets/visualbasic/language-reference/data-types/numeric-literals.vb#LongS)]

Starting with Visual Basic 15.5, you can also use the underscore character (`_`) as a leading separator between the prefix and the hexadecimal, binary, or octal digits. For example:

```vb
Dim number As Long = &H_0FAC_0326_1489_D68C
```

[!INCLUDE [supporting-underscores](../../../../includes/vb-separator-langversion.md)]

Numeric literals can also include the `L` [type character](../../programming-guide\language-features\data-types/type-characters.md) to denote the `Long` data type, as the following example shows.

```vb
Dim number = &H_0FAC_0326_1489_D68CL
```

## Programming tips

-   **Interop Considerations.** If you are interfacing with components not written for the .NET Framework, for example Automation or COM objects, remember that `Long` has a different data width (32 bits) in other environments. If you are passing a 32-bit argument to such a component, declare it as `Integer` instead of `Long` in your new Visual Basic code.  
  
-   **Widening.** The `Long` data type widens to `Decimal`, `Single`, or `Double`. This means you can convert `Long` to any one of these types without encountering a <xref:System.OverflowException?displayProperty=nameWithType> error.  
  
-   **Type Characters.** Appending the literal type character `L` to a literal forces it to the `Long` data type. Appending the identifier type character `&` to any identifier forces it to `Long`.  
  
-   **Framework Type.** The corresponding type in the .NET Framework is the <xref:System.Int64?displayProperty=nameWithType> structure.  

## See also

<xref:System.Int64>
[Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)   
[Integer Data Type](../../../visual-basic/language-reference/data-types/integer-data-type.md)   
[Short Data Type](../../../visual-basic/language-reference/data-types/short-data-type.md)   
[Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)   
[Conversion Summary](../../../visual-basic/language-reference/keywords/conversion-summary.md)   
[Efficient Use of Data Types](../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)
