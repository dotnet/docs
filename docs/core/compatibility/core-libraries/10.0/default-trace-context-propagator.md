---
title: "Breaking change - Default trace context propagator updated to W3C standard"
description: "Learn about the breaking change in .NET 10 where the default trace context propagator is switched from Legacy to W3C."
ms.date: 4/21/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/45793
ms.topic: how-to
---

# Default trace context propagator updated to W3C standard

The default trace context propagator has been switched from the legacy propagator to the W3C propagator. The new propagator uses the `baggage` header instead of `Correlation-Context`, enforces W3C-compliant encoding, and supports only W3C-formatted trace parent IDs.

## Version introduced

.NET 10 Preview 4

## Previous behavior

The <xref:System.Diagnostics.DistributedContextPropagator.CreateDefaultPropagator?displayProperty=nameWithType> method returned an instance of the legacy propagator. By default, <xref:System.Diagnostics.DistributedContextPropagator.Current?displayProperty=nameWithType> was set to this legacy instance.

## New behavior

The <xref:System.Diagnostics.DistributedContextPropagator.CreateDefaultPropagator?displayProperty=nameWithType> method now returns an instance of the W3C propagator. By default, <xref:System.Diagnostics.DistributedContextPropagator.Current?displayProperty=nameWithType> is set to this W3C instance.

Example of setting the default propagator to the legacy propagator:

```csharp
DistributedContextPropagator.Current = DistributedContextPropagator.CreatePreW3CPropagator();
```

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change ensures full compliance with the W3C Trace Context and Baggage specifications. The W3C propagator enforces strict formatting for trace parent, trace state, and baggage keys and values, aligning with the W3C standards. The legacy propagator was more lenient and used the non-standard `Correlation-Context` header for baggage propagation.

For more details, see the following GitHub issues:

- [Pull Request #114583](https://github.com/dotnet/runtime/pull/114583)
- [Issue #114584](https://github.com/dotnet/runtime/issues/114584)

## Recommended action

If you need to retain the legacy behavior, use the `DistributedContextPropagator.CreatePreW3CPropagator()` method to retrieve the legacy propagator instance. Set it as the current propagator as shown below:

```csharp
DistributedContextPropagator.Current = DistributedContextPropagator.CreatePreW3CPropagator();
```

## Affected APIs

- <xref:System.Diagnostics.DistributedContextPropagator.Current?displayProperty=fullName>
- <xref:System.Diagnostics.DistributedContextPropagator.CreateDefaultPropagator?displayProperty=fullName>
