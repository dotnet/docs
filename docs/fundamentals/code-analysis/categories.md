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

| Category | Description | EditorConfig value |
| - | - | - |
| [Design rules](quality-rules/design-warnings.md) | Design rules support adherence to the [.NET Framework Design Guidelines](../../standard/design-guidelines/index.md). | `dotnet_analyzer_diagnostic.category-Design.severity` |
| [Documentation rules](quality-rules/documentation-warnings.md) | Documentation rules support writing well-documented libraries through the correct use of XML documentation comments for externally visible APIs. | `dotnet_analyzer_diagnostic.category-Documentation.severity` |
| [Globalization rules](quality-rules/globalization-warnings.md) | Globalization rules support world-ready libraries and applications. | `dotnet_analyzer_diagnostic.category-Globalization.severity` |
| [Portability and interoperability rules](quality-rules/interoperability-warnings.md) | Portability rules support portability across different platforms. Interoperability rules support interaction with COM clients. | `dotnet_analyzer_diagnostic.category-Interoperability.severity` |
| [Maintainability rules](quality-rules/maintainability-warnings.md) | Maintainability rules support library and application maintenance. | `dotnet_analyzer_diagnostic.category-Maintainability.severity` |
| [Naming rules](quality-rules/naming-warnings.md) | Naming rules support adherence to the naming conventions of the .NET design guidelines. | `dotnet_analyzer_diagnostic.category-Naming.severity` |
| [Performance rules](quality-rules/performance-warnings.md) | Performance rules support high-performance libraries and applications. | `dotnet_analyzer_diagnostic.category-Performance.severity` |
| [SingleFile rules](quality-rules/singlefile-warnings.md) | Single-file rules support single-file applications. | `dotnet_analyzer_diagnostic.category-SingleFile.severity` |
| [Reliability rules](quality-rules/reliability-warnings.md) | Reliability rules support library and application reliability, such as correct memory and thread usage. | `dotnet_analyzer_diagnostic.category-Reliability.severity` |
| [Security rules](quality-rules/security-warnings.md) | Security rules support safer libraries and applications. These rules help prevent security flaws in your program. | `dotnet_analyzer_diagnostic.category-Security.severity` |
| [Style rules](style-rules/index.md) | Style rules support consistent code style in your codebase. These rules start with the "IDE" prefix. | `dotnet_analyzer_diagnostic.category-Style.severity` |
| [Usage rules](quality-rules/usage-warnings.md) | Usage rules support proper usage of .NET. | `dotnet_analyzer_diagnostic.category-Usage.severity` |
| N/A | You can use this EditorConfig value to enable the following rules: [IDE0051](style-rules/ide0051.md), [IDE0064](style-rules/ide0064.md), [IDE0076](style-rules/ide0076.md). While these rules start with "IDE", they are not technically part of the `Style` category. | `dotnet_analyzer_diagnostic.category-CodeQuality.severity` |
