---
title: Compiler Options (F#)
description: Use F# compiler command-line options to control the compilation of your F# apps and libraries.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: c797cf0b-5953-4053-8626-0558e9eaf10f 
---

# Compiler Options

This topic describes compiler command-line options for the F# compiler, fsc.exe. The compilation environment can also be controlled by setting the project properties.


## Compiler Options Listed Alphabetically
The following table shows compiler options listed alphabetically. Some of the F# compiler options are similar to the C# compiler options. If that is the case, a link to the C# compiler options topic is provided.



|Compiler Option|Description|
|---------------|-----------|
|**-a****&lt;output-filename&gt;**|Generates a library and specifies its filename. This option is a short form of **--target:library****&lt;filename&gt;**.|
|**--baseaddress:&lt;string&gt;**|Specifies the base address of the library to be built.<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;baseaddress &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/2fdbz5xd.aspx).|
|**--codepage:&lt;int&gt;**|Specifies the codepage used to read source files.<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;codepage &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/w0kyekyh.aspx).|
|**--consolecolors**|Specifies that errors and warnings use color-coded text on the console.|
|**--crossoptimize**[**+**&#124;**-**]|Enables or disables cross-module optimizations.|
|**--delaysign**[**+**&#124;**-**]|Delay-signs the assembly using only the public portion of the strong name key.<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;delaysign &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/ta1sxwy8.aspx).|
|**--checked**[**+**&#124;**-**]|Enables or disables the generation of overflow checks.<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;checked &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/h25wtyxf.aspx).|
|**--debug**[**+**&#124;**-**]<br /><br />**-g**[**+**&#124;**-**]<br /><br />**--debug**:[**full**&#124;**pdbonly**]<br /><br />**-g:** [**full**&#124;**pdbonly**]|Enables or disables the generation of debug information, or specifies the type of debug information to generate. The default is full, which allows attaching to a running program. Choose **pdbonly** to get limited debugging information stored in a pdb (program database) file.<br /><br />Equivalent to the C# compiler option of the same name. For more information, see<br /><br />[&#47;debug &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/8cw0bt21.aspx).|
|**--define:&lt;string&gt;**<br /><br />**-d:&lt;string&gt;**|Defines a symbol for use in conditional compilation.|
|**--deterministic**[**+**&#124;**-**]|Produce a deterministic assembly (including module version GUID and timestamp).  This cannot be used with wildcard version numbers, and only supports embedded and portable debugging types|
|**--doc:&lt;xmldoc-filename&gt;**|Instructs the compiler to generate XML documentation comments to the file specified. For more information, see [XML Documentation](xml-documentation.md).<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;doc &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/3260k4x7.aspx).|
|**--fullpaths**|Instructs the compiler to generate fully qualified paths.<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;fullpaths &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/d315xc66.aspx).|
|**--help**<br /><br />**-?**|Displays usage information, including a brief description of all the compiler options.|
|**--highentropyva**[**+**&#124;**-**]|Enable or disable high-entropy address space layout randomization (ASLR), an enhanced security feature. The OS randomizes the locations in memory where infrastructure for applications (such as the stack and heap) are loaded. If you enable this option, operating systems can use this randomization to use the full 64-bit address-space on a 64-bit machine.|
|**--keycontainer:&lt;string&gt;**|Specifies a strong name key container.|
|**--keyfile:&lt;filename&gt;**|Specifies the name of a public key file for signing the generated assembly.|
|**--lib:&lt;folder-name&gt;**<br /><br />**-I:&lt;folder-name&gt;**|Specifies a directory to be searched for assemblies that are referenced.<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;lib &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/s5bac5fx.aspx).|
|**--linkresource**:**&lt;resource-info&gt;**|Links a specified resource to the assembly. The format of resource-info is *filename*[,*name*[,*public*&#124;*private*]]<br /><br />Linking a single resource with this option is an alternative to embedding an entire resource file with the **--resource** option.<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;linkresource &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/xawyf94k.aspx).|
|**--mlcompatibility**|Ignores warnings that appear when you use features that are designed for compatibility with other versions of ML.|
|**--noframework**|Disables the default reference to the .NET Framework assembly.|
|**--nointerfacedata**|Instructs the compiler to omit the resource it normally adds to an assembly that includes F#-specific metadata.|
|**--nologo**|Doesn't show the banner text when launching the compiler.|
|**--nooptimizationdata**|Instructs the compiler to only include optimization essential for implementing inlined constructs. Inhibits cross-module inlining but improves binary compatibility.|
|**--nowin32manifest**|Instructs the compiler to omit the default Win32 manifest.|
|**--nowarn:&lt;int-list&gt;**|Disables specific warnings listed by number. Separate each warning number by a comma. You can discover the warning number for any warning from the compilation output.<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;nowarn &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/7f28x9z3.aspx).|
|**--optimize**[**+**&#124;**-**]**[&lt;string-list&gt;]**<br /><br />**-O[+&#124;-] [&lt;string-list&gt;]**|Enables or disables optimizations. Some optimization options can be disabled or enabled selectively by listing them. These are: **nojitoptimize**, **nojittracking**, **nolocaloptimize**, **nocrossoptimize**, **notailcalls**.|
|**--out:&lt;output-filename&gt;**<br /><br />**-o:&lt;output-filename&gt;**|Specifies the name of the compiled assembly or module.<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;out &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/bw3t50f3.aspx).|
|**--pdb:&lt;pdb-filename&gt;**|Names the output debug PDB (program database) file. This option only applies when **--debug** is also enabled.<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;pdb &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/ms228625.aspx).|
|**--platform:&lt;platform-name&gt;**|Specifies that the generated code will only run on the specified platform (**x86**, **Itanium**, or **x64**), or, if the platform-name **anycpu** is chosen, specifies that the generated code can run on any platform.<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;platform &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/zekwfyz4.aspx).|
|**--preferreduilang:&lt;lang&gt;**| Specifies the preferred output language culture name (for example,  es-ES, ja-JP). |
|**--quotations-debug**|Specifies that extra debugging information should be emitted for expressions that are derived from F# quotation literals and reflected definitions. The debug information is added to the custom attributes of an F# expression tree node. See [Code Quotations](code-quotations.md) and [Expr.CustomAttributes](https://msdn.microsoft.com/library/eb89943f-5f5b-474e-b125-030ca412edb3).|
|**--reference:&lt;assembly-filename&gt;**<br /><br />**-r** &lt;**assembly-filename&gt;**|Makes code from an F# or .NET Framework assembly available to the code being compiled.<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;reference &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/yabyz3h4.aspx).|
|**--resource:&lt;resource-filename&gt;**|Embeds a managed resource file into the generated assembly.<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;resource &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/c0tyye07.aspx).|
|**--sig**:&lt;**signature-filename&gt;**|Generates a signature file based on the generated assembly. For more information about signature files, see [Signatures](signatures.md).|
|**--simpleresolution**|Specifies that assembly references should be resolved using directory-based Mono rules rather than MSBuild resolution. The default is to use MSBuild resolution except when running under Mono.|
|**--standalone**|Specifies to produce an assembly that contains all of its dependencies so that it runs by itself without the need for additional assemblies, such as the F# library.|
|**--staticlink:&lt;assembly-name**&gt;|Statically links the given assembly and all referenced DLLs that depend on this assembly. Use the assembly name, not the DLL name.|
|**--subsystemversion**|Specifies the version of the OS subsystem to be used by the generated executable. Use 6.02 for Windows 8.1, 6.01 for Windows 7, 6.00 for Windows Vista. This option only applies to executables, not DLLs, and need only be used if your application depends on specific security features available only on certain versions of the OS. If this option is used, and a user attempts to execute your application on a lower version of the OS, it will fail with an error message.|
|**--tailcalls**[**+**&#124;**-**]|Enables or disables the use of the tail IL instruction, which causes the stack frame to be reused for tail recursive functions. This option is enabled by default.|
|**--target**:[**exe** &#124; **winexe** &#124; **library** &#124; **module** ] **&lt;output-filename&gt;**|Specifies the type and file name of the generated compiled code.<ul><li>**exe** means a console application.<br /></li><li>**winexe** means a Windows application, which differs from the console application in that it does not have standard input/output streams (stdin, stdout, and stderr) defined.<br /></li><li>**library** is an assembly without an entry point.<br /></li><li>**module** is a .NET Framework module (.netmodule), which can later be combined with other modules into an assembly.<br /></li><ul/>This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;target &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/6h25dztx.aspx).|
|**--times**|Displays timing information for compilation.|
|**--utf8output**|Enables printing compiler output in the UTF-8 encoding.|
|**--warn:&lt;warning-level&gt;**|Sets a warning level (0 to 5). The default level is 3. Each warning is given a level based on its severity. Level 5 gives more, but less severe, warnings than level 1.<br /><br />Level 5 warnings are: 21 (recursive use checked at runtime), 22 (**let rec** evaluated out of order), 45 (full abstraction), and 52 (defensive copy). All other warnings are level 2.<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;warn &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/13b90fz7.aspx).|
|**--warnon:&lt;int-list&gt;**|Enable specific warnings that might be off by default or disabled by another command line option. In F# 3.0, only the 1182 (unused variables) warning is off by default.|
|**--warnaserror**[**+**&#124;**-**] [**&lt;int-list&gt;**]|Enables or disables the option to report warnings as errors. You can provide specific warning numbers to be disabled or enabled. Options later in the command line override options earlier in the command line. For example, to specify the warnings that you don't want reported as errors, specify **--warnaserror+ --warnaserror-:&lt;int-list&gt;**.<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;warnaserror &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/406xhdz3.aspx).|
|**--win32manifest:manifest-filename**|Adds a Win32 manifest file to the compilation. This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;win32manifest &#40;C&#35; Compiler Options&#41;](https://msdn.microsoft.com/library/bb545961.aspx).|
|**--win32res:resource-filename**|Adds a Win32 resource file to the compilation.<br /><br />This compiler option is equivalent to the C# compiler option of the same name. For more information, see [&#47;win32res (&#40;C&#35); Compiler Options&#41;](https://msdn.microsoft.com/library/8f2f5x2e.aspx).|

## Related Topics


|Title|Description|
|-----|-----------|
|[F# Interactive Options](fsharp-interactive-options.md)|Describes command-line options supported by the F# interpreter, fsi.exe.|
|[Project Properties Reference](/visualstudio/ide/reference/project-properties-reference)|Describes the UI for projects, including project property pages that provide build options.|
