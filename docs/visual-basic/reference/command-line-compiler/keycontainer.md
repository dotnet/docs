---
title: "-keycontainer | Microsoft Docs"
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
  - "-keycontainer compiler option [Visual Basic]"
  - "keycontainer compiler option [Visual Basic]"
  - "/keycontainer compiler option [Visual Basic]"
ms.assetid: 6a9bc861-1752-4db1-9f64-b5252f0482cc
caps.latest.revision: 16
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# /keycontainer
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Specifies a key container name for a key pair to give an assembly a strong name.  
  
## Syntax  
  
```  
/keycontainer:container  
```  
  
## Arguments  
  
|||  
|-|-|  
|Term|Definition|  
|`container`|Required. Container file that contains the key. Enclose the file name in quotation marks ("") if the name contains a space.|  
  
## Remarks  
 The compiler creates the sharable component by inserting a public key into the assembly manifest and by signing the final assembly with the private key. To generate a key file, type `sn -k``file` at the command line. The `-i` option installs the key pair into a container. For more information, see [Sn.exe (Strong Name Tool)](../Topic/Sn.exe%20\(Strong%20Name%20Tool\).md).  
  
 If you compile with `/target:module`, the name of the key file is held in the module and incorporated into the assembly that is created when you compile an assembly with [/addmodule](../../../visual-basic/reference/command-line-compiler/addmodule.md).  
  
 You can also specify this option as a custom attribute (<xref:System.Reflection.AssemblyKeyNameAttribute>) in the source code for any Microsoft intermediate language (MSIL) module.  
  
 You can also pass your encryption information to the compiler with [/keyfile](../../../visual-basic/reference/command-line-compiler/keyfile.md). Use [/delaysign](../../../visual-basic/reference/command-line-compiler/delaysign.md) if you want a partially signed assembly.  
  
 See [Creating and Using Strong-Named Assemblies](../Topic/Creating%20and%20Using%20Strong-Named%20Assemblies.md) for more information on signing an assembly.  
  
> [!NOTE]
>  The `/keycontainer` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## Example  
 The following code compiles source file `Input.vb` and specifies a key container.  
  
```  
vbc /keycontainer:key1 input.vb  
```  
  
## See Also  
 [Assemblies and the Global Assembly Cache](../Topic/Assemblies%20and%20the%20Global%20Assembly%20Cache%20\(C%23%20and%20Visual%20Basic\).md)   
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)   
 [/keyfile](../../../visual-basic/reference/command-line-compiler/keyfile.md)   
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)