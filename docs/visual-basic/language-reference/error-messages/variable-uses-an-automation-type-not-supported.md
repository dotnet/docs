---
title: "Variable uses an Automation type not supported in Visual Basic | Microsoft Docs"
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
  - "vbrID458"
dev_langs: 
  - "VB"
ms.assetid: bde4f4da-493b-452c-b6e4-1d370edba4cd
caps.latest.revision: 12
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Variable uses an Automation type not supported in Visual Basic
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

You tried to use a variable defined in a type library or object library that has a data type not supported by [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)].  
  
### To correct this error  
  
-   Use a variable of a type recognized by [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)].  
  
     -or-  
  
-   If you encounter this error while using `FileGet` or `FileGetOBject`, make sure the file you are trying to use was written to with `FilePut` or `FilePutObject`.  
  
## See Also  
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)