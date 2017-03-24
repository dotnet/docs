---
title: "Visual Basic Compiler Options Listed by Category | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "Visual Basic compiler, options"
ms.assetid: fbe36f7a-7cfa-4f77-a8d4-2be5958568e3
caps.latest.revision: 24
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Visual Basic Compiler Options Listed by Category
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

The [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] command-line compiler is provided as an alternative to compiling programs from within the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] integrated development environment (IDE). The following is a list of the [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] command-line compiler options sorted by functional category.  
  
## Compiler Output  
  
|||  
|-|-|  
|Option|Purpose|  
|[/nologo](../../../visual-basic/reference/command-line-compiler/nologo-visual-basic.md)|Suppresses compiler banner information.|  
|[/utf8output](../../../visual-basic/reference/command-line-compiler/utf8output-visual-basic.md)|Displays compiler output using UTF-8 encoding.|  
|[/verbose](../../../visual-basic/reference/command-line-compiler/verbose.md)|Outputs extra information during compilation.|  
|`/modulename:<string>`|Specify the name of the source module|  
|[/preferreduilang](../../../csharp/language-reference/compiler-options/preferreduilang-csharp-compiler-options.md)|Specify a language for compiler output.|  
  
## Optimization  
  
|||  
|-|-|  
|Option|Purpose|  
|[/filealign](../../../visual-basic/reference/command-line-compiler/filealign.md)|Specifies where to align the sections of the output file.|  
|[/optimize](../../../visual-basic/reference/command-line-compiler/optimize.md)|Enables/disables optimizations.|  
  
## Output Files  
  
|||  
|-|-|  
|Option|Purpose|  
|[/doc](../../../visual-basic/reference/command-line-compiler/doc.md)|Process documentation comments to an XML file.|  
|[/netcf](../../../visual-basic/reference/command-line-compiler/netcf.md)|Sets the compiler to target the [!INCLUDE[Compact](../../../includes/compact-md.md)].|  
|[/out](../../../visual-basic/reference/command-line-compiler/out-visual-basic.md)|Specifies an output file.|  
|[/target](../../../visual-basic/reference/command-line-compiler/target-visual-basic.md)|Specifies the format of the output.|  
  
## .NET Assemblies  
  
|||  
|-|-|  
|Option|Purpose|  
|[/addmodule](../../../visual-basic/reference/command-line-compiler/addmodule.md)|Causes the compiler to make all type information from the specified file(s) available to the project you are currently compiling.|  
|[/delaysign](../../../visual-basic/reference/command-line-compiler/delaysign.md)|Specifies whether the assembly will be fully or partially signed.|  
|[/imports](../../../visual-basic/reference/command-line-compiler/imports-visual-basic.md)|Imports a namespace from a specified assembly.|  
|[/keycontainer](../../../visual-basic/reference/command-line-compiler/keycontainer.md)|Specifies a key container name for a key pair to give an assembly a strong name.|  
|[/keyfile](../../../visual-basic/reference/command-line-compiler/keyfile.md)|Specifies a file containing a key or key pair to give an assembly a strong name.|  
|[/libpath](../../../visual-basic/reference/command-line-compiler/libpath.md)|Specifies the location of assemblies referenced by the [/reference](../../../visual-basic/reference/command-line-compiler/reference-visual-basic.md) option.|  
|[/reference](../../../visual-basic/reference/command-line-compiler/reference-visual-basic.md)|Imports metadata from an assembly.|  
|[/moduleassemblyname](../../../visual-basic/reference/command-line-compiler/moduleassemblyname.md)|Specifies the name of the assembly that a module will be a part of.|  
|`/analyzer`|Run the analyzers from this assembly (Short form: /a)|  
|`/additionalfile`|Names additional files that don't directly affect code generation but may be used by analyzers for producing errors or warnings.|  
  
## Debugging/Error Checking  
  
|||  
|-|-|  
|Option|Purpose|  
|[/bugreport](../../../visual-basic/reference/command-line-compiler/bugreport.md)|Creates a file that contains information that makes it easy to report a bug.|  
|[/debug](../../../visual-basic/reference/command-line-compiler/debug-visual-basic.md)|Produces debugging information.|  
|[/nowarn](../../../visual-basic/reference/command-line-compiler/nowarn.md)|Suppresses the compiler's ability to generate warnings.|  
|[/quiet](../../../visual-basic/reference/command-line-compiler/quiet.md)|Prevents the compiler from displaying code for syntax-related errors and warnings.|  
|[/removeintchecks](../../../visual-basic/reference/command-line-compiler/removeintchecks.md)|Disables integer overflow checking.|  
|[/warnaserror](../../../visual-basic/reference/command-line-compiler/warnaserror-visual-basic.md)|Promotes warnings to errors.|  
|`/ruleset:<file>`|Specify a ruleset file that disables specific diagnostics.|  
  
## Help  
  
|||  
|-|-|  
|Option|Purpose|  
|[/?](../../../visual-basic/reference/command-line-compiler/help-visual-basic.md)|Displays the compiler options. This command is the same as specifying the `/help` option. No compilation occurs.|  
|[/help](../../../visual-basic/reference/command-line-compiler/help-visual-basic.md)|Displays the compiler options. This command is the same as specifying the `/?` option. No compilation occurs.|  
  
