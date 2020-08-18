---
title: Interactive options
description: Learn about the command-line options supported by F# Interactive, fsi.exe.
ms.date: 08/15/2020
---
# F# Interactive options

This article describes the command-line options supported by F# Interactive, `fsi.exe`. F# Interactive accepts many of the same command-line options as the F# compiler, but also accepts some additional options.

## Use F# Interactive for scripting

F# Interactive, `dotnet fsi`, can be launched interactively, or it can be launched from the command line to run a script. The command-line syntax is

```dotnetcli
dotnet fsi [options] [ script-file [arguments] ]
```

The file extension for F# script files is `.fsx`.

## Table of F# Interactive Options

The following table summarizes the options supported by F# Interactive. You can set these options on the command line or through the Visual Studio IDE. To set these options in the Visual Studio IDE, open the **Tools** menu, select **Options**, expand the **F# Tools** node, and then select **F# Interactive**.

Where lists appear in F# Interactive option arguments, list elements are separated by semicolons (`;`).

|Option|Description|
|------|-----------|
|**--**|Used to instruct F# Interactive to treat remaining arguments as command-line arguments to the F# program or script, which you can access in code by using the list **fsi.CommandLineArgs**.|
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
|**--help**<br /><br />**-?**|Used to display the command-line syntax and a brief description of each option.|
|**--lib:&lt;folder-list&gt;**<br /><br />**-I:&lt;folder-list&gt;**|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--load:&lt;filename&gt;**|Compiles the given source code at startup and loads the compiled F# constructs into the session.|
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
|**--tailcalls**[**+**&#124;**-**]|Enable or disable the use of the tail IL instruction, which causes the stack frame to be reused for tail recursive functions. This option is enabled by default.|
|**--targetprofile:&lt;string&gt;**|Specifies target framework profile of this assembly. Valid values are `mscorlib`, `netcore`, or `netstandard`. The default is `mscorlib`.|
|**--use:&lt;filename&gt;**|Tells the interpreter to use the given file on startup as initial input.|
|**--utf8output**|Same as the fsc.exe compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--warn:&lt;warning-level&gt;**|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--warnaserror**[**+**&#124;**-**]|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|
|**--warnaserror**[**+**&#124;**-**]:**&lt;int-list&gt;**|Same as the **fsc.exe** compiler option. For more information, see [Compiler Options](compiler-options.md).|

## F# Interactive structured printing

F# Interactive (`dotnet fsi`) uses an extended version of [structured plain text formatting](plaintext-formatting.md) to
report values.

1. All features of `%A` plain text formatting are supported, and some are additionally customizable.

2. Printing is colorized if colors are supported by the output console.

3. A limit is placed on the length of strings shown, unless you explicitly evaluate that string.

4. A set of user-definable settings is available via the `fsi` object.

The available settings to customize plain text printing for reported values are:

```fsharp
open System.Globalization

fsi.FormatProvider <- CultureInfo("de-DE")  // control the default culture for primitives

fsi.PrintWidth <- 120        // Control the width used for structured printing

fsi.PrintDepth <- 10         // Control the maximum depth of nested printing

fsi.PrintLength <- 10        // Control the length of lists and arrays

fsi.PrintSize <- 100         // Control the maximum overall object count

fsi.ShowProperties <- false  // Control whether properties of .NET objects are shown by default

fsi.ShowIEnumerable <- false // Control whether sequence values are expanded by default

fsi.ShowDeclarationValues <- false // Control whether values are shown for declaration outputs
```

### Customize with `AddPrinter` and `AddPrintTransformer`

Printing in F# Interactive outputs can be customized by using `fsi.AddPrinter` and `fsi.AddPrintTransformer`.
The first function gives text to replace the printing of an object. The second function returns a surrogate object to display
instead. For example, consider the following F# code:

```fsharp
open System

fsi.AddPrinter<DateTime>(fun dt -> dt.ToString("s"))

type DateAndLabel =
    { Date: DateTime
      Label: string  }

let newYearsDay1999 =
    { Date = DateTime(1999, 1, 1)
      Label = "New Year" }
```

If you execute the example in F# Interactive, it outputs based on the formatting option set. In this case, it affects the formatting of date and time:

```console
type DateAndLabel =
  { Date: DateTime
    Label: string }
val newYearsDay1999 : DateAndLabel = { Date = 1999-01-01T00:00:00
                                       Label = "New Year" }
```

`fsi.AddPrintTransformer` can be used to give a surrogate object for printing:

```fsharp
type MyList(values: int list) =
    member _.Values = values

fsi.AddPrintTransformer(fun (x:MyList) -> box x.Values)

let x = MyList([1..10])
```

This outputs:

```console
val x : MyList = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
```

If the transformer function passed to `fsi.AddPrintTransformer` returns `null`, then the print transformer is ignored.
This can be used to filter any input value by starting with type `obj`.  For example:

```fsharp
fsi.AddPrintTransformer(fun (x:obj) ->
    match x with
    | :? string as s when s = "beep" -> box ["quack"; "quack"; "quack"]
    | _ -> null)

let y = "beep"
```

This outputs:

```console
val y : string = ["quack"; "quack"; "quack"]
```

## Related topics

|Title|Description|
|-----|-----------|
|[Compiler Options](compiler-options.md)|Describes command-line options available for the F# compiler, **fsc.exe**.|
