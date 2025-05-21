---
title: Testing with 'dotnet test'
description: Learn more about how 'dotnet test' works and its support for VSTest and Microsoft.Testing.Platform (MTP)
author: Youssef1313
ms.author: ygerges
ms.date: 03/26/2025
ms.topic: concept-article
---

# Testing with 'dotnet test'

This article provides insights into the `dotnet test` CLI command, including its history compatibility with both VSTest and Microsoft.Testing.Platform (MTP).

The `dotnet test` command operates in two primary modes:

- *VSTest* mode: This is the default mode for `dotnet test` and was the only mode available before the .NET 10 SDK. It is primarily designed for VSTest but can also run Microsoft.Testing.Platform test via [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild/) NuGet package.
- *Microsoft.Testing.Platform* mode: Introduced with the .NET 10 SDK, this mode exclusively supports test applications built with Microsoft.Testing.Platform.

> [!TIP]
> For CLI reference, see [dotnet test](../tools/dotnet-test.md).

## VSTest mode of `dotnet test`

For a long time, VSTest was the only test platform in .NET. Consequently, `dotnet test` was exclusively designed for VSTest, with all command-line options tailored to VSTest.

The process involves invoking the `VSTest` MSBuild target, which triggers other internal targets to run and ultimately runs vstest.console. All `dotnet test` command-line options are translated to their equivalents in vstest.console.

### Run MTP projects with VSTest mode

`dotnet test` was designed to run VSTest projects in VSTest mode. However, you can run MTP projects in `dotnet test` VSTest mode by using the [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild) package. From the user's perspective, this support is enabled by setting the `TestingPlatformDotnetTestSupport` MSBuild property to `true` (it's `false` by default for backward-compatibility reasons). When this property is set to `true`, Microsoft.Testing.Platform.MSBuild changes the `VSTest` target behavior, redirecting it to call `InvokeTestingPlatform`. `InvokeTestingPlatform` is an MSBuild target included in Microsoft.Testing.Platform.MSBuild that's responsible for correctly running MTP test applications as executables. VSTest-specific command-line options, such as `--logger`, are silently ignored in this mode. To include MTP-specific arguments, such as `--report-trx`, you must append them after an additional `--`. For example, `dotnet test -- --report-trx`.

> [!NOTE]
> MSTest and NUnit use the [Microsoft.Testing.Extensions.VSTestBridge](https://www.nuget.org/packages/Microsoft.Testing.Extensions.VSTestBridge) package. By setting `EnableMSTestRunner` or `EnableNUnitRunner` (which enables Microsoft.Testing.Platform), your test project will support both VSTest and Microsoft.Testing.Platform.
> In that scenario, if you use the VSTest mode of `dotnet test` and do not set `TestingPlatformDotnetTestSupport` to true, you are essentially running entirely with VSTest, as if `EnableMSTestRunner` and `EnableNUnitRunner` are not set to true.
>
> [!NOTE]
> It is highly recommended to set the `TestingPlatformDotnetTestSupport` property in `Directory.Build.props`. This ensures that you don't need to add it to every test project file individually. Additionally, it prevents the risk of introducing a new test project that doesn't set this property, which could result in a solution where some projects use VSTest while others use Microsoft.Testing.Platform. This mixed configuration might not work correctly and is an unsupported scenario.

The following list outlines the command-line options of `dotnet test` command in VSTest mode that are supported by Microsoft.Testing.Platform. These options are specific to the build process and not passed down to VSTest, which is why they work with MTP.

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

> [!TIP]
> You can customize the command-line arguments of your test application via `TestingPlatformCommandLineArguments` MSBuild property:
>
> ```xml
> <PropertyGroup>
>   ...
>   <TestingPlatformCommandLineArguments>--minimum-expected-tests 10</TestingPlatformCommandLineArguments>
> </PropertyGroup>
> ```

For more information specific to running MTP projects in VSTest mode of `dotnet test`, see [Use Microsoft.Testing.Platform with VSTest mode of `dotnet test`](./microsoft-testing-platform-integration-dotnet-test.md).

#### Advanced technical details

In `dotnet test` VSTest mode, the `--` is used to indicate the RunSettings arguments. Originally, `dotnet test` was designed to pass those arguments as an MSBuild property called `VSTestCLIRunSettings`. Therefore, when running MTP test applications in VSTest mode, we repurpose the value of `VSTestCLIRunSettings` to represent the "application arguments".

#### Mixing VSTest and Microsoft.Testing.Platform (MTP)

When running `dotnet test` in VSTest mode, it is recommended to avoid including both VSTest and Microsoft.Testing.Platform in the same solution.

This scenario is not officially supported, and you should be aware of the following:

- VSTest-specific command-line options will only apply to VSTest projects and not to MTP test applications.
- MTP-specific command-line options provided after `--` will be treated as RunSettings arguments for VSTest projects.

#### Key takeaways

- To run MTP test applications in `dotnet test` VSTest mode, you should use `Microsoft.Testing.Platform.MSBuild`, pass MTP-specific command-line options after the extra `--`, and set `TestingPlatformDotnetTestSupport` to `true`.
- VSTest-oriented command-line options are silently ignored.

Due to these issues, .NET has introduced a new `dotnet test` mode specifically designed for MTP. We encourage MTP users to transition from the VSTest `dotnet test` mode to the new mode with the .NET 10 SDK.

## Microsoft.Testing.Platform (MTP) mode of `dotnet test`

To address the issues encountered when running `dotnet test` with MTP in VSTest mode, .NET introduced a new mode in the .NET 10 SDK that's specifically designed for MTP.

To enable this mode, add a `dotnet.config` file to the root of the repository or solution.

```ini
[dotnet.test:runner]
name = "Microsoft.Testing.Platform"
```

> [!NOTE]
> The format will change from `dotnet.test:runner` to `dotnet.test.runner` in .NET 10 SDK Preview 4.

Since this mode is specifically designed for Microsoft.Testing.Platform, neither `TestingPlatformDotnetTestSupport` nor the additional `--` are required.

> [!IMPORTANT]
> This mode is only compatible with Microsoft.Testing.Platform version 1.7.0 and later.
>
> [!IMPORTANT]
> If your test project supports VSTest but does not support MTP, an error will be generated.
>
> [!TIP]
> You can customize the command-line arguments of your test application via `TestingPlatformCommandLineArguments` MSBuild property:
>
> ```xml
> <PropertyGroup>
>   ...
>   <TestingPlatformCommandLineArguments>--minimum-expected-tests 10</TestingPlatformCommandLineArguments>
> </PropertyGroup>
> ```
