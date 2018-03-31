---
title: Get started with F# with command-line tools
description: Learn how to build a simple multi-project solution on F# using the .NET Core CLI on any operating system (Windows, macOs or Linux).
author: cartermp
ms.author: phcart
ms.date: 03/26/2018
ms.topic: article
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
---
# Get started with F# with the .NET Core CLI

This article covers how you can get started with F# on any operating system (Windows, macOS, or Linux) with the .NET Core CLI. It goes through building a multi-project solution with a class library that is called by a console application.

## Prerequisites

To begin, you must install the [.NET Core SDK 1.0 or later](https://www.microsoft.com/net/download/). There is no need to uninstall a previous version of the .NET Core SDK, as it supports side-by-side installations.

This article assumes that you know how to use a command line and have a preferred text editor. If you don't already use it, [Visual Studio Code](https://code.visualstudio.com) is a great option as a text editor for F#. To get awesome features like IntelliSense, better syntax highlighting, and more, you can download the [Ionide Extension](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp).

## Build a simple multi-project solution

Open a command prompt/terminal and use the [dotnet new](../../core/tools/dotnet-new.md) command to create new solution file called `FSNetCore`:

```
dotnet new sln -o FSNetCore
```

The following directory structure is produced after running the previous command:

```
FSNetCore
    ├── FSNetCore.sln
```

### Write a class library

Change directories to *FSNetCore*.

Use the `dotnet new` command, create a class library project in the **src** folder named Library.

```
dotnet new lib -lang F# -o src/Library
```

The following directory structure is produced after running the previous command:

```
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

```
dotnet add src/Library/Library.fsproj package Newtonsoft.Json
```

Add the `Library` project to the `FSNetCore` solution using the [dotnet sln add](../../core/tools/dotnet-sln.md) command:

```
dotnet sln add src/Library/Library.fsproj
```

Restore the NuGet dependencies using the `dotnet restore` command ([see note](#dotnet-restore-note)) and run `dotnet build` to build the project.

### Write a console application that consumes the class library

Use the `dotnet new` command, create a console application in the **src** folder named App.

```
dotnet new console -lang F# -o src/App
```

The following directory structure is produced after running the previous command:

```
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

```
dotnet add src/App/App.fsproj reference src/Library/Library.fsproj
```

Add the `App` project to the `FSNetCore` solution using the `dotnet sln add` command:

```
dotnet sln add src/App/App.fsproj
```

Restore the NuGet dependencies, `dotnet restore` ([see note](#dotnet-restore-note)) and run `dotnet build` to build the project.

Change directory to the `src/App` console project and run the project passing `Hello World` as arguments:

```
cd src/App
dotnet run Hello World
```

You should see the following results:

```
Nice command-line arguments! Here's what JSON.NET has to say about them:

I used to be Hello but now I'm ""Hello"" thanks to JSON.NET!
I used to be World but now I'm ""World"" thanks to JSON.NET!
```

<a name="dotnet-restore-note"></a>
[!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]