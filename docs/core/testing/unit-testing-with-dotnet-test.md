---
title: Testing with dotnet test
description: Learn more about how dotnet test works and its support for VSTest and Microsoft.Testing.Platform (MTP)
author: Youssef1313
ms.author: ygerges
ms.date: 03/26/2025
---

# Testing with dotnet test

This article will provide you with insights into the `dotnet test` CLI command, its history, and its compatibility with both VSTest and Microsoft.Testing.Platform (MTP).

The `dotnet test` command operates in two primary modes:

- VSTest mode: This is the default mode for `dotnet test` and was the only mode available before the .NET 10 SDK. It is primarily designed for VSTest but can also run Microsoft.Testing.Platform test via [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild/) NuGet package.
- Microsoft.Testing.Platform mode: Introduced with the .NET 10 SDK, this mode exclusively supports test applications built with Microsoft.Testing.Platform.

> [!TIP]
> For CLI reference, see [dotnet test](../tools/dotnet-test.md).

## VSTest mode of `dotnet test`

For an extended period, VSTest has been the only test platform in .NET. Consequently, dotnet test was exclusively designed for VSTest, with all command-line options tailored to VSTest.

The process involves invoking the `VSTest` MSBuild target, which triggers other internal targets to run and ultimately runs vstest.console. This translates all `dotnet test` command-line options to their equivalents in vstest.console.

### Running MTP projects with VSTest mode

`dotnet test` is normally capable to run VSTest projects in VSTest mode as that's what it was originally designed for. However, running MTP projects with VSTest mode is done via [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild). From user-end, the support is enabled by setting `TestingPlatformDotnetTestSupport` MSBuild property to true (it's false by default, for backward compatibility concerns). In simple words, setting this property to true will cause Microsoft.Testing.Platform.MSBuild to change the VSTest target behavior, and instead route it to call `InvokeTestingPlatform`, which is an MSBuild target shipped in Microsoft.Testing.Platform.MSBuild and is responsible to run MTP test applications the correct way (as executable).

This means that VSTest-specific command-line options are silently ignored in this mode, such as `--logger`.

This implies that there should be a way to pass MTP-specific command-line options, such as `--report-trx`, which is equivalent to using `--logger trx` in VSTest. Given the current limitations of the `dotnet test` CLI, the only way to include MTP-specific arguments is by appending them after an additional `--`. For instance, `dotnet test -- --report-trx`.

#### Advanced technical details

In `dotnet test` VSTest mode, the `--` is used to indicate the RunSettings arguments. Originally, `dotnet test` was designed to pass those arguments as an MSBuild property called `VSTestCLIRunSettings`. Therefore, when running MTP test applications in VSTest mode, we repurpose the value of `VSTestCLIRunSettings` to represent the "application arguments".

#### Mixing VSTest and Microsoft.Testing.Platform (MTP)

When running `dotnet test` in VSTest mode, it is recommended to avoid including both VSTest and Microsoft.Testing.Platform in the same solution.

This scenario is not officially supported, and you should be aware of the following:

1. VSTest-specific command-line options will only apply to VSTest projects and not to MTP test applications.
2. MTP-specific command-line options provided after `--` will be treated as RunSettings arguments for VSTest projects.

#### Key takeaways

1. To run MTP test applications in `dotnet test` VSTest mode, you should use `Microsoft.Testing.Platform.MSBuild`, pass MTP-specific command-line options after the extra --, and set `TestingPlatformDotnetTestSupport` to true.
2. VSTest-oriented command-line options are silently ignored.
3. Due to these issues, we have introduced a new `dotnet test` mode specifically designed for MTP. We encourage MTP users to transition from the VSTest `dotnet test` mode to the new mode with the .NET 10 SDK.

## Microsoft.Testing.Platform (MTP) mode of `dotnet test`

To address the issues encountered when running `dotnet test` with MTP in VSTest mode, we introduced a new mode in the .NET 10 SDK that is specifically designed for MTP.

To enable this mode, you should add a `dotnet.config` file to the root of the repository or solution.

```toml
[dotnet.test:runner]
name = "Microsoft.Testing.Platform"
```

Since this mode is specifically designed for Microsoft.Testing.Platform, neither `TestingPlatformDotnetTestSupport` nor the additional `--` are required.

> [!IMPORTANT]
> This mode is only compatible with Microsoft.Testing.Platform version 1.7.0 and later.
>
> [!IMPORTANT]
> If your test project supports VSTest but does not support MTP, an error will be generated.
