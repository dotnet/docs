---
title: "-filealign"
ms.date: 03/10/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "sections compiler option [Visual Basic]"
  - "alignment compiler option [Visual Basic]"
  - "-filealign compiler option [Visual Basic]"
  - "section alignment"
  - "/filealign compiler option [Visual Basic]"
  - "filealign compiler option [Visual Basic]"
ms.assetid: cc61ec3d-ad38-4b28-9659-099d73cad099
author: rpetrusha
ms.author: ronpet
---
# -filealign
Specifies where to align the sections of the output file.  
  
## Syntax  
  
```  
-filealign:number  
```  
  
## Arguments  
 `number`  
 Required. A value that specifies the alignment of sections in the output file. Valid values are 512, 1024, 2048, 4096, and 8192. These values are in bytes.  
  
## Remarks  
 You can use the `-filealign` option to specify the alignment of sections in your output file. Sections are blocks of contiguous memory in a Portable Executable (PE) file that contains either code or data. The `-filealign` option lets you compile your application with a nonstandard alignment; most developers do not need to use this option.  
  
 Each section is aligned on a boundary that is a multiple of the `-filealign` value. There is no fixed default. If `-filealign` is not specified, the compiler picks a default at compile time.  
  
 By specifying the section size, you can change the size of the output file. Modifying section size may be useful for programs that will run on smaller devices.  
  
> [!NOTE]
>  The `-filealign` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)
