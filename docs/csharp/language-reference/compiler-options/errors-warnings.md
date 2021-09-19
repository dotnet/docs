---
description: "C# Compiler Options for errors and warnings. These options suppress or enable warnings, and control warnings as errors."
title: "C# Compiler Options - errors and warnings"
ms.date: 03/12/2021
f1_keywords: 
  - "cs.build.options"
helpviewer_keywords: 
  - "WarningLevel compiler option [C#]"
  - "TreatWarningsAsErrors compiler option [C#]"
  - "WarningsAsErrors compiler option [C#]"
  - "WarningsNotAsErrors compiler option [C#]"
  - "DisabledWarnings compiler option [C#]"
  - "CodeAnalysisRuleSet compiler option [C#]"
  - "ErrorLog compiler option [C#]"
  - "ReportAnalyzer compiler option [C#]"
---
# C# Compiler Options to report errors and warnings

The following options control how the compiler reports errors and warnings. The new MSBuild syntax is shown in **Bold**. The older *csc.exe* syntax is shown in `code style`.

- **WarningLevel** / `-warn`: Set warning level.
- **TreatWarningsAsErrors** / `-warnaserror`: Treat all warnings as errors
- **WarningsAsErrors** / `-warnaserror`: Treat one or more warnings as errors
- **WarningsNotAsErrors** / `-warnnotaserror`: Treat one or more warnings not as errors
- **DisabledWarnings** / `-nowarn`: Set a list of disabled warnings.
- **CodeAnalysisRuleSet** / `-ruleset`: Specify a ruleset file that disables specific diagnostics.
- **ErrorLog** / `-errorlog`: Specify a file to log all compiler and analyzer diagnostics.
- **ReportAnalyzer** / `-reportanalyzer`:  Report additional analyzer information, such as execution time.

## WarningLevel

The **WarningLevel** option specifies the warning level for the compiler to display.

```xml
<WarningLevel>3</WarningLevel>
```

The element value is the warning level you want displayed for the compilation: Lower numbers show only high severity warnings. Higher numbers show more warnings. The value must be zero or a positive integer:

|Warning level|Meaning|
|-------------------|-------------|
|0|Turns off emission of all warning messages.|
|1|Displays severe warning messages.|  
|2|Displays level 1 warnings plus certain, less-severe warnings, such as warnings about hiding class members.|
|3|Displays level 2 warnings plus certain, less-severe warnings, such as warnings about expressions that always evaluate to `true` or `false`.|
|4 (the default)|Displays all level 3 warnings plus informational warnings.|
|5|Displays level 4 warnings plus [additional warnings](https://github.com/dotnet/roslyn/blob/a6013f3213c902c0973b2d371c3007217d610533/docs/compilers/CSharp/Warnversion%20Warning%20Waves.md) from the compiler shipped with C# 9.0.|
|Greater than 5|Any value greater than 5 will be treated as 5. To make sure you always have all warnings if the compiler is updated with new warning levels, put an arbitrary large value (for example, `9999`).

To get information about an error or warning, you can look up the error code in the Help Index. For other ways to get information about an error or warning, see [C# Compiler Errors](../compiler-messages/index.md). Use [**TreatWarningsAsErrors**](#treatwarningsaserrors) to treat all warnings as errors. Use [**DisabledWarnings**](#disabledwarnings) to disable certain warnings.  

## TreatWarningsAsErrors

The **TreatWarningsAsErrors** option treats all warnings as errors. You can also use the **TreatWarningsAsErrors** to set only some warnings as errors. If you turn on **TreatWarningsAsErrors**, you can use **TreatWarningsAsErrors** to list warnings that shouldn't be treated as errors.

```xml
<TreatWarningsAsErrors>true</TreatWarningsAsErrors>
```

All warning messages are instead reported as errors. The build process halts (no output files are built). By default, **TreatWarningsAsErrors** isn't in effect, which means warnings don't prevent the generation of an output file. Optionally, if you want only a few specific warnings to be treated as errors, you may specify a comma-separated list of warning numbers to treat as errors. The set of all nullability warnings can be specified with the [**Nullable**](language.md#nullable) shorthand. Use [**WarningLevel**](#warninglevel) to specify the level of warnings that you want the compiler to display. Use [**DisabledWarnings**](#disabledwarnings) to disable certain warnings.

## WarningsAsErrors and WarningsNotAsErrors

The **WarningsAsErrors** and **WarningsNotAsErrors** options override the **TreatWarningsAsErrors** option for a list of warnings.

Enable warnings 0219 and 0168 as errors:

```xml
<WarningsAsErrors>0219,0168</WarningsAsErrors>
```

Disable the same warnings as errors:

```xml
<WarningsNotAsErrors>0219,0168</WarningsNotAsErrors>
```

You use **WarningsAsErrors** to configure a set of warnings as errors. Use **WarningsNotAsErrors** to configure a set of warnings that should not be errors when you've set all warnings as errors.

## DisabledWarnings

The **DisabledWarnings** option lets you suppress the compiler from displaying one or more warnings. Separate multiple warning numbers with a comma.

```xml
<DisabledWarnings>number1, number2</DisabledWarnings>
```

`number1`, `number2` Warning number(s) that you want the compiler to suppress. You specify the numeric part of the warning identifier. For example, if you want to suppress *CS0028*, you could specify `<DisabledWarnings>28</DisabledWarnings>`. The compiler silently ignores warning numbers passed to **DisabledWarnings** that were valid in previous releases, but that have been removed. For example, *CS0679* was valid in the compiler in Visual Studio .NET 2002 but was removed later.

 The following warnings cannot be suppressed by the **DisabledWarnings** option:

- Compiler Warning (level 1) CS2002  
- Compiler Warning (level 1) CS2023
- Compiler Warning (level 1) CS2029

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

The **ErrorLog** option causes the compiler to output a [Static Analysis Results Interchange Format (SARIF) log](https://github.com/microsoft/sarif-tutorials/blob/main/docs/1-Introduction.md#:~:text=What%20is%20SARIF%3F,for%20use%20by%20simpler%20tools). SARIF logs are typically read by tools that analyze the results from compiler and analyzer diagnostics.

## ReportAnalyzer

Report additional analyzer information, such as execution time.

```xml
<ReportAnalyzer>true</ReportAnalyzer>
```

The **ReportAnalyzer** option causes the compiler to emit extra MSBuild log information that details the performance characteristics of analyzers in the build. It's typically used by analyzer authors as part of validating the analyzer.
