---
title: "-out (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "/out compiler option [Visual Basic]"
  - "-out compiler option [Visual Basic]"
  - "out compiler option [Visual Basic]"
ms.assetid: 9f148c15-0909-4cb8-a2db-777f8a8b45ae
author: rpetrusha
ms.author: ronpet
---
# -out (Visual Basic)
Specifies the name of the output file.  
  
## Syntax  
  
```  
-out:filename  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`filename`|Required. The name of the output file the compiler creates. If the file name contains a space, enclose the name in quotation marks (" ").|  
  
## Remarks  
 Specify the full name and extension of the file to create. If you do not, the .exe file takes its name from the source-code file containing the `Sub Main` procedure, and the .dll file takes its name from the first source-code file.  
  
 If you specify a file name without an .exe or .dll extension, the compiler automatically adds the extension for you, depending on the value specified for the `-target` compiler option.  
  
|To set -out in the Visual Studio integrated development environment|  
|---|  
|1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**. <br />2.  Click the **Application** tab.<br />3.  Modify the value in the **Assembly Name** box.|  
  
## Example  
 The following code compiles `T2.vb` and creates output file `T2.exe`.  
  
```console
vbc t2.vb -out:t3.exe  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [-target (Visual Basic)](../../../visual-basic/reference/command-line-compiler/target.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)
