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

## Additions

* PackageReference
Item that specifies a NuGet dependency in the project. The `Include` attribute specifies the package ID. 

```xml
<PackageReference Include="<package-id>" Version="" PrivateAssets="" IncludeAssets="" ExcludeAssets="" />
```

## Version
`Version` specifies the version of the package to restore. The element respects the rules of the NuGet versioning scheme.

## IncludeAssets
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

## ExcludeAssets
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

## PrivateAssets
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

## Version
`Version` specifies the version of the package to restore. The attribute respect the rules of the NuGet versioning scheme.

* RuntimeIdentifiers
The `<RuntimeIdentifiers>` element lets you specify a semicolon-delimited list of [Runtime Identifiers (RIDs)](../../rid-catalog.md) for the project. 
RIDs enable publishing a self-contained deployments. 

```xml
<RuntimeIdentifiers>win10-x64;osx.10.11-x64;ubuntu.16.04-x64</RuntimeIdentifiers>
```


* RuntimeIdentifier
The `<RuntieIdentifier>` element allows you to specify only one [Runtime Identifier (RID)](../../rid-catalog.md) for the project. RIDs enable publishing a self-contained deployment. 

```xml
<RuntimeIdentifier>ubuntu.16.04-x64</RuntimeIdentifier>
```


* PackageTargetFallback 
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
With the move to MSbuild, we have moved the input metadata that is used when packing a NuGet package from project.json to csproj files. The inputs are MSBuild properties. The following is the list of properties that are used as inputs to the packing process when using the `dotnet pack` command or the `Pack` MSBuild target that is part of the SDK. 

* IsPackable
* PackageVersion
* PackageId
* Title
* Authors
* Description
* Copyright
* PackageRequireLicenseAcceptance
* PackageLicenseUrl
* PackageProjectUrl
* PackageIconUrl
* PackageReleaseNotes
* PackageTags
* PackageOutputPath
* IncludeSymbols
* IncludeSource
* PackageTypes
* IsTool
* RepositoryUrl
* RepositoryType
* NoPackageAnalysis
* MinClientVersion
* IncludeBuildOutput
* IncludeContentInPack
* BuildOutputTargetFolder
* ContentTargetFolders
* NuspecFile
* NuspecBasePath
* NuspecProperties