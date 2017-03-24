---
title: "Option -win32manifest ignored | Microsoft Docs"
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
  - "vbc2034"
  - "bc2034"
helpviewer_keywords: 
  - "BC2034"
ms.assetid: 8009553a-f6ba-4d2b-8ddd-8a9357bc928e
caps.latest.revision: 5
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Option /win32manifest ignored
Option /win32manifest ignored. It can be specified only when the target is an assembly.  
  
 The Visual Basic compiler has been passed the `/win32manifest` compiler option when the `/target` option is set to `module`.  
  
 **Error ID:** BC2034  
  
### To correct this error  
  
1.  Remove the `/win32manifest` compiler option or set the `/target` option to `exe`, `winexe`, or `library`.  
  
## See Also  
 [/target (Visual Basic)](../../visual-basic/reference/command-line-compiler/target-visual-basic.md)   
 [/win32manifest (Visual Basic)](../../visual-basic/reference/command-line-compiler/win32manifest-visual-basic.md)   
 [Visual Basic Command-Line Compiler](../../visual-basic/reference/command-line-compiler/index.md)