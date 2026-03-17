---
title: "Breaking change: LoggerMessage source generator diagnostics can't be suppressed with #pragma"
description: Learn about the breaking change in .NET 11 where LoggerMessage source generator diagnostics can no longer be suppressed with #pragma warning disable directives.
ms.date: 03/17/2026
ai-usage: ai-assisted
---

# LoggerMessage source generator diagnostics can't be suppressed with `#pragma`

`LoggerMessage` source generator diagnostics (such as `SYSLIB1002`, `SYSLIB1013`, and `SYSLIB1018`) can no longer be suppressed using `#pragma warning disable` directives.

## Version introduced

.NET 11 Preview 2

## Previous behavior

In previous .NET versions, you could suppress `LoggerMessage` source generator diagnostics using `#pragma warning disable` directives:

```csharp
#pragma warning disable SYSLIB1002
#pragma warning disable SYSLIB1013
#pragma warning disable SYSLIB1018
```

The compiler matched the pragma directives to the diagnostic locations and suppressed them as expected.

## New behavior

`#pragma warning disable` directives no longer suppress diagnostics emitted by the `LoggerMessage` source generator. The diagnostics are still reported, but the compiler can't match them to pragma directives because the diagnostic locations are created without `SyntaxTree` references.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The `LoggerMessage` source generator was refactored to support proper incremental building, which significantly improves source generator performance by avoiding full re-runs on every compilation change. As a side effect, the generator now uses `DiagnosticInfo.GetTrimmedLocation`, which creates diagnostic locations without `SyntaxTree` references. This breaks `#pragma warning disable` matching for diagnostics emitted by the generator.

This aligns `LoggerMessage` behavior with `System.Text.Json` source generator, which already had the same limitation.

## Recommended action

Use project-level `<NoWarn>` in an MSBuild project file instead of `#pragma warning disable` directives:

```xml
<PropertyGroup>
  <NoWarn>$(NoWarn);SYSLIB1002;SYSLIB1013;SYSLIB1018</NoWarn>
</PropertyGroup>
```

Alternatively, use an `.editorconfig` file to suppress diagnostics:

```ini
[*.cs]
dotnet_diagnostic.SYSLIB1002.severity = none
dotnet_diagnostic.SYSLIB1013.severity = none
dotnet_diagnostic.SYSLIB1018.severity = none
```

## Affected APIs

- <xref:Microsoft.Extensions.Logging.LoggerMessageAttribute?displayProperty=fullName>
