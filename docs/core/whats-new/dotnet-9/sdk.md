---
title: What's new in the SDK for .NET 9
description: Learn about the new .NET SDK features introduced in .NET 9.
titleSuffix: ""
ms.date: 04/11/2024
ms.topic: overview
---
# What's new in the SDK for .NET 9

This article describes new features in the .NET SDK for .NET 9. It's been updated for .NET 9 Preview 3.

## Unit testing

This section describes the updates to unit testing in .NET 9: running tests in parallel, and terminal logger test output.

### Run tests in parallel

In .NET 9, `dotnet test` is more fully integrated with MSBuild. Because MSBuild supports [building in parallel](/visualstudio/msbuild/building-multiple-projects-in-parallel-with-msbuild), you can run tests for the same project across different target frameworks in parallel. By default, MSBuild limits the number of parallel processes to the number of processors on the computer. You can also set your own limit using the [-maxcpucount](/visualstudio/msbuild/building-multiple-projects-in-parallel-with-msbuild#-maxcpucount-switch) switch. If you want to opt out of the parallelism, set the `TestTfmsInParallel` MSBuild property to `false`.

### Terminal logger test display

Test result reporting for [`dotnet test`](../../tools/dotnet-test.md) is now supported directly in the MSBuild terminal logger. You get more fully featured test reporting both *while* tests are running (displays the running test name) and *after* tests are completed (any test errors are rendered in a better way).

For more information about the terminal logger, see [dotnet build options](../tools/dotnet-build.md#options).

## .NET tool roll-forward

[.NET tools](../../tools/global-tools.md) are framework-dependent apps that you can install globally or locally, then run using the .NET SDK and installed .NET runtimes. These tools, like all .NET apps, target a specific major version of .NET. By default, apps don't run on *newer* versions of .NET. Tool authors have been able to opt in to running their tools on newer versions of the .NET runtime by setting the `RollForward` MSBuild property. However, not all tools do so.

A new option for [`dotnet tool install`](../../tools/dotnet-tool-install.md) lets *users* decide how .NET tools should be run. When you install a tool via `dotnet tool install`, or when you run tool via [`dotnet tool run <toolname>`](../../tools/dotnet-tool-run.md), you can specify a new flag called `--allow-roll-forward`. This option configures the tool with roll-forward mode `Major`. This mode allows the tool to run on a newer major version of .NET if the matching .NET version is not available. This feature helps early adopters use .NET tools without tool authors having to change any code.

## Terminal logger usability

The terminal logger now summarizes the total count of failures and warnings at the end of a build. It also shows errors that contain newlines. (For more information about the terminal logger, see ['dotnet build' options](../../../tools/dotnet-build.md#options), specifically the `--tl` option.)

Consider the following project file that emits a warning when the project is built:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>

  <Target Name="Error" BeforeTargets="Build">
    <Warning Code="ECLIPSE001" Text="Black Hole Sun, won't you come
  And wash away the rain
    Black Hole Sun, won't you come
      won't you come" />
  </Target>
</Project>
```

When you run `dotnet build -tl` on the .NET 8 SDK, the output is as shown following this paragraph. Each line of the multi-line warning is a separate line with a full error message prefix in the output, which is hard to read. Also, the final build summary says that there *were* warnings, but not *how many* there were. The missing information can make it hard to determine if a particular build is better or worse than previous builds.

```terminal
$ dotnet build -tl
MSBuild version 17.8.5+b5265ef37 for .NET
Restore complete (0.5s)
  multiline-error-example succeeded with warnings (0.2s) → bin\Debug\net8.0\multiline-error-example.dll
    E:\Code\multiline-error-example.csproj(11,5): warning ECLIPSE001: Black Hole Sun, won't you come
E:\Code\multiline-error-example.csproj(11,5): warning ECLIPSE001:   And wash away the rain
E:\Code\multiline-error-example.csproj(11,5): warning ECLIPSE001:     Black Hole Sun, won't you come
E:\Code\multiline-error-example.csproj(11,5): warning ECLIPSE001:       won't you come
Build succeeded with warnings in 0.9s
```

When you build the same project using the .NET 9 SDK, the output is as follows:

```terminal
> dotnet build -tl
Restore complete (0.4s)
You are using a preview version of .NET. See: https://aka.ms/dotnet-support-policy
  multiline-error-example succeeded with 3 warning(s) (0.2s) → bin\Debug\net8.0\multiline-error-example.dll
    E:\Code\multiline-error-example.csproj(11,5): warning ECLIPSE001:
      Black Hole Sun, won't you come
        And wash away the rain
          Black Hole Sun, won't you come
            won't you come
Build succeeded with 3 warning(s) in 0.8s
```

The message lines of the warning no longer have the repeated project and location information that clutter the display. In addition, the build summary shows how many warnings (and errors, if there are any) were generated during the build.

If you have feedback about the terminal logger, you can provide it in the [MSBuild repository](https://github.com/dotnet/msbuild/issues).
