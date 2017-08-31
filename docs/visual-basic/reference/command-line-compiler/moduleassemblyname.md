---
title: "-moduleassemblyname | Microsoft Docs"
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
  - "moduleassemblyname compiler option [Visual Basic]"
  - "/moduleassemblyname compiler option [Visual Basic]"
  - "-moduleassemblyname compiler option [Visual Basic]"
ms.assetid: 013a57b6-f425-4dd3-b333-512d72c42f55
caps.latest.revision: 16
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# /moduleassemblyname
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Specifies the name of the assembly that this module will be a part of.  
  
## Syntax  
  
```  
/moduleassemblyname:assembly_name  
```  
  
## Arguments  
  
|||  
|-|-|  
|Term|Definition|  
|`assembly_name`|The name of the assembly that this module will be a part of.|  
  
## Remarks  
 The compiler processes the `/moduleassemblyname` option only if the `/target:module` option has been specified. This causes the compiler to create a module. The module created by the compiler is valid only for the assembly specified with the `/moduleassemblyname` option. If you place the module in a different assembly, run-time errors will occur.  
  
 The `/moduleassemblyname` option is needed only when the following are true:  
  
-   A data type in the module needs access to a `Friend` type in a referenced assembly.  
  
-   The referenced assembly has granted friend assembly access to the assembly into which the module will be built.  
  
 For more information about creating a module, see [/target (Visual Basic)](../../../visual-basic/reference/command-line-compiler/target-visual-basic.md). For more information about friend assemblies, see [Friend Assemblies](http://msdn.microsoft.com/library/df0c70ea-2c2a-4bdc-9526-df951ad2d055).  
  
> [!NOTE]
>  The `/moduleassemblyname` option is not available from within the Visual Studio development environment; it is available only when you compile from a command prompt.  
  
## See Also  
 [How to: Build a Multifile Assembly](~/docs/framework/app-domains/how-to-build-a-multifile-assembly.md)   
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)   
 [/target (Visual Basic)](../../../visual-basic/reference/command-line-compiler/target-visual-basic.md)   
 [/main](../../../visual-basic/reference/command-line-compiler/main.md)   
 [/reference (Visual Basic)](../../../visual-basic/reference/command-line-compiler/reference-visual-basic.md)   
 [/addmodule](../../../visual-basic/reference/command-line-compiler/addmodule.md)   
 [Assemblies and the Global Assembly Cache](http://msdn.microsoft.com/library/35127020-6dd6-4a2a-8db8-4b2ceb658b28)   
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)   
 [Friend Assemblies](http://msdn.microsoft.com/library/df0c70ea-2c2a-4bdc-9526-df951ad2d055)