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
|[-lib](lib-compiler-option.md)|Specifies the location of assemblies referenced by means of [-reference](reference-compiler-option.md).|
|[-nostdlib](nostdlib-compiler-option.md)|Instructs the compiler not to import the standard library (mscorlib.dll).|
|-embed|Embed all source files in the PDB.|
|-embed:\<file list>|Embed specific files in the PDB.|

## Debugging/Error Checking

|Option|Purpose|
|------------|-------------|
|[-bugreport](bugreport-compiler-option.md)|Creates a file that contains information that makes it easy to report a bug.|
|[-errorreport](errorreport-compiler-option.md)|Sets error reporting behavior.|
|[-fullpaths](fullpaths-compiler-option.md)|Specifies the absolute path to the file in compiler output.|
|[-nullable](nullable-compiler-option.md)|Specifies nullable context option.|

## Miscellaneous

|Option|Purpose|
|------------|-------------|
|[-baseaddress](baseaddress-compiler-option.md)|Specifies the preferred base address at which to load a DLL.|
|[-codepage](codepage-compiler-option.md)|Specifies the code page to use for all source code files in the compilation.|
|[-help](help-compiler-option.md)|Lists compiler options to stdout.|
|[-main](main-compiler-option.md)|Specifies the location of the **Main** method.|
|[-subsystemversion](subsystemversion-compiler-option.md)|Specifies the minimum version of the subsystem that the executable file can use.|
|[-unsafe](unsafe-compiler-option.md)|Enables compilation of code that uses the [unsafe](../keywords/unsafe.md) keyword.|
f|[-utf8output](utf8output-compiler-option.md)|Displays compiler output using UTF-8 encoding.|
|-checksumalgorithm:\<alg>|Specify the algorithm for calculating the source file checksum stored in PDB.  Supported values are: SHA256 (default) or SHA1.<br>Due to collision problems with SHA1, Microsoft recommends SHA256.|

## Obsolete Options

|Option|Purpose|
|---|---|
|-incremental|Enables incremental compilation.|
|[-preferreduilang](preferreduilang-compiler-option.md)|OBSOLETE Specify a language for compiler output.|
|[-publicsign](publicsign-compiler-option.md)|Apply a public key without signing the assembly, but set the bit in the assembly indicating the assembly is signed.|
|[-recurse](recurse-compiler-option.md)|Searches subdirectories for source files to compile. (Listed in input section in Roslyn repo)|
|[-link](link-compiler-option.md)|Makes COM type information in specified assemblies available to the project. (Listed in the input section of the roslyn repo)|
|-analyzer|Run the analyzers from this assembly (Short form: /a)  |
|-additionalfile|Names additional files that don't directly affect code generation but may be used by analyzers for producing errors or warnings. (Listed in the input section on the roslyn repo)|
|-sourcelink|Source link info to embed into PDB. (Listed in the code generation section on roslyn repo)  |
|-ruleset:\<file>|Specify a ruleset file that disables specific diagnostics. (In the errors and warnings section) |
|-reportanalyzer|Report additional analyzer information, such as execution time. (In the errors and warnings section) |
|[-highentropyva](highentropyva-compiler-option.md)|Specifies that the executable file supports address space layout randomization (ASLR). (Listed in security)|
|[-?](help-compiler-option.md)|Lists compiler options to stdout. (Listed in Misc)|
|-parallel[+&#124;-]|Specifies whether to use concurrent build (+). (Listed in Misc)|

## See also

- [C# Compiler Options](index.md)
- [C# Compiler Options Listed Alphabetically](listed-alphabetically.md)
- [How to set environment variables for the Visual Studio Command Line](how-to-set-environment-variables-for-the-visual-studio-command-line.md)
