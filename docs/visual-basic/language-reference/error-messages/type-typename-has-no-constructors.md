---
title: "Type &#39;&lt;typename&gt;&#39; has no constructors"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc30251"
  - "vbc30251"
helpviewer_keywords: 
  - "BC30251"
ms.assetid: aff3e1df-abe6-4bc0-9abc-a1e70514c561
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# Type &#39;&lt;typename&gt;&#39; has no constructors
A type does not support a call to `Sub New()`. One possible cause is a corrupted compiler or binary file.  
  
 **Error ID:** BC30251  
  
## To correct this error  
  
1.  If the type is in a different project or in a referenced file, reinstall the project or file.  
  
2.  If the type is in the same project, recompile the assembly containing the type.  
  
3.  If the error recurs, reinstall the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler.  
  
4.  If the error persists, gather information about the circumstances and notify Microsoft Product Support Services.  
  
## See Also  
 [Objects and Classes](../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md)  
 [Talk to Us](/visualstudio/ide/talk-to-us)
