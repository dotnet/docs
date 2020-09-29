---
title: Configure code analysis rules
description: Learn how to configure code analysis rules in an EditorConfig file.
ms.date: 09/24/2020
ms.topic: conceptual
no-loc: ["EditorConfig"]
---
# Configuration options for code analysis

Code analysis rules have various configuration options. These options are specified as key-value pairs in a configuration file. For example,

```ini
<option key> = <option value>
```

The most common option you'll configure is a rule's severity. You can configure severity level for all analyzer rules, including [code quality rules](quality-rules/index.md) and [code style rules](style-rules/index.md).

You can also configure additional options to customize rule behavior:

- Code quality rules have [additional options](code-quality-rule-options.md) to configure behavior, such as which method names a rule should apply to.
- Code style rules have [custom code style options](code-style-rule-options.md).
- Third party analyzer rules can define their own configuration options, with custom key names and value formats.

You specify configuration options in an [EditorConfig file](/visualstudio/ide/create-portable-custom-editor-options). You can apply EditorConfig file conventions to a folder, a project, or an entire repo by placing the file in the corresponding directory. If you have an existing *.editorconfig* file for editor settings such as indent size or whether to trim trailing whitespace, you can place your code analysis configuration options in the same file. Add an entry for each rule you want to configure, and place it under the corresponding file extension section, for example, `[*.cs]`.

The syntax for configuring a specific rule's severity in an *.editorconfig* file is as follows:

```ini
dotnet_diagnostic.<rule ID>.severity = <severity>
```

The following example demonstrates setting the severity for rule `CA1822` to `error` for C# and Visual Basic files.

```ini
[*.{cs,vb}]
dotnet_diagnostic.CA1822.severity = error
```

> [!TIP]
> Visual Studio provides an *.editorconfig* item template that makes is easy to add one of these files to your project. For more information, see [Add an EditorConfig file to a project](/visualstudio/ide/create-portable-custom-editor-options#add-an-editorconfig-file-to-a-project).

## General options

These options apply to code analysis as a whole. They cannot be applied only to a single rule or set of rules.

### Exclude generated code

You can configure additional files and folders to be treated as generated code by adding a `generated_code = true | false` entry to your *.editorconfig* file. .NET code analyzer warnings aren't useful on generated code files, such as designer-generated files, which users can't edit to fix any violations. In most cases, code analyzers skip generated code files and don't report violations on these files.

By default, files with certain file extensions or auto-generated file headers are treated as generated code files. For example, a file name ending with `.designer.cs` or `.generated.cs` is considered generated code. This configuration option lets you specify additional naming patterns.

For example, to treat all files whose name ends with `.MyGenerated.cs` as generated code, add the following entry:

```ini
[*.MyGenerated.cs]
generated_code = true
```

## Rule-specific options

Rule-specific options can be applied to a single rule, a set of rules, or all rules. The rule-specific options include:

- [Rule severity level](#severity-level)
- [Options specific to *code-quality* rules](code-quality-rule-options.md)

### Severity level

The following table shows the different rule severities that you can configure for all analyzer rules, including [code quality](quality-rules/index.md) and [code style](style-rules/index.md) rules.

| Severity | Build-time behavior |
|-|-|
| `error` | Violations appear as build *errors* and cause builds to fail.|
| `warning` | Violations appear as build *warnings* but do not cause builds to fail (unless you have an option set to treat warnings as errors). |
| `suggestion` | Violations appear as build *messages* and as suggestions in the Visual Studio IDE. |
| `silent` | Violations aren't visible to the user. |
| `none` | Rule is suppressed completely. |
| `default` | The default severity of the rule is used. |

> [!TIP]
> For information about how rule severities surface in Visual Studio, see [Severity levels](/visualstudio/ide/editorconfig-language-conventions#severity-levels).

#### Scope

To set the rule severity for a single rule, use the following syntax.

```ini
dotnet_diagnostic.<rule ID>.severity = <severity value>
```

To set the default rule severity for a category of analyzer rules, use the following syntax.

```ini
dotnet_analyzer_diagnostic.category-<rule category>.severity = <severity value>
```

To set the default rule severity for all analyzer rules, use the following syntax.

```ini
dotnet_analyzer_diagnostic.severity = <severity value>
```

#### Precedence

If you have multiple entries that can be applied to the same rule ID, precedence is chosen in the following order:

- An entry for an individual rule by ID takes precedence over an entry for a category.
- An entry for a category takes precedence over an entry for all analyzer rules.

Consider the following EditorConfig example, where [CA1822](/visualstudio/code-quality/ca1822) has the category "Performance":

```ini
[*.cs]
dotnet_diagnostic.CA1822.severity = error
dotnet_analyzer_diagnostic.category-performance.severity = warning
dotnet_analyzer_diagnostic.severity = suggestion
```

In the preceding example, all three severity entries are applicable to CA1822. However, using the specified precedence rules, the first rule ID-based entry wins over the next entries. In this example, CA1822 will have an effective severity of `error`. All other rules within the "Performance" category will have a severity of `warning`.
