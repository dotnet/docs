---
title: "Byte Data Type (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "vb.Byte"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "Byte data type"
  - "data types [Visual Basic], assigning"
ms.assetid: eed44dff-eaee-4937-a89f-444e418e74f6
caps.latest.revision: 18
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Byte Data Type (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Holds unsigned 8-bit (1-byte) integers that range in value from 0 through 255.  
  
## Remarks  
 Use the `Byte` data type to contain binary data.  
  
 The default value of `Byte` is 0.  
  
## Programming Tips  
  
-   **Negative Numbers.** Because `Byte` is an unsigned type, it cannot represent a negative number. If you use the unary minus (`-`) operator on an expression that evaluates to type `Byte`, Visual Basic converts the expression to `Short` first.  
  
-   **Format Conversions.** When Visual Basic reads or writes files, or when it calls DLLs, methods, and properties, it can automatically convert between data formats. Binary data stored in `Byte` variables and arrays is preserved during such format conversions. You should not use a `String` variable for binary data, because its contents can be corrupted during conversion between ANSI and Unicode formats.  
  
-   **Widening.** The `Byte` data type widens to `Short`, `UShort`, `Integer`, `UInteger`, `Long`, `ULong`, `Decimal`, `Single`, or `Double`. This means you can convert `Byte` to any of these types without encountering a <xref:System.OverflowException?displayProperty=fullName> error.  
  
-   **Type Characters.** `Byte` has no literal type character or identifier type character.  
  
-   **Framework Type.** The corresponding type in the .NET Framework is the <xref:System.Byte?displayProperty=fullName> structure.  
  
## Example  
 In the following example, `b` is a `Byte` variable. The statements demonstrate the range of the variable and the application of bit-shift operators to it.  
  
 [!code-vb[VbVbalrDataTypes#16](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDataTypes/VB/Class1.vb#16)]  
  
## See Also  
 <xref:System.Byte?displayProperty=fullName>   
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)   
 [Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)   
 [Conversion Summary](../../../visual-basic/language-reference/keywords/conversion-summary.md)   
 [Efficient Use of Data Types](../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)