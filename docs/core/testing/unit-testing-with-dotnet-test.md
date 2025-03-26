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

This means that VSTest-spcific command-line options are silently ignored in this mode. For example, `--logger`.

This also means there should be a way to pass MTP-specific command-line options. For example, `--report-trx` (which is the equivalent of doing `--logger trx` in VSTest). As we are limited by what the `dotnet test` CLI currently has, the only way to get MTP-specific arguments is to add them after extra `--`. For example, `dotnet test -- --report-trx`.

#### Advanced technical details

The `--` in `dotnet test` VSTest mode is used to denote RunSettings arguments. The way `dotnet test` was originally designed is to forward those RunSettings arguments as an MSBuild property named `VSTestCLIRunSettings`. So, when running MTP test applications in VSTest mode, we are using the value of `VSTestCLIRunSettings` for another purpose to denote "application arguments".

#### Mixing VSTest and MTP

When running `dotnet test` in VSTest mode, we advise against having both VSTest and Microsoft.Testing.Platform in the same solution.

This scenario is not officially supported, and you should pay attention to:

1. VSTest-specific command-line options will only be considered for VSTest projects but not MTP test applications.
2. MTP-specific command-line options after `--` will be considered as RunSettings arguments for VSTest projects.

#### Key takeaways

1. To run MTP test applications in `dotnet test` VSTest mode, you should be using `Microsoft.Testing.Platform.MSBuild`, be passing MTP-specific command-line options after extra `--`, and setting `TestingPlatformDotnetTestSupport` to true.
2. VSTest-oriented command-line options are silently ignored.
3. Due to the above issues, we introduce a new `dotnet test` mode that is designed for MTP, and we encourage MTP users to move out of the VSTest `dotnet test` mode to the new mode with .NET 10 SDK.

## MTP mode of `dotnet test`

Due to the problems of running `dotnet test` with MTP in VSTest mode, we introduced a new mode of `dotnet test` in .NET 10 SDK, which is designed for MTP specifically.

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
