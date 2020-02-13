---
title: "-codepage"
ms.date: 03/09/2018
helpviewer_keywords: 
  - "-codepage compiler option [Visual Basic]"
  - "codepage compiler option [Visual Basic]"
  - "-codepage compiler option [Visual Basic]"
ms.assetid: be36ec33-6800-4505-838c-4124564f5cc9
---
# -codepage (Visual Basic)
Specifies the code page to use for all source-code files in the compilation.  
  
## Syntax  
  
```console  
-codepage:id  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`id`|Required. The compiler uses the code page specified by `id` to interpret the encoding of the source files.|  
  
## Remarks  
 To compile source code saved with a specific encoding, you can use `-codepage` to specify which code page should be used. The `-codepage` option applies to all source-code files in your compilation. For more information, see [Character Encoding in the .NET Framework](../../../standard/base-types/character-encoding.md).  
  
 The `-codepage` option is not needed if the source-code files were saved using the current ANSI code page, Unicode, or UTF-8 with a signature. Visual Studio saves all source-code files with the current ANSI code page by default, unless the user specifies another encoding in the **Encoding** dialog box. Visual Studio uses the **Encoding** dialog box to open source-code files saved with a different code page.  
  
> [!NOTE]
> The `-codepage` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## See also

- [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)
