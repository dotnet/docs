---
title: ".NET 6 breaking change: EventSource callback behavior"
description: Learn about the .NET 6 servicing breaking change in core .NET libraries where the 'EventSource' is marked as disabled before the callback is issue for an 'EventCommand.Disable'.
ms.date: 06/15/2023
ms.topic: article
---
# EventSource callback behavior

For an <xref:System.Diagnostics.Tracing.EventCommand.Disable?displayProperty=nameWithType>, the <xref:System.Diagnostics.Tracing.EventSource> is now marked as disabled *before* the callback is issued.

## Previous behavior

Previously, the <xref:System.Diagnostics.Tracing.EventSource.OnEventCommand(System.Diagnostics.Tracing.EventCommandEventArgs)?displayProperty=nameWithType> callback was issued for an <xref:System.Diagnostics.Tracing.EventCommand.Disable?displayProperty=nameWithType> prior to setting `m_eventSourceEnabled=false`.

This meant that <xref:System.Diagnostics.Tracing.EventSource.IsEnabled?displayProperty=nameWithType> returned `true` in the <xref:System.Diagnostics.Tracing.EventSource.OnEventCommand(System.Diagnostics.Tracing.EventCommandEventArgs)> callback for a user <xref:System.Diagnostics.Tracing.EventSource>, even if the command led to the `EventSource` being disabled. The callback happened after the ability to dispatch events was turned off though, so even if an `EventSource` tried to fire an event, it wasn't written.

## New behavior

Now, the <xref:System.Diagnostics.Tracing.EventSource> is marked as disabled *before* the callback is issued for an <xref:System.Diagnostics.Tracing.EventCommand.Disable?displayProperty=nameWithType>.

## Version introduced

- .NET 6 servicing
- .NET 7 servicing

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was necessary to support multiple <xref:System.Diagnostics.Tracing.EventCounter> instances. The ability to have multiple instances has been requested by multiple customers.

In addition, <xref:System.Diagnostics.Tracing.EventCommand.Enable?displayProperty=nameWithType> has always issued a consistent view: <xref:System.Diagnostics.Tracing.EventSource.IsEnabled?displayProperty=nameWithType> accurately reports the enabled status, and `EventSource` can write events from the `OnEventCommand` callback. This change makes the `EventCommand.Disable` behavior consistent with `EventCommand.Enable`.

## Recommended action

It's unlikely that there's a scenario where the previous behavior is desired, and there's no way to revert the behavior.

## Affected APIs

- <xref:System.Diagnostics.Tracing.EventCommand.Disable?displayProperty=fullName>
