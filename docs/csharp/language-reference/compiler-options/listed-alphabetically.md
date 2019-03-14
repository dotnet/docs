---
title: "C# Compiler Options Listed Alphabetically"
ms.date: 05/15/2018
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
|[@](response-file-compiler-option.md)|Reads a response file for more options.|
|[-?](help-compiler-option.md)|Displays a usage message to stdout.|
|-additionalfile|Names additional files that don't directly affect code generation but may be used by analyzers for producing errors or warnings.|
|[-addmodule](addmodule-compiler-option.md)|Links the specified modules into this assembly|
|-analyzer|Run the analyzers from this assembly (Short form: -a)|
|[-appconfig](appconfig-compiler-option.md)|Specifies the location of app.config at assembly binding time.|
|[-baseaddress](baseaddress-compiler-option.md)|Specifies the base address for the library to be built.|
|[-bugreport](bugreport-compiler-option.md)|Creates a 'Bug Report' file. This file will be sent together with any crash information if it is used with -errorreport:prompt or -errorreport:send.|
|[-checked](checked-compiler-option.md)|Causes the compiler to generate overflow checks.|
|-checksumalgorithm:\<alg>|Specifies the algorithm for calculating the source file checksum stored in PDB.  Supported values are: SHA1 (default) or SHA256.<br>Due to collision problems with SHA1, Microsoft recommends SHA256. |
|[-codepage](codepage-compiler-option.md)|Specifies the codepage to use when opening source files.|
|[-debug](debug-compiler-option.md)|Emits debugging information.|
|[-define](define-compiler-option.md)|Defines conditional compilation symbols.|
|[-delaysign](delaysign-compiler-option.md)|Delay-signs the assembly by using only the public part of the strong name key.|
|[-deterministic](deterministic-compiler-option.md)|Causes the compiler to output an assembly whose binary content is identical across compilations if inputs are identical.|
|[-doc](doc-compiler-option.md)|Specifies an XML Documentation file to generate.|
|-embed|Embed all source files in the PDB.|
|-embed:\<file list>|Embed specific files in the PDB.|
|-errorendlocation|Output line and column of the end location of each error.|
|-errorlog:\<file>|Specify a file to log all compiler and analyzer diagnostics.|
|[-errorreport](errorreport-compiler-option.md)|Specifies how to handle internal compiler errors: prompt, send, or none. The default is none.|
|[-filealign](filealign-compiler-option.md)|Specifies the alignment used for output file sections.|
|[-fullpaths](fullpaths-compiler-option.md)|Causes the compiler to generate fully qualified paths.|
|[-help](help-compiler-option.md)|Displays a usage message to stdout.|
|[-highentropyva](highentropyva-compiler-option.md)|Specifies that high entropy ASLR is supported.|
|-incremental|Enables incremental compilation [obsolete].|
|[-keycontainer](keycontainer-compiler-option.md)|Specifies a strong name key container.|
|[-keyfile](keyfile-compiler-option.md)|Specifies a strong name key file.|
|[-langversion:\<string>](langversion-compiler-option.md)|Specify language version: Default, ISO-1, ISO-2, 3, 4, 5, 6, 7, 7.1, 7.2, 7.3, or Latest |
|[-lib](lib-compiler-option.md)|Specifies additional directories in which to search for references.|
|[-link](link-compiler-option.md)|Makes COM type information in specified assemblies available to the project.|
|[-linkresource](linkresource-compiler-option.md)|Links the specified resource to this assembly.|
|[-main](main-compiler-option.md)|Specifies the type that contains the entry point (ignore all other possible entry points).|
|[-moduleassemblyname](moduleassemblyname-compiler-option.md)|Specifies an assembly whose non-public types a .netmodule can access.|
|-modulename:\<string>|Specify the name of the source module|
|[-noconfig](noconfig-compiler-option.md)|Instructs the compiler not to auto include CSC.RSP file.|
|[-nologo](nologo-compiler-option.md)|Suppresses compiler copyright message.|
|[-nostdlib](nostdlib-compiler-option.md)|Instructs the compiler not to reference standard library (mscorlib.dll).|
|[-nowarn](nowarn-compiler-option.md)|Disables specific warning messages|
|[-nowin32manifest](nowin32manifest-compiler-option.md)|Instructs the compiler not to embed an application manifest in the executable file.|
|[-optimize](optimize-compiler-option.md)|Enables/disables optimizations.|
|[-out](out-compiler-option.md)|Specifies the output file name (default: base name of file with main class or first file).|
|-parallel[+&#124;-]|Specifies whether to use concurrent build (+).|
|[-pathmap](pathmap-compiler-option.md)|Specifies a mapping for source path names output by the compiler.|
|[-pdb](pdb-compiler-option.md)|Specifies the file name and location of the .pdb file.|
|[-platform](platform-compiler-option.md)|Limits which platforms this code can run on: x86, Itanium, x64, anycpu, or anycpu32bitpreferred. The default is anycpu.|
|[-preferreduilang](preferreduilang-compiler-option.md)|Specifies the language to be used for compiler output.|
|[-publicsign](publicsign-compiler-option.md)|Apply a public key without signing the assembly, but set the bit in the assembly indicating the assembly is signed.|
|[-recurse](recurse-compiler-option.md)|Includes all files in the current directory and subdirectories according to the wildcard specifications.|
|[-reference](reference-compiler-option.md)|References metadata from the specified assembly files.|
|[-refout](refout-compiler-option.md)|Generate a reference assembly in addition to the primary assembly.|
|[-refonly](refonly-compiler-option.md)|Generate a reference assembly instead of a primary assembly.|
|-reportanalyzer|Report additional analyzer information, such as execution time.|
|[-resource](resource-compiler-option.md)|Embeds the specified resource.|
|-ruleset:\<file>|Specify a ruleset file that disables specific diagnostics.|
|[-subsystemversion](subsystemversion-compiler-option.md)|Specifies the minimum version of the subsystem that the executable file can use.|
|[-target](target-compiler-option.md)|Specifies the format of the output file by using one of four options: [-target:appcontainerexe](target-appcontainerexe-compiler-option.md), [-target:exe](target-exe-compiler-option.md), [-target:library](target-library-compiler-option.md), [-target:module](target-module-compiler-option.md), [-target:winexe](target-winexe-compiler-option.md),  [-target:winmdobj](target-winmdobj-compiler-option.md).|
|[-unsafe](unsafe-compiler-option.md)|Allows [unsafe](../../../csharp/language-reference/keywords/unsafe.md) code.|
|[-utf8output](utf8output-compiler-option.md)|Outputs compiler messages in UTF-8 encoding.|
|-version|Display the compiler version number and exit.|
|[-warn](warn-compiler-option.md)|Sets the warning level (0-4).|
|[-warnaserror](warnaserror-compiler-option.md)|Reports specific warnings as errors.|
|[-win32icon](win32icon-compiler-option.md)|Uses this icon for the output.|
|[-win32manifest](win32manifest-compiler-option.md)|Specifies a custom win32 manifest file.|
|[-win32res](win32res-compiler-option.md)|Specifies the win32 resource file (.res).|

## See also

- [C# Compiler Options](index.md)
- [C# Compiler Options Listed by Category](listed-by-category.md)
- [How to: Set Environment Variables for the Visual Studio Command Line](how-to-set-environment-variables-for-the-visual-studio-command-line.md)
- [\<compiler> Element](../../../framework/configure-apps/file-schema/compiler/compiler-element.md)
