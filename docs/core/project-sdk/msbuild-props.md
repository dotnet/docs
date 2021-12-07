---
title: MSBuild properties for Microsoft.NET.Sdk
description: Reference for the MSBuild properties and items that are understood by the .NET SDK.
ms.date: 11/22/2021
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

## Assembly attribute properties

- [GenerateAssemblyInfo](#generateassemblyinfo)
- [GeneratedAssemblyInfoFile](#generatedassemblyinfofile)

### GenerateAssemblyInfo

The `GenerateAssemblyInfo` property controls `AssemblyInfo` attribute generation for the project. The default value is `true`. Use `false` to disable generation of the file:

```xml
<PropertyGroup>
  <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
</PropertyGroup>
```

The [GeneratedAssemblyInfoFile](#generatedassemblyinfofile) setting controls the name of the generated file.

When the `GenerateAssemblyInfo` value is `true`, [package-related project properties](#package-properties) are transformed into assembly attributes. The following table lists the project properties that generate the attributes. It also lists the properties that you can use to disable that generation on a per-attribute basis, for example:

```xml
<PropertyGroup>
  <GenerateNeutralResourcesLanguageAttribute>false</GenerateNeutralResourcesLanguageAttribute>
</PropertyGroup>
```

| MSBuild property       | Assembly attribute                                             | Property to disable attribute generation        |
| ---------------------- | -------------------------------------------------------------- | ----------------------------------------------- |
| `Company`              | <xref:System.Reflection.AssemblyCompanyAttribute>              | `GenerateAssemblyCompanyAttribute`              |
| `Configuration`        | <xref:System.Reflection.AssemblyConfigurationAttribute>        | `GenerateAssemblyConfigurationAttribute`        |
| `Copyright`            | <xref:System.Reflection.AssemblyCopyrightAttribute>            | `GenerateAssemblyCopyrightAttribute`            |
| `Description`          | <xref:System.Reflection.AssemblyDescriptionAttribute>          | `GenerateAssemblyDescriptionAttribute`          |
| `FileVersion`          | <xref:System.Reflection.AssemblyFileVersionAttribute>          | `GenerateAssemblyFileVersionAttribute`          |
| `InformationalVersion` | <xref:System.Reflection.AssemblyInformationalVersionAttribute> | `GenerateAssemblyInformationalVersionAttribute` |
| `Product`              | <xref:System.Reflection.AssemblyProductAttribute>              | `GenerateAssemblyProductAttribute`              |
| `AssemblyTitle`        | <xref:System.Reflection.AssemblyTitleAttribute>                | `GenerateAssemblyTitleAttribute`                |
| `AssemblyVersion`      | <xref:System.Reflection.AssemblyVersionAttribute>              | `GenerateAssemblyVersionAttribute`              |
| `NeutralLanguage`      | <xref:System.Resources.NeutralResourcesLanguageAttribute>      | `GenerateNeutralResourcesLanguageAttribute`     |

Notes about these settings:

- `AssemblyVersion` and `FileVersion` default to the value of `$(Version)` without the suffix. For example, if `$(Version)` is `1.2.3-beta.4`, then the value would be `1.2.3`.
- `InformationalVersion` defaults to the value of `$(Version)`.
- If the `$(SourceRevisionId)` property is present, it's appended to `InformationalVersion`. You can disable this behavior using `IncludeSourceRevisionInInformationalVersion`.
- `Copyright` and `Description` properties are also used for NuGet metadata.
- `Configuration`, which defaults to `Debug`, is shared with all MSBuild targets. You can set it via the `--configuration` option of `dotnet` commands, for example, [dotnet pack](../tools/dotnet-pack.md).
- Some of the properties are used when creating a NuGet package. For more information, see [Package properties](#package-properties).

#### Migrating from .NET Framework

.NET Framework project templates create a code file with these assembly info attributes set. The file is typically located at *.\Properties\AssemblyInfo.cs* or *.\Properties\AssemblyInfo.vb*. SDK-style projects generate this file for you based on the project settings. **You can't have both.** When porting your code to .NET 5 (or .NET Core 3.1) or later, do one of the following:

- Disable the generation of the temporary code file that contains the assembly info attributes by setting `GenerateAssemblyInfo` to `false` in your project file. This enables you to keep your *AssemblyInfo* file.
- Migrate the settings in the `AssemblyInfo` file to the project file, and then delete the `AssemblyInfo` file.

### GeneratedAssemblyInfoFile

The `GeneratedAssemblyInfoFile` property defines the relative or absolute path of the generated assembly info file. Defaults to a file named *[project-name].AssemblyInfo.[cs|vb]* in the `$(IntermediateOutputPath)` (usually the *obj*) directory.

```xml
<PropertyGroup>
  <GeneratedAssemblyInfoFile>assemblyinfo.cs</GeneratedAssemblyInfoFile>
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
- [EnablePackageValidation](#enablepackagevalidation)
- [ErrorOnDuplicatePublishOutputFiles](#erroronduplicatepublishoutputfiles)
- [GenerateRuntimeConfigurationFiles](#generateruntimeconfigurationfiles)
- [IsPublishable](#ispublishable)
- [PreserveCompilationContext](#preservecompilationcontext)
- [PreserveCompilationReferences](#preservecompilationreferences)
- [RollForward](#rollforward)
- [RuntimeFrameworkVersion](#runtimeframeworkversion)
- [RuntimeIdentifier](#runtimeidentifier)
- [RuntimeIdentifiers](#runtimeidentifiers)
- [SatelliteResourceLanguages](#satelliteresourcelanguages)
- [UseAppHost](#useapphost)

### AppendTargetFrameworkToOutputPath

The `AppendTargetFrameworkToOutputPath` property controls whether the [target framework moniker (TFM)](../../standard/frameworks.md) is appended to the output path (which is defined by [OutputPath](/visualstudio/msbuild/common-msbuild-project-properties#list-of-common-properties-and-parameters)). The .NET SDK automatically appends the target framework and, if present, the runtime identifier to the output path. Setting `AppendTargetFrameworkToOutputPath` to `false` prevents the TFM from being appended to the output path. However, without the TFM in the output path, multiple build artifacts may overwrite each other.

For example, for a .NET 5 app, the output path changes from `bin\Debug\net5.0` to `bin\Debug` with the following setting:

```xml
<PropertyGroup>
  <AppendTargetFrameworkToOutputPath>false</AppendTargetFrameworkToOutputPath>
</PropertyGroup>
```

### AppendRuntimeIdentifierToOutputPath

The `AppendRuntimeIdentifierToOutputPath` property controls whether the [runtime identifier (RID)](../rid-catalog.md) is appended to the output path. The .NET SDK automatically appends the target framework and, if present, the runtime identifier to the output path. Setting `AppendRuntimeIdentifierToOutputPath` to `false` prevents the RID from being appended to the output path.

For example, for a .NET 5 app and an RID of `win10-x64`, the output path changes from `bin\Debug\net5.0\win10-x64` to `bin\Debug\net5.0` with the following setting:

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

### ErrorOnDuplicatePublishOutputFiles

The `ErrorOnDuplicatePublishOutputFiles` property relates to whether the SDK generates error NETSDK1148 when MSBuild detects duplicate files in the publish output, but can't determine which files to remove. Set the `ErrorOnDuplicatePublishOutputFiles` property to `false` if you don't want the error to be generated.

```xml
<PropertyGroup>
  <ErrorOnDuplicatePublishOutputFiles>false</ErrorOnDuplicatePublishOutputFiles>
</PropertyGroup>
```

This property was introduced in .NET 6.

### EnablePackageValidation

The `EnablePackageValidation` property enables a series of validations on the package after the `pack` task. For more information, see [package validation](../../fundamentals/package-validation/overview.md).

```xml
<PropertyGroup>
  <EnablePackageValidation>true</EnablePackageValidation>
</PropertyGroup>
```

This property was introduced in .NET 6.

### GenerateRuntimeConfigurationFiles

The `GenerateRuntimeConfigurationFiles` property controls whether runtime configuration options are copied from the *runtimeconfig.template.json* file to the *[appname].runtimeconfig.json* file. For apps that require a *runtimeconfig.json* file, that is, those whose `OutputType` is `Exe`, this property defaults to `true`.

```xml
<PropertyGroup>
  <GenerateRuntimeConfigurationFiles>true</GenerateRuntimeConfigurationFiles>
</PropertyGroup>
```

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

### SatelliteResourceLanguages

The `SatelliteResourceLanguages` property lets you specify which languages you want to preserve satellite resource assemblies for during build and publish. Many NuGet packages include localized resource satellite assemblies in the main package. For projects that reference these NuGet packages that don't require localized resources, the localized assemblies can unnecessarily inflate the build and publish output size. By adding the `SatelliteResourceLanguages` property to your project file, only localized assemblies for the languages you specify will be included in the build and publish output. For example, in the following project file, only English (US) resource satellite assemblies will be retained.

```xml
<PropertyGroup>
  <SatelliteResourceLanguages>en-US</SatelliteResourceLanguages>
</PropertyGroup>
```

> [!NOTE]
> You must specify this property in the project that references the NuGet package with localized resource satellite assemblies.

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

- [DocumentationFile](#documentationfile)
- [EmbeddedResourceUseDependentUponConvention](#embeddedresourceusedependentuponconvention)
- [EnablePreviewFeatures](#enablepreviewfeatures)
- [GenerateDocumentationFile](#generatedocumentationfile)
- [GenerateRequiresPreviewFeaturesAttribute](#generaterequirespreviewfeaturesattribute)
- [OptimizeImplicitlyTriggeredBuild](#optimizeimplicitlytriggeredbuild)

C# compiler options, such as `LangVersion` and `Nullable`, can also be specified as MSBuild properties in your project file. For more information, see [C# compiler options](../../csharp/language-reference/compiler-options/index.md).

### EmbeddedResourceUseDependentUponConvention

The `EmbeddedResourceUseDependentUponConvention` property defines whether resource manifest file names are generated from type information in source files that are co-located with resource files. For example, if *Form1.resx* is in the same folder as *Form1.cs*, and `EmbeddedResourceUseDependentUponConvention` is set to `true`, the generated *.resources* file takes its name from the first type that's defined in *Form1.cs*. For example, if `MyNamespace.Form1` is the first type defined in *Form1.cs*, the generated file name is *MyNamespace.Form1.resources*.

> [!NOTE]
> If `LogicalName`, `ManifestResourceName`, or `DependentUpon` metadata is specified for an `EmbeddedResource` item, the generated manifest file name for that resource file is based on that metadata instead.

By default, in a new .NET project, this property is set to `true`. If set to `false`, and no `LogicalName`, `ManifestResourceName`, or `DependentUpon` metadata is specified for the `EmbeddedResource` item in the project file, the resource manifest file name is based off the root namespace for the project and the relative file path to the *.resx* file. For more information, see [How resource manifest files are named](../resources/manifest-file-names.md).

```xml
<PropertyGroup>
  <EmbeddedResourceUseDependentUponConvention>true</EmbeddedResourceUseDependentUponConvention>
</PropertyGroup>
```

### EnablePreviewFeatures

The `EnablePreviewFeatures` property defines whether your project depends on any APIs or assemblies that are decorated with the <xref:System.Runtime.Versioning.RequiresPreviewFeaturesAttribute> attribute. This attribute is used to signify that an API or assembly uses features that are considered to be in *preview* for the SDK version you're using. Preview features are not supported and may be removed in a future version. To enable the use of preview features, set the property to `True`.

```xml
<PropertyGroup>
  <EnablePreviewFeatures>True</EnablePreviewFeatures>
</PropertyGroup>
```

When a project contains this property set to `True`, the following assembly-level attribute is added to the *AssemblyInfo.cs* file:

```csharp
[assembly: RequiresPreviewFeatures]
```

An analyzer warns if this attribute is present on dependencies for projects where `EnablePreviewFeatures` is not set to `True`.

Library authors who intend to ship preview assemblies should set this property to `True`. If an assembly needs to ship with a mixture of preview and non-preview APIs, see the [GenerateRequiresPreviewFeaturesAttribute](#generaterequirespreviewfeaturesattribute) section below.

### DocumentationFile

The `DocumentationFile` property lets you specify a file name for the XML file that contains the documentation for your library. For IntelliSense to function correctly with your documentation, the file name must be the same as the assembly name and must be in the same directory as the assembly. If you don't specify this property but you do set [GenerateDocumentationFile](#generatedocumentationfile) to `true`, the name of the documentation file defaults to the name of your assembly but with an *.xml* file extension. For this reason, it's often easier to omit this property and use the [GenerateDocumentationFile property](#generatedocumentationfile) instead.

If you specify this property but you set [GenerateDocumentationFile](#generatedocumentationfile) to `false`, the compiler *does not* generate a documentation file. If you specify this property and omit the [GenerateDocumentationFile property](#generatedocumentationfile), the compiler *does* generate a documentation file.

```xml
<PropertyGroup>
  <DocumentationFile>path/to/file.xml</DocumentationFile>
</PropertyGroup>
```

### GenerateDocumentationFile

The `GenerateDocumentationFile` property controls whether the compiler generates an XML documentation file for your library. If you set this property to `true` and you don't specify a file name via the [DocumentationFile property](#documentationfile), the generated XML file is placed in the same output directory as your assembly and has the same file name (but with an *.xml* extension).

```xml
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
</PropertyGroup>
```

For more information about generating documentation from code comments, see [XML documentation comments (C#)](../../csharp/language-reference/xmldoc/index.md), [Document your code with XML (Visual Basic)](../../visual-basic/programming-guide/program-structure/documenting-your-code-with-xml.md), or [Document your code with XML (F#)](../../fsharp/language-reference/xml-documentation.md).

### GenerateRequiresPreviewFeaturesAttribute

The `GenerateRequiresPreviewFeaturesAttribute` property is closely related to the [EnablePreviewFeatures](#enablepreviewfeatures) property. If your library uses preview features but you don't want the entire assembly to be marked with the <xref:System.Runtime.Versioning.RequiresPreviewFeaturesAttribute> attribute, which would require any consumers to [enable preview features](#enablepreviewfeatures), set this property to `False`.

```xml
<PropertyGroup>
    <EnablePreviewFeatures>True</EnablePreviewFeatures>
    <GenerateRequiresPreviewFeaturesAttribute>False</GenerateRequiresPreviewFeaturesAttribute>
</PropertyGroup>
```

> [!IMPORTANT]
> If you set the `GenerateRequiresPreviewFeaturesAttribute` property to `False`, you must be certain to decorate all public APIs that rely on preview features with <xref:System.Runtime.Versioning.RequiresPreviewFeaturesAttribute>.

### OptimizeImplicitlyTriggeredBuild

To speed up the build time, builds that are implicitly triggered by Visual Studio skip code analysis, including nullable analysis. Visual Studio triggers an implicit build when you run tests, for example. However, implicit builds are optimized only when `TreatWarningsAsErrors` is not `true`. If you have `TreatWarningsAsErrors` set to `true` but you still want implicitly triggered builds to be optimized, you can set `OptimizeImplicitlyTriggeredBuild` to `True`. To turn off build optimization for implicitly triggered builds, set `OptimizeImplicitlyTriggeredBuild` to `False`.

```xml
<PropertyGroup>
    <OptimizeImplicitlyTriggeredBuild>True</OptimizeImplicitlyTriggeredBuild>
</PropertyGroup>
```

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
- [AnalysisLevel\<Category>](#analysislevelcategory)
- [AnalysisMode](#analysismode)
- [AnalysisMode\<Category>](#analysismodecategory)
- [CodeAnalysisTreatWarningsAsErrors](#codeanalysistreatwarningsaserrors)
- [EnableNETAnalyzers](#enablenetanalyzers)
- [EnforceCodeStyleInBuild](#enforcecodestyleinbuild)

### AnalysisLevel

The `AnalysisLevel` property lets you specify a set of code analyzers to run according to a .NET release. Each .NET release, starting in .NET 5, has a set of code analysis rules. Of that set, the rules that are enabled by default for that release will analyze your code.

For example, if you upgrade to .NET 6 but don't want the default set of code analysis rules to change, set `AnalysisLevel` to `5`.

```xml
<PropertyGroup>
  <AnalysisLevel>preview</AnalysisLevel>
</PropertyGroup>
```

Optionally, starting in .NET 6, you can specify a compound value for this property that also specifies how aggressively to enable rules. Compound values take the form `<version>-<mode>`, where the `<mode>` value is one of the [AnalysisMode](#analysismode) values. The following example uses the preview version of code analyzers, and enables the recommended set of rules.

```xml
<PropertyGroup>
  <AnalysisLevel>preview-recommended</AnalysisLevel>
</PropertyGroup>
```

> [!NOTE]
> If you set `AnalysisLevel` to `5-<mode>` or `5.0-<mode>` and then install the .NET 6 SDK and recompile your project, you may see unexpected new build warnings. For more information, see [dotnet/roslyn-analyzers#5679](https://github.com/dotnet/roslyn-analyzers/issues/5679).

Default value:

- If your project targets .NET 5 or later, or if you've added the [AnalysisMode](#analysismode) property, the default value is `latest`.
- Otherwise, this property is omitted unless you explicitly add it to the project file.

The following table shows the values you can specify.

| Value | Meaning |
|-|-|
| `latest` | The latest code analyzers that have been released are used. This is the default. |
| `latest-<mode>` | The latest code analyzers that have been released are used. The `<mode>` value determines which rules are enabled. |
| `preview` | The latest code analyzers are used, even if they are in preview. |
| `preview-<mode>` | The latest code analyzers are used, even if they are in preview. The `<mode>` value determines which rules are enabled. |
| `6.0` | The set of rules that was available for the .NET 6 release is used, even if newer rules are available. |
| `6.0-<mode>` | The set of rules that was available for the .NET 6 release is used, even if newer rules are available. The `<mode>` value determines which rules are enabled. |
| `6` | The set of rules that was available for the .NET 6 release is used, even if newer rules are available. |
| `6-<mode>` | The set of rules that was available for the .NET 6 release is used, even if newer rules are available. The `<mode>` value determines which rules are enabled. |
| `5.0` | The set of rules that was available for the .NET 5 release is used, even if newer rules are available. |
| `5.0-<mode>` | The set of rules that was available for the .NET 5 release is used, even if newer rules are available. The `<mode>` value determines which rules are enabled. |
| `5` | The set of rules that was available for the .NET 5 release is used, even if newer rules are available. |
| `5-<mode>` | The set of rules that was available for the .NET 5 release is used, even if newer rules are available. The `<mode>` value determines which rules are enabled. |

> [!NOTE]
>
> - In .NET 5 and earlier versions, this property only affects [code-quality (CAXXXX) rules](../../fundamentals/code-analysis/quality-rules/index.md). Starting in .NET 6, if you set [EnforceCodeStyleInBuild](#enforcecodestyleinbuild) to `true`, this property affects [code-style (IDEXXXX) rules](../../fundamentals/code-analysis/style-rules/index.md) too.
> - If you set a compound value for `AnalysisLevel`, you don't need to specify an [AnalysisMode](#analysismode). However, if you do, `AnalysisLevel` takes precedence over `AnalysisMode`.
> - This property has no effect on code analysis in projects that don't reference a [project SDK](overview.md), for example, legacy .NET Framework projects that reference the Microsoft.CodeAnalysis.NetAnalyzers NuGet package.

### AnalysisLevel\<Category>

Introduced in .NET 6, this property is the same as [AnalysisLevel](#analysislevel), except that it only applies to a specific [category of code-analysis rules](../../fundamentals/code-analysis/categories.md). This property allows you to use a different version of code analyzers for a specific category, or to enable or disable rules at a different level to the other rule categories. If you omit this property for a particular category of rules, it defaults to the [AnalysisLevel](#analysislevel) value. The available values are the same as those for [AnalysisLevel](#analysislevel).

```xml
<PropertyGroup>
  <AnalysisLevelSecurity>preview</AnalysisLevelSecurity>
</PropertyGroup>
```

```xml
<PropertyGroup>
  <AnalysisLevelSecurity>preview-recommended</AnalysisLevelSecurity>
</PropertyGroup>
```

The following table lists the property name for each rule category.

| Property name | Rule category |
| - |
| `<AnalysisLevelDesign>` | [Design rules](../../fundamentals/code-analysis/quality-rules/design-warnings.md) |
| `<AnalysisLevelDocumentation>` | [Documentation rules](../../fundamentals/code-analysis/quality-rules/documentation-warnings.md) |
| `<AnalysisLevelGlobalization>` | [Globalization rules](../../fundamentals/code-analysis/quality-rules/globalization-warnings.md) |
| `<AnalysisLevelInteroperability>` | [Portability and interoperability rules](../../fundamentals/code-analysis/quality-rules/interoperability-warnings.md) |
| `<AnalysisLevelMaintainability>` | [Maintainability rules](../../fundamentals/code-analysis/quality-rules/maintainability-warnings.md) |
| `<AnalysisLevelNaming>` | [Naming rules](../../fundamentals/code-analysis/quality-rules/naming-warnings.md) |
| `<AnalysisLevelPerformance>` | [Performance rules](../../fundamentals/code-analysis/quality-rules/performance-warnings.md) |
| `<AnalysisLevelSingleFile>` | [Single-file application rules](../../fundamentals/code-analysis/quality-rules/singlefile-warnings.md) |
| `<AnalysisLevelReliability>` | [Reliability rules](../../fundamentals/code-analysis/quality-rules/reliability-warnings.md) |
| `<AnalysisLevelSecurity>` | [Security rules](../../fundamentals/code-analysis/quality-rules/security-warnings.md) |
| `<AnalysisLevelStyle>` | [Code-style (IDEXXXX) rules](../../fundamentals/code-analysis/style-rules/index.md) |
| `<AnalysisLevelUsage>` | [Usage rules](../../fundamentals/code-analysis/quality-rules/usage-warnings.md) |

### AnalysisMode

Starting with .NET 5, the .NET SDK ships with all of the ["CA" code quality rules](../../fundamentals/code-analysis/quality-rules/index.md). By default, only [some rules are enabled](../../fundamentals/code-analysis/overview.md#enabled-rules) as build warnings in each .NET release. The `AnalysisMode` property lets you customize the set of rules that are enabled by default. You can either switch to a more aggressive analysis mode where you can opt out of rules individually, or a more conservative analysis mode where you can opt in to specific rules. For example, if you want to enable all rules as build warnings, set the value to `All`.

```xml
<PropertyGroup>
  <AnalysisMode>All</AnalysisMode>
</PropertyGroup>
```

The following table shows the available option values in .NET 5 and .NET 6. They're listed in increasing order of the number of rules they enable.

| .NET 6+ value | .NET 5 value | Meaning |
|-|-|-|
| `None` | `AllDisabledByDefault` | All rules are disabled. You can selectively [opt in to](../../fundamentals/code-analysis/configuration-options.md) individual rules to enable them. |
| `Default` | `Default` | Default mode, where certain rules are enabled as build warnings, certain rules are enabled as Visual Studio IDE suggestions, and the remainder are disabled. |
| `Minimum` | N/A | More aggressive mode than the `Default` mode. Certain suggestions that are highly recommended for build enforcement are enabled as build warnings. |
| `Recommended` | N/A | More aggressive mode than the `Minimum` mode, where more rules are enabled as build warnings. |
| `All` | `AllEnabledByDefault` | All rules are enabled as build warnings. You can selectively [opt out](../../fundamentals/code-analysis/configuration-options.md) of individual rules to disable them. |

> [!NOTE]
>
> - In .NET 5, this property only affects [code-quality (CAXXXX) rules](../../fundamentals/code-analysis/quality-rules/index.md). Starting in .NET 6, if you set [EnforceCodeStyleInBuild](#enforcecodestyleinbuild) to `true`, this property affects [code-style (IDEXXXX) rules](../../fundamentals/code-analysis/style-rules/index.md) too.
> - If you use a compound value for [AnalysisLevel](#analysislevel), for example, `<AnalysisLevel>5-recommended</AnalysisLevel>`, you can omit this property entirely. However, if you specify both properties, `AnalysisLevel` takes precedence over `AnalysisMode`.
> - If `AnalysisMode` is set to `AllEnabledByDefault` and `AnalysisLevel` is set to `5` or `5.0`, and then you install the .NET 6 SDK and recompile your project, you may see unexpected new build warnings. For more information, see [dotnet/roslyn-analyzers#5679](https://github.com/dotnet/roslyn-analyzers/issues/5679).
> - This property has no effect on code analysis in projects that don't reference a [project SDK](overview.md), for example, legacy .NET Framework projects that reference the Microsoft.CodeAnalysis.NetAnalyzers NuGet package.

### AnalysisMode\<Category>

Introduced in .NET 6, this property is the same as [AnalysisMode](#analysismode), except that it only applies to a specific [category of code-analysis rules](../../fundamentals/code-analysis/categories.md). This property allows you to enable or disable rules at a different level to the other rule categories. If you omit this property for a particular category of rules, it defaults to the [AnalysisMode](#analysismode) value. The available values are the same as those for [AnalysisMode](#analysismode).

```xml
<PropertyGroup>
  <AnalysisModeSecurity>All</AnalysisModeSecurity>
</PropertyGroup>
```

The following table lists the property name for each rule category.

| Property name | Rule category |
| - |
| `<AnalysisModeDesign>` | [Design rules](../../fundamentals/code-analysis/quality-rules/design-warnings.md) |
| `<AnalysisModeDocumentation>` | [Documentation rules](../../fundamentals/code-analysis/quality-rules/documentation-warnings.md) |
| `<AnalysisModeGlobalization>` | [Globalization rules](../../fundamentals/code-analysis/quality-rules/globalization-warnings.md) |
| `<AnalysisModeInteroperability>` | [Portability and interoperability rules](../../fundamentals/code-analysis/quality-rules/interoperability-warnings.md) |
| `<AnalysisModeMaintainability>` | [Maintainability rules](../../fundamentals/code-analysis/quality-rules/maintainability-warnings.md) |
| `<AnalysisModeNaming>` | [Naming rules](../../fundamentals/code-analysis/quality-rules/naming-warnings.md) |
| `<AnalysisModePerformance>` | [Performance rules](../../fundamentals/code-analysis/quality-rules/performance-warnings.md) |
| `<AnalysisModeSingleFile>` | [Single-file application rules](../../fundamentals/code-analysis/quality-rules/singlefile-warnings.md) |
| `<AnalysisModeReliability>` | [Reliability rules](../../fundamentals/code-analysis/quality-rules/reliability-warnings.md) |
| `<AnalysisModeSecurity>` | [Security rules](../../fundamentals/code-analysis/quality-rules/security-warnings.md) |
| `<AnalysisModeStyle>` | [Code-style (IDEXXXX) rules](../../fundamentals/code-analysis/style-rules/index.md) |
| `<AnalysisModeUsage>` | [Usage rules](../../fundamentals/code-analysis/quality-rules/usage-warnings.md) |

### CodeAnalysisTreatWarningsAsErrors

The `CodeAnalysisTreatWarningsAsErrors` property lets you configure whether code quality analysis warnings (CAxxxx) should be treated as warnings and break the build. If you use the `-warnaserror` flag when you build your projects, [.NET code quality analysis](../../fundamentals/code-analysis/overview.md#code-quality-analysis) warnings are also treated as errors. If you do not want code quality analysis warnings to be treated as errors, you can set the `CodeAnalysisTreatWarningsAsErrors` MSBuild property to `false` in your project file.

```xml
<PropertyGroup>
  <CodeAnalysisTreatWarningsAsErrors>false</CodeAnalysisTreatWarningsAsErrors>
</PropertyGroup>
```

### EnableNETAnalyzers

[.NET code quality analysis](../../fundamentals/code-analysis/overview.md#code-quality-analysis) is enabled, by default, for projects that target .NET 5 or a later version. If you're developing using the .NET 5+ SDK, you can enable .NET code analysis for SDK-style projects that target earlier versions of .NET by setting the `EnableNETAnalyzers` property to `true`. To disable code analysis in any project, set this property to `false`.

```xml
<PropertyGroup>
  <EnableNETAnalyzers>true</EnableNETAnalyzers>
</PropertyGroup>
```

> [!NOTE]
> This property applies specifically to the built-in analyzers in the .NET 5+ SDK. It should not be used when you install a NuGet code analysis package.

### EnforceCodeStyleInBuild

[.NET code style analysis](../../fundamentals/code-analysis/overview.md#code-style-analysis) is disabled, by default, on build for all .NET projects. You can enable code style analysis for .NET projects by setting the `EnforceCodeStyleInBuild` property to `true`.

```xml
<PropertyGroup>
  <EnforceCodeStyleInBuild>true</EnforceCodeStyleInBuild>
</PropertyGroup>
```

All code style rules that are [configured](../../fundamentals/code-analysis/overview.md#code-style-analysis) to be warnings or errors will execute on build and report violations.

## Runtime configuration properties

You can configure some run-time behaviors by specifying MSBuild properties in the project file of the app. For information about other ways of configuring run-time behavior, see [Runtime configuration settings](../run-time-config/index.md).

- [ConcurrentGarbageCollection](#concurrentgarbagecollection)
- [InvariantGlobalization](#invariantglobalization)
- [PredefinedCulturesOnly](#predefinedculturesonly)
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

### PredefinedCulturesOnly

In .NET 6 and later versions, the `PredefinedCulturesOnly` property configures whether apps can create cultures other than the invariant culture when [globalization-invariant mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md) is enabled. The default is `true`. Set the value to `false` to allow creation of any new culture in globalization-invariant mode.

```xml
<PropertyGroup>
  <PredefinedCulturesOnly>false</PredefinedCulturesOnly>
</PropertyGroup>
```

For more information, see [Culture creation and case mapping in globalization-invariant mode](../compatibility/globalization/6.0/culture-creation-invariant-mode.md).

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

The `DisableImplicitFrameworkReferences` property controls implicit `FrameworkReference` items when targeting .NET Core 3.0 and later versions. When targeting .NET Core 2.1 or .NET Standard 2.0 and earlier versions, it controls implicit [PackageReference](#packagereference) items to packages in a metapackage. (A metapackage is a framework-based package that consists only of dependencies on other packages.) This property also controls implicit references such as `System` and `System.Core` when targeting .NET Framework.

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

### WindowsSdkPackageVersion

The `WindowsSdkPackageVersion` property can be used to override the version of the [Windows SDK targeting package](https://www.nuget.org/packages/Microsoft.Windows.SDK.NET.Ref). This property was introduced in .NET 5, and replaces the use of the `FrameworkReference` item for this purpose.

```xml
<PropertyGroup>
  <WindowsSdkPackageVersion>10.0.19041.18</WindowsSdkPackageVersion>
</PropertyGroup>
```

> [!NOTE]
> We don't recommend overriding the Windows SDK version, because the Windows SDK targeting packages are included with the .NET 5+ SDK. Instead, to reference the latest Windows SDK package, update your version of the .NET SDK. This property should only be used in rare cases such as using preview packages or needing to override the version of C#/WinRT.

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

The `EnableDynamicLoading` property indicates that an assembly is a dynamically loaded component. The component could be a [COM library](/windows/win32/com/the-component-object-model) or a non-COM library that can be [used from a native host](../tutorials/netcore-hosting.md) or [used as a plugin](../tutorials/creating-app-with-plugin-support.md). Setting this property to `true` has the following effects:

- A *.runtimeconfig.json* file is generated.
- [RollForward](#rollforward) is set to `LatestMinor`.
- NuGet references are copied locally.

```xml
<PropertyGroup>
  <EnableDynamicLoading>true</EnableDynamicLoading>
</PropertyGroup>
```

## Generated file properties

The following properties concern code in generated files:

- [DisableImplicitNamespaceImports](#disableimplicitnamespaceimports)
- [ImplicitUsings](#implicitusings)

### DisableImplicitNamespaceImports

The `DisableImplicitNamespaceImports` property can be used to disable implicit namespace imports in Visual Basic projects that target .NET 6 or a later version. Implicit namespaces are the default namespaces that are imported globally in a Visual Basic project. Set this property to `true` to disable implicit namespace imports.

```xml
<PropertyGroup>
  <DisableImplicitNamespaceImports>true</DisableImplicitNamespaceImports>
</PropertyGroup>
```

### ImplicitUsings

The `ImplicitUsings` property can be used to enable and disable implicit `global using` directives in C# projects that target .NET 6 or a later version and C# 10 or a later version. When the feature is enabled, the .NET SDK adds `global using` directives for a set of default namespaces based on the type of project SDK. Set this property to `true` or `enable` to enable implicit `global using` directives. To disable implicit `global using` directives, remove the property or set it to `false` or `disable`.

```xml
<PropertyGroup>
  <ImplicitUsings>enable</ImplicitUsings>
</PropertyGroup>
```

> [!NOTE]
> The templates for new C# projects that target .NET 6 or later have `ImplicitUsings` set to `enable` by default.

To define an explicit `global using` directive, add a [Using](#using) item.

## Items

[MSBuild items](/visualstudio/msbuild/msbuild-items) are inputs into the build system. Items are specified according to their type, which is the element name. For example, `Compile` and `Reference` are two [common item types](/visualstudio/msbuild/common-msbuild-project-items). The following additional item types are made available by the .NET SDK:

- [AssemblyMetadata](#assemblymetadata)
- [InternalsVisibleTo](#internalsvisibleto)
- [PackageReference](#packagereference)
- [TrimmerRootAssembly](#trimmerrootassembly)
- [Using](#using)

You can use any of the standard [item attributes](/visualstudio/msbuild/item-element-msbuild#attributes-and-elements), for example, `Include` and `Update`, on these items. Use `Include` to add a new item, and use `Update` to modify an existing item. For example, `Update` is often used to modify an item that has implicitly been added by the .NET SDK.

### AssemblyMetadata

The `AssemblyMetadata` item specifies a key-value pair <xref:System.Reflection.AssemblyMetadataAttribute> assembly attribute. The `Include` metadata becomes the key, and the `Value` metadata becomes the value.

```xml
<ItemGroup>
  <AssemblyMetadata Include="Serviceable" Value="True" />
</ItemGroup>
```

### InternalsVisibleTo

The `InternalsVisibleTo` item generates an <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> assembly attribute for the specified friend assembly.

```xml
<ItemGroup>
  <InternalsVisibleTo Include="MyProject.Tests" />
</ItemGroup>
```

If the friend assembly is signed, you can specify an optional `Key` metadata to specify its full public key. If you don't specify `Key` metadata and a `$(PublicKey)` is available, that key is used. Otherwise, no public key is added to the attribute.

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

The `TrimmerRootAssembly` item lets you exclude an assembly from [*trimming*](../deploying/trimming/trim-self-contained.md). Trimming is the process of removing unused parts of the runtime from a packaged application. In some cases, trimming might incorrectly remove required references.

The following XML excludes the `System.Security` assembly from trimming.

```xml
<ItemGroup>
  <TrimmerRootAssembly Include="System.Security" />
</ItemGroup>
```

### Using

The `Using` item lets you [globally include a namespace](../../csharp/language-reference/keywords/using-directive.md#global-modifier) across your C# project, such that you don't have to add a `using` directive for the namespace at the top of your source files. This item is similar to the `Import` item that can be used for the same purpose in Visual Basic projects. This property is available starting in .NET 6.

```xml
<ItemGroup>
  <Using Include="My.Awesome.Namespace" />
</ItemGroup>
```

You can also use the `Using` item to define global `using <alias>` and `using static <type>` directives.

```xml
<ItemGroup>
  <Using Include="My.Awesome.Namespace" Alias="Awesome" />
</ItemGroup>
```

For example:

- `<Using Include="Microsoft.AspNetCore.Http.Results" Alias="Results" />` emits `global using Results = global::Microsoft.AspNetCore.Http.Results;`
- `<Using Include="Microsoft.AspNetCore.Http.Results" Static="True" />` emits `global using static global::Microsoft.AspNetCore.Http.Results;`

For more information about aliased `using` directives and `using static <type>` directives, see [using directive](../../csharp/language-reference/keywords/using-directive.md#static-modifier).

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
