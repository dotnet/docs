---
title: Code analysis rule categories
description: Learn the different .NET code analysis rule categories.
ms.date: 10/04/2021
ms.topic: reference
helpviewer_keywords:
  - code analysis, categories
---
# Rule categories

Each code analysis rule belongs to a category of rules. For example, design rules support adherence to the .NET design guidelines, and security rules help prevent security flaws. You can [configure the severity level](configuration-options.md#scope) for an entire category of rules. You can also [configure additional options](code-quality-rule-options.md#category-of-rules) on a per-category basis.

The following table shows the different code analysis rule categories and provides a link to the rules in each category. It also lists the configuration value to use in an EditorConfig file to [bulk-configure rule severity](configuration-options.md#severity-level) on a per-category basis. For example, to set the severity of security rule violations to be errors, the EditorConfig entry is `dotnet_analyzer_diagnostic.category-Security.severity = error`.

> [!TIP]
> Setting the severity for a category of rules using the `dotnet_analyzer_diagnostic.category-<category>.severity` syntax doesn't apply to rules that are disabled by default. However, starting in .NET 6, you can use the [AnalysisMode\<Category>](../../core/project-sdk/msbuild-props.md#analysismodecategory) project property to enable all the rules in a category.

## Design rules

|  | Value |
|--|-------|
| **Link to rules** | [Design rules](quality-rules/design-warnings.md) |
| **Description** | Design rules support adherence to the [Framework design guidelines](../../standard/design-guidelines/index.md). |
| **EditorConfig value** | `dotnet_analyzer_diagnostic.category-Design.severity` |
| [**MSBuild property value**](../../core/project-sdk/msbuild-props.md#analysismodecategory) | `<AnalysisModeDesign>` |

## Documentation rules

|  | Value |
|--|-------|
| **Link to rules** | [Documentation rules](quality-rules/documentation-warnings.md)  |
| **Description** | Documentation rules support writing well-documented libraries through the correct use of XML documentation comments for externally visible APIs. |
| **EditorConfig value** | `dotnet_analyzer_diagnostic.category-Documentation.severity` |
| [**MSBuild property value**](../../core/project-sdk/msbuild-props.md#analysismodecategory) | `<AnalysisModeDocumentation>` |

## Globalization rules

|  | Value |
|--|-------|
| **Link to rules** | [Globalization rules](quality-rules/globalization-warnings.md) |
| **Description** | Globalization rules support world-ready libraries and applications. |
| **EditorConfig value** | `dotnet_analyzer_diagnostic.category-Globalization.severity` |
| [**MSBuild property value**](../../core/project-sdk/msbuild-props.md#analysismodecategory) | `<AnalysisModeGlobalization>` |

## Portability and interoperability rules

|  | Value |
|--|-------|
| **Link to rules** | [Portability and interoperability rules](quality-rules/interoperability-warnings.md)  |
| **Description** | Portability rules support portability across different platforms. Interoperability rules support interaction with COM clients. |
| **EditorConfig value** | `dotnet_analyzer_diagnostic.category-Interoperability.severity` |
| [**MSBuild property value**](../../core/project-sdk/msbuild-props.md#analysismodecategory) | `<AnalysisModeInteroperability>` |

## Maintainability rules

|  | Value |
|--|-------|
| **Link to rules** | [Maintainability rules](quality-rules/maintainability-warnings.md) |
| **Description** | Maintainability rules support library and application maintenance. |
| **EditorConfig value** | `dotnet_analyzer_diagnostic.category-Maintainability.severity` |
| [**MSBuild property value**](../../core/project-sdk/msbuild-props.md#analysismodecategory) | `<AnalysisModeMaintainability>` |

## Naming rules

|  | Value |
|--|-------|
| **Link to rules** | [Naming rules](quality-rules/naming-warnings.md) |
| **Description** | Naming rules support adherence to the naming conventions of the .NET design guidelines. |
| **EditorConfig value** | `dotnet_analyzer_diagnostic.category-Naming.severity` |
| [**MSBuild property value**](../../core/project-sdk/msbuild-props.md#analysismodecategory) | `<AnalysisModeNaming>` |

## Performance rules

|  | Value |
|--|-------|
| **Link to rules** | [Performance rules](quality-rules/performance-warnings.md)  |
| **Description** | Performance rules support high-performance libraries and applications. |
| **EditorConfig value** | `dotnet_analyzer_diagnostic.category-Performance.severity` |
| [**MSBuild property value**](../../core/project-sdk/msbuild-props.md#analysismodecategory) | `<AnalysisModePerformance>` |

## SingleFile rules

|  | Value |
|--|-------|
| **Link to rules** | [SingleFile rules](../../core/deploying/single-file/warnings/overview.md) |
| **Description** | Single-file rules support single-file applications. |
| **EditorConfig value** | `dotnet_analyzer_diagnostic.category-SingleFile.severity` |
| [**MSBuild property value**](../../core/project-sdk/msbuild-props.md#analysismodecategory) | `<AnalysisModeSingleFile>` |

## Reliability rules

|  | Value |
|--|-------|
| **Link to rules** | [Reliability rules](quality-rules/reliability-warnings.md) |
| **Description** | Reliability rules support library and application reliability, such as correct memory and thread usage. |
| **EditorConfig value** | `dotnet_analyzer_diagnostic.category-Reliability.severity` |
| [**MSBuild property value**](../../core/project-sdk/msbuild-props.md#analysismodecategory) | `<AnalysisModeReliability>` |

## Security rules

|  | Value |
|--|-------|
| **Link to rules** | [Security rules](quality-rules/security-warnings.md) |
| **Description** | Security rules support safer libraries and applications. These rules help prevent security flaws in your program. |
| **EditorConfig value** | `dotnet_analyzer_diagnostic.category-Security.severity` |
| [**MSBuild property value**](../../core/project-sdk/msbuild-props.md#analysismodecategory) | `<AnalysisModeSecurity>` |

## Style rules

|  | Value |
|--|-------|
| **Link to rules** | [Style rules](style-rules/index.md) |
| **Description** | Style rules support consistent code style in your codebase. These rules start with the "IDE" prefix.<sup>*</sup> |
| **EditorConfig value** | `dotnet_analyzer_diagnostic.category-Style.severity` |
| [**MSBuild property value**](../../core/project-sdk/msbuild-props.md#analysismodecategory) | `<AnalysisModeStyle>` |

\* Use the EditorConfig value `dotnet_analyzer_diagnostic.category-CodeQuality.severity` to enable the following rules: [IDE0051](style-rules/ide0051.md), [IDE0064](style-rules/ide0064.md), and [IDE0076](style-rules/ide0076.md). While these rules start with "IDE", they aren't technically part of the `Style` category.

## Usage rules

|  | Value |
|--|-------|
| **Link to rules** | [Usage rules](quality-rules/usage-warnings.md) |
| **Description** | Usage rules support proper usage of .NET. |
| **EditorConfig value** | `dotnet_analyzer_diagnostic.category-Usage.severity` |
| [**MSBuild property value**](../../core/project-sdk/msbuild-props.md#analysismodecategory) | `<AnalysisModeUsage>` |
