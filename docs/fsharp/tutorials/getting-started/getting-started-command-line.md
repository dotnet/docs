---
title: Getting started with F# with command-line tools
description: Learn how to use F# with the cross-platform .NET CLI.
keywords: visual f#, f#, functional programming, .NET, .NET Core
author: cartermp
ms.author: phcart
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 615db1ec-6ef3-4de2-bae6-4586affa9771
---

# Getting started with F# with command-line tools

This article covers how you can get started with using F# on .NET Core. It will go through building a multi-project solution with a Class Library that is called by a Console Application.

## Prerequisites

To begin, you must install the [.NET Core SDK 1.0.3 - (build 004769 or later)](https://dot.net/core). There is no need to uninstall a previous version of the .NET Core SDK, as it supports side-by-side installations.

This article assumes that you know how to use a command line and have a preferred text editor. If you don't already use it, [Visual Studio Code](https://code.visualstudio.com) is a great option as a text editor for F#. To get awesome features like IntelliSense, better syntax highlighting, and more, you can download the [Ionide Extension](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp).

## Building a Simple Multi-project Solution

Open a command prompt/terminal and use the `dotnet new` command to create new solution file called `FSNetCore`:

```
dotnet new sln -o FSNetCore
```

The folowing directory structure is produced as a result of the command completing:

```
FSNetCore
    ├── FSNetCore.sln
```

Change directories to *FSNetCore* and start adding projects to the solution folder.
 
### Writing a Class library

Use the `dotnet new` command, create a Class Library project in the **src** folder named Library. 

```bash
dotnet new classlib -lang F# -o src/Library 
```

The folowing directory structure is produced as a result of the command completing:

```
└── FSNetCore
    ├── FSNetCore.sln
    └── src
        └── Library
            ├── Library.fs
            └── Library.fsproj
```

Replace the contents of `Library.fs` with the following:

```fsharp
module Library

open Newtonsoft.Json

let getJsonNetJson value = 
    sprintf "I used to be %s but now I'm %s thanks to JSON.NET!" value  (JsonConvert.SerializeObject(value))
```

Add the Newtonsoft.Json NuGet package to the Library project.

```bash
dotnet add package Newtonsoft.Json
```

Add the `Library` project to the `FSNetCore` solution using the `dotnet sln add` command:

```bash
dotnet sln add src/Library/Library.fsproj
```

Restore the NuGet dependencies, `dotnet restore` and run `dotnet build` to build the project.

### Writing a Console Application which Consumes the Class Library

Use the `dotnet new` command, create a Console app in the **src** folder named App. 

```bash
dotnet new console -lang F# -o src/App 
```

The folowing directory structure is produced as a result of the command completing:

```
└── FSNetCore
    ├── FSNetCore.sln
    └── src
        ├── App
        │   ├── App.fsproj
        │   ├── Program.fs
        └── Library
            ├── Library.fs
            └── Library.fsproj
```

Change `Program.fs` to:

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

Change directories to the *App* console project and add a reference to the `Library` project using `dotnet add reference`.

```bash
dotnet add reference ../Library/Library.fsproj
```
Add the `Library` project to the `FSNetCore` solution using the `dotnet sln add` command:

```bash
dotnet sln add src/App/App.fsproj
```

Restore the NuGet dependencies, `dotnet restore` and run `dotnet build` to build the project.

Run the project passing `Hello World` as arguments.

```bash
dotnet run Hello World
``` 

You should see the following results:

```
Nice command-line arguments! Here's what JSON.NET has to say about them:

I used to be Hello but now I'm ""Hello"" thanks to JSON.NET!
I used to be World but now I'm ""World"" thanks to JSON.NET!
```
