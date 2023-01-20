---
title: "Build apps against Microsoft.NETFramework.ReferenceAssemblies"
description: "Learn how to reference the .NET Framework Reference Assemblies in your project, when you can't install a matching developer pack."
ms.date: 01/19/2023
helpviewer_keywords:
  - ".NET Framework, targeting"
---
# Build apps against Microsoft.NETFramework.ReferenceAssemblies

When you target a particular version of .NET Framework, by default your application is built by using the reference assemblies that are included with that version's developer pack. In scenarios where the matching developer pack cannot be installed on the computer, you can alternatively build against reference assemblies distributed via a NuGet package.

## Update project files

Each project that should build against the reference assemblies NuGet package needs to include a reference to _Microsoft.NETFramework.ReferenceAssemblies_.

Projects using [_packages.config_](/nuget/reference/packages-config) should include the following in _packages.config_.

```xml
<packages>
  <package id="Microsoft.NETFramework.ReferenceAssemblies" version="1.0.3" developmentDependency="true" />
</packages>
```

Projects using [`<PackageReference>`](/nuget/consume-packages/package-references-in-project-files) should include the following in the project file.

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.NETFramework.ReferenceAssemblies" Version="1.0.3" PrivateAssets="All" />
</ItemGroup>
```

SDK-style projects include this reference by default. For typical .NET Framework projects that were created with Visual Studio, the reference can be added with the NuGet Package Manager UI in Visual Studio. The package contains reference assemblies for many versions of .NET Framework. The version to be actually used is determined by the `TargetFrameworkVersion` or `TargetFramework` (`TargetFrameworks`) property, as already defined in the project file.

## Run restore on the command line

Projects that contain a package reference need to be restored before they can be built.

When building with Visual Studio, either in the IDE or on the command line with *MSBuild.exe*, make sure to explicitly restore packages prior to building the project. For projects using _packages.config_, this done with [nuget restore](/nuget/reference/cli-reference/cli-ref-restore). For projects using `<PackageReference>`, this is done on the Developer Command Prompt with the `msbuild /t:restore` command from the project directory.

When building with the .NET SDK, make sure to run the [dotnet restore](../../core/tools/dotnet-restore.md) command from the project directory.

## References

- [.NET Framework Targeting Pack Nuget Packages](https://github.com/microsoft/dotnet/tree/main/releases/reference-assemblies)
