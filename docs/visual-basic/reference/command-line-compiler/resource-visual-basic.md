---
title: "-resource (Visual Basic) | Microsoft Docs"
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
  - "/resource compiler option [Visual Basic]"
  - "-resource compiler option [Visual Basic]"
  - "/res compiler option [Visual Basic]"
  - "res compiler option [Visual Basic]"
  - "-res compiler option [Visual Basic]"
  - "resource compiler option [Visual Basic]"
ms.assetid: eee2f227-91f2-4f2b-a9d6-1c51c5320858
caps.latest.revision: 19
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# /resource (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Embeds a managed resource in an assembly.  
  
## Syntax  
  
```  
/resource:filename[,identifier[,public|private]]  
' -or-  
/res:filename[,identifier[,public|private]]  
```  
  
## Arguments  
  
|||  
|-|-|  
|Term|Definition|  
|`filename`|Required. The name of the resource file to embed in the output file. By default, `filename` is public in the assembly. Enclose the file name in quotation marks (" ") if it contains a space.|  
|`identifier`|Optional. The logical name for the resource; the name used to load it. The default is the name of the file. Optionally, you can specify whether the resource is public or private in the assembly manifest, as with the following: `/res:``filename.res`,`myname.res`,`public`|  
  
## Remarks  
 Use `/linkresource` to link a resource to an assembly without placing the resource file in the output file.  
  
 If `filename` is a [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] resource file created, for example, by the [Resgen.exe (Resource File Generator)](../Topic/Resgen.exe%20\(Resource%20File%20Generator\).md) or in the development environment, it can be accessed with members in the <xref:System.Resources> namespace (see <xref:System.Resources.ResourceManager> for more information). To access all other resources at run time, use one of the following methods: <xref:System.Reflection.Assembly.GetManifestResourceInfo%2A>, <xref:System.Reflection.Assembly.GetManifestResourceNames%2A>, or <xref:System.Reflection.Assembly.GetManifestResourceStream%2A>.  
  
 The short form of `/resource` is `/res`.  
  
 For information about how to set `/resource` in the Visual Studio IDE, see [Managing Application Resources (.NET)](/visual-studio/ide/managing-application-resources-dotnet).  
  
## Example  
 The following code compiles `In.vb` and attaches resource file `Rf.resource`.  
  
```  
vbc /res:rf.resource in.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)   
 [/win32resource](../../../visual-basic/reference/command-line-compiler/win32resource.md)   
 [/linkresource (Visual Basic)](../../../visual-basic/reference/command-line-compiler/linkresource-visual-basic.md)   
 [/target (Visual Basic)](../../../visual-basic/reference/command-line-compiler/target-visual-basic.md)   
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)