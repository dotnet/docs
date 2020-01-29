---
title: .NET Core SDK overview
description: Learn about the .NET Core SDK and how to install it.
ms.date: 01/28/2020
ms.topic: conceptual
---
# .NET Core SDKs and project files

.NET Core projects are associated with a .NET software development kit (SDK). These SDKs, as the [layering document](../tools/cli-msbuild-architecture.md) describes, are a set of MSBuild [tasks](/visualstudio/msbuild/msbuild-tasks) and [targets](/visualstudio/msbuild/msbuild-targets) that can build .NET Core code. The following SDKs are available for .NET Core:

| ID | Description |
| - | - | - |
| `Microsoft.NET.Sdk` | The .NET Core SDK |
| `Microsoft.NET.Sdk.Web` | The .NET Core [Web SDK](/aspnet/core/razor-pages/web-sdk) |
| `Microsoft.NET.Sdk.Razor` | The .NET Core [Razor SDK](/aspnet/core/razor-pages/sdk) |
| `Microsoft.NET.Sdk.Worker` | The .NET Core Worker Service SDK |
| `Microsoft.NET.Sdk.WindowsDesktop` | The .NET Core WinForms and WPF SDK |

The .NET Core SDK is the base SDK for .NET Core. The other SDKs depend on the .NET Core SDK. For example, the Web SDK depends on the .NET Core SDK and the Razor SDK.

The .NET Core SDK is a set of libraries and tools that allow developers to create .NET Core applications and libraries. It contains the following components that are used to build and run applications:

- .NET Core [CLI](../tools/index.md)
- .NET Core libraries and runtime

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

## See also

- [Install the SDK](../install/sdk.md)
- [The .NET Core CLI](../tools/index.md)
- [How to use MSBuild project SDKs](/visualstudio/msbuild/how-to-use-project-sdk)
