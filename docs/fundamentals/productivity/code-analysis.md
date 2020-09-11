---
title: Code analysis in .NET
titleSuffix: ""
description: Learn about source code analysis in the .NET SDK.
ms.date: 08/22/2020
ms.topic: overview
ms.custom: updateeachrelease
helpviewer_keywords:
  - code analysis
  - code analyzers
---
# Overview of .NET source code analysis

.NET compiler platform (Roslyn) analyzers inspect your C# or Visual Basic code for code quality and code style issues. Starting in .NET 5.0, these analyzers are included with the .NET SDK. (Previously, you installed code quality analyzers as a [NuGet package](https://www.nuget.org/packages/Microsoft.CodeAnalysis.FxCopAnalyzers), and code style analyzers were installed with Visual Studio.)

- [Code quality analysis ("CAxxxx" rules)](#code-quality-analysis)
- [Code style analysis ("IDExxxx" rules)](#code-style-analysis)

If rule violations are found by an analyzer, they're reported as a suggestion, warning, or error, depending on how each rule is [configured](configure-code-analysis-rules.md). Code analysis violations appear with the prefix "CA" or "IDE" to differentiate them from compiler errors.

> [!TIP]
>
> - You can also install third party analyzers, such as [StyleCop](https://www.nuget.org/packages/StyleCop.Analyzers/), [Roslynator](https://www.nuget.org/packages/Roslynator.Analyzers/), [XUnit Analyzers](https://www.nuget.org/packages/xunit.analyzers/), and [Sonar Analyzer](https://www.nuget.org/packages/SonarAnalyzer.CSharp/).
> - If you're using Visual Studio, many analyzer rules have associated *code fixes* that you can apply to correct the problem. Code fixes are shown in the light bulb icon menu.

## Code quality analysis

_Code quality analysis ("CA") rules_ inspect your C# or Visual Basic code for security, performance, design and other issues. Analysis is enabled, by default, for projects that target .NET 5.0 or later. You can enable code analysis on projects that target earlier .NET versions by setting the [EnableNETAnalyzers](../../core/project-sdk/msbuild-props.md#enablenetanalyzers) property to `true`. You can also disable code analysis for your project by setting `EnableNETAnalyzers` to `false`.

> [!TIP]
> In Visual Studio, you can enable or disable code analysis using the Project Properties window. To access the Project Properties window, right-click on a project within Solution Explorer and select **Properties**. Next, select the **Code Analysis** tab, and then either select or clear the checkbox to **Enable .NET analyzers**.

### Enabled rules

The following rules are enabled, by default, in .NET 5.0 Preview 8.

| Diagnostic ID | Category | Severity | Description |
| - | - | - | - |
| [CA1417](/visualstudio/code-quality/ca1417) | Interoperability | Warning | Do not use `OutAttribute` on string parameters for P/Invokes |
| [CA1831](/visualstudio/code-quality/ca1831) | Performance | Warning | Use `AsSpan` instead of range-based indexers for string when appropriate |
| [CA2013](/visualstudio/code-quality/ca2013) | Reliability | Warning | Do not use `ReferenceEquals` with value types |
| [CA2014](/visualstudio/code-quality/ca2014) | Reliability | Warning | Do not use `stackalloc` in loops |
| [CA2015](/visualstudio/code-quality/ca2015) | Reliability | Warning | Do not define finalizers for types derived from <xref:System.Buffers.MemoryManager%601> |
| [CA2247](/visualstudio/code-quality/ca2247) | Usage | Warning | Argument passed to TaskCompletionSource constructor should be <xref:System.Threading.Tasks.TaskCreationOptions> enum instead of <xref:System.Threading.Tasks.TaskContinuationOptions> |

You can change the severity of these rules to disable them or elevate them to errors.

### Enable additional rules

Starting with .NET 5.0 RC2, the .NET SDK ships with all of the ["CA" code quality rules](/visualstudio/code-quality/code-analysis-for-managed-code-warnings). For a full list of rules that are included with each .NET SDK version, see [analyzer releases](https://github.com/dotnet/roslyn-analyzers/blob/master/src/NetAnalyzers/Core/AnalyzerReleases.Shipped.md).

#### Default analysis mode

In the default analysis mode, some rules are [enabled by default](#enabled-rules) as build warnings. Some other rules are enabled by default only as Visual Studio IDE suggestions with corresponding code fixes. The remaining rules are disabled by default. The [full list of rules](https://github.com/dotnet/roslyn-analyzers/blob/master/src/NetAnalyzers/Core/AnalyzerReleases.Shipped.md) includes each rule's default severity and whether or not the rule is enabled by default in the default analysis mode.

#### Custom analysis mode

You can [configure code analysis rules](configure-code-analysis-rules.md) to enable or disable an individual rule or a category of rules. Additionally, you can use the [AnalysisMode](../../core/project-sdk/msbuild-props.md#analysismode) property to switch to one of the following custom analysis modes:

- _Aggressive_ or _Opt-out_ mode: All rules are enabled by default as build warnings. You can selectively [opt out](configure-code-analysis-rules.md) of individual rules to disable them.
- _Conservative_ or _Opt-in_ mode: All rules are disabled by default. You can selectively [opt into](configure-code-analysis-rules.md) individual rules to enable them.

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

- Install the [Microsoft.CodeAnalysis.NetAnalyzers NuGet package](https://github.com/dotnet/roslyn-analyzers#microsoftcodeanalysisnetanalyzers) to decouple rule updates from .NET SDK updates. Installing the package turns off the built-in SDK analyzers and generates a build warning if the SDK contains a newer analyzer assembly version than that of the NuGet package.

## Code style analysis

_[Code style analysis](/visualstudio/ide/editorconfig-code-style-settings-reference) ("IDExxxx" rules)_ enables you to define and maintain consistent code style in your codebase. Following are the default settings:

- Command line build: Code style analysis is disabled, by default, for all .NET projects on command-line builds.
- Visual Studio: Code style analysis is enabled, by default, for all .NET projects inside Visual Studio as [code refactoring quick actions](/visualstudio/ide/code-generation-in-visual-studio).

Starting .NET 5.0 RC2, you can enable code style analysis on build, both at the command line and inside Visual Studio. Code style violations appear as warnings or errors with an "IDE" prefix. This enables you to enforce consistent code styles at build time.

Steps to enable code style analysis on build:

1. Set the MSBuild property [EnforceCodeStyleInBuild](../../core/project-sdk/msbuild-props.md#enforcecodestyleinbuild) to `true`.
2. [Configure](configure-code-analysis-rules.md) each "IDE" code style rule that you wish to run on build as a warning or an error. For example:

   ```ini
   [*.{cs,vb}]
   # IDE0040: Accessibility modifiers required (escalated to a build warning)
   dotnet_diagnostic.IDE0040.severity = warning
   ```

   Alternatively, you can [configure the entire "Style" category](configure-code-analysis-rules.md#configure-multiple-rules) to be a warning or error, by default, and then selectively turn off rules that you don't want to run on build. For example:

   ```ini
   [*.{cs,vb}]
  
   # Default severity for analyzer diagnostics with category 'Style' (escalated to build warnings)
   dotnet_analyzer_diagnostic.category-Style.severity = warning

   # IDE0040: Accessibility modifiers required (disabled on build)
   dotnet_diagnostic.IDE0040.severity = silent
   ```

## See also

- [Code analysis in Visual Studio](/visualstudio/code-quality/roslyn-analyzers-overview)
- [Code quality analysis rule reference](/visualstudio/code-quality/code-analysis-for-managed-code-warnings)
- [Code style analysis rule reference](/visualstudio/ide/editorconfig-code-style-settings-reference)
- [.NET Compiler Platform SDK](../../csharp/roslyn-sdk/index.md)
- [Tutorial: Write your first analyzer and code fix](../../csharp/roslyn-sdk/tutorials/how-to-write-csharp-analyzer-code-fix.md)
