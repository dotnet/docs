---
title: "-rootnamespace | Microsoft Docs"
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
  - "/rootnamespace"
  - "rootnamespace"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "/rootnamespace compiler option [Visual Basic]"
  - "-rootnamespace compiler option [Visual Basic]"
  - "rootnamespace compiler option [Visual Basic]"
ms.assetid: e9245edf-6bef-420d-a7c7-324117752783
caps.latest.revision: 13
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# /rootnamespace
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Specifies a namespace for all type declarations.  
  
## Syntax  
  
```  
/rootnamespace:namespace  
```  
  
## Arguments  
  
|||  
|-|-|  
|Term|Definition|  
|`namespace`|The name of the namespace in which to enclose all type declarations for the current project.|  
  
## Remarks  
 If you use the Visual Studio executable file (Devenv.exe) to compile a project created in the Visual Studio integrated development environment, use `/rootnamespace` to specify the value of the <xref:VSLangProj80.VBProjectProperties3.RootNamespace%2A> property. See [Devenv Command Line Switches](/visual-studio/ide/reference/devenv-command-line-switches) for more information.  
  
 Use the common language runtime MSIL Disassembler (I`ldasm.exe`) to view the namespace names in your output file.  
  
||  
|-|  
|To set /rootnamespace in the Visual Studio integrated development environment|  
|1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**. For more information, see [Introduction to the Project Designer](http://msdn.microsoft.com/en-us/898dd854-c98d-430c-ba1b-a913ce3c73d7).<br />2.  Click the **Application** tab.<br />3.  Modify the value in the **Root Namespace** box.|  
  
## Example  
 The following code compiles `In.vb` and encloses all type declarations in the namespace `mynamespace`.  
  
```  
vbc /rootnamespace:mynamespace in.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)   
 [Ildasm.exe (IL Disassembler)](../Topic/Ildasm.exe%20\(IL%20Disassembler\).md)   
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)