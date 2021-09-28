---
description: "Learn more about: -recurse"
title: "-recurse"
ms.date: 03/13/2018
helpviewer_keywords: 
  - "/recurse compiler option [Visual Basic]"
  - "-recurse compiler option [Visual Basic]"
  - "recurse compiler option [Visual Basic]"
ms.assetid: 84a0b670-33ae-44c4-a46a-b90388809317
---
# -recurse

Compiles source-code files in all child directories of either the specified directory or the project directory.  
  
## Syntax  
  
```console  
-recurse:[dir\]file  
```  
  
## Arguments  

 `dir`  
 Optional. The directory in which you want the search to begin. If not specified, the search begins in the project directory.  
  
 `file`  
 Required. The file(s) to search for. Wildcard characters are allowed.  
  
## Remarks  

 You can use wildcards in a file name to compile all matching files in the project directory without using `-recurse`. If no output file name is specified, the compiler bases the output file name on the first input file processed. This is generally the first file in the list of files compiled when viewed alphabetically. For this reason, it is best to specify an output file using the `-out` option.  
  
> [!NOTE]
> The `-recurse` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## Example  

 The following command compiles all Visual Basic files in the current directory.  
  
```console
vbc *.vb  
```  
  
 The following command compiles all Visual Basic files in the `Test\ABC` directory and any directories below it, and then generates `Test.ABC.dll`.  
  
```console
vbc -target:library -out:Test.ABC.dll -recurse:Test\ABC\*.vb  
```  
  
## See also

- [Visual Basic Command-Line Compiler](index.md)
- [-out (Visual Basic)](out.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
