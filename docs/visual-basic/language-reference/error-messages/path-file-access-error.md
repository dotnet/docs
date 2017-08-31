---
title: "Path-File access error | Microsoft Docs"
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
  - "vbrID75"
dev_langs: 
  - "VB"
ms.assetid: 6ce3a161-7316-46bd-a785-0d50e5414020
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Path/File access error
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

During a file-access or disk-access operation, the operating system could not make a connection between the path and the file name.  
  
### To correct this error  
  
1.  Make sure the file specification is correctly formatted. A file name can contain a fully qualified (absolute) or relative path. A fully qualified path starts with the drive name (if the path is on another drive) and lists the explicit path from the root to the file. Any path that is not fully qualified is relative to the current drive and directory.  
  
2.  Make sure that you did not attempt to save a file that would replace an existing read-only file. If this is the case, change the read-only attribute of the target file, or save the file with a different file name.  
  
3.  Make sure you did not attempt to open a read-only file in sequential`Output`or `Append` mode. If this is the case, open the file in `Input` mode or change the read-only attribute of the file.  
  
4.  Make sure you did not attempt to change a [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] project within a database or document.  
  
## See Also  
 [Error Types](../../../visual-basic/programming-guide/language-features/error-types.md)