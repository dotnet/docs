---
title: AssemblyInfo properties
description: Learn about assembly attributes and how they correspond to MSBuild properties in .NET Core 2.1 and later versions.
ms.topic: reference
ms.date: 01/08/2021
---
# Map AssemblyInfo attributes to properties

[Assembly attributes](../../standard/assembly/set-attributes.md) that were typically present in an *AssemblyInfo* file in .NET Core 2.0 and earlier versions are automatically generated from properties, starting in .NET Core 2.1.

## Properties per attribute

As shown in the following table, each attribute has a corresponding property that controls its content and another that disables its generation:

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

Notes:

- `AssemblyVersion` and `FileVersion` default to the value of `$(Version)` without the suffix. For example, if `$(Version)` is `1.2.3-beta.4`, then the value would be `1.2.3`.
- `InformationalVersion` defaults to the value of `$(Version)`.
- `InformationalVersion` has `$(SourceRevisionId)` appended if the property is present. It can be disabled using `IncludeSourceRevisionInInformationalVersion`.
- `Copyright` and `Description` properties are also used for NuGet metadata.
- `Configuration` is shared with all the build process and set via the `--configuration` parameter of `dotnet` commands.

## GenerateAssemblyInfo

A Boolean that enables or disables the AssemblyInfo generation. The default value is `true`.

## GeneratedAssemblyInfoFile

The path of the generated assembly info file. Defaults to a file in the `$(IntermediateOutputPath)` (*obj*) directory.
