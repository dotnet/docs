---
title: Get started with MSTest
description: Learn how to create your first MSTest project and run tests.
author: Evangelink
ms.author: amauryleve
ms.date: 07/24/2024
---

# Get started with MSTest

The recommended way to create an MSTest project is to use the [MSTest.Sdk](https://www.nuget.org/packages/MSTest.Sdk), an [MSBuild project SDK](/visualstudio/msbuild/how-to-use-project-sdk) that provides a first-class experience for testing with MSTest. It includes all the recommended defaults and simplifies the project configuration.

## Create a project with MSTest.Sdk

To create an MSTest project, set the `Sdk` attribute to `MSTest.Sdk` in your project file:

```xml
<Project Sdk="MSTest.Sdk/4.1.0">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
  </PropertyGroup>

</Project>
```

> [!NOTE]
> `/4.1.0` is given as an example and can be replaced with any newer version.

To simplify version management across multiple test projects, we recommend specifying the SDK version in a _global.json_ file at the solution level:

```xml
<Project Sdk="MSTest.Sdk">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
  </PropertyGroup>

</Project>
```

```json
{
    "msbuild-sdks": {
        "MSTest.Sdk": "4.1.0"
    }
}
```

For more information, see [Use MSBuild project SDKs](/visualstudio/msbuild/how-to-use-project-sdk#how-project-sdks-are-resolved).

When you `build` the project, all needed components are restored and installed using the standard NuGet workflow. You can use the same tooling (for example, `dotnet test` or Visual Studio) as any other test project.

> [!TIP]
> By default, MSTest.Sdk uses the [MSTest runner with Microsoft.Testing.Platform](./unit-testing-mstest-running-tests.md). For advanced configuration options such as extension profiles, switching to VSTest, or integrating with Aspire and Playwright, see [MSTest SDK configuration](./unit-testing-mstest-sdk.md).

## Alternative: Use the MSTest NuGet package

If you prefer not to use MSTest.Sdk, you can use the [MSTest](https://www.nuget.org/packages/MSTest) NuGet meta-package, which includes:

- `MSTest.TestFramework`, `MSTest.TestAdapter`, and `MSTest.Analyzers` for core MSTest functionality
- `Microsoft.NET.Test.Sdk` for VSTest integration and test host support
- `Microsoft.Testing.Extensions.CodeCoverage` and `Microsoft.Testing.Extensions.TrxReport` for Microsoft Testing Platform extensions

## NuGet packages overview

MSTest functionality is split across multiple NuGet packages:

| Package | Description |
|---------|-------------|
| [MSTest.TestFramework](https://www.nuget.org/packages/MSTest.TestFramework) | Contains the attributes and classes used to define MSTest tests |
| [MSTest.TestAdapter](https://www.nuget.org/packages/MSTest.TestAdapter) | Contains the test adapter that discovers and runs MSTest tests |
| [MSTest.Analyzers](https://www.nuget.org/packages/MSTest.Analyzers) | Contains analyzers that help you write high-quality tests |

> [!NOTE]
> If you're creating a test infrastructure project intended as a helper library for multiple test projects, install `MSTest.TestFramework` and `MSTest.Analyzers` directly into that project.

## Language-specific tutorials

For detailed step-by-step tutorials in your preferred .NET language:

- [Getting started with C#](unit-testing-csharp-with-mstest.md): Create your first C# test project and write basic tests
- [Getting started with F#](unit-testing-fsharp-with-mstest.md): Test F# code with MSTest
- [Getting started with Visual Basic](unit-testing-visual-basic-with-mstest.md): Test Visual Basic code with MSTest

## Sample projects

The MSTest team maintains sample projects in the [microsoft/testfx repository](https://github.com/microsoft/testfx/tree/main/samples/public) demonstrating various features and scenarios:

| Sample | Description | Link |
|--------|-------------|------|
| **Simple1** | Basic MSTest runner setup | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/Simple1) |
| **DemoMSTestSdk** | MSTest SDK project setup | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/DemoMSTestSdk) |
| **BlankUwpNet9App** | UWP testing with .NET 9 | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/BlankUwpNet9App) |
| **BlankWinUINet9App** | WinUI 3 testing with .NET 9 | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/BlankWinUINet9App) |
| **NativeAotRunner** | Native AOT compilation | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/NativeAotRunner) |
| **RunInDocker** | Containerized test execution | [View on GitHub](https://github.com/microsoft/testfx/tree/main/samples/public/mstest-runner/RunInDocker) |
