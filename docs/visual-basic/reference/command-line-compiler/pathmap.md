---
description: "Learn more about: -pathmap"
title: "-pathmap"
ms.date: 08/29/2025
f1_keywords: 
  - "pathmap"
  - "-pathmap"
helpviewer_keywords: 
  - "-pathmap compiler option [Visual Basic]"
  - "/pathmap compiler option [Visual Basic]"
  - "pathmap compiler option [Visual Basic]"
ai-usage: ai-generated
---
# -pathmap

Specifies how to map physical paths to source path names output by the compiler.

## Syntax

```console
-pathmap:path1=sourcePath1,path2=sourcePath2
```

## Arguments

| Term              | Definition                                                           |
|----------------|-----------------------------------------------------------------------------|
| `path1`           | Required. The full path to the source files in the current environment. |
| `sourcePath1` | Required. The source path substituted for `path1` in any output files.  |

## Remarks

> [!NOTE]
> Specifying `-pathmap` prevents breakpoints from working in local debug builds. Only set `-pathmap` for production or continuous integration builds.

The `-pathmap` compiler option specifies how to map physical paths to source path names output by the compiler. This option maps each physical path on the machine where the compiler runs to a corresponding path that should be written in the output files.

To specify multiple mapped source paths, separate each with a comma.

The compiler writes the source path into its output for the following reasons:

- The source path is substituted for an argument when the <xref:System.Runtime.CompilerServices.CallerFilePathAttribute> is applied to an optional parameter.
- The source path is embedded in a PDB file.
- The path of the PDB file is embedded into a PE (portable executable) file.

The `-pathmap` option is not available from within the Visual Studio development environment; it's available only when compiling from the command line.

## Example

The following example compiles `Test.vb` and maps the source paths:

```console
vbc -pathmap:C:\MyProject\=\BuildServer\,C:\Temp\=\BuildTemp\ Test.vb
```

In this example, if a source file is located at `C:\MyProject\Program.vb`, it will appear in the output as `\BuildServer\Program.vb`.

## See also

- [Visual Basic Command-Line Compiler](index.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
- <xref:System.Runtime.CompilerServices.CallerFilePathAttribute>
