---
title: "-refonly (Visual Basic)"
ms.date: 03/16/2018
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "-refonly"
helpviewer_keywords: 
  - "/refonly compiler option [Visual Basic]"
  - "-refonly compiler option [Visual Basic]"
  - "refonly compiler option [Visual Basic]"
author: "rpetrusha"
ms.author: "ronpet"
---

# -refonly (Visual Basic)

The **-refonly** option indicates that the primary output of the compilation should be a reference assembly instead of an implementation assembly. The `-refonly` parameter silently disables outputting PDBs, as reference assemblies cannot be executed.

[!INCLUDE[compiler-options](~/includes/compiler-options.md)]

## Syntax

```console
-refonly
```

## Remarks

Visual Basic supports the `-refout` switch starting with version 15.3.

Reference assemblies are metadata-only assemblies that contain metadata but no implementation code. They include type and member information for everything except anonymous types. The reason for using `throw null` bodies (as opposed to no bodies) is so that PEVerify could run and pass (thus validating the completeness of the metadata).

Reference assemblies include an assembly-level [ReferenceAssembly](xref:System.Runtime.CompilerServices.ReferenceAssemblyAttribute) attribute. This attribute may be specified in source (then the compiler won't need to synthesize it). Because of this attribute, runtimes will refuse to load reference assemblies for execution (but they can still be loaded in a reflection-only context). Tools that reflect on assemblies need to ensure they load reference assemblies as reflection-only; otherwise, the runtime throws a <xref:System.BadImageFormatException>.

The `-refonly` and [`-refout`](refout-compiler-option.md) options are mutually exclusive.

## See also
[-refout](refout-compiler-option.md)   
[Visual Basic Command-Line Compiler](index.md)  
[Sample Compilation Command Lines](sample-compilation-command-lines.md)   
