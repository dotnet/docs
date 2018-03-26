---
title: Additions to the csproj format for .NET Core
description: Learn about the differences between existing and .NET Core csproj files
keywords: reference, csproj, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 09/22/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: bdc29497-64f2-4d11-a21b-4097e0bdf5c9
ms.workload: 
  - dotnetcore
---

# Additions to the csproj format for .NET Core

This document outlines the changes that were added to the project files as part of the move from *project.json* to *csproj* and [MSBuild](https://github.com/Microsoft/MSBuild). For more information about general project file syntax and reference, see [the MSBuild project file](/visualstudio/msbuild/msbuild-project-file-schema-reference) documentation.  

## Implicit package references
Metapackages are implicitly referenced based on the target framework(s) specified in the `<TargetFramework>` or `<TargetFrameworks>` property of your project file. `<TargetFrameworks>` is ignored if `<TargetFramework>` is specified, independent of order.

```xml
 <PropertyGroup>
   <TargetFramework>netcoreapp1.1</TargetFramework>
 </PropertyGroup>
 ```
 
 ```xml
 <PropertyGroup>
   <TargetFrameworks>netcoreapp1.1;net462</TargetFrameworks>
 </PropertyGroup>
 ```

### Recommendations
Since `Microsoft.NETCore.App` or `NetStandard.Library` metapackages are implicitly referenced, the following are our recommended best practices:

* When targeting .NET Core or .NET Standard, never have an explicit reference to the `Microsoft.NETCore.App` or `NetStandard.Library` metapackages via a `<PackageReference>` item in your project file.
* If you need a specific version of the runtime when targeting .NET Core, you should use the `<RuntimeFrameworkVersion>` property in your project (for example, `1.0.4`) instead of referencing the metapackage.
    * This might happen if you are using [self-contained deployments](../deploying/index.md#self-contained-deployments-scd) and you need a specific patch version of 1.0.0 LTS runtime, for example.
* If you need a specific version of the `NetStandard.Library` metapackage when targeting .NET Standard, you can use the `<NetStandardImplicitPackageVersion>` property and set the version you need.
* Don't explicitly add or update references to either the `Microsoft.NETCore.App` or `NetStandard.Library` metapackage in .NET Framework projects. If any version of `NetStandard.Library` is needed when using a .NET Standard-based NuGet package, NuGet automatically installs that version.

## Default compilation includes in .NET Core projects
With the move to the *csproj* format in the latest SDK versions, we've moved the default includes and excludes for compile items and embedded resources to the SDK properties files. This means that you no longer need to specify these items in your project file. 

The main reason for doing this is to reduce the clutter in your project file. The defaults that are present in the SDK should cover most common use cases, so there is no need to repeat them in every project that you create. This leads to smaller project files that are much easier to understand as well as edit by hand, if needed. 

The following table shows which element and which [globs](https://en.wikipedia.org/wiki/Glob_(programming)) are both included and excluded in the SDK: 

| Element          	| Include glob                           	| Exclude glob                                     	            | Remove glob             	 |
|-------------------|-------------------------------------------|---------------------------------------------------------------|----------------------------|
| Compile          	| \*\*/\*.cs (or other language extensions) | \*\*/\*.user;  \*\*/\*.\*proj;  \*\*/\*.sln;  \*\*/\*.vssscc 	| N/A                     	 |
| EmbeddedResource 	| \*\*/\*.resx                             	| \*\*/\*.user; \*\*/\*.\*proj; \*\*/\*.sln; \*\*/\*.vssscc     | N/A                     	 |
| None             	| \*\*/\*                                  	| \*\*/\*.user; \*\*/\*.\*proj; \*\*/\*.sln; \*\*/\*.vssscc     | - \*\*/\*.cs; \*\*/\*.resx |

If you have globs in your project and you try to build it using the newest SDK, you'll get the following error:

> Duplicate Compile items were included. The .NET SDK includes Compile items from your project directory by default. You can either remove these items from your project file, or set the 'EnableDefaultCompileItems' property to 'false' if you want to explicitly include them in your project file. 

In order to get around this error, you can either remove the explicit `Compile` items that match the ones listed on the previous table, or you can set the `<EnableDefaultCompileItems>` property to `false`, like this:

```xml
<PropertyGroup>
    <EnableDefaultCompileItems>false</EnableDefaultCompileItems>
</PropertyGroup>
```
Setting this property to `false` will override implicit inclusion and the behavior will revert back to the previous SDKs where you had to specify the default globs in your project. 

This change does not modify the main mechanics of other includes. However, if you wish to specify, for example, some files to get published with your app, you can still use the known mechanisms in *csproj* for that (for example, the `<Content>` element).

`<EnableDefaultCompileItems>` only disables `Compile` globs but doesn't affect other globs, like the implicit `None` glob, which also applies to \*.cs items. Because of that, **Solution Explorer** will continue show \*.cs items as part of the project, included as `None` items. In a similar way, you can use `<EnableDefaultNoneItems>` to disable the implicit `None` glob.

To disable **all implicit globs**, you can set the `<EnableDefaultItems>` property to `false` as in the following example:
```xml
<PropertyGroup>
    <EnableDefaultItems>false</EnableDefaultItems>
</PropertyGroup>
```

### Recommendation
With csproj, we recommend that you remove the default globs from your project and only add file paths with globs for those artifacts that your app/library needs for various scenarios (for example, runtime and NuGet packaging).

## How to see the whole project as MSBuild sees it

While those csproj changes greatly simplify project files, you might want to see the fully expanded project as MSBuild sees it once the SDK and its targets are included. Preprocess the project with [the `/pp` switch](/visualstudio/msbuild/msbuild-command-line-reference#preprocess) of the [`dotnet msbuild`](dotnet-msbuild.md) command, which shows which files are imported, their sources, and their contributions to the build without actually building the project:

`dotnet msbuild /pp:fullproject.xml`

If the project has multiple target frameworks, the results of the command should be focused on only one of them by specifying it as an MSBuild property:

`dotnet msbuild /p:TargetFramework=netcoreapp2.0 /pp:fullproject.xml`

## Additions

### Sdk attribute 
The `<Project>` element of the *.csproj* file has a new attribute called `Sdk`. `Sdk` specifies which SDK will be used by the project. The SDK, as the [layering document](cli-msbuild-architecture.md) describes, is a set of MSBuild [tasks](/visualstudio/msbuild/msbuild-tasks) and [targets](/visualstudio/msbuild/msbuild-targets) that can build .NET Core code. We ship two main SDKs with the .NET Core tools:

1. The .NET Core SDK with the ID of `Microsoft.NET.Sdk`
2. The .NET Core web SDK with the ID of `Microsoft.NET.Sdk.Web`

You need to have the `Sdk` attribute set to one of those IDs on the `<Project>` element in order to use the .NET Core tools and build your code. 

### PackageReference
Item that specifies a NuGet dependency in the project. The `Include` attribute specifies the package ID. 

```xml
<PackageReference Include="<package-id>" Version="" PrivateAssets="" IncludeAssets="" ExcludeAssets="" />
```

#### Version
`Version` specifies the version of the package to restore. The attribute respects the rules of the [NuGet versioning](/nuget/create-packages/dependency-versions#version-ranges) scheme. The default behavior is an exact version match. For example, specifying `Version="1.2.3"` is equivalent to NuGet notation `[1.2.3]` for the exact 1.2.3 version of the package.

#### IncludeAssets, ExcludeAssets and PrivateAssets
`IncludeAssets` attribute specifies what assets belonging to the package specified by `<PackageReference>` should be 
consumed. 

`ExcludeAssets` attribute specifies what assets belonging to the package specified by `<PackageReference>` should not 
be consumed.

`PrivateAssets` attribute specifies what assets belonging to the package specified by `<PackageReference>` should be 
consumed but that they should not flow to the next project. 

> [!NOTE]
> `PrivateAssets` is equivalent to the *project.json*/*xproj* `SuppressParent` element.

These attributes can contain one or more of the following items:

* `Compile` – the contents of the lib folder are available to compile against.
* `Runtime` – the contents of the runtime folder are distributed.
* `ContentFiles` – the contents of the *contentfiles* folder are used.
* `Build` – the props/targets in the build folder are used.
* `Native` – the contents from native assets are copied to the output folder for runtime.
* `Analyzers` – the analyzers are used.

Alternatively, the attribute can contain:

* `None` – none of the assets are used.
* `All` – all assets are used.

### DotNetCliToolReference
`<DotNetCliToolReference>` item element specifies the CLI tool that the user wants to restore in the context of the project. It's 
a replacement for the `tools` node in *project.json*. 

```xml
<DotNetCliToolReference Include="<package-id>" Version="" />
```

#### Version
`Version` specifies the version of the package to restore. The attribute respects the rules of the [NuGet versioning](/nuget/create-packages/dependency-versions#version-ranges) scheme. The default behavior is an exact version match. For example, specifying `Version="1.2.3"` is equivalent to NuGet notation `[1.2.3]` for the exact 1.2.3 version of the package.

### RuntimeIdentifiers
The `<RuntimeIdentifiers>` element lets you specify a semicolon-delimited list of [Runtime Identifiers (RIDs)](../rid-catalog.md) for the project. 
RIDs enable publishing a self-contained deployments. 

```xml
<RuntimeIdentifiers>win10-x64;osx.10.11-x64;ubuntu.16.04-x64</RuntimeIdentifiers>
```

### RuntimeIdentifier
The `<RuntimeIdentifier>` element allows you to specify only one [Runtime Identifier (RID)](../rid-catalog.md) for the project. RIDs enable publishing a self-contained deployment. 

```xml
<RuntimeIdentifier>ubuntu.16.04-x64</RuntimeIdentifier>
```

### PackageTargetFallback 
The `<PackageTargetFallback>` element allows you to specify a set of compatible targets to be used when restoring packages. It's designed to allow packages that use the dotnet [TxM (Target x Moniker)](/nuget/schema/target-frameworks) to operate with packages that don't declare a dotnet TxM. If your project uses the dotnet TxM, then all the packages it depends on must also have a dotnet TxM, unless you add the `<PackageTargetFallback>` to your project in order to allow non-dotnet platforms to be compatible with dotnet. 

The following example provides the fallbacks for all targets in your project: 

```xml
<PackageTargetFallback>
    $(PackageTargetFallback);portable-net45+win8+wpa81+wp8
</PackageTargetFallback >
```

The following example specifies the fallbacks only for the `netcoreapp1.0` target:

```xml
<PackageTargetFallback Condition="'$(TargetFramework)'=='netcoreapp1.0'">
    $(PackageTargetFallback);portable-net45+win8+wpa81+wp8
</PackageTargetFallback >
```

## NuGet metadata properties
With the move to MSbuild, we have moved the input metadata that is used when packing a NuGet package from *project.json* to *.csproj* files. The inputs are MSBuild properties so they have to go within a `<PropertyGroup>` group. The following is the list of properties that are used as inputs to the packing process when using the `dotnet pack` command or the `Pack` MSBuild target that is part of the SDK. 

### IsPackable
A Boolean value that specifies whether the project can be packed. The default value is `true`. 

### PackageVersion
Specifies the version that the resulting package will have. Accepts all forms of NuGet version string. Default is the value of `$(Version)`, that is, of the property `Version` in the project. 

### PackageId
Specifies the name for the resulting package. If not specified, the `pack` operation will default to using the `AssemblyName` or directory name as the name of the package. 

### Title
A human-friendly title of the package, typically used in UI displays as on nuget.org and the Package Manager in Visual Studio. If not specified, the package ID is used instead.

### Authors
A semicolon-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.

### Description
A long description of the package for UI display.

### Copyright
Copyright details for the package.

### PackageRequireLicenseAcceptance
A Boolean value that specifies whether the client must prompt the consumer to accept the package license before installing the package. The default is `false`.

### PackageLicenseUrl
An URL to the license that is applicable to the package.

### PackageProjectUrl
A URL for the package's home page, often shown in UI displays as well as nuget.org.

### PackageIconUrl
A URL for a 64x64 image with transparent background to use as the icon for the package in UI display.

### PackageReleaseNotes
Release notes for the package.

### PackageTags
A semicolon-delimited list of tags that designates the package.

### PackageOutputPath
Determines the output path in which the packed package will be dropped. Default is `$(OutputPath)`. 

### IncludeSymbols
This Boolean value indicates whether the package should create an additional symbols package when the project is packed. This package will have a *.symbols.nupkg* extension and will copy the PDB files along with the DLL and other output files.

### IncludeSource
This Boolean value indicates whether the pack process should create a source package. The source package contains the library's source code as well as PDB files. Source files are put under the `src/ProjectName` directory in the resulting package file. 

### IsTool
Specifies whether all output files are copied to the *tools* folder instead of the *lib* folder. Note that this is different from a `DotNetCliTool` which is specified by setting the `PackageType` in the *.csproj* file.

### RepositoryUrl
Specifies the URL for the repository where the source code for the package resides and/or from which it's being built. 

### RepositoryType
Specifies the type of the repository. Default is "git". 

### NoPackageAnalysis
Specifies that pack should not run package analysis after building the package.

### MinClientVersion
Specifies the minimum version of the NuGet client that can install this package, enforced by nuget.exe and the Visual Studio Package Manager.

### IncludeBuildOutput
This Boolean values specifies whether the build output assemblies should be packed into the *.nupkg* file or not.

### IncludeContentInPack
This Boolean value specifies whether any items that have a type of `Content` will be included in the resulting package automatically. The default is `true`. 

### BuildOutputTargetFolder
Specifies the folder where to place the output assemblies. The output assemblies (and other output files) are copied into their respective framework folders.

### ContentTargetFolders
This property specifies the default location of where all the content files should go if `PackagePath` is not specified for them. The default value is "content;contentFiles".

### NuspecFile
Relative or absolute path to the *.nuspec* file being used for packing. 

> [!NOTE]
> If the *.nuspec* file is specified, it's used **exclusively** for packaging information and any information in the projects is not used. 

### NuspecBasePath
Base path for the *.nuspec* file.

### NuspecProperties
Semicolon separated list of key=value pairs.
