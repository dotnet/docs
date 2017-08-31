---
title: "C# Compiler Options Listed by Category | Microsoft Docs"
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
  - "Visual C# compiler, options listed by category"
  - "compiler options [C#], listed by category"
  - "Visual C#, compiler options listed by category"
ms.assetid: 96437ecc-6502-4cd3-b070-e9386a298e83
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# C# Compiler Options Listed by Category
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The following compiler options are sorted by category. For an alphabetical list, see [C# Compiler Options Listed Alphabetically](../../../csharp/language-reference/compiler-options/listed-alphabetically.md).  
  
### Optimization  
  
|Option|Purpose|  
|------------|-------------|  
|[/filealign](../../../csharp/language-reference/compiler-options/filealign-csharp-compiler-options.md)|Specifies the size of sections in the output file.|  
|[/optimize](../../../csharp/language-reference/compiler-options/optimize-csharp-compiler-options.md)|Enables/disables optimizations.|  
  
### Output Files  
  
|Option|Purpose|  
|------------|-------------|  
|[/doc](../../../csharp/language-reference/compiler-options/doc-csharp-compiler-options.md)|Specifies an XML file where processed documentation comments are to be written.|  
|[/out](../../../csharp/language-reference/compiler-options/out-csharp-compiler-options.md)|Specifies the output file.|  
|[/pdb](../../../csharp/language-reference/compiler-options/pdb-csharp-compiler-options.md)|Specifies the file name and location of the .pdb file.|  
|[/platform](../../../csharp/language-reference/compiler-options/platform-csharp-compiler-options.md)|Specify the output platform.|  
|[/preferreduilang](../../../csharp/language-reference/compiler-options/preferreduilang-csharp-compiler-options.md)|Specify a language for compiler output.|  
|[/target](../../../csharp/language-reference/compiler-options/target-csharp-compiler-options.md)|Specifies the format of the output file using one of five options: [/target:appcontainerexe](../../../csharp/language-reference/compiler-options/target-appcontainerexe-csharp-compiler-options.md), [/target:exe](../../../csharp/language-reference/compiler-options/target-exe-csharp-compiler-options.md), [/target:library](../../../csharp/language-reference/compiler-options/target-library-csharp-compiler-options.md), [/target:module](../../../csharp/language-reference/compiler-options/target-module-csharp-compiler-options.md), [/target:winexe](../../../csharp/language-reference/compiler-options/target-winexe-csharp-compiler-options.md), or [/target:winmdobj](../../../csharp/language-reference/compiler-options/target-winmdobj-csharp-compiler-options.md).|  
|`/modulename:<string>`|Specify the name of the source module|  
  
### .NET Framework Assemblies  
  
|Option|Purpose|  
|------------|-------------|  
|[/addmodule](../../../csharp/language-reference/compiler-options/addmodule-csharp-compiler-options.md)|Specifies one or more modules to be part of this assembly.|  
|[/delaysign](../../../csharp/language-reference/compiler-options/delaysign-csharp-compiler-options.md)|Instructs the compiler to add the public key but to leave the assembly unsigned.|  
|[/keycontainer](../../../csharp/language-reference/compiler-options/keycontainer-csharp-compiler-options.md)|Specifies the name of the cryptographic key container.|  
|[/keyfile](../../../csharp/language-reference/compiler-options/keyfile-csharp-compiler-options.md)|Specifies the filename containing the cryptographic key.|  
|[/lib](../../../csharp/language-reference/compiler-options/lib-csharp-compiler-options.md)|Specifies the location of assemblies referenced by means of [/reference](../../../csharp/language-reference/compiler-options/reference-csharp-compiler-options.md).|  
|[/nostdlib](../../../csharp/language-reference/compiler-options/nostdlib-csharp-compiler-options.md)|Instructs the compiler not to import the standard library (mscorlib.dll).|  
|[/reference](../../../csharp/language-reference/compiler-options/reference-csharp-compiler-options.md)|Imports metadata from a file that contains an assembly.|  
|`/analyzer`|Run the analyzers from this assembly (Short form: /a)|  
|`/additionalfile`|Names additional files that don't directly affect code generation but may be used by analyzers for producing errors or warnings.|  
  
### Debugging/Error Checking  
  
|Option|Purpose|  
|------------|-------------|  
|[/bugreport](../../../csharp/language-reference/compiler-options/bugreport-csharp-compiler-options.md)|Creates a file that contains information that makes it easy to report a bug.|  
|[/checked](../../../csharp/language-reference/compiler-options/checked-csharp-compiler-options.md)|Specifies whether integer arithmetic that overflows the bounds of the data type will cause an exception at run time.|  
|[/debug](../../../csharp/language-reference/compiler-options/debug-csharp-compiler-options.md)|Instruct the compiler to emit debugging information.|  
|[/errorreport](../../../csharp/language-reference/compiler-options/errorreport-csharp-compiler-options.md)|Sets error reporting behavior.|  
|[/fullpaths](../../../csharp/language-reference/compiler-options/fullpaths-csharp-compiler-options.md)|Specifies the absolute path to the file in compiler output.|  
|[/nowarn](../../../csharp/language-reference/compiler-options/nowarn-csharp-compiler-options.md)|Suppresses the compiler's generation of specified warnings.|  
|[/warn](../../../csharp/language-reference/compiler-options/warn-csharp-compiler-options.md)|Sets the warning level.|  
|[/warnaserror](../../../csharp/language-reference/compiler-options/warnaserror-csharp-compiler-options.md)|Promotes warnings to errors.|  
|`/ruleset:<file>`|Specify a ruleset file that disables specific diagnostics.|  
  
### Preprocessor  
  
|Option|Purpose|  
|------------|-------------|  
|[/define](../../../csharp/language-reference/compiler-options/define-csharp-compiler-options.md)|Defines preprocessor symbols.|  
  
### Resources  
  
|Option|Purpose|  
|------------|-------------|  
|[/link](../../../csharp/language-reference/compiler-options/link-csharp-compiler-options.md)|Makes COM type information in specified assemblies available to the project.|  
|[/linkresource](../../../csharp/language-reference/compiler-options/linkresource-csharp-compiler-options.md)|Creates a link to a managed resource.|  
|[/resource](../../../csharp/language-reference/compiler-options/resource-csharp-compiler-options.md)|Embeds a .NET Framework resource into the output file.|  
|[/win32icon](../../../csharp/language-reference/compiler-options/win32icon-csharp-compiler-options.md)|Specifies an .ico file to insert into the output file.|  
|[/win32res](../../../csharp/language-reference/compiler-options/win32res-csharp-compiler-options.md)|Specifies a Win32 resource to insert into the output file.|  
  
### Miscellaneous  
  
|Option|Purpose|  
|------------|-------------|  
|[@](../../../csharp/language-reference/compiler-options/response-file-compiler-option.md)|Specifies a response file.|  
|[/?](../../../csharp/language-reference/compiler-options/help-csharp-compiler-options.md)|Lists compiler options to stdout.|  
|[/baseaddress](../../../csharp/language-reference/compiler-options/baseaddress-csharp-compiler-options.md)|Specifies the preferred base address at which to load a DLL.|  
|[/codepage](../../../csharp/language-reference/compiler-options/codepage-csharp-compiler-options.md)|Specifies the code page to use for all source code files in the compilation.|  
|[/help](../../../csharp/language-reference/compiler-options/help-csharp-compiler-options.md)|Lists compiler options to stdout.|  
|[/highentropyva](../../../csharp/language-reference/compiler-options/highentropyva-csharp-compiler-options.md)|Specifies that the executable file supports address space layout randomization (ASLR).|  
|[/langversion](../../../csharp/language-reference/compiler-options/langversion-csharp-compiler-options.md)|Specify language version mode: ISO-1, ISO-2, 3, 4, 5, 6, or Default|  
|[/main](../../../csharp/language-reference/compiler-options/main-csharp-compiler-options.md)|Specifies the location of the **Main** method.|  
|[/noconfig](../../../csharp/language-reference/compiler-options/noconfig-csharp-compiler-options.md)|Instructs the compiler not to compile with csc.rsp.|  
|[/nologo](../../../csharp/language-reference/compiler-options/nologo-csharp-compiler-options.md)|Suppresses compiler banner information.|  
|[/recurse](../../../csharp/language-reference/compiler-options/recurse-csharp-compiler-options.md)|Searches subdirectories for source files to compile.|  
|[/subsystemversion](../../../csharp/language-reference/compiler-options/subsystemversion-csharp-compiler-options.md)|Specifies the minimum version of the subsystem that the executable file can use.|  
|[/unsafe](../../../csharp/language-reference/compiler-options/unsafe-csharp-compiler-options.md)|Enables compilation of code that uses the [unsafe](../../../csharp/language-reference/keywords/unsafe.md) keyword.|  
|[/utf8output](../../../csharp/language-reference/compiler-options/utf8output-csharp-compiler-options.md)|Displays compiler output using UTF-8 encoding.|  
|`/parallel[+&#124;-]`|Specifies whether to use concurrent build (+).|  
|`/checksumalgorithm:<alg>`|Specify the algorithm for calculating the source file checksum stored in PDB.  Supported values are: SHA1 (default) or SHA256.|  
  
## Obsolete Options  
  
|||  
|-|-|  
|**/incremental**|Enables incremental compilation.|  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [C# Compiler Options Listed Alphabetically](../../../csharp/language-reference/compiler-options/listed-alphabetically.md)   
 [How to: Set Environment Variables for the Visual Studio Command Line](../../../csharp/language-reference/compiler-options/how-to-set-environment-variables-for-the-visual-studio-command-line.md)