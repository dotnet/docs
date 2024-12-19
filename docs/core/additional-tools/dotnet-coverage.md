---
title: dotnet-coverage code coverage tool - .NET CLI
description: Learn how to install and use the dotnet-coverage CLI tool to collect code coverage data of a running process.
ms.date: 10/21/2021
ms.topic: reference
---
# dotnet-coverage code coverage utility

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Synopsis

```console
dotnet-coverage <command> [-h, --help] [--version]
```

## Description

The `dotnet-coverage` tool:

* Enables the cross-platform collection of code coverage data of a running process.
* Provides cross-platform merging of code coverage reports.

## Options

* **`-h|--help`**

  Shows command-line help.

* **`--version`**

  Displays the version of the dotnet-coverage utility.

## Install

To install the latest release version of the `dotnet-coverage` [NuGet package](https://www.nuget.org/packages/dotnet-coverage), use the [dotnet tool install](../tools/dotnet-tool-install.md) command:

```dotnetcli
dotnet tool install --global dotnet-coverage
```

## Commands

| Command                                                   |
|-----------------------------------------------------------|
| [dotnet-coverage merge](#dotnet-coverage-merge)           |
| [dotnet-coverage collect](#dotnet-coverage-collect)       |
| [dotnet-coverage connect](#dotnet-coverage-connect)       |
| [dotnet-coverage snapshot](#dotnet-coverage-snapshot)     |
| [dotnet-coverage shutdown](#dotnet-coverage-shutdown)     |
| [dotnet-coverage instrument](#dotnet-coverage-instrument) |
| [dotnet-coverage uninstrument](#dotnet-coverage-uninstrument) |

## dotnet-coverage merge

The `merge` command is used to merge several code coverage reports into one. This command is available on all platforms. This command supports the following code coverage report formats:

* `coverage`
* `cobertura`
* `xml`

### Synopsis

```console
dotnet-coverage merge
    <files>...
    [--remove-input-files]
    [-o|--output <output>] [-f|--output-format <output-format>]
    [-l|--log-file <log-file>] [-ll|--log-level <log-level>]
    [-dco|--disable-console-output] [--nologo]
    [-?|-h|--help]
```

### Arguments

* **`<files>`**

  The input code coverage reports.

### Options

* **`--remove-input-files`**

  Removes all input coverage reports that were merged.

* **`-r, --recursive`**

  .NET 7 SDK and earlier versions only Search for coverage reports in subdirectories.

* **`-o|--output <output>`**

  Sets the code coverage report output file.

* **`-f|--output-format <output-format>`**

  The output file format. Supported values: `coverage`, `xml`, and `cobertura`. Default is `coverage` (binary format that can be opened in Visual Studio).

* **`-l|--log-file <log-file>`**

  Sets the log file path. When you provide a directory (with a path separator at the end), a new log file is generated for each process under analysis.

* **`-ll|--log-level <log-level>`**

  Sets the log level. Supported values: `Error`, `Info`, and  `Verbose`.

* **`-dco|--disable-console-output`**

  Disables console output.

* **`--nologo`**

  Do not display Code Coverage banner.

## dotnet-coverage collect

The `collect` command is used to collect code coverage data for any .NET process and its subprocesses. For example, you can collect code coverage data for a console application or a Blazor application. This command supports dynamic and static instrumentation. Static instrumentation is available on all platforms. You can specify files to be statically instrumented using `include-files` option. Dynamic instrumentation is available on Windows (x86, x64 and Arm64), Linux (x64), and macOS (x64). The command supports only .NET modules. Native modules are not supported.

### Synopsis

The `collect` command can run in two modes.

#### Command Mode

The `collect` command will collect code coverage for the given process executed by the `command` argument.

```console
dotnet-coverage collect
    <command> <args>...
    [-s|--settings <settings>] [-id|--session-id <session-id>]
    [-if|--include-files <include-files>] [-o|--output <output>] [-f|--output-format <output-format>]
    [-l|--log-file <log-file>] [-ll|--log-level <log-level>]
    [-dco|--disable-console-output] [--nologo]
    [-?|-h|--help]
```

#### Server Mode

The `collect` command hosts a server for code coverage collection. Clients can connect to the server via `connect` command.

```console
dotnet-coverage collect
    [-s|--settings <settings>] [-id|--session-id <session-id>]
    [-sv|--server-mode] [-b|--background] [-t|--timeout]
    [-if|--include-files <include-files>] [-o|--output <output>] [-f|--output-format <output-format>]
    [-l|--log-file <log-file>] [-ll|--log-level <log-level>]
    [-dco|--disable-console-output] [--nologo]
    [-?|-h|--help]
```

### Arguments

* **`<command>`**

  The command for which to collect code coverage data.

* **`<args>`**

  The command line arguments for the command.

### Options

* **`-s|--settings <settings>`**

  Sets the path to the XML code coverage settings.

* **`-id|--session-id <session-id>`**

  Specifies the code coverage session ID. If not provided, the tool will generate a random GUID.

* **`-sv|--server-mode`**

  Starts the collector in server mode. Clients can connect to the server with the `connect` command.

* **`-b|--background`**

  Starts code coverage collection server in a new background process. Clients can connect to the server with the `connect` command.

* **`-t|--timeout`**

  Timeout (in milliseconds) for interprocess communication between clients and the server.

* **`-if|--include-files <include-files>`**

  Specifies list of files to be statically instrumented.

* **`-o|--output <output>`**

  Sets the code coverage report output file.

* **`-f|--output-format <output-format>`**

  The output file format. Supported values: `coverage`, `xml`, and `cobertura`. Default is `coverage` (binary format that can be opened in Visual Studio).

* **`-l|--log-file <log-file>`**

  Sets the log file path. When you provide a directory (with a path separator at the end), a new log file is generated for each process under analysis.

* **`-ll|--log-level <log-level>`**

  Sets the log level. Supported values: `Error`, `Info`, and  `Verbose`.

* **`-dco|--disable-console-output`**

  Disables console output.

* **`--nologo`**

  Do not display Code Coverage banner.

## dotnet-coverage connect

The `connect` command is used to connect with the existing server and collects code coverage data for any .NET process and its subprocesses. For example, you can collect code coverage data for a console application or a Blazor application. The command supports only .NET modules. Native modules are not supported.

> [!NOTE]
> Command will use dynamic instrumentation for all subprocesses which is available on Windows (x86, x64 and Arm64), Linux (x64), and macOS (x64). If you need to statically instrument any .NET module use `instrument` command (with corresponding session ID option) before executing `connect` command.

### Synopsis

```console
dotnet-coverage connect
    <session> <command> <args>...
    [-b|--background] [-t|--timeout]
    [-l|--log-file <log-file>] [-ll|--log-level <log-level>]
    [-dco|--disable-console-output] [--nologo]
    [-?|-h|--help]
```

### Arguments

* **`<session>`**

  The session ID of the server hosted by the `collect` command.

* **`<command>`**

  The command for which to collect code coverage data.

* **`<args>`**

  The command line arguments for the command.

### Options

* **`-b|--background`**

  Starts the client in a new background process.

* **`-t|--timeout`**

  Timeout (in milliseconds) for interprocess communication between the client and the server.* **`-l|--log-file <log-file>`**

* **`-l|--log-file <log-file>`**

  Sets the log file path. When you provide a directory (with a path separator at the end), a new log file is generated for each process under analysis.

* **`-ll|--log-level <log-level>`**

  Sets the log level. Supported values: `Error`, `Info`, and  `Verbose`.

* **`-dco|--disable-console-output`**

  Disables console output.

* **`--nologo`**

  Do not display Code Coverage banner.

## dotnet-coverage snapshot

Creates a coverage file for existing code coverage collection.

### Synopsis

```console
dotnet-coverage snapshot
    <session>
    [-r|--reset]
    [-tn|--tag-name <tag-name>] [-tid|--tag-identifier <tag-identifier>]
    [-o|--output <output>]
    [-t|--timeout]
    [-l|--log-file <log-file>] [-ll|--log-level <log-level>]
    [-dco|--disable-console-output] [--nologo]
    [-?|-h|--help]
```

### Arguments

* **`<session>`**

  The session ID of the collection for which a coverage file is to be generated.

### Options

* **`-r|--reset <reset>`**

  Clears existing coverage information after a coverage file is created.

* **`-tn|--tag-name <tag-name>`**

  Creates a snapshot tag name in the coverage file with current coverage information. Tag-name and tag-identifier are mutually inclusive.

* **`-tid|--tag-identifier <tag-identifier>`**

  Creates a snapshot tag identifier in the coverage file with current coverage information. Tag-name and tag-identifier are mutually inclusive.

* **`-o|--output <output>`**

  Sets the code coverage report output file. If not provided, it's generated automatically with a timestamp.

* **`-t|--timeout`**

  Timeout (in milliseconds) for interprocess communication between the client and the server.

* **`-l|--log-file <log-file>`**

  Sets the log file path. When you provide a directory (with a path separator at the end), a new log file is generated for each process under analysis.

* **`-ll|--log-level <log-level>`**

  Sets the log level. Supported values: `Error`, `Info`, and  `Verbose`.

* **`-dco|--disable-console-output`**

  Disables console output.

* **`--nologo`**

  Do not display Code Coverage banner.

## dotnet-coverage shutdown

Closes existing code coverage collection.

### Synopsis

```console
dotnet-coverage shutdown
    <session>
    [-t|--timeout]
    [-l|--log-file <log-file>] [-ll|--log-level <log-level>]
    [-dco|--disable-console-output] [--nologo]
    [-?|-h|--help]
```

### Arguments

* **`<session>`**

  The session ID of the collection to be closed.

### Options

* **`-t|--timeout`**

  Timeout (in milliseconds) for interprocess communication with the server.

* **`-l|--log-file <log-file>`**

  Sets the log file path. When you provide a directory (with a path separator at the end), a new log file is generated for each process under analysis.

* **`-ll|--log-level <log-level>`**

  Sets the log level. Supported values: `Error`, `Info`, and  `Verbose`.

* **`-dco|--disable-console-output`**

  Disables console output.

* **`--nologo`**

  Do not display Code Coverage banner.

## dotnet-coverage instrument

The instrument command is used to instrument binary on disk.

### Synopsis

```console
dotnet-coverage instrument
    <input-file>
    [-s|--settings <settings>] [-id|--session-id <session-id>]
    [-o|--output <output>]
    [-l|--log-file <log-file>] [-ll|--log-level <log-level>]
    [-dco|--disable-console-output] [--nologo]
    [-?|-h|--help]
```

### Arguments

* **`<input-file>`**

  The input binary.

### Options

* **`-s|--settings <settings>`**

  Sets the path to the XML code coverage settings.

* **`-id|--session-id <session-id>`**

  Specifies the code coverage session ID. If not provided, the tool will generate a random GUID.

* **`-o|--output <output>`**

  Sets the path to output file binary. If not provided, instrumentation will be performed in-place.

* **`-l|--log-file <log-file>`**

  Sets the log file path. When you provide a directory (with a path separator at the end), a new log file is generated for each process under analysis.

* **`-ll|--log-level <log-level>`**

  Sets the log level. Supported values: `Error`, `Info`, and  `Verbose`.

* **`-dco|--disable-console-output`**

  Disables console output.

* **`--nologo`**

  Do not display Code Coverage banner.

## dotnet-coverage uninstrument

The uninstrument command is used to restore original binary from the instrumented binary.

### Synopsis

```console
Microsoft.CodeCoverage.Console uninstrument
    <input-file>
    [-s|--settings <settings>]
    [-l|--log-file <log-file>] [-ll|--log-level <log-level>]
    [-dco|--disable-console-output] [--nologo]
    [-?|-h|--help]
```

### Arguments

* **`<input-file>`**

  The input instrumented binary.

### Options

* **`-s|--settings <settings>`**

  Sets the path to the XML code coverage settings.

* **`-l|--log-file <log-file>`**

  Sets the log file path. When you provide a directory (with a path separator at the end), a new log file is generated for each process under analysis.

* **`-ll|--log-level <log-level>`**

  Sets the log level. Supported values: `Error`, `Info`, and  `Verbose`.

* **`-dco|--disable-console-output`**

  Disables console output.

* **`--nologo`**

  Do not display Code Coverage banner.

## Sample scenarios

## Collecting code coverage

Collect code coverage data for any .NET application (such as console or Blazor) by using the following command:

```console
dotnet-coverage collect dotnet run
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

Also, a snapshot tag can be added to the coverage file using tag options as follows:

```console
dotnet-coverage snapshot --tag-name after_first_test --tag-identifier after_first_test serverdemo
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

### Server and client mode

Code coverage collection can be done in server-client mode as well. In this scenario, a code coverage collection server starts, and multiple clients can connect with the server. Code coverage is collected for all the clients collectively.

Start the code coverage server using the following command:

```condole
dotnet-coverage collect --session-id serverdemo --server-mode
```

In this example, the session ID was specified as `serverdemo` for the server. A client can connect to the server using this session ID using the following command:

```condole
dotnet-coverage connect serverdemo dotnet run
```

Finally, you can close the session `serverdemo` and the server using the following command:

```console
dotnet-coverage shutdown serverdemo
```

The server process creates a collective code coverage report for all clients and exits.

Following is an example of full output on the server side:

```console
D:\serverexample\server> dotnet-coverage collect --session-id serverdemo --server-mode
SessionId: serverdemo
// Server will be in idle state and wait for connect and shutdown commands
Code coverage results: output.coverage.
D:\serverexample\server>
```

Following is an example of full output on the client side:

```console
D:\serverexample\server> dotnet-coverage connect serverdemo ConsoleApplication.exe World
Hello World!!
D:\serverexample\server> dotnet-coverage connect serverdemo WpfApplication.exe
D:\serverexample\server> dotnet-coverage shutdown serverdemo
D:\serverexample\server>
```

You can also start both server and client in background mode. Another process starts in the background and returns control back to the user.

Following is an example of full output in background server client mode:

```console
D:\serverexample\server> dotnet-coverage collect --session-id serverdemo --server-mode --background
D:\serverexample\server> dotnet-coverage connect --background serverdemo ConsoleApplication.exe World
D:\serverexample\server> dotnet-coverage connect --background serverdemo WpfApplication.exe
D:\serverexample\server> dotnet-coverage shutdown serverdemo
D:\serverexample\server>
```

## Static code coverage for managed assemblies

The dotnet-coverage tool can be used to collect code coverage for managed assemblies using static instrumentation. There are three different methods available that you can use. To demonstrate, let's assume we have a simple C# console application:

```console
D:\examples\ConsoleApp> dotnet run
Hello, World!
```

### Use collect command with include files option or configuration

If you don't want to use the `instrument` command, then the files to be instrumented can be specified using `--include-files` option as follows:

```console
D:\examples\ConsoleApp> dotnet-coverage collect --include-files .\bin\Debug\net7.0\*.dll dotnet run
Microsoft (R) Code Coverage Command Line Tool (x64)
Copyright (c) Microsoft Corporation. All rights reserved.

SessionId: 57862ec0-e512-49a5-8b66-2804174680fc
Hello, World!
Code coverage results: output.coverage.
```

You can also specify files to be instrumented using configuration as follows:

```xml
<ModulePaths>
  <IncludeDirectories>
    <Directory>D:\examples\ConsoleApp\bin\Debug\net7.0</Directory>
  </IncludeDirectories>
</ModulePaths>
```

### Using instrument and collect commands

In this case, first binary needs to be instrumented as follows:

```console
D:\examples\ConsoleApp> dotnet-coverage instrument .\bin\Debug\net7.0\ConsoleApp.dll
Microsoft (R) Code Coverage Command Line Tool (x64)
Copyright (c) Microsoft Corporation. All rights reserved.

Input file successfully instrumented.
```

Then you can collect code coverage as follows:

```console
D:\examples\ConsoleApp> dotnet-coverage collect .\bin\Debug\net7.0\ConsoleApp.exe
Microsoft (R) Code Coverage Command Line Tool (x64)
Copyright (c) Microsoft Corporation. All rights reserved.

SessionId: a09e6bef-ff64-4b5f-8bb8-fc495ebb50ba
Hello, World!
Code coverage results: output.coverage.
```

### Use the instrument and collect commands in server mode

In this case, you can completely separate coverage collection from running your application. First, instrument your binary as follows:

```console
D:\examples\ConsoleApp> dotnet-coverage instrument --session-id 73c34ce5-501c-4369-a4cb-04d31427d1a4 .\bin\Debug\net7.0\ConsoleApp.dll
Microsoft (R) Code Coverage Command Line Tool (x64)
Copyright (c) Microsoft Corporation. All rights reserved.

Input file successfully instrumented.
```

> [!NOTE]
> Session ID needs to be used in this scenario to make sure that the application can connect and provide data to external collector.

In the second step, you need to start coverage collector as follows:

```console
D:\examples\ConsoleApp> dotnet-coverage collect --session-id 73c34ce5-501c-4369-a4cb-04d31427d1a4 --server-mode
Microsoft (R) Code Coverage Command Line Tool (x64)
Copyright (c) Microsoft Corporation. All rights reserved.

SessionId: 73c34ce5-501c-4369-a4cb-04d31427d1a4
```

Then the application can be started as follows:

```console
D:\examples\ConsoleApp> .\bin\Debug\net7.0\ConsoleApp.exe
Hello, World!
```

Finally, the collector can be closed as follows:

```console
D:\examples\ConsoleApp> dotnet-coverage shutdown 73c34ce5-501c-4369-a4cb-04d31427d1a4
Microsoft (R) Code Coverage Command Line Tool (x64)
Copyright (c) Microsoft Corporation. All rights reserved.
```

### Settings

You can specify a file with settings when you use the `collect` command. The settings file can be used to exclude some modules or methods from code coverage analysis. The format is the same as the data collector configuration inside a *runsettings* file. For more information, see [Customize code coverage analysis](/visualstudio/test/customizing-code-coverage-analysis). Here's an example:

```xml
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
            <!-- Additional directories from .NET assemblies should be statically instrumented: -->
            <IncludeDirectories>
                <Directory Recursive="true">C:\temp</Directory>
            </IncludeDirectories>
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

        <EnableStaticManagedInstrumentation>True</EnableStaticManagedInstrumentation>
        <EnableDynamicManagedInstrumentation>True</EnableDynamicManagedInstrumentation>

    </CodeCoverage>
</Configuration>
```

## Merge code coverage reports

You can merge `a.coverage` and `b.coverage` and store the data in `merged.coverage` as follows:

```console
dotnet-coverage merge -o merged.coverage a.coverage b.coverage
```

For example, if you run a command like `dotnet test --collect "Code Coverage"`, the coverage report is stored into a folder that is named a random GUID. Such folders are hard to find and merge. Using this tool, you can merge all code coverage reports for all your projects using globbing patterns as follows:

```console
dotnet-coverage merge -o merged.cobertura.xml -f cobertura **\*.coverage
```

The preceding command merges all coverage reports from the current directory and all subdirectories and stores the result into a cobertura file. In Azure Pipelines, you can use [Publish Code Coverage Results task](/azure/devops/pipelines/tasks/test/publish-code-coverage-results) to publish a merged cobertura report.

You can use the `merge` command to convert a code coverage report to another format. For example, the following command converts a binary code coverage report into XML format.

```console
dotnet-coverage merge -o output.xml -f xml input.coverage
```

## See also

* [Customize code coverage analysis](/visualstudio/test/customizing-code-coverage-analysis)
* [Publish Code Coverage Results task](/azure/devops/pipelines/tasks/test/publish-code-coverage-results)
