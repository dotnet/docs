---
title: dotnet vstest command
description: The 'dotnet vstest' command builds a project and all of its dependencies. 
keywords: dotnet vstest, dotnet vstest, CLI, CLI command, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 0e36c070-2242-41d3-96f1-aea0aca48d4d
---

# dotnet vstest

## Name

`dotnet vstest` - Runs tests from the specified files.

## Synopsis

`dotnet vstest [<TEST_FILE_NAMES>] [--Collect|/Collect] [--Diag|/Diag] [--Framework|/Framework] [-?|--Help|/?|/Help] [-lt|--ListTests|/lt|/ListTests] [--logger|/logger] [--Parallel|/Parallel] [--ParentProcessId|/ParentProcessId] [--Platform|/Platform] [--Port|/Port] [--ResultsDirectory|/ResultsDirectory] [--Settings|/Settings] [--TestAdapterPath|/TestAdapterPath] [--TestCaseFilter|/TestCaseFilter] [--Tests|/Tests] [[--] <args>...]]`

## Description

The `dotnet vstest` command runs the `VSTest.Console` command-line app to run automated unit and coded UI app tests.

## Arguments

`TEST_FILE_NAMES`

Run tests from the specified assemblies. Separate multiple test assembly names with spaces.

## Options

`[--] args`

Specifies extra arguments to pass to the adapter. Arguments are specified as name-value pairs of the form `<n>=<v>`, where `<n>` is the argument name and `<v>` is the argument value. Use a space to separate multiple arguments.

`--Collect|/Collect:<DataCollector friendlyName>`

Enables data collector for the test run. For more information, see [Monitor and analyze test run](https://aka.ms/vstest-collect).

`--Diag|/Diag:<Path to log file>`

Enables verbose logs for the test platform. Logs are written to the provided file.

`--Framework|/Framework:<Framework Version>`

Target .NET Framework version used for test execution. Examples of valid values are `.NETFramework,Version=v4.7` and `.NETCoreApp,Version=v2.0`. Other supported values are `Framework35`, `Framework40`, `Framework45`, and `FrameworkCore10`.

`-?|--Help|/?|/Help`

Shows help information.

`--logger|/logger:<Logger Uri/FriendlyName>`

Specify a logger for test results.

- To publish test results to Team Foundation Server, use the `TfsPublisher` logger provider:

  ```console
  /logger:TfsPublisher;
      Collection=<team project collection url>;
      BuildName=<build name>;
      TeamProject=<team project name>
      [;Platform=<Defaults to "Any CPU">]
      [;Flavor=<Defaults to "Debug">]
      [;RunTitle=<title>]
  ```

- To log results to a Visual Studio Test Results File (TRX), use the `trx` logger provider. This switch creates a file in the test results directory with given log file name. If `LogFileName` isn't provided, a unique file name is created to hold the test results.

  ```console
  /logger:trx [;LogFileName=<Defaults to unique file name>]
  ```

`-lt|--ListTests|/lt|/ListTests:<File Name>`

Lists discovered tests from the given test container.

`--Parallel|/Parallel`

Execute tests in parallel. By default, all available cores on the machine are available for use. Set an explicit number of cores with a settings file.

`--ParentProcessId|/ParentProcessId:<ParentProcessId>`

Process Id of the parent process responsible for launching the current process.

`--Platform|/Platform:<Platform type>`

Target platform architecture used for test execution. Valid values are `x86`, `x64`, and `ARM`.

`--Port|/Port:<Port>`

Specifies the port for the socket connection and receiving the event messages.

`--ResultsDirectory|/ResultsDirectory <DIRECTORY>`

The test results directory is created on the specified path if it doesn't exist.

`--Settings|/Settings:<Settings File>`

Settings to use when running tests.

`--TestAdapterPath|/TestAdapterPath`

Use custom test adapters from a given path (if any) in the test run.

`--TestCaseFilter|/TestCaseFilter:<Expression>`

Run tests that match the given expression. `<Expression>` is of the format `<property>Operator<value>[|&<Expression>]`, where Operator is one of `=`, `!=`, or `~`.  Operator `~` has *contains* semantics and is applicable to string properties like `DisplayName`. Parenthesis `()` are used to group sub-expressions.

`--Tests|/Tests:<Test Names>`

Run tests with names that match the provided values. Separate multiple values with commas.

## Examples

Run tests in `mytestproject.dll`:

`dotnet vstest mytestproject.dll`

Run tests in `mytestproject.dll` and `myothertestproject.exe`:

`dotnet vstest mytestproject.dll myothertestproject.exe`

Run `TestMethod1` tests:

`dotnet vstest /Tests:TestMethod1`

Run `TestMethod1` and `TestMethod2` tests:

`dotnet vstest /Tests:TestMethod1,TestMethod2`