## Language  
  
|||  
|-|-|  
|Option|Purpose|  
|[/langversion](../../../visual-basic/reference/command-line-compiler/langversion-visual-basic.md)|Specify language version: 9&#124;9.0&#124;10&#124;10.0&#124;11&#124;11.0.|  
|[/optionexplicit](../../../visual-basic/reference/command-line-compiler/optionexplicit.md)|Enforces explicit declaration of variables.|  
|[/optionstrict](../../../visual-basic/reference/command-line-compiler/optionstrict.md)|Enforces strict type semantics.|  
|[/optioncompare](../../../visual-basic/reference/command-line-compiler/optioncompare.md)|Specifies whether string comparisons should be binary or use locale-specific text semantics.|  
|[/optioninfer](../../../visual-basic/reference/command-line-compiler/optioninfer.md)|Enables the use of local type inference in variable declarations.|  
  
## Preprocessor  
  
|||  
|-|-|  
|Option|Purpose|  
|[/define](../../../visual-basic/reference/command-line-compiler/define-visual-basic.md)|Defines symbols for conditional compilation.|  
  
## Resources  
  
|||  
|-|-|  
|Option|Purpose|  
|[/linkresource](../../../visual-basic/reference/command-line-compiler/linkresource-visual-basic.md)|Creates a link to a managed resource.|  
|[/resource](../../../visual-basic/reference/command-line-compiler/resource-visual-basic.md)|Embeds a managed resource in an assembly.|  
|[/win32icon](../../../visual-basic/reference/command-line-compiler/win32icon.md)|Inserts an .ico file into the output file.|  
|[/win32resource](../../../visual-basic/reference/command-line-compiler/win32resource.md)|Inserts a Win32 resource into the output file.|  
  
## Miscellaneous  
  
|||  
|-|-|  
|Option|Purpose|  
|[@ (Specify Response File)](../../../visual-basic/reference/command-line-compiler/specify-response-file.md)|Specifies a response file.|  
|[/baseaddress](../../../visual-basic/reference/command-line-compiler/baseaddress.md)|Specifies the base address of a DLL.|  
|[/codepage](../../../visual-basic/reference/command-line-compiler/codepage-visual-basic.md)|Specifies the code page to use for all source code files in the compilation.|  
|[/errorreport](../../../visual-basic/reference/command-line-compiler/errorreport.md)|Specifies how the [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] compiler should report internal compiler errors.|  
|[/highentropyva](../../../visual-basic/reference/command-line-compiler/highentropyva-visual-basic.md)|Tells the Windows kernel whether a particular executable supports high entropy Address Space Layout Randomization (ASLR).|  
|[/main](../../../visual-basic/reference/command-line-compiler/main.md)|Specifies the class that contains the `Sub``Main` procedure to use at startup.|  
|[/noconfig](../../../visual-basic/reference/command-line-compiler/noconfig.md)|Do not compile with Vbc.rsp|  
|[/nostdlib](../../../visual-basic/reference/command-line-compiler/nostdlib-visual-basic.md)|Causes the compiler not to reference the standard libraries.|  
|[/nowin32manifest](../../../visual-basic/reference/command-line-compiler/nowin32manifest-visual-basic.md)|Instructs the compiler not to embed any application manifest into the executable file.|  
|[/platform](../../../visual-basic/reference/command-line-compiler/platform-visual-basic.md)|Specifies the processor platform the compiler targets for the output file.|  
|[/recurse](../../../visual-basic/reference/command-line-compiler/recurse.md)|Searches subdirectories for source files to compile.|  
|[/rootnamespace](../../../visual-basic/reference/command-line-compiler/rootnamespace.md)|Specifies a namespace for all type declarations.|  
|[/sdkpath](../../../visual-basic/reference/command-line-compiler/sdkpath.md)|Specifies the location of Mscorlib.dll and Microsoft.VisualBasic.dll.|  
|[/vbruntime](../../../visual-basic/reference/command-line-compiler/vbruntime.md)|Specifies that the compiler should compile without a reference to the Visual Basic Runtime Library, or with a reference to a specific runtime library.|  
|[/win32manifest](../../../visual-basic/reference/command-line-compiler/win32manifest-visual-basic.md)|Identifies a user-defined Win32 application manifest file to be embedded into a project's portable executable (PE) file.|  
|`/parallel[+&#124;-]`|Specifies whether to use concurrent build (+).|  
|`/checksumalgorithm:<alg>`|Specify the algorithm for calculating the source file checksum stored in PDB.  Supported values are: SHA1 (default) or SHA256.|  
  
## See Also  
 [Visual Basic Compiler Options Listed Alphabetically](../../../visual-basic/reference/command-line-compiler/compiler-options-listed-alphabetically.md)   
 [Introduction to the Project Designer](http://msdn.microsoft.com/en-us/898dd854-c98d-430c-ba1b-a913ce3c73d7)   
 [C# Compiler Options Listed Alphabetically](../../../csharp/language-reference/compiler-options/listed-alphabetically.md)   
 [C# Compiler Options Listed by Category](../../../csharp/language-reference/compiler-options/listed-by-category.md)