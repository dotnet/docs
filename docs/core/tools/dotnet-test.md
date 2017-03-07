---
title: dotnet-test command | Microsoft Docs
description: The `dotnet test` command is used to execute unit tests in a given project.
keywords: dotnet-test, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 10/07/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 3a0fa917-eb0a-4d7e-9217-d06e65455675
---

#dotnet-test

> [!WARNING]
> This topic applies to .NET Core Tools Preview 2. For the .NET Core Tools RC4 version,
> see the [dotnet-test (.NET Core Tools RC4)](../preview3/tools/dotnet-test.md) topic.

## Name

`dotnet-test` - Runs unit tests using the configured test runner.

## Synopsis

`dotnet test [project] [--help] 
    [--parentProcessId] [--port] [--configuration]   
    [--output] [--build-base-path] [--framework] [--runtime]
    [--no-build]`  

## Description

The `dotnet test` command is used to execute unit tests in a given project. Unit tests are class library 
projects that have dependencies on the unit test framework (for example, NUnit or xUnit) and the 
dotnet test runner for that unit testing framework. 
These are packaged as NuGet packages and are restored as ordinary dependencies for the project.

Test projects also need to specify a test runner property in project.json using the "testRunner" node. 
This value should contain the name of the unit test framework.

The following sample project.json shows the properties needed:

```json
{
  "version": "1.0.0-*",
  "buildOptions": {
    "debugType": "portable"
  },
  "dependencies": {
    "System.Runtime.Serialization.Primitives": "4.1.1",
    "xunit": "2.1.0",
    "dotnet-test-xunit": "1.0.0-rc2-192208-24"
  },
  "testRunner": "xunit",
  "frameworks": {
    "netcoreapp1.0": {
      "dependencies": {
        "Microsoft.NETCore.App": {
          "type": "platform",
          "version": "1.0.0"
        }
      },
      "imports": [
        "dotnet5.4",
        "portable-net451+win8"
      ]
    }
  }
}
```

`dotnet test` supports two running modes:

1. Console: In console mode, `dotnet test` simply executes fully any command gets passed to it and outputs the results. Anytime you invoke `dotnet test` without passing --port, it runs in console mode, which in turn will cause the runner to run in console mode.
2. Design time: used in the context of other tools, such as editors or Integrated Development Environments (IDEs).

## Options

`[project]`
    
Specifies a path to the test project. If omitted, it defaults to current directory.

`-?|-h|--help`

Prints out a short help for the command.

`--parentProcessId`

Used by IDEs to specify their process ID. Test will exit if the parent process does.

`--port`

Used by IDEs to specify a port number to listen for a connection.

`-c|--configuration <Debug|Release>`

Configuration under which to build. The default value is `Release`. 

`-o|--output [OUTPUT_DIRECTORY]`

Directory in which to find the binaries to run.

`-b|--build-base-path <OUTPUT_DIRECTORY>`

Directory in which to place temporary outputs.

`-f|--framework [FRAMEWORK]`

Looks for test binaries for a specific framework.

`-r|--runtime [RUNTIME_IDENTIFIER]`

Look for test binaries for a for the specified runtime.

`--no-build` 

Does not build the test project prior to running it. 

## Examples

Run the tests in the project in the current directory:

`dotnet test` 

Run the tests in the test1 project:

`dotnet test /projects/test1/project.json` 

## See also

[Frameworks](../../standard/frameworks.md)

[Runtime IDentifier (RID) catalog](../rid-catalog.md)