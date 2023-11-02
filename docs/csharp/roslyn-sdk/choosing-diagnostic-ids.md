---
title: Choosing diagnostic IDs
description: This overview provides an understanding of how to choose a diagnostic ID
ms.date: 11/2/2023
ms.custom: mvc, vs-dotnet, analyzers, source-generators
---

# Choosing diagnostic IDs

A diagnostic ID is the string associated with a given diagnostic, such as a
compiler error or a diagnostic that is produced by an analyzer.

They are surfaced from various APIs, such as

* [DiagnosticDescriptor.Id]
* [ObsoleteAttribute.DiagnosticId]
* [ExperimentalAttribute.DiagnosticId]

They are also used as identifiers in source, e.g. from [#pragma warning disable]
or [.editorconfig] files.

## Considerations

* Diagnostic IDs should be unique
* Diagnostic IDs must be legal identifiers in C#
* Diagnostic IDs should be less than 15 characters long
* Diagnostic IDs should be of the form `PREFIX123456`
  - The prefix should be specific to your project
  - The number should represent the specific diagnostic

> [!NOTE]
> It's a source breaking change to change diagnostic IDs (e.g. existing
> suppressions would now ignored).

You generally don't want to limit your prefix to two-characters (such as `CSXXX`
and `CAXXXX`) but rather something longer to avoid conflicts. For the `System.*`
diagnostics we use `SYSLIB` for instance.

[DiagnosticDescriptor.Id]: https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.diagnosticdescriptor.id
[ObsoleteAttribute.DiagnosticId]: https://learn.microsoft.com/dotnet/api/system.obsoleteattribute.diagnosticid
[ExperimentalAttribute.DiagnosticId]: https://learn.microsoft.com/dotnet/api/system.diagnostics.codeanalysis.experimentalattribute.diagnosticid
[#pragma warning disable]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/preprocessor-directives#pragma-warning
[.editorconfig]: https://learn.microsoft.com/dotnet/fundamentals/code-analysis/code-style-rule-options
