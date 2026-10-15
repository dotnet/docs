---
description: "Learn more about: Visual Basic compiler options listed by category"
title: "Compiler Options Listed by Category"
ms.date: 04/12/2018
helpviewer_keywords: 
  - "Visual Basic compiler, options"
ms.assetid: fbe36f7a-7cfa-4f77-a8d4-2be5958568e3
---
# Visual Basic compiler options listed by category

The Visual Basic command-line compiler is provided as an alternative to compiling programs from within the Visual Studio integrated development environment (IDE). The following is a list of the Visual Basic command-line compiler options sorted by functional category.  

[!INCLUDE[compiler-options](~/includes/compiler-options.md)]
  
## Compiler output  
  
|Option|Purpose|  
|---|---|  
|[:::no-loc text="\-nologo":::](nologo.md)|Suppresses compiler banner information.|  
|[:::no-loc text="\-utf8output":::](utf8output.md)|Displays compiler output using UTF-8 encoding.|  
|[:::no-loc text="\-verbose":::](verbose.md)|Outputs extra information during compilation.|  
|`-modulename:<string>`|Specify the name of the source module|  
|[:::no-loc text="\-preferreduilang":::](../../../csharp/language-reference/compiler-options/advanced.md#preferreduilang)|Specify a language for compiler output.|
  
## Optimization  
  
|Option|Purpose|  
|---|---|  
|[:::no-loc text="\-filealign":::](filealign.md)|Specifies where to align the sections of the output file.|  
|[:::no-loc text="\-optimize":::](optimize.md)|Enables/disables optimizations.|  
  
## Output files  
  
|Option|Purpose|  
|---|---|  
|[:::no-loc text="\-doc":::](doc.md)|Process documentation comments to an XML file.|  
|[:::no-loc text="\-deterministic":::](deterministic.md)|Causes the compiler to output an assembly whose binary content is identical across compilations if inputs are identical.|
|[:::no-loc text="\-netcf":::](netcf.md)|Sets the compiler to target the .NET Compact Framework.|  
|[:::no-loc text="\-out":::](out.md)|Specifies an output file.|  
|[:::no-loc text="\-refonly":::](refonly-compiler-option.md)|Outputs only a reference assembly.|
|[:::no-loc text="\-refout":::](refout-compiler-option.md)|Specifies the output path of a reference assembly.|
|[:::no-loc text="\-target":::](target.md)|Specifies the format of the output.|  
  
## .NET assemblies  
  
|Option|Purpose|  
|---|---|  
|[:::no-loc text="\-addmodule":::](addmodule.md)|Causes the compiler to make all type information from the specified file(s) available to the project you are currently compiling.|  
|[:::no-loc text="\-delaysign":::](delaysign.md)|Specifies whether the assembly will be fully or partially signed.|  
|[:::no-loc text="\-imports":::](imports.md)|Imports a namespace from a specified assembly.|  
|[:::no-loc text="\-keycontainer":::](keycontainer.md)|Specifies a key container name for a key pair to give an assembly a strong name.|  
|[:::no-loc text="\-keyfile":::](keyfile.md)|Specifies a file containing a key or key pair to give an assembly a strong name.|  
|[:::no-loc text="\-libpath":::](libpath.md)|Specifies the location of assemblies referenced by the [-reference](reference.md) option.|  
|[:::no-loc text="\-reference":::](reference.md)|Imports metadata from an assembly.|  
|[:::no-loc text="\-moduleassemblyname":::](moduleassemblyname.md)|Specifies the name of the assembly that a module will be a part of.|  
|`-analyzer`|Run the analyzers from this assembly (Short form: -a)|  
|`-additionalfile`|Names additional files that don't directly affect code generation but may be used by analyzers for producing errors or warnings.|  
  
## Debugging/error checking  
  
|Option|Purpose|  
|---|---|  
|[:::no-loc text="\-bugreport":::](bugreport.md)|Creates a file that contains information that makes it easy to report a bug.|  
|[:::no-loc text="\-debug":::](debug.md)|Produces debugging information.|  
|[:::no-loc text="\-nowarn":::](nowarn.md)|Suppresses the compiler's ability to generate warnings.|  
|[:::no-loc text="\-quiet":::](quiet.md)|Prevents the compiler from displaying code for syntax-related errors and warnings.|  
|[:::no-loc text="\-removeintchecks":::](removeintchecks.md)|Disables integer overflow checking.|  
|[:::no-loc text="\-warnaserror":::](warnaserror.md)|Promotes warnings to errors.|  
|`-ruleset:<file>`|Specify a ruleset file that disables specific diagnostics.|  
  
## Help  
  
|Option|Purpose|  
|---|---|  
|[:::no-loc text="\-\?":::](help.md)|Displays the compiler options. This command is the same as specifying the `-help` option. No compilation occurs.|  
|[:::no-loc text="\-help":::](help.md)|Displays the compiler options. This command is the same as specifying the `-?` option. No compilation occurs.|  
  
## Language  
  
|Option|Purpose|  
|---|---|  
|[:::no-loc text="\-langversion":::](langversion.md)|Specify language version: 9&#124;9.0&#124;10&#124;10.0&#124;11&#124;11.0.|  
|[:::no-loc text="\-optionexplicit":::](optionexplicit.md)|Enforces explicit declaration of variables.|  
|[:::no-loc text="\-optionstrict":::](optionstrict.md)|Enforces strict type semantics.|  
|[:::no-loc text="\-optioncompare":::](optioncompare.md)|Specifies whether string comparisons should be binary or use locale-specific text semantics.|  
|[:::no-loc text="\-optioninfer":::](optioninfer.md)|Enables the use of local type inference in variable declarations.|  
  
## Preprocessor  
  
|Option|Purpose|  
|---|---|  
|[:::no-loc text="\-define":::](define.md)|Defines symbols for conditional compilation.|  
  
## Resources  
  
|Option|Purpose|  
|---|---|  
|[:::no-loc text="\-linkresource":::](linkresource.md)|Creates a link to a managed resource.|  
|[:::no-loc text="\-resource":::](resource.md)|Embeds a managed resource in an assembly.|  
|[:::no-loc text="\-win32icon":::](win32icon.md)|Inserts an .ico file into the output file.|  
|[:::no-loc text="\-win32resource":::](win32resource.md)|Inserts a Win32 resource into the output file.|  
  
## Miscellaneous  
  
|Option|Purpose|  
|---|---|  
|[:::no-loc text="\@ \(Specify Response File\)":::](specify-response-file.md)|Specifies a response file.|  
|[:::no-loc text="\-baseaddress":::](baseaddress.md)|Specifies the base address of a DLL.|  
|[:::no-loc text="\-codepage":::](codepage.md)|Specifies the code page to use for all source code files in the compilation.|  
|[:::no-loc text="\-errorreport":::](errorreport.md)|Specifies how the Visual Basic compiler should report internal compiler errors.|  
|[:::no-loc text="\-highentropyva":::](highentropyva.md)|Tells the Windows kernel whether a particular executable supports high entropy Address Space Layout Randomization (ASLR).|  
|[:::no-loc text="\-main":::](main.md)|Specifies the class that contains the `Sub Main` procedure to use at startup.|  
|[:::no-loc text="\-noconfig":::](noconfig.md)|Do not compile with Vbc.rsp|  
|[:::no-loc text="\-nostdlib":::](nostdlib.md)|Causes the compiler not to reference the standard libraries.|  
|[:::no-loc text="\-nowin32manifest":::](nowin32manifest.md)|Instructs the compiler not to embed any application manifest into the executable file.|  
|[:::no-loc text="\-pathmap":::](pathmap.md)|Specifies how to map physical paths to source path names output by the compiler.|
|[:::no-loc text="\-platform":::](platform.md)|Specifies the processor platform the compiler targets for the output file.|  
|[:::no-loc text="\-recurse":::](recurse.md)|Searches subdirectories for source files to compile.|  
|[:::no-loc text="\-rootnamespace":::](rootnamespace.md)|Specifies a namespace for all type declarations.|  
|[:::no-loc text="\-sdkpath":::](sdkpath.md)|Specifies the location of Mscorlib.dll and Microsoft.VisualBasic.dll.|  
|[:::no-loc text="\-vbruntime":::](vbruntime.md)|Specifies that the compiler should compile without a reference to the Visual Basic Runtime Library, or with a reference to a specific runtime library.|  
|[:::no-loc text="\-win32manifest":::](win32manifest.md)|Identifies a user-defined Win32 application manifest file to be embedded into a project's portable executable (PE) file.|  
|`-parallel[+&#124;-]`|Specifies whether to use concurrent build (+).|  
|`-checksumalgorithm:<alg>`|Specify the algorithm for calculating the source file checksum stored in PDB.  Supported values are: SHA1 (default) or SHA256. <br>Due to collision problems with SHA1, Microsoft recommends SHA256 or better.|  
  
## See also

- [Visual Basic Compiler Options Listed Alphabetically](compiler-options-listed-alphabetically.md)
- [Manage project and solution properties](/visualstudio/ide/managing-project-and-solution-properties)
