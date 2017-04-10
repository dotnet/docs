---
title: "Can&#39;t create necessary temporary file | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbrID322"
dev_langs: 
  - "VB"
ms.assetid: 53617b5b-eb06-4188-b4c2-8607cb9fbc79
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Can&#39;t create necessary temporary file
Either the drive is full that contains the directory specified by the TEMP environment variable, or the TEMP environment variable specifies an invalid or read-only drive or directory.  
  
## To correct this error  
  
1.  Delete files from the drive, if full.  
  
2.  Specify a different drive in the TEMP environment variable.  
  
3.  Specify a valid drive for the TEMP environment variable.  
  
4.  Remove the read-only restriction from the currently specified drive or directory.  
  
## See Also  
 [Error Types](../../../visual-basic/programming-guide/language-features/error-types.md)