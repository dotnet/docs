---
title: "SByte Data Type (Visual Basic) | Microsoft Docs"
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
  - "vb.sbyte"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "numbers, whole"
  - "whole numbers"
  - "integral data types"
  - "integer numbers"
  - "numbers, integer"
  - "integers, data types"
  - "integers, types"
  - "data types [Visual Basic], integral"
  - "SByte data type"
ms.assetid: 5c38374a-18a1-4cc2-b493-299e3dcaa60f
caps.latest.revision: 18
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# SByte Data Type (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Holds signed 8-bit (1-byte) integers that range in value from -128 through 127.  
  
## Remarks  
 Use the `SByte` data type to contain integer values that do not require the full data width of `Integer` or even the half data width of `Short`. In some cases the common language runtime might be able to pack your `SByte` variables closely together and save memory consumption.  
  
 The default value of `SByte` is 0.  
  
## Programming Tips  
  
-   **CLS Compliance.** The `SByte` data type is not part of the [Language Independence and Language-Independent Components](../Topic/Language%20Independence%20and%20Language-Independent%20Components.md) (CLS), so CLS-compliant code cannot consume a component that uses it.  
  
-   **Widening.** The `SByte` data type widens to `Short`, `Integer`, `Long`, `Decimal`, `Single`, and `Double`. This means you can convert `SByte` to any of these types without encountering a <xref:System.OverflowException?displayProperty=fullName> error.  
  
-   **Type Characters.** `SByte` has no literal type character or identifier type character.  
  
-   **Framework Type.** The corresponding type in the .NET Framework is the <xref:System.SByte?displayProperty=fullName> structure.  
  
## See Also  
 <xref:System.SByte?displayProperty=fullName>   
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)   
 [Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)   
 [Conversion Summary](../../../visual-basic/language-reference/keywords/conversion-summary.md)   
 [Short Data Type](../../../visual-basic/language-reference/data-types/short-data-type.md)   
 [Integer Data Type](../../../visual-basic/language-reference/data-types/integer-data-type.md)   
 [Long Data Type](../../../visual-basic/language-reference/data-types/long-data-type.md)   
 [Efficient Use of Data Types](../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)