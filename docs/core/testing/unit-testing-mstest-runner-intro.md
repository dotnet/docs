---
title: Microsoft.Testing.Platform support in MSTest (MSTest runner)
description: Learn about the MSTest runner, a lightweight way to run tests without depending on the .NET SDK.
author: nohwnd
ms.author: jajares
ms.date: 12/15/2023
ms.topic: article
---

# Microsoft.Testing.Platform support in MSTest (MSTest runner)

MSTest supports running tests with both VSTest and [Microsoft.Testing.Platform (MTP)](./microsoft-testing-platform-intro.md). The support for MTP is powered by the MSTest runner, which can run tests in all contexts (for example, continuous integration (CI) pipelines, CLI, Visual Studio Test Explorer, and VS Code Text Explorer). The MSTest runner is embedded directly in your MSTest test projects, and there are no other app dependencies, such as `vstest.console` or `dotnet test`, needed to run your tests. However, you can still run your tests using `dotnet test`.

The MSTest runner is open source and builds on the [`Microsoft.Testing.Platform`](./microsoft-testing-platform-intro.md) library. You can find `Microsoft.Testing.Platform` code in the [microsoft/testfx](https://github.com/microsoft/testfx/tree/main/src/Platform/Microsoft.Testing.Platform) GitHub repository. The MSTest runner comes bundled with `MSTest in 3.2.0` or newer.

## Enable Microsoft.Testing.Platform in an MSTest project

It's recommended to use [MSTest SDK](./unit-testing-mstest-sdk.md) as it greatly simplifies your project configuration and updating the project, and it ensures a proper alignment of the versions of the platform (Microsoft.Testing.Platform) and its extensions.

When you use `MSTest SDK`, by default you're opted in to using Microsoft.Testing.Platform.

```xml
<Project Sdk="MSTest.Sdk/3.8.2">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

Alternatively, you can enable MSTest runner by adding the `EnableMSTestRunner` property and setting `OutputType` to `Exe` in your project file. You also need to ensure that you're using `MSTest 3.2.0` or newer. We strongly recommend you update to the latest MSTest version available.

Consider the following example project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <!-- Enable Microsoft.Testing.Platform, this is an opt-in feature -->
    <EnableMSTestRunner>true</EnableMSTestRunner>
    <TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>

    <!--
      Displays error on console in addition to the log file. Note that this feature comes with a performance impact.
      For more information, visit https://learn.microsoft.com/dotnet/core/testing/microsoft-testing-platform-integration-dotnet-test#show-failure-per-test
      -->
    <TestingPlatformShowTestsFailure>true</TestingPlatformShowTestsFailure>

    <OutputType>Exe</OutputType>

    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <!--
      MSTest meta package is the recommended way to reference MSTest.
      It's equivalent to referencing:
          Microsoft.NET.Test.Sdk
          MSTest.TestAdapter
          MSTest.TestFramework
          MSTest.Analyzers
      Starting with 3.8, it also includes:
          Microsoft.Testing.Extensions.TrxReport
          Microsoft.Testing.Extensions.CodeCoverage
    -->
    <PackageReference Include="MSTest" Version="3.8.0" />

    <!--
      Coverlet collector isn't compatible with Microsoft.Testing.Platform, you can
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
> To ensure all test projects in your solution use the MSTest runner, set the `EnableMSTestRunner` and `TestingPlatformDotnetTestSupport` properties in *Directory.Build.props* file instead of individual project files.

## Configurations and filters

### .runsettings

Microsoft.Testing.Platform supports the [runsettings](microsoft-testing-platform-extensions-vstest-bridge.md#runsettings-support) through the command-line option `--settings`. For the full list of supported MSTest entries, see [Configure MSTest: Runsettings](./unit-testing-mstest-configure.md#runsettings). The following commands show various usage examples.

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
