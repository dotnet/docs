---
title: "Breaking change: CA2015: Do not define finalizers for types derived from MemoryManager<T>"
description: Learn about the breaking change in .NET 5 caused by the enablement of code analysis rule CA2015.
ms.date: 09/03/2020
---
# Warning CA2015: Do not define finalizers for types derived from MemoryManager\<T>

.NET code analyzer rule [CA2015](/visualstudio/code-quality/ca2015) is enabled, by default, starting in .NET 5. It produces a build warning for any types that derive from <xref:System.Buffers.MemoryManager%601> that define a finalizer.

## Change description

Starting in .NET 5, the .NET SDK includes [.NET source code analyzers](../../../../fundamentals/code-analysis/overview.md). Several of these rules are enabled, by default, including [CA2015](/visualstudio/code-quality/ca2015). If your project contains code that violates this rule and is configured to treat warnings as errors, this change could break your build.

Rule CA2015 flags types that derive from <xref:System.Buffers.MemoryManager%601> that define a finalizer. Adding a finalizer to a type that derives from <xref:System.Buffers.MemoryManager%601> is likely an indication of a bug. It suggests that a native resource that could have been obtained in a <xref:System.Span%601> is getting cleaned up, potentially while it's still in use by the <xref:System.Span%601>.

## Version introduced

5.0

## Recommended action

- Remove the finalizer definition. For more information, see [CA2015](/visualstudio/code-quality/ca2015).

- To disable code analysis completely, set `EnableNETAnalyzers` to `false` in your project file. For more information, see [EnableNETAnalyzers](../../../project-sdk/msbuild-props.md#enablenetanalyzers).

## Affected APIs

Not detectable via API analysis.

<!--

### Affected APIs

Not detectable via API analysis.

### Category

Code analysis

-->
