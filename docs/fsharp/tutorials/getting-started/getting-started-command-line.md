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

To begin, you must install the [.NET Core SDK 1.0.0 - Preview 2 (build 003131)](https://dot.net/core).  There is no need to uninstall a previous version of the .NET Core SDK, as it supports side-by-side installations.

This article assumes that you know how to use a command line and have a preferred text editor.  If you don't already use it, [Visual Studio Code](https://code.visualstudio.com) is a great option as a text editor for F#.  To get awesome features like IntelliSense, better syntax highlighting, and more, you can download the [Ionide Extension](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp).

## Building a Simple Multi-project Solution

1. Open a Command Line/Terminal.
2. Create a new directory named `FSNetCore`.  Open Visual Studio code or your preferred editor inside this directory. 
3. Under `FSNetCore`, create `src` and `test` directories.
4. Under `FSNetCore`, create a new file called `global.json`.  It should have this as its contents:

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

1. Create a `Library` folder under `FSNetCore/src`.
2. In the command line, execute `dotnet new -l F# -t lib` in `FSNetCore/src/Library`.
3. Replace the contents of `Library.fs` with the following:

    ```fsharp
    module Library

    open Newtonsoft.Json

    let getJsonNetJson value = 
        sprintf "I used to be %s but now I'm %s thanks to JSON.NET!" value  (JsonConvert.SerializeObject(value))
    ```

5. Replace the contents of `project.json` with the following:

    ```json
    {
      "version": "1.0.0-*",
      "buildOptions": {
        "debugType":"portable",
        "compilerName": "fsc",
        "compile": {
          "includeFiles": [
            "Library.fs"
          ]
        }
      },
      "tools": {
        "dotnet-compile-fsc":"1.0.0-preview2-*"
      },
      "frameworks": {
        "netstandard1.6": {
          "dependencies": {
            "NETStandard.Library":"1.6.0",
            "Microsoft.FSharp.Core.netcore":"1.0.0-alpha-160629",
            "Newtonsoft.Json":"9.0.1"    
          }
        }
      }
    }
    ```

6. Run `dotnet restore` and `dotnet build`.  These should succeed.

### Writing a Console Application which Consumes the Class Library

1. Create an `App` folder under `FSNetCore/src`.
2. In the command line, execute `dotnet new -l F#` in `FSNetCore/src/App`.
3. Change `Program.fs` to:

    ```fs
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

4. Add a reference to the `Library` project you just created in the `project.json` file.  It should look like this:

    ```json
    {
      "version": "1.0.0-*",
      "buildOptions": {
        "debugType":"portable",
        "emitEntryPoint": true,
        "compilerName": "fsc",
        "compile": {
          "includeFiles": [
            "Program.fs"
          ]
        }
      },
      "tools": {
        "dotnet-compile-fsc":"1.0.0-preview2-*"
      },
      "frameworks": {
        "netcoreapp1.0": {
          "dependencies": {
            "Microsoft.NETCore.App": {
              "type": "platform",
              "version": "1.0.0"
            },
            "Microsoft.FSharp.Core.netcore": "1.0.0-alpha-160629",
            "Library":{
              "target": "project"
            }
          }
        }
      }
    }
    ```

10. Enter `dotnet restore` and `dotnet build` into the command line.  These should succeed.
11. Enter `dotnet run Hello World` into the command line.  You should see results like this:

```
Nice command line arguments!  Here's what JSON.NET has to say about them:

I used to be Hello but now I'm ""Hello""!
I used to be World but now I'm ""World""!
```