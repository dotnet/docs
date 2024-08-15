---
title: What's new in the SDK for .NET 9
description: Learn about the new .NET SDK features introduced in .NET 9, including for unit testing, terminal logger, tool roll-forward, and build script analyzers.
titleSuffix: ""
ms.date: 08/15/2024
ms.topic: whats-new
---
# What's new in the SDK for .NET 9

This article describes new features in the .NET SDK for .NET 9. It's been updated for .NET 9 Preview 7.

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

## Terminal logger

The terminal logger is now [enabled by default](#enabled-by-default) and also has [improved usability](#usability).

### Enabled by default

Starting in .NET 9, the default experience for all .NET CLI commands that use MSBuild is terminal logger, the enhanced logging experience that was released in .NET 8. This new output uses the capabilities of modern terminals to provide functionality like:

- Clickable links
- Duration timers for MSBuild tasks
- Color coding of warning and error messages

The output is more condensed and usable than the existing MSBuild console logger.

The new logger attempts to auto-detect if it can be used, but you can also manually control whether terminal logger is used. Specify the `--tl:off` command-line option to disable terminal logger for a specific command. Or, to disable terminal logger more broadly, set the `MSBUILDTERMINALLOGGER` environment variable to `off`.

The set of commands that uses terminal logger by default is:

- `build`
- `clean`
- `msbuild`
- `pack`
- `publish`
- `restore`
- `test`

### Usability

The terminal logger now summarizes the total count of failures and warnings at the end of a build. It also shows errors that contain newlines. (For more information about the terminal logger, see ['dotnet build' options](../../tools/dotnet-build.md#options), specifically the `--tl` option.)

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

## NuGet security audits

Starting in .NET 8, `dotnet restore` [audits NuGet package references for known vulnerabilities](../../tools/dotnet-restore.md#audit-for-security-vulnerabilities). In .NET 9, the default mode has changed from auditing only *direct* package references to auditing both *direct* and *transitive* package references.

## MSBuild script analyzers ("BuildChecks")

.NET 9 introduces a feature that helps guard against defects and regressions in your build scripts. To run the build-check analyzers, add the `/analyze` flag to any command that invokes MSBuild. For example, `dotnet build myapp.sln /analyze` builds the `myapp` solution and runs all configured build checks.

The following two BuildCheck rules are run:

- [BC0101](../../tools/buildcheck-rules/bc0101.md)
- [BC0102](../../tools/buildcheck-rules/bc0102.md)

When a problem is detected, a diagnostic is produced in the build output for the project that contains the issue.

For more information, see the [design documentation](https://github.com/dotnet/msbuild/blob/main/documentation/specs/BuildCheck/BuildCheck.md).

## Analyzer mismatch

Many users install the .NET SDK and Visual Studio at different cadences. While this flexibility is desirable, it can lead to problems for tooling that needs to interop between the two environments. One example of this kind of tooling is Roslyn Analyzers. Analyzer authors have to code for specific versions of Roslyn, but which versions are available and which is used by a given build is sometimes unclear.

This kind of version mismatch between the .NET SDK and MSBuild is referred to as a *torn SDK*. When you're in this torn state, you might see errors like this:

> CSC : warning CS9057: The analyzer assembly '..\dotnet\sdk\8.0.200\Sdks\Microsoft.NET.Sdk.Razor\source-generators\Microsoft.CodeAnalysis.Razor.Compiler.SourceGenerators.dll' references version '4.9.0.0' of the compiler, which is newer than the currently running version '4.8.0.0'.

.NET 9 can detect and automatically adjust for this torn state. The SDK's MSBuild logic embeds the version of MSBuild it shipped with, and that information can be used to detect when the SDK is running in an environment with a different version. When that happens, the SDK inserts an implicit download of a support package called Microsoft.Net.Sdk.Compilers.Toolset that ensures a consistent analyzer experience.

## Workload sets

*Workload sets* is an SDK feature intended to give users more control over the workloads they install and the cadence of change of those workloads. In previous versions, workloads would periodically be updated as new versions of individual workloads were released onto any configured NuGet feeds. Now, *all* of your workloads will stay at a specific, single version until you make an explicit update gesture.

You can see what mode your SDK installation is in by running `dotnet workload --info`:

```dotnetcli
> dotnet workload --info
Workload version: 9.0.100-manifests.400dd185
Configured to use loose manifests when installing new manifests.
 [aspire]
   Installation Source: VS 17.10.35027.167, VS 17.11.35111.106
   Manifest Version:    8.0.2/8.0.100
   Manifest Path:       C:\Program Files\dotnet\sdk-manifests\8.0.100\microsoft.net.sdk.aspire\8.0.2\WorkloadManifest.json
   Install Type:              Msi
```

In this example, the SDK installation is in 'manifest' mode, where updates are installed as they're available. To opt into the new mode, add a `--version` option to a `dotnet workload install` or `dotnet workload update` command. You can also explicitly control your mode of operation using the new `dotnet workload config` command:

```dotnetcli
> dotnet workload config --update-mode workload-set
Successfully updated workload install mode to use workload-set.
```

If you need to change back for any reason, you can run the same command with `manifests` instead of `workload-set`. You can also use `dotnet workload config --update-mode` to check the current mode of operation.

<!-- Add link to ../../tools/dotnet-workload-sets.md -->

## Containers

- [Publishing support for insecure registries](#publishing-support-for-insecure-registries)
- [Environment variable naming](#environment-variable-naming)

### Publishing support for insecure registries

The SDK's built-in container publishing support can publish images to container registries. Until .NET 9, those registries were required to be secured&mdash;for the .NET SDK to work, they needed HTTPS support and valid certificates. Container engines can usually be configured to work with insecure registries as well, that is, registries that don't have TLS configured, or have TLS configured with a certificate that's invalid. This is a valid use case, but our tooling didn't support this mode of communication.

Starting in .NET 9, the SDK can communicate with insecure registries.

Requirements (depending on your environment):

- Configure the Docker CLI to mark a registry as insecure.
- Configure Podman to mark a registry as insecure.
- Use the `DOTNET_CONTAINER_INSECURE_REGISTRIES` environment variable to pass a semicolon-delimited list of registry domains to treat as insecure.

### Environment variable naming

Environment variables that the container publish tooling uses to control some of the finer aspects of registry communication and security now start with the prefix `DOTNET` instead of `SDK`. The `SDK` prefix will continue to be supported in the near term.
