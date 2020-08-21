---
title: Code analysis in .NET
titleSuffix: ""
description: Learn about source code analysis in .NET.
ms.date: 08/20/2020
ms.topic: overview
helpviewer_keywords:
- code analysis
- code analyzers
---
# Overview of .NET source code analysis

.NET code analyzers inspect your C# or Visual Basic code for security, performance, design, and other issues. Starting in .NET 5.0, these analyzers are included with the .NET SDK. You can also install third party analyzers, such as [StyleCop](https://www.nuget.org/packages/StyleCop.Analyzers/), [Roslynator](https://www.nuget.org/packages/Roslynator.Analyzers/), [XUnit Analyzers](https://www.nuget.org/packages/xunit.analyzers/), and [Sonar Analyzer](https://www.nuget.org/packages/SonarAnalyzer.CSharp/).

> [!TIP]
> In previous versions of .NET, you can install the .NET code analyzers as a [NuGet package](https://www.nuget.org/packages/Microsoft.CodeAnalysis.FxCopAnalyzers). For more information, see [Install code analyzers](/visualstudio/code-quality/install-fxcop-analyzers).

If rule violations are found by an analyzer, they're reported as a suggestion, warning, or error, depending on how each rule is [configured](configure-code-analysis-rules.md). Code analysis violations appear with the prefix "CA" or "IDE" to differentiate them from compiler errors. The verbosity of the build output does not affect whether rule violations are shown.

If you're using Visual Studio, many analyzer rules have associated *code fixes* that you can apply to correct the problem. Code fixes are shown in the light bulb icon menu.

## See also

- [Code analysis in Visual Studio](/visualstudio/code-quality/roslyn-analyzers-overview)
- [Code analysis rule reference](/visualstudio/code-quality/code-analysis-for-managed-code-warnings)
- [Tutorial: Write your first analyzer and code fix](../../csharp/roslyn-sdk/tutorials/how-to-write-csharp-analyzer-code-fix.md)
- [.NET Compiler Platform SDK](../../csharp/roslyn-sdk/index.md)
