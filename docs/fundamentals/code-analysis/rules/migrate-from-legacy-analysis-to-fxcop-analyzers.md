---
title: Migrate from legacy analysis (FxCop) to source analysis (FxCop analyzers)
description: "Learn how to analyze code for the first time or how to migrate from binary analysis (FxCop) to the new way of analyzing managed code using source analysis (FxCop analyzers)."
ms.date: 03/06/2020
ms.topic: conceptual
f1_keywords:
 - "vs.projectpropertypages.codeanalysis"
helpviewer_keywords:
- FxCop, migration
- legacy analysis, migration
- source code analysis, migration
author: mikejo5000
ms.author: mikejo
manager: jillfra
---

# Migrate from legacy analysis (FxCop) to source analysis (FxCop analyzers)

Source analysis by .NET Compiler Platform ("Roslyn") analyzers replaces [legacy analysis](../code-quality/code-analysis-for-managed-code-overview.md) for managed code. For newer project templates such as .NET Core and .NET Standard projects, legacy analysis is not available.

Many of the legacy analysis (FxCop) rules have already been rewritten for FxCop analyzers, a set of Roslyn code analyzers. You [install FxCop analyzers as a NuGet package](install-fxcop-analyzers.md#nuget-package) that's referenced by the project or solution. FxCop analyzers run source-code based analysis during compiler execution. Analyzer results are reported along with compiler results.

For more information on the differences between legacy analysis and source analysis, see the following:

- [Source code analysis versus legacy analysis](../code-quality/fxcop-analyzers-faq.md#whats-the-difference-between-legacy-fxcop-and-fxcop-analyzers)

- [FAQ about FxCop analyzers](../code-quality/fxcop-analyzers-faq.md)

To migrate to source analysis, [install the FxCop analyzers](../code-quality/install-fxcop-analyzers.md). Like legacy analysis rule violations, source code analysis violations appear in the Error List window in Visual Studio. In addition, source code analysis violations also show up in the code editor as *squiggles* under the offending code. The color of the squiggle depends on the [severity setting](../code-quality/use-roslyn-analyzers.md#configure-severity-levels) of the rule. To see the status of rules ported to the new FxCop analyzers, see [Ported and unported rules](../code-quality/fxcop-rule-port-status.md).

To learn more about how to configure the FxCop analyzers:

- To configure FxCop analyzers, see [Configure FxCop analyzers](../code-quality/configure-fxcop-analyzers.md).

- To find out about configuring analyzers using predefined rules with EditorConfig or a rule set file, see [Enable a category of rules](../code-quality/analyzer-rule-sets.md).