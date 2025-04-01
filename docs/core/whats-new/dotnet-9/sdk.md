---
title: What's new in the SDK and tooling for .NET 9
description: Learn about the new .NET SDK features introduced in .NET 9, including for unit testing, terminal logger, tool roll-forward, and build script analyzers.
titleSuffix: ""
ms.date: 11/11/2024
ms.topic: whats-new
---

# What's new in the SDK and tooling for .NET 9

This article describes new features in the .NET SDK and tooling for .NET 9.

## Unit testing

This section describes the updates to unit testing in .NET 9: running tests in parallel, and terminal logger test output.

### Run tests in parallel

In .NET 9, `dotnet test` is more fully integrated with MSBuild. Because MSBuild supports [building in parallel](/visualstudio/msbuild/building-multiple-projects-in-parallel-with-msbuild), you can run tests for the same project across different target frameworks in parallel. By default, MSBuild limits the number of parallel processes to the number of processors on the computer. You can also set your own limit using the [-maxcpucount](/visualstudio/msbuild/building-multiple-projects-in-parallel-with-msbuild#-maxcpucount-switch) switch. If you want to opt out of the parallelism, set the `TestTfmsInParallel` MSBuild property to `false`.

### Terminal logger test display

Test result reporting for [`dotnet test`](../../tools/dotnet-test.md) is now supported directly in the MSBuild terminal logger. You get more fully featured test reporting both _while_ tests are running (displays the running test name) and _after_ tests are completed (any test errors are rendered in a better way).

For more information about the terminal logger, see [dotnet build options](../../tools/dotnet-build.md#options).

## .NET tool roll-forward

[.NET tools](../../tools/global-tools.md) are framework-dependent apps that you can install globally or locally, then run using the .NET SDK and installed .NET runtimes. These tools, like all .NET apps, target a specific major version of .NET. By default, apps don't run on _newer_ versions of .NET. Tool authors have been able to opt in to running their tools on newer versions of the .NET runtime by setting the `RollForward` MSBuild property. However, not all tools do so.

A new option for [`dotnet tool install`](../../tools/dotnet-tool-install.md) lets _users_ decide how .NET tools should be run. When you install a tool via `dotnet tool install`, or when you run tool via [`dotnet tool run <toolname>`](../../tools/dotnet-tool-run.md), you can specify a new flag called `--allow-roll-forward`. This option configures the tool with roll-forward mode `Major`. This mode allows the tool to run on a newer major version of .NET if the matching .NET version is not available. This feature helps early adopters use .NET tools without tool authors having to change any code.

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

When you run `dotnet build -tl` on the .NET 8 SDK, the output is as shown following this paragraph. Each line of the multi-line warning is a separate line with a full error message prefix in the output, which is hard to read. Also, the final build summary says that there _were_ warnings, but not _how many_ there were. The missing information can make it hard to determine if a particular build is better or worse than previous builds.

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

## Faster NuGet dependency resolution for large repos

The NuGet dependency resolver has been overhauled to improve performance and scalability for all `<PackageReference>` projects. Enabled by default, the new algorithm speeds up restore operations without compromising on functionality, strictly adhering to the core dependency resolution rules.

If you encounter any issues, such as restore failures or unexpected package versions, you can [revert to the legacy resolver](/nuget/consume-packages/Package-References-in-Project-Files#nuget-dependency-resolver).

## MSBuild script analyzers ("BuildChecks")

.NET 9 introduces a feature that helps guard against defects and regressions in your build scripts. To run the build checks, add the `/check` flag to any command that invokes MSBuild. For example, `dotnet build myapp.sln /check` builds the `myapp` solution and runs all configured build checks.

The .NET 9 SDK includes a small number of initial checks, for example, [BC0101](../../tools/buildcheck-rules/bc0101.md) and [BC0102](../../tools/buildcheck-rules/bc0102.md). For a complete list, see [BuildCheck codes](https://github.com/dotnet/msbuild/blob/main/documentation/specs/BuildCheck/Codes.md).

When a problem is detected, a diagnostic is produced in the build output for the project that contains the issue.

For more information, see the [design documentation](https://github.com/dotnet/msbuild/blob/main/documentation/specs/BuildCheck/BuildCheck.md).

## Analyzer mismatch

Many users install the .NET SDK and Visual Studio at different cadences. While this flexibility is desirable, it can lead to problems for tooling that needs to interop between the two environments. One example of this kind of tooling is Roslyn Analyzers. Analyzer authors have to code for specific versions of Roslyn, but which versions are available and which is used by a given build is sometimes unclear.

This kind of version mismatch between the .NET SDK and MSBuild is referred to as a _torn SDK_. When you're in this state, you might see errors like this:

> CSC : warning CS9057: The analyzer assembly '..\dotnet\sdk\8.0.200\Sdks\Microsoft.NET.Sdk.Razor\source-generators\Microsoft.CodeAnalysis.Razor.Compiler.SourceGenerators.dll' references version '4.9.0.0' of the compiler, which is newer than the currently running version '4.8.0.0'.

.NET 9 can detect and automatically adjust for this problem scenario. The SDK's MSBuild logic embeds the version of MSBuild it shipped with, and that information can be used to detect when the SDK is running in an environment with a different version. When that happens, the SDK inserts an implicit download of a support package called Microsoft.Net.Sdk.Compilers.Toolset that ensures a consistent analyzer experience.

## Workload sets

_Workload sets_ is an SDK feature intended to give users more control over the workloads they install and the cadence of change of those workloads. In previous versions, workloads were periodically updated as new versions of individual workloads were released onto any configured NuGet feeds. Now, _all_ of your workloads stay at a specific, single version until you make an explicit update gesture.

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

In this example, the SDK installation is in 'manifest' mode, where updates are installed as they're available. To opt in to the new mode, add a `--version` option to a `dotnet workload install` or `dotnet workload update` command. You can also explicitly control your mode of operation using the new `dotnet workload config` command:

```dotnetcli
> dotnet workload config --update-mode workload-set
Successfully updated workload install mode to use workload-set.
```

If you need to change back for any reason, you can run the same command with `manifests` instead of `workload-set`. You can also use `dotnet workload config --update-mode` to check the current mode of operation.

For more information, see [.NET SDK workload sets](../../tools/dotnet-workload-sets.md).

## Workload history

.NET SDK workloads are an integral part of .NET MAUI and Blazor WebAssembly. In their default configuration, you can update workloads independently as .NET tooling authors release new versions. In addition, .NET SDK installations done through Visual Studio install a parallel set of versions. Without taking care, the workload installation status of a given .NET SDK installation can drift over time, but there hasn't been a way to visualize this drift.

To address this, .NET 9 adds a new `dotnet workload history` command to the .NET SDK. `dotnet workload history` prints out a table of the history of workload installations and modifications for the current .NET SDK installation. The table shows the date of the installation or modification, the command that was run, the workloads that were installed or modified, and the relevant versions for the command. This output can help you understand the drift in workload installations over time, and help you make informed decisions about which workloads versions to set your installation to. You can think of it as `git reflog` for workloads.

```dotnetcli
> dotnet workload history

Id  Date                         Command       Workloads                                        Global.json Version  Workload Version
-----------------------------------------------------------------------------------------------------------------------------------------------
1   1/1/0001 12:00:00 AM +00:00  InitialState  android, ios, maccatalyst, maui-windows                               9.0.100-manifests.6d3c8f5d
2   9/4/2024 8:15:33 PM -05:00   install       android, aspire, ios, maccatalyst, maui-windows                       9.0.100-rc.1.24453.3
```

In this example, the SDK was initially installed with the `android`, `ios`, `maccatalyst`, and `maui-windows` workloads. Then, the `dotnet workload install aspire --version 9.0.100-rc.1.24453.3` command was used to install the `aspire` workload and switch to [workload sets mode](../../tools/dotnet-workload-sets.md). To return to the previous state, you can use the ID from the first column in the history table, for example, `dotnet workload update --from-history 1`.

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

## Code analysis

.NET 9 includes several new code analyzers and fixers to help verify that you're using .NET library APIs correctly and efficiently. The following table summarizes the new analyzers.

| Rule ID | Category | Description |
|---------|----------|-------------|
| [CA1514: Avoid redundant length argument](../../../fundamentals/code-analysis/quality-rules/ca1514.md) | Maintainability | An explicitly calculated length argument can be error-prone and is unnecessary when you're slicing to the end of a string or buffer. |
| [CA1515: Consider making public types internal](../../../fundamentals/code-analysis/quality-rules/ca1515.md) | Maintainability | Types inside an executable assembly should be declared as `internal`. |
| [CA1871: Do not pass a nullable struct to 'ArgumentNullException.ThrowIfNull'](../../../fundamentals/code-analysis/quality-rules/ca1871.md) | Performance | For improved performance, it's better to check the `HasValue` property and manually throw an exception than to pass a nullable struct to `ArgumentNullException.ThrowIfNull`. |
| [CA1872: Prefer 'Convert.ToHexString' and 'Convert.ToHexStringLower' over call chains based on 'BitConverter.ToString'](../../../fundamentals/code-analysis/quality-rules/ca1872.md) | Performance | Use <xref:System.Convert.ToHexString*?displayProperty=nameWithType> or <xref:System.Convert.ToHexStringLower*?displayProperty=nameWithType> when encoding bytes to a hexadecimal string representation. |
| [CA2022: Avoid inexact read with Stream.Read](../../../fundamentals/code-analysis/quality-rules/ca2022.md) | Reliability | A call to `Stream.Read` might return fewer bytes than requested, resulting in unreliable code if the return value isn't checked. |
| [CA2262: Set 'MaxResponseHeadersLength' properly](../../../fundamentals/code-analysis/quality-rules/ca2262.md) | Usage | The <xref:System.Net.Http.HttpClientHandler.MaxResponseHeadersLength?displayProperty=nameWithType> property is measured in kilobytes, not bytes. |
| [CA2263: Prefer generic overload when type is known](../../../fundamentals/code-analysis/quality-rules/ca2263.md) | Usage | Generic overloads are preferable to overloads that accept an argument of type <xref:System.Type?displayProperty=fullName> when the type is known at compile time. |
| [CA2264: Do not pass a non-nullable value to 'ArgumentNullException.ThrowIfNull'](../../../fundamentals/code-analysis/quality-rules/ca2264.md) | Usage | Certain constructs like non-nullable structs (except for <xref:System.Nullable%601>), 'nameof()' expressions, and 'new' expressions are known to never be null, so `ArgumentNullException.ThrowIfNull` will never throw. |
| [CA2265: Do not compare `Span<T>` to null or default](../../../fundamentals/code-analysis/quality-rules/ca2265.md) | Usage | Comparing a span to `null` or `default` might not do what you intended. `default` and the `null` literal are implicitly converted to <xref:System.Span`1.Empty?displayProperty=nameWithType>. Remove the redundant comparison or make the code more explicit by using `IsEmpty`. |
