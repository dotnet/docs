---
title: "C# Compiler Options Listed by Category"
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
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# C# Compiler Options Listed by Category
The following compiler options are sorted by category. For an alphabetical list, see [C# Compiler Options Listed Alphabetically](../compiler-options/csharp-compiler-options-listed-alphabetically.md).  
  
### Optimization  
  
|Option|Purpose|  
|------------|-------------|  
|[/filealign](../compiler-options/-filealign--csharp-compiler-options-.md)|Specifies the size of sections in the output file.|  
|[/optimize](../compiler-options/-optimize--csharp-compiler-options-.md)|Enables/disables optimizations.|  
  
### Output Files  
  
|Option|Purpose|  
|------------|-------------|  
|[/doc](../compiler-options/-doc--csharp-compiler-options-.md)|Specifies an XML file where processed documentation comments are to be written.|  
|[/out](../compiler-options/-out--csharp-compiler-options-.md)|Specifies the output file.|  
|[/pdb](../compiler-options/-pdb--csharp-compiler-options-.md)|Specifies the file name and location of the .pdb file.|  
|[/platform](../compiler-options/-platform--csharp-compiler-options-.md)|Specify the output platform.|  
|[/preferreduilang](../compiler-options/-preferreduilang--csharp-compiler-options-.md)|Specify a language for compiler output.|  
|[/target](../compiler-options/-target--csharp-compiler-options-.md)|Specifies the format of the output file using one of five options: [/target:appcontainerexe](../compiler-options/-target-appcontainerexe--csharp-compiler-options-.md), [/target:exe](../compiler-options/-target-exe--csharp-compiler-options-.md), [/target:library](../compiler-options/-target-library--csharp-compiler-options-.md), [/target:module](../compiler-options/-target-module--csharp-compiler-options-.md), [/target:winexe](../compiler-options/-target-winexe--csharp-compiler-options-.md), or [/target:winmdobj](../compiler-options/-target-winmdobj--csharp-compiler-options-.md).|  
|`/modulename:<string>`|Specify the name of the source module|  
  
### .NET Framework Assemblies  
  
|Option|Purpose|  
|------------|-------------|  
|[/addmodule](../compiler-options/-addmodule--csharp-compiler-options-.md)|Specifies one or more modules to be part of this assembly.|  
|[/delaysign](../compiler-options/-delaysign--csharp-compiler-options-.md)|Instructs the compiler to add the public key but to leave the assembly unsigned.|  
|[/keycontainer](../compiler-options/-keycontainer--csharp-compiler-options-.md)|Specifies the name of the cryptographic key container.|  
|[/keyfile](../compiler-options/-keyfile--csharp-compiler-options-.md)|Specifies the filename containing the cryptographic key.|  
|[/lib](../compiler-options/-lib--csharp-compiler-options-.md)|Specifies the location of assemblies referenced by means of [/reference](../compiler-options/-reference--csharp-compiler-options-.md).|  
|[/nostdlib](../compiler-options/-nostdlib--csharp-compiler-options-.md)|Instructs the compiler not to import the standard library (mscorlib.dll).|  
|[/reference](../compiler-options/-reference--csharp-compiler-options-.md)|Imports metadata from a file that contains an assembly.|  
|`/analyzer`|Run the analyzers from this assembly (Short form: /a)|  
|`/additionalfile`|Names additional files that don't directly affect code generation but may be used by analyzers for producing errors or warnings.|  
  
### Debugging/Error Checking  
  
|Option|Purpose|  
|------------|-------------|  
|[/bugreport](../compiler-options/-bugreport--csharp-compiler-options-.md)|Creates a file that contains information that makes it easy to report a bug.|  
|[/checked](../compiler-options/-checked--csharp-compiler-options-.md)|Specifies whether integer arithmetic that overflows the bounds of the data type will cause an exception at run time.|  
|[/debug](../compiler-options/-debug--csharp-compiler-options-.md)|Instruct the compiler to emit debugging information.|  
|[/errorreport](../compiler-options/-errorreport--csharp-compiler-options-.md)|Sets error reporting behavior.|  
|[/fullpaths](../compiler-options/-fullpaths--csharp-compiler-options-.md)|Specifies the absolute path to the file in compiler output.|  
|[/nowarn](../compiler-options/-nowarn--csharp-compiler-options-.md)|Suppresses the compiler's generation of specified warnings.|  
|[/warn](../compiler-options/-warn--csharp-compiler-options-.md)|Sets the warning level.|  
|[/warnaserror](../compiler-options/-warnaserror--csharp-compiler-options-.md)|Promotes warnings to errors.|  
|`/ruleset:<file>`|Specify a ruleset file that disables specific diagnostics.|  
  
### Preprocessor  
  
|Option|Purpose|  
|------------|-------------|  
|[/define](../compiler-options/-define--csharp-compiler-options-.md)|Defines preprocessor symbols.|  
  
### Resources  
  
|Option|Purpose|  
|------------|-------------|  
|[/link](../compiler-options/-link--csharp-compiler-options-.md)|Makes COM type information in specified assemblies available to the project.|  
|[/linkresource](../compiler-options/-linkresource--csharp-compiler-options-.md)|Creates a link to a managed resource.|  
|[/resource](../compiler-options/-resource--csharp-compiler-options-.md)|Embeds a .NET Framework resource into the output file.|  
|[/win32icon](../compiler-options/-win32icon--csharp-compiler-options-.md)|Specifies an .ico file to insert into the output file.|  
|[/win32res](../compiler-options/-win32res--csharp-compiler-options-.md)|Specifies a Win32 resource to insert into the output file.|  
  
### Miscellaneous  
  
|Option|Purpose|  
|------------|-------------|  
|[@](../compiler-options/@--csharp-compiler-options-.md)|Specifies a response file.|  
|[/?](../compiler-options/-help------csharp-compiler-options-.md)|Lists compiler options to stdout.|  
|[/baseaddress](../compiler-options/-baseaddress--csharp-compiler-options-.md)|Specifies the preferred base address at which to load a DLL.|  
|[/codepage](../compiler-options/-codepage--csharp-compiler-options-.md)|Specifies the code page to use for all source code files in the compilation.|  
|[/help](../compiler-options/-help------csharp-compiler-options-.md)|Lists compiler options to stdout.|  
|[/highentropyva](../compiler-options/-highentropyva--csharp-compiler-options-.md)|Specifies that the executable file supports address space layout randomization (ASLR).|  
|[/langversion](../compiler-options/-langversion--csharp-compiler-options-.md)|Specify language version mode: ISO-1, ISO-2, 3, 4, 5, 6, or Default|  
|[/main](../compiler-options/-main--csharp-compiler-options-.md)|Specifies the location of the **Main** method.|  
|[/noconfig](../compiler-options/-noconfig--csharp-compiler-options-.md)|Instructs the compiler not to compile with csc.rsp.|  
|[/nologo](../compiler-options/-nologo--csharp-compiler-options-.md)|Suppresses compiler banner information.|  
|[/recurse](../compiler-options/-recurse--csharp-compiler-options-.md)|Searches subdirectories for source files to compile.|  
|[/subsystemversion](../compiler-options/-subsystemversion--csharp-compiler-options-.md)|Specifies the minimum version of the subsystem that the executable file can use.|  
|[/unsafe](../compiler-options/-unsafe--csharp-compiler-options-.md)|Enables compilation of code that uses the [unsafe](../keywords/unsafe--csharp-reference-.md) keyword.|  
|[/utf8output](../compiler-options/-utf8output--csharp-compiler-options-.md)|Displays compiler output using UTF-8 encoding.|  
|`/parallel[+&#124;-]`|Specifies whether to use concurrent build (+).|  
|`/checksumalgorithm:<alg>`|Specify the algorithm for calculating the source file checksum stored in PDB.  Supported values are: SHA1 (default) or SHA256.|  
  
## Obsolete Options  
  
|||  
|-|-|  
|**/incremental**|Enables incremental compilation.|  
  
## See Also  
 [C# Compiler Options](../compiler-options/csharp-compiler-options.md)   
 [C# Compiler Options Listed Alphabetically](../compiler-options/csharp-compiler-options-listed-alphabetically.md)   
 [How to: Set Environment Variables for the Visual Studio Command Line](../compiler-options/how-to--set-environment-variables-for-the-visual-studio-command-line.md)