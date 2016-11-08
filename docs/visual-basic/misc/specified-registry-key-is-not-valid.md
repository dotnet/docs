---
title: "Specified registry key is not valid because it contains two or more consecutive backslashes | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0d78b6f7-5759-45b4-8c37-c6902ada76ff
caps.latest.revision: 9
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Specified registry key is not valid because it contains two or more consecutive backslashes
A registry key specified with a path contains two or more consecutive backslashes. This may be a result of combining several strings to form the path and inadvertently including too many backslashes.  
  
### To correct this error  
  
-   Examine the registry key being specified to determine where and why the extra backslashes are being inserted.  
  
## See Also  
 [How to: Parse File Paths](../../visual-basic/developing-apps/programming/drives-directories-files/how-to-parse-file-paths.md)   
 [My.Computer.Registry Object](../../visual-basic/language-reference/objects/my-computer-registry-object.md)