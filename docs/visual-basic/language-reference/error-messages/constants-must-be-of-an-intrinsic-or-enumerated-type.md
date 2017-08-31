---
title: "Constants must be of an intrinsic or enumerated type, not a class, structure, type parameter, or array type | Microsoft Docs"
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
  - "vbc30424"
  - "bc30424"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30424"
ms.assetid: 2d402c2f-27ad-428b-b699-d45cd62f7196
caps.latest.revision: 12
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Constants must be of an intrinsic or enumerated type, not a class, structure, type parameter, or array type
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

You have attempted to declare a constant as a class, structure, or array type, or as a type parameter defined by a containing generic type.  
  
 Constants must be of an intrinsic type (`Boolean`, `Byte`, `Date`, `Decimal`, `Double`, `Integer`, `Long`, `Object`, `SByte`, `Short`, `Single`, `String`, `UInteger`, `ULong`, or `UShort`), or an `Enum` type based on one of the integral types.  
  
 **Error ID:** BC30424  
  
### To correct this error  
  
1.  Declare the constant as an intrinsic or `Enum` type.  
  
2.  A constant can also be a special value such as `True`, `False`, or `Nothing`. The compiler considers these predefined values to be of the appropriate intrinsic type.  
  
## See Also  
 [Constants and Enumerations](../../../visual-basic/language-reference/constants-and-enumerations.md)   
 [Data Types](../../../visual-basic/programming-guide/language-features/data-types/index.md)   
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)