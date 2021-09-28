---
description: "Learn more about: -utf8output (Visual Basic)"
title: "-utf8output"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "-utf8output compiler option [Visual Basic]"
  - "utf8output compiler option [Visual Basic]"
  - "/utf8output compiler option [Visual Basic]"
ms.assetid: 8ab36b1e-027a-49ac-85b4-f48997d9e4d6
---
# -utf8output (Visual Basic)

Displays compiler output using UTF-8 encoding.  
  
## Syntax  
  
```console  
-utf8output[+ | -]  
```  
  
## Arguments  

 `+` &#124; `-`  
 Optional. The default for this option is `-utf8output-`, which means compiler output does not use UTF-8 encoding. Specifying `-utf8output` is the same as specifying `-utf8output+`.  
  
## Remarks  

 In some international configurations, compiler output cannot be displayed correctly in the console. In such situations, use `-utf8output` and redirect compiler output to a file.  
  
> [!NOTE]
> The `-utf8output` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## Example  

 The following code compiles `In.vb` and directs the compiler to display output using UTF-8 encoding.  
  
```console  
vbc -utf8output in.vb  
```  
  
## See also

- [Visual Basic Command-Line Compiler](index.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
