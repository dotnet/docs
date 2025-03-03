---
title: Microsoft.Testing.Platform and VSTest comparison
description: Learn the differences between Microsoft.Testing.Platform and VSTest, such as namespaces, NuGet packages, and executables.
author: nohwnd
ms.author: jajares
ms.date: 12/15/2023
---

# Microsoft.Testing.Platform and VSTest comparison

`Microsoft.Testing.Platform` is a lightweight and portable alternative to [VSTest](https://github.com/microsoft/vstest) for running tests in command line, in continuous integration (CI) pipelines, in Visual Studio Test Explorer, and in Visual Studio Code. In this article, you learn the key differences between Microsoft.Testing.Platform and VSTest.

## Differences in test execution

Tests are executed in different ways depending on the runner.

### Execute VSTest tests

VSTest ships with Visual Studio, the .NET SDK, and as a standalone tool in the [Microsoft.TestPlatform](https://www.nuget.org/packages/Microsoft.TestPlatform) NuGet package. VSTest uses a runner executable to run tests, called `vstest.console.exe`, which can be used directly or through `dotnet test`.

### Execute Microsoft.Testing.Platform tests

Microsoft.Testing.Platform is embedded directly into your test project and doesn't ship any extra executables. When you run your project executable, your tests run. For more information on running Microsoft.Testing.Platform tests, see [Microsoft.Testing.Platform overview: Run and debug tests](unit-testing-platform-intro.md#run-and-debug-tests).

## Namespaces and NuGet packages

To familiarize yourself with `Microsoft.Testing.Platform` and VSTest, it's helpful to understand the namespaces and NuGet packages that are used by each.

### VSTest namespaces

VSTest is a collection of testing tools that are also known as the _Test Platform_. The VSTest source code is open-source and available in the [microsoft/vstest](https://github.com/microsoft/vstest) GitHub repository. The code uses the `Microsoft.TestPlatform.*` namespace.

VSTest is extensible and common types are placed in [Microsoft.TestPlatform.ObjectModel](https://www.nuget.org/packages/Microsoft.TestPlatform.ObjectModel) NuGet package.

### Microsoft.Testing.Platform namespaces

Microsoft.Testing.Platform is based on [Microsoft.Testing.Platform](https://www.nuget.org/packages/Microsoft.Testing.Platform) NuGet package and other libraries in the `Microsoft.Testing.*` namespace. Like VSTest, the `Microsoft.Testing.Platform` is open-source and has a [microsoft/testfx](https://github.com/microsoft/testfx/tree/main/src/Platform/Microsoft.Testing.Platform) GitHub repository.

## Communication protocol (preview)

> [!NOTE]
> The Visual Studio Test Explorer supports the Microsoft.Testing.Platform protocol in the **preview** versions since 17.10 onward. If you run/debug your tests using earlier versions of Visual Studio, Test Explorer will use `vstest.console.exe` and the old protocol to run these tests.

Microsoft.Testing.Platform uses a JSON-RPC based protocol to communicate between Visual Studio and the test runner process. The protocol is documented in the [MSTest GitHub repository](https://github.com/microsoft/testfx/tree/main/docs/mstest-runner-protocol).

VSTest also uses a JSON based communication protocol, but it's not JSON-RPC based.

### Disabling the new protocol

To disable the use of the new protocol in Test Explorer, you can edit your project to add the following property: `<DisableTestingPlatformServerCapability>true</DisableTestingPlatformServerCapability>`.

## Executables

VSTest ships multiple executables, notably `vstest.console.exe`, `testhost.exe`, and `datacollector.exe`. However, MSTest is embedded directly into your test project and doesn't ship any other executables. The executable your test project compiles to is used to host all the testing tools and carry out all the tasks needed to run tests.

## Migrating from VSTest

In addition to the steps specific to your test framework, you need to update your test infrastructure to accommodate to `Microsoft.Testing.Platform`.

### `dotnet test`

Command line options of `dotnet test` are divided into 2 categories: build related arguments and test related ones.

The build related arguments are passed to the `dotnet build` command and as such don't need to be updated for the new platform. Build related arguments are listed below:

- `-a|--arch <ARCHITECTURE>`
- `--artifacts-path <ARTIFACTS_DIR>`
- `-c|--configuration <CONFIGURATION>`
- `-f|--framework <FRAMEWORK>`
- `-e|--environment <NAME="VALUE">`
- `--interactive`
- `--no-build`
- `--nologo`
- `--no-restore`
- `-o|--output <OUTPUT_DIRECTORY>`
- `--os <OS>`
- `-r|--runtime <RUNTIME_IDENTIFIER>`
- `-v|--verbosity <LEVEL>`

The test related arguments are VSTest specific and so need to be transformed to match the new platform. The following table shows the mapping between the VSTest arguments and the new platform:

| VSTest argument | New platform argument |
|-----------------|-----------------------|
| `--test-adapter-path <ADAPTER_PATH>` | Not supported |
| `--blame` | Not supported |
| `--blame-crash` | `--crashdump` requires [Crash dump extension](./unit-testing-platform-extensions-diagnostics.md#crash-dump) |
| `--blame-crash-dump-type <DUMP_TYPE>` | `--crashdump-type` requires [Crash dump extension](./unit-testing-platform-extensions-diagnostics.md#crash-dump) |
| `--blame-crash-collect-always` | Not supported |
| `--blame-hang` | `--hangdump` requires [Hang dump extension](./unit-testing-platform-extensions-diagnostics.md#hang-dump) |
| `--blame-hang-dump-type <DUMP_TYPE>` | `--hangdump-type` requires [Hang dump extension](./unit-testing-platform-extensions-diagnostics.md#hang-dump) |
| `--blame-hang-timeout <TIMESPAN>` | `--hangdump-timeout` requires [Hang dump extension](./unit-testing-platform-extensions-diagnostics.md#hang-dump) |
| `--collect <DATA_COLLECTOR_NAME>` | Depends on the data collector |
| `-d\|--diag <LOG_FILE>` | `--diagnostic` |
| `--filter <EXPRESSION>` | Depends upon the selected test framework |
| `-l\|--logger <LOGGER>` | Depends on the logger |
| `--results-directory <RESULTS_DIR>` | `--results-directory <RESULTS_DIR>` |
| `-s\|--settings <SETTINGS_FILE>` | Depends upon the selected test framework |
| `-t\|--list-tests` | `--list-tests` |
| `-- <RunSettings arguments>` | Not supported |

> [!IMPORTANT]
> Before specifying any `Microsoft.Testing.Platform` arguments, you need to add `--` to separate the `dotnet test` arguments from the new platform arguments. For example, `dotnet test --no-build -- --list-tests`.

### `vstest.console.exe`

If you are using `vstest.console.exe` directly, we recommend replacing it with the `dotnet test` command.

### Test Explorer

When using Visual Studio or Visual Studio Code Test Explorer, you might need to enable the support for the new test platform.

#### Visual Studio

Visual Studio Test Explorer supports the new test platform starting with version 17.14. If you are using an earlier version, you might need to update your Visual Studio to the latest version.

#### Visual Studio Code

Visual Studio Code Test Explorer supports the new test platform starting with version X.

### Azure DevOps

When using Azure DevOps tasks, you might need to update your pipeline to use the new test platform.

#### VSTest task

If you're using the [VSTest task](/azure/devops/pipelines/tasks/reference/vstest-v3) in Azure DevOps, you can replace it with the [.NET Core task](/azure/devops/pipelines/tasks/reference/dotnet-core-cli-v2).

#### .NET Core task

If you're using the [.NET Core task](/azure/devops/pipelines/tasks/reference/dotnet-core-cli-v2), no changes are needed.
