---
title: "-refonly (Visual Basic)"
ms.date: 03/16/2018
f1_keywords: 
  - "-refonly"
helpviewer_keywords: 
  - "/refonly compiler option [Visual Basic]"
  - "-refonly compiler option [Visual Basic]"
  - "refonly compiler option [Visual Basic]"
---

# -refonly (Visual Basic)

The **-refonly** option indicates that the primary output of the compilation should be a reference assembly instead of an implementation assembly. The `-refonly` parameter silently disables outputting PDBs, as reference assemblies cannot be executed.

[!INCLUDE[compiler-options](~/includes/compiler-options.md)]

## Syntax

```console
-refonly
```

## Remarks

Visual Basic supports the `-refonly` switch starting with version 15.3.

Reference assemblies are a special type of assembly that contain only the minimum amount of metadata required to represent the library's public API surface. They include declarations for all members that are significant when referencing an assembly in build tools, but exclude all member implementations and declarations of private members that have no observable impact on their API contract. For more information, see [Reference assemblies](../../../standard/assembly/reference-assemblies.md) in .NET Guide.

The `-refonly` and [`-refout`](refout-compiler-option.md) options are mutually exclusive.

## See also

- [-refout](refout-compiler-option.md)
- [Visual Basic Command-Line Compiler](index.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
