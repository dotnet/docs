---
title: "-pathmap (C# Compiler Options)"
ms.date: 05/16/2018
f1_keywords: 
  - "/pathmap"
helpviewer_keywords: 
  - "-pathmap compiler option [C#]"
  - "pathmap compiler option [C#]"
  - "/pathmap compiler option [C#]"
---
# -pathmap (C# Compiler Options)

The **-pathmap** compiler option specifies how to map physical paths to source path names output by the compiler.

## Syntax

```console
-pathmap:path1=sourcePath1,path2=sourcePath2
```

## Arguments

 `path1`
 The full path to the source files in the current environment

 `sourcePath1`
 The source path substituted for `path1` in any output files.

To specify multiple mapped source paths, separate each with a comma.

## Remarks

The compiler writes the source path into its output for the following reasons:

1. The source path is substituted for an argument when the <xref:System.Runtime.CompilerServices.CallerFilePathAttribute> is applied to an optional parameter.
1. The source path is embedded in a PDB file.
1. The path of the PDB file is embedded into a PE (portable executable) file.

This option maps each physical path on the machine where the compiler runs to a corresponding path that should be written in the output files.

## Example

Compile `t.cs` in the directory **C:\\work\\tests** and map that directory to **\publish** in the output:

```console
csc -pathmap:C:\work\tests=\publish t.cs
```

## See also

- [C# Compiler Options](./index.md)
- [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
