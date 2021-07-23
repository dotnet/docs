---
title: MSBuild properties for Microsoft.NET.Sdk
description: Reference for the MSBuild properties and items that are understood by the .NET SDK.
ms.date: 02/14/2020
ms.topic: reference
ms.custom: updateeachrelease
---
# MSBuild reference for .NET SDK projects

This page is a reference for the MSBuild properties and items that you can use to configure .NET projects.

> [!NOTE]
> This page is a work in progress and does not list all of the useful MSBuild properties for the .NET SDK. For a list of common MSBuild properties, see [Common MSBuild properties](/visualstudio/msbuild/common-msbuild-project-properties).

## Framework properties

The following MSBuild properties are documented in this section:

- [TargetFramework](#targetframework)
- [TargetFrameworks](#targetframeworks)
- [NetStandardImplicitPackageVersion](#netstandardimplicitpackageversion)

### TargetFramework

The `TargetFramework` property specifies the target framework version for the app. For a list of valid target framework monikers, see [Target frameworks in SDK-style projects](../../standard/frameworks.md#supported-target-frameworks).

```xml
<PropertyGroup>
  <TargetFramework>netcoreapp3.1</TargetFramework>
</PropertyGroup>
```

For more information, see [Target frameworks in SDK-style projects](../../standard/frameworks.md).

### TargetFrameworks

Use the `TargetFrameworks` property when you want your app to target multiple platforms. For a list of valid target framework monikers, see [Target frameworks in SDK-style projects](../../standard/frameworks.md#supported-target-frameworks).

> [!NOTE]
> This property is ignored if `TargetFramework` (singular) is specified.

```xml
<PropertyGroup>
  <TargetFrameworks>netcoreapp3.1;net462</TargetFrameworks>
</PropertyGroup>
```

For more information, see [Target frameworks in SDK-style projects](../../standard/frameworks.md).

### NetStandardImplicitPackageVersion

> [!NOTE]
> This property only applies to projects using `netstandard1.x`. It doesn't apply to projects that use `netstandard2.x`.

Use the `NetStandardImplicitPackageVersion` property when you want to specify a framework version that's lower than the metapackage version. The project file in the following example targets `netstandard1.3` but uses the 1.6.0 version of `NETStandard.Library`.

```xml
<PropertyGroup>
  <TargetFramework>netstandard1.3</TargetFramework>
  <NetStandardImplicitPackageVersion>1.6.0</NetStandardImplicitPackageVersion>
</PropertyGroup>
```

## Assembly info generation properties

- [GenerateAssemblyCompanyAttribute](#generateassemblycompanyattribute)
- [GenerateAssemblyConfigurationAttribute](#generateassemblyconfigurationattribute)
- [GenerateAssemblyCopyrightAttribute](#generateassemblycopyrightattribute)
- [GenerateAssemblyDescriptionAttribute](#generateassemblydescriptionattribute)
- [GenerateAssemblyFileVersionAttribute](#generateassemblyfileversionattribute)
- [GenerateAssemblyInfo](#generateassemblyinfo)
- [GenerateAssemblyInformationalVersionAttribute](#generateassemblyinformationalversionattribute)
- [GenerateAssemblyProductAttribute](#generateassemblyproductattribute)
- [GenerateAssemblyTitleAttribute](#generateassemblytitleattribute)
- [GenerateAssemblyVersionAttribute](#generateassemblyversionattribute)
- [GeneratedAssemblyInfoFile](#generatedassemblyinfofile)
- [GenerateNeutralResourcesLanguageAttribute](#generateneutralresourceslanguageattribute)

### GenerateAssemblyCompanyAttribute

This property controls whether or not the `Company` property generates the <xref:System.Reflection.AssemblyCompanyAttribute> for the assembly. The default value is `true`.

```xml
<PropertyGroup>
  <GenerateAssemblyCompanyAttribute>false</GenerateAssemblyCompanyAttribute>
</PropertyGroup>
```

### GenerateAssemblyConfigurationAttribute

This property controls whether or not the `Configuration` property generates the <xref:System.Reflection.AssemblyConfigurationAttribute> for the assembly. The default value is `true`.

```xml
<PropertyGroup>
  <GenerateAssemblyConfigurationAttribute>false</GenerateAssemblyConfigurationAttribute>
</PropertyGroup>
```

### GenerateAssemblyCopyrightAttribute

This property controls whether or not the `Copyright` property generates the <xref:System.Reflection.AssemblyCopyrightAttribute> for the assembly. The default value is `true`.

```xml
<PropertyGroup>
  <GenerateAssemblyCopyrightAttribute>false</GenerateAssemblyCopyrightAttribute>
</PropertyGroup>
```

### GenerateAssemblyDescriptionAttribute

This property controls whether or not the `Description` property generates the <xref:System.Reflection.AssemblyDescriptionAttribute> for the assembly. The default value is `true`.

```xml
<PropertyGroup>
  <GenerateAssemblyDescriptionAttribute>false</GenerateAssemblyDescriptionAttribute>
</PropertyGroup>
```

### GenerateAssemblyFileVersionAttribute

This property controls whether or not the `FileVersion` property generates the <xref:System.Reflection.AssemblyFileVersionAttribute> for the assembly. The default value is `true`.

```xml
<PropertyGroup>
  <GenerateAssemblyFileVersionAttribute>false</GenerateAssemblyFileVersionAttribute>
</PropertyGroup>
```

### GenerateAssemblyInfo

Controls `AssemblyInfo` attribute generation for the project. The default value is `true`. Use `false` to disable generation of the file:

```xml
<PropertyGroup>
  <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
</PropertyGroup>
```

The [GeneratedAssemblyInfoFile](#generatedassemblyinfofile) setting controls the name of the generated file.

When the `GenerateAssemblyInfo` value is `true`, project properties are transformed into `AssemblyInfo` attributes. The following table lists the project properties that generate the attributes, and the properties that can disable that generation:

| Property               | Attribute                                                      | Property to disable                                                                               |
|------------------------|----------------------------------------------------------------|---------------------------------------------------------------------------------------------------|
| `Company`              | <xref:System.Reflection.AssemblyCompanyAttribute>              | [`GenerateAssemblyCompanyAttribute`](#generateassemblycompanyattribute)                           |
| `Configuration`        | <xref:System.Reflection.AssemblyConfigurationAttribute>        | [`GenerateAssemblyConfigurationAttribute`](#generateassemblyconfigurationattribute)               |
| `Copyright`            | <xref:System.Reflection.AssemblyCopyrightAttribute>            | [`GenerateAssemblyCopyrightAttribute`](#generateassemblycopyrightattribute)                       |
| `Description`          | <xref:System.Reflection.AssemblyDescriptionAttribute>          | [`GenerateAssemblyDescriptionAttribute`](#generateassemblydescriptionattribute)                   |
| `FileVersion`          | <xref:System.Reflection.AssemblyFileVersionAttribute>          | [`GenerateAssemblyFileVersionAttribute`](#generateassemblyfileversionattribute)                   |
| `InformationalVersion` | <xref:System.Reflection.AssemblyInformationalVersionAttribute> | [`GenerateAssemblyInformationalVersionAttribute`](#generateassemblyinformationalversionattribute) |
| `Product`              | <xref:System.Reflection.AssemblyProductAttribute>              | [`GenerateAssemblyProductAttribute`](#generateassemblyproductattribute)                           |
| `AssemblyTitle`        | <xref:System.Reflection.AssemblyTitleAttribute>                | [`GenerateAssemblyTitleAttribute`](#generateassemblytitleattribute)                               |
| `AssemblyVersion`      | <xref:System.Reflection.AssemblyVersionAttribute>              | [`GenerateAssemblyVersionAttribute`](#generateassemblyversionattribute)                           |
| `NeutralLanguage`      | <xref:System.Resources.NeutralResourcesLanguageAttribute>      | [`GenerateNeutralResourcesLanguageAttribute`](#generateneutralresourceslanguageattribute)         |

Notes about these settings:

- `AssemblyVersion` and `FileVersion` default to the value of `$(Version)` without the suffix. For example, if `$(Version)` is `1.2.3-beta.4`, then the value would be `1.2.3`.
- `InformationalVersion` defaults to the value of `$(Version)`.
- If the `$(SourceRevisionId)` property is present, it's appended to `InformationalVersion`. You can disable this behavior using `IncludeSourceRevisionInInformationalVersion`.
- `Copyright` and `Description` properties are also used for NuGet metadata.
- `Configuration`, which defaults to `Debug`, is shared with all MSBuild targets. You can set it via the `--configuration` option of `dotnet` commands, for example, [dotnet pack](../tools/dotnet-pack.md).
- Some of the properties are used when creating a NuGet package. For more information, see [Package properties](#package-properties).

#### Migrating from .NET Framework

.NET Framework project templates create a code file with these assembly info attributes set. The file is typically located at *.\Properties\AssemblyInfo.cs* or *.\Properties\AssemblyInfo.vb*. SDK-style projects generate this file for you based on the project settings. **You can't have both.** When porting your code to .NET 5 (and .NET Core 3.1) or later, do one of the following:

- Disable the generation of the temporary code file that contains the assembly info attributes by setting `GenerateAssemblyInfo` to `false`. This enables you to keep your *AssemblyInfo* file.
- Migrate the settings in the `AssemblyInfo` file to the project file, and delete the `AssemblyInfo` file.

### GenerateAssemblyInformationalVersionAttribute

This property controls whether or not the `InformationalVersion` property generates the <xref:System.Reflection.AssemblyInformationalVersionAttribute> for the assembly. The default value is `true`.

```xml
<PropertyGroup>
  <GenerateAssemblyInformationalVersionAttribute>false</GenerateAssemblyInformationalVersionAttribute>
</PropertyGroup>
```

### GenerateAssemblyProductAttribute

This property controls whether or not the `Product` property generates the <xref:System.Reflection.AssemblyProductAttribute> for the assembly. The default value is `true`.

```xml
<PropertyGroup>
  <GenerateAssemblyProductAttribute>false</GenerateAssemblyProductAttribute>
</PropertyGroup>
```

### GenerateAssemblyTitleAttribute

This property controls whether or not the `AssemblyTitle` property generates the <xref:System.Reflection.AssemblyTitleAttribute> for the assembly. The default value is `true`.

```xml
<PropertyGroup>
  <GenerateAssemblyTitleAttribute>false</GenerateAssemblyTitleAttribute>
</PropertyGroup>
```

### GenerateAssemblyVersionAttribute

This property controls whether or not the `AssemblyVersion` property generates the <xref:System.Reflection.AssemblyVersionAttribute> for the assembly. The default value is `true`.

```xml
<PropertyGroup>
  <GenerateAssemblyVersionAttribute>false</GenerateAssemblyVersionAttribute>
</PropertyGroup>
```

### GeneratedAssemblyInfoFile

The property defines the relative or absolute path of the generated assembly info file. Defaults to a file named *[project-name].AssemblyInfo.[cs|vb]* in the `$(IntermediateOutputPath)` (usually the *obj*) directory.

```xml
<PropertyGroup>
  <GeneratedAssemblyInfoFile>assemblyinfo.cs</GeneratedAssemblyInfoFile>
</PropertyGroup>
```

### GenerateNeutralResourcesLanguageAttribute

This property controls whether or not the `NeutralLanguage` property generates the <xref:System.Resources.NeutralResourcesLanguageAttribute> for the assembly. The default value is `true`.

```xml
<PropertyGroup>
  <GenerateNeutralResourcesLanguageAttribute>false</GenerateNeutralResourcesLanguageAttribute>
</PropertyGroup>
```

## Package properties

You can specify properties such as `PackageId`, `PackageVersion`, `PackageIcon`, `Title`, and `Description` to describe the package that gets created from your project. For information about these and other properties, see [pack target](/nuget/reference/msbuild-targets#pack-target).

```xml
<PropertyGroup>
  ...
  <PackageId>ClassLibDotNetStandard</PackageId>
  <Version>1.0.0</Version>
  <Authors>John Doe</Authors>
  <Company>Contoso</Company>
</PropertyGroup>
```

## Publish-related properties

The following MSBuild properties are documented in this section:

- [AppendRuntimeIdentifierToOutputPath](#appendruntimeidentifiertooutputpath)
- [AppendTargetFrameworkToOutputPath](#appendtargetframeworktooutputpath)
- [CopyLocalLockFileAssemblies](#copylocallockfileassemblies)
- [ErrorOnDuplicatePublishOutputFiles](#erroronduplicatepublishoutputfiles)
- [IsPublishable](#ispublishable)
- [PreserveCompilationContext](#preservecompilationcontext)
- [PreserveCompilationReferences](#preservecompilationreferences)
- [RollForward](#rollforward)
- [RuntimeFrameworkVersion](#runtimeframeworkversion)
- [RuntimeIdentifier](#runtimeidentifier)
- [RuntimeIdentifiers](#runtimeidentifiers)
- [UseAppHost](#useapphost)

### AppendTargetFrameworkToOutputPath

The `AppendTargetFrameworkToOutputPath` property controls whether the [target framework moniker (TFM)](../../standard/frameworks.md) is appended to the output path (which is defined by [OutputPath](/visualstudio/msbuild/common-msbuild-project-properties#list-of-common-properties-and-parameters)). The .NET SDK automatically appends the target framework and, if present, the runtime identifier to the output path. Setting `AppendTargetFrameworkToOutputPath` to `false` prevents the TFM from being appended to the output path. However, without the TFM in the output path, multiple build artifacts may overwrite each other.

For example, for a .NET 5.0 app, the output path changes from `bin\Debug\net5.0` to `bin\Debug` with the following setting:

```xml
<PropertyGroup>
  <AppendTargetFrameworkToOutputPath>false</AppendTargetFrameworkToOutputPath>
</PropertyGroup>
```

### AppendRuntimeIdentifierToOutputPath

The `AppendRuntimeIdentifierToOutputPath` property controls whether the [runtime identifier (RID)](../rid-catalog.md) is appended to the output path. The .NET SDK automatically appends the target framework and, if present, the runtime identifier to the output path. Setting `AppendRuntimeIdentifierToOutputPath` to `false` prevents the RID from being appended to the output path.

For example, for a .NET 5.0 app and an RID of `win10-x64`, the output path changes from `bin\Debug\net5.0\win10-x64` to `bin\Debug\net5.0` with the following setting:

```xml
<PropertyGroup>
  <AppendRuntimeIdentifierToOutputPath>false</AppendRuntimeIdentifierToOutputPath>
</PropertyGroup>
```

### CopyLocalLockFileAssemblies

The `CopyLocalLockFileAssemblies` property is useful for plugin projects that have dependencies on other libraries. If you set this property to `true`, any NuGet package dependencies are copied to the output directory. That means you can use the output of `dotnet build` to run your plugin on any machine.

```xml
<PropertyGroup>
  <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
</PropertyGroup>
```

> [!TIP]
> Alternatively, you can use `dotnet publish` to publish the class library. For more information, see [dotnet publish](../tools/dotnet-publish.md).

## ErrorOnDuplicatePublishOutputFiles

The `ErrorOnDuplicatePublishOutputFiles` property relates to whether the SDK generates error NETSDK1148 when MSBuild detects duplicate files in the publish output, but can't determine which files to remove. Set the `ErrorOnDuplicatePublishOutputFiles` property to `false` if you don't want the error to be generated.

```xml
<PropertyGroup>
  <ErrorOnDuplicatePublishOutputFiles>false</ErrorOnDuplicatePublishOutputFiles>
</PropertyGroup>
```

This property was introduced in .NET 6.

### IsPublishable

The `IsPublishable` property allows the `Publish` target to run. This property only affects processes that use *.\*proj* files and the `Publish` target, such as the [dotnet publish](../tools/dotnet-publish.md) command. It does not affect publishing in Visual Studio, which uses the `PublishOnly` target. The default value is `true`.

This property is useful if you run `dotnet publish` on a solution file, as it allows automatic selection of projects that should be published.

```xml
<PropertyGroup>
  <IsPublishable>false</IsPublishable>
</PropertyGroup>
```

### PreserveCompilationContext

The `PreserveCompilationContext` property allows a built or published application to compile more code at run time using the same settings that were used at build time. The assemblies referenced at build time will be copied into the *ref* subdirectory of the output directory. The names of the reference assemblies are stored in the application's *.deps.json* file along with the options passed to the compiler. You can retrieve this information using the <xref:Microsoft.Extensions.DependencyModel.DependencyContext.CompileLibraries?displayProperty=nameWithType> and <xref:Microsoft.Extensions.DependencyModel.DependencyContext.CompilationOptions?displayProperty=nameWithType> properties.

This functionality is mostly used internally by ASP.NET Core MVC and Razor pages to support run-time compilation of Razor files.

```xml
<PropertyGroup>
  <PreserveCompilationContext>true</PreserveCompilationContext>
</PropertyGroup>
```

### PreserveCompilationReferences

The `PreserveCompilationReferences` property is similar to the [PreserveCompilationContext](#preservecompilationcontext) property, except that it only copies the referenced assemblies to the publish directory, and not the *.deps.json* file.

```xml
<PropertyGroup>
  <PreserveCompilationReferences>true</PreserveCompilationReferences>
</PropertyGroup>
```

For more information, see [Razor SDK properties](/aspnet/core/razor-pages/sdk#properties).

### RollForward

The `RollForward` property controls how the application chooses a runtime when multiple runtime versions are available. This value is output to the *.runtimeconfig.json* as the `rollForward` setting.

```xml
<PropertyGroup>
  <RollForward>LatestMinor</RollForward>
</PropertyGroup>
```

Set `RollForward` to one of the following values:

[!INCLUDE [roll-forward-table](../../../includes/roll-forward-table.md)]

For more information, see [Control roll-forward behavior](../versions/selection.md#control-roll-forward-behavior).

### RuntimeFrameworkVersion

The `RuntimeFrameworkVersion` property specifies the version of the runtime to use when publishing. Specify a runtime version:

``` xml
<PropertyGroup>
  <RuntimeFrameworkVersion>5.0.7</RuntimeFrameworkVersion>
</PropertyGroup>
```

When publishing a framework-dependent application, this value specifies the *minimum* version required. When publishing a self-contained application, this value specifies the *exact* version required.

### RuntimeIdentifier

The `RuntimeIdentifier` property lets you specify a single [runtime identifier (RID)](../rid-catalog.md) for the project. The RID enables publishing a self-contained deployment.

```xml
<PropertyGroup>
  <RuntimeIdentifier>ubuntu.16.04-x64</RuntimeIdentifier>
</PropertyGroup>
```

### RuntimeIdentifiers

The `RuntimeIdentifiers` property lets you specify a semicolon-delimited list of [runtime identifiers (RIDs)](../rid-catalog.md) for the project. Use this property if you need to publish for multiple runtimes. `RuntimeIdentifiers` is used at restore time to ensure the right assets are in the graph.

> [!TIP]
> `RuntimeIdentifier` (singular) can provide faster builds when only a single runtime is required.

```xml
<PropertyGroup>
  <RuntimeIdentifiers>win10-x64;osx.10.11-x64;ubuntu.16.04-x64</RuntimeIdentifiers>
</PropertyGroup>
```

### UseAppHost

The `UseAppHost` property controls whether or not a native executable is created for a deployment. A native executable is required for self-contained deployments.

In .NET Core 3.0 and later versions, a framework-dependent executable is created by default. Set the `UseAppHost` property to `false` to disable generation of the executable.

```xml
<PropertyGroup>
  <UseAppHost>false</UseAppHost>
</PropertyGroup>
```

For more information about deployment, see [.NET application deployment](../deploying/index.md).

## Compilation-related properties

The following MSBuild properties are documented in this section:

- [EmbeddedResourceUseDependentUponConvention](#embeddedresourceusedependentuponconvention)
- [LangVersion](#langversion)

### EmbeddedResourceUseDependentUponConvention

The `EmbeddedResourceUseDependentUponConvention` property defines whether resource manifest file names are generated from type information in source files that are colocated with resource files. For example, if *Form1.resx* is in the same folder as *Form1.cs*, and `EmbeddedResourceUseDependentUponConvention` is set to `true`, the generated *.resources* file takes its name from the first type that's defined in *Form1.cs*. For example, if `MyNamespace.Form1` is the first type defined in *Form1.cs*, the generated file name is *MyNamespace.Form1.resources*.

> [!NOTE]
> If `LogicalName`, `ManifestResourceName`, or `DependentUpon` metadata is specified for an `EmbeddedResource` item, the generated manifest file name for that resource file is based on that metadata instead.

By default, in a new .NET project, this property is set to `true`. If set to `false`, and no `LogicalName`, `ManifestResourceName`, or `DependentUpon` metadata is specified for the `EmbeddedResource` item in the project file, the resource manifest file name is based off the root namespace for the project and the relative file path to the *.resx* file. For more information, see [How resource manifest files are named](../resources/manifest-file-names.md).

```xml
<PropertyGroup>
  <EmbeddedResourceUseDependentUponConvention>true</EmbeddedResourceUseDependentUponConvention>
</PropertyGroup>
```

### LangVersion

The `LangVersion` property lets you specify a specific programming language version. For example, if you want access to C# preview features, set `LangVersion` to `preview`.

```xml
<PropertyGroup>
  <LangVersion>preview</LangVersion>
</PropertyGroup>
```

For more information, see [C# language versioning](../../csharp/language-reference/configure-language-version.md#override-a-default).

## Default item inclusion properties

The following MSBuild properties are documented in this section:

- [DefaultExcludesInProjectFolder](#defaultexcludesinprojectfolder)
- [DefaultItemExcludes](#defaultitemexcludes)
- [EnableDefaultCompileItems](#enabledefaultcompileitems)
- [EnableDefaultEmbeddedResourceItems](#enabledefaultembeddedresourceitems)
- [EnableDefaultItems](#enabledefaultitems)
- [EnableDefaultNoneItems](#enabledefaultnoneitems)

For more information, see [Default includes and excludes](overview.md#default-includes-and-excludes).

### DefaultItemExcludes

Use the `DefaultItemExcludes` property to define glob patterns for files and folders that should be excluded from the include, exclude, and remove globs. By default, the *./bin* and *./obj* folders are excluded from the glob patterns.

```xml
<PropertyGroup>
  <DefaultItemExcludes>$(DefaultItemExcludes);**/*.myextension</DefaultItemExcludes>
</PropertyGroup>
```

### DefaultExcludesInProjectFolder

Use the `DefaultExcludesInProjectFolder` property to define glob patterns for files and folders in the project folder that should be excluded from the include, exclude, and remove globs. By default, folders that start with a period (`.`), such as *.git* and *.vs*, are excluded from the glob patterns.

This property is very similar to the `DefaultItemExcludes` property, except that it only considers files and folders in the project folder. When a glob pattern would unintentionally match items outside the project folder with a relative path, use the `DefaultExcludesInProjectFolder` property instead of the `DefaultItemExcludes` property.

```xml
<PropertyGroup>
  <DefaultExcludesInProjectFolder>$(DefaultExcludesInProjectFolder);**/myprefix*/**</DefaultExcludesInProjectFolder>
</PropertyGroup>
```

### EnableDefaultItems

The `EnableDefaultItems` property controls whether compile items, embedded resource items, and `None` items are implicitly included in the project. The default value is `true`. Set the `EnableDefaultItems` property to `false` to disable all implicit file inclusion.

```xml
<PropertyGroup>
  <EnableDefaultItems>false</EnableDefaultItems>
</PropertyGroup>
```

### EnableDefaultCompileItems

The `EnableDefaultCompileItems` property controls whether compile items are implicitly included in the project. The default value is `true`. Set the `EnableDefaultCompileItems` property to `false` to disable implicit inclusion of *.cs and other language-extension files.

```xml
<PropertyGroup>
  <EnableDefaultCompileItems>false</EnableDefaultCompileItems>
</PropertyGroup>
```

### EnableDefaultEmbeddedResourceItems

The `EnableDefaultEmbeddedResourceItems` property controls whether embedded resource items are implicitly included in the project. The default value is `true`. Set the `EnableDefaultEmbeddedResourceItems` property to `false` to disable implicit inclusion of embedded resource files.

```xml
<PropertyGroup>
  <EnableDefaultEmbeddedResourceItems>false</EnableDefaultEmbeddedResourceItems>
</PropertyGroup>
```

### EnableDefaultNoneItems

The `EnableDefaultNoneItems` property controls whether `None` items (files that have no role in the build process) are implicitly included in the project. The default value is `true`. Set the `EnableDefaultNoneItems` property to `false` to disable implicit inclusion of `None` items.

```xml
<PropertyGroup>
  <EnableDefaultNoneItems>false</EnableDefaultNoneItems>
</PropertyGroup>
```

## Code analysis properties

The following MSBuild properties are documented in this section:

- [AnalysisLevel](#analysislevel)
- [AnalysisMode](#analysismode)
- [CodeAnalysisTreatWarningsAsErrors](#codeanalysistreatwarningsaserrors)
- [EnableNETAnalyzers](#enablenetanalyzers)
- [EnforceCodeStyleInBuild](#enforcecodestyleinbuild)

### AnalysisLevel

The `AnalysisLevel` property lets you specify a code-analysis level. For example, if you want access to preview code analyzers, set `AnalysisLevel` to `preview`.

Default value:

- If your project targets .NET 5.0 or later, or if you've added the [AnalysisMode](#analysismode) property, the default value is `latest`.
- Otherwise, this property is omitted unless you explicitly add it to the project file.

```xml
<PropertyGroup>
  <AnalysisLevel>preview</AnalysisLevel>
</PropertyGroup>
```

The following table shows the available options.

| Value | Meaning |
|-|-|
| `latest` | The latest code analyzers that have been released are used. This is the default. |
| `preview` | The latest code analyzers are used, even if they are in preview. |
| `5.0` | The set of rules that was enabled for the .NET 5.0 release is used, even if newer rules are available. |
| `5` | The set of rules that was enabled for the .NET 5.0 release is used, even if newer rules are available. |

> [!NOTE]
> This property has no effect on code analysis in projects that don't reference a [project SDK](overview.md), for example, legacy .NET Framework projects that reference the Microsoft.CodeAnalysis.NetAnalyzers NuGet package.

### AnalysisMode

Starting with .NET 5.0, the .NET SDK ships with all of the ["CA" code quality rules](../../fundamentals/code-analysis/quality-rules/index.md). By default, only [some rules are enabled](../../fundamentals/code-analysis/overview.md#enabled-rules) as build warnings. The `AnalysisMode` property lets you customize the set of rules that are enabled by default. You can either switch to a more aggressive (opt-out) analysis mode or a more conservative (opt-in) analysis mode. For example, if you want to enable all rules by default as build warnings, set the value to `AllEnabledByDefault`.

```xml
<PropertyGroup>
  <AnalysisMode>AllEnabledByDefault</AnalysisMode>
</PropertyGroup>
```

The following table shows the available options.

| Value | Meaning |
|-|-|
| `Default` | Default mode, where certain rules are enabled as build warnings, certain rules are enabled as Visual Studio IDE suggestions, and the remainder are disabled. |
| `AllEnabledByDefault` | Aggressive or opt-out mode, where all rules are enabled by default as build warnings. You can selectively [opt out](../../fundamentals/code-analysis/configuration-options.md) of individual rules to disable them. |
| `AllDisabledByDefault` | Conservative or opt-in mode, where all rules are disabled by default. You can selectively [opt into](../../fundamentals/code-analysis/configuration-options.md) individual rules to enable them. |

> [!NOTE]
> This property has no effect on code analysis in projects that don't reference a [project SDK](overview.md), for example, legacy .NET Framework projects that reference the Microsoft.CodeAnalysis.NetAnalyzers NuGet package.

### CodeAnalysisTreatWarningsAsErrors

The `CodeAnalysisTreatWarningsAsErrors` property lets you configure whether code quality analysis warnings (CAxxxx) should be treated as warnings and break the build. If you use the `-warnaserror` flag when you build your projects, [.NET code quality analysis](../../fundamentals/code-analysis/overview.md#code-quality-analysis) warnings are also treated as errors. If you do not want code quality analysis warnings to be treated as errors, you can set the `CodeAnalysisTreatWarningsAsErrors` MSBuild property to `false` in your project file.

```xml
<PropertyGroup>
  <CodeAnalysisTreatWarningsAsErrors>false</CodeAnalysisTreatWarningsAsErrors>
</PropertyGroup>
```

### EnableNETAnalyzers

[.NET code quality analysis](../../fundamentals/code-analysis/overview.md#code-quality-analysis) is enabled, by default, for projects that target .NET 5.0 or later. You can enable .NET code analysis for SDK-style projects that target earlier versions of .NET by setting the `EnableNETAnalyzers` property to `true`. To disable code analysis in any project, set this property to `false`.

```xml
<PropertyGroup>
  <EnableNETAnalyzers>true</EnableNETAnalyzers>
</PropertyGroup>
```

> [!NOTE]
> This property applies specifically to the built-in analyzers in the .NET 5+ SDK. It should not be used when you install a NuGet code analysis package.

### EnforceCodeStyleInBuild

> [!NOTE]
> This feature is currently experimental and may change between the .NET 5 and .NET 6 releases.

[.NET code style analysis](../../fundamentals/code-analysis/overview.md#code-style-analysis) is disabled, by default, on build for all .NET projects. You can enable code style analysis for .NET projects by setting the `EnforceCodeStyleInBuild` property to `true`.

```xml
<PropertyGroup>
  <EnforceCodeStyleInBuild>true</EnforceCodeStyleInBuild>
</PropertyGroup>
```

All code style rules that are [configured](../../fundamentals/code-analysis/overview.md#code-style-analysis) to be warnings or errors will execute on build and report violations.

## Run-time configuration properties

You can configure some run-time behaviors by specifying MSBuild properties in the project file of the app. For information about other ways of configuring run-time behavior, see [Run-time configuration settings](../run-time-config/index.md).

- [ConcurrentGarbageCollection](#concurrentgarbagecollection)
- [InvariantGlobalization](#invariantglobalization)
- [RetainVMGarbageCollection](#retainvmgarbagecollection)
- [ServerGarbageCollection](#servergarbagecollection)
- [ThreadPoolMaxThreads](#threadpoolmaxthreads)
- [ThreadPoolMinThreads](#threadpoolminthreads)
- [TieredCompilation](#tieredcompilation)
- [TieredCompilationQuickJit](#tieredcompilationquickjit)
- [TieredCompilationQuickJitForLoops](#tieredcompilationquickjitforloops)

### ConcurrentGarbageCollection

The `ConcurrentGarbageCollection` property configures whether [background (concurrent) garbage collection](../../standard/garbage-collection/background-gc.md) is enabled. Set the value to `false` to disable background garbage collection. For more information, see [Background GC](../run-time-config/garbage-collector.md#background-gc).

```xml
<PropertyGroup>
  <ConcurrentGarbageCollection>false</ConcurrentGarbageCollection>
</PropertyGroup>
```

### InvariantGlobalization

The `InvariantGlobalization` property configures whether the app runs in *globalization-invariant* mode, which means it doesn't have access to culture-specific data. Set the value to `true` to run in globalization-invariant mode. For more information, see [Invariant mode](../run-time-config/globalization.md#invariant-mode).

```xml
<PropertyGroup>
  <InvariantGlobalization>true</InvariantGlobalization>
</PropertyGroup>
```

### RetainVMGarbageCollection

The `RetainVMGarbageCollection` property configures the garbage collector to put deleted memory segments on a standby list for future use or release them. Setting the value to `true` tells the garbage collector to put the segments on a standby list. For more information, see [Retain VM](../run-time-config/garbage-collector.md#retain-vm).

```xml
<PropertyGroup>
  <RetainVMGarbageCollection>true</RetainVMGarbageCollection>
</PropertyGroup>
```

### ServerGarbageCollection

The `ServerGarbageCollection` property configures whether the application uses [workstation garbage collection or server garbage collection](../../standard/garbage-collection/workstation-server-gc.md). Set the value to `true` to use server garbage collection. For more information, see [Workstation vs. server](../run-time-config/garbage-collector.md#workstation-vs-server).

```xml
<PropertyGroup>
  <ServerGarbageCollection>true</ServerGarbageCollection>
</PropertyGroup>
```

### ThreadPoolMaxThreads

The `ThreadPoolMaxThreads` property configures the maximum number of threads for the worker thread pool. For more information, see [Maximum threads](../run-time-config/threading.md#maximum-threads).

```xml
<PropertyGroup>
  <ThreadPoolMaxThreads>20</ThreadPoolMaxThreads>
</PropertyGroup>
```

### ThreadPoolMinThreads

The `ThreadPoolMinThreads` property configures the minimum number of threads for the worker thread pool. For more information, see [Minimum threads](../run-time-config/threading.md#minimum-threads).

```xml
<PropertyGroup>
  <ThreadPoolMinThreads>4</ThreadPoolMinThreads>
</PropertyGroup>
```

### TieredCompilation

The `TieredCompilation` property configures whether the just-in-time (JIT) compiler uses [tiered compilation](../whats-new/dotnet-core-3-0.md#tiered-compilation). Set the value to `false` to disable tiered compilation. For more information, see [Tiered compilation](../run-time-config/compilation.md#tiered-compilation).

```xml
<PropertyGroup>
  <TieredCompilation>false</TieredCompilation>
</PropertyGroup>
```

### TieredCompilationQuickJit

The `TieredCompilationQuickJit` property configures whether the JIT compiler uses quick JIT. Set the value to `false` to disable quick JIT. For more information, see [Quick JIT](../run-time-config/compilation.md#quick-jit).

```xml
<PropertyGroup>
  <TieredCompilationQuickJit>false</TieredCompilationQuickJit>
</PropertyGroup>
```

### TieredCompilationQuickJitForLoops

The `TieredCompilationQuickJitForLoops` property configures whether the JIT compiler uses quick JIT on methods that contain loops. Set the value to `true` to enable quick JIT on methods that contain loops. For more information, see [Quick JIT for loops](../run-time-config/compilation.md#quick-jit-for-loops).

```xml
<PropertyGroup>
  <TieredCompilationQuickJitForLoops>true</TieredCompilationQuickJitForLoops>
</PropertyGroup>
```

## Reference properties

The following MSBuild properties are documented in this section:

- [AssetTargetFallback](#assettargetfallback)
- [DisableImplicitFrameworkReferences](#disableimplicitframeworkreferences)
- [Restore-related properties](#restore-related-properties)
- [ValidateExecutableReferencesMatchSelfContained](#validateexecutablereferencesmatchselfcontained)

### AssetTargetFallback

The `AssetTargetFallback` property lets you specify additional compatible framework versions for project references and NuGet packages. For example, if you specify a package dependency using `PackageReference` but that package doesn't contain assets that are compatible with your projects's `TargetFramework`, the `AssetTargetFallback` property comes into play. The compatibility of the referenced package is rechecked using each target framework that's specified in `AssetTargetFallback`. This property replaces the deprecated property `PackageTargetFallback`.

You can set the `AssetTargetFallback` property to one or more [target framework versions](../../standard/frameworks.md#supported-target-frameworks).

```xml
<PropertyGroup>
  <AssetTargetFallback>net461</AssetTargetFallback>
</PropertyGroup>
```

### DisableImplicitFrameworkReferences

The `DisableImplicitFrameworkReferences` property controls implicit `FrameworkReference` items when targeting .NET Core 3.0 and later versions. When targeting .NET Core 2.1 or .NET Standard 2.0 and earlier versions, it controls implicit [PackageReference](#packagereference) items to packages in a metapackage. (A metapackage is a framework-based package that consist only of dependencies on other packages.) This property also controls implicit references such as `System` and `System.Core` when targeting .NET Framework.

Set this property to `true` to disable implicit `FrameworkReference` or [PackageReference](#packagereference) items. If you set this property to `true`, you can add explicit references to just the frameworks or packages you need.

```xml
<PropertyGroup>
  <DisableImplicitFrameworkReferences>true</DisableImplicitFrameworkReferences>
</PropertyGroup>
```

### Restore-related properties

Restoring a referenced package installs all of its direct dependencies and all the dependencies of those dependencies. You can customize package restoration by specifying properties such as `RestorePackagesPath` and `RestoreIgnoreFailedSources`. For more information about these and other properties, see [restore target](/nuget/reference/msbuild-targets#restore-target).

```xml
<PropertyGroup>
  <RestoreIgnoreFailedSource>true</RestoreIgnoreFailedSource>
</PropertyGroup>
```

### ValidateExecutableReferencesMatchSelfContained

The `ValidateExecutableReferencesMatchSelfContained` property can be used to disable errors related to executable project references. If .NET detects that a self-contained executable project references a framework-dependent executable project, or vice versa, it generates errors NETSDK1150 and NETSDK1151, respectively. To avoid these errors when the reference is intentional, set the `ValidateExecutableReferencesMatchSelfContained` property to `false`.

```xml
<PropertyGroup>
  <ValidateExecutableReferencesMatchSelfContained>false</ValidateExecutableReferencesMatchSelfContained>
</PropertyGroup>
```

## Run-related properties

The following properties are used for launching an app with the [`dotnet run`](../tools/dotnet-run.md) command:

- [RunArguments](#runarguments)
- [RunWorkingDirectory](#runworkingdirectory)

### RunArguments

The `RunArguments` property defines the arguments that are passed to the app when it is run.

```xml
<PropertyGroup>
  <RunArguments>-mode dryrun</RunArguments>
</PropertyGroup>
```

> [!TIP]
> You can specify additional arguments to be passed to the app by using the [`--` option for `dotnet run`](../tools/dotnet-run.md#options).

### RunWorkingDirectory

The `RunWorkingDirectory` property defines the working directory for the application process to be started in. It can be an absolute path or a path that's relative to the project directory. If you don't specify a directory, `OutDir` is used as the working directory.

```xml
<PropertyGroup>
  <RunWorkingDirectory>c:\temp</RunWorkingDirectory>
</PropertyGroup>
```

## Hosting-related properties

The following MSBuild properties are documented in this section:

- [EnableComHosting](#enablecomhosting)
- [EnableDynamicLoading](#enabledynamicloading)

### EnableComHosting

The `EnableComHosting` property indicates that an assembly provides a COM server. Setting the `EnableComHosting` to `true` also implies that [EnableDynamicLoading](#enabledynamicloading) is `true`.

```xml
<PropertyGroup>
  <EnableComHosting>True</EnableComHosting>
</PropertyGroup>
```

For more information, see [Expose .NET components to COM](../native-interop/expose-components-to-com.md).

### EnableDynamicLoading

The `EnableDynamicLoading` property indicates that an assembly is a dynamically loaded component. The component could be a [COM library](/windows/win32/com/the-component-object-model) or a non-COM library that can be [used from a native host](../tutorials/netcore-hosting.md). Setting this property to `true` has the following effects:

- A *.runtimeconfig.json* file is generated.
- [RollForward](#rollforward) is set to `LatestMinor`.
- NuGet references are copied locally.

```xml
<PropertyGroup>
  <EnableDynamicLoading>true</EnableDynamicLoading>
</PropertyGroup>
```

## Items

[MSBuild items](/visualstudio/msbuild/msbuild-items) are inputs into the build system. Items are specified according to their type, which is the element name. For example, `Compile` and `Reference` are two [common item types](/visualstudio/msbuild/common-msbuild-project-items). The following additional item types are made available by the .NET SDK:

- [PackageReference](#packagereference)
- [TrimmerRootAssembly](#trimmerrootassembly)

You can use any of the standard [item attributes](/visualstudio/msbuild/item-element-msbuild#attributes-and-elements), for example, `Include` and `Update`, on these items. Use `Include` to add a new item, and use `Update` to modify an existing item. For example, `Update` is often used to modify an item that has implicitly been added by the .NET SDK.

### PackageReference

The `PackageReference` item defines a reference to a NuGet package.

The `Include` attribute specifies the package ID. The `Version` attribute specifies the version or version range. For information about how to specify a minimum version, maximum version, range, or exact match, see [Version ranges](/nuget/concepts/package-versioning#version-ranges).

The project file snippet in the following example references the [System.Runtime](https://www.nuget.org/packages/System.Runtime/) package.

```xml
<ItemGroup>
  <PackageReference Include="System.Runtime" Version="4.3.0" />
</ItemGroup>
```

You can also [control dependency assets](/nuget/consume-packages/package-references-in-project-files#controlling-dependency-assets) using metadata such as `PrivateAssets`.

```xml
<ItemGroup>
  <PackageReference Include="Contoso.Utility.UsefulStuff" Version="3.6.0">
    <PrivateAssets>all</PrivateAssets>
  </PackageReference>
</ItemGroup>
```

For more information, see [Package references in project files](/nuget/consume-packages/package-references-in-project-files).

### TrimmerRootAssembly

The `TrimmerRootAssembly` item lets you exclude an assembly from [*trimming*](../deploying/trim-self-contained.md). Trimming is the process of removing unused parts of the runtime from a packaged application. In some cases, trimming might incorrectly remove required references.

The following XML excludes the `System.Security` assembly from trimming.

```xml
<ItemGroup>
  <TrimmerRootAssembly Include="System.Security" />
</ItemGroup>
```

## Item metadata

In addition to the standard [MSBuild item attributes](/visualstudio/msbuild/item-element-msbuild#attributes-and-elements), the following item metadata tags are made available by the .NET SDK:

- [CopyToPublishDirectory](#copytopublishdirectory)
- [LinkBase](#linkbase)

### CopyToPublishDirectory

The `CopyToPublishDirectory` metadata on an MSBuild item controls when the item is copied to the publish directory. Allowable values are `PreserveNewest`, which only copies the item if it has changed, `Always`, which always copies the item, and `Never`, which never copies the item. From a performance standpoint, `PreserveNewest` is preferable because it enables an incremental build.

```xml
<ItemGroup>
  <None Update="appsettings.Development.json" CopyToOutputDirectory="PreserveNewest" CopyToPublishDirectory="PreserveNewest" />
</ItemGroup>
```

### LinkBase

For an item that's outside of the project directory and its subdirectories, the publish target uses the item's [Link metadata](/visualstudio/msbuild/common-msbuild-item-metadata) to determine where to copy the item to. `Link` also determines how items outside of the project tree are displayed in the Solution Explorer window of Visual Studio.

If `Link` is not specified for an item that's outside of the project cone, it defaults to `%(LinkBase)\%(RecursiveDir)%(Filename)%(Extension)`. `LinkBase` lets you specify a sensible base folder for items outside of the project cone. The folder hierarchy under the base folder is preserved via `RecursiveDir`. If `LinkBase` is not specified, it's omitted from the `Link` path.

```xml
<ItemGroup>
  <Content Include="..\Extras\**\*.cs" LinkBase="Shared"/>
</ItemGroup>
```

The following image shows how a file that's included via the previous item `Include` glob displays in Solution Explorer.

:::image type="content" source="media/solution-explorer-linkbase.png" alt-text="Solution Explorer showing item with LinkBase metadata.":::

## See also

- [MSBuild schema reference](/visualstudio/msbuild/msbuild-project-file-schema-reference)
- [Common MSBuild properties](/visualstudio/msbuild/common-msbuild-project-properties)
- [MSBuild properties for NuGet pack](/nuget/reference/msbuild-targets#pack-target)
- [MSBuild properties for NuGet restore](/nuget/reference/msbuild-targets#restore-properties)
- [Customize a build](/visualstudio/msbuild/customize-your-build)
