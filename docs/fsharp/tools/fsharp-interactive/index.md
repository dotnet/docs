---
title: F# Interactive (dotnet) Reference
description: Learn how F# Interactive (dotnet fsi) is used to run F# code interactively at the console or to execute F# scripts.
ms.date: 11/29/2020
f1_keywords:
 - VS.ToolsOptionsPages.F#_Tools.F#_Interactive
---
# Interactive programming with F\#

F# Interactive (dotnet fsi) is used to run F# code interactively at the console, or to execute F# scripts. In other words, F# interactive executes a REPL (Read, Evaluate, Print Loop) for F#.

To run F# Interactive from the console, run `dotnet fsi`. You will find `dotnet fsi` in any .NET SDK.

For information about available command-line options, see [F# Interactive Options](../../language-reference/fsharp-interactive-options.md).

## Executing code directly in F# Interactive

Because F# Interactive is a REPL (read-eval-print loop), you can execute code interactively in it. Here is an example of an interactive session after executing `dotnet fsi` from the command line:

```console
Microsoft (R) F# Interactive version 11.0.0.0 for F# 5.0
Copyright (c) Microsoft Corporation. All Rights Reserved.

For help type #help;;

> let square x = x *  x;;
val square : x:int -> int

> square 12;;
val it : int = 144

> printfn "Hello, FSI!"
- ;;
Hello, FSI!
val it : unit = ()
```

You'll notice two main things:

1. All code must be terminated with a double semicolon (`;;`) to be evaluated
2. Code is evaluated and stored in an `it` value. You can reference `it` interactively.

F# Interactive also supports multi-line input. You just need to terminate your submission with a double semicolon (`;;`). Consider the following snippet that has been pasted into and evaluated by F# Interactive:

```console
> let getOddSquares xs =
-     xs
-     |> List.filter (fun x -> x % 2 <> 0)
-     |> List.map (fun x -> x * x)
-
- printfn "%A" (getOddSquares [1..10]);;
[1; 9; 25; 49; 81]
val getOddSquares : xs:int list -> int list
val it : unit = ()

>
```

The code's formatting is preserved, and there is a double semicolon (`;;`) terminating the input. F# Interactive then evaluated the code and printed the results!

## Scripting with F\#

Evaluating code interactively in F# Interactive can be a great learning tool, but you'll quickly find that it's not as productive as writing code in a normal editor. To support normal code editing, you can write F# scripts.

Scripts use the file extension **.fsx**. Instead of compiling source code and then later running the compiled assembly, you can just run **dotnet fsi** and specify the filename of the script of F# source code, and F# interactive reads the code and executes it in real time. For example, consider the following script called `Script.fsx`:

```fsharp
let getOddSquares xs =
    xs
    |> List.filter (fun x -> x % 2 <> 0)
    |> List.map (fun x -> x * x)

printfn "%A" (getOddSquares [1..10])
```

When this file is created in your machine, you can run it with `dotnet fsi` and see the output directly in your terminal window:

```console
dotnet fsi Script.fsx
[1; 9; 25; 49; 81]
```

F# scripting is natively supported in [Visual Studio](../../get-started/get-started-visual-studio.md), [Visual Studio Code](../../get-started/get-started-vscode.md), and [Visual Studio for Mac](../../get-started/get-started-with-visual-studio-for-mac.md).

## Referencing packages in F# Interactive

> [!NOTE]
> Package management system is extensible.

F# Interactive supports referencing NuGet packages with the `#r "nuget:"` syntax and an optional version:

```fsharp
#r "nuget: Newtonsoft.Json"
open Newtonsoft.Json

let data = {| Name = "Don Syme"; Occupation = "F# Creator" |}
JsonConvert.SerializeObject(data)
```

If a version is not specified, the highest available non-preview package is taken. To reference a specific version, introduce the version via a comma. This can be handy when referencing a preview version of a package. For example, consider this script using a preview version of [DiffSharp](https://diffsharp.github.io/):

```fsharp
#r "nuget: DiffSharp-lite, 1.0.0-preview-328097867"
open DiffSharp

// A 1D tensor
let t1 = dsharp.tensor [ 0.0 .. 0.2 .. 1.0 ]

// A 2x2 tensor
let t2 = dsharp.tensor [ [ 0; 1 ]; [ 2; 2 ] ]

// Define a scalar-to-scalar function
let f (x: Tensor) = sin (sqrt x)

printfn $"{f (dsharp.tensor 1.2)}"
```

### Specifying a package source

You can also specify a package source with the `#i` command. The following example specifies a remote and a local source:

```fsharp
#i "nuget: https://my-remote-package-source/index.json"
#i """nuget: C:\path\to\my\local\source"""
```

This will tell the resolution engine under the covers to also take into account the remote and/or local sources added to a script.

You can specify as many package references as you like in a script.

> [!NOTE]
> There's currently a limitation for scripts that use framework references (e.g.`Microsoft.NET.Sdk.Web` or  `Microsoft.NET.Sdk.WindowsDesktop`). Packages like Saturn, Giraffe, WinForms are not available. This is being tracked in issue [#9417](https://github.com/dotnet/fsharp/issues/9417).

## Referencing assemblies on disk with F# interactive

Alternatively, if you have an assembly on disk and wish to reference that in a script, you can use the `#r` syntax to specify an assembly. Consider the following code in a project compiled into `MyAssembly.dll`:

```fsharp
// MyAssembly.fs
module MyAssembly
let myFunction x y = x + 2 * y
```

Once compiled, you can reference it in a file called `Script.fsx` like so:

```fsharp
#r "path/to/MyAssembly.dll"

printfn $"{MyAssembly.myFunction 10 40}"
```

The output is as follows:

```console
dotnet fsi Script.fsx
90
```

You can specify as many assembly references as you like in a script.

## Loading other scripts

When scripting, it can often be helpful to use different scripts for different tasks. Sometimes you may want to reuse code from one script in another. Rather than copy-pasting its contents into your file, you can simply load and evaluate it with `#load`.

Consider the following `Script1.fsx`:

```fsharp
let square x = x * x
```

And the consuming file, `Script2.fsx`:

```fsharp
#load "Script1.fsx"
open Script1

printfn $"%d{square 12}"
```

You can evaluate `Script2.fsx` like so:

```console
dotnet fsi Script2.fsx
144
```

You can specify as many `#load` directives as you like in a script.

> [!NOTE]
> The `open Script1` declaration is required. This is because constructs in an F# script are compiled into a top-level module that is the name of the script file it is in. If the script file has a lowercase name such as `script3.fsx` then the implied module name is automatically capitalized, and you will need to use `open Script3`. If you would like a loadable-script to define constructs in a specific namespace of module you can include a namespace of module declaration, for example:
>
> ```fsharp
> module MyScriptLibrary
> ```

## Using the `fsi` object in F# code

F# scripts have access to a custom `fsi` object that represents the F# Interactive session. It allows you to customize things like output formatting. It is also how you can access command-line arguments.

The following example shows how to get and use command-line arguments:

```fsharp
let args = fsi.CommandLineArgs

for arg in args do
    printfn $"{arg}"
```

When evaluated, it prints all arguments. The first argument is always the name of the script that is evaluated:

```dotnet
dotnet fsi Script1.fsx hello world from fsi
Script1.fsx
hello
world
from
fsi
```

You can also use `System.Environment.GetCommandLineArgs()` to access the same arguments.

## F# Interactive directive reference

The `#r` and `#load` directives seen previously are only available in F# Interactive. There are several directives only available in F# Interactive:

|Directive|Description|
|---------|-----------|
|`#r "nuget:..."`|References a package from NuGet|
|`#r "assembly-name.dll"`|References an assembly on disk|
|`#load "file-name.fsx"`|Reads a source file, compiles it, and runs it.|
|`#help`|Displays information about available directives.|
|`#I`|Specifies an assembly search path in quotation marks.|
|`#quit`|Terminates an F# Interactive session.|
|`#time "on"` or `#time "off"`|By itself, `#time` toggles whether to display performance information. When it is `"on"`, F# Interactive measures real time, CPU time, and garbage collection information for each section of code that is interpreted and executed.|

When you specify files or paths in F# Interactive, a string literal is expected. Therefore, files and paths must be in quotation marks, and the usual escape characters apply. You can use the `@` character to cause F# Interactive to interpret a string that contains a path as a verbatim string. This causes F# Interactive to ignore any escape characters.

## Interactive and compiled preprocessor directives

When you compile code in F# Interactive, whether you are running interactively or running a script, the symbol **INTERACTIVE** is defined. When you compile code in the compiler, the symbol **COMPILED** is defined. Thus, if code needs to be different in compiled and interactive modes, you can use these preprocessor directives for conditional compilation to determine which to use. For example:

```fsharp
#if INTERACTIVE
// Some code that executes only in FSI
// ...
#endif
```

## Using F# Interactive in Visual Studio

To run F# Interactive through Visual Studio, you can click the appropriate toolbar button labeled **F# Interactive**, or use the keys **Ctrl+Alt+F**. Doing this will open the interactive window, a tool window running an F# Interactive session. You can also select some code that you want to run in the interactive window and hit the key combination **Alt+Enter**. F# Interactive starts in a tool window labeled **F# Interactive**. When you use this key combination, make sure that the editor window has the focus.

Whether you are using the console or Visual Studio, a command prompt appears and the interpreter awaits your input. You can enter code just as you would in a code file. To compile and execute the code, enter two semicolons (**;;**) to terminate a line or several lines of input.

F# Interactive attempts to compile the code and, if successful, it executes the code and prints the signature of the types and values that it compiled. If errors occur, the interpreter prints the error messages.

Code entered in the same session has access to any constructs entered previously, so you can build up programs. An extensive buffer in the tool window allows you to copy the code into a file if needed.

When run in Visual Studio, F# Interactive runs independently of your project, so, for example, you cannot use constructs defined in your project in F# Interactive unless you copy the code for the function into the interactive window.

You can control the F# Interactive command-line arguments (options) by adjusting the settings. On the **Tools** menu, select **Options...**, and then expand **F# Tools**. The two settings that you can change are the F# Interactive options and the **64-bit F# Interactive** setting, which is relevant only if you are running F# Interactive on a 64-bit machine. This setting determines whether you want to run the dedicated 64-bit version of **fsi.exe** or **fsianycpu.exe**, which uses the machine architecture to determine whether to run as a 32-bit or 64-bit process.

## Related articles

|Title|Description|
|-----|-----------|
|[F# Interactive Options](../../language-reference/fsharp-interactive-options.md)|Describes command-line syntax and options for the F# Interactive, fsi.exe.|
