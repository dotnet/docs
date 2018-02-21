---
title: "Structure &#39;&lt;structurename&gt;&#39; must contain at least one instance member variable or at least one instance event declaration not marked &#39;Custom&#39;"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc30941"
  - "vbc30941"
helpviewer_keywords: 
  - "BC30941"
ms.assetid: 7054cc1e-bac3-4c3d-82f3-35772bd8dd3b
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# Structure &#39;&lt;structurename&gt;&#39; must contain at least one instance member variable or at least one instance event declaration not marked &#39;Custom&#39;
A structure definition does not include any nonshared variables or nonshared noncustom events.  
  
 Every structure must have either a variable or an event that applies to each specific instance (nonshared) instead of to all instances collectively ([Shared](../../../visual-basic/language-reference/modifiers/shared.md)). Nonshared constants, properties, and procedures do not satisfy this requirement. In addition, if there are no nonshared variables and only one nonshared event, that event cannot be a `Custom` event.  
  
 **Error ID:** BC30941  
  
## To correct this error  
  
-   Define at least one variable or event that is not `Shared`. If you define only one event, it must be noncustom as well as nonshared.  
  
## See Also  
 [Structures](../../../visual-basic/programming-guide/language-features/data-types/structures.md)  
 [How to: Declare a Structure](../../../visual-basic/programming-guide/language-features/data-types/how-to-declare-a-structure.md)  
 [Structure Statement](../../../visual-basic/language-reference/statements/structure-statement.md)
