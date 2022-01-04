---
title: dotnet-coverage code coverage tool - .NET CLI
description: Learn how to install and use the dotnet-coverage CLI tool to collect code coverage data of a running process.
ms.date: 10/21/2021
ms.topic: reference
---
# dotnet-coverage code coverage utility

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Install

To install the latest release version of the `dotnet-coverage` [NuGet package](https://www.nuget.org/packages/dotnet-coverage), use the [dotnet tool install](../tools/dotnet-tool-install.md) command:

```dotnetcli
dotnet tool install --global dotnet-coverage
```

## Synopsis

```console
dotnet-coverage [-h, --help] [--version] <command>
```

## Description

The `dotnet-coverage` tool:

* Enables the collection of code coverage data of a running process on Windows and Linux x64.
* Provides cross-platform merging of code coverage reports.

## Options

- **`-h|--help`**

  Shows command-line help.

- **`--version`**

  Displays the version of the dotnet-coverage utility.

## Commands

| Command                                                   |
|-----------------------------------------------------------|
| [dotnet-coverage collect](#dotnet-coverage-collect)       |
| [dotnet-coverage merge](#dotnet-coverage-merge)           |
| [dotnet-coverage snapshot](#dotnet-coverage-snapshot)     |
| [dotnet-coverage shutdown](#dotnet-coverage-shutdown)     |

## dotnet-coverage collect

The `collect` command is used to collect code coverage data for any .NET process and its subprocesses. For example, you can collect code coverage data for a console application or a Blazor application. This command is available on Windows (x86 and x64), Linux (x64), and macOS (x64). The command supports only .NET modules. Native modules are not supported.

### Synopsis

```console
dotnet-coverage collect [-?|-h|--help] [-l|--log-file <log-file>] [-ll|--log-level <log-level>]
    [-o|--output <output>] [-f|--output-format <output-format>]
    [-s|--settings <settings>] [-id|--session-id <session-id>]
    <command>
```

### Arguments

- **`<command>`**

  The command for which to collect code coverage data.

### Options

- **`-l|--log-file <log-file>`**

  Sets the log file path. When you provide a directory (with a path separator at the end), a new log file is generated for each process under analysis.

- **`-ll|--log-level <log-level>`**

  Sets the log level. Supported values: `Error`, `Info`, and  `Verbose`.

- **`-o|--output <output>`**

  Sets the code coverage report output file.

- **`-f|--output-format <output-format>`**

  The output file format. Supported values: `coverage`, `xml`, and `cobertura`. Default is `coverage` (binary format that can be opened in Visual Studio).

- **`-id|--session-id <session-id>`**

  Specifies the code coverage session ID. If not provided, the tool will generate a random GUID.

- **`-s|--settings <settings>`**

  Sets the path to the XML code coverage settings.

## dotnet-coverage merge

The `merge` command is used to merge several code coverage reports into one. This command is available on all platforms. This command supports the following code coverage report formats:

- `coverage`
- `cobertura`
- `xml`

### Synopsis

```console
dotnet-coverage merge [-?|-h|--help] [-l|--log-file <log-file>] [-ll|--log-level <log-level>]
    [-o|--output <output>] [-f|--output-format <output-format>]
    [-r|--recursive] [--remove-input-files]
    <files>
```

### Arguments

- **`<files>`**

  The input code coverage reports.

### Options

- **`-l|--log-file <log-file>`**

  Sets the log file path. When you provide a directory (with a path separator at the end), a new log file is generated for each process under analysis.

- **`-ll|--log-level <log-level>`**

  Sets the log level. Supported values: `Error`, `Info`, and  `Verbose`.

- **`-o|--output <output>`**

  Sets the code coverage report output file.

- **`-f|--output-format <output-format>`**

  The output file format. Supported values: `coverage`, `xml`, and `cobertura`. Default is `coverage` (binary format that can be opened in Visual Studio).

- **`-r, --recursive`**

  Search for coverage reports in subdirectories.

- **`--remove-input-files`**

  Removes all input coverage reports that were merged.

## dotnet-coverage snapshot

Creates a coverage file for existing code coverage collection.

### Synopsis

```console
dotnet-coverage snapshot [-?|-h|--help] [-l|--log-file <log-file>] [-ll|--log-level <log-level>]
  [-o|--output <output>] [-r|--reset] <session>
```

### Arguments

- **`<session>`**

  The session ID of the collection for which a coverage file is to be generated.

### Options

- **`-l|--log-file <log-file>`**

  Sets the log file path. When you provide a directory (with a path separator at the end), a new log file is generated for each process under analysis.

- **`-ll|--log-level <log-level>`**

  Sets the log level. Supported values: `Error`, `Info`, and  `Verbose`.

- **`-o|--output <output>`**

  Sets the code coverage report output file. If not provided, it's generated automatically with a timestamp.

- **`-r|--reset <reset>`**

  Clears existing coverage information after a coverage file is created.

## dotnet-coverage shutdown

Closes existing code coverage collection.

### Synopsis

```console
dotnet-coverage shutdown [-?|-h|--help] [-l|--log-file <log-file>] [-ll|--log-level <log-level>] <session>
```

### Arguments

- **`<session>`**

  The session ID of the collection to be closed.

### Options

- **`-l|--log-file <log-file>`**

  Sets the log file path. When you provide a directory (with a path separator at the end), a new log file is generated for each process under analysis.

- **`-ll|--log-level <log-level>`**

  Sets the log level. Supported values: `Error`, `Info`, and  `Verbose`.

## Collecting code coverage

Collect code coverage data for any .NET application (such as console or Blazor) by using the following command:

```console
dotnet-coverage collect "dotnet run"
```

In case of an application that requires a signal to terminate, you can use <kbd>Ctrl</kbd>+<kbd>C</kbd>, which will still let you collect code coverage data. For the argument, you can provide any command that will eventually start a .NET app. For example, it can be a PowerShell script.

### Sessions

When you're running code coverage analysis on a .NET server that just waits for messages and sends responses, you need a way to stop the server to get final code coverage results. You can use <kbd>Ctrl</kbd>+<kbd>C</kbd> locally, but not in Azure Pipelines. For these scenarios, you can use sessions. You can specify a session ID when starting collection, and then use the `shutdown` command to stop collection and the server.

For example, assume you have a server in the *D:\serverexample\server* directory and a test project in the *D:\serverexample\tests* directory. Tests are communicating with the server through the network. You can start code coverage collection for the server as follows:

```console
D:\serverexample\server> dotnet-coverage collect --session-id serverdemo "dotnet run"
```

Session ID was specified as `serverdemo`. Then you can run tests as follows:

```console
D:\serverexample\tests> dotnet test
```

A code coverage file for session `serverdemo` can be generated with current coverage as follows:

```console
dotnet-coverage snapshot --output after_first_test.coverage serverdemo
```

Finally, session `serverdemo` and the server can be closed as follows:

```console
dotnet-coverage shutdown serverdemo
```

Following is an example of full output on the server side:

```console
D:\serverexample\server> dotnet-coverage collect --session-id serverdemo "dotnet run"
SessionId: serverdemo
Waiting for a connection... Connected!
Received: Hello!
Sent: HELLO!
Waiting for a connection... Code coverage results: output.coverage.
D:\serverexample\server>
```

### Settings

You can specify a file with settings when you use the `collect` command. The settings file can be used to exclude some modules or methods from code coverage analysis. The format is the same as the data collector configuration inside a *runsettings* file. For more information, see [Customize code coverage analysis](/visualstudio/test/customizing-code-coverage-analysis). Here's an example:

```
<?xml version="1.0" encoding="utf-8"?>
<Configuration>
    <CodeCoverage>
        <!--
        Additional paths to search for .pdb (symbol) files. Symbols must be found for modules to be instrumented.
        If .pdb files are in the same folder as the .dll or .exe files, they are automatically found. Otherwise, specify them here.
        Note that searching for symbols increases code coverage run time. So keep this small and local.
        -->
        <SymbolSearchPaths>
            <Path>C:\Users\User\Documents\Visual Studio 2012\Projects\ProjectX\bin\Debug</Path>
            <Path>\\mybuildshare\builds\ProjectX</Path>
        </SymbolSearchPaths>

        <!--
        About include/exclude lists:
        Empty "Include" clauses imply all; empty "Exclude" clauses imply none.
        Each element in the list is a regular expression (ECMAScript syntax). See /visualstudio/ide/using-regular-expressions-in-visual-studio.
        An item must first match at least one entry in the include list to be included.
        Included items must then not match any entries in the exclude list to remain included.
        -->

        <!-- Match assembly file paths: -->
        <ModulePaths>
            <Include>
                <ModulePath>.*\.dll$</ModulePath>
                <ModulePath>.*\.exe$</ModulePath>
            </Include>
            <Exclude>
                <ModulePath>.*CPPUnitTestFramework.*</ModulePath>
            </Exclude>
        </ModulePaths>

        <!-- Match fully qualified names of functions: -->
        <!-- (Use "\." to delimit namespaces in C# or Visual Basic, "::" in C++.)  -->
        <Functions>
            <Exclude>
                <Function>^Fabrikam\.UnitTest\..*</Function>
                <Function>^std::.*</Function>
                <Function>^ATL::.*</Function>
                <Function>.*::__GetTestMethodInfo.*</Function>
                <Function>^Microsoft::VisualStudio::CppCodeCoverageFramework::.*</Function>
                <Function>^Microsoft::VisualStudio::CppUnitTestFramework::.*</Function>
            </Exclude>
        </Functions>

        <!-- Match attributes on any code element: -->
        <Attributes>
            <Exclude>
            <!-- Don't forget "Attribute" at the end of the name -->
                <Attribute>^System\.Diagnostics\.DebuggerHiddenAttribute$</Attribute>
                <Attribute>^System\.Diagnostics\.DebuggerNonUserCodeAttribute$</Attribute>
                <Attribute>^System\.CodeDom\.Compiler\.GeneratedCodeAttribute$</Attribute>
                <Attribute>^System\.Diagnostics\.CodeAnalysis\.ExcludeFromCodeCoverageAttribute$</Attribute>
            </Exclude>
        </Attributes>

        <!-- Match the path of the source files in which each method is defined: -->
        <Sources>
            <Exclude>
                <Source>.*\\atlmfc\\.*</Source>
                <Source>.*\\vctools\\.*</Source>
                <Source>.*\\public\\sdk\\.*</Source>
                <Source>.*\\microsoft sdks\\.*</Source>
                <Source>.*\\vc\\include\\.*</Source>
            </Exclude>
        </Sources>

        <!-- Match the company name property in the assembly: -->
        <CompanyNames>
            <Exclude>
                <CompanyName>.*microsoft.*</CompanyName>
            </Exclude>
        </CompanyNames>

        <!-- Match the public key token of a signed assembly: -->
        <PublicKeyTokens>
            <!-- Exclude Visual Studio extensions: -->
            <Exclude>
                <PublicKeyToken>^B77A5C561934E089$</PublicKeyToken>
                <PublicKeyToken>^B03F5F7F11D50A3A$</PublicKeyToken>
                <PublicKeyToken>^31BF3856AD364E35$</PublicKeyToken>
                <PublicKeyToken>^89845DCD8080CC91$</PublicKeyToken>
                <PublicKeyToken>^71E9BCE111E9429C$</PublicKeyToken>
                <PublicKeyToken>^8F50407C4E9E73B6$</PublicKeyToken>
                <PublicKeyToken>^E361AF139669C375$</PublicKeyToken>
            </Exclude>
        </PublicKeyTokens>

    </CodeCoverage>
</Configuration>
```

## Merge code coverage reports

You can merge `a.coverage` and `b.coverage` and store the data in `merged.coverage` as follows:

```console
dotnet-coverage merge -o merged.coverage a.coverage b.coverage
```

For example, if you run a command like `dotnet test --collect "Code Coverage"`, the coverage report is stored into a folder that is named a random GUID. Such folders are hard to find and merge. Using this tool, you can merge all code coverage reports for all your projects as follows:

```console
dotnet-coverage merge -o merged.cobertura.xml -f cobertura -r *.coverage
```

The preceding command merges all coverage reports from the current directory and all subdirectories and stores the result into a cobertura file. In Azure Pipelines, you can use [Publish Code Coverage Results task](/azure/devops/pipelines/tasks/test/publish-code-coverage-results) to publish a merged cobertura report.

You can use the `merge` command to convert a code coverage report to another format. For example, the following command converts a binary code coverage report into XML format.

```console
dotnet-coverage merge -o output.xml -f xml input.coverage
```

## See also

- [Customize code coverage analysis](/visualstudio/test/customizing-code-coverage-analysis)
- [Publish Code Coverage Results task](/azure/devops/pipelines/tasks/test/publish-code-coverage-results)
