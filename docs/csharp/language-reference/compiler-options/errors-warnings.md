---
description: "C# Compiler Options for errors and warnings"
title: "C# Compiler Options - errors and warnings"
ms.date: 02/27/2021
f1_keywords: 
  - "cs.build.options"
helpviewer_keywords: 
  - "TreatWarningsAsErrors compiler option [C#]"
  - "WarningsAsErrors compiler option [C#]"
  - "WarningsNotAsErrors compiler option [C#]"
  - "WarningLevel compiler option [C#]"
  - "DisabledWarnings compiler option [C#]"
---
# C# Compiler Options to report errors and warnings

The following options control how the compiler reports errors and warnings. The new MSBuild syntax is shown in **Bold**. The older `csc.exe` syntax is shown in `code style`.

- **TreatWarningsAsErrors** / `-warnaserror`: Treat all warnings as errors
- **WarningsAsErrors** / `-warnaserror`: Treat one or more warnings as errors
- **WarningsNotAsErrors** / `-warnaserror`: Treat one or more warnings not as errors
- **WarningLevel** / `-warn`: Set warning level.
- **DisabledWarnings** / `-nowarn`: Set a list of disabled warnings.
- **??** / `-ruleset`: Specify a ruleset file that disables specific diagnostics.
- **??** / `-errorlog`: Specify a file to log all compiler and analyzer diagnostics.
- **?** / `-reportanalyzer`:  Report additional analyzer information, such as execution time.

## TreatWarningsAsErrors

The **TreatWarningsAsErrors** option treats all warnings as errors. You can also use the **WarningsAsError** to set only some warnings as errors. If you turn on **TreatWarningsAsErrors**, you can use **WarningsNotAsError** to list warnings that should not be treated as errors.

```xml
<TreatWarningsAsErrors></TreatWarningsAsErrors>
```

Any messages that would ordinarily be reported as warnings are instead reported as errors, and the build process is halted (no output files are built). By default, **TreatWarningsAsErrors** isn't in effect, which means warnings don't prevent the generation of an output file. Optionally, if you want only a few specific warnings to be treated as errors, you may specify a comma-separated list of warning numbers to treat as errors. The set of all nullability warnings can be specified with the **Nullable** shorthand. Use **WarningLevel** to specify the level of warnings that you want the compiler to display. Use **DisabledWarnings** to disable certain warnings.

## WarningLevel

The **WarningLevel** option specifies the warning level for the compiler to display.

```xml
<WarningLevel>3</WarningLevel>
```

The element value is the warning level you want displayed for the compilation: Lower numbers show only high severity warnings; higher numbers show more warnings. The value must be zero or a positive integer:

|Warning level|Meaning|
|-------------------|-------------|
|0|Turns off emission of all warning messages.|
|1|Displays severe warning messages.|  
|2|Displays level 1 warnings plus certain, less-severe warnings, such as warnings about hiding class members.|
|3|Displays level 2 warnings plus certain, less-severe warnings, such as warnings about expressions that always evaluate to `true` or `false`.|
|4 (the default)|Displays all level 3 warnings plus informational warnings.|
|5|Displays level 4 warnings plus [additional warnings](https://github.com/dotnet/roslyn/blob/a6013f3213c902c0973b2d371c3007217d610533/docs/compilers/CSharp/Warnversion%20Warning%20Waves.md) from the compiler shipped with C# 9.0.|
|Greater than 5|Any value greater than 5 will be treated as 5. You generally put arbitrary large value (for example, `9999`) to make sure you always have all warnings if the compiler is updated with new warning levels.|

To get information about an error or warning, you can look up the error code in the Help Index. For other ways to get information about an error or warning, see [C# Compiler Errors](../compiler-messages/index.md). Use **TreatWarningsAsErrors** to treat all warnings as errors. Use **DisabledWarnings** to disable certain warnings.  

## DisabledWarnings

The **DisabledWarnings** option lets you suppress the compiler from displaying one or more warnings. Separate multiple warning numbers with a comma.

```xml
<DisabledWarnings>number2, number2</DisabledWarnings>
```

`number1`, `number2` Warning number(s) that you want the compiler to suppress. You should only specify the numeric part of the warning identifier. For example, if you want to suppress *CS0028*, you could specify `<DisabledWarnings>28</DisabledWarnings>`. The compiler will silently ignore warning numbers passed to **DisabledWarnings** that were valid in previous releases, but that have been removed from the compiler. For example, *CS0679* was valid in the compiler in Visual Studio .NET 2002 but was subsequently removed.

 The following warnings cannot be suppressed by the **DisabledWarnings** option:

- Compiler Warning (level 1) CS2002  
- Compiler Warning (level 1) CS2023
- Compiler Warning (level 1) CS2029

## ruleset

TODO

## errorlog

TODO

## reportAnalyzer

TODO
