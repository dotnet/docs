---
title: Testing with dotnet test
description: Learn more about how dotnet test works and its support for VSTest and Microsoft.Testing.Platform (MTP)
author: Youssef1313
ms.author: ygerges
ms.date: 03/26/2025
---

# Testing with dotnet test

In this article, you'll learn more about `dotnet test` CLI command, some history, and its support for VSTest and Microsoft.Testing.Platform (MTP).

The `dotnet test` command has two main modes of operations:

- VSTest mode: This is the default mode of `dotnet test`, and it's the only mode available before .NET 10 SDK. It's designed towards VSTest, but it can also run Microsoft.Testing.Platform via [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild/) NuGet package.
- Microsoft.Testing.Platform mode: This is available starting with .NET 10 SDK, and only supports Microsoft.Testing.Platform test applications.

> [!TIP]
> For CLI reference, see [dotnet test](../tools/dotnet-test.md).

## VSTest mode of `dotnet test`

For too long, VSTest has been the only test platform in .NET. As a result, `dotnet test` was designed only for VSTest. All the command-line options are VSTest oriented.

It works by invoking `VSTest` MSBuild target, which causes other internal targets to run and eventually runs vstest.console, translating all the `dotnet test` command-line options to equivalent in vstest.console.

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

To opt-in this mode, you should add `dotnet.config` file in the root of the repository or the solution:

```toml
[dotnet.test:runner]
name = "Microsoft.Testing.Platform"
```

As this mode is designed for Microsoft.Testing.Platform, both `TestingPlatformDotnetTestSupport` and the extra `--` are no longer required.

> [!IMPORTANT]
> This mode is only compatible for Microsoft.Testing.Platform 1.7.0 and later.
>
> [!IMPORTANT]
> If you have a test project that supports VSTest and doesn't support MTP, an error is produced.
