---
title: Choosing diagnostic IDs
description: This overview provides an understanding of how to choose a diagnostic ID
ms.date: 11/2/2023
---

# Choose diagnostic IDs

A diagnostic ID is the string associated with a given diagnostic, such as a
compiler error or a diagnostic that is produced by an analyzer.

The IDs are surfaced from various APIs, such as:

* <xref:Microsoft.CodeAnalysis.DiagnosticDescriptor.Id?displayProperty=nameWithType>
* <xref:System.ObsoleteAttribute.DiagnosticId?displayProperty=nameWithType>
* <xref:System.Diagnostics.CodeAnalysis.ExperimentalAttribute.DiagnosticId?displayProperty=nameWithType>

Diagnostic IDs are also used as identifiers in source, for example, from
[#pragma warning disable] or [.editorconfig] files.

## Considerations

* Diagnostic IDs should be unique
* Diagnostic IDs must be legal identifiers in C#
* Diagnostic IDs should be less than 15 characters long
* Diagnostic IDs should be of the form `<PREFIX><number>`
  - The prefix is specific to your project
  - The number represents the specific diagnostic

> [!NOTE]
> It's a source breaking change to change diagnostic IDs, as existing
> suppressions would be ignored if the ID changed.

Don't limit your prefix to two-characters (such as `CSXXX`and `CAXXXX`).
Instead, use a longer prefix to avoid conflicts. For example, the `System.*`
diagnostics use `SYSLIB` as their prefix.

[#pragma warning disable]: ../language-reference/preprocessor-directives.md#pragma-warning
[.editorconfig]: ../../fundamentals/code-analysis/code-style-rule-options.md
