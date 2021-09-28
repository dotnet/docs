---
description: "Learn more about: -addmodule"
title: "-addmodule"
ms.date: 03/09/2018
helpviewer_keywords: 
  - "/addmodule compiler option [Visual Basic]"
  - "addmodule compiler option [Visual Basic]"
  - "-addmodule compiler option [Visual Basic]"
ms.assetid: fb4b89d4-4926-4f20-868d-427fa28497b2
---
# -addmodule

Causes the compiler to make all type information from the specified file(s) available to the project you are currently compiling.  
  
## Syntax  
  
```console  
-addmodule:fileList  
```  
  
## Arguments  

 `fileList`  
 Required. Comma-delimited list of files that contain metadata but do not contain assembly manifests. File names containing spaces should be surrounded by quotation marks (" ").  
  
## Remarks  

 The files listed by the `fileList` parameter must be created with the `-target:module` option, or with another compiler's equivalent to `-target:module`.  
  
 All modules added with `-addmodule` must be in the same directory as the output file at run time. That is, you can specify a module in any directory at compile time, but the module must be in the application directory at run time. If it is not, you get a <xref:System.TypeLoadException> error.  
  
 If you specify (implicitly or explicitly) any[-target (Visual Basic)](target.md) option other than `-target:module` with `-addmodule`, the files you pass to `-addmodule` become part of the project's assembly. An assembly is required to run an output file that has one or more files added with `-addmodule`.  
  
 Use [-reference (Visual Basic)](reference.md) to import metadata from a file that contains an assembly.  
  
> [!NOTE]
> The `-addmodule` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## Example  

 The following code creates a module.  
  
 [!code-vb[VbVbalrCompiler#47](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrCompiler/VB/OptionStrictOff.vb#47)]  
  
 The following code imports the module's types.  
  
 [!code-vb[VbVbalrCompiler#48](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrCompiler/VB/OptionStrictOff.vb#48)]  
  
 When you run `t1`, it outputs `802`.  
  
## See also

- [Visual Basic Command-Line Compiler](index.md)
- [-target (Visual Basic)](target.md)
- [-reference (Visual Basic)](reference.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
