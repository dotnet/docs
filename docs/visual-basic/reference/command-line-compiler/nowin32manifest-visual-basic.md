---
title: "-nowin32manifest (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "/nowin32manifest compiler option [Visual Basic]"
  - "nowin32manifest compiler option [Visual Basic]"
  - "-nowin32manifest compiler option [Visual Basic]"
ms.assetid: c0528aae-83b3-4425-99f0-19448e9843e3
caps.latest.revision: 7
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# /nowin32manifest (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Instructs the compiler not to embed any application manifest into the executable file.  
  
## Syntax  
  
```  
/nowin32manifest  
```  
  
## Remarks  
 When this option is used, the application will be subject to virtualization on Windows Vista unless you provide an application manifest in a Win32 Resource file or during a later build step. For more information about virtualization, see [ClickOnce Deployment on Windows Vista](/visual-studio/deployment/clickonce-deployment-on-windows-vista).  
  
 For more information about manifest creation, see [/win32manifest (Visual Basic)](../../../visual-basic/reference/command-line-compiler/win32manifest-visual-basic.md).  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)   
 [Application Page, Project Designer (Visual Basic)](/visual-studio/ide/reference/application-page-project-designer-visual-basic)