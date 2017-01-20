---
title: csproj reference | Microsoft Docs
description: Learn about the differences between existing and .NET Core csproj files
keywords: reference, csproj, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 10/12/2016
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

### PackageReference
Specifies a NuGet dependency in the project. The `Include` attribute specifies the package ID. 

```xml
<PackageReference Include="<package-id>">
    <Version></Version>
    <PrivateAssets></PrivateAssets>
    <IncludeAssets></IncludeAssets>
    <ExcludeAssets></ExcludeAssets>
</PackageReference>
```

#### Version
`<Version>` specifies the version of the package to restore. The element respects the rules of the NuGet versioning scheme.

#### IncludeAssets
`<IncludeAssets>` child element specifies what assets belonging to the package specified by parent `<PackageReference>` should be 
consumed. 

The element can contain one or more of the following values:

* Compile – the contents of the lib folder are available to compile against.
* Runtime – the contents of the runtime folder are distributed.
* ContentFiles – the contents of the contentfiles folder are used.
* Build – the props/targets in the build folder are used.
* Native – the contents from native assets are copied to the output folder for runtime.
* Analyzers – the analyzers are used.

Alternatively, the element can contain:

* None – none of the assets are used.
* All – all assets are used.

#### ExcludeAssets
`<ExcludeAssets>` child element specifies what assets belonging to the package specified by parent `<PackageReference>` should not 
be consumed.

The element can contain one or more of the following values:

* Compile – the contents of the lib folder are available to compile against.
* Runtime – the contents of the runtime folder are distributed.
* ContentFiles – the contents of the contentfiles folder are used.
* Build – the props/targets in the build folder are used.
* Native – the contents from native assets are copied to the output folder for runtime.
* Analyzers – the analyzers are used.

Alternatively, the element can contain:

* None – none of the assets are used.
* All – all assets are used.

#### PrivateAssets
`<PrivateAssets>` child element specifies what assets belonging to the package specified by parent `<PackageReference>` should be 
consumed but that they should not flow to the next project. 

> [!NOTE]
> This is a new term for project.json/xproj `SuppressParent` element. 

The element can contain one or more of the following values:

* Compile – the contents of the lib folder are available to compile against.
* Runtime – the contents of the runtime folder are distributed.
* ContentFiles – the contents of the contentfiles folder are used.
* Build – the props/targets in the build folder are used.
* Native – the contents from native assets are copied to the output folder for runtime.
* Analyzers – the analyzers are used.

Alternatively, the element can contain:

* None – none of the assets are used.
* All – all assets are used.

### DotnetCliToolReference
`<DotnetCliToolReference>` element specifies the CLI tool that the user wants restores in the context of the project. It is 
a replacement for the `tools` node in `project.json`. 

#### Version
`<Version>` specifies the version of the package to restore. The element respect the rules of the NuGet versioning scheme.

### RuntimeIdentifiers
The `<RuntimeIdentifiers>` element lets you specify a semicolon-delimited list of [Runtime Identifiers (RIDs)](../../rid-catalog.md) for the project. 
RIDs enable publishing self-contained deployments. 