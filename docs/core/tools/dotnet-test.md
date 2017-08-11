---
title: dotnet test command
description: The 'dotnet test' command is used to execute unit tests in a given project.
keywords: dotnet test, dotnet test, CLI, CLI command, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 4bf0aef4-148a-41c6-bb95-0a9e1af8762e
---
# dotnet test

## Name

`dotnet test` - .NET test driver used to execute unit tests.

## Synopsis

`dotnet test [<PROJECT>] [-a|--test-adapter-path] [-c|--configuration] [-d|--diag] [--filter] [-f|--framework] [-h|--help] [-l|--logger] [--no-build] [-o|--output] [-s|--settings] [-t|--list-tests] [-v|--verbosity]`

## Description

The `dotnet test` command is used to execute unit tests in a given project. Unit tests are console app projects that have dependencies on a unit test framework (for example, MSTest or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.

Test projects must specify the test runner. This is specified using an ordinary **\<PackageReference>** element, as seen in the following sample project file:

[!code-xml[XUnit Basic Template](../../../samples/snippets/csharp/xunit-test/xunit-test.csproj)]

## Arguments

`PROJECT`
    
Specifies a path to the test project. If omitted, it defaults to current directory.

## Options

`-a|--test-adapter-path <PATH_TO_ADAPTER>`

Use the custom test adapters from the specified path in the test run.

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`, but your project's configuration could override this default SDK setting.

`-d|--diag <PATH_TO_DIAGNOSTICS_FILE>`

Enables diagnostic mode for the test platform and writes diagnostic messages to the specified file. 

`--filter <EXPRESSION>`

Filters out tests in the current project using the given expression. For more information, see the [Filter option details](#filter-option-details) section. For additional information and examples on how to use selective unit test filtering, see [Running selective unit tests](../testing/selective-unit-tests.md).

`-f|--framework <FRAMEWORK>`

Looks for test binaries for a specific [framework](../../standard/frameworks.md).

`-h|--help`

Shows help information.

`-l|--logger <LoggerUri/FriendlyName>`

Specifies a logger for test results.

`--no-build` 

Doesn't build the test project prior to running it.

`-o|--output <OUTPUT_DIRECTORY>`

Directory in which to find the binaries to run.

`-s|--settings <SETTINGS_FILE>`

Settings to use when running tests. 

`-t|--list-tests`

List the discovered tests in the current project. 

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

## Examples

Run the tests in the project in the current directory:

`dotnet test` 

Run the tests in the `test1` project:

`dotnet test ~/projects/test1/test1.csproj`

## Filter option details

`--filter <EXPRESSION>`

`<Expression>` has the format `<property><operator><value>[|&<Expression>]`.

`<property>` is an attribute of the `Test Case`. The following table shows the properties supported by popular unit test frameworks.

| Test Framework | Supported properties                                                                                      |
| :------------: | --------------------------------------------------------------------------------------------------------- |
| MSTest         | <ul><li>FullyQualifiedName</li><li>Name</li><li>ClassName</li><li>Priority</li><li>TestCategory</li></ul> |
| xUnit          | <ul><li>FullyQualifiedName</li><li>DisplayName</li><li>Traits</li></ul>                                   |

The `<operator>` describes the relationship between the property and the value:

| Operator | Function        |
| :------: | --------------- |
| `=`      | Exact match     |
| `!=`     | Not exact match |
| `~`      | Contains        |

`<value>` is a string. The lookups are case insensitive.

An expression without an `<operator>` is automatically considered as a *contains* on `FullyQualifiedName` property (for example, `dotnet test --filter xyz` is same as `dotnet test --filter FullyQualifiedName~xyz`).

Expressions can be joined with conditional operators:

| Operator | Function |
| :------: | :------: |
| `|`      | OR       |
| `&`      | AND      |

You can enclose expressions in paranthesis when using conditional operators (for example, `(Name~TestMethod1) | (Name~TestMethod2)`).

For a additional information and examples on how to use selective unit test filtering, see [Running selective unit tests](../testing/selective-unit-tests.md).

## See also

[Frameworks and Targets](../../standard/frameworks.md)   
[.NET Core Runtime IDentifier (RID) catalog](../rid-catalog.md)
