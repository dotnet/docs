---
title: Predefined configuration files (code analysis)
description: Learn about using predefined editorconfig and rule set files to target specific types of code analysis.
ms.date: 09/24/2020
ms.topic: conceptual
---
# Predefined configuration files

Predefined EditorConfig and [rule set](/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules) files are available that make it quick and easy to enable a category of code quality rules, such as security or design rules. By enabling a specific category of rules, you can identify targeted issues and specific conditions. To access these predefined files, install the [Microsoft.CodeAnalysis.NetAnalyzers](https://github.com/dotnet/roslyn-analyzers#microsoftcodeanalysisnetanalyzers) NuGet analyzer package.

[Microsoft.CodeAnalysis.NetAnalyzers](https://github.com/dotnet/roslyn-analyzers#microsoftcodeanalysisnetanalyzers) includes predefined EditorConfig files and rule sets for the following rule categories:

- All rules
- Dataflow
- Design
- Documentation
- Globalization
- Interoperability
- Maintainability
- Naming
- Performance
- Ported from FxCop
- Reliability
- Security
- Usage

Each of those categories of rules has an EditorConfig or rule set file to:

- Enable all the rules in the category (and disable all other rules)
- Use each rule's default severity and enabled by default setting (and disable all other rules)

> [!TIP]
> The "all rules" category has an additional EditorConfig or rule set file to disable all rules. Use this file to quickly get rid of any analyzer warnings or errors in a project.

## Predefined EditorConfig files

The predefined EditorConfig files for the Microsoft.CodeAnalysis.NetAnalyzers analyzer package are located in the *editorconfig* subdirectory of where the NuGet package was installed. For example, the EditorConfig file to enable all security rules is located at *editorconfig/SecurityRulesEnabled/.editorconfig*.

Copy the chosen *.editorconfig* file to your project's root directory.

## Predefined rule sets

The predefined rule set files for the Microsoft.CodeAnalysis.NetAnalyzers analyzer package are located in the *rulesets* subdirectory of where the NuGet package was installed. For example, the rule set file to enable all security rules is located at *rulesets/SecurityRulesEnabled.ruleset*. Copy one or more of the rule sets and paste them in the directory that contains your project.

## See also

- [Analyzer configuration](https://github.com/dotnet/roslyn-analyzers/blob/main/docs/Analyzer%20Configuration.md)
- [.NET code style rule options for EditorConfig](code-style-rule-options.md)
