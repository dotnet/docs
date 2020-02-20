---
title: "-refonly (C# Compiler Options)"
ms.date: 07/08/2017
f1_keywords: 
  - "/refonly"
helpviewer_keywords: 
  - "/refonly compiler option [C#]"
  - "-refonly compiler option [C#]"
  - "refonly compiler option [C#]"
---

# -refonly (C# Compiler Options)

The **-refonly** option indicates that a reference assembly should be output instead of an implementation assembly, as the primary output. The `-refonly` parameter silently disables outputting PDBs, as reference assemblies cannot be executed. This option corresponds to the [ProduceOnlyReferenceAssembly](/visualstudio/msbuild/common-msbuild-project-properties) project property of MSBuild.

## Syntax

```console
-refonly
```

## Remarks

Reference assemblies are a special type of assembly that contain only the minimum amount of metadata required to represent the library's public API surface. They include declarations for all members that are significant when referencing an assembly in build tools, but exclude all member implementations and declarations of private members that have no observable impact on their API contract. For more information, see [Reference assemblies](../../../standard/assembly/reference-assemblies.md) in .NET Guide.

The `-refonly` and [`-refout`](refout-compiler-option.md) options are mutually exclusive.

## See also

- [C# Compiler Options](./index.md)
- [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
