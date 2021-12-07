---
title: Code analysis in .NET
titleSuffix: ""
description: Learn about source code analysis in the .NET SDK.
ms.date: 11/08/2021
ms.topic: overview
ms.custom: updateeachrelease
helpviewer_keywords:
  - code analysis
  - code analyzers
---
# Overview of .NET source code analysis

.NET compiler platform (Roslyn) analyzers inspect your C# or Visual Basic code for code quality and style issues. Starting in .NET 5, these analyzers are included with the .NET SDK and you don't need to install them separately. If your project targets .NET 5 or later, code analysis is enabled by default. If your project targets a different .NET implementation, for example, .NET Core, .NET Standard, or .NET Framework, you must manually enable code analysis by setting the [EnableNETAnalyzers](../../core/project-sdk/msbuild-props.md#enablenetanalyzers) property to `true`.

If you don't want to move to the .NET 5+ SDK, have a non-SDK-style .NET Framework project, or prefer a NuGet package-based model, the analyzers are also available in the [Microsoft.CodeAnalysis.NetAnalyzers NuGet package](https://www.nuget.org/packages/Microsoft.CodeAnalysis.NetAnalyzers). You might prefer a package-based model for on-demand version updates.

> [!NOTE]
> .NET analyzers are target-framework agnostic. That is, your project does not need to target a specific .NET implementation. The analyzers work for projects that target .NET 5+ as well as earlier .NET versions, such as .NET Core 3.1 and .NET Framework 4.7.2. However, to enable code analysis using the [EnableNETAnalyzers](../../core/project-sdk/msbuild-props.md#enablenetanalyzers) property, your project must reference a [project SDK](../../core/project-sdk/overview.md).

If rule violations are found by an analyzer, they're reported as a suggestion, warning, or error, depending on how each rule is [configured](configuration-options.md). Code analysis violations appear with the prefix "CA" or "IDE" to differentiate them from compiler errors.

## Code quality analysis

*Code quality analysis* ("CAxxxx") rules inspect your C# or Visual Basic code for security, performance, design and other issues. Analysis is enabled, by default, for projects that target .NET 5 or later. You can enable code analysis on projects that target earlier .NET versions by setting the [EnableNETAnalyzers](../../core/project-sdk/msbuild-props.md#enablenetanalyzers) property to `true`. You can also disable code analysis for your project by setting `EnableNETAnalyzers` to `false`.

> [!TIP]
> If you're using Visual Studio, many analyzer rules have associated *code fixes* that you can apply to correct the problem. Code fixes are shown in the light bulb icon menu.

### Enabled rules

The following rules are enabled, by default, in .NET 6.

| Diagnostic ID | Category | Severity | Description |
| - | - | - | - |
| [CA1416](quality-rules/ca1416.md) | Interoperability | Warning | Platform compatibility analyzer |
| [CA1417](quality-rules/ca1417.md) | Interoperability | Warning | Do not use `OutAttribute` on string parameters for P/Invokes |
| [CA1418](quality-rules/ca1418.md) | Interoperability | Warning | Use valid platform string |
| [CA1831](quality-rules/ca1831.md) | Performance | Warning | Use `AsSpan` instead of range-based indexers for string when appropriate |
| [CA2013](quality-rules/ca2013.md) | Reliability | Warning | Do not use `ReferenceEquals` with value types |
| [CA2014](quality-rules/ca2014.md) | Reliability | Warning | Do not use `stackalloc` in loops |
| [CA2015](quality-rules/ca2015.md) | Reliability | Warning | Do not define finalizers for types derived from <xref:System.Buffers.MemoryManager%601> |
| CA2017 | Reliability | Warning | Parameter count mismatch |
| [CA2018](quality-rules/ca2018.md) | Reliability | Warning | The `count` argument to `Buffer.BlockCopy` should specify the number of bytes to copy |
| [CA2200](quality-rules/ca2200.md) | Usage | Warning | Rethrow to preserve stack details |
| [CA2252](quality-rules/ca2252.md) | Usage | Error | Opt in to preview features |
| [CA2247](quality-rules/ca2247.md) | Usage | Warning | Argument passed to `TaskCompletionSource` constructor should be <xref:System.Threading.Tasks.TaskCreationOptions> enum instead of <xref:System.Threading.Tasks.TaskContinuationOptions> |
| [CA2255](quality-rules/ca2255.md) | Usage | Warning | The `ModuleInitializer` attribute should not be used in libraries |
| CA2256 | Usage | Warning | All members declared in parent interfaces must have an implementation in a `DynamicInterfaceCastableImplementation`-attributed interface |
| CA2257 | Usage | Warning | Members defined on an interface with the `DynamicInterfaceCastableImplementationAttribute` should be `static` |
| CA2258 | Usage | Warning | Providing a `DynamicInterfaceCastableImplementation` interface in Visual Basic is unsupported |

You can change the severity of these rules to disable them or elevate them to errors. You can also [enable more rules](#enable-additional-rules).

- For a list of rules that are included with each .NET SDK version, see [Analyzer releases](https://github.com/dotnet/roslyn-analyzers/blob/main/src/NetAnalyzers/Core/AnalyzerReleases.Shipped.md).
- For a list of all the code quality rules, see [Code quality rules](quality-rules/index.md).

### Enable additional rules

*Analysis mode* refers to a predefined code analysis configuration where none, some, or all rules are enabled. In the default analysis mode, only a small number of rules are [enabled as build warnings](#enabled-rules). You can change the analysis mode for your project by setting the [\<AnalysisMode>](../../core/project-sdk/msbuild-props.md#analysismode) property in the project file. The allowable values are:

:::row:::
    :::column:::
        `None`
    :::column-end:::
    :::column:::
        `Default`
    :::column-end:::
    :::column:::
        `Minimum`
    :::column-end:::
    :::column:::
        `Recommended`
    :::column-end:::
    :::column:::
        `All`
    :::column-end:::
:::row-end:::

Starting in .NET 6, you can omit [\<AnalysisMode>](../../core/project-sdk/msbuild-props.md#analysismode) in favor of a compound value for the \<AnalysisLevel> property. For example, the following value enables the recommended set of rules for the latest release: `<AnalysisLevel>latest-Recommended</AnalysisLevel>`. For more information, see [AnalysisLevel](../../core/project-sdk/msbuild-props.md#analysislevel).

To find the default severity for each available rule and whether or not the rule is enabled in the default analysis mode, see the [full list of rules](https://github.com/dotnet/roslyn-analyzers/blob/main/src/NetAnalyzers/Core/AnalyzerReleases.Shipped.md).

### Treat warnings as errors

If you use the `-warnaserror` flag when you build your projects, all code analysis warnings are also treated as errors. If you do not want code quality warnings (CAxxxx) to be treated as errors in presence of `-warnaserror`, you can set the `CodeAnalysisTreatWarningsAsErrors` MSBuild property to `false` in your project file.

```xml
<PropertyGroup>
  <CodeAnalysisTreatWarningsAsErrors>false</CodeAnalysisTreatWarningsAsErrors>
</PropertyGroup>
```

You'll still see any code analysis warnings, but they won't break your build.

### Latest updates

By default, you'll get the latest code analysis rules and default rule severities as you upgrade to newer versions of the .NET SDK. If you don't want this behavior, for example, if you want to ensure that no new rules are enabled or disabled, you can override it in one of the following ways:

- Set the `AnalysisLevel` MSBuild property to a specific value to lock the warnings to that set. When you upgrade to a newer SDK, you'll still get bug fixes for those warnings, but no new warnings will be enabled and no existing warnings will be disabled. For example, to lock the set of rules to those that ship with version 5.0 of the .NET SDK, add the following entry to your project file.

  ```xml
  <PropertyGroup>
    <AnalysisLevel>5.0</AnalysisLevel>
  </PropertyGroup>
  ```

  > [!TIP]
  > The default value for the `AnalysisLevel` property is `latest`, which means you always get the latest code analysis rules as you move to newer versions of the .NET SDK.

  For more information, and to see a list of possible values, see [AnalysisLevel](../../core/project-sdk/msbuild-props.md#analysislevel).

- Install the [Microsoft.CodeAnalysis.NetAnalyzers NuGet package](https://github.com/dotnet/roslyn-analyzers#microsoftcodeanalysisnetanalyzers) to decouple rule updates from .NET SDK updates. For projects that target .NET 5+, installing the package turns off the built-in SDK analyzers. You'll get a build warning if the SDK contains a newer analyzer assembly version than that of the NuGet package. To disable the warning, set the `_SkipUpgradeNetAnalyzersNuGetWarning` property to `true`.

  > [!NOTE]
  > If you install the Microsoft.CodeAnalysis.NetAnalyzers NuGet package, you should not add the [EnableNETAnalyzers](../../core/project-sdk/msbuild-props.md#enablenetanalyzers) property to either your project file or a *Directory.Build.props* file. When the NuGet package is installed and the `EnableNETAnalyzers` property is set to `true`, a build warning is generated.

## Code-style analysis

*Code-style analysis* ("IDExxxx") rules enable you to define and maintain consistent code style in your codebase. The default enablement settings are:

- Command-line build: Code-style analysis is disabled, by default, for all .NET projects on command-line builds.

  Starting in .NET 5, you can [enable code-style analysis on build](#enable-on-build), both at the command line and inside Visual Studio. Code style violations appear as warnings or errors with an "IDE" prefix. This enables you to enforce consistent code styles at build time.

- Visual Studio: Code-style analysis is enabled, by default, for all .NET projects inside Visual Studio as [code refactoring quick actions](/visualstudio/ide/code-generation-in-visual-studio).

For a full list of code-style analysis rules, see [Code style rules](style-rules/index.md).

### Enable on build

With the .NET 5 SDK and later versions, you can enable code-style analysis when building from the command-line and in Visual Studio. (However, for performance reasons, [a handful of code-style rules](https://github.com/dotnet/roslyn/blob/9f87b444da9c48a4d492b19f8337339056bf2b95/src/Analyzers/Core/Analyzers/EnforceOnBuildValues.cs#L95) will still apply only in the Visual Studio IDE.)

Follow these steps to enable code-style analysis on build:

1. Set the MSBuild property [EnforceCodeStyleInBuild](../../core/project-sdk/msbuild-props.md#enforcecodestyleinbuild) to `true`.

1. In an *.editorconfig* file, [configure](configuration-options.md) each "IDE" code style rule that you wish to run on build as a warning or an error. For example:

   ```ini
   [*.{cs,vb}]
   # IDE0040: Accessibility modifiers required (escalated to a build warning)
   dotnet_diagnostic.IDE0040.severity = warning
   ```

   Alternatively, you can configure an entire category to be a warning or error, by default, and then selectively turn off rules in that category that you don't want to run on build. For example:

   ```ini
   [*.{cs,vb}]

   # Default severity for analyzer diagnostics with category 'Style' (escalated to build warnings)
   dotnet_analyzer_diagnostic.category-Style.severity = warning

   # IDE0040: Accessibility modifiers required (disabled on build)
   dotnet_diagnostic.IDE0040.severity = silent
   ```

> [!NOTE]
> The code-style analysis feature is experimental and may change between the .NET 5 and .NET 6 releases.

## Suppress a warning

One way to suppress a rule violation is to set the severity option for that rule ID to `none` in an EditorConfig file. For example:

```ini
dotnet_diagnostic.CA1822.severity = none
```

For more information and other ways to suppress warnings, see [How to suppress code analysis warnings](suppress-warnings.md).

## Run code analysis as a GitHub Action

The [dotnet/code-analysis](https://github.com/dotnet/code-analysis) GitHub Action lets you run .NET code analyzers as part of continuous integration (CI) in an offline mode. For more information, see [.NET code analysis GitHub Action](../../devops/dotnet-github-action-reference.md#net-code-analysis).

## Third-party analyzers

In addition to the official .NET analyzers, you can also install third party analyzers, such as [StyleCop](https://www.nuget.org/packages/StyleCop.Analyzers/), [Roslynator](https://www.nuget.org/packages/Roslynator.Analyzers/), [XUnit Analyzers](https://www.nuget.org/packages/xunit.analyzers/), and [Sonar Analyzer](https://www.nuget.org/packages/SonarAnalyzer.CSharp/).

## See also

- [Code quality analysis rule reference](quality-rules/index.md)
- [Code style analysis rule reference](style-rules/index.md)
- [Code analysis in Visual Studio](/visualstudio/code-quality/roslyn-analyzers-overview)
- [.NET Compiler Platform SDK](../../csharp/roslyn-sdk/index.md)
- [Tutorial: Write your first analyzer and code fix](../../csharp/roslyn-sdk/tutorials/how-to-write-csharp-analyzer-code-fix.md)
