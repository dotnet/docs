---
title: NUnit runner overview
description: Learn about the NUnit runner, a lightweight way to run tests without depending on the .NET SDK.
author: Evangelink
ms.author: amauryleve
ms.date: 05/21/2024
---

# NUnit runner overview

The NUnit runner is a lightweight and portable alternative to [VSTest](https://github.com/microsoft/vstest) for running tests in all contexts (for example, continuous integration (CI) pipelines, CLI, Visual Studio Test Explorer, and VS Code Text Explorer). The NUnit runner is embedded directly in your NUnit test projects, and there are no other app dependencies, such as `vstest.console` or `dotnet test`, needed to run your tests.

The NUnit runner is open source, and builds on a [`Microsoft.Testing.Platform`](./unit-testing-platform-intro.md) library. You can find `Microsoft.Testing.Platform` code in [microsoft/testfx](https://github.com/microsoft/testfx/tree/main/src/Platform/Microsoft.Testing.Platform) GitHub repository. The NUnit runner comes bundled with `NUnit 5.0.0-beta.2` or newer.

## Enable NUnit runner in a NUnit project

You can enable NUnit runner by adding the `EnableNUnitRunner` property and setting `OutputType` to `Exe` in your project file. You also need to ensure that you're using `NUnit 5.0.0-beta.2` or newer.

Consider the following example project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <!-- Enable the NUnit runner, this is an opt-in feature -->
    <EnableNUnitRunner>true</EnableNUnitRunner>
    <OutputType>Exe</OutputType>

    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <IsPackable>false</IsPackable>
    <IsTestProject>true</IsTestProject>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.9.0" />
    <PackageReference Include="NUnit" Version="4.1.0" />
    <PackageReference Include="NUnit.Analyzers" Version="4.2.0">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="NUnit3TestAdapter" Version="5.0.0-beta.2" />

    <!--
      Coverlet collector isn't compatible with NUnit runner, you can
      either switch to Microsoft CodeCoverage (as shown below),
      or switch to be using coverlet global tool
      https://github.com/coverlet-coverage/coverlet#net-global-tool-guide-suffers-from-possible-known-issue
    -->
    <PackageReference Include="Microsoft.Testing.Extensions.CodeCoverage"
                      Version="17.10.1" />
  </ItemGroup>

</Project>
```

## Configurations and filters

### .runsettings

The NUnit runner supports the [runsettings](unit-testing-platform-extensions-vstest-bridge.md#runsettings-support) through the command-line option `--settings`. The following commands show examples.

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

You can provide the tests [filter](selective-unit-tests.md?pivots=nunit#nunit-examples) seamlessly using the command line option `--filter`. The following commands show some examples.

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
