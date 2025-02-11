---
title: MSTest runner overview
description: Learn about the MSTest runner, a lightweight way to run tests without depending on the .NET SDK.
author: nohwnd
ms.author: jajares
ms.date: 12/15/2023
---

# MSTest runner overview

The MSTest runner is a lightweight and portable alternative to [VSTest](https://github.com/microsoft/vstest) for running tests in all contexts (for example, continuous integration (CI) pipelines, CLI, Visual Studio Test Explorer, and VS Code Test Explorer). The MSTest runner is embedded directly in your MSTest test projects, and there are no other app dependencies, such as `vstest.console` or `dotnet test`, needed to run your tests.

The MSTest runner is open source, and builds on a [`Microsoft.Testing.Platform`](./unit-testing-platform-intro.md) library. You can find `Microsoft.Testing.Platform` code in [microsoft/testfx](https://github.com/microsoft/testfx/tree/main/src/Platform/Microsoft.Testing.Platform) GitHub repository. The MSTest runner comes bundled with `MSTest in 3.2.0-preview.23623.1` or newer.

## Enable MSTest runner in an MSTest project

It's recommended to use [MSTest SDK](./unit-testing-mstest-sdk.md) as it greatly simplifies your project configuration and updating the project, and it ensures a proper alignment of the versions of the platform (MSTest runner) and its extensions.

When you use `MSTest SDK`, by default you're opted in to using MSTest runner.

```xml
<Project Sdk="MSTest.Sdk/3.3.1">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

Alternatively, you can enable MSTest runner by adding the `EnableMSTestRunner` property and setting `OutputType` to `Exe` in your project file. You also need to ensure that you're using `MSTest 3.2.0-preview.23623.1` or newer.

Consider the following example project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <!-- Enable the MSTest runner, this is an opt-in feature -->
    <EnableMSTestRunner>true</EnableMSTestRunner>
    <OutputType>Exe</OutputType>

    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <IsPackable>false</IsPackable>
    <IsTestProject>true</IsTestProject>
  </PropertyGroup>

  <ItemGroup>
    <!--
      MSTest meta package is the recommended way to reference MSTest.
      It's equivalent to referencing:
          Microsoft.NET.Test.Sdk
          MSTest.TestAdapter
          MSTest.TestFramework
          MSTest.Analyzers
    -->
    <PackageReference Include="MSTest" Version="3.2.0" />

    <!--
      Coverlet collector isn't compatible with MSTest runner, you can
      either switch to Microsoft CodeCoverage (as shown below),
      or switch to be using coverlet global tool
      https://github.com/coverlet-coverage/coverlet#net-global-tool-guide-suffers-from-possible-known-issue
    -->
    <PackageReference Include="Microsoft.Testing.Extensions.CodeCoverage"
                      Version="17.10.1" />
  </ItemGroup>

</Project>
```

> [!TIP]
> It's advised to set the `EnableMSTestRunner` property in *Directory.Build.props* file instead of *csproj* file to ensure all test projects in your solution are using the MSTest runner.

## Configurations and filters

### .runsettings

The MSTest runner supports the [runsettings](unit-testing-platform-extensions-vstest-bridge.md#runsettings-support) through the command-line option `--settings`. For the full list of supported MSTest entries, see [Configure MSTest: Runsettings](./unit-testing-mstest-configure.md#runsettings). The following commands show various usage examples.

Using `dotnet run`:

```dotnetcli
dotnet run --project Contoso.MyTests -- --settings config.runsettings
```

Using `dotnet exec`:

```dotnetcli
dotnet exec Contoso.MyTests.dll --settings config.runsettings
```

-or-

```dotnetcli
dotnet Contoso.MyTests.dll --settings config.runsettings
```

Using the executable:

```dotnetcli
Contoso.MyTests.exe --settings config.runsettings
```

### Tests filter

You can provide the tests [filter](selective-unit-tests.md?pivots=mstest#mstest-examples) seamlessly using the command line option `--filter`. The following commands show some examples.

Using `dotnet run`:

```dotnetcli
dotnet run --project Contoso.MyTests -- --filter "FullyQualifiedName~UnitTest1|TestCategory=CategoryA"
```

Using `dotnet exec`:

```dotnetcli
dotnet exec Contoso.MyTests.dll --filter "FullyQualifiedName~UnitTest1|TestCategory=CategoryA"
```

-or-

```dotnetcli
dotnet Contoso.MyTests.dll --filter "FullyQualifiedName~UnitTest1|TestCategory=CategoryA"
```

Using the executable:

```dotnetcli
Contoso.MyTests.exe --filter "FullyQualifiedName~UnitTest1|TestCategory=CategoryA"
```
