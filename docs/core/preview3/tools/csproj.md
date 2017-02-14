---
title: csproj reference | Microsoft Docs
description: Learn about the differences between existing and .NET Core csproj files
keywords: reference, csproj, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 07/02/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: bdc29497-64f2-4d11-a21b-4097e0bdf5c9
---

# Additions to the csproj format for .NET Core

[!INCLUDE[preview-warning](../../../includes/warning.md)]

This document outlines the changes that were added to the csproj files as part of the move from `project.json` to `csproj` and 
[MSBuild](https://github.com/Microsoft/MSBuild). For more information about general project file syntax and reference, 
see [the MSBuild project file](https://docs.microsoft.com/visualstudio/msbuild/msbuild-project-file-schema-reference) documentation.  

## Implicit package references
The metapackage included is tied to the target framework. That means that for `netcoreapp1.0` a proper version of the `Microsoft.NETCore.App` metapackage is referenced. Same goes for `netcoreapp1.1` target framework as well as `netstandard1.x` target frameworks. 

As far as the rest of the behavior is concerned, the tools will work as expected and most of the gestures will remain the same (for example, `dotnet restore`). 

### Migrating a project
If you have an existing reference to the metapackage in your project.json, the migration (both in `dotnet migrate` as well as Visual Studio 2017) will include that reference in your new csproj project. This will cause the tools to issue the following warning when you try to build your project:

> A PackageReference for [metapackage ID] was included in your project. This package is implicitly referenced by the .NET SDK and you do not typically need to reference it from your project. For more information, see https://aka.ms/sdkimplicitrefs.

This warning simply means that you probably want to remove that package reference from your project file. If you do keep it, the specified version of the metapackage will be used. 

### Recommendations
With this new feature, you might be wondering when you should specify a version of the metapackage in the project and when not. Here is the overall guidance:

* For new projects, you should use the template and not add an explicit reference to any metapackage. 
* For existing projects, you should remove the reference. 
* If you need a specific version of the runtime, you should use the `<RuntimeFrameworkVersion>` property in your project (for example, `1.0.4`) instead of referencing the metapackage.
    * This might happen if you are using [self-contained deployments](https://docs.microsoft.com/en-us/dotnet/articles/core/preview3/deploying/#self-contained-deployments-scd) and you need a specific patch version of 1.0.0 LTS runtime, for example.
* If you need a specific version of the `NetStandard.Library` metapackage, you can use the `<NetStandardImplicitPackageVersion>` property and set the version you need. 

## Default compilation includes in .NET Core projects
As part of the RC3 release of Visual Studio 2017, a new version of the .NET Core SDK is included. With that, we've  moved the default includes and excludes for compile items and embedded resources to the SDK properties files. This means that you don't need to specify these items in your project file moving forward. 

The main reason for doing this is to reduce the clutter on your project file. The defaults that are present in the SDK should cover most common use cases, so there is no need to repeat them in every project that you create. This leads to shorter projects that are much easier to understand as well as edit by hand, if needed. 

The table below shows which element and which globs are both included and excluded in the SDK: 

| Element          	| Include glob                           	| Exclude glob                                     	            | Remove glob             	 |
|-------------------|-------------------------------------------|---------------------------------------------------------------|----------------------------|
| Compile          	| \*\*/\*.cs (or other language extensions) | \*\*/\*.user;  \*\*/\*.\*proj;  \*\*/\*.sln;  \*\*/\*.vssscc 	| N/A                     	 |
| EmbeddedResource 	| \*\*/\*.resx                             	| \*\*/\*.user; \*\*/\*.\*proj; \*\*/\*.sln; \*\*/\*.vssscc     | N/A                     	 |
| None             	| \*\*/\*                                  	| \*\*/\*.user; \*\*/\*.\*proj; \*\*/\*.sln; \*\*/\*.vssscc     | - \*\*/\*.cs; \*\*/\*.resx |

If you have globs in your project and you try to build it using the newest SDK, you'll get the following error:

> Duplicate Compile items were included. The .NET SDK includes Compile items from your project directory by default. You can either remove these items from your project file, or set the 'EnableDefaultCompileItems' property to 'false' if you want to explicitly include them in your project file. 

In order to get around this error, you can either remove the explicit Compile items that match the ones listed above, or you can set the `<EnableDefaultCompileItems>` property to false, like this:

```xml
<PropertyGroup>
    <EnableDefaultCompileItems>false</EnableDefaultCompileItems>
</PropertyGroup>
```
Setting this property to `false` will override implicit inclusion and the behavior will revert back to the previous SDKs where you had to specify the default globs in your project. 

This change does not modify the main mechanics of other includes. However, if you wish to specify, for example, some files to get published with your app, you can still use the known mechanisms in `csproj` for that (for example, the `<Content>` element).

### Recommendation
Moving forward, our recommendation is for you to remove the above default globs from your project and only add globs file paths for those artifacts that your app/library needs for various scenarios (runtime, NuGet packaging, etc.)


## Additions

### Sdk property 
As part of this work, we've added a new property to the `<Project>` element of the `csproj` file that is called SDK. The SDK property lists out what SDK will be used in this project. The SDK, as the [layering document](layering.md) describes, is a set of MSBuild [tasks]() and [targets]() that can build .NET Core code. We ship two main SDKs with the .NET Core tools:

1. The .NET Core SDK with the ID of `Microsoft.NET.Sdk`
2. The .NET Core web SDK with the ID of `Microsoft.NET.Sdk.Web`

You need to have this attribute on the `<Project>` element in order to use the .NET Core tools and build your code. 

### PackageReference
Item that specifies a NuGet dependency in the project. The `Include` attribute specifies the package ID. 

```xml
<PackageReference Include="<package-id>" Version="" PrivateAssets="" IncludeAssets="" ExcludeAssets="" />
```

#### Version
`Version` specifies the version of the package to restore. The element respects the rules of the NuGet versioning scheme.

#### IncludeAssets
`IncludeAssets` attribute specifies what assets belonging to the package specified by `<PackageReference>` should be 
consumed. 

The attribute can contain one or more of the following values:

* `Compile` – the contents of the lib folder are available to compile against.
* `Runtime` – the contents of the runtime folder are distributed.
* `ContentFiles` – the contents of the contentfiles folder are used.
* `Build` – the props/targets in the build folder are used.
* `Native` – the contents from native assets are copied to the output folder for runtime.
* `Analyzers` – the analyzers are used.

Alternatively, the attribute can contain:

* `None` – none of the assets are used.
* `All` – all assets are used.

#### ExcludeAssets
`ExcludeAssets` attribute specifies what assets belonging to the package specified by `<PackageReference>` should not 
be consumed.

The attribute can contain one or more of the following values:

* `Compile` – the contents of the lib folder are available to compile against.
* `Runtime` – the contents of the runtime folder are distributed.
* `ContentFiles` – the contents of the contentfiles folder are used.
* `Build` – the props/targets in the build folder are used.
* `Native` – the contents from native assets are copied to the output folder for runtime.
* `Analyzers` – the analyzers are used.

Alternatively, the element can contain:

* `None` – none of the assets are used.
* `All` – all assets are used.

#### PrivateAssets
`PrivateAssets` attribute specifies what assets belonging to the package specified by `<PackageReference>` should be 
consumed but that they should not flow to the next project. 

> [!NOTE]
> This is a new term for project.json/xproj `SuppressParent` element. 

The attribute can contain one or more of the following values:

* `Compile` – the contents of the lib folder are available to compile against.
* `Runtime` – the contents of the runtime folder are distributed.
* `ContentFiles` – the contents of the contentfiles folder are used.
* `Build` – the props/targets in the build folder are used.
* `Native` – the contents from native assets are copied to the output folder for runtime.
* `Analyzers` – the analyzers are used.

Alternatively, the attribute can contain:

* `None` – none of the assets are used.
* `All` – all assets are used.

* DotnetCliToolReference
`<DotnetCliToolReference>` item element specifies the CLI tool that the user wants to restore in the context of the project. It is 
a replacement for the `tools` node in `project.json`. 

```xml
<DotnetCliToolReference Include="<package-id>" Version="" />
```

#### Version
`Version` specifies the version of the package to restore. The attribute respect the rules of the NuGet versioning scheme.

* RuntimeIdentifiers
The `<RuntimeIdentifiers>` element lets you specify a semicolon-delimited list of [Runtime Identifiers (RIDs)](../../rid-catalog.md) for the project. 
RIDs enable publishing a self-contained deployments. 

```xml
<RuntimeIdentifiers>win10-x64;osx.10.11-x64;ubuntu.16.04-x64</RuntimeIdentifiers>
```


### RuntimeIdentifier
The `<RuntieIdentifier>` element allows you to specify only one [Runtime Identifier (RID)](../../rid-catalog.md) for the project. RIDs enable publishing a self-contained deployment. 

```xml
<RuntimeIdentifier>ubuntu.16.04-x64</RuntimeIdentifier>
```


### PackageTargetFallback 
The `<PackageTargetFallback>` element allows you to specify a set of compatible targets to be used when restoring packages. It is designed to allow packages that use the dotnet TxM to operate with packages that don't declare a dotnet TxM. If your project uses the dotnet TxM then all the packages you depend on must also have a dotnet TxM, unless you add the `<PackageTargetFallback>` to your project in order to allow non dotnet platforms to be compatible with dotnet. 

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
With the move to MSbuild, we have moved the input metadata that is used when packing a NuGet package from project.json to csproj files. The inputs are MSBuild properties so they have to go within a `<PropertyGroup>` group. The following is the list of properties that are used as inputs to the packing process when using the `dotnet pack` command or the `Pack` MSBuild target that is part of the SDK. 

### IsPackable
TBD

### PackageVersion
Specified a version that the resulting package will have. Accepts all forms of NuGet version string. 

### PackageId
Specify a name for the resulting package. If not specified, the `pack` operation will default to using the AssemblyName or directory name as the name of the package. 

### Title
A human-friendly title of the package, typically used in UI displays as on nuget.org and the Package Manager in Visual Studio. If not specified, the package ID is used instead.

### Authors
A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.

### Description
A long description of the package for UI display.

### Copyright
Copyright details for the package.

### PackageRequireLicenseAcceptance
A Boolean value specifying whether the client must prompt the consumer to accept the package license before installing the package.

### PackageLicenseUrl
An URL to the license that is applicable to the package.

### PackageProjectUrl
A URL for the package's home page, often shown in UI displays as well as nuget.org.

### PackageIconUrl
A URL for a 64x64 image with transparenty background to use as the icon for the package in UI display.

### PackageReleaseNotes
Release notes for the package.

### PackageTags
A list of tags that designates the package. The list is represented as a list of tags that are comma-delimited. 

### PackageOutputPath
TBD

### IncludeSymbols
This boolean value indicates whether the package should include symbols when it is packed. The default value is "false". 

### IncludeSource
This boolean value indicates whether the packing process should include source code in the resulting NuGet package. 

### PackageTypes
TBD

### IsTool
Specifies whether all output files, as specified in the Output Assemblies scenario, are copied to the tools folder instead of the lib folder. Note that this is different from a DotNetCliTool which is specified by setting the PackageType in csproj file.

### RepositoryUrl
Specifies the URL for the repository where the source code for the package resides and/or from which it is being built. 

### RepositoryType
Specifies the type of the repository. Default is "git". 

### NoPackageAnalysis
TBD

### MinClientVersion
Specifies the minimum version of the NuGet client that can install this package, enforced by nuget.exe and the Visual Studio Package Manager.

### IncludeBuildOutput
This is a boolean, which decided whether the build output assemblies should be packed into the nupkg or not.

### IncludeContentInPack
TBD

### BuildOutputTargetFolder
Specify the folder in which the output assemblies should go to. The output assemblies (and other output files) are copied into their respective framework folders.

### ContentTargetFolders
TBD

### NuspecFile
Relative or absolute path to the nuspec file being used for packing.

### NuspecBasePath
`BasePath` for the nuspec file.

### NuspecProperties
Semicolon separated list of key=value pairs. 