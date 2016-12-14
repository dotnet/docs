---
title: csproj reference | .NET Core SDK
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

# Additions to csproj format for .NET Core

This document outlines the changes that were added to the csproj files as part of the move from project.json to csproj and 
[MSBuild](https://github.com/Microsoft/MSBuild). This document outlines **only the deltas to non-core csproj files**. If 
you need more information about general project file syntax and reference, please consult [the MSBuild project file]() documentation. 

> ![NOTE]
> This document will grow in the future, so please check back to see new additions. 

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

* Compile – are the contents of the lib folder available to compile against
* Runtime – are the contents of the runtime folder distributed
* ContentFiles – are the contents of the contentfiles folder used
* Build – do the props/targets in the build folder get used
* Native – are the contents from native assets copied to the output folder for runtime
* Analyzers – do the analyzers get used

Alternatively, the element can contain:

* None – none of those things get used
* All – all of those things get used.

#### ExcludeAssets
`<ExcludeAssets>` child element specifies what assets belonging to the package specified by parent `<PackageReference>` should not 
be consumed.

The element can contain one or more of the following values:

* Compile – are the contents of the lib folder available to compile against
* Runtime – are the contents of the runtime folder distributed
* ContentFiles – are the contents of the contentfiles folder used
* Build – do the props/targets in the build folder get used
* Native – are the contents from native assets copied to the output folder for runtime
* Analyzers – do the analyzers get used

Alternatively, the element can contain:

* None – none of those things get used
* All – all of those things get used.

#### PrivateAssets
`<PrivateAssets>` child element specifies what assets belonging to the package specified by parent `<PackageReference>` should be 
consumed but that they should not flow to the next project. 

> [!NOTE]
> This is a new term for project.json/xproj `SuppressParent` element. 

The element can contain one or more of the following values:

* Compile – are the contents of the lib folder available to compile against
* Runtime – are the contents of the runtime folder distributed
* ContentFiles – are the contents of the contentfiles folder used
* Build – do the props/targets in the build folder get used
* Native – are the contents from native assets copied to the output folder for runtime
* Analyzers – do the analyzers get used

Alternatively, the element can contain:

* None – none of those things get used
* All – all of those things get used.

### DotnetCliToolReference
`<DotnetCliToolReference>` element specifies the CLI tool that the user wants restores in the context of the project. It is 
a replacement for the `tools` node in `project.json`. 

#### Version
`<Version>` specifies the version of the package to restore. The element respect the rules of the NuGet versioning scheme.

### RuntimeIdentifiers
`<RuntimeIdentifiers>` element allows specifying a semicolon-delimited list of [Runtime Identifiers](../../rid-catalog.md) for the project. 
These allow publishing self-contained deployments. 

