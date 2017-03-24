---
title: "File already open | Microsoft Docs"
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
  - "vbrID55"
dev_langs: 
  - "VB"
ms.assetid: d674a0fb-ef16-4cc2-9da7-709a8a07dbea
caps.latest.revision: 7
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# File already open
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Sometimes a file must be closed before another `FileOpen` or other operation can occur. Among the possible causes of this error are:  
  
-   A sequential output mode `FileOpen` operation was executed for a file that is already open  
  
-   A statement refers to an open file.  
  
### To correct this error  
  
1.  Close the file before executing the statement.  
  
## See Also  
 <xref:Microsoft.VisualBasic.FileSystem.FileOpen%2A>