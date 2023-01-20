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

## Restore the project

Projects that contain a package reference must be restored before they can be built.

After adding the **Microsoft.NETFramework.ReferenceAssemblies** NuGet package to your project, you must explicitly run the restore action in one of the following ways:

- If your project is a non SDK-style project and uses the _packages.config_ file to reference NuGet packages:

  01. Install the [NuGet CLI tool](https://learn.microsoft.com/en-us/nuget/install-nuget-client-tools#nugetexe-cli), making sure _nuget.exe_ is in the PATH variable.
  01. Open a command prompt.
  01. Navigate to the directory that contains your project file.
  01. Run _nuget.exe restore_.

- If your project is a non SDK-style project and uses `<PackageReference>` settings in the project file to reference NuGet packages:

  01. Open **Developer Command Prompt for VS 2022**. The name of this app may be different based on which version of Visual Studio you've installed.
  01. Navigate to the directory that contains your project file.
  01. Run _msbuild /t:restore_.

- If your project is an SDK-style project, you don't need to do anything. The NuGet restore action is automatically run when the project is built.
