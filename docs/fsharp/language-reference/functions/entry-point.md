---
title: Console Applications and Explicit Entry Points
description: Learn how to set the entry point to an F# program that is compiled as an executable file, where execution formally starts.
ms.date: 10/29/2021
---
# Console Applications

In this article, you learn how to structure an F# console application.

## Implicit Entry Point

By default, F# applications use an implicit entry point. For example, for the following program, the entry point is implicit and, when the program is run, the code executes from the first line to the last:

```fsharp
open System

let printSomeText() =
    let text = "Hello" + "World"
    printfn $"text = {text}"

let showCommandLineArgs() =
    for arg in Environment.GetCommandLineArgs() do
        printfn $"arg = {arg}"

printSomeText()
showCommandLineArgs()
exit 100
```

## Explicit Entry Point

If you want, you can use an explicit entry point. This is usually done for one or all of the following reasons:

* You prefer to access the command-line arguments via an argument passed to a function, rather than using `System.Environment.GetCommandLineArgs()`.

* You want to return an error code via a return result, rather than using `exit`.

* You want to unit test the code in the last file of your console application.

The following example illustrates a simple `main` function with an explicit entry point.

[!code-fsharp[Main](~/samples/snippets/fsharp/entry-point/snippet501.fs)]

When this code is executed with the command line `EntryPoint.exe 1 2 3`, the output is as follows.

```console
Arguments passed to function : [|"1"; "2"; "3"|]
```

## Syntax

```fsharp
[<EntryPoint>]
let-function-binding
```

## Remarks

In the previous syntax, *let-function-binding* is the definition of a function in a `let` binding.

The entry point to a program that is compiled as an executable file is where execution formally starts. You specify the entry point to an F# application by applying the `EntryPoint` attribute to the program's `main` function. This function (created by using a `let` binding) must be the last function in the last compiled file. The last compiled file is the last file in the project or the last file that is passed to the command line.

The entry point function has type `string array -> int`. The arguments provided on the command line are passed to the `main` function in the array of strings. The first element of the array is the first argument; the name of the executable file is not included in the array, as it is in some other languages. The return value is used as the exit code for the process. Zero usually indicates success; nonzero values indicate an error. There is no convention for the specific meaning of nonzero return codes; the meanings of the return codes are application-specific.

## See also

- [Tour of F#](../../tour.md)
- [Functions](index.md)
- [let Bindings](let-bindings.md)
