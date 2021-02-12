---
description: "Learn more about: Visual Basic compiler options listed alphabetically"
title: "Compiler Options Listed Alphabetically"
ms.date: 04/12/2018
helpviewer_keywords: 
  - "Visual Basic compiler, options"
ms.assetid: e67febba-bacf-4e1f-a143-c141e063f90e
---
# Visual Basic compiler options listed alphabetically

The Visual Basic command-line compiler is provided as an alternative to compiling programs from the Visual Studio integrated development environment (IDE). The following is a list of the Visual Basic command-line compiler options sorted alphabetically.  

[!INCLUDE[compiler-options](~/includes/compiler-options.md)]
  
|Option|Purpose|  
|------------|-------------|  
|[@ (Specify Response File)](specify-response-file.md)|Specifies a response file.|  
|[-?](help.md)|Displays compiler options. This command is the same as specifying the `-help` option. No compilation occurs.|  
|`-additionalfile`|Names additional files that don't directly affect code generation but may be used by analyzers for producing errors or warnings.|  
|[-addmodule](addmodule.md)|Causes the compiler to make all type information from the specified file(s) available to the project you are currently compiling.|  
|`-analyzer`|Run the analyzers from this assembly (Short form: -a)|  
|[-baseaddress](baseaddress.md)|Specifies the base address of a DLL.|  
|[-bugreport](bugreport.md)|Creates a file that contains information that makes it easy to report a bug.|  
|`-checksumalgorithm:<alg>`|Specify the algorithm for calculating the source file checksum stored in PDB.  Supported values are: SHA1 (default) or SHA256. <br>Due to collision problems with SHA1, Microsoft recommends SHA256 or better.|  
|[-codepage](codepage.md)|Specifies the code page to use for all source code files in the compilation.|  
|[-debug](debug.md)|Produces debugging information.|  
|[-define](define.md)|Defines symbols for conditional compilation.|  
|[-delaysign](delaysign.md)|Specifies whether the assembly will be fully or partially signed.|  
|[-deterministic](deterministic.md)|Causes the compiler to output an assembly whose binary content is identical across compilations if inputs are identical.|
|[-doc](doc.md)|Processes documentation comments to an XML file.|  
|[-errorreport](errorreport.md)|Specifies how the Visual Basic compiler should report internal compiler errors.|  
|[-filealign](filealign.md)|Specifies where to align the sections of the output file.|  
|[-help](help.md)|Displays compiler options. This command is the same as specifying the `-?` option. No compilation occurs.|  
|[-highentropyva](highentropyva.md)|Indicates whether a particular executable supports high entropy Address Space Layout Randomization (ASLR).|  
|[-imports](imports.md)|Imports a namespace from a specified assembly.|  
|[-keycontainer](keycontainer.md)|Specifies a key container name for a key pair to give an assembly a strong name.|  
|[-keyfile](keyfile.md)|Specifies a file that contains a key or key pair to give an assembly a strong name.|  
|[-langversion](langversion.md)|Specify language version: 9&#124;9.0&#124;10&#124;10.0&#124;11&#124;11.0.|  
|[-libpath](libpath.md)|Specifies the location of assemblies referenced by the [-reference](reference.md) option.|  
|[-linkresource](linkresource.md)|Creates a link to a managed resource.|  
|[-main](main.md)|Specifies the class that contains the `Sub Main` procedure to use at startup.|  
|[-moduleassemblyname](moduleassemblyname.md)|Specifies the name of the assembly that a module will be a part of.|  
|`-modulename:<string>`|Specify the name of the source module|  
|[-netcf](netcf.md)|Sets the compiler to target the .NET Compact Framework.|  
|[-noconfig](noconfig.md)|Do not compile with Vbc.rsp.|  
|[-nologo](nologo.md)|Suppresses compiler banner information.|  
|[-nostdlib](nostdlib.md)|Causes the compiler not to reference the standard libraries.|  
|[-nowarn](nowarn.md)|Suppresses the compiler's ability to generate warnings.|  
|[-nowin32manifest](nowin32manifest.md)|Instructs the compiler not to embed any application manifest into the executable file.|  
|[-optimize](optimize.md)|Enables/disables code optimization.|  
|[-optioncompare](optioncompare.md)|Specifies whether string comparisons should be binary or use locale-specific text semantics.|  
|[-optionexplicit](optionexplicit.md)|Enforces explicit declaration of variables.|  
|[-optioninfer](optioninfer.md)|Enables the use of local type inference in variable declarations.|  
|[-optionstrict](optionstrict.md)|Enforces strict language semantics.|  
|[-out](out.md)|Specifies an output file.|  
|<code>-parallel[+&#124;-]</code>|Specifies whether to use concurrent build (+).|  
|[-platform](platform.md)|Specifies the processor platform the compiler targets for the output file.|  
|`-preferreduilang`|Specify the preferred output language name.|  
|[-quiet](quiet.md)|Prevents the compiler from displaying code for syntax-related errors and warnings.|  
|[-recurse](recurse.md)|Searches subdirectories for source files to compile.|  
|[-reference](reference.md)|Imports metadata from an assembly.|  
|[-refonly](refonly-compiler-option.md)|Outputs only a reference assembly.|
|[-refout](refout-compiler-option.md)|Specifies the output path of a reference assembly.|
|[-removeintchecks](removeintchecks.md)|Disables integer overflow checking.|  
|[-resource](resource.md)|Embeds a managed resource in an assembly.|  
|[-rootnamespace](rootnamespace.md)|Specifies a namespace for all type declarations.|  
|`-ruleset:<file>`|Specify a ruleset file that disables specific diagnostics.|  
|[-sdkpath](sdkpath.md)|Specifies the location of Mscorlib.dll and Microsoft.VisualBasic.dll.|  
|[-subsystemversion](subsystemversion.md)|Specifies the minimum version of the subsystem that the generated executable file can use.|  
|[-target](target.md)|Specifies the format of the output file.|  
|[-utf8output](utf8output.md)|Displays compiler output using UTF-8 encoding.|  
|[-vbruntime](vbruntime.md)|Specifies that the compiler should compile without a reference to the Visual Basic Runtime Library, or with a reference to a specific runtime library.|  
|[-verbose](verbose.md)|Outputs extra information during compilation.|  
|[-warnaserror](warnaserror.md)|Promotes warnings to errors.|  
|[-win32icon](win32icon.md)|Inserts an .ico file into the output file.|  
|[-win32manifest](win32manifest.md)|Identifies a user-defined Win32 application manifest file to be embedded into a project's portable executable (PE) file.|  
|[-win32resource](win32resource.md)|Inserts a Win32 resource into the output file.|  
  
## See also

- [Visual Basic Compiler Options Listed by Category](compiler-options-listed-by-category.md)
- [Manage project and solution properties](/visualstudio/ide/managing-project-and-solution-properties)
