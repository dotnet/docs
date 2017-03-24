---
title: "-help, -? (Visual Basic) | Microsoft Docs"
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
  - "/? compiler option [Visual Basic]"
  - "-help compiler option [Visual Basic]"
  - "/help compiler option [Visual Basic]"
  - "help compiler option [Visual Basic]"
  - "-? compiler option [Visual Basic]"
  - "? compiler option [Visual Basic]"
ms.assetid: eb984aa5-ac98-4d0b-a0d2-24238d7bc8dc
caps.latest.revision: 11
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# /help, /? (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Displays the compiler options.  
  
## Syntax  
  
```  
/help  
' -or-  
/?  
```  
  
## Remarks  
 If you include this option in a compilation, no output file is created and no compilation takes place.  
  
> [!NOTE]
>  The `/help` option is not available from within the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] development environment; it is available only when compiling from the command line.  
  
## Example  
 The following code displays help from the command line.  
  
```  
vbc /help  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)   
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)