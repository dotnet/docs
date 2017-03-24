---
title: "File not found (Visual Basic Run-Time Error) | Microsoft Docs"
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
  - "vbrID53"
dev_langs: 
  - "VB"
ms.assetid: 57addb16-6f9a-444d-8af8-dda52431daca
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# File not found (Visual Basic Run-Time Error)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

The file was not found where specified. The error has the following possible causes:  
  
-   A statement refers to a file that does not exist.  
  
-   An attempt was made to call a procedure in a dynamic-link library (DLL), but the library specified in the `Lib` clause of the `Declare` statement cannot be found.  
  
-   You attempted to open a project or load a text file that does not exist.  
  
### To correct this error  
  
1.  Check the spelling of the file name and the path specification.  
  
## See Also  
 [Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md)