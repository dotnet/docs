---
title: F# Interactive (fsi.exe) Reference
description: Learn how F# Interactive (fsi.exe) is used to run F# code interactively at the console or to execute F# scripts.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 36af8d1b-dc08-4a37-9497-d23c0a0ac11c 
---

# Interactive Programming with F# #

> [!NOTE]
This article currently describes the experience for Windows only.  It will be rewritten.

> [!NOTE]
The API reference link will take you to MSDN.  The docs.microsoft.com API reference is not complete.

F# Interactive (fsi.exe) is used to run F# code interactively at the console, or to execute F# scripts. In other words, F# interactive executes a REPL (Read, Evaluate, Print Loop) for the F# language.

To run F# Interactive from the console, run fsi.exe.  You will find fsi.exe in "c:\Program Files (x86)\Microsoft SDKs\F#\<version>\Framework\<version>\". For information about command line options available, see [F# Interactive Options](../../language-reference/fsharp-interactive-options.md).

To run F# Interactive through Visual Studio, you can click the appropriate toolbar button labeled **F# Interactive**, or use the keys **Ctrl+Alt+F**. Doing this will open the interactive window, a tool window running an F# Interactive session. You can also select some code that you want to run in the interactive window and hit the key combination **ALT+ENTER**. F# Interactive starts in a tool window labeled **F# Interactive**. When you use this key combination, make sure that the editor window has the focus.

Whether you are using the console or Visual Studio, a command prompt appears and the interpreter awaits your input. You can enter code just as you would in a code file. To compile and execute the code, enter two semicolons (**;;**) to terminate a line or several lines of input.

F# Interactive attempts to compile the code and, if successful, it executes the code and prints the signature of the types and values that it compiled. If errors occur, the interpreter prints the error messages.

Code entered in the same session has access to any constructs entered previously, so you can build up programs. An extensive buffer in the tool window allows you to copy the code into a file if needed.

When run in Visual Studio, F# Interactive runs independently of your project, so, for example, you cannot use constructs defined in your project in F# Interactive unless you copy the code for the function into the interactive window.

If you have a project open that references some libraries, you can reference these in F# Interactive through **Solution Explorer**. To reference a library in F# Interactive, expand the **References** node, open the shortcut menu for the library, and choose **Send to F# Interactive**.

You can control the F# Interactive command line arguments (options) by adjusting the settings. On the **Tools** menu, select **Options...**, and then expand **F# Tools**. The two settings that you can change are the F# Interactive options and the **64-bit F# Interactive** setting, which is relevant only if you are running F# Interactive on a 64-bit machine. This setting determines whether you want to run the dedicated 64-bit version of fsi.exe or fsianycpu.exe, which uses the machine architecture to determine whether to run as a 32-bit or 64-bit process.


## Scripting with F# #
Scripts use the file extension **.fsx** or **.fsscript**. Instead of compiling source code and then later running the compiled assembly, you can just run **fsi.exe** and specify the filename of the script of F# source code, and F# interactive reads the code and executes it in real time.


## Differences Between the Interactive, Scripting and Compiled Environments
When you are compiling code in F# Interactive, whether you are running interactively or running a script, the symbol **INTERACTIVE** is defined. When you are compiling code in the compiler, the symbol **COMPILED** is defined. Thus, if code needs to be different in compiled and interactive modes, you can use preprocessor directives for conditional compilation to determine which to use.

Some directives are available when you are executing scripts in F# Interactive that are not available when you are executing the compiler. The following table summarizes directives that are available when you are using F# Interactive.

|Directive|Description|
|---------|-----------|
|**#help**|Displays information about available directives.|
|**#I**|Specifies an assembly search path in quotation marks.|
|**#load**|Reads a source file, compiles it, and runs it.|
|**#quit**|Terminates an F# Interactive session.|
|**#r**|References an assembly.|
|**#time ["on"&#124;"off"]**|By itself, **#time** toggles whether to display performance information. When it is enabled, F# Interactive measures real time, CPU time, and garbage collection information for each section of code that is interpreted and executed.|

When you specify files or paths in F# Interactive, a string literal is expected. Therefore, files and paths must be in quotation marks, and the usual escape characters apply. Also, you can use the @ character to cause F# Interactive to interpret a string that contains a path as a verbatim string. This causes F# Interactive to ignore any escape characters.

One of the differences between compiled and interactive mode is the way you access command line arguments. In compiled mode, use **System.Environment.GetCommandLineArgs**. In scripts, use **fsi.CommandLineArgs**.

The following code illustrates how to create a function that reads the command line arguments in a script and also demonstrates how to reference another assembly from a script. The first code file, **MyAssembly.fs**, is the code for the assembly being referenced. Compile this file with the command line: **fsc -a MyAssembly.fs** and then execute the second file as a script with the command line: **fsi --exec file1.fsx** test

```fsharp
// MyAssembly.fs
module MyAssembly
let myFunction x y = x + 2 * y
```

```fsharp
// file1.fsx
#r "MyAssembly.dll"

printfn "Command line arguments: "

for arg in fsi.CommandLineArgs do
    printfn "%s" arg

printfn "%A" (MyAssembly.myFunction 10 40)
```

The output is as follows:

```
Command line arguments: 
file1.fsx
test
60
```

## Related Topics

|Title|Description|
|-----|-----------|
|[F# Interactive Options](../../language-reference/fsharp-interactive-options.md)|Describes command-line syntax and options for the F# Interactive, fsi.exe.|
|[F# Interactive Library Reference](https://msdn.microsoft.com/visualfsharpdocs/conceptual/fsharp-interactive-library-reference)|Describes library functionality available when executing code in F# interactive.|
