---
title: "C# Compiler Options Listed Alphabetically"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "compiler options [C#], listed alpabetically"
  - "C# language, compiler options listed alphabitically"
  - "Visual C# compiler, options listed alphabetically"
  - "Visual C#, compiler options listed alphabetically"
ms.assetid: 43535ea0-ca47-4a15-b528-615087a86092
caps.latest.revision: 25
author: "BillWagner"
ms.author: "wiwagn"
---
# C# Compiler Options Listed Alphabetically
The following compiler options are sorted alphabetically. For a categorical list, see [C# Compiler Options Listed by Category](../../../csharp/language-reference/compiler-options/listed-by-category.md).  
  
|Option|Purpose|  
|------------|-------------|  
|[@](../../../csharp/language-reference/compiler-options/response-file-compiler-option.md)|Reads a response file for more options.|  
|[-?](../../../csharp/language-reference/compiler-options/help-compiler-option.md)|Displays a usage message to stdout.|  
|-additionalfile|Names additional files that don't directly affect code generation but may be used by analyzers for producing errors or warnings.|  
|[-addmodule](../../../csharp/language-reference/compiler-options/addmodule-compiler-option.md)|Links the specified modules into this assembly|  
|-analyzer|Run the analyzers from this assembly (Short form: -a)|  
|[-appconfig](../../../csharp/language-reference/compiler-options/appconfig-compiler-option.md)|Specifies the location of app.config at assembly binding time.|  
|[-baseaddress](../../../csharp/language-reference/compiler-options/baseaddress-compiler-option.md)|Specifies the base address for the library to be built.|  
|[-bugreport](../../../csharp/language-reference/compiler-options/bugreport-compiler-option.md)|Creates a 'Bug Report' file. This file will be sent together with any crash information if it is used with -errorreport:prompt or -errorreport:send.|  
|[-checked](../../../csharp/language-reference/compiler-options/checked-compiler-option.md)|Causes the compiler to generate overflow checks.|  
|-checksumalgorithm:\<alg>|Specify the algorithm for calculating the source file checksum stored in PDB.  Supported values are: SHA1 (default) or SHA256.|  
|[-codepage](../../../csharp/language-reference/compiler-options/codepage-compiler-option.md)|Specifies the codepage to use when opening source files.|  
|[-debug](../../../csharp/language-reference/compiler-options/debug-compiler-option.md)|Emits debugging information.|  
|[-define](../../../csharp/language-reference/compiler-options/define-compiler-option.md)|Defines conditional compilation symbols.|  
|[-delaysign](../../../csharp/language-reference/compiler-options/delaysign-compiler-option.md)|Delay-signs the assembly by using only the public part of the strong name key.|  
|[-doc](../../../csharp/language-reference/compiler-options/doc-compiler-option.md)|Specifies an XML Documentation file to generate.|  
|[-errorreport](../../../csharp/language-reference/compiler-options/errorreport-compiler-option.md)|Specifies how to handle internal compiler errors: prompt, send, or none. The default is none.|  
|[-filealign](../../../csharp/language-reference/compiler-options/filealign-compiler-option.md)|Specifies the alignment used for output file sections.|  
|[-fullpaths](../../../csharp/language-reference/compiler-options/fullpaths-compiler-option.md)|Causes the compiler to generate fully qualified paths.|  
|[-help](../../../csharp/language-reference/compiler-options/help-compiler-option.md)|Displays a usage message to stdout.|  
|[-highentropyva](../../../csharp/language-reference/compiler-options/highentropyva-compiler-option.md)|Specifies that high entropy ASLR is supported.|  
|-incremental|Enables incremental compilation [obsolete].|  
|[-keycontainer](../../../csharp/language-reference/compiler-options/keycontainer-compiler-option.md)|Specifies a strong name key container.|  
|[-keyfile](../../../csharp/language-reference/compiler-options/keyfile-compiler-option.md)|Specifies a strong name key file.|  
|[-langversion:\<string>](../../../csharp/language-reference/compiler-options/langversion-compiler-option.md)|Specify language version mode: Default, ISO-1, ISO-2, 3, 4, 5, 6, 7, 7.1, or Latest |  
|[-lib](../../../csharp/language-reference/compiler-options/lib-compiler-option.md)|Specifies additional directories in which to search for references.|  
|[-link](../../../csharp/language-reference/compiler-options/link-compiler-option.md)|Makes COM type information in specified assemblies available to the project.|  
|[-linkresource](../../../csharp/language-reference/compiler-options/linkresource-compiler-option.md)|Links the specified resource to this assembly.|  
|[-main](../../../csharp/language-reference/compiler-options/main-compiler-option.md)|Specifies the type that contains the entry point (ignore all other possible entry points).|  
|[-moduleassemblyname](../../../csharp/language-reference/compiler-options/moduleassemblyname-compiler-option.md)|Specifies an assembly whose non-public types a .netmodule can access.|  
|-modulename:\<string>|Specify the name of the source module|  
|[-noconfig](../../../csharp/language-reference/compiler-options/noconfig-compiler-option.md)|Instructs the compiler not to auto include CSC.RSP file.|  
|[-nologo](../../../csharp/language-reference/compiler-options/nologo-compiler-option.md)|Suppresses compiler copyright message.|  
|[-nostdlib](../../../csharp/language-reference/compiler-options/nostdlib-compiler-option.md)|Instructs the compiler not to reference standard library (mscorlib.dll).|  
|[-nowarn](../../../csharp/language-reference/compiler-options/nowarn-compiler-option.md)|Disables specific warning messages|  
|[-nowin32manifest](../../../csharp/language-reference/compiler-options/nowin32manifest-compiler-option.md)|Instructs the compiler not to embed an application manifest in the executable file.|  
|[-optimize](../../../csharp/language-reference/compiler-options/optimize-compiler-option.md)|Enables/disables optimizations.|  
|[-out](../../../csharp/language-reference/compiler-options/out-compiler-option.md)|Specifies the output file name (default: base name of file with main class or first file).|  
|-parallel[+&#124;-]|Specifies whether to use concurrent build (+).|  
|[-pdb](../../../csharp/language-reference/compiler-options/pdb-compiler-option.md)|Specifies the file name and location of the .pdb file.|  
|[-platform](../../../csharp/language-reference/compiler-options/platform-compiler-option.md)|Limits which platforms this code can run on: x86, Itanium, x64, anycpu, or anycpu32bitpreferred. The default is anycpu.|  
|[-preferreduilang](../../../csharp/language-reference/compiler-options/preferreduilang-compiler-option.md)|Specifies the language to be used for compiler output.|  
|[-recurse](../../../csharp/language-reference/compiler-options/recurse-compiler-option.md)|Includes all files in the current directory and subdirectories according to the wildcard specifications.|  
|[-reference](../../../csharp/language-reference/compiler-options/reference-compiler-option.md)|References metadata from the specified assembly files.|  
|[-refout](refout-compiler-option.md)|Generate a reference assembly in addition to the primary assembly.|  
|[-refonly](refonly-compiler-option.md)|Generate a reference assembly instead of a primary assembly.|  
|[-resource](../../../csharp/language-reference/compiler-options/resource-compiler-option.md)|Embeds the specified resource.|  
|-ruleset:\<file>|Specify a ruleset file that disables specific diagnostics.|  
|[-subsystemversion](../../../csharp/language-reference/compiler-options/subsystemversion-compiler-option.md)|Specifies the minimum version of the subsystem that the executable file can use.|  
|[-target](../../../csharp/language-reference/compiler-options/target-compiler-option.md)|Specifies the format of the output file by using one of four options: [-target:appcontainerexe](../../../csharp/language-reference/compiler-options/target-appcontainerexe-compiler-option.md), [-target:exe](../../../csharp/language-reference/compiler-options/target-exe-compiler-option.md), [-target:library](../../../csharp/language-reference/compiler-options/target-library-compiler-option.md), [-target:module](../../../csharp/language-reference/compiler-options/target-module-compiler-option.md), [-target:winexe](../../../csharp/language-reference/compiler-options/target-winexe-compiler-option.md),  [-target:winmdobj](../../../csharp/language-reference/compiler-options/target-winmdobj-compiler-option.md).|  
|[-unsafe](../../../csharp/language-reference/compiler-options/unsafe-compiler-option.md)|Allows [unsafe](../../../csharp/language-reference/keywords/unsafe.md) code.|  
|[-utf8output](../../../csharp/language-reference/compiler-options/utf8output-compiler-option.md)|Outputs compiler messages in UTF-8 encoding.|  
|[-warn](../../../csharp/language-reference/compiler-options/warn-compiler-option.md)|Sets the warning level (0-4).|  
|[-warnaserror](../../../csharp/language-reference/compiler-options/warnaserror-compiler-option.md)|Reports specific warnings as errors.|  
|[-win32icon](../../../csharp/language-reference/compiler-options/win32icon-compiler-option.md)|Uses this icon for the output.|  
|[-win32manifest](../../../csharp/language-reference/compiler-options/win32manifest-compiler-option.md)|Specifies a custom win32 manifest file.|  
|[-win32res](../../../csharp/language-reference/compiler-options/win32res-compiler-option.md)|Specifies the win32 resource file (.res).|  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [C# Compiler Options Listed by Category](../../../csharp/language-reference/compiler-options/listed-by-category.md)  
 [How to: Set Environment Variables for the Visual Studio Command Line](../../../csharp/language-reference/compiler-options/how-to-set-environment-variables-for-the-visual-studio-command-line.md)  
 [\<compiler> Element](../../../framework/configure-apps/file-schema/compiler/compiler-element.md)
