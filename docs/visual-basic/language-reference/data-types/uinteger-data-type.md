---
title: "UInteger Data Type"
ms.date: 01/31/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.uinteger"
helpviewer_keywords: 
  - "numbers [Visual Basic], whole"
  - "UInteger data type"
  - "literal type characters [Visual Basic], UI"
  - "whole numbers"
  - "integral data types [Visual Basic]"
  - "integer numbers"
  - "numbers [Visual Basic], integer"
  - "integers [Visual Basic], data types"
  - "integers [Visual Basic], types"
  - "UI literal type characters [Visual Basic]"
  - "data types [Visual Basic], integral"
ms.assetid: db7ddd34-4f23-46f5-84dd-8b0f83bb8729
author: "rpetrusha"
ms.author: "ronpet"
---
# UInteger data type

Holds unsigned 32-bit (4-byte) integers ranging in value from 0 through 4,294,967,295.  
  
## Remarks

 The `UInteger` data type provides the largest unsigned value in the most efficient data width.  
  
 The default value of `UInteger` is 0.  
  
## Literal assignments

You can declare and initialize a `UInteger` variable by assigning it a decimal literal, a hexadecimal literal, an octal literal, or (starting with Visual Basic 2017) a binary literal. If the integer literal is outside the range of `UInteger` (that is, if it is less than <xref:System.UInt32.MinValue?displayProperty=nameWithType> or greater than <xref:System.UInt32.MaxValue?displayProperty=nameWithType>, a compilation error occurs.

In the following example, integers equal to 3,000,000,000 that are represented as decimal, hexadecimal, and binary literals are assigned to `UInteger` values.
  
[!code-vb[UInteger](../../../../samples/snippets/visualbasic/language-reference/data-types/numeric-literals.vb#UInt)]  

> [!NOTE] 
> You use the prefix `&h` or `&H` to denote a hexadecimal literal, the prefix `&b` or `&B` to denote a binary literal, and the prefix `&o` or `&O` to denote an octal literal. Decimal literals have no prefix.

Starting with Visual Basic 2017, you can also use the underscore character, `_`, as a digit separator to enhance readability, as the following example shows.

[!code-vb[UInteger](../../../../samples/snippets/visualbasic/language-reference/data-types/numeric-literals.vb#UIntS)]  

Starting with Visual Basic 15.5, you can also use the underscore character (`_`) as a leading separator between the prefix and the hexadecimal, binary, or octal digits. For example:

```vb
Dim number As UInteger = &H_0F8C_0326
```

[!INCLUDE [supporting-underscores](../../../../includes/vb-separator-langversion.md)]

Numeric literals can also include the `UI` or `ui` [type character](../../programming-guide\language-features\data-types/type-characters.md) to denote the `UInteger` data type, as the following example shows.

```vb
Dim number = &H_0FAC_14D7ui
```

## Programming tips

 The `UInteger` and `Integer` data types provide optimal performance on a 32-bit processor, because the smaller integer types (`UShort`, `Short`, `Byte`, and `SByte`), even though they use fewer bits, take more time to load, store, and fetch.  
  
-   **Negative Numbers.** Because `UInteger` is an unsigned type, it cannot represent a negative number. If you use the unary minus (`-`) operator on an expression that evaluates to type `UInteger`, Visual Basic converts the expression to `Long` first.  
  
-   **CLS Compliance.** The `UInteger` data type is not part of the [Common Language Specification](http://www.ecma-international.org/publications/standards/Ecma-335.htm) (CLS), so CLS-compliant code cannot consume a component that uses it.
  
-   **Interop Considerations.** If you are interfacing with components not written for the .NET Framework, for example Automation or COM objects, keep in mind that types such as `uint` can have a different data width (16 bits) in other environments. If you are passing a 16-bit argument to such a component, declare it as `UShort` instead of `UInteger` in your managed Visual Basic code.  
  
-   **Widening.** The `UInteger` data type widens to `Long`, `ULong`, `Decimal`, `Single`, and `Double`. This means you can convert `UInteger` to any of these types without encountering a <xref:System.OverflowException?displayProperty=nameWithType> error.  
  
-   **Type Characters.** Appending the literal type characters `UI` to a literal forces it to the `UInteger` data type. `UInteger` has no identifier type character.  
  
-   **Framework Type.** The corresponding type in the .NET Framework is the <xref:System.UInt32?displayProperty=nameWithType> structure.  
  
## See Also  
 <xref:System.UInt32>  
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)  
 [Conversion Summary](../../../visual-basic/language-reference/keywords/conversion-summary.md)  
 [How to: Call a Windows Function that Takes Unsigned Types](../../../visual-basic/programming-guide/com-interop/how-to-call-a-windows-function-that-takes-unsigned-types.md)  
 [Efficient Use of Data Types](../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)
