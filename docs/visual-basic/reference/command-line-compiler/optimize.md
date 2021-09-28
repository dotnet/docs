---
description: "Learn more about: -optimize"
title: "-optimize"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "optimize compiler option [Visual Basic]"
  - "/optimize compiler option [Visual Basic]"
  - "optimization [Visual Basic], enabling"
  - "-optimize compiler option [Visual Basic]"
ms.assetid: fcba4a97-3622-4b87-a891-0f77deab4998
---
# -optimize

Enables or disables compiler optimizations.  
  
## Syntax  
  
```console  
-optimize[ + | - ]  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`+` &#124; `-`|Optional. The `-optimize-` option disables compiler optimizations. The `-optimize+` option enables optimizations. By default, optimizations are disabled.|  
  
## Remarks  

 Compiler optimizations make your output file smaller, faster, and more efficient. However, because optimizations result in code rearrangement in the output file, `-optimize+` can make debugging difficult.  
  
 All modules generated with `-target:module` for an assembly must use the same `-optimize` settings as the assembly. For more information, see [-target (Visual Basic)](target.md).  
  
 You can combine the `-optimize` and `-debug` options.  
  
|To set -optimize in the Visual Studio integrated development environment|  
|---|  
|1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**.<br />     <br />2.  Click the **Compile** tab.<br />3.  Click the **Advanced** button.<br />4.  Modify the **Enable optimizations** check box.|  
  
## Example  

 The following code compiles `T2.vb` and enables compiler optimizations.  
  
```console
vbc t2.vb -optimize  
```  
  
## See also

- [Visual Basic Command-Line Compiler](index.md)
- [-debug (Visual Basic)](debug.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
- [-target (Visual Basic)](target.md)
