---
title: "-refout (Visual Basic)"
ms.date: 03/16/2018
f1_keywords:
  - "/refout"
helpviewer_keywords:
  - "refout compiler option [Visual Basic]"
  - "/refout compiler option [Visual Basic]"
  - "-refout compiler option [Visual Basic]"
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

Reference assemblies are a special type of assembly that contain only the minimum amount of metadata required to represent the library's public API surface. They include declarations for all members that are significant when referencing an assembly in build tools, but exclude all member implementations and declarations of private members that have no observable impact on their API contract. For more information, see [Reference assemblies](../../../standard/assembly/reference-assemblies.md) in .NET Guide.

The `-refout` and [`-refonly`](refonly-compiler-option.md) options are mutually exclusive.

## See also

- [-refonly](refonly-compiler-option.md)
- [Visual Basic Command-Line Compiler](index.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
