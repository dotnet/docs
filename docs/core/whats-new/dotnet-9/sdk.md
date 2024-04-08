---
title: What's new in the SDK and tooling for .NET 9
description: Learn about the new .NET SDK and tooling features introduced in .NET 9.
titleSuffix: ""
ms.date: 04/08/2024
ms.topic: overview
ms.custom: linux-related-content
---
# What's new in the SDK and tooling for .NET 9

This article describes new features in the .NET SDK and tooling for .NET 9.

## Unit testing

This section describes the updates to unit testing in .NET 9: running tests in parallel, and terminal logger test output.

### Run tests in parallel

In .NET 9, `dotnet test` is more fully integrated with MSBuild. Because MSBuild supports [building in parallel](/visualstudio/msbuild/building-multiple-projects-in-parallel-with-msbuild), you can run tests for the same project across different target frameworks in parallel. By default, MSBuild limits the number of parallel processes to the number of processors on the computer. You can also set your own limit using the [-maxcpucount](/visualstudio/msbuild/building-multiple-projects-in-parallel-with-msbuild#-maxcpucount-switch) switch. If you want to opt out of the parallelism, set the `TestTfmsInParallel` MSBuild property to `false`.

### Terminal logger test display

Test result reporting for [`dotnet test`](../../tools/dotnet-test.md) is now supported directly in the MSBuild terminal logger. You get more fully featured test reporting both *while* tests are running (displays the running test name) and *after* tests are completed (any test errors are rendered in a better way).

For more information about the terminal logger, see [dotnet build options](../../tools/dotnet-build.md#options).

## .NET tool roll-forward

[.NET tools](../../tools/global-tools.md) are framework-dependent apps that you can install globally or locally, then run using the .NET SDK and installed .NET runtimes. These tools, like all .NET apps, target a specific major version of .NET. By default, apps don't run on *newer* versions of .NET. Tool authors have been able to opt in to running their tools on newer versions of the .NET runtime by setting the `RollForward` MSBuild property. However, not all tools do so.

A new option for [`dotnet tool install`](../../tools/dotnet-tool-install.md) lets *users* decide how .NET tools should be run. When you install a tool via `dotnet tool install`, or when you run tool via [`dotnet tool run <toolname>`](../../tools/dotnet-tool-run.md), you can specify a new flag called `--allow-roll-forward`. This option configures the tool with roll-forward mode `Major`. This mode allows the tool to run on a newer major version of .NET if the matching .NET version is not available. This feature helps early adopters use .NET tools without tool authors having to change any code.
