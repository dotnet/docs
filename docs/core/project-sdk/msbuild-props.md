---
title: MSBuild properties for Microsoft.NET.Sdk
description: Reference for the MSBuild properties and items that are understood by the .NET SDK.
ms.date: 11/07/2024
ms.topic: reference
ms.custom: updateeachrelease
---
# MSBuild reference for .NET SDK projects

This page is a reference for the MSBuild properties and items that you can use to configure .NET projects.

> [!NOTE]
> This page is a work in progress and does not list all of the useful MSBuild properties for the .NET SDK. For a list of common MSBuild properties, see [Common MSBuild properties](/visualstudio/msbuild/common-msbuild-project-properties).

## Assembly validation properties

These properties and items are passed to the `ValidateAssemblies` task. For more information about assembly validation, see [Assembly validation](../../fundamentals/apicompat/assembly-validation.md).

The following MSBuild properties are documented in this section:

- [ApiCompatStrictMode](#apicompatstrictmode)
- [ApiCompatValidateAssemblies](#apicompatvalidateassemblies)

> [!NOTE]
> These properties aren't part of the .NET SDK (yet). To use them, you must also add a `PackageReference` to [Microsoft.DotNet.ApiCompat.Task](https://www.nuget.org/packages/Microsoft.DotNet.ApiCompat.Task).

In addition, the following properties that are documented in the [Package validation properties](#package-validation-properties) also apply to assembly validation:

- [ApiCompatEnableRuleAttributesMustMatch](#apicompatenableruleattributesmustmatch)
- [ApiCompatEnableRuleCannotChangeParameterName](#apicompatenablerulecannotchangeparametername)
- [ApiCompatExcludeAttributesFile](#apicompatexcludeattributesfile)
- [ApiCompatGenerateSuppressionFile](#apicompatgeneratesuppressionfile)
- [ApiCompatPermitUnnecessarySuppressions](#apicompatpermitunnecessarysuppressions)
- [ApiCompatPreserveUnnecessarySuppressions](#apicompatpreserveunnecessarysuppressions)
- [ApiCompatRespectInternals](#apicompatrespectinternals)
- [ApiCompatSuppressionFile](#apicompatsuppressionfile)
- [ApiCompatSuppressionOutputFile](#apicompatsuppressionoutputfile)
- [NoWarn](#nowarn)
- [RoslynAssembliesPath](#roslynassembliespath)

### ApiCompatStrictMode

When set to `true`, the `ApiCompatStrictMode` property specifies that API compatibility checks should be performed in [strict mode](../../fundamentals/apicompat/overview.md#strict-mode).

```xml
<PropertyGroup>
  <ApiCompatStrictMode>true</ApiCompatStrictMode>
</PropertyGroup>
```

### ApiCompatValidateAssemblies

The `ApiCompatValidateAssemblies` property enables a series of validations on the specified assemblies. For more information, see [Assembly validation](../../fundamentals/apicompat/assembly-validation.md).

```xml
<PropertyGroup>
  <ApiCompatValidateAssemblies>true</ApiCompatValidateAssemblies>
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

When the `GenerateAssemblyInfo` value is `true`, [package-related project properties](#package-properties) are transformed into assembly attributes.

For more information about generating assembly attributes using a project file, see [Set assembly attributes in a project file](../../standard/assembly/set-attributes-project-file.md).

### GeneratedAssemblyInfoFile

The `GeneratedAssemblyInfoFile` property defines the relative or absolute path of the generated assembly info file. Defaults to a file named *[project-name].AssemblyInfo.[cs|vb]* in the `$(IntermediateOutputPath)` (usually the *obj*) directory.

```xml
<PropertyGroup>
  <GeneratedAssemblyInfoFile>assemblyinfo.cs</GeneratedAssemblyInfoFile>
</PropertyGroup>
```

## Framework properties

The following MSBuild properties are documented in this section:

- [TargetFramework](#targetframework)
- [TargetFrameworks](#targetframeworks)
- [NetStandardImplicitPackageVersion](#netstandardimplicitpackageversion)

### TargetFramework

The `TargetFramework` property specifies the target framework version for the app. For a list of valid target framework monikers, see [Target frameworks in SDK-style projects](../../standard/frameworks.md#supported-target-frameworks).

```xml
<PropertyGroup>
  <TargetFramework>net8.0</TargetFramework>
</PropertyGroup>
```

For more information, see [Target frameworks in SDK-style projects](../../standard/frameworks.md).

### TargetFrameworks

Use the `TargetFrameworks` property when you want your app to target multiple platforms. For a list of valid target framework monikers, see [Target frameworks in SDK-style projects](../../standard/frameworks.md#supported-target-frameworks).

> [!NOTE]
> This property is ignored if `TargetFramework` (singular) is specified.

```xml
<PropertyGroup>
  <TargetFrameworks>net8.0;net462</TargetFrameworks>
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

## Package properties

- [Descriptive properties](#descriptive-properties)
- [PackRelease](#packrelease)

### Descriptive properties

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

### PackRelease

The `PackRelease` property is similar to the [PublishRelease](#publishrelease) property, except that it changes the default behavior of `dotnet pack`. This property was introduced in .NET 7.

```xml
<PropertyGroup>
  <PackRelease>true</PackRelease>
</PropertyGroup>
```

> [!NOTE]
>
> - Starting in the .NET 8 SDK, `PackRelease` defaults to `true`. For more information, see ['dotnet pack' uses Release configuration](../compatibility/sdk/8.0/dotnet-pack-config.md).
> - .NET 7 SDK only: To use `PackRelease` in a project that's part of a Visual Studio solution, you must set the environment variable `DOTNET_CLI_ENABLE_PACK_RELEASE_FOR_SOLUTIONS` to `true` (or any other value). For solutions that have many projects, setting this variable increases the time required to pack.

## Package validation properties

These properties and items are passed to the `ValidatePackage` task. For more information about package validation, see [Package validation overview](../../fundamentals/apicompat/package-validation/overview.md).

For properties for the `ValidateAssemblies` task, see [Assembly validation properties](#assembly-validation-properties).

The following MSBuild properties and items are documented in this section:

- [ApiCompatEnableRuleAttributesMustMatch](#apicompatenableruleattributesmustmatch)
- [ApiCompatEnableRuleCannotChangeParameterName](#apicompatenablerulecannotchangeparametername)
- [ApiCompatExcludeAttributesFile](#apicompatexcludeattributesfile)
- [ApiCompatGenerateSuppressionFile](#apicompatgeneratesuppressionfile)
- [ApiCompatPermitUnnecessarySuppressions](#apicompatpermitunnecessarysuppressions)
- [ApiCompatPreserveUnnecessarySuppressions](#apicompatpreserveunnecessarysuppressions)
- [ApiCompatRespectInternals](#apicompatrespectinternals)
- [ApiCompatSuppressionFile](#apicompatsuppressionfile)
- [ApiCompatSuppressionOutputFile](#apicompatsuppressionoutputfile)
- [EnablePackageValidation](#enablepackagevalidation)
- [EnableStrictModeForBaselineValidation](#enablestrictmodeforbaselinevalidation)
- [EnableStrictModeForCompatibleFrameworksInPackage](#enablestrictmodeforcompatibleframeworksinpackage)
- [EnableStrictModeForCompatibleTfms](#enablestrictmodeforcompatibletfms)
- [NoWarn](#nowarn)
- [PackageValidationBaselineFrameworkToIgnore](#packagevalidationbaselineframeworktoignore)
- [PackageValidationBaselineName](#packagevalidationbaselinename)
- [PackageValidationBaselineVersion](#packagevalidationbaselineversion)
- [PackageValidationReferencePath](#packagevalidationreferencepath)
- [RoslynAssembliesPath](#roslynassembliespath)

### ApiCompatEnableRuleAttributesMustMatch

When set to `true`, the `ApiCompatEnableRuleAttributesMustMatch` property enables the validation rule that checks if attributes match. The default is `false`.

```xml
<PropertyGroup>
  <ApiCompatEnableRuleAttributesMustMatch>true</ApiCompatEnableRuleAttributesMustMatch>
</PropertyGroup>
```

### ApiCompatEnableRuleCannotChangeParameterName

When set to `true`, the `ApiCompatEnableRuleCannotChangeParameterName` property enables the validation rule that checks whether parameter names have changed in public methods. The default is `false`.

```xml
<PropertyGroup>
  <ApiCompatEnableRuleCannotChangeParameterName>true</ApiCompatEnableRuleCannotChangeParameterName>
</PropertyGroup>
```

### ApiCompatExcludeAttributesFile

The `ApiCompatExcludeAttributesFile` item specifies the path to a file that contains attributes to exclude in [DocId](../../csharp/language-reference/xmldoc/index.md#id-strings) format.

```xml
<ItemGroup>
  <ApiCompatExcludeAttributesFile Include="ApiCompatExcludedAttributes.txt" />
  <ApiCompatExcludeAttributesFile Include="ApiCompatBaselineExcludedAttributes.txt" />
</ItemGroup>
```

### ApiCompatGenerateSuppressionFile

The `ApiCompatGenerateSuppressionFile` property specifies whether to generate a compatibility suppression file.

```xml
<PropertyGroup>
  <ApiCompatGenerateSuppressionFile>true</ApiCompatGenerateSuppressionFile>
</PropertyGroup>
```

### ApiCompatPermitUnnecessarySuppressions

The `ApiCompatPermitUnnecessarySuppressions` property specifies whether to permit unnecessary suppressions in the suppression file.

The default is `false`.

```xml
<PropertyGroup>
  <ApiCompatPermitUnnecessarySuppressions>true</ApiCompatPermitUnnecessarySuppressions>
</PropertyGroup>
```

### ApiCompatPreserveUnnecessarySuppressions

The `ApiCompatPreserveUnnecessarySuppressions` property specifies whether to preserve unnecessary suppressions when regenerating the suppression file. When an existing suppression file is regenerated, its content is read, deserialized into a set of suppressions, and then stored in a list. Some of the suppressions might no longer be necessary if the incompatibility has been fixed. When the suppressions are serialized back to disk, you can choose to keep *all* the existing (deserialized) expressions by setting this property to `true`.

The default is `false`.

```xml
<PropertyGroup>
  <ApiCompatPreserveUnnecessarySuppressions>true</ApiCompatPreserveUnnecessarySuppressions>
</PropertyGroup>
```

### ApiCompatRespectInternals

The `ApiCompatRespectInternals` property specifies whether `internal` APIs should be checked for compatibility in addition to `public` APIs.

```xml
<PropertyGroup>
  <ApiCompatRespectInternals>true</ApiCompatRespectInternals>
</PropertyGroup>
```

### ApiCompatSuppressionFile

The `ApiCompatSuppressionFile` item specifies the path to one or more suppression files to read from. If unspecified, the suppression file *\<project-directory>/CompatibilitySuppressions.xml* is read (if it exists).

```xml
<ItemGroup>
  <ApiCompatSuppressionFile Include="CompatibilitySuppressions.xml;CompatibilitySuppressions.WasmThreads.xml" />
</ItemGroup>
```

### ApiCompatSuppressionOutputFile

The `ApiCompatSuppressionOutputFile` property specifies the path to a suppression file to write to when `<ApiCompatGenerateSuppressionFile>` is `true`. If unspecified, the first `ApiCompatSuppressionFile` item is used.

### EnablePackageValidation

The `EnablePackageValidation` property enables a series of validations on the package after the `Pack` task. For more information, see [package validation](../../fundamentals/apicompat/package-validation/overview.md).

```xml
<PropertyGroup>
  <EnablePackageValidation>true</EnablePackageValidation>
</PropertyGroup>
```

### EnableStrictModeForBaselineValidation

When set to `true`, the `EnableStrictModeForBaselineValidation` property enables [strict mode](../../fundamentals/apicompat/overview.md#strict-mode) for package baseline checks. The default is `false`.

### EnableStrictModeForCompatibleFrameworksInPackage

When set to `true`, the `EnableStrictModeForCompatibleFrameworksInPackage` property enables [strict mode](../../fundamentals/apicompat/overview.md#strict-mode) for assemblies that are compatible based on their target framework. The default is `false`.

### EnableStrictModeForCompatibleTfms

When set to `true`, the `EnableStrictModeForCompatibleTfms` property enables [strict mode](../../fundamentals/apicompat/overview.md#strict-mode) for contract and implementation assemblies for all compatible target frameworks. The default is `true`.

### NoWarn

The `NoWarn` property specifies the diagnostic IDs to suppress.

```xml
<PropertyGroup>
  <NoWarn>$(NoWarn);PKV0001</NoWarn>
</PropertyGroup>
```

### PackageValidationBaselineFrameworkToIgnore

The `PackageValidationBaselineFrameworkToIgnore` item specifies a target framework to ignore from the baseline package. The framework string must exactly match the folder name in the baseline package.

```xml
<ItemGroup>
  <PackageValidationBaselineFrameworkToIgnore Include="netcoreapp2.1" />
</ItemGroup>
```

### PackageValidationBaselineName

The `PackageValidationBaselineName` property specifies the name of the baseline package to validate the current package against. If unspecified, the `PackageId` value is used.

### PackageValidationBaselineVersion

The `PackageValidationBaselineVersion` property specifies the version of the baseline package to validate the current package against.

### PackageValidationReferencePath

The `PackageValidationReferencePath` item specifies the directory path where the reference assembly can be found per TFM.

```xml
<ItemGroup>
  <PackageValidationReferencePath Include="path/to/reference-assembly" TargetFramework="net7.0" />
</ItemGroup>
```

### RoslynAssembliesPath

The `RoslynAssembliesPath` property specifies the path to the directory that contains the Microsoft.CodeAnalysis assemblies you want to use. You only need to set this property if you want to test with a newer compiler than what's in the SDK.

## Publish-related properties

The following MSBuild properties are documented in this section:

- [AppendRuntimeIdentifierToOutputPath](#appendruntimeidentifiertooutputpath)
- [AppendTargetFrameworkToOutputPath](#appendtargetframeworktooutputpath)
- [CopyLocalLockFileAssemblies](#copylocallockfileassemblies)
- [ErrorOnDuplicatePublishOutputFiles](#erroronduplicatepublishoutputfiles)
- [GenerateRuntimeConfigDevFile](#generateruntimeconfigdevfile)
- [GenerateRuntimeConfigurationFiles](#generateruntimeconfigurationfiles)
- [GenerateSatelliteAssembliesForCore](#generatesatelliteassembliesforcore)
- [IsPublishable](#ispublishable)
- [PreserveCompilationContext](#preservecompilationcontext)
- [PreserveCompilationReferences](#preservecompilationreferences)
- [ProduceReferenceAssemblyInOutDir](#producereferenceassemblyinoutdir)
- [PublishDocumentationFile](#publishdocumentationfile)
- [PublishDocumentationFiles](#publishdocumentationfiles)
- [PublishReferencesDocumentationFiles](#publishreferencesdocumentationfiles)
- [PublishRelease](#publishrelease)
- [PublishSelfContained](#publishselfcontained)
- [RollForward](#rollforward)
- [RuntimeFrameworkVersion](#runtimeframeworkversion)
- [RuntimeIdentifier](#runtimeidentifier)
- [RuntimeIdentifiers](#runtimeidentifiers)
- [SatelliteResourceLanguages](#satelliteresourcelanguages)
- [SelfContained](#selfcontained)
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

For example, for a .NET 5 app and an RID of `win-x64`, the following setting changes the output path from `bin\Debug\net5.0\win-x64` to `bin\Debug\net5.0`:

```xml
<PropertyGroup>
  <AppendRuntimeIdentifierToOutputPath>false</AppendRuntimeIdentifierToOutputPath>
</PropertyGroup>
```

### CopyLocalLockFileAssemblies

The `CopyLocalLockFileAssemblies` property is useful for plugin projects that have dependencies on other libraries. If you set this property to `true`, any transitive NuGet package dependencies are copied to the output directory. That means you can use the output of `dotnet build` to run your plugin on any machine.

```xml
<PropertyGroup>
  <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
</PropertyGroup>
```

The default value of `CopyLocalLockFileAssemblies` can vary based on the output type. For example, for class libraries the default value is `false`, while for console applications the default is `true`. You can specify this property explicitly to override the default if needed.

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

### GenerateRuntimeConfigDevFile

Starting with the .NET 6 SDK, the *\[Appname].runtimesettings.dev.json* file is [no longer generated by default](../compatibility/sdk/6.0/runtimeconfigdev-file.md) at compile time. If you still want this file to be generated, set the `GenerateRuntimeConfigDevFile` property to `true`.

```xml
<PropertyGroup>
  <GenerateRuntimeConfigDevFile>true</GenerateRuntimeConfigDevFile>
</PropertyGroup>
```

### GenerateRuntimeConfigurationFiles

The `GenerateRuntimeConfigurationFiles` property controls whether runtime configuration options are copied from the *runtimeconfig.template.json* file to the *[appname].runtimeconfig.json* file. For apps that require a *runtimeconfig.json* file, that is, those whose `OutputType` is `Exe`, this property defaults to `true`.

```xml
<PropertyGroup>
  <GenerateRuntimeConfigurationFiles>true</GenerateRuntimeConfigurationFiles>
</PropertyGroup>
```

### GenerateSatelliteAssembliesForCore

The `GenerateSatelliteAssembliesForCore` property controls whether satellite assemblies are generated using *csc.exe* or [Al.exe (Assembly Linker)](../../framework/tools/al-exe-assembly-linker.md) in .NET Framework projects. (.NET Core and .NET 5+ projects always use *csc.exe* to generate satellite assemblies.) For .NET Framework projects, satellite assemblies are created by *al.exe*, by default. By setting the `GenerateSatelliteAssembliesForCore` property to `true`, satellite assemblies are created by *csc.exe* instead. Using *csc.exe* can be advantageous in the following situations:

- You want to use the C# compiler [`deterministic` option](../../csharp/language-reference/compiler-options/code-generation.md#deterministic).
- You're limited by the fact that *al.exe* has no support for public signing and handles <xref:System.Reflection.AssemblyInformationalVersionAttribute> poorly.

```xml
<PropertyGroup>
  <GenerateSatelliteAssembliesForCore>true</GenerateSatelliteAssembliesForCore>
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

### ProduceReferenceAssemblyInOutDir

In .NET 5 and earlier versions, reference assemblies are always written to the `OutDir` directory. In .NET 6 and later versions, you can use the `ProduceReferenceAssemblyInOutDir` property to control whether reference assemblies are written to the `OutDir` directory. The default value is `false`, and reference assemblies are only written to the `IntermediateOutputPath` directory. Set the value to `true` to write reference assemblies to the `OutDir` directory.

```xml
<PropertyGroup>
  <ProduceReferenceAssemblyInOutDir>true</ProduceReferenceAssemblyInOutDir>
</PropertyGroup>
```

For more information, see [Write reference assemblies to intermediate output](../compatibility/sdk/6.0/write-reference-assemblies-to-obj.md).

### PublishDocumentationFile

When this property is `true`, the XML documentation file for the project, if one is generated, is included in the publish output for the project. This property defaults to `true`.

> [!TIP]
> Set [GenerateDocumentationFile](#generatedocumentationfile) to `true` to generate an XML documentation file at compile time.

### PublishDocumentationFiles

This property is an enablement flag for several other properties that control whether various kinds of XML documentation files are copied to the publish directory by default, namely [PublishDocumentationFile](#publishdocumentationfile) and [PublishReferencesDocumentationFiles](#publishreferencesdocumentationfiles). If those properties are unset, and this property is set, then those properties will default to `true`. This property defaults to `true`.

### PublishReferencesDocumentationFiles

When this property is `true`, XML documentation files for the project's references are copied to the publish directory, instead of just run-time assets like DLL files. This property defaults to `true`.

### PublishRelease

The `PublishRelease` property informs `dotnet publish` to use the `Release` configuration by default instead of the `Debug` configuration. This property was introduced in .NET 7.

```xml
<PropertyGroup>
  <PublishRelease>true</PublishRelease>
</PropertyGroup>
```

> [!NOTE]
>
> - Starting in the .NET 8 SDK, `PublishRelease` defaults to `true` for projects that target .NET 8 or later. For more information, see ['dotnet publish' uses Release configuration](../compatibility/sdk/8.0/dotnet-publish-config.md).
> - This property does not affect the behavior of `dotnet build /t:Publish`, and it only changes the configuration only when publishing via the .NET CLI.
> - .NET 7 SDK only: To use `PublishRelease` in a project that's part of a Visual Studio solution, you must set the environment variable `DOTNET_CLI_ENABLE_PUBLISH_RELEASE_FOR_SOLUTIONS` to `true` (or any other value). When publishing a solution with this variable enabled, the executable project's `PublishRelease` value takes precedence and flows the new default configuration to any other projects in the solution. If a solution contains multiple executable or top-level projects with differing values of `PublishRelease`, the solution won't successfully publish. For solutions that have many projects, use of this setting increases the time required to publish.

### PublishSelfContained

The `PublishSelfContained` property informs `dotnet publish` to publish an app as a [self-contained app](../deploying/index.md#publish-self-contained). This property is useful when you can't use the `--self-contained` argument for the [dotnet publish](../tools/dotnet-publish.md) command&mdash;for example, when you're publishing at the solution level. In that case, you can add the `PublishSelfContained` MSBuild property to a project or *Directory.Build.Props* file.

This property was introduced in .NET 7. It's similar to the [SelfContained](#selfcontained) property, except that it's specific to the `publish` verb. It's recommended to use `PublishSelfContained` instead of `SelfContained`.

```xml
<PropertyGroup>
  <PublishSelfContained>true</PublishSelfContained>
</PropertyGroup>
```

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
  <RuntimeIdentifier>linux-x64</RuntimeIdentifier>
</PropertyGroup>
```

### RuntimeIdentifiers

The `RuntimeIdentifiers` property lets you specify a semicolon-delimited list of [runtime identifiers (RIDs)](../rid-catalog.md) for the project. Use this property if you need to publish for multiple runtimes. `RuntimeIdentifiers` is used at restore time to ensure the right assets are in the graph.

> [!TIP]
> `RuntimeIdentifier` (singular) can provide faster builds when only a single runtime is required.

```xml
<PropertyGroup>
  <RuntimeIdentifiers>win-x64;osx-x64;linux-x64</RuntimeIdentifiers>
</PropertyGroup>
```

### SatelliteResourceLanguages

The `SatelliteResourceLanguages` property lets you specify which languages you want to preserve satellite resource assemblies for during build and publish. Many NuGet packages include localized resource satellite assemblies in the main package. For projects that reference these NuGet packages that don't require localized resources, the localized assemblies can unnecessarily inflate the build and publish output size. By adding the `SatelliteResourceLanguages` property to your project file, only localized assemblies for the languages you specify will be included in the build and publish output. For example, in the following project file, only English (US) and German (Germany) resource satellite assemblies will be retained.

```xml
<PropertyGroup>
  <SatelliteResourceLanguages>en-US;de-DE</SatelliteResourceLanguages>
</PropertyGroup>
```

> [!NOTE]
>
> - You must specify this property in the project that references the NuGet package with localized resource satellite assemblies.
> - To specify multiple languages as an argument to `dotnet publish`, you must add *three pairs* of quotation marks around the language identifiers. For example:
>
>   `dotnet msbuild multi.msbuildproj -p:SatelliteResourceLanguages="""de;en"""`

### SelfContained

The `SelfContained` property informs `dotnet build` and `dotnet publish` to build or publish an app as a [self-contained app](../deploying/index.md#publish-self-contained). This property is useful when you can't use the `--self-contained` argument with the [dotnet](../tools/dotnet.md) command&mdash;for example, when you're publishing at the solution level. In that case, you can add the `SelfContained` MSBuild property to a project or *Directory.Build.Props* file.

This property is similar to the [PublishSelfContained](#publishselfcontained) property. It's recommended to use `PublishSelfContained` instead of `SelfContained` when possible.

```xml
<PropertyGroup>
  <SelfContained>true</SelfContained>
</PropertyGroup>
```

### UseAppHost

The `UseAppHost` property controls whether or not a native executable is created for a deployment. A native executable is required for self-contained deployments. A framework-dependent executable is created by default. Set the `UseAppHost` property to `false` to disable generation of the executable.

```xml
<PropertyGroup>
  <UseAppHost>false</UseAppHost>
</PropertyGroup>
```

For more information about deployment, see [.NET application deployment](../deploying/index.md).

## Trim-related properties

Numerous MSBuild properties are available to fine tune trimming, which is a feature that trims unused code from self-contained deployments. These options are discussed in detail at [Trimming options](../deploying/trimming/trimming-options.md). The following table provides a quick reference.

| Property | Values | Description |
| - | - | - |
| `PublishTrimmed` | `true` or `false` | Controls whether trimming is enabled during publish. |
| `TrimMode` | `full` or `partial` | Default is `full`. Controls the trimming granularity. |
| `SuppressTrimAnalysisWarnings` | `true` or `false` | Controls whether trim analysis warnings are produced. |
| `EnableTrimAnalyzer` | `true` or `false` | Controls whether a subset of trim analysis warnings are produced. You can enable analysis even if `PublishTrimmed` is set to `false`. |
| `ILLinkTreatWarningsAsErrors` | `true` or `false` | Controls whether trim warnings are treated as errors. For example, you may want to set this property to `false` when `TreatWarningsAsErrors` is set to `true`.  |
| `TrimmerSingleWarn` | `true` or `false` | Controls whether a single warning per assembly is shown or all warnings. |
| `TrimmerRemoveSymbols` | `true` or `false` | Controls whether all symbols are removed from a trimmed application. |

## Build-related properties

The following MSBuild properties are documented in this section:

- [ContinuousIntegrationBuild](#continuousintegrationbuild)
- [CopyDebugSymbolFilesFromPackages](#copydebugsymbolfilesfrompackages)
- [CopyDocumentationFilesFromPackages](#copydocumentationfilesfrompackages)
- [DisableImplicitFrameworkDefines](#disableimplicitframeworkdefines)
- [DocumentationFile](#documentationfile)
- [EmbeddedResourceUseDependentUponConvention](#embeddedresourceusedependentuponconvention)
- [EnablePreviewFeatures](#enablepreviewfeatures)
- [EnableWindowsTargeting](#enablewindowstargeting)
- [GenerateDocumentationFile](#generatedocumentationfile)
- [GenerateRequiresPreviewFeaturesAttribute](#generaterequirespreviewfeaturesattribute)
- [OptimizeImplicitlyTriggeredBuild](#optimizeimplicitlytriggeredbuild)
- [DisableRuntimeMarshalling](#disableruntimemarshalling)

C# compiler options, such as `LangVersion` and `Nullable`, can also be specified as MSBuild properties in your project file. For more information, see [C# compiler options](../../csharp/language-reference/compiler-options/index.md).

### ContinuousIntegrationBuild

The `ContinuousIntegrationBuild` property indicates whether a build is executing on a continuous integration (CI) server. When set to `true`, this property enables settings that only apply to official builds as opposed to local builds on a developer machine. For example, stored file paths are normalized for official builds. But on a local development machine, the debugger isn't able to find local source files if file paths are normalized.

> [!NOTE]
> Currently, setting this property to `true` works only if you add either a specific [SourceLink](https://github.com/dotnet/sourcelink) provider package reference or a `<SourceRoot Include="$(MyDirectory)" />` item. For more information, see [dotnet/roslyn issue 55860](https://github.com/dotnet/roslyn/issues/55860).

You can use your CI system's variable to conditionally set the `ContinuousIntegrationBuild` property. For example, the variable name for Azure Pipelines is `TF_BUILD`:

```xml
<PropertyGroup Condition="'$(TF_BUILD)' == 'true'">
  <ContinuousIntegrationBuild>true</ContinuousIntegrationBuild>
</PropertyGroup>
```

For GitHub Actions, the variable name is `GITHUB_ACTIONS`:

```xml
<PropertyGroup Condition="'$(GITHUB_ACTIONS)' == 'true'">
  <ContinuousIntegrationBuild>true</ContinuousIntegrationBuild>
</PropertyGroup>
```

### CopyDebugSymbolFilesFromPackages

When this property is set to `true`, all symbol files (also known as PDB files) from `PackageReference` items in the project are copied to the build output. These files can provide more informative stack traces for exceptions and make memory dumps and traces of the running application easier to understand. However, including these files results in an increased deployment bundle size.

This property was introduced in .NET SDK 7.0.100, though it defaults to not being specified.

### CopyDocumentationFilesFromPackages

When this property is set to `true`, all generated XML documentation files from `PackageReference` items in the project are copied to the build output. Note that enabling this feature will result in increased deployment bundle size.

This property was introduced in .NET SDK 7.0.100, though it defaults to not being specified.

### DisableImplicitFrameworkDefines

The `DisableImplicitFrameworkDefines` property controls whether or not the SDK generates preprocessor symbols for the target framework and platform for the .NET project. When this property is set to `false` or is unset (which is the default value) preprocessor symbols are generated for:

- Framework without version (`NETFRAMEWORK`, `NETSTANDARD`, `NET`)
- Framework with version (`NET48`, `NETSTANDARD2_0`, `NET6_0`)
- Framework with version minimum bound (`NET48_OR_GREATER`, `NETSTANDARD2_0_OR_GREATER`, `NET6_0_OR_GREATER`)

For more information on target framework monikers and these implicit preprocessor symbols, see [Target frameworks](../../standard/frameworks.md).

Additionally, if you specify an operating system-specific target framework in the project (for example `net6.0-android`), the following preprocessor symbols are generated:

- Platform without version (`ANDROID`, `IOS`, `WINDOWS`)
- Platform with version (`IOS15_1`)
- Platform with version minimum bound (`IOS15_1_OR_GREATER`)

For more information on operating system-specific target framework monikers, see [OS-specific TFMs](../../standard/frameworks.md#net-5-os-specific-tfms).

Finally, if your target framework implies support for older target frameworks, preprocessor symbols for those older frameworks are emitted. For example, `net6.0` **implies** support for `net5.0` and so on all the way back to `.netcoreapp1.0`. So for each of these target frameworks, the *Framework with version minimum bound* symbol will be defined.

### DocumentationFile

The `DocumentationFile` property lets you specify a file name for the XML file that contains the documentation for your library. For IntelliSense to function correctly with your documentation, the file name must be the same as the assembly name and must be in the same directory as the assembly. If you don't specify this property but you do set [GenerateDocumentationFile](#generatedocumentationfile) to `true`, the name of the documentation file defaults to the name of your assembly but with an *.xml* file extension. For this reason, it's often easier to omit this property and use the [GenerateDocumentationFile property](#generatedocumentationfile) instead.

If you specify this property but you set [GenerateDocumentationFile](#generatedocumentationfile) to `false`, the compiler *does not* generate a documentation file. If you specify this property and omit the [GenerateDocumentationFile property](#generatedocumentationfile), the compiler *does* generate a documentation file.

```xml
<PropertyGroup>
  <DocumentationFile>path/to/file.xml</DocumentationFile>
</PropertyGroup>
```

### EmbeddedResourceUseDependentUponConvention

The `EmbeddedResourceUseDependentUponConvention` property defines whether resource manifest file names are generated from type information in source files that are co-located with resource files. For example, if *Form1.resx* is in the same folder as *Form1.cs*, and `EmbeddedResourceUseDependentUponConvention` is set to `true`, the generated *.resources* file takes its name from the first type that's defined in *Form1.cs*. If `MyNamespace.Form1` is the first type defined in *Form1.cs*, the generated file name is *MyNamespace.Form1.resources*.

> [!NOTE]
> If `LogicalName`, `ManifestResourceName`, or `DependentUpon` metadata is specified for an `EmbeddedResource` item, the generated manifest file name for that resource file is based on that metadata instead.

By default, in a new .NET project that targets .NET Core 3.0 or a later version, this property is set to `true`. If set to `false`, and no `LogicalName`, `ManifestResourceName`, or `DependentUpon` metadata is specified for the `EmbeddedResource` item in the project file, the resource manifest file name is based off the root namespace for the project and the relative file path to the *.resx* file. For more information, see [How resource manifest files are named](../resources/manifest-file-names.md).

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

### EnableWindowsTargeting

Set the `EnableWindowsTargeting` property to `true` to build Windows apps (for example, Windows Forms or Windows Presentation Foundation apps) on a non-Windows platform. If you don't set this property to `true`, you'll get build warning [NETSDK1100](../tools/sdk-errors/netsdk1100.md). This error occurs because targeting and runtime packs aren't automatically downloaded on platforms that aren't supported. By setting this property, those packs are downloaded when cross-targeting.

> [!NOTE]
> This property is currently recommended to allow development on non-Windows platforms. But when the application is ready to be released, it should be built on Windows. When building on a non-Windows platform, the output may not be the same as when building on Windows. In particular, the executable is not marked as a Windows application (which means that it will always launch a console window) and won't have an icon embedded.

```xml
<PropertyGroup>
  <EnableWindowsTargeting>true</EnableWindowsTargeting>
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

### DisableRuntimeMarshalling

The `DisableRuntimeMarshalling` property enables you to specify that you would like to disable runtime marshalling support for your project. If this property is set to `true`, then the <xref:System.Runtime.CompilerServices.DisableRuntimeMarshallingAttribute> is added to the assembly and any P/Invokes or delegate-based interop will follow the rules for [disabled runtime marshalling](../../standard/native-interop/disabled-marshalling.md).

```xml
<PropertyGroup>
    <DisableRuntimeMarshalling>True</DisableRuntimeMarshalling>
</PropertyGroup>
```

## Default item inclusion properties

The following MSBuild properties are documented in this section:

- [DefaultItemExcludesInProjectFolder](#defaultitemexcludesinprojectfolder)
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

### DefaultItemExcludesInProjectFolder

Use the `DefaultItemExcludesInProjectFolder` property to define glob patterns for files and folders in the project folder that should be excluded from the include, exclude, and remove globs. By default, folders that start with a period (`.`), such as *.git* and *.vs*, are excluded from the glob patterns.

This property is very similar to the `DefaultItemExcludes` property, except that it only considers files and folders in the project folder. When a glob pattern would unintentionally match items outside the project folder with a relative path, use the `DefaultItemExcludesInProjectFolder` property instead of the `DefaultItemExcludes` property.

```xml
<PropertyGroup>
  <DefaultItemExcludesInProjectFolder>$(DefaultItemExcludesInProjectFolder);**/myprefix*/**</DefaultItemExcludesInProjectFolder>
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
- [_SkipUpgradeNetAnalyzersNuGetWarning](#_skipupgradenetanalyzersnugetwarning)

### AnalysisLevel

The `AnalysisLevel` property lets you specify a set of code analyzers to run according to a .NET release. Each .NET release has a set of code analysis rules. Of that set, the rules that are enabled by default for that release analyze your code. For example, if you upgrade from .NET 8 to .NET 9 but don't want the default set of code analysis rules to change, set `AnalysisLevel` to `8`.

```xml
<PropertyGroup>
  <AnalysisLevel>8</AnalysisLevel>
</PropertyGroup>
```

Optionally, you can specify a compound value for this property that also specifies how aggressively to enable rules. Compound values take the form `<version>-<mode>`, where the `<mode>` value is one of the [AnalysisMode](#analysismode) values. The following example uses the `preview` version of code analyzers, and enables the `recommended` set of rules.

```xml
<PropertyGroup>
  <AnalysisLevel>preview-recommended</AnalysisLevel>
</PropertyGroup>
```

Default value:

- If your project targets .NET 5 or later, or if you've added the [AnalysisMode](#analysismode) property, the default value is `latest`.
- Otherwise, this property is omitted unless you explicitly add it to the project file.

The following table shows the values you can specify.

| Value    | Meaning                                                                          |
|----------|----------------------------------------------------------------------------------|
| `latest` | The latest code analyzers that have been released are used. This is the default. |
| `latest-<mode>` | The latest code analyzers that have been released are used. The `<mode>` value determines which rules are enabled. |
| `preview` | The latest code analyzers are used, even if they are in preview. |
| `preview-<mode>` | The latest code analyzers are used, even if they are in preview. The `<mode>` value determines which rules are enabled. |
| `9.0` | The set of rules that was available for the .NET 9 release is used, even if newer rules are available. |
| `9.0-<mode>` | The set of rules that was available for the .NET 9 release is used, even if newer rules are available. The `<mode>` value determines which rules are enabled. |
| `9` | The set of rules that was available for the .NET 9 release is used, even if newer rules are available. |
| `9-<mode>` | The set of rules that was available for the .NET 9 release is used, even if newer rules are available. The `<mode>` value determines which rules are enabled. |
| `8.0` | The set of rules that was available for the .NET 8 release is used, even if newer rules are available. |
| `8.0-<mode>` | The set of rules that was available for the .NET 8 release is used, even if newer rules are available. The `<mode>` value determines which rules are enabled. |
| `8` | The set of rules that was available for the .NET 8 release is used, even if newer rules are available. |
| `8-<mode>` | The set of rules that was available for the .NET 8 release is used, even if newer rules are available. The `<mode>` value determines which rules are enabled. |
| `7.0` | The set of rules that was available for the .NET 7 release is used, even if newer rules are available. |
| `7.0-<mode>` | The set of rules that was available for the .NET 7 release is used, even if newer rules are available. The `<mode>` value determines which rules are enabled. |
| `7` | The set of rules that was available for the .NET 7 release is used, even if newer rules are available. |
| `7-<mode>` | The set of rules that was available for the .NET 7 release is used, even if newer rules are available. The `<mode>` value determines which rules are enabled. |

> [!NOTE]
>
> - If you set [EnforceCodeStyleInBuild](#enforcecodestyleinbuild) to `true`, this property affects [code-style (IDEXXXX) rules](../../fundamentals/code-analysis/style-rules/index.md) (in addition to code-quality rules).
> - If you set a compound value for `AnalysisLevel`, you don't need to specify an [AnalysisMode](#analysismode). However, if you do, `AnalysisLevel` takes precedence over `AnalysisMode`.
> - This property has no effect on code analysis in projects that don't reference a [project SDK](overview.md), for example, legacy .NET Framework projects that reference the Microsoft.CodeAnalysis.NetAnalyzers NuGet package.

### AnalysisLevel\<Category>

This property is the same as [AnalysisLevel](#analysislevel), except that it only applies to a specific [category of code-analysis rules](../../fundamentals/code-analysis/categories.md). This property allows you to use a different version of code analyzers for a specific category, or to enable or disable rules at a different level to the other rule categories. If you omit this property for a particular category of rules, it defaults to the [AnalysisLevel](#analysislevel) value. The available values are the same as those for [AnalysisLevel](#analysislevel).

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

| Property name           | Rule category                                                                     |
|-------------------------|-----------------------------------------------------------------------------------|
| `<AnalysisLevelDesign>` | [Design rules](../../fundamentals/code-analysis/quality-rules/design-warnings.md) |
| `<AnalysisLevelDocumentation>` | [Documentation rules](../../fundamentals/code-analysis/quality-rules/documentation-warnings.md) |
| `<AnalysisLevelGlobalization>` | [Globalization rules](../../fundamentals/code-analysis/quality-rules/globalization-warnings.md) |
| `<AnalysisLevelInteroperability>` | [Portability and interoperability rules](../../fundamentals/code-analysis/quality-rules/interoperability-warnings.md) |
| `<AnalysisLevelMaintainability>` | [Maintainability rules](../../fundamentals/code-analysis/quality-rules/maintainability-warnings.md) |
| `<AnalysisLevelNaming>` | [Naming rules](../../fundamentals/code-analysis/quality-rules/naming-warnings.md) |
| `<AnalysisLevelPerformance>` | [Performance rules](../../fundamentals/code-analysis/quality-rules/performance-warnings.md) |
| `<AnalysisLevelSingleFile>` | [Single-file application rules](../../core/deploying/single-file/warnings/overview.md) |
| `<AnalysisLevelReliability>` | [Reliability rules](../../fundamentals/code-analysis/quality-rules/reliability-warnings.md) |
| `<AnalysisLevelSecurity>` | [Security rules](../../fundamentals/code-analysis/quality-rules/security-warnings.md) |
| `<AnalysisLevelStyle>` | [Code-style (IDEXXXX) rules](../../fundamentals/code-analysis/style-rules/index.md) |
| `<AnalysisLevelUsage>` | [Usage rules](../../fundamentals/code-analysis/quality-rules/usage-warnings.md) |

### AnalysisMode

The .NET SDK ships with all of the ["CA" code quality rules](../../fundamentals/code-analysis/quality-rules/index.md). By default, only [some rules are enabled](../../fundamentals/code-analysis/overview.md#enabled-rules) as build warnings in each .NET release. The `AnalysisMode` property lets you customize the set of rules that's enabled by default. You can either switch to a more aggressive analysis mode where you can opt out of rules individually, or a more conservative analysis mode where you can opt in to specific rules. For example, if you want to enable all rules as build warnings, set the value to `All`.

```xml
<PropertyGroup>
  <AnalysisMode>All</AnalysisMode>
</PropertyGroup>
```

The following table shows the available option values. They're listed in increasing order of the number of rules they enable.

[!INCLUDE [analysis-model-levels](../../fundamentals/code-analysis/includes/analysis-model-levels.md)]

> [!NOTE]
>
> - If you set [EnforceCodeStyleInBuild](#enforcecodestyleinbuild) to `true`, this property affects [code-style (IDEXXXX) rules](../../fundamentals/code-analysis/style-rules/index.md) (in addition to code-quality rules).
> - If you use a compound value for [AnalysisLevel](#analysislevel), for example, `<AnalysisLevel>9-recommended</AnalysisLevel>`, you can omit this property entirely. However, if you specify both properties, `AnalysisLevel` takes precedence over `AnalysisMode`.
> - This property has no effect on code analysis in projects that don't reference a [project SDK](overview.md), for example, legacy .NET Framework projects that reference the Microsoft.CodeAnalysis.NetAnalyzers NuGet package.

### AnalysisMode\<Category>

This property is the same as [AnalysisMode](#analysismode), except that it only applies to a specific [category of code-analysis rules](../../fundamentals/code-analysis/categories.md). This property allows you to enable or disable rules at a different level to the other rule categories. If you omit this property for a particular category of rules, it defaults to the [AnalysisMode](#analysismode) value. The available values are the same as those for [AnalysisMode](#analysismode).

```xml
<PropertyGroup>
  <AnalysisModeSecurity>All</AnalysisModeSecurity>
</PropertyGroup>
```

The following table lists the property name for each rule category.

| Property name          | Rule category                                                                     |
|------------------------|-----------------------------------------------------------------------------------|
| `<AnalysisModeDesign>` | [Design rules](../../fundamentals/code-analysis/quality-rules/design-warnings.md) |
| `<AnalysisModeDocumentation>` | [Documentation rules](../../fundamentals/code-analysis/quality-rules/documentation-warnings.md) |
| `<AnalysisModeGlobalization>` | [Globalization rules](../../fundamentals/code-analysis/quality-rules/globalization-warnings.md) |
| `<AnalysisModeInteroperability>` | [Portability and interoperability rules](../../fundamentals/code-analysis/quality-rules/interoperability-warnings.md) |
| `<AnalysisModeMaintainability>` | [Maintainability rules](../../fundamentals/code-analysis/quality-rules/maintainability-warnings.md) |
| `<AnalysisModeNaming>` | [Naming rules](../../fundamentals/code-analysis/quality-rules/naming-warnings.md) |
| `<AnalysisModePerformance>` | [Performance rules](../../fundamentals/code-analysis/quality-rules/performance-warnings.md) |
| `<AnalysisModeSingleFile>` | [Single-file application rules](../../core/deploying/single-file/warnings/overview.md) |
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

### _SkipUpgradeNetAnalyzersNuGetWarning

The `_SkipUpgradeNetAnalyzersNuGetWarning` property lets you configure whether you receive a warning if you're using code analyzers from a NuGet package that's out-of-date when compared with the code analyzers in the latest .NET SDK. The warning looks similar to:

**The .NET SDK has newer analyzers with version '6.0.0' than what version '5.0.3' of 'Microsoft.CodeAnalysis.NetAnalyzers' package provides. Update or remove this package reference.**

To remove this warning and continue to use the version of code analyzers in the NuGet package, set `_SkipUpgradeNetAnalyzersNuGetWarning` to `true` in your project file.

```xml
<PropertyGroup>
  <_SkipUpgradeNetAnalyzersNuGetWarning>true</_SkipUpgradeNetAnalyzersNuGetWarning>
</PropertyGroup>
```

## Runtime configuration properties

You can configure some runtime behaviors by specifying MSBuild properties in the project file of the app. For information about other ways of configuring runtime behavior, see [Runtime configuration settings](../runtime-config/index.md).

- [AutoreleasePoolSupport](#autoreleasepoolsupport)
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
- [TieredPGO](#tieredpgo)
- [UseWindowsThreadPool](#usewindowsthreadpool)

### AutoreleasePoolSupport

The `AutoreleasePoolSupport` property configures whether each managed thread receives an implicit [NSAutoreleasePool](https://developer.apple.com/documentation/foundation/nsautoreleasepool) when running on a supported macOS platform. For more information, see [`AutoreleasePool` for managed threads](../runtime-config/threading.md#autoreleasepool-for-managed-threads).

```xml
<PropertyGroup>
  <AutoreleasePoolSupport>true</AutoreleasePoolSupport>
</PropertyGroup>
```

### ConcurrentGarbageCollection

The `ConcurrentGarbageCollection` property configures whether [background (concurrent) garbage collection](../../standard/garbage-collection/background-gc.md) is enabled. Set the value to `false` to disable background garbage collection. For more information, see [Background GC](../runtime-config/garbage-collector.md#background-gc).

```xml
<PropertyGroup>
  <ConcurrentGarbageCollection>false</ConcurrentGarbageCollection>
</PropertyGroup>
```

### InvariantGlobalization

The `InvariantGlobalization` property configures whether the app runs in *globalization-invariant* mode, which means it doesn't have access to culture-specific data. Set the value to `true` to run in globalization-invariant mode. For more information, see [Invariant mode](../runtime-config/globalization.md#invariant-mode).

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

The `RetainVMGarbageCollection` property configures the garbage collector to put deleted memory segments on a standby list for future use or release them. Setting the value to `true` tells the garbage collector to put the segments on a standby list. For more information, see [Retain VM](../runtime-config/garbage-collector.md#retain-vm).

```xml
<PropertyGroup>
  <RetainVMGarbageCollection>true</RetainVMGarbageCollection>
</PropertyGroup>
```

### ServerGarbageCollection

The `ServerGarbageCollection` property configures whether the application uses [workstation garbage collection or server garbage collection](../../standard/garbage-collection/workstation-server-gc.md). Set the value to `true` to use server garbage collection. For more information, see [Workstation vs. server](../runtime-config/garbage-collector.md#workstation-vs-server).

```xml
<PropertyGroup>
  <ServerGarbageCollection>true</ServerGarbageCollection>
</PropertyGroup>
```

### ThreadPoolMaxThreads

The `ThreadPoolMaxThreads` property configures the maximum number of threads for the worker thread pool. For more information, see [Maximum threads](../runtime-config/threading.md#maximum-threads).

```xml
<PropertyGroup>
  <ThreadPoolMaxThreads>20</ThreadPoolMaxThreads>
</PropertyGroup>
```

### ThreadPoolMinThreads

The `ThreadPoolMinThreads` property configures the minimum number of threads for the worker thread pool. For more information, see [Minimum threads](../runtime-config/threading.md#minimum-threads).

```xml
<PropertyGroup>
  <ThreadPoolMinThreads>4</ThreadPoolMinThreads>
</PropertyGroup>
```

### TieredCompilation

The `TieredCompilation` property configures whether the just-in-time (JIT) compiler uses [tiered compilation](../whats-new/dotnet-core-3-0.md#tiered-compilation). Set the value to `false` to disable tiered compilation. For more information, see [Tiered compilation](../runtime-config/compilation.md#tiered-compilation).

```xml
<PropertyGroup>
  <TieredCompilation>false</TieredCompilation>
</PropertyGroup>
```

### TieredCompilationQuickJit

The `TieredCompilationQuickJit` property configures whether the JIT compiler uses quick JIT. Set the value to `false` to disable quick JIT. For more information, see [Quick JIT](../runtime-config/compilation.md#quick-jit).

```xml
<PropertyGroup>
  <TieredCompilationQuickJit>false</TieredCompilationQuickJit>
</PropertyGroup>
```

### TieredCompilationQuickJitForLoops

The `TieredCompilationQuickJitForLoops` property configures whether the JIT compiler uses quick JIT on methods that contain loops. Set the value to `true` to enable quick JIT on methods that contain loops. For more information, see [Quick JIT for loops](../runtime-config/compilation.md#quick-jit-for-loops).

```xml
<PropertyGroup>
  <TieredCompilationQuickJitForLoops>true</TieredCompilationQuickJitForLoops>
</PropertyGroup>
```

### TieredPGO

The `TieredPGO` property controls whether dynamic or tiered profile-guided optimization (PGO) is enabled. Set the value to `true` to enable tiered PGO. For more information, see [Profile-guided optimization](../runtime-config/compilation.md#profile-guided-optimization).

```xml
<PropertyGroup>
  <TieredPGO>true</TieredPGO>
</PropertyGroup>
```

### UseWindowsThreadPool

The `UseWindowsThreadPool` property configures whether thread pool thread management is delegated to the Windows thread pool (Windows only). The default value is `false`, in which case the .NET thread pool is used. For more information, see [Windows thread pool](../runtime-config/threading.md#windows-thread-pool).

```xml
<PropertyGroup>
  <UseWindowsThreadPool>true</UseWindowsThreadPool>
</PropertyGroup>
```

## Reference-related properties

The following MSBuild properties are documented in this section:

- [AssetTargetFallback](#assettargetfallback)
- [DisableImplicitFrameworkReferences](#disableimplicitframeworkreferences)
- [DisableTransitiveFrameworkReferenceDownloads](#disabletransitiveframeworkreferencedownloads)
- [DisableTransitiveProjectReferences](#disabletransitiveprojectreferences)
- [ManagePackageVersionsCentrally](#managepackageversionscentrally)
- [Restore-related properties](#restore-related-properties)
- [UseMauiEssentials](#usemauiessentials)
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

Set this property to `true` to disable implicit [FrameworkReference](#frameworkreference) or [PackageReference](#packagereference) items. If you set this property to `true`, you can add explicit references to just the frameworks or packages you need.

```xml
<PropertyGroup>
  <DisableImplicitFrameworkReferences>true</DisableImplicitFrameworkReferences>
</PropertyGroup>
```

### DisableTransitiveFrameworkReferenceDownloads

Set the `DisableTransitiveFrameworkReferenceDownloads` property to `true` to avoid downloading extra runtime and targeting packs that aren't directly referenced by your project.

```xml
<PropertyGroup>
  <DisableTransitiveFrameworkReferenceDownloads>true</DisableTransitiveFrameworkReferenceDownloads>
</PropertyGroup>
```

### DisableTransitiveProjectReferences

The `DisableTransitiveProjectReferences` property controls implicit project references. Set this property to `true` to disable implicit `ProjectReference` items. Disabling implicit project references results in non-transitive behavior similar to the [legacy project system](https://github.com/dotnet/project-system/blob/main/docs/feature-comparison.md).

When this property is `true`, it has a similar effect to that of setting [`PrivateAssets="All"`](/nuget/consume-packages/package-references-in-project-files#controlling-dependency-assets) on all of the dependencies of the depended-upon project.

If you set this property to `true`, you can add explicit references to just the projects you need.

```xml
<PropertyGroup>
  <DisableTransitiveProjectReferences>true</DisableTransitiveProjectReferences>
</PropertyGroup>
```

### ManagePackageVersionsCentrally

The `ManagePackageVersionsCentrally` property was introduced in .NET 7. By setting it to `true` in a *Directory.Packages.props* file in the root of your repository, you can manage common dependencies in your projects from one location. Add versions for common package dependencies using `PackageVersion` items in the *Directory.Packages.props* file. Then, in the individual project files, you can omit `Version` attributes from any [`PackageReference`](#packagereference) items that refer to centrally managed packages.

Example *Directory.Packages.props* file:

```xml
<PropertyGroup>
  <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>
</PropertyGroup>
...
<ItemGroup>
  <PackageVersion Include="Microsoft.Extensions.Configuration" Version="7.0.0" />
</ItemGroup>
```

Individual project file:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Configuration" />
</ItemGroup>
```

For more information, see [central package management (CPM)](/nuget/consume-packages/central-package-management).

### Restore-related properties

Restoring a referenced package installs all of its direct dependencies and all the dependencies of those dependencies. You can customize package restoration by specifying properties such as `RestorePackagesPath` and `RestoreIgnoreFailedSources`. For more information about these and other properties, see [restore target](/nuget/reference/msbuild-targets#restore-target).

```xml
<PropertyGroup>
  <RestoreIgnoreFailedSource>true</RestoreIgnoreFailedSource>
</PropertyGroup>
```

### UseMauiEssentials

Set the `UseMauiEssentials` property to `true` to declare an explicit reference to a project or package that depends on MAUI Essentials. This setting ensures that your project pulls in the correct known framework reference for MAUI Essentials. If your project references a project that uses MAUI Essentials but you don't set this property to `true`, you might encounter build warning `NETSDK1186`.

```xml
<PropertyGroup>
  <UseMauiEssentials>true</UseMauiEssentials>
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

The `RunArguments` property defines the arguments that are passed to the app when it's run.

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

## SDK-related properties

The following MSBuild properties are documented in this section:

- [SdkAnalysisLevel](#sdkanalysislevel)

### SdkAnalysisLevel

Introduced in .NET 9, the `SdkAnalysisLevel` property can be used to configure how *strict* SDK tooling is. It helps you manage SDK warning levels in situations where you might not be able to pin SDKs via *global.json* or other means. You can use this property to tell a newer SDK to behave as if it were an older SDK, with regards to a specific tool or feature, without having to install the older SDK.

The allowed values of this property are SDK feature bands, for example, 8.0.100 and 8.0.400. The value defaults to the SDK feature band of the running SDK. For example, for SDK 9.0.102, the value would be 9.0.100. (For information about how the .NET SDK is versioned, see [How .NET is versioned](../versions/index.md).)

```xml
<PropertyGroup>
  <SdkAnalysisLevel>8.0.400</SdkAnalysisLevel>
</PropertyGroup>
```

For more information, see [SDK Analysis Level Property and Usage](https://github.com/dotnet/designs/blob/main/proposed/sdk-analysis-level.md).

## Test project&ndash;related properties

The following MSBuild properties are documented in this section:

- [IsTestProject](#istestproject)
- [IsTestingPlatformApplication](#istestingplatformapplication)
- [Enable\[NugetPackageNameWithoutDots\]](#enablenugetpackagenamewithoutdots)
- [EnableAspireTesting](#enableaspiretesting)
- [EnablePlaywright](#enableplaywright)
- [EnableMSTestRunner](#enablemstestrunner)
- [EnableNUnitRunner](#enablenunitrunner)
- [GenerateTestingPlatformEntryPoint](#generatetestingplatformentrypoint)
- [TestingPlatformCaptureOutput](#testingplatformcaptureoutput)
- [TestingPlatformCommandLineArguments](#testingplatformcommandlinearguments)
- [TestingPlatformDotnetTestSupport](#testingplatformdotnettestsupport)
- [TestingPlatformShowTestsFailure](#testingplatformshowtestsfailure)
- [TestingExtensionsProfile](#testingextensionsprofile)
- [UseVSTest](#usevstest)
- [MSTestAnalysisMode](#mstestanalysismode)

### IsTestProject

The `IsTestProject` property signifies that a project is a test project. When this property is set to `true`, validation to check if the project references a self-contained executable is disabled. That's because test projects have an `OutputType` of `Exe` but usually call APIs in a referenced executable rather than trying to run. In addition, if a project references a project where `IsTestProject` is set to `true`, the test project isn't validated as an executable reference.

This property is mainly needed for the `dotnet test` scenario and has no impact when using *vstest.console.exe*.

> [!NOTE]
> If your project specifies the [MSTest SDK](../testing/unit-testing-mstest-sdk.md), you don't need to set this property. It's set automatically. Similarly, this property is set automatically for projects that reference the Microsoft.NET.Test.Sdk NuGet package linked to VSTest.

### IsTestingPlatformApplication

When your project references the [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild) package, setting `IsTestingPlatformApplication` to `true` (which is also the default value if not specified) does the following:

- Generates the entry point to the test project.
- Generates the configuration file.
- Detects the extensions.

Setting the property to `false` disables the transitive dependency to the package. A *transitive dependency* is when a project that references another project that references a given package behaves as if *it* references the package. You'd typically set this property to `false` in a non-test project that references a test project. For more information, see [error CS8892](../testing/unit-testing-platform-faq.md#error-cs8892-method-testingplatformentrypointmainstring-will-not-be-used-as-an-entry-point-because-a-synchronous-entry-point-programmainstring-was-found).

If your test project references MSTest, NUnit, or xUnit, this property is set to the same value as [EnableMSTestRunner](#enablemstestrunner), [EnableNUnitRunner](#enablenunitrunner), or `UseMicrosoftTestingPlatformRunner` (for xUnit).

### Enable\[NugetPackageNameWithoutDots\]

Use a property with the pattern `Enable[NugetPackageNameWithoutDots]` to enable or disable Microsoft.Testing.Platform extensions.

For example, to enable the crash dump extension (NuGet package [Microsoft.Testing.Extensions.CrashDump](https://www.nuget.org/packages/Microsoft.Testing.Extensions.CrashDump)), set the `EnableMicrosoftTestingExtensionsCrashDump` to `true`.

For more information, see [Enable or disable extensions](../testing/unit-testing-mstest-sdk.md#enable-or-disable-extensions).

### EnableAspireTesting

When you use the [MSTest project SDK](../testing/unit-testing-mstest-sdk.md), you can use the `EnableAspireTesting` property to bring in all the dependencies and default `using` directives you need for testing with `Aspire` and `MSTest`. This property is available in MSTest 3.4 and later versions.

For more information, see [Test with .NET Aspire](../testing/unit-testing-mstest-sdk.md#test-with-net-aspire).

### EnablePlaywright

When you use the [MSTest project SDK](../testing/unit-testing-mstest-sdk.md), you can use the `EnablePlaywright` property to bring in all the dependencies and default `using` directives you need for testing with `Playwright` and `MSTest`.This property is available in MSTest 3.4 and later versions.

For more information, see [Playwright](../testing/unit-testing-mstest-sdk.md#test-with-playwright).

### EnableMSTestRunner

The `EnableMSTestRunner` property enables or disables the use of the [Microsoft Testing Platform](../testing/unit-testing-mstest-runner-intro.md). The Microsoft Testing Platform is a lightweight and portable alternative to VSTest. This property is available in MSTest 3.2 and later versions.

> [!NOTE]
> If your project specifies the [MSTest SDK](../testing/unit-testing-mstest-sdk.md), you don't need to set this property. It's set automatically.

### EnableNUnitRunner

The `EnableNUnitRunner` property enables or disables the use of the [NUnit runner](../testing/unit-testing-nunit-runner-intro.md). The NUnit runner is a lightweight and portable alternative to VSTest. This property is available in [NUnit3TestAdapter](https://www.nuget.org/packages/NUnit3TestAdapter) in version 5.0 and later.

### GenerateTestingPlatformEntryPoint

Setting the `GenerateTestingPlatformEntryPoint` property to `false` disables the automatic generation of the program entry point in an MSTest or NUnit test project. You might want to set this property to `false` when you manually define an entry point, or when you reference a test project from an executable that also has an entry point.

For more information, see [error CS8892](../testing/unit-testing-platform-faq.md#error-cs8892-method-testingplatformentrypointmainstring-will-not-be-used-as-an-entry-point-because-a-synchronous-entry-point-programmainstring-was-found).

To control the generation of the entry point in a VSTest project, use the `GenerateProgramFile` property.

### TestingPlatformCaptureOutput

The `TestingPlatformCaptureOutput` property controls whether all console output that a test executable writes is captured and hidden from the user when you use `dotnet test` to run `Microsoft.Testing.Platform` tests. By default, the console output is hidden. This output includes the banner, version information, and formatted test information. Set this property to `false` to show this information together with MSBuild output.

For more information, see [Show complete platform output](../testing/unit-testing-platform-integration-dotnet-test.md#show-complete-platform-output).

### TestingPlatformCommandLineArguments

The `TestingPlatformCaptureOutput` property lets you specify command-line arguments to the test app when you use `dotnet test` to run `Microsoft.Testing.Platform` tests. The following project file snippet shows an example.

```xml
<PropertyGroup>
  ...
  <TestingPlatformCommandLineArguments>--minimum-expected-tests 10</TestingPlatformCommandLineArguments>
</PropertyGroup>
```

### TestingPlatformDotnetTestSupport

The `TestingPlatformDotnetTestSupport` property lets you specify whether VSTest is used when you use `dotnet test` to run tests. If you set this property to `true`, VSTest is disabled and all `Microsoft.Testing.Platform` tests are run directly.

If you have a solution that contains VSTest test projects as well as MSTest, NUnit, or XUnit projects, you should make one call per mode (that is, `dotnet test` won't run tests from both VSTest and the newer platforms in one call).

### TestingPlatformShowTestsFailure

The `TestingPlatformShowTestsFailure` property lets you control whether a single failure or all errors in a failed test are reported when you use `dotnet test` to run tests. By default, test failures are summarized into a _.log_ file, and a single failure per test project is reported to MSBuild. To show errors per failed test, set this property to `true` in your project file.

### TestingExtensionsProfile

When you use the [MSTest project SDK](../testing/unit-testing-mstest-sdk.md), the `TestingExtensionsProfile` property lets you select a profile to use. The following table shows the allowable values.

| Value          | Description                                                                                   |
|----------------|-----------------------------------------------------------------------------------------------|
| `Default`      | Enables the recommended extensions for this version of MSTest.SDK.                            |
| `None`         | No extensions are enabled.                                                                    |
| `AllMicrosoft` | Enable all extensions shipped by Microsoft (including extensions with a restrictive license). |

For more information, see [Microsoft Testing Platform profile](../testing/unit-testing-mstest-sdk.md#Microsoft-Testing-Platform-profile).

### UseVSTest

Set the `UseVSTest` property to `true` to switch from Microsoft Testing Platform to the [VSTest](/visualstudio/test/vstest-console-options) runner when using the [MSTest project SDK](../testing/unit-testing-mstest-sdk.md).

### MSTestAnalysisMode

This property decides which analyzers are enabled at which severity. For more information, see [MSTest code analysis](../testing/mstest-analyzers/overview.md).

## Hosting-related properties

The following MSBuild properties are documented in this section:

- [AppHostDotNetSearch](#apphostdotnetsearch)
- [AppHostRelativeDotNet](#apphostrelativedotnet)
- [EnableComHosting](#enablecomhosting)
- [EnableDynamicLoading](#enabledynamicloading)

### AppHostDotNetSearch

The `AppHostDotNetSearch` property configures how [the native executable](../deploying/index.md#produce-an-executable) produced for an application will search for a .NET installation. This property only impacts the executable produced on publish, not build.

```xml
<PropertyGroup>
  <AppHostDotNetSearch>Global</AppHostDotNetSearch>
</PropertyGroup>
```

The following table lists valid values. You can specify multiple values, separated by semi-colons.

| Value | Meaning |
| --- | --- |
| `AppLocal` | App executable's folder |
| `AppRelative` | Path relative to the app executable as specified by [AppHostRelativeDotNet](#apphostrelativedotnet) |
| `EnvironmentVariables` | Value of [`DOTNET_ROOT[_<arch>]`](../tools/dotnet-environment-variables.md#dotnet_root-dotnet_rootx86-dotnet_root_x86-dotnet_root_x64) environment variables |
| `Global` | [Registered](https://github.com/dotnet/designs/blob/main/accepted/2020/install-locations.md#global-install-to-custom-location) and [default](https://github.com/dotnet/designs/blob/main/accepted/2020/install-locations.md#global-install-to-default-location) global install locations |

This property was introduced in .NET 9.

### AppHostRelativeDotNet

The `AppHostRelativeDotNet` property allows specifying a relative path for the app executable to look for the .NET installation when it's [configured to do so](#apphostdotnetsearch). Setting the `AppHostRelativeDotNet` property implies that [`AppHostDotNetSearch`](#apphostdotnetsearch) is `AppRelative`. This property only impacts the executable produced on publish, not build.

```xml
<PropertyGroup>
  <AppHostRelativeDotNet>./relative/path/to/runtime</AppHostRelativeDotNet>
</PropertyGroup>
```

This property was introduced in .NET 9.

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

### FrameworkReference

The `FrameworkReference` item defines a reference to a .NET shared framework.

The `Include` attribute specifies the framework ID.

The project file snippet in the following example references the Microsoft.AspNetCore.App shared framework.

```xml
<ItemGroup>
  <FrameworkReference Include="Microsoft.AspNetCore.App" />
</ItemGroup>
```

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

For more information, see [Trimming options](../deploying/trimming/trimming-options.md).

### Using

The `Using` item lets you [globally include a namespace](../../csharp/language-reference/keywords/using-directive.md#the-global-modifier) across your C# project, such that you don't have to add a `using` directive for the namespace at the top of your source files. This item is similar to the `Import` item that can be used for the same purpose in Visual Basic projects. This property is available starting in .NET 6.

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

For more information, see [aliased `using` directives](../../csharp/language-reference/keywords/using-directive.md#the-using-alias) and [`using static <type>` directives](../../csharp/language-reference/keywords/using-directive.md#the-static-modifier).

## Item metadata

In addition to the standard [MSBuild item attributes](/visualstudio/msbuild/item-element-msbuild#attributes-and-elements), the following item metadata tags are made available by the .NET SDK:

- [CopyToPublishDirectory](#copytopublishdirectory)
- [LinkBase](#linkbase)

### CopyToPublishDirectory

The `CopyToPublishDirectory` metadata on an MSBuild item controls when the item is copied to the publish directory. The following table shows the allowable values.

| Value | Description |
| ------ | ------------ |
| `PreserveNewest` | Only copies the item if it has changed in the source location. |
| `IfDifferent` | Only copies the item if it has changed either in the source or target location. This setting is helpful for situations where you need to reset changes that occur after publishing. |
| `Always` | Always copies the item. |
| `Never` | Never copies the item. |

From a performance standpoint, `PreserveNewest` is preferable because it enables an incremental build. Avoid using `Always` and use `IfDifferent` instead, which avoids I/O writes with no effect.

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
