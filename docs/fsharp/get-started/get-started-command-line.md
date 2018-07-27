---
title: Get started with F# with command-line tools
description: Learn how to build a simple multi-project solution on F# using the .NET Core CLI on any operating system (Windows, macOs or Linux).
ms.date: 03/26/2018
---
# Get started with F# with the .NET Core CLI

This article covers how you can get started with F# on any operating system (Windows, macOS, or Linux) with the .NET Core CLI. It goes through building a multi-project solution with a class library that is called by a console application.

## Prerequisites

To begin, you must install the latest [.NET Core SDK](https://www.microsoft.com/net/download/).

This article assumes that you know how to use a command line and have a preferred text editor. If you don't already use it, [Visual Studio Code](get-started-vscode.md) is a great option as a text editor for F#.

## Build a simple multi-project solution

Open a command prompt/terminal and use the [dotnet new](../../core/tools/dotnet-new.md) command to create new solution file called `FSNetCore`:

```console
dotnet new sln -o FSNetCore
```

The following directory structure is produced after running the previous command:

```console
FSNetCore
    ├── FSNetCore.sln
```

### Write a class library

Change directories to *FSNetCore*.

Use the `dotnet new` command, create a class library project in the **src** folder named Library.

```console
dotnet new lib -lang F# -o src/Library
```

The following directory structure is produced after running the previous command:

```console
└── FSNetCore
    ├── FSNetCore.sln
    └── src
        └── Library
            ├── Library.fs
            └── Library.fsproj
```

Replace the contents of `Library.fs` with the following code:

```fsharp
module Library

open Newtonsoft.Json

let getJsonNetJson value =
    sprintf "I used to be %s but now I'm %s thanks to JSON.NET!" value (JsonConvert.SerializeObject(value))
```

Add the Newtonsoft.Json NuGet package to the Library project.

```console
dotnet add src/Library/Library.fsproj package Newtonsoft.Json
```

Add the `Library` project to the `FSNetCore` solution using the [dotnet sln add](../../core/tools/dotnet-sln.md) command:

```console
dotnet sln add src/Library/Library.fsproj
```

Run `dotnet build` to build the project. Unresolved dependencies will be restored when building.

### Write a console application that consumes the class library

Use the `dotnet new` command, create a console application in the **src** folder named App.

```console
dotnet new console -lang F# -o src/App
```

The following directory structure is produced after running the previous command:

```console
└── FSNetCore
    ├── FSNetCore.sln
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
let main argv =
    printfn "Nice command-line arguments! Here's what JSON.NET has to say about them:"

    argv
    |> Array.map getJsonNetJson
    |> Array.iter (printfn "%s")

    0 // return an integer exit code
```

Add a reference to the `Library` project using [dotnet add reference](../../core/tools/dotnet-add-reference.md).

```console
dotnet add src/App/App.fsproj reference src/Library/Library.fsproj
```

Add the `App` project to the `FSNetCore` solution using the `dotnet sln add` command:

```console
dotnet sln add src/App/App.fsproj
```

Restore the NuGet dependencies, `dotnet restore` ([see note](#dotnet-restore-note)) and run `dotnet build` to build the project.

Change directory to the `src/App` console project and run the project passing `Hello World` as arguments:

```console
cd src/App
dotnet run Hello World
```

You should see the following results:

```console
Nice command-line arguments! Here's what JSON.NET has to say about them:

I used to be Hello but now I'm ""Hello"" thanks to JSON.NET!
I used to be World but now I'm ""World"" thanks to JSON.NET!
```

## Next steps

Next, check out the [Tour of F#](../tour.md) to learn more about different F# features.