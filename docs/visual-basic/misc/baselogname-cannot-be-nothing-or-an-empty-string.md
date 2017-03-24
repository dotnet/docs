---
title: "BaseLogName cannot be Nothing or an empty String | Microsoft Docs"
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
  - "vbrApplicationLogBaseNameNull"
ms.assetid: 8e7665e3-5343-45fa-bc79-64e235a0477f
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# BaseLogName cannot be Nothing or an empty String
The value of the <xref:Microsoft.VisualBasic.Logging.FileLogTraceListener.BaseFileName%2A> property cannot be `Nothing` or an empty string.  
  
 The <xref:Microsoft.VisualBasic.Logging.FileLogTraceListener.BaseFileName%2A> property specifies the base name for the log files.  
  
### To correct this error  
  
-   Set the <xref:Microsoft.VisualBasic.Logging.FileLogTraceListener.BaseFileName%2A> property to a string that contains at least one character.  
  
## See Also  
 <xref:Microsoft.VisualBasic.Logging.FileLogTraceListener.BaseFileName%2A>   
 [My.Application.Log Object](../../visual-basic/language-reference/objects/my-application-log-object.md)   
 [My.Log Object](../../visual-basic/language-reference/objects/my-log-object.md)