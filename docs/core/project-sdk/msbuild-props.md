---
title: MSBuild properties for Microsoft.NET.Sdk
description: Reference for the MSBuild properties that are understood by the .NET Core SDK.
ms.date: 02/14/2020
ms.topic: reference
---
# MSBuild properties for .NET Core SDK projects

This page describes MSBuild properties for configuring .NET Core projects.

> [!NOTE]
> This page is a work in progress and does not list all of the useful MSBuild properties for the .NET Core SDK. For a list of common MSBuild properties, see [Common MSBuild properties](/visualstudio/msbuild/common-msbuild-project-properties).

## Framework properties

- [TargetFramework](#targetframework)
- [TargetFrameworks](#targetframeworks)
- [NetStandardImplicitPackageVersion](#netstandardimplicitpackageversion)

### TargetFramework

The `TargetFramework` property specifies the target framework version for the app, which implicitly references a [metapackage](../packages.md#metapackages). For a list of valid target framework monikers, see [Target frameworks in SDK-style projects](../../standard/frameworks.md#supported-target-framework-versions).

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>
</Project>
```

For more information, see [Target frameworks in SDK-style projects](../../standard/frameworks.md).

### TargetFrameworks

Use the `TargetFrameworks` property when you want your app to target multiple platforms. For a list of valid target framework monikers, see [Target frameworks in SDK-style projects](../../standard/frameworks.md#supported-target-framework-versions).

> [!NOTE]
> This property is ignored if `TargetFramework` (singular) is specified.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>netcoreapp3.1;net462</TargetFrameworks>
  </PropertyGroup>
</Project>
```

For more information, see [Target frameworks in SDK-style projects](../../standard/frameworks.md).

### NetStandardImplicitPackageVersion

> [!NOTE]
> This property only applies to projects using `netstandard1.x`. It doesn't apply to projects that use `netstandard2.x`.

Use the `NetStandardImplicitPackageVersion` property when you want to specify a framework version that's lower than the [metapackage](../packages.md#metapackages) version. The project file in the following example targets `netstandard1.3` but uses the 1.6.0 version of `NETStandard.Library`.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netstandard1.3</TargetFramework>
    <NetStandardImplicitPackageVersion>1.6.0</NetStandardImplicitPackageVersion>
  </PropertyGroup>
</Project>
```

## Publish properties

- [RuntimeIdentifier](#runtimeidentifier)
- [RuntimeIdentifiers](#runtimeidentifiers)
- [TrimmerRootAssembly](#trimmerrootassembly)
- [UseAppHost](#useapphost)

### RuntimeIdentifier

The `RuntimeIdentifier` property lets you specify a single [runtime identifier (RID)](../rid-catalog.md) for the project. The RID enables publishing a self-contained deployment.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <RuntimeIdentifier>ubuntu.16.04-x64</RuntimeIdentifier>
  </PropertyGroup>
</Project>
```

### RuntimeIdentifiers

The `RuntimeIdentifiers` property lets you specify a semicolon-delimited list of [runtime identifiers (RIDs)](../rid-catalog.md) for the project. Use this property if you need to publish for multiple runtimes. `RuntimeIdentifiers` is used at restore time to ensure the right assets are in the graph.

> [!TIP]
> `RuntimeIdentifier` (singular) can provide faster builds when only a single runtime is required.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <RuntimeIdentifiers>win10-x64;osx.10.11-x64;ubuntu.16.04-x64</RuntimeIdentifiers>
  </PropertyGroup>
</Project>
```

### TrimmerRootAssembly

The `TrimmerRootAssembly` item lets you exclude an assembly from [*trimming*](../deploying/trim-self-contained.md). Trimming is the process of removing unused parts of the runtime from a packaged application. In some cases, trimming might incorrectly remove required references.

The following XML excludes the `System.Security` assembly from trimming.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <TrimmerRootAssembly Include="System.Security" />
  </ItemGroup>
</Project>
```

### UseAppHost

The `UseAppHost` property was introduced in the 2.1.400 version of the .NET Core SDK. It controls whether or not a native executable is created for a deployment. A native executable is required for self-contained deployments.

In .NET Core 3.0 and later versions, a framework-dependent executable is created by default. Set the `UseAppHost` property to `false` to disable generation of the executable.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <UseAppHost>false</UseAppHost>
  </PropertyGroup>
</Project>
```

For more information about deployment, see [.NET Core application deployment](../deploying/index.md).

## Compile properties

- [LangVersion](#langversion)

### LangVersion

The `LangVersion` property lets you specify a specific programming language version. For example, if you want access to C# preview features, set `LangVersion` to `preview`.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <LangVersion>preview</LangVersion>
  </PropertyGroup>
</Project>
```

For more information, see [C# language versioning](../../csharp/language-reference/configure-language-version.md#override-a-default).

## Run-time configuration properties

You can configure some run-time behaviors by specifying MSBuild properties in the project file of the app. For information about other ways of configuring run-time behavior, see [.NET Core run-time configuration settings](../run-time-config/index.md).

- [ConcurrentGarbageCollection](#concurrentgarbagecollection)
- [InvariantGlobalization](#invariantglobalization)
- [RetainVMGarbageCollection](#retainvmgarbagecollection)
- [ServerGarbageCollection](#servergarbagecollection)
- [ThreadPoolMaxThreads](#threadpoolmaxthreads)
- [ThreadPoolMinThreads](#threadpoolminthreads)
- [TieredCompilation](#tieredcompilation)
- [TieredCompilationQuickJit](#tieredcompilationquickjit)
- [TieredCompilationQuickJitForLoops](#tieredcompilationquickjitforloops)

### ConcurrentGarbageCollection

The `ConcurrentGarbageCollection` property configures whether [background (concurrent) garbage collection](../../standard/garbage-collection/background-gc.md) is enabled. Set the value to `false` to disable background garbage collection. For more information, see [System.GC.Concurrent/COMPlus_gcConcurrent](../run-time-config/garbage-collector.md#systemgcconcurrentcomplus_gcconcurrent).

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <ConcurrentGarbageCollection>false</ConcurrentGarbageCollection>
  </PropertyGroup>
</Project>
```

### InvariantGlobalization

The `InvariantGlobalization` property configures whether the app runs in *globalization-invariant* mode, which means it doesn't have access to culture-specific data. Set the value to `true` to run in globalization-invariant mode. For more information, see [Invariant mode](../run-time-config/globalization.md#invariant-mode).

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <InvariantGlobalization>true</InvariantGlobalization>
  </PropertyGroup>
</Project>
```

### RetainVMGarbageCollection

The `RetainVMGarbageCollection` property configures the garbage collector to put deleted memory segments on a standby list for future use or release them. Setting the value to `true` tells the garbage collector to put the segments on a standby list. For more information, see [System.GC.RetainVM/COMPlus_GCRetainVM](../run-time-config/garbage-collector.md#systemgcretainvmcomplus_gcretainvm).

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <RetainVMGarbageCollection>true</RetainVMGarbageCollection>
  </PropertyGroup>
</Project>
```

### ServerGarbageCollection

The `ServerGarbageCollection` property configures whether the application uses [workstation garbage collection or server garbage collection](../../standard/garbage-collection/workstation-server-gc.md). Set the value to `true` to use server garbage collection. For more information, see [System.GC.Server/COMPlus_gcServer](../run-time-config/garbage-collector.md#systemgcservercomplus_gcserver).

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <ServerGarbageCollection>true</ServerGarbageCollection>
  </PropertyGroup>
</Project>
```

### ThreadPoolMaxThreads

The `ThreadPoolMaxThreads` property configures the maximum number of threads for the worker thread pool. For more information, see [Maximum threads](../run-time-config/threading.md#maximum-threads).

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <ThreadPoolMaxThreads>20</ThreadPoolMaxThreads>
  </PropertyGroup>
</Project>
```

### ThreadPoolMinThreads

The `ThreadPoolMinThreads` property configures the minimum number of threads for the worker thread pool. For more information, see [Minimum threads](../run-time-config/threading.md#minimum-threads).

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <ThreadPoolMinThreads>4</ThreadPoolMinThreads>
  </PropertyGroup>
</Project>
```

### TieredCompilation

The `TieredCompilation` property configures whether the just-in-time (JIT) compiler uses [tiered compilation](../whats-new/dotnet-core-3-0.md#tiered-compilation). Set the value to `false` to disable tiered compilation. For more information, see [Tiered compilation](../run-time-config/compilation.md#tiered-compilation).

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TieredCompilation>false</TieredCompilation>
  </PropertyGroup>
</Project>
```

### TieredCompilationQuickJit

The `TieredCompilationQuickJit` property configures whether the JIT compiler uses quick JIT. Set the value to `false` to disable quick JIT. For more information, see [Quick JIT](../run-time-config/compilation.md#quick-jit).

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TieredCompilationQuickJit>false</TieredCompilationQuickJit>
  </PropertyGroup>
</Project>
```

### TieredCompilationQuickJitForLoops

The `TieredCompilationQuickJitForLoops` property configures whether the JIT compiler uses quick JIT on methods that contain loops. Set the value to `true` to enable quick JIT on methods that contain loops. For more information, see [Quick JIT for loops](../run-time-config/compilation.md#quick-jit-for-loops).

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TieredCompilationQuickJitForLoops>true</TieredCompilationQuickJitForLoops>
  </PropertyGroup>
</Project>
```

## NuGet packages

- [PackageReference](#packagereference)
- [AssetTargetFallback](#assettargetfallback)

### PackageReference

The `PackageReference` item lets you specify a NuGet dependency. For example, you may want to reference a single package instead of a [metapackage](../packages.md#metapackages). The `Include` attribute specifies the package ID. The project file snippet in the following example references the [System.Runtime](https://www.nuget.org/packages/System.Runtime/) package.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  ...
  <ItemGroup>
    <PackageReference Include="System.Runtime" Version="4.3.0" />
  </ItemGroup>
</Project>
```

For more information, see [Package references in project files](/nuget/consume-packages/package-references-in-project-files).

### AssetTargetFallback

The `AssetTargetFallback` property lets you specify additional compatible framework versions for projects that your project references and NuGet packages that your project consumes. For example, if you specify a package dependency using `PackageReference` but that package doesn't contain assets that are compatible with your projects's `TargetFramework`, the `AssetTargetFallback` property comes into play. The compatibility of the referenced package is rechecked using each target framework that's specified in `AssetTargetFallback`.

You can set the `AssetTargetFallback` property to one or more [target framework versions](../../standard/frameworks.md#supported-target-framework-versions).

```xml
<Project Sdk="Microsoft.NET.Sdk">
  ...
  <PropertyGroup>
    <AssetTargetFallback>net461</AssetTargetFallback>
  </PropertyGroup>
</Project>
```

### Pack and restore targets

MSBuild 15.1 introduced `pack` and `restore` targets for creating and restoring NuGet packages as part of a build. For information about the MSBuild properties for these targets, including `PackageTargetFallback`, see [NuGet pack and restore as MSBuild targets](/nuget/reference/msbuild-targets).

## See also

- [MSBuild schema reference](/visualstudio/msbuild/msbuild-project-file-schema-reference)
- [Common MSBuild properties](/visualstudio/msbuild/common-msbuild-project-properties)
- [MSBuild properties for NuGet pack](/nuget/reference/msbuild-targets#pack-target)
- [MSBuild properties for NuGet restore](/nuget/reference/msbuild-targets#restore-properties)
- [Customize a build](/visualstudio/msbuild/customize-your-build)
