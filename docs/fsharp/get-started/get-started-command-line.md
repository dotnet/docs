---
title: Get started with F# with command-line tools
description: Learn how to build a simple multi-project solution on F# using the .NET CLI on any operating system (Windows, macOS, or Linux).
ms.date: 10/29/2021
---
# Get started with F# with the .NET CLI

This article covers how you can get started with F# on any operating system (Windows, macOS, or Linux) with the .NET CLI. It goes through building a multi-project solution with a class library that is called by a console application.

## Prerequisites

To begin, you must install the latest [.NET SDK](https://dotnet.microsoft.com/download).

This article assumes that you know how to use a command line and have a preferred text editor. If you don't already use it, [Visual Studio Code](get-started-vscode.md) is a great option as a text editor for F#.

## Build a simple multi-project solution

Open a command prompt/terminal and use the [dotnet new](../../core/tools/dotnet-new.md) command to create new solution file called `FSharpSample`:

```dotnetcli
dotnet new sln -o FSharpSample
```

The following directory structure is produced after running the previous command:

```console
FSharpSample
    ├── FSharpSample.sln
```

### Write a class library

Change directories to *FSharpSample*.

Use the `dotnet new` command, create a class library project in the **src** folder named Library.

```dotnetcli
dotnet new classlib -lang "F#" -o src/Library
```

The following directory structure is produced after running the previous command:

```console
└── FSharpSample
    ├── FSharpSample.sln
    └── src
        └── Library
            ├── Library.fs
            └── Library.fsproj
```

Replace the contents of `Library.fs` with the following code:

```fsharp
module Library

open System.Text.Json

let getJson value =
    let json = JsonSerializer.Serialize(value)
    value, json
```

Add the `Library` project to the `FSharpSample` solution using the [dotnet sln add](../../core/tools/dotnet-sln.md) command:

```dotnetcli
dotnet sln add src/Library/Library.fsproj
```

Run `dotnet build` to build the project. Unresolved dependencies will be restored when building.

### Write a console application that consumes the class library

Use the `dotnet new` command, create a console application in the **src** folder named App.

```dotnetcli
dotnet new console -lang "F#" -o src/App
```

The following directory structure is produced after running the previous command:

```console
└── FSharpSample
    ├── FSharpSample.sln
    └── src
        ├── App
        │   ├── App.fsproj
        │   ├── Program.fs
        └── Library
            ├── Library.fs
            └── Library.fsproj
```

Replace the contents of the `Program.fs` file with the following code:

```fsharp
open System
open Library

[<EntryPoint>]
let main args =
    printfn "Nice command-line arguments! Here's what System.Text.Json has to say about them:"

    let value, json = getJson {| args=args; year=System.DateTime.Now.Year |}
    printfn $"Input: %0A{value}"
    printfn $"Output: %s{json}"

    0 // return an integer exit code
```

Add a reference to the `Library` project using [dotnet add reference](../../core/tools/dotnet-add-reference.md).

```dotnetcli
dotnet add src/App/App.fsproj reference src/Library/Library.fsproj
```

Add the `App` project to the `FSharpSample` solution using the `dotnet sln add` command:

```dotnetcli
dotnet sln add src/App/App.fsproj
```

Restore the NuGet dependencies, `dotnet restore` and run `dotnet build` to build the project.

Change directory to the `src/App` console project and run the project passing `Hello World` as arguments:

```dotnetcli
cd src/App
dotnet run Hello World
```

You should see the following results:

```console
Nice command-line arguments! Here's what System.Text.Json has to say about them:
Input: { args = [|"Hello"; "World"|] year = 2021 }
Output: {"args":["Hello","World"],"year":2021}
```

## Next steps

Next, check out the [Tour of F#](../tour.md) to learn more about different F# features.
