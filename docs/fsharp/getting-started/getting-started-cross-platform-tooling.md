---
title: Getting started with F# on .NET Core
description: Getting started with F# on .NET Core
keywords: .NET, .NET Core
author: cartermp
manager: wpickett
ms.date: 07/01/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 615db1ec-6ef3-4de2-bae6-4586affa9771
---

# Getting started with F# with Cross-Platform Tools

This article covers how you can get started with using F# on .NET Core with the ..NET Core SDK 1.0 Preview 2.  It will go through building a multi-project solution with a Class Library, a Console App, and an xUnit test project.

## Prerequisites

To begin, you must install the [.NET Core SDK 1.0 Preview 2](https://www.microsoft.com/net/core).

This article uses the command line and [Visual Studio Code](https://code.visualstudio.com) as the text editor.  You're free to use any editor you like, though.  To get awesome features like Intellisense, better syntax highlighting, and more, you can also download the [Ionide Extension](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp) and get a lightweight IDE experience in Visual Studio Code.

## Building a Simple Multi-project Solution

1. Open up a Command Line/Terminal.
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
2. In the command line, execute `dotnet new -l F#` in `FSNetCore/src/Library`.
3. Remove the `NuGet.Config` file.
4. Rename `Program.fs` to `Lib.fs`.
5. Open the `project.json` file and remove the `emitEntryPoint` entry from `buildOptions`.
6. Under `buildOptions/compile/includeFiles`, replace `Program.fs` with `Lib.fs`.
7. Remove the global `dependencies` section.
8. Under `tools/dotnet-compile-fsc`, remove the `imports` section.
9. Under `frameworks`, change `netcoreapp1.0` to `netstandard1.6`.
11. Under `frameworks/netstandard1.6`, remove the `imports` section.
12. Under `frameworks/netstandard1.6/dependencies`, replace the `Microsoft.NETCore.App` package with `"NETStandard.Library":"1.6.0"`.  Add `"Microsoft.FSharp.Core.netcore": "1.0.0-alpha-160629"` and `"Newtonsoft.Json": "9.0.1"`.
13. Open `Lib.fs` and change the contents to the following code:

    ```fsharp
    module Library

    open Newtonsoft.Json

    let getJsonNetJson value = 
        sprintf "I used to be %s but now I'm %s!" value  (JsonConvert.SerializeObject(value))
    ```

14. Run `dotnet restore` and `dotnet build`.  These should succeed.

Your `project.json` file should look like this:

```json
{
  "version": "1.0.0-*",
  "buildOptions": {
    "compilerName": "fsc",
    "compile": {
      "includeFiles": [
        "Lib.fs"
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
        "Microsoft.FSharp.Core.netcore": "1.0.0-alpha-160629",
        "Newtonsoft.Json": "9.0.1"    
      }
    }
  }
}
```

And your `Lib.fs` file should look like this:

```fsharp
module Library

open Newtonsoft.Json

let getJsonNetJson value = 
    sprintf "I used to be %s but now I'm %s!" value  (JsonConvert.SerializeObject(value))
```

### Writing a Console Application which Consumes the Class Library

1. Create an `App` folder under `FSNetCore/src`.
2. In the command line, execute `dotnet new -l F#` in `FSNetCore/src/App`.
3. Remove the `NuGet.Config` file.
4. Open the `project.json` file.
5. Remove the global `dependencies` section.
6. Under `tools/dotnet-compile-fsc`, remove the `imports` section.
7. Under `frameworks/netcoreapp1.0/`, remove the `imports` section.
8. Under `frameworks/netcoreapp1.0/dependencies`, add the following after `Microsoft.NETCore.App`:

    ```json
    "Microsoft.FSharp.Core.netcore": "1.0.0-alpha-160629",
    "Library":{
      "version":"1.0.0",
      "target": "project"
    }
    ```

9. Change `Program.fs` to:

    ```fs
    open System
    open Library

    [<EntryPoint>]
    let main argv = 
        printfn "Nice command line arguments!.  Here's what JSON.NET has to say about them:"

        argv
        |> Array.map getJsonNetJson
        |> Array.iter (printfn "%s")

        0 // return an integer exit code
    ```

10. Enter `dotnet restore` and `dotnet build` into the command line.  These should succeed.
11. Enter `dotnet run Hello World` into the command line.  You should see results like this:

```
Nice command line arguments!  Here's what JSON.NET has to say about them:

I used to be Hello but now I'm ""Hello""!
I used to be World but now I'm ""World""!
```

Your `project.json` file should look like this:

```json
{
  "version": "1.0.0-*",
  "buildOptions": {
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
          "version":"1.0.0",
          "target": "project"
        }
      }
    }
  }
}
```

And your `Program.fs` file should look like this:

```fsharp
open System
open Library

[<EntryPoint>]
let main argv = 
    printfn "Nice command line arguments!.  Here's what JSON.NET has to say about them:"

    argv
    |> Array.map getJsonNetJson
    |> Array.iter (printfn "%s")

    0 // return an integer exit code
```

### Testing the Class Library with xUnit.net

1. Create a `TestLibrary` folder under `NETCoreFS/test`.
2. In the command line, execute `dotnet new -l F#` in `FSNetCore/src/Tests`.
3. Remove the `NuGet.Config`.
4. Rename `Program.fs` to `Tests.fs`.
5. Open the `project.json` file.
6. Remove the `emitEntryPoint` entry under `buildOptions`.
7. Under `buildOptions/compile/includeFiles`, replace `Program.fs` with `Tests.fs`.
8. Remove the global `dependencies` section. 
9. Under `tools/dotnet-compile-fsc`, remove the `imports` section.
9. Under `frameworks/netcoreapp1.0/`, remove the `imports` section.
10. Under `frameworks/netcoreapp1.0/dependencies`, add the following after `Microsoft.NETCore.App`:

    ```json
    "Microsoft.FSharp.Core.netcore": "1.0.0-alpha-160629",
    "xunit":"2.2.0-beta2-build3300",
    "dotnet-test-xunit":"2.2.0-preview2-build1029",
    "Library":{
      "version": "1.0.0",
      "target": "project"
    },
    ```

11. After the `frameworks` section, add `"testRunner":"xunit"`.  Note that you can add this section anywhere in the `project.json` file.
12. In `test.fs`, paste the following code:

    ```fs
    module Test

    open Xunit
    open Library

    [<Fact>]    
    let ``Library converts "Banana" correctly``() =
        let expected = """I used to be Banana but now I'm "Banana"!"""
        let actual =  getJsonNetJson "Banana"
        Assert.Equal(expected, actual)
    ```

10. Run `dotnet restore` and `dotnet build`.

You should now be able to run the test and verify it passes by doing `dotnet test`.

> [!NOTE]
> This will temporarily fail on macOS. [There is an issue here to track this](https://github.com/xunit/xunit/issues/859).

Your `project.json` file should look like this:

```json
{
  "version": "1.0.0-*",
  "buildOptions": {
    "compilerName": "fsc",
    "compile": {
      "includeFiles": [
        "Tests.fs"
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
        "xunit":"2.2.0-beta2-build3300",
        "dotnet-test-xunit":"2.2.0-preview2-build1029",
        "Library":{
          "version": "1.0.0",
          "target": "project"
        },
      }
    }
  },
  "testRunner": "xunit"
}
```

And your `Tests.fs` file should look like this:

```fsharp
module Test

open Xunit
open Library

[<Fact>]    
let ``Library converts "Banana" correctly``() =
    let expected = """I used to be Banana but now I'm "Banana"!"""
    let actual =  getJsonNetJson "Banana"
    Assert.Equal(expected, actual)
```