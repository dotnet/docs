---
title: Additions to the csproj format for .NET Core
description: Learn about the differences between existing and .NET Core csproj files
ms.topic: reference
ms.date: 04/08/2019
---

# Additions to the csproj format for .NET Core

This document outlines the changes that were added to the project files as part of the move from *project.json* to *csproj* and [MSBuild](https://github.com/Microsoft/MSBuild). For more information about general project file syntax and reference, see [the MSBuild project file](/visualstudio/msbuild/msbuild-project-file-schema-reference) documentation.


#### IncludeAssets, ExcludeAssets, and PrivateAssets

`IncludeAssets` attribute specifies which assets belonging to the package specified by `<PackageReference>` should be
consumed. By default, all package assets are included.

`ExcludeAssets` attribute specifies which assets belonging to the package specified by `<PackageReference>` should not
be consumed.

`PrivateAssets` attribute specifies which assets belonging to the package specified by `<PackageReference>` should be
consumed but not flow to the next project. The `Analyzers`, `Build` and `ContentFiles` assets are private by default
when this attribute is not present.

> [!NOTE]
> `PrivateAssets` is equivalent to the *project.json*/*xproj* `SuppressParent` element.

These attributes can contain one or more of the following items, separated by the semicolon `;` character if more than
one is listed:

- `Compile` – the contents of the *lib* folder are available to compile against.
- `Runtime` – the contents of the *runtime* folder are distributed.
- `ContentFiles` – the contents of the *contentfiles* folder are used.
- `Build` – the props/targets in the *build* folder are used.
- `Native` – the contents from native assets are copied to the *output* folder for runtime.
- `Analyzers` – the analyzers are used.

Alternatively, the attribute can contain:

- `None` – none of the assets are used.
- `All` – all assets are used.

## NuGet metadata properties

With the move to MSBuild, we have moved the input metadata that is used when packing a NuGet package from *project.json* to *.csproj* files. The inputs are MSBuild properties so they have to go within a `<PropertyGroup>` group. The following is the list of properties that are used as inputs to the packing process when using the `dotnet pack` command or the `Pack` MSBuild target that is part of the SDK:

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

### PackageDescription

A long description of the package for UI display.

### Description

A long description for the assembly. If `PackageDescription` is not specified, then this property is also used as the description of the package.

### Copyright

Copyright details for the package.

### PackageRequireLicenseAcceptance

A Boolean value that specifies whether the client must prompt the consumer to accept the package license before installing the package. The default is `false`.

### DevelopmentDependency

A Boolean value that specifies whether the package is marked as a development-only dependency, which prevents the package from being included as a dependency in other packages. With PackageReference (NuGet 4.8+), this flag also means that compile-time assets are excluded from compilation. For more information, see [DevelopmentDependency support for PackageReference](https://github.com/NuGet/Home/wiki/DevelopmentDependency-support-for-PackageReference).

### PackageLicenseExpression

An [SPDX license identifier](https://spdx.org/licenses/) or expression. For example, `Apache-2.0`.

Here is the complete list of [SPDX license identifiers](https://spdx.org/licenses/). NuGet.org accepts only OSI or FSF approved licenses when using license type expression.

The exact syntax of the license expressions is described below in [ABNF](https://tools.ietf.org/html/rfc5234).

```abnf
license-id            = <short form license identifier from https://spdx.org/spdx-specification-21-web-version#h.luq9dgcle9mo>

license-exception-id  = <short form license exception identifier from https://spdx.org/spdx-specification-21-web-version#h.ruv3yl8g6czd>

simple-expression = license-id / license-id”+”

compound-expression =  1*1(simple-expression /
                simple-expression "WITH" license-exception-id /
                compound-expression "AND" compound-expression /
                compound-expression "OR" compound-expression ) /
                "(" compound-expression ")" )

license-expression =  1*1(simple-expression / compound-expression / UNLICENSED)
```

> [!NOTE]
> Only one of `PackageLicenseExpression`, `PackageLicenseFile` and `PackageLicenseUrl` can be specified at a time.

### PackageLicenseFile

Path to a license file within the package if you are using a license that hasn’t been assigned an SPDX identifier, or it is a custom license (Otherwise `PackageLicenseExpression` is preferred)

Replaces `PackageLicenseUrl`, can't be combined with `PackageLicenseExpression`, and requires Visual Studio version 15.9.4 and .NET SDK 2.1.502 or 2.2.101 or newer.

You will need to ensure the license file is packed by adding it explicitly to the project, example usage:

```xml
<PropertyGroup>
  <PackageLicenseFile>LICENSE.txt</PackageLicenseFile>
</PropertyGroup>
<ItemGroup>
  <None Include="licenses\LICENSE.txt" Pack="true" PackagePath="$(PackageLicenseFile)"/>
</ItemGroup>
```

### PackageLicenseUrl

A URL to the license that is applicable to the package. (_deprecated since Visual Studio 15.9.4, .NET SDK 2.1.502 and 2.2.101_)

### PackageIcon

A path to an image in the package to use as a package icon. Read more about [`icon` metadata](/nuget/reference/nuspec#icon). [PackageIconUrl is deprecated](/nuget/reference/msbuild-targets#packageiconurl) in favor of PackageIcon.

### PackageReleaseNotes

Release notes for the package.

### PackageTags

A semicolon-delimited list of tags that designates the package.

### PackageOutputPath

Determines the output path in which the packed package will be dropped. Default is `$(OutputPath)`.

### IncludeSymbols

This Boolean value indicates whether the package should create an additional symbols package when the project is packed. The symbols package's format is controlled by the `SymbolPackageFormat` property.

### SymbolPackageFormat

Specifies the format of the symbols package. If "symbols.nupkg", a legacy symbols package will be created with a *.symbols.nupkg* extension containing PDBs, DLLs, and other output files. If "snupkg", a snupkg symbol package will be created containing the portable PDBs. Default is "symbols.nupkg".

### IncludeSource

This Boolean value indicates whether the pack process should create a source package. The source package contains the library's source code as well as PDB files. Source files are put under the `src/ProjectName` directory in the resulting package file.

### IsTool

Specifies whether all output files are copied to the *tools* folder instead of the *lib* folder. This is different from a `DotNetCliTool`, which is specified by setting the `PackageType` in the *.csproj* file.

### RepositoryUrl

Specifies the URL for the repository where the source code for the package resides and/or from which it's being built.

### RepositoryType

Specifies the type of the repository. Default is "git".

### RepositoryBranch

Specifies the name of the source branch in the repository. When the project is packaged in a NuGet package, it's added to the package metadata.

### RepositoryCommit

Optional repository commit or changeset to indicate which source the package was built against. `RepositoryUrl` must also be specified for this property to be included. When the project is packaged in a NuGet package, this commit or changeset is added to the package metadata.

### NoPackageAnalysis

Specifies that pack should not run package analysis after building the package.

### MinClientVersion

Specifies the minimum version of the NuGet client that can install this package, enforced by nuget.exe and the Visual Studio Package Manager.

### IncludeBuildOutput

This Boolean value specifies whether the build output assemblies should be packed into the *.nupkg* file or not.

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
