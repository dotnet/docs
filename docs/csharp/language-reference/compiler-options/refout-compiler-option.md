---
title: "-refout (C# Compiler Options)"
ms.date: 08/08/2017
f1_keywords: 
  - "/refout"
helpviewer_keywords: 
  - "refout compiler option [C#]"
  - "/refout compiler option [C#]"
  - "-refout compiler option [C#]"
---

# -refout (C# Compiler Options)

The **-refout** option specifies a file path where the reference assembly should be output. This translates to `metadataPeStream` in the Emit API. This option corresponds to the [ProduceReferenceAssembly](/visualstudio/msbuild/common-msbuild-project-properties) project property of MSBuild.

## Syntax

```console
-refout:filepath
```

## Arguments

 `filepath`
The filepath for the reference assembly. It should generally match that of the primary assembly. The recommended convention (used by MSBuild) is to place the reference assembly in a "ref/" sub-folder relative to the primary assembly.

## Remarks

Reference assemblies are a special type of assembly that contain only the minimum amount of metadata required to represent the library's public API surface. They include declarations for all members that are significant when referencing an assembly in build tools, but exclude all member implementations and declarations of private members that have no observable impact on their API contract. For more information, see [Reference assemblies](../../../standard/assembly/reference-assemblies.md) in .NET Guide.

The `-refout` and [`-refonly`](refonly-compiler-option.md) options are mutually exclusive.

## See also

- [C# Compiler Options](./index.md)
- [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
