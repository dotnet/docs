---
title: Configure code analysis rules
description: Learn how to configure code analysis rules in an analyzer configuration file.
ms.date: 12/06/2021
no-loc: ["EditorConfig"]
---
# Configuration options for code analysis

Code analysis rules have various configuration options. Some of these options are specified as key-value pairs in an [analyzer configuration file](configuration-files.md) using the syntax `<option key> = <option value>`. Other options, which configure code analysis as a whole, are available as MSBuild properties in your project file.

The most common option you'll configure is a [rule's severity](#severity-level). You can configure the severity level for any rule, including [code quality rules](quality-rules/index.md) and [code style rules](style-rules/index.md). For example, to enable a rule as a warning, add the following key-value pair to an [analyzer configuration file](configuration-files.md):

`dotnet_diagnostic.<rule ID>.severity = warning`

You can also configure additional options to customize rule behavior:

- Code quality rules have [behavior options](code-quality-rule-options.md), such as which method names a rule should apply to.
- Code style rules have [style-preference options](code-style-rule-options.md), such as where new lines are desirable.
- Third-party analyzer rules can define their own configuration options, with custom key names and value formats.

## General options

These options apply to code analysis as a whole. They cannot be applied only to a specific rule.

- [Analysis mode](#analysis-mode)
- [Enable code analysis](#enable-code-analysis)
- [Exclude generated code](#exclude-generated-code)

For additional options, see [Code analysis properties](../../core/project-sdk/msbuild-props.md#code-analysis-properties).

### Analysis mode

While the .NET SDK includes all code analysis rules, only some of them are [enabled by default](https://github.com/dotnet/roslyn-analyzers/blob/main/src/NetAnalyzers/Core/AnalyzerReleases.Shipped.md). The *analysis mode* determines which, if any, set of rules to enable. You can choose a more aggressive analysis mode where most or all rules are enabled. Or you can choose a more conservative analysis mode where most or all rules are disabled, and you can then opt-in to specific rules as needed. Set your analysis mode by adding the [\<AnalysisMode>](../../core/project-sdk/msbuild-props.md#analysismode) MSBuild property to your project file.

```xml
<PropertyGroup>
  <AnalysisMode>Recommended</AnalysisMode>
</PropertyGroup>
```

Starting in .NET 6, you can also bulk enable a category of rules using the [\<AnalysisMode\<Category>>](../../core/project-sdk/msbuild-props.md#analysismodecategory) MSBuild property.

> [!NOTE]
> If you configure code analysis using MSBuild properties like `AnalysisMode`, any *bulk* configuration options you set in your [configuration file](configuration-files.md) are ignored. For example, if you've bulk-enabled [all rules or a category of rules](#scope) in an *.editorconfig* file, that configuration is ignored.

### Enable code analysis

Code analysis is enabled by default for projects that target .NET 5 and later versions. If you have the .NET 5+ SDK but your project targets a different .NET implementation, you can manually enable code analysis by setting the [EnableNETAnalyzers](../../core/project-sdk/msbuild-props.md#enablenetanalyzers) property in your project file to `true`.

```xml
<PropertyGroup>
  <EnableNETAnalyzers>true</EnableNETAnalyzers>
</PropertyGroup>
```

### Exclude generated code

.NET code analyzer warnings aren't useful on generated code files, such as designer-generated files, which users can't edit to fix any violations. In most cases, code analyzers skip generated code files and don't report violations on these files.

By default, files with certain file extensions or auto-generated file headers are treated as generated code files. For example, a file name ending with `.designer.cs` or `.generated.cs` is considered generated code. This configuration option lets you specify additional naming patterns to be treated as generated code. You configure additional files and folders by adding a `generated_code = true | false` entry to your [configuration file](configuration-files.md). For example, to treat all files whose name ends with `.MyGenerated.cs` as generated code, add the following entry:

```ini
[*.MyGenerated.cs]
generated_code = true
```

> [!NOTE]
> Generated code files are excluded only from code analysis diagnostics. Other diagnostics, such as those from the C# compiler, aren't affected by this setting.

## Rule-specific options

Rule-specific options can be applied to a single rule, a set of rules, or all rules. The rule-specific options include:

- [Rule severity level](#severity-level)
- [Options specific to *code-quality* rules](code-quality-rule-options.md)

### Severity level

The following table shows the different rule severities that you can configure for all analyzer rules, including [code quality](quality-rules/index.md) and [code style](style-rules/index.md) rules.

| Severity configuration value | Build-time behavior |
|-|-|
| `error` | Violations appear as build *errors* and cause builds to fail.|
| `warning` | Violations appear as build *warnings* but do not cause builds to fail (unless you have an option set to treat warnings as errors). |
| `suggestion` | Violations appear as build *messages* and as suggestions in the Visual Studio IDE. (In Visual Studio, suggestions appear as three gray dots under the first two characters.) |
| `silent` | Violations aren't visible to the user.<br/><br/>However, for code-style rules, Visual Studio code-generation features still generate code in this style. These rules also participate in cleanup and appear in the **Quick Actions and Refactorings** menu in Visual Studio. |
| `none` | Rule is suppressed completely.<br/><br/>However, for code-style rules, Visual Studio code-generation features still generate code in this style. |
| `default` | The default severity of the rule is used. The default severities for each .NET release are listed in the [roslyn-analyzers repo](https://github.com/dotnet/roslyn-analyzers/blob/main/src/NetAnalyzers/Core/AnalyzerReleases.Shipped.md). In that table, "Disabled" corresponds to `none`, "Hidden" corresponds to `silent`, and "Info" corresponds to `suggestion`. |

#### Scope

- **Single rule**

  To set the rule severity for a single rule, use the following syntax.

  ```ini
  dotnet_diagnostic.<rule ID>.severity = <severity value>
  ```

- **Category of rules**

  To set the default rule severity for a category of rules, use the following syntax. However, this severity setting only affects rules in that category that are enabled by default.

  ```ini
  dotnet_analyzer_diagnostic.category-<rule category>.severity = <severity value>
  ```

  The different categories are listed and described at [Rule categories](categories.md). In addition, you can find the category for a specific rule on its reference page, for example, [CA1000](quality-rules/ca1000.md).

- **All rules**

  To set the default rule severity for all analyzer rules, use the following syntax. However, this severity setting only affects rules that are enabled by default.

  ```ini
  dotnet_analyzer_diagnostic.severity = <severity value>
  ```

> [!IMPORTANT]
> When you configure the severity level for multiple rules with a single entry, either for a *category* of rules or for *all* rules, the severity only applies to rules that are [enabled by default](https://github.com/dotnet/roslyn-analyzers/blob/main/src/NetAnalyzers/Core/AnalyzerReleases.Shipped.md). And if you enable all rules by using the MSBuild properties [\<AnalysisMode>](../../core/project-sdk/msbuild-props.md#analysismode) or [\<AnalysisLevel>](../../core/project-sdk/msbuild-props.md#analysislevel), any bulk `dotnet_analyzer_diagnostic` options are ignored. For this reason, it's better to enable a category of rules by setting [\<AnalysisMode\<Category>>](../../core/project-sdk/msbuild-props.md#analysismodecategory) to `All`.

> [!NOTE]
> The prefix for setting severity for a single rule, `dotnet_diagnostic`, is slightly different than the prefix for configuring severity via category or for all rules, `dotnet_analyzer_diagnostic`.

#### Precedence

If you have multiple severity configuration entries that can be applied to the same rule ID, precedence is chosen in the following order:

- An entry for a category takes precedence over an entry for all analyzer rules.
- An entry for an individual rule by ID takes precedence over an entry for a category.

Consider the following example, where [CA1822](/visualstudio/code-quality/ca1822) has the category "Performance":

```ini
[*.cs]
dotnet_diagnostic.CA1822.severity = error
dotnet_analyzer_diagnostic.category-performance.severity = warning
dotnet_analyzer_diagnostic.severity = suggestion
```

In the preceding example, all three severity entries are applicable to CA1822. However, using the specified precedence rules, the first rule ID-based entry wins over the next entries. In this example, CA1822 will have an effective severity of `error`. All other rules within the "Performance" category will have a severity of `warning`.

For information about how inter-file precedence is decided, see the [Precedence section of the Configuration files article](configuration-files.md#precedence).
