---
title: dotnet vstest command - .NET Core CLI
description: The dotnet vstest command builds a project and all of its dependencies.
author: guardrex
ms.author: mairaw
ms.date: 08/14/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet vstest

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet-vstest` - Runs tests from the specified files.

## Synopsis

`dotnet vstest [<TEST_FILE_NAMES>] [--Settings|/Settings] [--Tests|/Tests] [--TestAdapterPath|/TestAdapterPath] [--Platform|/Platform] [--Framework|/Framework] [--Parallel|/Parallel] [--TestCaseFilter|/TestCaseFilter] [--logger|/logger] [-lt|--ListTests|/lt|/ListTests] [--ParentProcessId|/ParentProcessId] [--Port|/Port] [--Diag|/Diag] [[--] <args>...]] [-?|--Help|/?|/Help]`

## Description

The `dotnet-vstest` command runs the `VSTest.Console` command-line application to run automated unit and coded UI application tests.

## Arguments

`TEST_FILE_NAMES`

Run tests from the specified assemblies. Separate multiple test assembly names with spaces.

## Options

`--Settings|/Settings:<Settings File>`

Settings to use when running tests.

`--Tests|/Tests:<Test Names>`

Run tests with names that match the provided values. Separate multiple values with commas.

`--TestAdapterPath|/TestAdapterPath`

Use custom test adapters from a given path (if any) in the test run.

`--Platform|/Platform:<Platform type>`

Target platform architecture used for test execution. Valid values are `x86`, `x64`, and `ARM`.

`--Framework|/Framework:<Framework Version>`

Target .NET Framework version used for test execution. Examples of valid values are `.NETFramework,Version=v4.6`, `.NETCoreApp,Version=v1.0`, etc. Other supported values are `Framework35`, `Framework40`, `Framework45`, and `FrameworkCore10`.

`--Parallel|/Parallel`

Execute tests in parallel. By default, all available cores on the machine are available for use. Set an explicit number of cores with a settings file.

`--TestCaseFilter|/TestCaseFilter:<Expression>`

Run tests that match the given expression. `<Expression>` is of the format `<property>Operator<value>[|&<Expression>]`, where Operator is one of `=`, `!=`, or `~`.  Operator `~` has 'contains' semantics and is applicable for string properties like `DisplayName`. Parenthesis `()` are used to group sub-expressions.

`-?|--Help|/?|/Help`

Prints out a short help for the command.

`--logger|/logger:<Logger Uri/FriendlyName>`

Specify a logger for test results.  

* To publish test results to Team Foundation Server, use the `TfsPublisher` logger provider:

  ```
  /logger:TfsPublisher;
      Collection=<team project collection url>;
      BuildName=<build name>;
      TeamProject=<team project name>
      [;Platform=<Defaults to "Any CPU">]
      [;Flavor=<Defaults to "Debug">]
      [;RunTitle=<title>]
  ```

* To log results to a Visual Studio Test Results File (TRX), use the `trx` logger provider. This switch creates a file in the test results directory with given log file name. If `LogFileName` isn't provided, a unique file name is created to hold the test results.

  ```
  /logger:trx [;LogFileName=<Defaults to unique file name>]
  ```

`-lt|--ListTests|/lt|/ListTests:<File Name>`

Lists discovered tests from the given test container.

`--ParentProcessId|/ParentProcessId:<ParentProcessId>`

Process Id of the parent process responsible for launching the current process.

`--Port|/Port:<Port>`

Specifies the port for the socket connection and receiving the event messages.

`--Diag|/Diag:<Path to log file>`

Enables verbose logs for the test platform. Logs are written to the provided file.

`args`

Specifies extra arguments to pass to the adapter. Arguments are specified as name-value pairs of the form `<n>=<v>`, where `<n>` is the argument name and `<v>` is the argument value. Use a space to separate multiple arguments.

## Examples

Run tests in `mytestproject.dll`:

`dotnet vstest mytestproject.dll`

Run tests in `mytestproject.dll`, exporting to custom folder with custom name:

`dotnet vstest mytestproject.dll --logger:"trx;LogFileName=custom_file_name.trx" --ResultsDirectory:custom/file/path`

Run tests in `mytestproject.dll` and `myothertestproject.exe`:

`dotnet vstest mytestproject.dll myothertestproject.exe`

Run `TestMethod1` tests:

`dotnet vstest /Tests:TestMethod1`

Run `TestMethod1` and `TestMethod2` tests:

`dotnet vstest /Tests:TestMethod1,TestMethod2`

