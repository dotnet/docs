---
title: Getting started with F# with command-line tools
description: Learn how to use F# with the cross-platform .NET CLI.
keywords: visual f#, f#, functional programming, .NET, .NET Core
author: cartermp
ms.author: phcart
ms.date: 07/01/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 615db1ec-6ef3-4de2-bae6-4586affa9771
---

# Getting started with F# with command-line tools

This article covers how you can get started with using F# on .NET Core 1.0 with the .NET Core SDK 1.0.0 - Preview 2 (build 003131).  It will go through building a multi-project solution with a Class Library that is called by a Console Application.

## Prerequisites

To begin, you must install the [.NET Core SDK 1.0.3 - (build 004769)](https://dot.net/core).  There is no need to uninstall a previous version of the .NET Core SDK, as it supports side-by-side installations.

This article assumes that you know how to use a command line and have a preferred text editor.  If you don't already use it, [Visual Studio Code](https://code.visualstudio.com) is a great option as a text editor for F#.  To get awesome features like IntelliSense, better syntax highlighting, and more, you can download the [Ionide Extension](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp).

## Building a Simple Multi-project Solution

1. Open a Command Line/Terminal.
2. Create a new directory named `FSNetCore`.  Open Visual Studio code or your preferred editor inside this directory. 
3. Under `FSNetCore`, create `src` and `test` directories.
4. Under `FSNetCore`, create a new file called `global.json`.  It should have the following contents:

```json
{
    "projects":[ "src", "test" ]
}
```

Your solutions structure should now look like this:

```
FSNetCore/
|---src/
|---test/
|---global.json
```

### Writing a Class library

Use the `dotnet new` command, create a Class Library project in the **src** folder named Library. 

```bash
dotnet new classlib --lang F# -o src/Library 
```

Replace the contents of `Library.fs` with the following:

```fsharp
module Library

open Newtonsoft.Json

let getJsonNetJson value = 
    sprintf "I used to be %s but now I'm %s thanks to JSON.NET!" value  (JsonConvert.SerializeObject(value))
```

Add the Newtonsoft.Json nuget package to the Library project.

```bash
dotnet add package Newtonsoft.Json
```

Restore the nuget dependencies

```bash
dotnet restore
``` 

and build the project

```bash 
dotnet build
```

>[!NOTE] `restore` and `build` assumes the current directory contains the project file, otherwise pass in the location. For example, `dotnet restore src/Library/Library.fsproj`

### Writing a Console Application which Consumes the Class Library

Use the `dotnet new` command, create a Console app in the **src** folder named App. 

```bash
dotnet new console --lang F# -o src/App 
```

Change `Program.fs` to:

```fsharp
open System
open Library

[<EntryPoint>]
let main argv = 
    printfn "Nice command line arguments!  Here's what JSON.NET has to say about them:"

    argv
    |> Array.map getJsonNetJson
    |> Array.iter (printfn "%s")

    0 // return an integer exit code
```

Change directories to the `App` console project and add a reference to the `Library` project using `dotnet add reference`.

```bash
dotnet add reference ../Library/Library.fsproj
```

Restore the nuget dependencies

```bash
dotnet restore
``` 

and build the project

```bash 
dotnet build
```

Run the project passing `Hello World` as arguments.

```bash
dotnet run Hello World
``` 

You should see the following results:

```
Nice command line arguments!  Here's what JSON.NET has to say about them:

I used to be Hello but now I'm ""Hello""!
I used to be World but now I'm ""World""!
```