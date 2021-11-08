---
title: "Breaking change: CA2014: Do not use stackalloc in loops"
description: Learn about the breaking change in .NET 5 caused by the enablement of code analysis rule CA2014.
ms.date: 09/03/2020
---
# Warning CA2014: Do not use stackalloc in loops

.NET code analyzer rule [CA2014](/visualstudio/code-quality/ca2014) is enabled, by default, starting in .NET 5. It produces a build warning for any C# code where a [stackalloc](../../../../csharp/language-reference/operators/stackalloc.md) expression is used inside a loop.

## Change description

Starting in .NET 5, the .NET SDK includes [.NET source code analyzers](../../../../fundamentals/code-analysis/overview.md). Several of these rules are enabled, by default, including [CA2014](/visualstudio/code-quality/ca2014). If your project contains code that violates this rule and is configured to treat warnings as errors, this change could break your build.

Rule CA2014 looks for C# code where a [stackalloc expression](../../../../csharp/language-reference/operators/stackalloc.md) is used inside a loop. [stackalloc](../../../../csharp/language-reference/operators/stackalloc.md) allocates memory from the current stack frame. The memory isn't released until the current method call returns, which can lead to stack overflows. Because you can't catch stack overflow exceptions, the app will terminate in case of stack overflow.

## Version introduced

5.0

## Recommended action

- Avoid using [stackalloc](../../../../csharp/language-reference/operators/stackalloc.md) inside loops. Allocate the memory block outside the loop and reuse it inside the loop. For more information, see [CA2014](/visualstudio/code-quality/ca2014).

- To disable code analysis completely, set `EnableNETAnalyzers` to `false` in your project file. For more information, see [EnableNETAnalyzers](../../../project-sdk/msbuild-props.md#enablenetanalyzers).

## Affected APIs

Not detectable via API analysis.

<!--

### Affected APIs

Not detectable via API analysis.

### Category

Code analysis

-->
