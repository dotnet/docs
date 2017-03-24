---
title: "C# Compiler Options Listed Alphabetically | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
  - "CSharp"
helpviewer_keywords: 
  - "compiler options [C#], listed alpabetically"
  - "C# language, compiler options listed alphabitically"
  - "Visual C# compiler, options listed alphabetically"
  - "Visual C#, compiler options listed alphabetically"
ms.assetid: 43535ea0-ca47-4a15-b528-615087a86092
caps.latest.revision: 25
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# C# Compiler Options Listed Alphabetically
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The following compiler options are sorted alphabetically. For a categorical list, see [C# Compiler Options Listed by Category](../../../csharp/language-reference/compiler-options/listed-by-category.md).  
  
|Option|Purpose|  
|------------|-------------|  
|[@](../../../csharp/language-reference/compiler-options/response-file-compiler-option.md)|Reads a response file for more options.|  
|[/?](../../../csharp/language-reference/compiler-options/help-csharp-compiler-options.md)|Displays a usage message to stdout.|  
|`/additionalfile`|Names additional files that don't directly affect code generation but may be used by analyzers for producing errors or warnings.|  
|[/addmodule](../../../csharp/language-reference/compiler-options/addmodule-csharp-compiler-options.md)|Links the specified modules into this assembly|  
|`/analyzer`|Run the analyzers from this assembly (Short form: /a)|  
|[/appconfig](../../../csharp/language-reference/compiler-options/appconfig-csharp-compiler-options.md)|Specifies the location of app.config at assembly binding time.|  
|[/baseaddress](../../../csharp/language-reference/compiler-options/baseaddress-csharp-compiler-options.md)|Specifies the base address for the library to be built.|  
|[/bugreport](../../../csharp/language-reference/compiler-options/bugreport-csharp-compiler-options.md)|Creates a 'Bug Report' file. This file will be sent together with any crash information if it is used with **/errorreport:prompt** or **/errorreport:send**.|  
|[/checked](../../../csharp/language-reference/compiler-options/checked-csharp-compiler-options.md)|Causes the compiler to generate overflow checks.|  
|`/checksumalgorithm:<alg>`|Specify the algorithm for calculating the source file checksum stored in PDB.  Supported values are: SHA1 (default) or SHA256.|  
|[/codepage](../../../csharp/language-reference/compiler-options/codepage-csharp-compiler-options.md)|Specifies the codepage to use when opening source files.|  
|[/debug](../../../csharp/language-reference/compiler-options/debug-csharp-compiler-options.md)|Emits debugging information.|  
|[/define](../../../csharp/language-reference/compiler-options/define-csharp-compiler-options.md)|Defines conditional compilation symbols.|  
|[/delaysign](../../../csharp/language-reference/compiler-options/delaysign-csharp-compiler-options.md)|Delay-signs the assembly by using only the public part of the strong name key.|  
|[/doc](../../../csharp/language-reference/compiler-options/doc-csharp-compiler-options.md)|Specifies an XML Documentation file to generate.|  
|[/errorreport](../../../csharp/language-reference/compiler-options/errorreport-csharp-compiler-options.md)|Specifies how to handle internal compiler errors: prompt, send, or none. The default is none.|  
|[/filealign](../../../csharp/language-reference/compiler-options/filealign-csharp-compiler-options.md)|Specifies the alignment used for output file sections.|  
|[/fullpaths](../../../csharp/language-reference/compiler-options/fullpaths-csharp-compiler-options.md)|Causes the compiler to generate fully qualified paths.|  
|[/help](../../../csharp/language-reference/compiler-options/help-csharp-compiler-options.md)|Displays a usage message to stdout.|  
|[/highentropyva](../../../csharp/language-reference/compiler-options/highentropyva-csharp-compiler-options.md)|Specifies that high entropy ASLR is supported.|  
|**/incremental**|Enables incremental compilation [obsolete].|  
|[/keycontainer](../../../csharp/language-reference/compiler-options/keycontainer-csharp-compiler-options.md)|Specifies a strong name key container.|  
|[/keyfile](../../../csharp/language-reference/compiler-options/keyfile-csharp-compiler-options.md)|Specifies a strong name key file.|  
|[/langversion:\<string>](../../../csharp/language-reference/compiler-options/langversion-csharp-compiler-options.md)|Specify language version mode: ISO-1, ISO-2, 3, 4, 5, 6, or Default|  
|[/lib](../../../csharp/language-reference/compiler-options/lib-csharp-compiler-options.md)|Specifies additional directories in which to search for references.|  
|[/link](../../../csharp/language-reference/compiler-options/link-csharp-compiler-options.md)|Makes COM type information in specified assemblies available to the project.|  
|[/linkresource](../../../csharp/language-reference/compiler-options/linkresource-csharp-compiler-options.md)|Links the specified resource to this assembly.|  
|[/main](../../../csharp/language-reference/compiler-options/main-csharp-compiler-options.md)|Specifies the type that contains the entry point (ignore all other possible entry points).|  
|[/moduleassemblyname](../../../csharp/language-reference/compiler-options/moduleassemblyname-csharp-compiler-option.md)|Specifies an assembly whose non-public types a .netmodule can access.|  
|`/modulename:<string>`|Specify the name of the source module|  
|[/noconfig](../../../csharp/language-reference/compiler-options/noconfig-csharp-compiler-options.md)|Instructs the compiler not to auto include CSC.RSP file.|  
|[/nologo](../../../csharp/language-reference/compiler-options/nologo-csharp-compiler-options.md)|Suppresses compiler copyright message.|  
|[/nostdlib](../../../csharp/language-reference/compiler-options/nostdlib-csharp-compiler-options.md)|Instructs the compiler not to reference standard library (mscorlib.dll).|  
|[/nowarn](../../../csharp/language-reference/compiler-options/nowarn-csharp-compiler-options.md)|Disables specific warning messages|  
|[/nowin32manifest](../../../csharp/language-reference/compiler-options/nowin32manifest-csharp-compiler-options.md)|Instructs the compiler not to embed an application manifest in the executable file.|  
|[/optimize](../../../csharp/language-reference/compiler-options/optimize-csharp-compiler-options.md)|Enables/disables optimizations.|  
|[/out](../../../csharp/language-reference/compiler-options/out-csharp-compiler-options.md)|Specifies the output file name (default: base name of file with main class or first file).|  
|`/parallel[+&#124;-]`|Specifies whether to use concurrent build (+).|  
|[/pdb](../../../csharp/language-reference/compiler-options/pdb-csharp-compiler-options.md)|Specifies the file name and location of the .pdb file.|  
|[/platform](../../../csharp/language-reference/compiler-options/platform-csharp-compiler-options.md)|Limits which platforms this code can run on: x86, Itanium, x64, anycpu, or anycpu32bitpreferred. The default is anycpu.|  
|[/preferreduilang](../../../csharp/language-reference/compiler-options/preferreduilang-csharp-compiler-options.md)|Specifies the language to be used for compiler output.|  
|[/recurse](../../../csharp/language-reference/compiler-options/recurse-csharp-compiler-options.md)|Includes all files in the current directory and subdirectories according to the wildcard specifications.|  
|[/reference](../../../csharp/language-reference/compiler-options/reference-csharp-compiler-options.md)|References metadata from the specified assembly files.|  
|[/resource](../../../csharp/language-reference/compiler-options/resource-csharp-compiler-options.md)|Embeds the specified resource.|  
|`/ruleset:<file>`|Specify a ruleset file that disables specific diagnostics.|  
|[/subsystemversion](../../../csharp/language-reference/compiler-options/subsystemversion-csharp-compiler-options.md)|Specifies the minimum version of the subsystem that the executable file can use.|  
|[/target](../../../csharp/language-reference/compiler-options/target-csharp-compiler-options.md)|Specifies the format of the output file by using one of four options:[/target:appcontainerexe](../../../csharp/language-reference/compiler-options/target-appcontainerexe-csharp-compiler-options.md), [/target:exe](../../../csharp/language-reference/compiler-options/target-exe-csharp-compiler-options.md), [/target:library](../../../csharp/language-reference/compiler-options/target-library-csharp-compiler-options.md), [/target:module](../../../csharp/language-reference/compiler-options/target-module-csharp-compiler-options.md), [/target:winexe](../../../csharp/language-reference/compiler-options/target-winexe-csharp-compiler-options.md),  [/target:winmdobj](../../../csharp/language-reference/compiler-options/target-winmdobj-csharp-compiler-options.md).|  
|[/unsafe](../../../csharp/language-reference/compiler-options/unsafe-csharp-compiler-options.md)|Allows [unsafe](../../../csharp/language-reference/keywords/unsafe.md) code.|  
|[/utf8output](../../../csharp/language-reference/compiler-options/utf8output-csharp-compiler-options.md)|Outputs compiler messages in UTF-8 encoding.|  
|[/warn](../../../csharp/language-reference/compiler-options/warn-csharp-compiler-options.md)|Sets the warning level (0-4).|  
|[/warnaserror](../../../csharp/language-reference/compiler-options/warnaserror-csharp-compiler-options.md)|Reports specific warnings as errors.|  
|[/win32icon](../../../csharp/language-reference/compiler-options/win32icon-csharp-compiler-options.md)|Uses this icon for the output.|  
|[/win32manifest](../../../csharp/language-reference/compiler-options/win32manifest-csharp-compiler-options.md)|Specifies a custom win32 manifest file.|  
|[/win32res](../../../csharp/language-reference/compiler-options/win32res-csharp-compiler-options.md)|Specifies the win32 resource file (.res).|  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [C# Compiler Options Listed by Category](../../../csharp/language-reference/compiler-options/listed-by-category.md)   
 [How to: Set Environment Variables for the Visual Studio Command Line](../../../csharp/language-reference/compiler-options/how-to-set-environment-variables-for-the-visual-studio-command-line.md)   
 [\<compiler> Element](../Topic/%3Ccompiler%3E%20Element.md)