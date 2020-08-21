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

.NET code analyzers inspect your C# or Visual Basic code for security, performance, design, and other issues. Starting in .NET 5.0, these analyzers are included with the .NET SDK. (Previously, you installed these analyzers as a [NuGet package](https://www.nuget.org/packages/Microsoft.CodeAnalysis.FxCopAnalyzers).)

If rule violations are found by an analyzer, they're reported as a suggestion, warning, or error, depending on how each rule is [configured](configure-code-analysis-rules.md). Code analysis violations appear with the prefix "CA" or "IDE" to differentiate them from compiler errors.

> [!TIP]
>
> - You can also install third party analyzers, such as [StyleCop](https://www.nuget.org/packages/StyleCop.Analyzers/), [Roslynator](https://www.nuget.org/packages/Roslynator.Analyzers/), [XUnit Analyzers](https://www.nuget.org/packages/xunit.analyzers/), and [Sonar Analyzer](https://www.nuget.org/packages/SonarAnalyzer.CSharp/).
> - If you're using Visual Studio, many analyzer rules have associated *code fixes* that you can apply to correct the problem. Code fixes are shown in the light bulb icon menu.

## Enabled rules

The following rules are enabled, by default, in .NET 5.0 Preview 8.

| Diagnostic ID | Category | Severity | Description |
| - | - | - | - |
| [CA1417](/visualstudio/code-quality/ca1417) | Interoperability | Warning | Do not use `OutAttribute` on string parameters for P/Invokes |
| [CA1831](/visualstudio/code-quality/ca1831) | Performance | Warning | Use `AsSpan` instead of range-based indexers for string when appropriate |
| [CA2013](/visualstudio/code-quality/ca2013) | Reliability | Warning | Do not use `ReferenceEquals` with value types |
| [CA2014](/visualstudio/code-quality/ca2014) | Reliability | Warning | Do not use `stackalloc` in loops |
| [CA2015](/visualstudio/code-quality/ca2015) | Reliability | Warning | Do not define finalizers for types derived from <xref:System.Buffers.MemoryManager%601> |
| [CA2247](/visualstudio/code-quality/ca2247) | Usage | Warning | Argument passed to TaskCompletionSource constructor should be <xref:System.Threading.Tasks.TaskCreationOptions> enum instead of <xref:System.Threading.Tasks.TaskContinuationOptions> |

You can change the severity of these rules to disable them or elevate them to errors. For more information, see [Configure code analysis rules](configure-code-analysis-rules.md).

## Treat warnings as errors

If you use the `/warnaserror` flag when you build your projects, .NET code analysis warnings are also treated as errors. If you only want compiler warnings to be treated as errors, you can add the set the `CodeAnalysisTreatWarningsAsErrors` MSBuild property to `false` in your project file.

```xml
<PropertyGroup>
  <CodeAnalysisTreatWarningsAsErrors>false</CodeAnalysisTreatWarningsAsErrors>
</PropertyGroup>
```

You'll still see any code analysis warnings, but they won't break your build.

## Latest updates

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

- Install the code analyzers [NuGet package](https://www.nuget.org/packages/Microsoft.CodeAnalysis.FxCopAnalyzers) to decouple rule updates from .NET SDK updates. Installing the package turns off the built-in SDK analyzers and generates a build warning if the SDK contains a newer analyzer assembly version than that of the NuGet package.

## See also

- [Code analysis in Visual Studio](/visualstudio/code-quality/roslyn-analyzers-overview)
- [Code analysis rule reference](/visualstudio/code-quality/code-analysis-for-managed-code-warnings)
- [.NET Compiler Platform SDK](../../csharp/roslyn-sdk/index.md)
- [Tutorial: Write your first analyzer and code fix](../../csharp/roslyn-sdk/tutorials/how-to-write-csharp-analyzer-code-fix.md)
