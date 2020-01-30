---
title: Additions to the csproj format for .NET Core
description: Learn about the differences between existing and .NET Core csproj files
ms.date: 04/08/2019
---
# Additions to the csproj format for .NET Core

This article outlines the changes that were added to project files as part of the move from *project.json* to *csproj* and [MSBuild](https://github.com/Microsoft/MSBuild). For more information about general project file syntax and reference, see [the MSBuild project file](/visualstudio/msbuild/msbuild-project-file-schema-reference) documentation.

## Implicit package references

Metapackages are implicitly referenced based on the target frameworks specified in the `<TargetFramework>` or `<TargetFrameworks>` property of the project file. `<TargetFrameworks>` is ignored if `<TargetFramework>` is specified, independent of order. For more information, see [Packages, metapackages, and frameworks](../packages.md).

```xml
 <PropertyGroup>
   <TargetFramework>netcoreapp2.1</TargetFramework>
 </PropertyGroup>
 ```

 ```xml
 <PropertyGroup>
   <TargetFrameworks>netcoreapp2.1;net462</TargetFrameworks>
 </PropertyGroup>
 ```

### Recommendations

Since `Microsoft.NETCore.App` or `NETStandard.Library` metapackages are implicitly referenced, consider the following guidelines:

- When targeting .NET Core or .NET Standard, never have an explicit reference to the `Microsoft.NETCore.App` or `NETStandard.Library` metapackages via a `<PackageReference>` item in your project file.
- If you need a specific version of the runtime when targeting .NET Core, use the `<RuntimeFrameworkVersion>` property in your project (for example, `1.0.4`) instead of referencing the metapackage.
  For example, if you're using [self-contained deployments](../deploying/index.md#self-contained-deployments-scd), you might need a specific patch version of 1.0.0 LTS runtime.
- If you need a specific version of the `NETStandard.Library` metapackage when targeting .NET Standard, you can use the `<NetStandardImplicitPackageVersion>` property and set the version you need.
- For .NET Framework projects, don't explicitly add or update references to either the `Microsoft.NETCore.App` or `NETStandard.Library` metapackage. If any version of `NETStandard.Library` is needed when using a .NET Standard-based NuGet package, NuGet automatically installs that version.

## Implicit version for some package references

Most usages of [`<PackageReference>`](#packagereference) require setting the `Version` attribute to specify the NuGet package version to be used. However, when using .NET Core 2.1 or 2.2 and referencing [Microsoft.AspNetCore.App](/aspnet/core/fundamentals/metapackage-app) or [Microsoft.AspNetCore.All](/aspnet/core/fundamentals/metapackage), the `Version` attribute is unnecessary. The .NET Core SDK can automatically select the appropriate version of these packages.

### Recommendation

When referencing the `Microsoft.AspNetCore.App` or `Microsoft.AspNetCore.All` packages, do not specify their version. If a version is specified, the SDK may produce warning NETSDK1071. To fix this warning, remove the package version like in the following example:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.AspNetCore.App" />
</ItemGroup>
```

> Known issue: the .NET Core 2.1 SDK only supported this syntax when the project also used Microsoft.NET.Sdk.Web. This is resolved in the .NET Core 2.2 SDK.

These references to ASP.NET Core metapackages have a slightly different behavior from most normal NuGet packages. [Framework-dependent deployments](../deploying/index.md#framework-dependent-deployments-fdd) of applications that use these metapackages automatically take advantage of the ASP.NET Core shared framework. When you use the metapackages, **no** assets from the referenced ASP.NET Core NuGet packages are deployed with the application&mdash;the ASP.NET Core shared framework contains these assets. The assets in the shared framework are optimized for the target platform to improve application startup time. For more information about shared framework, see [.NET Core distribution packaging](../distribution-packaging.md).

If a version *is* specified, it's treated as the *minimum* version of ASP.NET Core shared framework for framework-dependent deployments and as an *exact* version for self-contained deployments. This can have the following consequences:

- If the version of ASP.NET Core installed on the server is less than the version specified on the PackageReference, the .NET Core process fails to launch. Updates to the metapackage are often available on NuGet.org before updates have been made available in hosting environments such as Azure. Updating the version on the PackageReference to ASP.NET Core could cause a deployed application to fail.
- If the application is deployed as a [self-contained deployment](../deploying/index.md#self-contained-deployments-scd), the application may not contain the latest security updates to .NET Core. When a version isn't specified, the SDK can automatically include the newest version of ASP.NET Core in the self-contained deployment.

## Additions

### PackageReference

A `<PackageReference>` item element specifies a [NuGet dependency in the project](/nuget/consume-packages/package-references-in-project-files). The `Include` attribute specifies the package ID.

```xml
<PackageReference Include="<package-id>" Version="" PrivateAssets="" IncludeAssets="" ExcludeAssets="" />
```

#### Version

The required `Version` attribute specifies the version of the package to restore. The attribute respects the rules of the [NuGet versioning](/nuget/reference/package-versioning#version-ranges-and-wildcards) scheme. The default behavior is an exact version match. For example, specifying `Version="1.2.3"` is equivalent to NuGet notation `[1.2.3]` for the exact 1.2.3 version of the package.

#### IncludeAssets, ExcludeAssets, and PrivateAssets

`IncludeAssets` attribute specifies which assets belonging to the package specified by `<PackageReference>` should be consumed. By default, all package assets are included.

`ExcludeAssets` attribute specifies which assets belonging to the package specified by `<PackageReference>` should not be consumed.

`PrivateAssets` attribute specifies which assets belonging to the package specified by `<PackageReference>` should be consumed but not flow to the next project. The `Analyzers`, `Build`, and `ContentFiles` assets are private, by default, when this attribute is not present.

> [!NOTE]
> `PrivateAssets` is equivalent to the *project.json*/*xproj* `SuppressParent` element.

These attributes can contain one or more of the following items, separated by the semicolon `;` character if more than one is listed:

- `Compile` – the contents of the *lib* folder are available to compile against.
- `Runtime` – the contents of the *runtime* folder are distributed.
- `ContentFiles` – the contents of the *contentfiles* folder are used.
- `Build` – the props/targets in the *build* folder are used.
- `Native` – the contents from native assets are copied to the *output* folder for runtime.
- `Analyzers` – the analyzers are used.

Alternatively, the attribute can contain:

- `None` – none of the assets are used.
- `All` – all assets are used.

### DotNetCliToolReference

A `<DotNetCliToolReference>` item element specifies the CLI tool that the user wants to restore in the context of the project. It's a replacement for the `tools` node in *project.json*.

```xml
<DotNetCliToolReference Include="<package-id>" Version="" />
```

> [!NOTE]
> `DotNetCliToolReference` is [deprecated](https://github.com/dotnet/announcements/issues/107) in favor of [.NET Core Local Tools](https://aka.ms/local-tools).

#### Version

`Version` specifies the version of the package to restore. The attribute respects the rules of the [NuGet versioning](/nuget/create-packages/dependency-versions#version-ranges) scheme. The default behavior is an exact version match. For example, specifying `Version="1.2.3"` is equivalent to NuGet notation `[1.2.3]` for the exact 1.2.3 version of the package.

### RuntimeIdentifiers

The `<RuntimeIdentifiers>` property element lets you specify a semicolon-delimited list of [Runtime Identifiers (RIDs)](../rid-catalog.md) for the project. RIDs enable publishing self-contained deployments.

```xml
<RuntimeIdentifiers>win10-x64;osx.10.11-x64;ubuntu.16.04-x64</RuntimeIdentifiers>
```

### RuntimeIdentifier

The `<RuntimeIdentifier>` property element allows you to specify only one [Runtime Identifier (RID)](../rid-catalog.md) for the project. The RID enables publishing a self-contained deployment.

```xml
<RuntimeIdentifier>ubuntu.16.04-x64</RuntimeIdentifier>
```

Use `<RuntimeIdentifiers>` (plural) instead if you need to publish for multiple runtimes. `<RuntimeIdentifier>` can provide faster builds when only a single runtime is required.

### PackageTargetFallback

The `<PackageTargetFallback>` property element allows you to specify a set of compatible targets to be used when restoring packages. It's designed to allow packages that use the dotnet [TxM (Target x Moniker)](/nuget/schema/target-frameworks) to operate with packages that don't declare a dotnet TxM. If your project uses the dotnet TxM, then all the packages it depends on must also have a dotnet TxM, unless you add the `<PackageTargetFallback>` to your project in order to allow non-dotnet platforms to be compatible with dotnet.

The following example provides the fallbacks for all targets in your project:

```xml
<PackageTargetFallback>
    $(PackageTargetFallback);portable-net45+win8+wpa81+wp8
</PackageTargetFallback >
```

The following example specifies the fallbacks only for the `netcoreapp2.1` target:

```xml
<PackageTargetFallback Condition="'$(TargetFramework)'=='netcoreapp2.1'">
    $(PackageTargetFallback);portable-net45+win8+wpa81+wp8
</PackageTargetFallback >
```

## Build events

The way that pre-build and post-build events are specified in the project file has changed. The properties `PreBuildEvent` and `PostBuildEvent` are not recommended in the SDK-style project format, because macros such as `$(ProjectDir)` are not resolved. For example, the following code is no longer supported:

```xml
<PropertyGroup>
    <PreBuildEvent>"$(ProjectDir)PreBuildEvent.bat" "$(ProjectDir)..\" "$(ProjectDir)" "$(TargetDir)" />
</PropertyGroup>
```

In SDK-style projects, use an MSBuild target named `PreBuild` or `PostBuild` and set the `BeforeTargets` property for `PreBuild` or the `AfterTargets` property for `PostBuild`. For the preceding example, use the following code:

```xml
<Target Name="PreBuild" BeforeTargets="PreBuildEvent">
    <Exec Command="&quot;$(ProjectDir)PreBuildEvent.bat&quot; &quot;$(ProjectDir)..\&quot; &quot;$(ProjectDir)&quot; &quot;$(TargetDir)&quot;" />
</Target>

<Target Name="PostBuild" AfterTargets="PostBuildEvent">
   <Exec Command="echo Output written to $(TargetDir)" />
</Target>
```

> [!NOTE]
> You can use any name for the MSBuild targets. However, the Visual Studio integrated development environment (IDE) recognizes `PreBuild` and `PostBuild` targets, so use those names if you want to edit the commands in Visual Studio.

## NuGet metadata properties

With the move to MSBuild, the input metadata that's used when packing a NuGet package has moved from *project.json* to *.csproj* files. The inputs are MSBuild properties, so they have to go within a `<PropertyGroup>` group. The following is the list of properties that are used as inputs to the packing process when using the `dotnet pack` command or the `Pack` MSBuild target that's part of the SDK:

### IsPackable

Boolean value that specifies whether the project can be packed. The default value is `true`.

### PackageVersion

Specifies the version for the resulting package. Accepts all forms of NuGet version string. Default is the value of `$(Version)`, that is, of the property `Version` in the project.

### PackageId

Specifies the name for the resulting package. If not specified, the `pack` operation defaults to using the `AssemblyName` or directory name as the name of the package.

### Title

Human-friendly title of the package, typically used in UI displays as on nuget.org and the Package Manager in Visual Studio. If not specified, the package ID is used instead.

### Authors

Semicolon-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.

### PackageDescription

Long description of the package for UI display.

### Description

Long description for the assembly. If `PackageDescription` is not specified, then this property is also used as the description of the package.

### Copyright

Copyright details for the package.

### PackageRequireLicenseAcceptance

Boolean value that specifies whether the client must prompt the consumer to accept the package license before installing the package. The default is `false`.

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
> Only one of `PackageLicenseExpression`, `PackageLicenseFile`, and `PackageLicenseUrl` can be specified at a time.

### PackageLicenseFile

Path to a license file within the package if you're using a license that hasn’t been assigned an SPDX identifier, or it's a custom license (otherwise, `PackageLicenseExpression` is preferred).

Replaces `PackageLicenseUrl`, can't be combined with `PackageLicenseExpression`, and requires Visual Studio version 15.9.4 and .NET SDK 2.1.502 or 2.2.101 or newer.

Ensure that the license file is packed by adding it explicitly to the project, for example:

```xml
<PropertyGroup>
  <PackageLicenseFile>LICENSE.txt</PackageLicenseFile>
</PropertyGroup>
<ItemGroup>
  <None Include="licenses\LICENSE.txt" Pack="true" PackagePath="$(PackageLicenseFile)"/>
</ItemGroup>
```

### PackageLicenseUrl

A URL to the license that is applicable to the package. (Deprecated since Visual Studio 15.9.4, and .NET SDK 2.1.502 or 2.2.101.)

### PackageIconUrl

A URL for a 64x64 image with transparent background to use as the icon for the package in UI display.

### PackageReleaseNotes

Release notes for the package.

### PackageTags

A semicolon-delimited list of tags that designates the package.

### PackageOutputPath

Determines the output path in which the packed package will be dropped. Default is `$(OutputPath)`.

### IncludeSymbols

Boolean value that indicates whether the package should create an additional symbols package when the project is packed. The symbols package's format is controlled by the `SymbolPackageFormat` property.

### SymbolPackageFormat

Specifies the format of the symbols package. If "symbols.nupkg", a legacy symbols package is created with a *.symbols.nupkg* extension that contains PDBs, DLLs, and other output files. If "snupkg", a snupkg symbol package is created that contains the portable PDBs. Default is "symbols.nupkg".

### IncludeSource

Boolean value that indicates whether the pack process should create a source package. The source package contains the library's source code as well as PDB files. Source files are put under the `src/ProjectName` directory in the resulting package file.

### IsTool

Specifies whether all output files are copied to the *tools* folder instead of the *lib* folder. This is different from a `DotNetCliTool`, which is specified by setting the `PackageType` in the *.csproj* file.

### RepositoryUrl

Specifies the URL for the repository where the source code for the package resides or from which it's built.

### RepositoryType

Specifies the type of the repository. Default is "git".

### RepositoryBranch

Specifies the name of the source branch in the repository. When the project is packaged in a NuGet package, it's added to the package metadata.

### RepositoryCommit

Optional repository commit or changeset to indicate which source the package was built against. `RepositoryUrl` must also be specified for this property to be included. When the project is packaged in a NuGet package, this commit or changeset is added to the package metadata.

### NoPackageAnalysis

Specifies that pack should not run package analysis after building the package.

### MinClientVersion

Specifies the minimum version of the NuGet client that can install this package. Enforced by nuget.exe and the Visual Studio Package Manager.

### IncludeBuildOutput

Boolean value that specifies whether the build output assemblies should be packed into the *.nupkg* file or not.

### IncludeContentInPack

Boolean value that specifies whether any items that have a type of `Content` will be included in the resulting package automatically. The default is `true`.

### BuildOutputTargetFolder

Specifies the folder in which to place the output assemblies. The output assemblies (and other output files) are copied into their respective framework folders.

### ContentTargetFolders

Specifies the default location to place the content files if `PackagePath` is not specified for them. The default value is "content;contentFiles".

### NuspecFile

Relative or absolute path to the *.nuspec* file being used for packing.

> [!NOTE]
> If the *.nuspec* file is specified, it's exclusively used for packaging information. Any information in the projects is not used.

### NuspecBasePath

Base path for the *.nuspec* file.

### NuspecProperties

Semicolon separated list of key=value pairs.

## AssemblyInfo properties

[Assembly attributes](../../standard/assembly/set-attributes.md) that were typically present in an *AssemblyInfo* file are now automatically generated from properties.

### Properties per attribute

As shown in the following table, each attribute has a property that controls its content and another that disables its generation:

| Attribute                                                      | Property               | Property to disable                             |
|----------------------------------------------------------------|------------------------|-------------------------------------------------|
| <xref:System.Reflection.AssemblyCompanyAttribute>              | `Company`              | `GenerateAssemblyCompanyAttribute`              |
| <xref:System.Reflection.AssemblyConfigurationAttribute>        | `Configuration`        | `GenerateAssemblyConfigurationAttribute`        |
| <xref:System.Reflection.AssemblyCopyrightAttribute>            | `Copyright`            | `GenerateAssemblyCopyrightAttribute`            |
| <xref:System.Reflection.AssemblyDescriptionAttribute>          | `Description`          | `GenerateAssemblyDescriptionAttribute`          |
| <xref:System.Reflection.AssemblyFileVersionAttribute>          | `FileVersion`          | `GenerateAssemblyFileVersionAttribute`          |
| <xref:System.Reflection.AssemblyInformationalVersionAttribute> | `InformationalVersion` | `GenerateAssemblyInformationalVersionAttribute` |
| <xref:System.Reflection.AssemblyProductAttribute>              | `Product`              | `GenerateAssemblyProductAttribute`              |
| <xref:System.Reflection.AssemblyTitleAttribute>                | `AssemblyTitle`        | `GenerateAssemblyTitleAttribute`                |
| <xref:System.Reflection.AssemblyVersionAttribute>              | `AssemblyVersion`      | `GenerateAssemblyVersionAttribute`              |
| <xref:System.Resources.NeutralResourcesLanguageAttribute>      | `NeutralLanguage`      | `GenerateNeutralResourcesLanguageAttribute`     |

Remarks:

- `AssemblyVersion` and `FileVersion` default is to take the value of `$(Version)` without suffix. For example, if `$(Version)` is `1.2.3-beta.4`, then the value would be `1.2.3`.
- `InformationalVersion` defaults to the value of `$(Version)`.
- `InformationalVersion` has `$(SourceRevisionId)` appended if the property is present. It can be disabled using `IncludeSourceRevisionInInformationalVersion`.
- `Copyright` and `Description` properties are also used for NuGet metadata.
- `Configuration` is shared with all the build process and set via the `--configuration` parameter of `dotnet` commands.

### GenerateAssemblyInfo

A Boolean that enable or disable all the AssemblyInfo generation. The default value is `true`.

### GeneratedAssemblyInfoFile

The path of the generated assembly info file. Default to a file in the `$(IntermediateOutputPath)` (obj) directory.

## See also

- [MSBuild items](/visualstudio/msbuild/msbuild-items)
