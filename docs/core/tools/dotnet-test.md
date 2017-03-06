---
title: dotnet-test command | Microsoft Docs
description: The `dotnet test` command is used to execute unit tests in a given project.
keywords: dotnet-test, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 02/08/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 4bf0aef4-148a-41c6-bb95-0a9e1af8762e
---

#dotnet-test

## Name

`dotnet-test` - .NET test driver

## Synopsis

`dotnet test [project] [--help] 
    [--settings] [--list-tests] [--filter] 
    [--test-adapter-path] [--logger] 
    [--configuration] [--framework] [--output] [--diag]
    [--no-build] [--verbosity]`

## Description

The `dotnet test` command is used to execute unit tests in a given project. Unit tests are class library 
projects that have dependencies on the unit test framework (for example, NUnit or xUnit) and the 
dotnet test runner for that unit testing framework. 
These are packaged as NuGet packages and are restored as ordinary dependencies for the project.

Test projects also need to specify the test runner. This is specified using an ordinary `<PackageReference>` element, as 
seen in the following sample project file:

[!code-xml[XUnit Basic Template](../../../samples/snippets/csharp/xunit-test/xunit-test.csproj)]

## Options

`[project]`
    
Specifies a path to the test project. If omitted, it defaults to current directory.

`-h|--help`

Prints out a short help for the command.

`-s|--settings <SETTINGS_FILE>`

Settings to use when running tests. 

`-t|--list-tests`

List all of the discovered tests in the current project. 

`--filter <EXPRESSION>`

Filters out tests in the current project using the given expression. For more information on filtering support, see [Running selective unit tests in Visual Studio using TestCaseFilter](https://aka.ms/vstest-filtering).

`-a|--test-adapter-path <PATH_TO_ADAPTER>`

Use the custom test adapters from the specified path in the test run. 

`-l|--logger <LoggerUri/FriendlyName>`

Specifies a logger for test results. 

`-c|--configuration <Debug|Release>`

Configuration under which to build. The default value is `Debug` but your project's configuration could override this default SDK setting.

`-f|--framework <FRAMEWORK>`

Looks for test binaries for a specific framework.

`-o|--output <OUTPUT_DIRECTORY>`

Directory in which to find the binaries to run.

`-d|--diag <PATH_TO_DIAGNOSTICS_FILE>`

Enables diagnostic mode for the test platform and write diagnostic messages to the specified file. 

`--no-build` 

Does not build the test project prior to running it.

`-v|--verbosity [quiet|minimal|normal|diagnostic]`

Set the verbosity level of the command. You can specify the following verbosity levels: q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic]. 

## Examples

Run the tests in the project in the current directory:

`dotnet test` 

Run the tests in the test1 project:

`dotnet test ~/projects/test1/test1.csproj` 

## See also

[Frameworks](../../standard/frameworks.md)

[Runtime IDentifier (RID) catalog](../rid-catalog.md)