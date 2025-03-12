---
title: Use Microsoft.Testing.Platform with `dotnet test`
description: Learn how to run Microsoft.Testing.Platform tests through dotnet test.
author: nohwnd
ms.author: jajares
ms.date: 12/20/2023
---

# Use Microsoft.Testing.Platform with `dotnet test`

This article describes how to use `dotnet test` to run tests when using `Microsoft.Testing.Platform`, and the various options that are available to configure the MSBuild output produced when running tests through Microsoft.Testing.Platform.

This article shows how to use `dotnet test` to run all tests in a solution (_*.sln_) that uses `Microsoft.Testing.Platform`.

## `dotnet test` integration

The [dotnet test](../tools/dotnet-test.md) command is a way to run tests from solutions, projects, or already built assemblies. [Microsoft.Testing.Platform](microsoft-testing-platform-intro.md) hooks up into this infrastructure to provide a unified way to run tests, especially when migrating from VSTest to `Microsoft.Testing.Platform`.

### `dotnet test` integration - VSTest mode

`Microsoft.Testing.Platform` provides a [compatibility layer (VSTest Bridge)](./microsoft-testing-platform-extensions-vstest-bridge.md) to work with `dotnet test` seamlessly.

Tests can be run by running:

```dotnetcli
dotnet test
```

This layer runs test through VSTest and integrates with it on VSTest Test Framework Adapter level.

### `dotnet test` - Microsoft.Testing.Platform mode

By default, `dotnet test` is using VSTest behavior to run tests. You can enable support for `Microsoft.Testing.Platform` in `dotnet test` by specifying the `<TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>` setting in your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <IsPackable>false</IsPackable>

    <OutputType>Exe</OutputType>
    <EnableMSTestRunner>true</EnableMSTestRunner>

    <!-- Add this to your project file. -->
    <TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>

  </PropertyGroup>

  <!-- ... -->

</Project>
```

> [!NOTE]
> It's highly recommended that you set the `TestingPlatformDotnetTestSupport` property in `Directory.Build.props`. That way, you don't have to add it to every test project file, and you don't risk introducing a new project that doesn't set this property and end up with a solution where some projects are VSTest while others are Microsoft.Testing.Platform, which may not work correctly and is unsupported scenario.

> [!IMPORTANT]
> Despite `TestingPlatformDotnetTestSupport` being set to `true`, most of the command line options defined in [dotnet test](../tools/dotnet-test.md) remain VSTest oriented and don't impact `Microsoft.Testing.Platform` based tests. To supply arguments to `Microsoft.Testing.Platform`, you need to use one of the methods described in [Microsoft.Testing.Platform command line arguments with dotnet test](#microsofttestingplatform-command-line-arguments-with-dotnet-test).

The list below described all `dotnet test` command line options that are supported by `Microsoft.Testing.Platform`:

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

These arguments are supported because they are linked to the build step and are independent of the testing platform used.

### `Microsoft.Testing.Platform` command line arguments with `dotnet test`

You can supply arguments that are used to call the testing application in one of the following ways:

- Beginning with `Microsoft.Testing.Platform` version 1.4 (included with MSTest version 3.6), you can add options after the double dash `--` on the command line:

    ```dotnetcli
    dotnet test -- --minimum-expected-tests 10
    ```

- By using the `TestingPlatformCommandLineArguments` MSBuild property on the command line:

    ```dotnetcli
    dotnet test -p:TestingPlatformCommandLineArguments="--minimum-expected-tests 10"
    ```

  Or in the project file:

  ```xml
  <PropertyGroup>
    ...
    <TestingPlatformCommandLineArguments>--minimum-expected-tests 10</TestingPlatformCommandLineArguments>
  </PropertyGroup>
  ```

## Additional MSBuild options

The MSBuild integration provides options that can be specified in the project file or through global properties on the command line, such as `-p:TestingPlatformShowTestsFailure=true`.

These are the available options:

- [Show failure per test](#show-failure-per-test)
- [Show complete platform output](#show-complete-platform-output)

### Show failure per test

By default, test failures are summarized into a _.log_ file, and a single failure per test project is reported to MSBuild.

To show errors per failed test, specify `-p:TestingPlatformShowTestsFailure=true` on the command line, or add the `<TestingPlatformShowTestsFailure>true</TestingPlatformShowTestsFailure>` property to your project file.

On command line:

```dotnetcli
dotnet test -p:TestingPlatformShowTestsFailure=true
```

Or in project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <IsPackable>false</IsPackable>

    <OutputType>Exe</OutputType>
    <EnableMSTestRunner>true</EnableMSTestRunner>

    <TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>

    <!-- Add this to your project file. -->
    <TestingPlatformShowTestsFailure>true</TestingPlatformShowTestsFailure>

  </PropertyGroup>

  <!-- ... -->

</Project>
```

### Show complete platform output

By default, all console output that the underlying test executable writes is captured and hidden from the user. This includes the banner, version information, and formatted test information.

To show this information together with MSBuild output, use `<TestingPlatformCaptureOutput>false</TestingPlatformCaptureOutput>`.

This option doesn't impact how the testing framework captures user output written by `Console.WriteLine` or other similar ways to write to the console.

On command line:

```dotnetcli
dotnet test -p:TestingPlatformCaptureOutput=false
```

Or in project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <IsPackable>false</IsPackable>

    <OutputType>Exe</OutputType>
    <EnableMSTestRunner>true</EnableMSTestRunner>

    <TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>

    <!-- Add this to your project file. -->
    <TestingPlatformCaptureOutput>false</TestingPlatformCaptureOutput>

  </PropertyGroup>

  <!-- ... -->

</Project>
```

> [!IMPORTANT]
> All examples above add properties like `EnableMSTestRunner`, `TestingPlatformDotnetTestSupport`, and `TestingPlatformCaptureOutput` in the csproj file. However, it's highly recommended that you set these properties in `Directory.Build.props`. That way, you don't have to add it to every test project file, and you don't risk introducing a new project that doesn't set these properties and end up with a solution where some projects are VSTest while others are Microsoft.Testing.Platform, which may not work correctly and is unsupported scenario.
