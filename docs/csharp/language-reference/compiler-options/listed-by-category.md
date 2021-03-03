---
description: "C# Compiler Options Listed by Category"
title: "C# Compiler Options Listed by Category"
ms.date: 06/04/2020
helpviewer_keywords: 
  - "Visual C# compiler, options listed by category"
  - "compiler options [C#], listed by category"
  - "Visual C#, compiler options listed by category"
ms.assetid: 96437ecc-6502-4cd3-b070-e9386a298e83
---

# C# Compiler Options Listed by Category

The following compiler options are sorted by category. For an alphabetical list, see [C# Compiler Options Listed Alphabetically](listed-alphabetically.md).

## .NET Assemblies

|Option|Purpose|
|------------|-------------|
|-embed|Embed all source files in the PDB.|
|-embed:\<file list>|Embed specific files in the PDB.|

## Obsolete Options

|Option|Purpose|
|---|---|
|-incremental|Enables incremental compilation.|
|[-preferreduilang](preferreduilang-compiler-option.md)|OBSOLETE Specify a language for compiler output. (listed in advanced)|
|[-publicsign](publicsign-compiler-option.md)|Apply a public key without signing the assembly, but set the bit in the assembly indicating the assembly is signed.|
|[-bugreport](bugreport-compiler-option.md)|Creates a file that contains information that makes it easy to report a bug. (Listed in Advanced)|
|-checksumalgorithm:\<alg>|Specify the algorithm for calculating the source file checksum stored in PDB.  Supported values are: SHA256 (default) or SHA1.<br>Due to collision problems with SHA1, Microsoft recommends SHA256. (listed in Advanced)|
|-errorendlocation|Output line and column of the end location of each error. (Listed in Advanced)|
|-modulename|Specify the name of the source module. (Listed in Advanced)|

## See also

- [C# Compiler Options](index.md)
- [C# Compiler Options Listed Alphabetically](listed-alphabetically.md)
- [How to set environment variables for the Visual Studio Command Line](how-to-set-environment-variables-for-the-visual-studio-command-line.md)
