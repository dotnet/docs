---
description: "C# Compiler Options Listed Alphabetically"
title: "C# Compiler Options Listed Alphabetically"
ms.date: 06/04/2020
helpviewer_keywords:
  - "compiler options [C#], listed alphabetically"
  - "C# language, compiler options listed alphabetically"
  - "Visual C# compiler, options listed alphabetically"
  - "Visual C#, compiler options listed alphabetically"
ms.assetid: 43535ea0-ca47-4a15-b528-615087a86092
---

# C# Compiler Options Listed Alphabetically

The following compiler options are sorted alphabetically. For a categorical list, see [C# Compiler Options Listed by Category](listed-by-category.md).

|Option|Purpose|
|------------|-------------|
|[-?](help-compiler-option.md)|Displays a usage message to stdout.|
|[-bugreport](bugreport-compiler-option.md)|Creates a 'Bug Report' file. This file will be sent together with any crash information if it is used with -errorreport:prompt or -errorreport:send.|
|-checksumalgorithm:\<alg>|Specifies the algorithm for calculating the source file checksum stored in PDB.  Supported values are: SHA256 (default) or SHA1.<br>Due to collision problems with SHA1, Microsoft recommends SHA256. |
|-embed|Embed all source files in the PDB.|
|-embed:\<file list>|Embed specific files in the PDB.|
|-errorendlocation|Output line and column of the end location of each error.|
|-errorlog:\<file>|Specify a file to log all compiler and analyzer diagnostics.|
|[-help](help-compiler-option.md)|Displays a usage message to stdout.|
|-incremental|Enables incremental compilation [obsolete].|
|-parallel[+&#124;-]|Specifies whether to use concurrent build (+).|
|[-preferreduilang](preferreduilang-compiler-option.md)|Specifies the language to be used for compiler output.|
|[-publicsign](publicsign-compiler-option.md)|Apply a public key without signing the assembly, but set the bit in the assembly indicating the assembly is signed.|
|-version|Display the compiler version number and exit.|

## See also

- [C# Compiler Options](index.md)
- [C# Compiler Options Listed by Category](listed-by-category.md)
- [How to set environment variables for the Visual Studio Command Line](how-to-set-environment-variables-for-the-visual-studio-command-line.md)
- [\<compiler> Element](../../../framework/configure-apps/file-schema/compiler/compiler-element.md)
