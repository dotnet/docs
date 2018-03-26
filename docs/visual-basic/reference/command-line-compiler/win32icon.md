---
title: "-win32icon"
ms.date: 03/13/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "win32icon compiler option [Visual Basic]"
  - "-win32icon compiler option [Visual Basic]"
  - "/win32icon compiler option [Visual Basic]"
ms.assetid: aecaab01-9353-46c5-941c-6edabd4eff92
author: rpetrusha
ms.author: ronpet
---
# -win32icon
Inserts an .ico file in the output file. This .ico file represents the output file in **File Explorer**.  
  
## Syntax  
  
```  
-win32icon:filename  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`filename`|The .ico file to add to your output file. Enclose the file name in quotation marks (" ") if it contains a space.|  
  
## Remarks  
 You can create an .ico file with the Microsoft Windows Resource Compiler (RC). The resource compiler is invoked when you compile a Visual C++ program; an .ico file is created from the .rc file. The `-win32icon` and `-win32resource` options are mutually exclusive.  
  
 See [-linkresource (Visual Basic)](../../../visual-basic/reference/command-line-compiler/linkresource.md) to reference a [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] resource file, or [-resource (Visual Basic)](../../../visual-basic/reference/command-line-compiler/resource.md) to attach a [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] resource file. See [-win32resource](../../../visual-basic/reference/command-line-compiler/win32resource.md) to import a .res file.  
  
|To set -win32icon in the Visual Studio IDE|  
|---|  
|1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**. <br />2.  Click the **Application** tab.<br />3.  Modify the value in the **Icon** box.|  
  
## Example  
 The following code compiles `In.vb` and attaches an .ico file, `Rf.ico`.  
  
```console
vbc -win32icon:rf.ico in.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)
