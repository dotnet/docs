---
title: Configure code analysis rules
description: Learn how to configure code analysis rules in an EditorConfig file and how to suppress rule violations.
ms.date: 08/22/2020
ms.topic: conceptual
no-loc: ["EditorConfig"]
---
# Configure code analysis rules

You configure the severity of .NET code analysis rules by using an [EditorConfig file](https://docs.microsoft.com/visualstudio/ide/create-portable-custom-editor-options). Add an entry for each rule you want to configure under the corresponding file extension, for example, `*.cs`. The syntax for the *.editorconfig* file is as follows:

```ini
dotnet_diagnostic.<rule ID>.severity = <severity>
```

The following example demonstrates setting the severity for rule `CA1822` to `error` for C# and Visual Basic files.

```ini
[*.{cs,vb}]
dotnet_diagnostic.CA1822.severity = error
```

## Rule severities

The following table shows the different rule severities.

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

## Configure multiple rules

You can set the severity for a specific category of analyzer rules or for all analyzer rules with a single entry in an EditorConfig file.

- Set rule severity for a category of analyzer rules:

  ```ini
  dotnet_analyzer_diagnostic.category-<rule category>.severity = <severity>
  ```

- Set rule severity for all analyzer rules:

  ```ini
  dotnet_analyzer_diagnostic.severity = <severity>
  ```

## Precedence

If you have multiple entries that are applicable to the same rule ID, precedence is chosen in the following order:

- Severity entry for an individual rule by ID takes precedence over severity entry for a category.
- Severity entry for a category takes precedence over severity entry for all analyzer rules.

Consider the following EditorConfig example, where [CA1822](https://docs.microsoft.com/visualstudio/code-quality/ca1822) has the category "Performance":

```ini
[*.cs]
dotnet_diagnostic.CA1822.severity = error
dotnet_analyzer_diagnostic.category-performance.severity = warning
dotnet_analyzer_diagnostic.severity = suggestion
```

In the preceding example, all three entries are applicable to CA1822. However, using the specified precedence rules, the first rule ID-based severity entry wins over the next entries. In this example, CA1822 will have an effective severity of `error`. All other rules within the "Performance" category will have a severity of `warning`.

## Suppress violations

To suppress a rule violation in an EditorConfig file, set the severity to `none`. For example:

```ini
dotnet_diagnostic.CA1822.severity = none
```

Visual Studio provides additional ways to suppress rule violations. For more information, see [Suppress violations](/visualstudio/code-quality/use-roslyn-analyzers#suppress-violations).

## Exclude generated code

.NET code analyzer warnings aren't useful on generated code files, such as designer-generated files, which users can't edit to fix any violations. In most cases, code analyzers skip generated code files and don't report violations on these files.

By default, files with certain file extensions or auto-generated file headers are treated as generated code files. For example, a file name ending with `.designer.cs` or `.generated.cs` is considered generated code. You can configure additional files and folders to be treated as generated code in an [EditorConfig file](https://editorconfig.org/) by adding a `generated_code = true | false` entry. For example, to treat all files whose name ends with `.MyGenerated.cs` as generated code, the entry is as follows:

```ini
[*.MyGenerated.cs]
generated_code = true
```
