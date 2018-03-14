---
title: "Variable uses an Automation type not supported in Visual Basic"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbrID458"
ms.assetid: bde4f4da-493b-452c-b6e4-1d370edba4cd
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
---
# Variable uses an Automation type not supported in Visual Basic
You tried to use a variable defined in a type library or object library that has a data type not supported by [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)].  
  
## To correct this error  
  
-   Use a variable of a type recognized by [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)].  
  
     -or-  
  
-   If you encounter this error while using `FileGet` or `FileGetOBject`, make sure the file you are trying to use was written to with `FilePut` or `FilePutObject`.  
  
## See Also  
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)
