---
title: "-reference (Visual Basic)"
ms.date: 03/13/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "/reference compiler option [Visual Basic]"
  - "r compiler option [Visual Basic]"
  - "-reference compiler option [Visual Basic]"
  - "/r compiler option [Visual Basic]"
  - "reference compiler option [Visual Basic]"
  - "-r compiler option [Visual Basic]"
ms.assetid: 66bdfced-bbf6-43d1-a554-bc0990315737
author: rpetrusha
ms.author: ronpet
---
# -reference (Visual Basic)
Causes the compiler to make type information in the specified assemblies available to the project you are currently compiling.  
  
## Syntax  
  
```  
-reference:fileList  
' -or-  
-r:fileList  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`fileList`|Required. Comma-delimited list of assembly file names. If the file name contains a space, enclose the name in quotation marks.|  
  
## Remarks  
 The file(s) you import must contain assembly metadata. Only public types are visible outside the assembly. The [/addmodule](../../../visual-basic/reference/command-line-compiler/addmodule.md) option imports metadata from a module.  
  
 If you reference an assembly (Assembly A) which itself references another assembly (Assembly B), you need to reference Assembly B if:  
  
-   A type from Assembly A inherits from a type or implements an interface from Assembly B.  
  
-   A field, property, event, or method that has a return type or parameter type from Assembly B is invoked.  
  
 Use [-libpath](../../../visual-basic/reference/command-line-compiler/libpath.md) to specify the directory in which one or more of your assembly references is located.  
  
 For the compiler to recognize a type in an assembly (not a module), it must be forced to resolve the type. One example of how you can do this is to define an instance of the type. Other ways are available to resolve type names in an assembly for the compiler. For example, if you inherit from a type in an assembly, the type name then becomes known to the compiler.  
  
 The Vbc.rsp response file, which references commonly used [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] assemblies, is used by default. Use `-noconfig` if you do not want the compiler to use Vbc.rsp.  
  
 The short form of `-reference` is `/r`.  
  
## Example  
 The following command compiles source file `Input.vb` and reference assemblies from `Metad1.dll` and `Metad2.dll` to produce `Out.exe`.  
  
```console
vbc -reference:metad1.dll,metad2.dll -out:out.exe input.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [-noconfig](../../../visual-basic/reference/command-line-compiler/noconfig.md)  
 [-target (Visual Basic)](../../../visual-basic/reference/command-line-compiler/target.md)  
 [Public](../../../visual-basic/language-reference/modifiers/public.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)
