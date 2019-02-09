---
title: "C# Compiler Options Listed by Category"
ms.date: 05/15/2018
helpviewer_keywords: 
  - "Visual C# compiler, options listed by category"
  - "compiler options [C#], listed by category"
  - "Visual C#, compiler options listed by category"
ms.assetid: 96437ecc-6502-4cd3-b070-e9386a298e83
---
# C# Compiler Options Listed by Category

The following compiler options are sorted by category. For an alphabetical list, see [C# Compiler Options Listed Alphabetically](listed-alphabetically.md).

## Optimization

|Option|Purpose|
|------------|-------------|
|[-filealign](filealign-compiler-option.md)|Specifies the size of sections in the output file.|
|[-optimize](optimize-compiler-option.md)|Enables/disables optimizations.|

## Output Files

|Option|Purpose|
|------------|-------------|
|[-deterministic](deterministic-compiler-option.md)|Causes the compiler to output an assembly whose binary content is identical across compilations if inputs are identical.|
|[-doc](doc-compiler-option.md)|Specifies an XML file where processed documentation comments are to be written.|
|[-out](out-compiler-option.md)|Specifies the output file.|
|[-pathmap](pathmap-compiler-option.md)|Specify a mapping for source path names output by the compiler|
|[-pdb](pdb-compiler-option.md)|Specifies the file name and location of the .pdb file.|
|[-platform](platform-compiler-option.md)|Specify the output platform.|
|[-preferreduilang](preferreduilang-compiler-option.md)|Specify a language for compiler output.|
|[-refout](refout-compiler-option.md)|Generate a reference assembly in addition to the primary assembly.|
|[-refonly](refonly-compiler-option.md)|Generate a reference assembly instead of a primary assembly.|
|[-target](target-compiler-option.md)|Specifies the format of the output file using one of five options: [-target:appcontainerexe](target-appcontainerexe-compiler-option.md), [-target:exe](target-exe-compiler-option.md), [-target:library](target-library-compiler-option.md), [-target:module](target-module-compiler-option.md), [-target:winexe](target-winexe-compiler-option.md), or [-target:winmdobj](target-winmdobj-compiler-option.md).|
|-modulename:\<string>|Specify the name of the source module|

## .NET Framework Assemblies

|Option|Purpose|
|------------|-------------|
|[-addmodule](addmodule-compiler-option.md)|Specifies one or more modules to be part of this assembly.|
|[-delaysign](delaysign-compiler-option.md)|Instructs the compiler to add the public key but to leave the assembly unsigned.|
|[-keycontainer](keycontainer-compiler-option.md)|Specifies the name of the cryptographic key container.|
|[-keyfile](keyfile-compiler-option.md)|Specifies the filename containing the cryptographic key.|
|[-lib](lib-compiler-option.md)|Specifies the location of assemblies referenced by means of [-reference](reference-compiler-option.md).|
|[-nostdlib](nostdlib-compiler-option.md)|Instructs the compiler not to import the standard library (mscorlib.dll).|
|[-publicsign](publicsign-compiler-option.md)|Apply a public key without signing the assembly, but set the bit in the assembly indicating the assembly is signed.|
|[-reference](reference-compiler-option.md)|Imports metadata from a file that contains an assembly.|
|-analyzer|Run the analyzers from this assembly (Short form: /a)|
|-additionalfile|Names additional files that don't directly affect code generation but may be used by analyzers for producing errors or warnings.|

## Debugging/Error Checking

|Option|Purpose|
|------------|-------------|
|[-bugreport](bugreport-compiler-option.md)|Creates a file that contains information that makes it easy to report a bug.|
|[-checked](checked-compiler-option.md)|Specifies whether integer arithmetic that overflows the bounds of the data type will cause an exception at run time.|
|[-debug](debug-compiler-option.md)|Instruct the compiler to emit debugging information.|
|[-errorreport](errorreport-compiler-option.md)|Sets error reporting behavior.|
|[-fullpaths](fullpaths-compiler-option.md)|Specifies the absolute path to the file in compiler output.|
|[-nowarn](nowarn-compiler-option.md)|Suppresses the compiler's generation of specified warnings.|
|[-warn](warn-compiler-option.md)|Sets the warning level.|
|[-warnaserror](warnaserror-compiler-option.md)|Promotes warnings to errors.|
|-ruleset:\<file>|Specify a ruleset file that disables specific diagnostics.|

## Preprocessor

|Option|Purpose|
|------------|-------------|
|[-define](define-compiler-option.md)|Defines preprocessor symbols.|

## Resources

|Option|Purpose|
|------------|-------------|
|[-link](link-compiler-option.md)|Makes COM type information in specified assemblies available to the project.|
|[-linkresource](linkresource-compiler-option.md)|Creates a link to a managed resource.|
|[-resource](resource-compiler-option.md)|Embeds a .NET Framework resource into the output file.|
|[-win32icon](win32icon-compiler-option.md)|Specifies an .ico file to insert into the output file.|
|[-win32res](win32res-compiler-option.md)|Specifies a Win32 resource to insert into the output file.|

## Miscellaneous

|Option|Purpose|
|------------|-------------|
|[@](response-file-compiler-option.md)|Specifies a response file.|
|[-?](help-compiler-option.md)|Lists compiler options to stdout.|
|[-baseaddress](baseaddress-compiler-option.md)|Specifies the preferred base address at which to load a DLL.|
|[-codepage](codepage-compiler-option.md)|Specifies the code page to use for all source code files in the compilation.|
|[-help](help-compiler-option.md)|Lists compiler options to stdout.|
|[-highentropyva](highentropyva-compiler-option.md)|Specifies that the executable file supports address space layout randomization (ASLR).|
|[-langversion](langversion-compiler-option.md)|Specify language version: Default, ISO-1, ISO-2, 3, 4, 5, 6, 7, 7.1, 7.2, 7.3, or Latest |
|[-main](main-compiler-option.md)|Specifies the location of the **Main** method.|
|[-noconfig](noconfig-compiler-option.md)|Instructs the compiler not to compile with csc.rsp.|
|[-nologo](nologo-compiler-option.md)|Suppresses compiler banner information.|
|[-recurse](recurse-compiler-option.md)|Searches subdirectories for source files to compile.|
|[-subsystemversion](subsystemversion-compiler-option.md)|Specifies the minimum version of the subsystem that the executable file can use.|
|[-unsafe](unsafe-compiler-option.md)|Enables compilation of code that uses the [unsafe](../../../csharp/language-reference/keywords/unsafe.md) keyword.|
|[-utf8output](utf8output-compiler-option.md)|Displays compiler output using UTF-8 encoding.|
|-parallel[+&#124;-]|Specifies whether to use concurrent build (+).|
|-checksumalgorithm:\<alg>|Specify the algorithm for calculating the source file checksum stored in PDB.  Supported values are: SHA1 (default) or SHA256.|

## Obsolete Options

|Option|Purpose|
|---|---|
|-incremental|Enables incremental compilation.|

## See also

- [C# Compiler Options](index.md)
- [C# Compiler Options Listed Alphabetically](listed-alphabetically.md)
- [How to: Set Environment Variables for the Visual Studio Command Line](how-to-set-environment-variables-for-the-visual-studio-command-line.md)
