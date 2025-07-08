---
description: "C# Compiler Options for errors and warnings. These options suppress or enable warnings, and control warnings as errors."
title: "Compiler Options - errors and warnings"
ms.date: 05/30/2025
f1_keywords: 
  - "cs.build.options"
helpviewer_keywords: 
  - "WarningLevel compiler option [C#]"
  - "TreatWarningsAsErrors compiler option [C#]"
  - "WarningsAsErrors compiler option [C#]"
  - "WarningsNotAsErrors compiler option [C#]"
  - "NoWarn compiler option [C#]"
  - "CodeAnalysisRuleSet compiler option [C#]"
  - "ErrorLog compiler option [C#]"
  - "ReportAnalyzer compiler option [C#]"
---
# C# Compiler Options to report errors and warnings

The following options control how the compiler reports errors and warnings.

| MSBuild syntax          | _csc.exe_ syntax  | Description                                                                                       |
| ----------------------- | ----------------- | ------------------------------------------------------------------------------------------------- |
| `WarningLevel`          | `-warn`           | Set warning level. [More info.](#warninglevel)                                                    |
| `AnalysisLevel`         | /                 | Set optional warning level. [More info.](#analysis-level)                                         |
| `TreatWarningsAsErrors` | `-warnaserror`    | Treat all warnings as errors. [More info.](#treatwarningsaserrors)                                |
| `WarningsAsErrors`      | `-warnaserror+`   | Treat one or more warnings as errors. [More info.](#warningsaserrors-and-warningsnotaserrors)     |
| `WarningsNotAsErrors`   | `-warnaserror-`   | Treat one or more warnings not as errors. [More info.](#warningsaserrors-and-warningsnotaserrors) |
| `NoWarn`                | `-nowarn`         | Set a list of disabled warnings. [More info.](#nowarn)                                            |
| `CodeAnalysisRuleSet`   | `-ruleset`        | Specify a ruleset file that disables specific diagnostics. [More info.](#codeanalysisruleset)     |
| `ErrorLog`              | `-errorlog`       | Specify a file to log all compiler and analyzer diagnostics. [More info.](#errorlog)              |
| `ReportAnalyzer`        | `-reportanalyzer` | Report extra analyzer information, such as execution time. [More info.](#reportanalyzer)     |

> [!NOTE]
> For more information about configuring these options for your project, see the [Compiler options](index.md#how-to-set-options). For more information on the available switches, see the [MSBuild command line switches](/visualstudio/msbuild/msbuild-command-line-reference#switches) article in the Visual Studio documentation.

## WarningLevel

The **WarningLevel** option specifies the warning level for the compiler to display.

```xml
<WarningLevel>3</WarningLevel>
```

The element value is the warning level you want displayed for the compilation: Lower numbers show only high severity warnings. Higher numbers show more warnings. The value must be zero or a positive integer:

| Warning level | Meaning |
|---------------|---------|
| 0 | Turns off emission of all warning messages. |
| 1 | Displays severe warning messages. |
| 2 | Displays level 1 warnings plus certain, less-severe warnings, such as warnings about hiding class members. |
| 3 | Displays level 2 warnings plus certain, less-severe warnings, such as warnings about expressions that always evaluate to `true` or `false`. |
| 4 (default) | Displays all level 3 warnings plus informational warnings. |

> [!WARNING]
> The compiler command line accepts values greater than 4 to enable [warning wave warnings](../compiler-messages/warning-waves.md).

To get information about an error or warning, you can look up the error code in the [Help Index](/visualstudio/help-viewer/install-manage-local-content). For other ways to get information about an error or warning, see [C# Compiler Errors](../compiler-messages/index.md). Use [**TreatWarningsAsErrors**](#treatwarningsaserrors) to treat all warnings as errors. Use [**DisabledWarnings**](#nowarn) to disable certain warnings.  

## Analysis level

The **AnalysisLevel** option specifies higher [warning waves](../compiler-messages/warning-waves.md) and analyzers to enable in .NET 7 and later projects. Warning wave warnings are extra checks that improve your code, or ensure it remains compatible with upcoming releases. Analyzers provide lint-like capability to improve your code.

Beginning with the .NET 7 SDK, **AnalysisLevel** and **WarningLevel** are set based on these rules:

- The default **AnalysisLevel** matches the Target Framework Moniker (TFM) from the project file.
- The default **WarningLevel** matches the value for **AnalysisLevel**.
- The default **WarningLevel** is 4 for .NET Framework projects.

Before the .NET 7 SDK, the **AnalysisLevel** overwrote the **WarningLevel**.

```xml
<AnalysisLevel>preview</AnalysisLevel>
```

| Analysis level   | Meaning |
|------------------|---------|
| 5                | Displays all optional [warning wave 5 warnings](../compiler-messages/warning-waves.md#cs7023---a-static-type-is-used-in-an-is-or-as-expression). |
| 6                | Displays all optional [warning wave 6 warnings](../compiler-messages/warning-waves.md#cs8826---partial-method-declarations-have-signature-differences). |
| 7                | Displays all optional [warning wave 7 warnings](../compiler-messages/warning-waves.md#cs8981---the-type-name-only-contains-lower-cased-ascii-characters). |
| latest (default) | Displays all informational warnings up to and including the current release. |
| preview          | Displays all informational warnings up to and including the latest preview release. |
| none             | Turns off all informational warnings. |

For more information on optional warnings, see [Warning waves](../compiler-messages/warning-waves.md).

To get information about an error or warning, you can look up the error code in the Help Index. For other ways to get information about an error or warning, see [C# Compiler Errors](../compiler-messages/index.md). Use [**TreatWarningsAsErrors**](#treatwarningsaserrors) to treat all warnings as errors. Use [**NoWarn**](#nowarn) to disable certain warnings.  

## TreatWarningsAsErrors

The **TreatWarningsAsErrors** option treats all warnings as errors. You can also use the **WarningsAsErrors** to set only some warnings as errors. If you turn on **TreatWarningsAsErrors**, you can use **WarningsNotAsErrors** to list warnings that shouldn't be treated as errors.

```xml
<TreatWarningsAsErrors>true</TreatWarningsAsErrors>
```

All warning messages are instead reported as errors. The build process halts (no output files are built). By default, **TreatWarningsAsErrors** isn't in effect, which means warnings don't prevent the generation of an output file. Optionally, if you want only a few specific warnings to be treated as errors, you can specify a comma-separated list of warning numbers to treat as errors. The set of all nullability warnings can be specified with the [**Nullable**](language.md#nullable) shorthand. Use [**WarningLevel**](#warninglevel) to specify the level of warnings that you want the compiler to display. Use [**NoWarn**](#nowarn) to disable certain warnings.

> [!IMPORTANT]
> There are two subtle differences between using the `<TreatWarningsAsErrors>` element in your *csproj* file, and using the `warnaserror` MSBuild command line switch. *TreatWarningsAsErrors* only impacts the C# compiler, not any other MSBuild tasks in your *csproj* file. The `warnaserror` command line switch impacts all tasks. Secondly, the compiler doesn't produce any output on any warnings when *TreatWarningsAsErrors* is used. The compiler produces output when the `warnaserror` command line switch is used.

## WarningsAsErrors and WarningsNotAsErrors

The **WarningsAsErrors** and **WarningsNotAsErrors** options override the **TreatWarningsAsErrors** option for a list of warnings. This option can be used with all *CS* warnings. The "CS" prefix is optional. You can use either the number, or "CS" followed by the error or warning number. For other elements that affect warnings, see the [Common MSBuild properties](/visualstudio/msbuild/common-msbuild-project-properties). In addition to the list of warning IDs, you can also specify the string `nullable`, which treats all warnings related to nullability as errors.

Enable warnings 0219, 0168, and all nullable warnings as errors:

```xml
<WarningsAsErrors>0219;CS0168;nullable</WarningsAsErrors>
```

Disable the same warnings as errors:

```xml
<WarningsNotAsErrors>0219;CS0168;nullable</WarningsNotAsErrors>
```

You use **WarningsAsErrors** to configure a set of warnings as errors. Use **WarningsNotAsErrors** to configure a set of warnings that shouldn't be errors when you set all warnings as errors.

## NoWarn

The **NoWarn** option lets you suppress the compiler from displaying one or more warnings, where `warningnumber1`, `warningnumber2` are warning numbers that you want the compiler to suppress. Separate multiple warning numbers with a comma. You can specify `nullable` to disable all warnings related to nullability.

```xml
<NoWarn>warningnumber1,warningnumber2</NoWarn>
```

You need to specify only the numeric part of the warning identifier. For example, if you want to suppress *CS0028*, you could specify `<NoWarn>28</NoWarn>`. The compiler silently ignores warning numbers passed to **NoWarn** that were valid in previous releases, but aren't generated by the current compiler. For example, *CS0679* was valid in the compiler in Visual Studio .NET 2002 but was removed later.

The following warnings can't be suppressed by the **NoWarn** option:

- Compiler Warning (level 1) CS2002  
- Compiler Warning (level 1) CS2023
- Compiler Warning (level 1) CS2029

Warnings are intended to be an indication of a potential problem with your code, so you should understand the risks of disabling any particular warning. Use **NoWarn** only when you're certain that a warning is a false positive and can't possibly be a runtime bug.

You might want to use a more targeted approach to disabling warnings:

- Most compilers provide ways to disable warnings just for certain lines of code, so that you can still review the warnings if they occur elsewhere in the same project. To suppress a warning only in a specific part of the code in C#, use [#pragma warning](../preprocessor-directives.md#pragma-warning).
- If your goal is to see more concise and focused output in your build log, you might want to change the build log verbosity. For more information, see [How to: View, save, and configure build log files](/visualstudio/ide/how-to-view-save-and-configure-build-log-files).

To add warning numbers to any previously set value for **NoWarn** without overwriting it, reference `$(NoWarn)` as shown in the following example:

```xml
   <NoWarn>$(NoWarn);newwarningnumber3;newwarningnumber4</NoWarn>
```

## CodeAnalysisRuleSet

Specify a ruleset file that configures specific diagnostics.

```xml
<CodeAnalysisRuleSet>MyConfiguration.ruleset</CodeAnalysisRuleSet>
```

Where `MyConfiguration.ruleset` is the path to the ruleset file. For more information on using rule sets, see the article in the [Visual Studio documentation on Rule sets](/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules).

## ErrorLog

Specify a file to log all compiler and analyzer diagnostics.

```xml
<ErrorLog>compiler-diagnostics.sarif</ErrorLog>
```

The **ErrorLog** option causes the compiler to output a [Static Analysis Results Interchange Format (SARIF) log](https://github.com/microsoft/sarif-tutorials/blob/main/docs/1-Introduction.md#:~:text=What%20is%20SARIF%3F,for%20use%20by%20simpler%20tools). Tools that analyze compiler and analyzer results read SARIF logs.

You can specify the SARIF format using the `version` argument to the `ErrorLog` element:

```XML
<ErrorLog>logVersion21.json,version=2.1</ErrorLog>
```

The separator can be either a comma (`,`) or a semicolon (`;`). Valid values for version are:  "1", "2", and "2.1". The default is "1". "2" and "2.1" both mean SARIF version 2.1.0.

## ReportAnalyzer

Report extra analyzer information, such as execution time.

```xml
<ReportAnalyzer>true</ReportAnalyzer>
```

The **ReportAnalyzer** option causes the compiler to emit extra MSBuild log information that details the performance characteristics of analyzers in the build. It's typically used by analyzer authors as part of validating the analyzer.

> [!IMPORTANT]
> The extra log information generated by this flag is only generated when the `-verbosity:detailed` command line option is used. For more information, see the [switches](/visualstudio/msbuild/msbuild-command-line-reference#switches) article in the MSBuild documentation.
