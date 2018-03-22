---
title: "Visual Basic Compiler Options Listed Alphabetically"
ms.date: 03/09/2018
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Visual Basic compiler, options"
ms.assetid: e67febba-bacf-4e1f-a143-c141e063f90e
author: rpetrusha
ms.author: ronpet
---
# Visual Basic compiler options listed alphabetically
The Visual Basic command-line compiler is provided as an alternative to compiling programs from the [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] integrated development environment (IDE). The following is a list of the Visual Basic command-line compiler options sorted alphabetically.  

[!INCLUDE[compiler-options](~/includes/compiler-options.md)]
  
|Option|Purpose|  
|------------|-------------|  
|[@ (Specify Response File)](../../../visual-basic/reference/command-line-compiler/specify-response-file.md)|Specifies a response file.|  
|[-?](../../../visual-basic/reference/command-line-compiler/help.md)|Displays compiler options. This command is the same as specifying the `-help` option. No compilation occurs.|  
|`-additionalfile`|Names additional files that don't directly affect code generation but may be used by analyzers for producing errors or warnings.|  
|[-addmodule](../../../visual-basic/reference/command-line-compiler/addmodule.md)|Causes the compiler to make all type information from the specified file(s) available to the project you are currently compiling.|  
|`-analyzer`|Run the analyzers from this assembly (Short form: -a)|  
|[-baseaddress](../../../visual-basic/reference/command-line-compiler/baseaddress.md)|Specifies the base address of a DLL.|  
|[-bugreport](../../../visual-basic/reference/command-line-compiler/bugreport.md)|Creates a file that contains information that makes it easy to report a bug.|  
|`-checksumalgorithm:<alg>`|Specify the algorithm for calculating the source file checksum stored in PDB.  Supported values are: SHA1 (default) or SHA256.|  
|[-codepage](../../../visual-basic/reference/command-line-compiler/codepage.md)|Specifies the code page to use for all source code files in the compilation.|  
|[-debug](../../../visual-basic/reference/command-line-compiler/debug.md)|Produces debugging information.|  
|[-define](../../../visual-basic/reference/command-line-compiler/define.md)|Defines symbols for conditional compilation.|  
|[-delaysign](../../../visual-basic/reference/command-line-compiler/delaysign.md)|Specifies whether the assembly will be fully or partially signed.|  
|[-doc](../../../visual-basic/reference/command-line-compiler/doc.md)|Processes documentation comments to an XML file.|  
|[-errorreport](../../../visual-basic/reference/command-line-compiler/errorreport.md)|Specifies how the Visual Basic compiler should report internal compiler errors.|  
|[-filealign](../../../visual-basic/reference/command-line-compiler/filealign.md)|Specifies where to align the sections of the output file.|  
|[-help](../../../visual-basic/reference/command-line-compiler/help.md)|Displays compiler options. This command is the same as specifying the `-?` option. No compilation occurs.|  
|[-highentropyva](../../../visual-basic/reference/command-line-compiler/highentropyva.md)|Indicates whether a particular executable supports high entropy Address Space Layout Randomization (ASLR).|  
|[-imports](../../../visual-basic/reference/command-line-compiler/imports.md)|Imports a namespace from a specified assembly.|  
|[-keycontainer](../../../visual-basic/reference/command-line-compiler/keycontainer.md)|Specifies a key container name for a key pair to give an assembly a strong name.|  
|[-keyfile](../../../visual-basic/reference/command-line-compiler/keyfile.md)|Specifies a file that contains a key or key pair to give an assembly a strong name.|  
|[-langversion](../../../visual-basic/reference/command-line-compiler/langversion.md)|Specify language version: 9&#124;9.0&#124;10&#124;10.0&#124;11&#124;11.0.|  
|[-libpath](../../../visual-basic/reference/command-line-compiler/libpath.md)|Specifies the location of assemblies referenced by the [-reference](../../../visual-basic/reference/command-line-compiler/reference.md) option.|  
|[-linkresource](../../../visual-basic/reference/command-line-compiler/linkresource.md)|Creates a link to a managed resource.|  
|[-main](../../../visual-basic/reference/command-line-compiler/main.md)|Specifies the class that contains the `Sub Main` procedure to use at startup.|  
|[-moduleassemblyname](../../../visual-basic/reference/command-line-compiler/moduleassemblyname.md)|Specifies the name of the assembly that a module will be a part of.|  
|`-modulename:<string>`|Specify the name of the source module|  
|[-netcf](../../../visual-basic/reference/command-line-compiler/netcf.md)|Sets the compiler to target the [!INCLUDE[Compact](~/includes/compact-md.md)].|  
|[-noconfig](../../../visual-basic/reference/command-line-compiler/noconfig.md)|Do not compile with Vbc.rsp.|  
|[-nologo](../../../visual-basic/reference/command-line-compiler/nologo.md)|Suppresses compiler banner information.|  
|[-nostdlib](../../../visual-basic/reference/command-line-compiler/nostdlib.md)|Causes the compiler not to reference the standard libraries.|  
|[-nowarn](../../../visual-basic/reference/command-line-compiler/nowarn.md)|Suppresses the compiler's ability to generate warnings.|  
|[-nowin32manifest](../../../visual-basic/reference/command-line-compiler/nowin32manifest.md)|Instructs the compiler not to embed any application manifest into the executable file.|  
|[-optimize](../../../visual-basic/reference/command-line-compiler/optimize.md)|Enables/disables code optimization.|  
|[-optioncompare](../../../visual-basic/reference/command-line-compiler/optioncompare.md)|Specifies whether string comparisons should be binary or use locale-specific text semantics.|  
|[-optionexplicit](../../../visual-basic/reference/command-line-compiler/optionexplicit.md)|Enforces explicit declaration of variables.|  
|[-optioninfer](../../../visual-basic/reference/command-line-compiler/optioninfer.md)|Enables the use of local type inference in variable declarations.|  
|[-optionstrict](../../../visual-basic/reference/command-line-compiler/optionstrict.md)|Enforces strict language semantics.|  
|[-out](../../../visual-basic/reference/command-line-compiler/out.md)|Specifies an output file.|  
|`-parallel[+&#124;-]`|Specifies whether to use concurrent build (+).|  
|[-platform](../../../visual-basic/reference/command-line-compiler/platform.md)|Specifies the processor platform the compiler targets for the output file.|  
|`-preferreduilang`|Specify the preferred output language name.|  
|[-quiet](../../../visual-basic/reference/command-line-compiler/quiet.md)|Prevents the compiler from displaying code for syntax-related errors and warnings.|  
|[-recurse](../../../visual-basic/reference/command-line-compiler/recurse.md)|Searches subdirectories for source files to compile.|  
|[-reference](../../../visual-basic/reference/command-line-compiler/reference.md)|Imports metadata from an assembly.|  
|[-refonly](refonly-compiler-option.md)|Outputs only a reference assembly.|
|[-refout](refout-compiler-option.md)|Specifies the output path of a reference assembly.|
|[-removeintchecks](../../../visual-basic/reference/command-line-compiler/removeintchecks.md)|Disables integer overflow checking.|  
|[-resource](../../../visual-basic/reference/command-line-compiler/resource.md)|Embeds a managed resource in an assembly.|  
|[-rootnamespace](../../../visual-basic/reference/command-line-compiler/rootnamespace.md)|Specifies a namespace for all type declarations.|  
|`-ruleset:<file>`|Specify a ruleset file that disables specific diagnostics.|  
|[-sdkpath](../../../visual-basic/reference/command-line-compiler/sdkpath.md)|Specifies the location of Mscorlib.dll and Microsoft.VisualBasic.dll.|  
|[-subsystemversion](../../../visual-basic/reference/command-line-compiler/subsystemversion.md)|Specifies the minimum version of the subsystem that the generated executable file can use.|  
|[-target](../../../visual-basic/reference/command-line-compiler/target.md)|Specifies the format of the output file.|  
|[-utf8output](../../../visual-basic/reference/command-line-compiler/utf8output.md)|Displays compiler output using UTF-8 encoding.|  
|[-vbruntime](../../../visual-basic/reference/command-line-compiler/vbruntime.md)|Specifies that the compiler should compile without a reference to the Visual Basic Runtime Library, or with a reference to a specific runtime library.|  
|[-verbose](../../../visual-basic/reference/command-line-compiler/verbose.md)|Outputs extra information during compilation.|  
|[-warnaserror](../../../visual-basic/reference/command-line-compiler/warnaserror.md)|Promotes warnings to errors.|  
|[-win32icon](../../../visual-basic/reference/command-line-compiler/win32icon.md)|Inserts an .ico file into the output file.|  
|[-win32manifest](../../../visual-basic/reference/command-line-compiler/win32manifest.md)|Identifies a user-defined Win32 application manifest file to be embedded into a project's portable executable (PE) file.|  
|[-win32resource](../../../visual-basic/reference/command-line-compiler/win32resource.md)|Inserts a Win32 resource into the output file.|  
  
## See also  
 [Visual Basic Compiler Options Listed by Category](../../../visual-basic/reference/command-line-compiler/compiler-options-listed-by-category.md)  
 [Introduction to the Project Designer](http://msdn.microsoft.com/library/898dd854-c98d-430c-ba1b-a913ce3c73d7)  
 [C# Compiler Options Listed Alphabetically](../../../csharp/language-reference/compiler-options/listed-alphabetically.md)  
 [C# Compiler Options Listed by Category](../../../csharp/language-reference/compiler-options/listed-by-category.md)
