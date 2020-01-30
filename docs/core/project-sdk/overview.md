---
title: .NET Core project SDK overview
description: Learn about the .NET Core project SDKs.
ms.date: 01/28/2020
ms.topic: conceptual
---
# .NET Core project SDKs

.NET Core projects are associated with a software development kit (SDK). Each project SDK is a set of MSBuild [targets](/visualstudio/msbuild/msbuild-targets) and associated [tasks](/visualstudio/msbuild/msbuild-tasks) that are responsible for compiling code, publishing it, packing NuGet packages, and so on.

The following SDKs are available for .NET Core:

| ID | Description | Repo|
| - | - | - |
| `Microsoft.NET.Sdk` | The .NET Core SDK | https://github.com/dotnet/sdk |
| `Microsoft.NET.Sdk.Web` | The .NET Core [Web SDK](/aspnet/core/razor-pages/web-sdk) | https://github.com/aspnet/websdk |
| `Microsoft.NET.Sdk.Razor` | The .NET Core [Razor SDK](/aspnet/core/razor-pages/sdk) |
| `Microsoft.NET.Sdk.Worker` | The .NET Core Worker Service SDK |
| `Microsoft.NET.Sdk.WindowsDesktop` | The .NET Core WinForms and WPF SDK |

The .NET Core SDK is the base SDK for .NET Core. The other SDKs depend on the .NET Core SDK. For example, the Web SDK depends on the .NET Core SDK and the Razor SDK.

## Project files

.NET Core projects are based on the [MSBuild](/visualstudio/msbuild/msbuild) format. Project files, which have extensions like *.csproj* for C# projects and *.fsproj* for F# projects, are in XML format. The root element of an MSBuild project file is the [Project](/msbuild/project-element-msbuild) element. The `Project` element has an optional `Sdk` attribute that specifies which SDK (and version) to use.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  ...
</Project>
```

Another way to specify the SDK is with the top-level [Sdk](/visualstudio/msbuild/sdk-element-msbuild) element:

```xml
<Project>
  <Sdk Name="Microsoft.NET.Sdk" />
  ...
</Project>
```

Referencing an SDK in one of these ways greatly simplifies project files for .NET Core. While evaluating the project, MSBuild adds implicit imports for `Sdk.props` at the top of the project file and `Sdk.targets` at the bottom.

```xml
<Project>
  <!-- Implicit top import -->
  <Import Project="Sdk.props" Sdk="Microsoft.NET.Sdk" />
  ...
  <!-- Implicit bottom import -->
  <Import Project="Sdk.targets" Sdk="Microsoft.NET.Sdk" />
</Project>
```

> [!TIP]
> On a Windows machine, the *Sdk.props* and *Sdk.targets* files can be found in the *%ProgramFiles%\dotnet\sdk\\[version]\Sdks\Microsoft.NET.Sdk\Sdk* folder.

## Preprocess the project file

You can see the fully expanded project as MSBuild sees it after the SDK and its targets are included by using the `dotnet msbuild -preprocess` command. The [preprocess](/visualstudio/msbuild/msbuild-command-line-reference#preprocess) switch of the [`dotnet msbuild`](dotnet-msbuild.md) command shows which files are imported, their sources, and their contributions to the build without actually building the project. If the project has multiple target frameworks, focus the results of the command on only one framework by specifying it as an MSBuild property. For example:

`dotnet msbuild -property:TargetFramework=netcoreapp2.0 -preprocess:output.xml`

## Default compilation includes

The default includes and excludes for compile items and embedded resources are in the SDK properties files. Unlike .NET Framework projects, you don't need to specify these items in your project file, because the defaults cover most common use cases. This leads to smaller project files that are easier to understand as well as edit by hand, if needed.

The following table shows which element and which [globs](https://en.wikipedia.org/wiki/Glob_(programming)) are included and excluded in the .NET Core SDK:

| Element           | Include glob                              | Exclude glob                                                  | Remove glob              |
|-------------------|-------------------------------------------|---------------------------------------------------------------|--------------------------|
| Compile           | \*\*/\*.cs (or other language extensions) | \*\*/\*.user;  \*\*/\*.\*proj;  \*\*/\*.sln;  \*\*/\*.vssscc  | N/A                      |
| EmbeddedResource  | \*\*/\*.resx                              | \*\*/\*.user; \*\*/\*.\*proj; \*\*/\*.sln; \*\*/\*.vssscc     | N/A                      |
| None              | \*\*/\*                                   | \*\*/\*.user; \*\*/\*.\*proj; \*\*/\*.sln; \*\*/\*.vssscc     | \*\*/\*.cs; \*\*/\*.resx |

> [!NOTE]
> **Exclude glob** always excludes the `./bin` and `./obj` folders, which are represented by the `$(BaseOutputPath)` and `$(BaseIntermediateOutputPath)` MSBuild properties, respectively. As a whole, all excludes are represented by `$(DefaultItemExcludes)`.

If you have globs in your project and you try to build it using the .NET Core SDK, you'll get the following error:

**Duplicate Compile items were included. The .NET SDK includes Compile items from your project directory by default. You can either remove these items from your project file, or set the 'EnableDefaultCompileItems' property to 'false' if you want to explicitly include them in your project file.**

To resolve the error, remove the explicit `Compile` items that match the ones listed on the previous table, or set the `EnableDefaultCompileItems` property to `false`, which disables implicit inclusion:

```xml
<PropertyGroup>
  <EnableDefaultCompileItems>false</EnableDefaultCompileItems>
</PropertyGroup>
```

If you want to specify, for example, some files to get published with your app, you can still use the known MSBuild mechanisms for that, for example, the `Content` element.

`EnableDefaultCompileItems` only disables `Compile` globs but doesn't affect other globs, like the implicit `None` glob that also applies to \*.cs items. Because of that, Solution Explorer shows \*.cs items as part of the project, included as `None` items. To disable the implicit `None` glob, set `EnableDefaultNoneItems` to `false`:

```xml
<PropertyGroup>
  <EnableDefaultNoneItems>false</EnableDefaultNoneItems>
</PropertyGroup>
```

To disable *all* implicit globs, set the `EnableDefaultItems` property to `false`:

```xml
<PropertyGroup>
  <EnableDefaultItems>false</EnableDefaultItems>
</PropertyGroup>
```

## See also

- [Install .NET Core](../install/index.md)
- [How to use MSBuild project SDKs](/visualstudio/msbuild/how-to-use-project-sdk)
