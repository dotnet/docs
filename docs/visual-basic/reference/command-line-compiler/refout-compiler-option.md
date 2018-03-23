---
title: "-refout (Visual Basic)"
ms.date: 03/16/2018
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "/refout"
helpviewer_keywords: 
  - "refout compiler option [Visual Basic]"
  - "/refout compiler option [Visual Basic]"
  - "-refout compiler option [Visual Basic]"
author: "rpetrusha"
ms.author: "ronpet"
---

# -refout (Visual Basic)

The **-refout** option specifies a file path where the reference assembly should be output.

[!INCLUDE[compiler-options](~/includes/compiler-options.md)]

## Syntax

```console
-refout:filepath
```

## Arguments

 `filepath`
The path and filename of the reference assembly. It should generally be in a sub-folder of the primary assembly. The recommended convention (used by MSBuild) is to place the reference assembly in a "ref/" sub-folder relative to the primary assembly. All folders in `filepath` must exist; the compiler does not create them. 

## Remarks

Visual Basic supports the `-refout` switch starting with version 15.3.

Reference assemblies are metadata-only assemblies that contain metadata but no implementation code. They include type and member information for everything except anonymous types. Their method bodies are replaced with a single `throw null` statement. The reason for using `throw null` method bodies (as opposed to no bodies) is so that PEVerify can run and pass (thus validating the completeness of the metadata).

Reference assemblies include an assembly-level [ReferenceAssembly](xref:System.Runtime.CompilerServices.ReferenceAssemblyAttribute) attribute. This attribute may be specified in source (then the compiler won't need to synthesize it). Because of this attribute, runtimes refuse to load reference assemblies for execution (but they can still be loaded in a reflection-only context). Tools that reflect on assemblies need to ensure they load reference assemblies as reflection-only; otherwise, the runtime throws a <xref:System.BadImageFormatException>.

The `-refout` and [`-refonly`](refonly-compiler-option.md) options are mutually exclusive.

## See Also
[-refonly](refonly-compiler-option.md)   
[Visual Basic Command-Line Compiler](index.md)  
[Sample Compilation Command Lines](sample-compilation-command-lines.md)  

