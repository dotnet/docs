---
title: F# Interactive Options
description: Learn about the command-line options supported by F# Interactive, fsi.exe.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: f9f3e39b-ce6c-41ff-991f-0625f46441ae 
---

# F# Interactive Options

> [!NOTE]
This article currently describes the experience for Windows only.  It will be rewritten.

This topic describes the command-line options supported by F# Interactive, `fsi.exe`. F# Interactive accepts many of the same command line options as the F# compiler, but also accepts some additional options.

## Using F# Interactive for Scripting
F# Interactive, `fsi.exe`, can be launched interactively, or it can be launched from the command line to run a script. The command line syntax is

```
> fsi.exe [options] [ script-file [arguments] ]
```

The file extension for F# script files is `.fsx`.

## Table of F# Interactive Options
The following table summarizes the options supported by F# Interactive. You can set these options on the command-line or through the Visual Studio IDE. To set these options in the Visual Studio IDE, open the **Tools** menu, select **Options...**, then expand the **F# Tools** node and select **F# Interactive**.

Where lists appear in F# Interactive option arguments, list elements are separated by semicolons (`;`).

|Option|Description|
|------|-----------|
|**--**|Used to instruct F# Interactive to treat remaining arguments as command line arguments to the F# program or script, which you can access in code by using the list **fsi.CommandLineArgs**.|
|**--checked**[**+**&#124;**-**]|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--codepage:&lt;int&gt;**|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--consolecolors**[**+**&#124;**-**]|Outputs warning and error messages in color.|
|**--crossoptimize**[**+**&#124;**-**]|Enable or disable cross-module optimizations.|
|**--debug**[**+**&#124;**-**]<br /><br />**--debug:**[**full**&#124;**pdbonly**&#124;**portable**&#124;**embedded**]<br /><br />**-g**[**+**&#124;**-**]<br /><br />**-g:**[**full**&#124;**pdbonly**&#124;**portable**&#124;**embedded**]|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--define:&lt;string&gt;**|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--deterministic**[**+**&#124;**-**]|Produces a deterministic assembly (including module version GUID and timestamp).|
|**--exec**|Instructs F# interactive to exit after loading the files or running the script file given on the command line.|
|**--fullpaths**|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--gui**[**+**&#124;**-**]|Enables or disables the Windows Forms event loop. The default is enabled.|
|**--help**<br /><br />**-?**|Used to display the command line syntax and a brief description of each option.|
|**--lib:&lt;folder-list&gt;**<br /><br />**-I:&lt;folder-list&gt;**|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--load:&lt;filename&gt;**|Compiles the given source code at startup and loads the compiled F# constructs into the session. If the target source contains scripting directives such as **#use** or **#load**, then you must use **--use** or **#use** instead of **--load** or **#load**.|
|**--mlcompatibility**|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--noframework**|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md)|
|**--nologo**|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--nowarn:&lt;warning-list&gt;**|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--optimize**[**+**&#124;**-**]|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--preferreduilang:&lt;lang&gt;**| Specifies the preferred output language culture name (for example, es-ES, ja-JP). |
|**--quiet**|Suppress F# Interactive's output to the **stdout** stream.|
|**--quotations-debug**|Specifies that extra debugging information should be emitted for expressions that are derived from F# quotation literals and reflected definitions. The debug information is added to the custom attributes of an F# expression tree node. See [Code Quotations](code-quotations.md) and [Expr.CustomAttributes](https://msdn.microsoft.com/library/eb89943f-5f5b-474e-b125-030ca412edb3).|
|**--readline**[**+**&#124;**-**]|Enable or disable tab completion in interactive mode.|
|**--reference:&lt;filename&gt;**<br /><br />**-r:&lt;filename&gt;**|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--shadowcopyreferences**[**+**&#124;**-**]|Prevents references from being locked by the F# Interactive process.|
|**--simpleresolution**|Resolves assembly references using directory-based rules rather than MSBuild resolution.|
|**--tailcalls**[**+**&#124;**-**]|Enable or disable the use of the tail IL instruction, which causes the stack frame to be reused for tail recursive functions. This option is enabled by default.|
|**--targetprofile:&lt;string&gt;**|Specifies target framework profile of this assembly. Valid values are mscorlib, netcore or netstandard.  The default is mscorlib.|
|**--use:&lt;filename&gt;**|Tells the interpreter to use the given file on startup as initial input.|
|**--utf8output**|Same as the fsc.exe compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--warn:&lt;warning-level&gt;**|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--warnaserror**[**+**&#124;**-**]|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--warnaserror**[**+**&#124;**-**]:**&lt;int-list&gt;**|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|

## Related Topics

|Title|Description|
|-----|-----------|
|[Compiler Options](compiler-options.md)|Describes command line options available for the F# compiler, **fsc.exe**.|
