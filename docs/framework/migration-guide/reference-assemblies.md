---
title: "Build apps against Microsoft.NETFramework.ReferenceAssemblies"
description: "Learn how to reference the .NET Framework Reference Assemblies in your project, when you can't install a matching developer pack."
ms.date: 04/26/2024
helpviewer_keywords:
  - ".NET Framework, targeting"
---
# Build apps against Microsoft.NETFramework.ReferenceAssemblies

When you target a particular version of .NET Framework, by default your application is built by using the reference assemblies that are included with that version's developer pack. In scenarios where the matching developer pack can't be installed on the computer, you can build against reference assemblies distributed via a NuGet package instead.

## Update project files

Each project that should build against the reference assemblies NuGet package needs to include a reference to _Microsoft.NETFramework.ReferenceAssemblies_.

Projects that use a [_packages.config_](/nuget/reference/packages-config) file should include the following in _packages.config_.

```xml
<packages>
  <package id="Microsoft.NETFramework.ReferenceAssemblies" version="1.0.3" developmentDependency="true" />
</packages>
```

Projects that use the [`<PackageReference>`](/nuget/consume-packages/package-references-in-project-files) MSBuild property should include the following property in the project file.

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.NETFramework.ReferenceAssemblies" Version="1.0.3" PrivateAssets="All" />
</ItemGroup>
```

[SDK-style projects](../../core/project-sdk/overview.md) include this reference by default. For typical .NET Framework projects that were created with Visual Studio, you can add the reference by using the NuGet Package Manager UI in Visual Studio. The package contains reference assemblies for many versions of .NET Framework. The version that's actually used is determined by the `TargetFrameworkVersion` or `TargetFramework` property, as already defined in the project file.

## Restore the project

Projects that contain a package reference must be restored before they can be built.

After adding the **Microsoft.NETFramework.ReferenceAssemblies** NuGet package to your project, you must explicitly run the restore action in one of the following ways:

- If your project is a non SDK-style project and uses the _packages.config_ file to reference NuGet packages:

  01. Install the [NuGet CLI tool](/nuget/install-nuget-client-tools#nugetexe-cli), and make sure _nuget.exe_ is in the `PATH` environment variable.
  01. Open a command prompt.
  01. Navigate to the directory that contains your project file.
  01. Run `nuget.exe restore`.

- If your project is a non SDK-style project and uses `<PackageReference>` settings in the project file to reference NuGet packages:

  01. Open **Developer Command Prompt for VS 2022**. The name of this app might be different based on which version of Visual Studio you've installed.
  01. Navigate to the directory that contains your project file.
  01. Run `msbuild /t:restore`.

- If your project is an SDK-style project, you don't need to do anything. The NuGet restore action runs automatically when the project is built.

> [!IMPORTANT]
> Using reference assemblies makes it possible to build projects that target unsupported versions of .NET Framework from the command line. However, you still can't load these projects in newer versions of Visual Studio. To continue building these apps in Visual Studio, the only workaround is to use [an older version of Visual Studio](https://visualstudio.microsoft.com/vs/older-downloads/).
