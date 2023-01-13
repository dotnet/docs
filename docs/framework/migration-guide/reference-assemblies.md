---
title: "Build apps against Microsoft.NETFramework.ReferenceAssemblies"
description: "Developers can target .NET Framework by referencing the official reference assemblies NuGet package."
ms.date: 11/25/2022
helpviewer_keywords:
  - ".NET Framework, targeting"
---
# Build apps against Microsoft.NETFramework.ReferenceAssemblies

When you target a particular version of .NET Framework in a traditional, non-SDK-style project, by default your application is built by using the reference assemblies that are included with that version's developer pack. In scenarios where the matching developer pack cannot be installed on the computer, you can alternatively build against reference assemblies distributed via a NuGet package.

## Update project files

Each project that should build against the reference assemblies NuGet package needs to include the following package reference.

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.NETFramework.ReferenceAssemblies" Version="1.0.3" PrivateAssets="All" />
</ItemGroup>
```

This can be done with the NuGet Package Manager UI in Visual Studio, with [dotnet add package](../../core/tools/dotnet-add-package.md) on the .NET SDK command line, or by manually editing the project file. The package contains reference assemblies for many versions of .NET Framework. The version to be actually used is determined by the TargetFramework (TargetFrameworks) property.

> [!NOTE]
> Projects that contain a project reference need to be restored before they can be built. When building with Visual Studio, either in the IDE or on the command line with *MSBuild.exe*, make sure to explicitly execute the *restore* target prior to building the project. This is done on the Developer Command Prompt by executing `msbuild /t:restore` in the project directory.

> [!NOTE]
> SDK-style projects include a reference to Microsoft.NETFramework.ReferenceAssemblies by default.

## References

- [.NET Framework Targeting Pack Nuget Packages](https://github.com/microsoft/dotnet/tree/main/releases/reference-assemblies)
