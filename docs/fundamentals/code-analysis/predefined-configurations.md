---
title: Predefined configuration profiles (code analysis)
description: Learn about using predefined analysis modes and category properties to configure code analysis in .NET projects.
ms.date: 11/01/2026
---
# Predefined configuration profiles

Predefined configuration profiles make it quick and easy to enable specific categories of code quality rules, such as security, performance, or design rules. By configuring targeted categories, you can identify specific conditions and tailor analysis aggression to your project needs.

Starting in .NET 5, code analysis is built directly into the .NET SDK. Instead of manually copying individual EditorConfig or legacy rule set files from package cache directories, you configure predefined analysis profiles using MSBuild properties in your project file or a *Directory.Build.props* file.

## Analysis mode profiles

You can enable a predefined configuration profile across all rule categories using the [`<AnalysisMode>`](../../core/project-sdk/msbuild-props.md#analysismode) property. The supported profile modes include:

| Analysis mode | Description |
| --- | --- |
| `Default` | Uses default rule severities and only enables high-priority rules by default as build warnings. |
| `Minimum` | Enables a minimal set of critical rules as build warnings. |
| `Recommended` | Enables the recommended set of rules, including standard quality, reliability, and security practices. |
| `All` | Enables all rules across all categories as warnings. |
| `None` | Disables all rules by default. |

For example, to enable the recommended profile for your project, add the following to your project file:

```xml
<PropertyGroup>
  <AnalysisMode>Recommended</AnalysisMode>
</PropertyGroup>
```

You can also specify a compound value with [`<AnalysisLevel>`](../../core/project-sdk/msbuild-props.md#analysislevel), such as `<AnalysisLevel>latest-Recommended</AnalysisLevel>`.

## Category-specific profiles

If you want to configure a specific rule category rather than changing all categories globally, use the corresponding [`<AnalysisMode<Category>>`](../../core/project-sdk/msbuild-props.md#analysismodecategory) property.

For example, to enable all security rules while keeping other categories at their default settings:

```xml
<PropertyGroup>
  <AnalysisModeSecurity>All</AnalysisModeSecurity>
</PropertyGroup>
```

The following table lists the MSBuild properties for each rule category:

| Property name | Rule category |
| --- | --- |
| `<AnalysisModeDesign>` | [Design rules](quality-rules/design-warnings.md) |
| `<AnalysisModeDocumentation>` | [Documentation rules](quality-rules/documentation-warnings.md) |
| `<AnalysisModeGlobalization>` | [Globalization rules](quality-rules/globalization-warnings.md) |
| `<AnalysisModeInteroperability>` | [Portability and interoperability rules](quality-rules/interoperability-warnings.md) |
| `<AnalysisModeMaintainability>` | [Maintainability rules](quality-rules/maintainability-warnings.md) |
| `<AnalysisModeNaming>` | [Naming rules](quality-rules/naming-warnings.md) |
| `<AnalysisModePerformance>` | [Performance rules](quality-rules/performance-warnings.md) |
| `<AnalysisModeReliability>` | [Reliability rules](quality-rules/reliability-warnings.md) |
| `<AnalysisModeSecurity>` | [Security rules](quality-rules/security-warnings.md) |
| `<AnalysisModeStyle>` | [Code-style (IDEXXXX) rules](style-rules/index.md) |
| `<AnalysisModeUsage>` | [Usage rules](quality-rules/usage-warnings.md) |

## Exporting an EditorConfig file

If you need a physical *.editorconfig* file to check into version control or customize individual rule severities:

1. In Visual Studio, navigate to **Tools** > **Options** > **Text Editor** > **C#** (or **Visual Basic**) > **Code Style** > **General**, and select **Generate .editorconfig file from settings**.
1. Alternatively, you can create a baseline configuration using the .NET CLI:

   ```dotnetcli
   dotnet new editorconfig
   ```

1. Reference and source configurations for the official .NET analyzers are also published in the [dotnet/roslyn-analyzers](https://github.com/dotnet/roslyn-analyzers) repository.

> [!NOTE]
> Legacy `.ruleset` files are deprecated in SDK-style projects in favor of EditorConfig and MSBuild properties.

## See also

- [Overview of .NET code analysis](overview.md)
- [MSBuild code analysis properties](../../core/project-sdk/msbuild-props.md#code-analysis-properties)
- [Analyzer configuration](https://github.com/dotnet/roslyn-analyzers/blob/main/docs/Analyzer%20Configuration.md)
- [.NET code style rule options for EditorConfig](code-style-rule-options.md)
